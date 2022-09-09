using API.Endpoints;
using API.Models.Response;
using API.Utils.Constant;
using FU.Domain.Entities.Car.SubModel;
using FU.Service.Contract;
using FU.Service.Models.Car;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using ILogger = Serilog.ILogger;

namespace API.Controllers
{
    public class CarController : Controller
    {
        private readonly IManageCarService _manageCarService;
        private readonly ILogger _logger;

        public CarController(IManageCarService manageCarService, ILogger logger)
        {
            _manageCarService = manageCarService;
            _logger = logger;
        }

        [HttpGet]
        [Route(CarEndpoints.GetAll)]
        public async Task<IActionResult> GetCars()
        {
            var cars = await _manageCarService.GetCarsAsync();
            var res = new ResponseModel<List<CarInfoModel>>(cars);
            return Ok(res);
        }

        [HttpGet]
        [Route(CarEndpoints.GetSingle)]
        public async Task<IActionResult> GetCar(Guid id)
        {
            var car = await _manageCarService.GetCarAsync(id);
            var res = new ResponseModel<CarMapModel>(car);
            return Ok(res);
        }

        [HttpPost]
        [Route(CarEndpoints.CreateCar)]
        public async Task<IActionResult> CreateCar([FromBody]CreateCarModel model)
        {
            var car = await _manageCarService.CreateCarAsync(model);
            var res = new ResponseModel<Guid>(car);
            return Ok(res);
        }

        [HttpPost]
        [Route(CarEndpoints.UpdateCarDetail)]
        public async Task<IActionResult> UpdateCarDetail([FromBody] UpdateCarDetailModel model)
        {
            var car = await _manageCarService.UpdateCarDetailAsync(model);
            var res = new ResponseModel<Guid>(car);
            return Ok(res);
        }

        [HttpPost]
        [Route(CarEndpoints.UpdateCarPrice)]
        public async Task<IActionResult> UpdateCarPrice([FromBody] UpdateCarPriceModel model)
        {
            var car = await _manageCarService.UpdateCarPriceAsync(model);
            var res = new ResponseModel<Guid>(car);
            return Ok(res);
        }

        [HttpGet]
        [Route(CarEndpoints.DeleteCar)]
        public async Task<IActionResult> DeleteCar(Guid id)
        {
            await _manageCarService.DeleteCarAsync(id);
            var res = new ResponseModel<string>(MessageConstant.Success);
            return Ok(res);
        }
    }
}
