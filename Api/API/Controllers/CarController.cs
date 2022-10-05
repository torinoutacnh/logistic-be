﻿using API.Base;
using API.Endpoints;
using API.Models.Response;
using API.Utils.Constant;
using FU.Domain.Entities.Car.SubModel;
using FU.Domain.Entities.Seat.SubModel;
using FU.Domain.Entities.Ticket;
using FU.Service.Contract;
using FU.Service.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using ILogger = Serilog.ILogger;

namespace API.Controllers
{
    public class CarController : BaseController
    {
        private readonly IManageCarService _manageCarService;
        private readonly IManageRouteService _manageRouteService;
        private readonly IManageTicketService _manageTicketService;
        private readonly ILogger _logger;

        public CarController(IManageCarService manageCarService, IManageRouteService manageRouteService, IManageTicketService manageTicketService, ILogger logger)
        {
            _manageCarService = manageCarService;
            _manageRouteService = manageRouteService;
            _manageTicketService = manageTicketService;
            _logger = logger;
        }

        #region Car
        [HttpGet]
        [Route(CarEndpoints.GetAll)]
        public async Task<IActionResult> GetCars()
        {
            var cars = await _manageCarService.GetCarListAsync();
            var res = new ResponseModel<List<CarViewModel>>(cars);
            return Ok(res);
        }

        [HttpGet]
        [Route(CarEndpoints.GetSingle)]
        public async Task<IActionResult> GetCar(Guid id)
        {
            var car = await _manageCarService.GetCarDetailAsync(id);
            var res = new ResponseModel<CarInfoModel>(car);
            return Ok(res);
        }

        [HttpGet]
        [Route(CarEndpoints.GetByManager)]
        public async Task<IActionResult> GetCarByManager(Guid id)
        {
            var car = await _manageCarService.GetCarByManagerAsync(id);
            var res = new ResponseModel<List<CarViewModel>>(car);
            return Ok(res);
        }

        [HttpPost]
        [Route(CarEndpoints.CreateCar)]
        public async Task<IActionResult> CreateCar([FromForm]CreateCarWithFileModel model)
        {
            var car = await _manageCarService.CreateCarAsync(model);
            var res = new ResponseModel<Guid>(car);
            return Ok(res);
        }

        [HttpPost]
        [Route(CarEndpoints.UpdateCarDetail)]
        public async Task<IActionResult> UpdateCarDetail([FromForm] UpdateCarDetailWithFileModel model)
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
        #endregion

        #region Car seat
        [HttpPost]
        [Route(CarSeatEndpoints.CreateSeat)]
        public async Task<IActionResult> CreateSeat(Guid id, [FromBody]CreateCarSeatModel model)
        {
            var seat = await _manageRouteService.CreateSeat(id, model);
            var res = new ResponseModel<Guid>(seat);
            return Ok(res);
        }

        [HttpPost]
        [Route(CarSeatEndpoints.CreateSeats)]
        public async Task<IActionResult> CreateSeats(Guid id, [FromBody] CreateCarSeatModel[] models)
        {
            var seats = await _manageRouteService.CreateSeats(id, models);
            var res = new ResponseModel<List<Guid>>(seats);
            return Ok(res);
        }

        [HttpPost]
        [Route(CarSeatEndpoints.UpdateSeatInfo)]
        public async Task<IActionResult> UpdateSeatInfo(Guid id, [FromBody] UpdateCarSeatDetailModel model)
        {
            var seat = await _manageRouteService.UpdateSeatDetail(id, model);
            var res = new ResponseModel<Guid>(seat);
            return Ok(res);
        }

        [HttpPost]
        [Route(CarSeatEndpoints.UpdateSeatStatus)]
        public async Task<IActionResult> UpdateSeatStatus([FromBody] UpdateCarSeatStatusModel model)
        {
            var seat = await _manageRouteService.UpdateSeatStatus(model);
            var res = new ResponseModel<Guid>(seat);
            return Ok(res);
        }

        [HttpGet]
        [Route(CarSeatEndpoints.DeleteSeat)]
        public async Task<IActionResult> DeleteSeat(Guid id)
        {
            await _manageRouteService.DeleteSeat(id);
            var res = new ResponseModel<string>(MessageConstant.Success);
            return Ok(res);
        }
        #endregion

        #region Ticket
        [HttpGet]
        [Route(TicketEndpoints.GetAll)]
        public async Task<IActionResult> GetAllTicket()
        {
            var tickets = await _manageTicketService.GetTicketListAsync();
            var res = new ResponseModel<List<TicketViewModel>>(tickets);
            return Ok(res);
        }

        [HttpGet]
        [Route(TicketEndpoints.GetSingle)]
        public async Task<IActionResult> GetTicket(Guid id)
        {
            var ticket = await _manageTicketService.GetTicketAsync(id);
            var res = new ResponseModel<TicketViewModel>(ticket);
            return Ok(res);
        }

        [HttpPost]
        [Route(TicketEndpoints.CreateTicket)]
        public async Task<IActionResult> CreateTicket([FromBody]CreateTicketModel model)
        {
            var ticket = await _manageTicketService.CreateTicketAsync(model);
            var res = new ResponseModel<Guid>(ticket);
            return Ok(res);
        }

        [HttpPost]
        [Route(TicketEndpoints.UpdateTicketInfo)]
        public async Task<IActionResult> UpdateTicketInfo([FromBody]UpdateTicketSeatModel model)
        {
            var ticket = await _manageTicketService.UpdateTicketAsync(model);
            var res = new ResponseModel<Guid>(ticket);
            return Ok(res);
        }
        [HttpPost]
        [Route(TicketEndpoints.UpdateTicketMapping)]
        public async Task<IActionResult> UpdateTicketMapping([FromBody]UpdateTicketMappingModel model)
        {
            var ticket = await _manageTicketService.UpdateTicketMappingAsync(model);
            var res = new ResponseModel<Guid>(ticket);
            return Ok(res);
        }

        [HttpGet]
        [Route(TicketEndpoints.DeleteTicket)]
        public async Task<IActionResult> DeleteTicket(Guid id)
        {
            await _manageTicketService.DeleteTicketAsync(id);
            var res = new ResponseModel<string>(MessageConstant.Success);
            return Ok(res);
        }



        #endregion Ticket
    }
}
