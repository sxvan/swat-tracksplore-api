using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tracksplore.API.Extensions;
using Tracksplore.API.Models;
using Tracksplore.DataAccess.Models;
using Tracksplore.DataAccess.Services;

namespace Tracksplore.API.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class MusicTasteController : ControllerBase
{
    private readonly MusicTasteService musicTasteService;
    private readonly GenreFeatureService genreFeatureService;
    private readonly ArtistService artistService;

    public MusicTasteController(
      MusicTasteService musicTasteService,
      GenreFeatureService genreFeatureService,
      ArtistService artistService)
    {
        this.musicTasteService = musicTasteService;
        this.genreFeatureService = genreFeatureService;
        this.artistService = artistService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(this.musicTasteService.GetAllByUserId(this.GetCurrentUserId()).Select(MusicTasteDto.FromMusicTaste));
    }

    [HttpPost]
    public IActionResult Add(AddMusicTasteDto dto)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }

        MusicTaste musicTaste = this.musicTasteService.Create();
        musicTaste.UserId = this.GetCurrentUserId();
        musicTaste.IsDisabled = dto.IsDisabled;

        this.musicTasteService.Add(musicTaste);

        foreach (AddGenreFeatureDto genreFeatureDto in dto.GenreFeatures)
        {
            GenreFeature genreFeature = this.genreFeatureService.Create();
            genreFeature.Genre = genreFeatureDto.Genre;
            genreFeature.Percentage = genreFeatureDto.Percentage;
            genreFeature.MusicTasteId = musicTaste.Id;

            this.genreFeatureService.Add(genreFeature);
        }

        foreach (string artistId in dto.ArtistIds)
        {
            Artist? artist = this.artistService.GetBySpotifyId(artistId);

            if (artist == null)
            {
                artist = this.artistService.Create();
                artist.SpotifyId = artistId;
                artist.MusicTastes.Add(musicTaste);

                this.artistService.Add(artist);
            }
            else
            {
                artist.MusicTastes.Add(musicTaste);

                this.artistService.Update(artist);
            }
        }

        return CreatedAtAction(nameof(this.Add), musicTaste);
    }

    [HttpPut]
    public IActionResult Update(UpdateMusicTasteDto dto)
    {
        MusicTaste? musicTaste = this.musicTasteService.Get(dto.Id);
        if (musicTaste == null)
        {
            return NotFound();
        }

        if (musicTaste.UserId != this.GetCurrentUserId())
        {
            return Unauthorized();
        }

        musicTaste.Artists = dto.ArtistIds.Select(a =>
        {
            Artist? artist = this.artistService.GetBySpotifyId(a);
            if (artist == null)
            {
                artist = this.artistService.Create();
                artist.SpotifyId = a;
            }

            return artist;
        }).ToHashSet();

        musicTaste.IsDisabled = dto.IsDisabled;
        this.musicTasteService.Update(musicTaste);

        return Ok(musicTaste);
    }

    [HttpDelete]
    public IActionResult Delete(Guid id)
    {
        MusicTaste? musicTaste = this.musicTasteService.Get(id);
        if (musicTaste == null)
        {
            return NotFound();
        }

        if (musicTaste.UserId != this.GetCurrentUserId())
        {
            return Unauthorized();
        }

        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }

        if (!this.musicTasteService.Delete(id))
        {
            return BadRequest();
        }

        return Ok();
    }
}
