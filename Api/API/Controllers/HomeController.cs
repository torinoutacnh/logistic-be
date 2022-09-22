using API.Base;
using API.Endpoints;
using API.Models.Response;
using API.Utils.Constant;
using FU.Domain.Models;
using FU.Infras.Application;
using FU.Service.Contract;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace API.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        [HttpGet]
        [Route(OtherEndpoints.Home)]
        public IActionResult Index()
        {
            return Ok("Server is running");
        }

        [HttpGet]
        [Route(OtherEndpoints.Version)]
        public IActionResult Version()
        {
            return Ok($"Api version : {SystemHelper.Setting.Version}. Latest deployed time : {SystemHelper.Setting.LastestDepoyTime.ToString("dd/MM/yyyy - HH:mm")}");
        }
    }
}
