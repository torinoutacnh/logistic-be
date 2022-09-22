using API.Base;
using API.Endpoints;
using API.Models.Response;
using API.Utils.Constant;
using FU.Domain.Entities.LocalLocation.SubModel;
using FU.Domain.Entities.Route.SubModel;
using FU.Domain.Entities.StopPoint;
using FU.Service.Contract;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using ILogger = Serilog.ILogger;

namespace API.Controllers
{
    public class CarRouteController : BaseController
    {
        private readonly IManageRouteService _manageRouteService;
        private readonly ILogger _logger;

        public CarRouteController(IManageRouteService manageRouteService, ILogger logger)
        {
            _manageRouteService = manageRouteService;
            _logger = logger;
        }

        #region stop point
        [HttpPost]
        [Route(StopPointEndpoints.CreateStopPoint)]
        public async Task<IActionResult> CreateStopPoint(Guid carid, [FromBody] CreateStopPointModel model)
        {
            var stops = await _manageRouteService.CreateStopPoint(carid, model);
            var res = new ResponseModel<Guid>(stops);
            return Ok(res);
        }

        [HttpPost]
        [Route(StopPointEndpoints.CreateStopPoints)]
        public async Task<IActionResult> CreateStopPoints(Guid carid, [FromBody] ICollection<CreateStopPointModel> models)
        {
            var stops = await _manageRouteService.CreateStopPoints(carid, models);
            var res = new ResponseModel<List<Guid>>(stops);
            return Ok(res);
        }

        [HttpPost]
        [Route(StopPointEndpoints.UpdateStopPointLocation)]
        public async Task<IActionResult> UpdateStopPointLocation(Guid carid, [FromBody] Location model)
        {
            var stops = await _manageRouteService.UpdateStopPointLocation(carid, model);
            var res = new ResponseModel<Guid>(stops);
            return Ok(res);
        }

        [HttpPost]
        [Route(StopPointEndpoints.UpdateStopPointDetail)]
        public async Task<IActionResult> UpdateStopPointLocation(Guid carid, [FromBody] DetailLocation model)
        {
            var stops = await _manageRouteService.UpdateStopPointDetailLocation(carid, model);
            var res = new ResponseModel<Guid>(stops);
            return Ok(res);
        }

        [HttpGet]
        [Route(StopPointEndpoints.DeleteStopPoint)]
        public async Task<IActionResult> DeleteStopPoint(Guid id)
        {
            await _manageRouteService.DeleteStopPoint(id);
            var res = new ResponseModel<string>(MessageConstant.Success);
            return Ok(res);
        }
        #endregion

        #region route
        [HttpPost]
        [Route(RouteEndpoints.CreateRoute)]
        public async Task<IActionResult> CreateRoute(Guid id, [FromBody]CreateCarRouteModel model)
        {
            var route = await _manageRouteService.CreateRoute(id, model);
            var res = new ResponseModel<Guid>(route);
            return Ok(res);
        }

        [HttpPost]
        [Route(RouteEndpoints.CreateRoutes)]
        public async Task<IActionResult> CreateRoutes(Guid id, [FromBody] CreateCarRouteModel[] models)
        {
            var routes = await _manageRouteService.CreateRoutes(id, models);
            var res = new ResponseModel<List<Guid>>(routes);
            return Ok(res);
        }

        [HttpPost]
        [Route(RouteEndpoints.UpdateRoute)]
        public async Task<IActionResult> UpdateRoute(Guid id, [FromBody] UpdateCarRouteModel model)
        {
            var route = await _manageRouteService.UpdateRoute(id, model);
            var res = new ResponseModel<Guid>(route);
            return Ok(res);
        }

        [HttpGet]
        [Route(RouteEndpoints.DeleteRoute)]
        public async Task<IActionResult> DeleteRoute(Guid id)
        {
            await _manageRouteService.DeleteRoute(id);
            var res = new ResponseModel<string>(MessageConstant.Success);
            return Ok(res);
        }
        #endregion
    }
}
