using API.Endpoints;
using FU.Domain.Entities.CarsManager;
using FU.Service.Contract;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using ILogger = Serilog.ILogger;

namespace API.Controllers
{
    public class CarsManagerController : Controller
    {
        private readonly IManageCarService _manageCarService;
        private readonly ILogger _logger;

        public CarsManagerController(IManageCarService manageCarService, ILogger logger)
        {
            _manageCarService = manageCarService;
            _logger = logger;
        }

        [HttpGet]
        [Route(CarsManagerEndpoint.GetAll)]
        public IActionResult GetAllCarsManager()
        {
            return View();
        }
    }
}
