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

        [HttpGet]
        [Route(OtherEndpoints.GetCities)]
        public async Task<IActionResult> GetCities()
        {
            var cities = await _manageRouteService.GetCitiesAsync();
            var res = new ResponseModel<List<CityViewModel>>(cities);
            return Ok(res);
        }

        [HttpGet]
        [Route(OtherEndpoints.GetDistricts)]
        public async Task<IActionResult> GetDistricts(Guid id)
        {
            var districts = await _manageRouteService.GetDistrictsByCityAsync(id);
            var res = new ResponseModel<List<DistrictViewModel>>(districts);
            return Ok(res);
        }

        [HttpGet]
        [Route(OtherEndpoints.GetWards)]
        public async Task<IActionResult> GetWards(Guid id)
        {
            var wards = await _manageRouteService.GetWardsByDistrictAsync(id);
            var res = new ResponseModel<List<WardViewModel>>(wards);
            return Ok(res);
        }

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
    }
}
