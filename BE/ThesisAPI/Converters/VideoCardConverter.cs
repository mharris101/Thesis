using ThesisAPI.DTOs;
using ThesisAPI.Models;

namespace ThesisAPI.Converters
{
    public static class VideoCardConverter
    {
        public static VideoCard ToDto(this VideoCardEntity entity) => ConvertEntityToDto(entity);

        public static List<VideoCard> ToDto(this List<VideoCardEntity> entities)
        {
            var dtos = new List<VideoCard>();
            entities.ForEach(entity => dtos.Add(ConvertEntityToDto(entity)));
            return dtos;
        }

        private static VideoCard ConvertEntityToDto(VideoCardEntity entity) => new()
        {
            VideoCardId = entity.VideoCardId,
            VideoCardDesc = entity.VideoCardDesc
        };

        public static VideoCardEntity ToEntity(this VideoCard dto) => ConvertDtoToEntity(dto);

        public static List<VideoCardEntity> ToEntity(this List<VideoCard> dtos)
        {
            var entities = new List<VideoCardEntity>();
            dtos.ForEach(dto => entities.Add(ConvertDtoToEntity(dto)));
            return entities;
        }

        private static VideoCardEntity ConvertDtoToEntity(VideoCard dto) => new()
        {
            VideoCardId = dto.VideoCardId,
            VideoCardDesc = dto.VideoCardDesc
        };

        public static void Merge(this VideoCard dto, VideoCardEntity entity)
        {
            entity.VideoCardId = dto.VideoCardId;
            entity.VideoCardDesc = dto.VideoCardDesc;
        }
    }
}
