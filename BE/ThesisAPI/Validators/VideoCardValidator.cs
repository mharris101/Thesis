using FluentValidation;
using ThesisAPI.DTOs;

namespace ThesisAPI.Validators
{
    public class VideoCardValidator : AbstractValidator<VideoCard>
    {
        public VideoCardValidator()
        {
            RuleFor(videoCard => videoCard.VideoCardDesc)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
