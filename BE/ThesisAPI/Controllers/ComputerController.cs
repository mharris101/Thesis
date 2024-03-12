using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using ThesisAPI.DTOs;
using ThesisAPI.Services.Interfaces;
using ThesisAPI.Validators;

namespace ThesisAPI.Controllers
{
    [Route("api/Computers")]
    [ApiController]
    public class ComputerController : ControllerBase
    {
        private IComputerService _computerService;
        //private IValidator<VideoCard> _validator;

        public ComputerController(IComputerService computerService) //, IValidator<VideoCard> validator)
        {
            _computerService = computerService;
            //_validator = validator;
        }

        [HttpGet]
        [Route("")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<ComputerOut>))]
        public async Task<IActionResult> GetAll(int? page, int? pageSize)
        {
            var computers = await _computerService.GetAllAsync(page, pageSize);
            return Ok(computers);
        }
    }
}
