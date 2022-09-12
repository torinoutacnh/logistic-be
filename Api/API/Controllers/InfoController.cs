using API.Endpoints;
using API.Models.Response;
using FU.Domain.Entities.LocalLocation.SubModel;
using FU.Service.Contract;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class InfoController : Controller
    {
        private readonly IManageRouteService _manageRouteService;
        private readonly ILogger _logger;

        public InfoController(IManageRouteService manageRouteService, ILogger logger)
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
    }
}
