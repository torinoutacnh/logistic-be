using API.Base;
using API.Endpoints;
using API.Models.Response;
using API.Utils.Constant;
using FU.Domain.Entities.LocalLocation.SubModel;
using FU.Domain.Entities.Route;
using FU.Domain.Entities.Route.SubModel;
using FU.Service.Contract;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using ILogger = Serilog.ILogger;

namespace API.Controllers
{
    public class CarRouteController : BaseController
    {
        private readonly IManageRouteService _manageRouteService;

        public CarRouteController(IManageRouteService manageRouteService, ILogger logger)
        {
            _manageRouteService = manageRouteService;
        }

        #region route
        [HttpPost]
        [Route(RouteEndpoints.CreateRoute)]
        public async Task<IActionResult> CreateRoute([FromBody]CreateCarRouteModel model)
        {
            var route = await _manageRouteService.CreateRoute(model);
            var res = new ResponseModel<Guid>(route);
            return Ok(res);
        }

        //[HttpPost]
        //[Route(RouteEndpoints.CreateRoutes)]
        //public async Task<IActionResult> CreateRoutes([FromBody] CreateCarRouteModel[] models)
        //{
        //    var routes = await _manageRouteService.CreateRoutes(models);
        //    var res = new ResponseModel<List<Guid>>(routes);
        //    return Ok(res);
        //}

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
