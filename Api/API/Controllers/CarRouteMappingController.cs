using API.Base;
using API.Endpoints;
using API.Models.Response;
using API.Utils.Constant;
using FU.Domain.Entities.Car.SubModel;
using FU.Domain.Entities.Seat.SubModel;
using FU.Service.Contract;
using FU.Service.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using ILogger = Serilog.ILogger;

namespace API.Controllers
{
    public class CarRouteMappingController : BaseController
    {
        private readonly IManageCarService _manageCarService;
        private readonly IManageRouteService _manageRouteService;
        private readonly ILogger _logger;

        public CarRouteMappingController(IManageCarService manageCarService, IManageRouteService manageRouteService, ILogger logger)
        {
            _manageCarService = manageCarService;
            _manageRouteService = manageRouteService;
            _logger = logger;
        }
    }
}
