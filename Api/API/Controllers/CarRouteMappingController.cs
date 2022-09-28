using API.Base;
using API.Endpoints;
using API.Models.Response;
using API.Utils.Constant;
using FU.Domain.Entities.Car.SubModel;
using FU.Domain.Entities.CarRouteMapping.SubModel;
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
        private readonly IManageCarRouteMappingService _manageCarRouteMappingService;
        private readonly ILogger _logger;

        public CarRouteMappingController(IManageCarRouteMappingService manageCarRouteMapopingService, ILogger logger)
        {
            _manageCarRouteMappingService = manageCarRouteMapopingService;
            _logger = logger;
        }
        [HttpGet]
        [Route(CarRouteMappingEndPoints.GetAll)]
        public async Task<IActionResult> GetCarRouteMappings()
        {
            var carRouteMappings = await _manageCarRouteMappingService.GetCarRouteMappingDetailsAsync();
            var res = new ResponseModel<List<CarRouteMappingViewModel>>(carRouteMappings);
            return Ok(res);
        }
        [HttpGet]
        [Route(CarRouteMappingEndPoints.GetSingle)]
        public async Task<IActionResult> GetCarRouteMapping(Guid carId)
        {
            var carRouteMapping = await _manageCarRouteMappingService.GetCarRouteMappingDetailAsync(carId);
            var res = new ResponseModel<CarRouteMappingInfoModel>(carRouteMapping);
            return Ok(res);
        }
        [HttpPost]
        [Route(CarRouteMappingEndPoints.UpdateStarttime)]
        public async Task<IActionResult> UpdateCarRouteMapping([FromForm] UpdateCarRouteMappingStarttimeModel model)
        {
            var starttime = await _manageCarRouteMappingService.UpdateCarRouteMappingDetailAsync(model);
            var res = new ResponseModel<Guid>(starttime);
            return Ok(res);
        }
        [HttpPost]
        [Route(CarRouteMappingEndPoints.CreateStarttime)]
        public async Task<IActionResult> CreateCarMapping([FromForm] CreateCarRouteMappingStarttimeModel model)
        {
            var starttime = await _manageCarRouteMappingService.CreateCarRouteMappingDetailAsync(model);
            var res = new ResponseModel<Guid>(starttime);
            return Ok(res);
        }
        [HttpGet]
        [Route(CarRouteMappingEndPoints.DeleteStarttime)]
        public async Task<IActionResult> DeleteCar(Guid id)
        {
            await _manageCarRouteMappingService.DeleteCarRouteMappingAsync(id);
            var res = new ResponseModel<string>(MessageConstant.Success);
            return Ok(res);
        }
        [HttpGet]
        [Route(CarRouteMappingEndPoints.GetCarRouteByLocationStarttime)]
        public async Task<IActionResult> GetCarRouteByLocationStarttime(Guid FromCity, Guid ToCity, DateTimeOffset Starttime)
        {
            var carRoutebyLocationStarttime = await _manageCarRouteMappingService.GetCarRouteByLocationStarttime(FromCity, ToCity, Starttime);
            var res = new ResponseModel<List<CarRouteMappingInfoModel>>(carRoutebyLocationStarttime);
            return Ok(res);

        }
    }
}
