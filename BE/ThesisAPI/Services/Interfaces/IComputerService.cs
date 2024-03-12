using ThesisAPI.DTOs;

namespace ThesisAPI.Services.Interfaces
{
    public interface IComputerService
    {
        /// <summary>
        /// Gets all the computers
        /// </summary>
        /// <returns>A collection of computers</returns>
        Task<IEnumerable<ComputerOut>> GetAllAsync(int? page, int? pageSize);

        /// <summary>
        /// Gets a single computer
        /// </summary>
        /// <param name="id">The id of the computer</param>
        /// <returns>A single computer</returns>
        Task<ComputerOut?> GetAsync(int id);

        /// <summary>
        /// Adds a new computer
        /// </summary>
        /// <param name="computer">The new computer</param>
        /// <returns>The newly added computer</returns>
        Task<ComputerOut> AddAsync(ComputerOut computer);
    }
}
