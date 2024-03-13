using ThesisAPI.DTOs;

namespace ThesisAPI.Services.Interfaces
{
    public interface IVideoCardService
    {
        /// <summary>
        /// Gets all the video cards
        /// </summary>
        /// <param name="page">The page of the data to retrieve</param>
        /// <param name="pageSize">The size of the page</param>
        /// <returns>A collection of video cards</returns>
        Task<IEnumerable<VideoCard>> GetAllAsync(int? page = 1, int? pageSize = 10);

        /// <summary>
        /// Gets a single video card
        /// </summary>
        /// <param name="id">The id of the video card</param>
        /// <returns>A single video card</returns>
        Task<VideoCard?> GetAsync(int id);

        /// <summary>
        /// Adds a new video card
        /// </summary>
        /// <param name="videoCard">The new video card</param>
        /// <returns>The newly added video card</returns>
        Task<VideoCard> AddAsync(VideoCard videoCard);

        /// <summary>
        /// Updates an existing video card
        /// </summary>
        /// <param name="videoCard">The video card with updated values</param>
        /// <returns>The updated video card</returns>
        Task<VideoCard> UpdateAsync(VideoCard videoCard);

        /// <summary>
        /// Deletes a video card
        /// </summary>
        /// <param name="id"></param>
        Task DeleteAsync(int id);
    }
}
