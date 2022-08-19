using API.Models.Form;
using API.Models.Response;
using API.Utils.Constant;
using FU.Domain.Entities.Form;
using FU.Domain.Models;
using FU.Service.Contract;
using Microsoft.AspNetCore.Mvc;
using Serilog;

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
                if(ex is DomainException)
                {
                    return StatusCode((ex as DomainException).Code,new ErrorResponse(ex.Message));
                }else if(ex is ArgumentException||ex is ArgumentNullException)
                {
                    return StatusCode(400, new ErrorResponse(ex.Message));
                }
                return StatusCode(500, new ErrorResponse(ex.Message));
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
                if (ex is DomainException)
                {
                    return StatusCode((ex as DomainException).Code, new ErrorResponse(ex.Message));
                }
                else if (ex is ArgumentException || ex is ArgumentNullException)
                {
                    return StatusCode(400, new ErrorResponse(ex.Message));
                }
                return StatusCode(500, new ErrorResponse(ex.Message));
            }
        }
    }
}
