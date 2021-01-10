using Develgo.WebUi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Develgo.WebComponents.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Rendering the home page.");

            var body = "<h1>Hello World!</h1>";
            var page = new HtmlPage()
                .FavIcon(Request.UrlFrom("/images/favicon.ico"))
                .Title("Develgo WebUI");
            return base.Content(page.Render(body), "text/html");
        }
    }
}
