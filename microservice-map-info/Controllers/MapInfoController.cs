using Microsoft.AspNetCore.Mvc;

namespace microservice_map_info.Controllers
{
    [Route("[controller]")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class MapInfoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
