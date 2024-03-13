using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using ThesisAPI.DTOs;
using ThesisAPI.Services.Interfaces;
using ThesisAPI.Validators;

namespace ThesisAPI.Controllers
{
    [Route("api/VideoCards")]
    [ApiController]
    public class VideoCardController : ControllerBase
    {
        private IVideoCardService _videoCardService;
        private IValidator<VideoCard> _validator;

        public VideoCardController(IVideoCardService videoCardService, IValidator<VideoCard> validator)
        {
            _videoCardService = videoCardService;
            _validator = validator;
        }

        [HttpGet]
        [Route("")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<VideoCard>))]
        public async Task<IActionResult> GetAll(int? page, int? pageSize)
        {
            var videoCards = await _videoCardService.GetAllAsync(page, pageSize);
            return Ok(videoCards);
        }

        [HttpGet]
        [Route("{id:int}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(VideoCard))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var videoCard = await _videoCardService.GetAsync(id);

            return videoCard is VideoCard
                ? Ok(videoCard)
                : NotFound();
        }

        [HttpPost]
        [Route("")]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(VideoCard))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add(VideoCard videoCard)
        {
            var validationResult = _validator.Validate(videoCard);
            if (!validationResult.IsValid)
            {
                var errors = new List<ValidationError>();
                foreach (var failure in validationResult.Errors)
                {
                    errors.Add(new ValidationError() { Property = failure.PropertyName, Error = failure.ErrorMessage });
                }

                return BadRequest(new { errors });
            }

            await _videoCardService.AddAsync(videoCard);

            return Created($"/VideoCards/{videoCard.VideoCardId}", videoCard);
        }

        [HttpPut]
        [Route("{id:int}")]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, VideoCard videoCard)
        {
            if (id != videoCard.VideoCardId)
            {
                return BadRequest();
            }

            var validationResult = _validator.Validate(videoCard);
            if (!validationResult.IsValid)
            {
                var errors = new List<ValidationError>();
                foreach (var failure in validationResult.Errors)
                {
                    errors.Add(new ValidationError() { Property = failure.PropertyName, Error = failure.ErrorMessage });
                }

                return BadRequest(new { errors });
            }

            try
            {
                await _videoCardService.UpdateAsync(videoCard);
            }
            catch (Exception ex)
            {
                if (ex.Message == "Video card not found")
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        [HttpDelete]
        [Route("{id:int}")]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _videoCardService.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                switch (ex.Message)
                {
                    case "Reference constraint":
                        return Conflict(new { message = "Unable to delete. Its dependencies must first be deleted." });
                    case "Not found":
                        return NotFound();
                }

                throw;
            }

            return NoContent();
        }
    }
}
