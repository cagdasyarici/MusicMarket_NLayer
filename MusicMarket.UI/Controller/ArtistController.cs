using Microsoft.AspNetCore.Mvc;

namespace MusicMarket.UI.Controller
{
    public class ArtistController : ControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAllArtist()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = 
        }
    }
}
