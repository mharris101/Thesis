using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ThesisAPI.Converters;
using ThesisAPI.DTOs;
using ThesisAPI.Models;
using ThesisAPI.Services.Interfaces;

namespace ThesisAPI.Services
{
    public class VideoCardService : IVideoCardService
    {
        public ThesisContext _db;

        public VideoCardService(ThesisContext db)
        {
            _db = db;
        }

        /// <inheritdoc />
        public async Task<VideoCard> AddAsync(VideoCard videoCard)
        {
            var entity = videoCard.ToEntity();
            _db.VideoCards.Add(entity);
            await _db.SaveChangesAsync();
            return entity.ToDto();
        }

        /// <inheritdoc />
        public async Task DeleteAsync(int id)
        {
            var videoCardEntity = await _db.VideoCards.FindAsync(id)
                ?? throw new Exception("Not found");

            try
            {
                _db.VideoCards.Remove(videoCardEntity);
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateException ex) when (ex.InnerException is SqlException)
            {
                if (ex.InnerException.Message.ToLower().Contains("reference constraint"))
                {
                    throw new Exception("Reference constraint");
                }
                throw;
            }
            catch (Exception)
            {
                throw;
            }

            return;
        }

        /// <inheritdoc />
        public async Task<VideoCard?> GetAsync(int id)
        {
            return await _db.VideoCards.FindAsync(id)
                is VideoCardEntity model
                    ? model.ToDto()
                    : null;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<VideoCard>> GetAllAsync(int? page, int? pageSize)
        {
            var entities = _db.VideoCards.AsQueryable();
            
            if (page.HasValue && pageSize.HasValue)
            {
                var skip = (page.Value - 1) * pageSize.Value;
                entities = entities.Skip(skip).Take(pageSize.Value);
            }
                
            var entitiesList = await entities.ToListAsync();
            return entitiesList.ToDto();
        }

        /// <inheritdoc />
        public async Task<VideoCard> UpdateAsync(VideoCard videoCard)
        {
            var videoCardEntity = await _db.VideoCards.FindAsync(videoCard.VideoCardId) 
                ?? throw new Exception("Video card not found");

            videoCard.Merge(videoCardEntity);
            _db.Update(videoCardEntity);
            await _db.SaveChangesAsync();

            return videoCardEntity.ToDto();
        }
    }
}
