using API.Base;
using API.Endpoints;
using API.Models.Response;
using API.Utils.Constant;
using FU.Domain.Entities.CarsManager;
using FU.Domain.Entities.CarsManager.SubModel;
using FU.Service.Contract;
using FU.Service.Models.CarsManager;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using ILogger = Serilog.ILogger;

namespace API.Controllers
{
    public class CarsManagerController : BaseController
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
        public async Task<IActionResult> GetAllCarsManager()
        {
            var data = await _manageCarService.GetManagersAsync();
            var res = new ResponseModel<List<CarsManagerInfoModel>>(data);
            return Ok(res);
        }

        [HttpGet]
        [Route(CarsManagerEndpoint.GetSingle)]
        public async Task<IActionResult> GetCarsManager(Guid id)
        {
            var data = await _manageCarService.GetManagerAsync(id);
            var res = new ResponseModel<CarsManagerMapModel>(data);
            return Ok(res);
        }

        [HttpPost]
        [Route(CarsManagerEndpoint.CreateManager)]
        public async Task<IActionResult> CreateCarsManager([FromBody] CreateCarsManagerModel model)
        {
            var data = await _manageCarService.CreateManager(model);
            var res = new ResponseModel<Guid>(data);
            return Ok(res);
        }

        [HttpPost]
        [Route(CarsManagerEndpoint.UpdateManager)]
        public async Task<IActionResult> UpdateCarsManager([FromBody]UpdateCarsManagerModel model)
        {
            var data = await _manageCarService.UpdateManager(model);
            var res = new ResponseModel<Guid>(data);
            return Ok(res);
        }

        [HttpGet]
        [Route(CarsManagerEndpoint.DeleteManager)]
        public async Task<IActionResult> DeleteCarsManager(Guid id)
        {
            await _manageCarService.DeleteManager(id);
            var res = new ResponseModel<string>(MessageConstant.Success);
            return Ok(res);
        }
    }
}
