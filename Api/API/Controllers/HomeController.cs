using API.Models.Response;
using API.Utils.Constant;
using FU.Domain.Models;
using FU.Service.Contract;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace API.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IServiceProvider serviceProvider)
        {
        }

        [HttpPost]
        [Route("/test")]
        public IActionResult TestAsync()
        {
            return Ok();
        }
    }
}
