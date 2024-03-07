using ThesisAPI.DTOs;
using ThesisAPI.Models;

namespace ThesisAPI.Converters
{
    public static class VideoCardConverter
    {
        public static VideoCard ToDto(this VideoCardEntity entity) => ConvertToDto(entity);

        public static List<VideoCard> ToDto(this List<VideoCardEntity> entities)
        {
            var dtos = new List<VideoCard>();
            entities.ForEach(entity => dtos.Add(ConvertToDto(entity)));
            return dtos;
        }

        private static VideoCard ConvertToDto(VideoCardEntity entity) => new()
        {
            VideoCardId = entity.VideoCardId,
            VideoCardDesc = entity.VideoCardDesc
        };

        public static VideoCardEntity ToEntity(this VideoCard dto) => new()
        {
            VideoCardId = dto.VideoCardId,
            VideoCardDesc = dto.VideoCardDesc
        };
    }
}
