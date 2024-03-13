using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using ThesisAPI.DTOs;
using ThesisAPI.Services.Interfaces;

namespace ThesisAPI.Controllers
{
    [Route("api/Computers")]
    [ApiController]
    public class ComputerController : ControllerBase
    {
        private IComputerService _computerService;

        public ComputerController(IComputerService computerService)
        {
            _computerService = computerService;
        }

        [HttpGet]
        [Route("")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<ComputerOut>))]
        public async Task<IActionResult> GetAll(int? page, int? pageSize, string? uom)
        {
            var computers = await _computerService.GetAllAsync(page, pageSize, uom);
            return Ok(computers);
        }

        [HttpGet]
        [Route("{id:int}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(ComputerOut))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id, string? uom)
        {
            var computer = await _computerService.GetAsync(id, uom);

            return computer is ComputerOut
                ? Ok(computer)
                : NotFound();
        }

        [HttpPost]
        [Route("")]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(ComputerOut))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add(ComputerIn computer)
        {
            var newComputer = await _computerService.AddAsync(computer);

            return Created($"/Computers/{newComputer.ComputerId}", newComputer);
        }
    }
}