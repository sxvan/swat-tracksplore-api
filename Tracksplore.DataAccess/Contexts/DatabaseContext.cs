using Microsoft.EntityFrameworkCore;
using Tracksplore.DataAccess.Models;

namespace Tracksplore.DataAccess.Contexts;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
      : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    public DbSet<Artist> Artists { get; set; }

    public DbSet<GenreFeature> GenreFeatures { get; set; }

    public DbSet<MusicTaste> MusicTastes { get; set; }

    public DbSet<SpotifyToken> SpotifyTokens { get; set; }

    public DbSet<Swipe> Swipes { get; set; }

    public DbSet<ExternalLogin> ExternalLogins { get; set; }

    public DbSet<RateLimit> RateLimits { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasAlternateKey(u => u.Email);
        modelBuilder.Entity<User>().HasAlternateKey(u => u.DisplayName);
        modelBuilder.Entity<User>()
          .HasOne(u => u.SpotifyToken)
          .WithOne(st => st.User)
          .HasForeignKey<SpotifyToken>(st => st.UserId);

        modelBuilder.Entity<Artist>().HasAlternateKey(a => a.SpotifyId);

        base.OnModelCreating(modelBuilder);
    }
}
