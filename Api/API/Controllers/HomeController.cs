using API.Models.Form;
using API.Models.Response;
using API.Utils.Constant;
using FU.Domain.Entities.Form;
using FU.Service.Contract;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class HomeController : Controller
    {
        private readonly IReportService _reportService;
        public HomeController(IServiceProvider serviceProvider)
        {
            _reportService = serviceProvider.GetRequiredService<IReportService>();
        }

        [HttpPost]
        [Route("/test")]
        public async Task<IActionResult> TestAsync([FromBody] CreateFormModel model)
        {
            try
            {
                await _reportService.CreateForm(model.Info, model.Labels);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse(ex.Message));
            }
        }

        [HttpGet]
        [Route("/test")]
        public async Task<IActionResult> TestGetAsync(string code)
        {
            try
            {
                var form = await _reportService.GetForm(code);
                if(form == null) return NotFound(new ErrorResponse(MessageConstant.NotFound));
                
                var response = new ResponseModel<FormEntity>(form);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse(ex.Message));
            }
        }
    }
}
