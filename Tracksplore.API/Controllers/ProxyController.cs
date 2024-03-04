using Microsoft.AspNetCore.Mvc;

namespace Tracksplore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProxyController : ControllerBase
    {
        private readonly HttpClient httpClient;

        public ProxyController(HttpClient httpClient) {
            this.httpClient = httpClient;
        }

        //[HttpGet]
        //public IActionResult ProxyRequest(HttpRequest request) {

        //}
    }
}
