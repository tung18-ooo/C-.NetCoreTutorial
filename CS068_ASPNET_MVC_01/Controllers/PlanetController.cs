using CS068_ASPNET_MVC_01.Services;
using Microsoft.AspNetCore.Mvc;

namespace CS068_ASPNET_MVC_01.Controllers
{
    [Route("he-mat-troi/[action]")]
    public class PlanetController : Controller
    {
        private readonly PlanetService _planetsService;
        private readonly ILogger<PlanetController> _logger;

        public PlanetController(PlanetService planetsService, ILogger<PlanetController> logger)
        {
            _planetsService = planetsService;
            _logger = logger;
        }

        //[Route("list-planet")]   // he-mat-troi/list-planet
        [Route("/list-plant")]
        public ActionResult Index() 
        {
            return View();
        }

        //route : action
        [BindProperty(SupportsGet = true, Name = "action")]
        public string Name { get; set; }
        public IActionResult Mercury()
        {
            var planet = _planetsService.Where(p => p.Name == "Mercury").FirstOrDefault();
            return View("Detail", planet);
        }

        public IActionResult Venus()
        {
            var planet = _planetsService.Where(p => p.Name == "Venus").FirstOrDefault();
            return View("Detail", planet);
        }

        public IActionResult Earth()
        {
            var planet = _planetsService.Where(p => p.Name == "Earth").FirstOrDefault();
            return View("Detail", planet);
        }

        public IActionResult Mars()
        {
            var planet = _planetsService.Where(p => p.Name == "Mars").FirstOrDefault();
            return View("Detail", planet);
        }

        public IActionResult Jupiter()
        {
            var planet = _planetsService.Where(p => p.Name == "Jupiter").FirstOrDefault();
            return View("Detail", planet);
        }

        public IActionResult Saturn()
        {
            var planet = _planetsService.Where(p => p.Name == "Saturn").FirstOrDefault();
            return View("Detail", planet);
        }

        public IActionResult Uranus()
        {
            var planet = _planetsService.Where(p => p.Name == "Uranus").FirstOrDefault();
            return View("Detail", planet);
        }


        // [Route] co the khai bao nhieu lan
        // Order = int : do uu tien
        // [Route("sao/[action]", Order = 1)]

        [Route("sao/[action]", Order = 3, Name = "neptune3")]                   // /sao/Neptune
        [Route("sao/[controller]/[action]", Order = 2, Name = "neptune2")]      // /sao/Planet/Neptune
        [Route("[controller]-[action].html", Order = 1, Name = "neptune1")]      // /sao/Planet/Neptune

        public IActionResult Neptune()
        {
            var planet = _planetsService.Where(p => p.Name == "Neptune").FirstOrDefault();
            return View("Detail", planet);
        }

        // controller, action, area => [controller] [action] [area]

        [Route("planet/{id:int}")]  //planet/1
        public IActionResult PlanetInfo(int id)
        {
            var planet = _planetsService.Where(p => p.Id == id).FirstOrDefault();
            return View("Detail", planet);
        }
    }
}
