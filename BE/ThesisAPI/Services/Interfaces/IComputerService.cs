using ThesisAPI.DTOs;

namespace ThesisAPI.Services.Interfaces
{
    public interface IComputerService
    {
        /// <summary>
        /// Gets all the computers
        /// </summary>
        /// <param name="page">The page of the data to retrieve</param>
        /// <param name="pageSize">The size of the page</param>
        /// <param name="uom">The unit of measure to return the weight in (lb or kg)</param>
        /// <returns>A collection of computers</returns>
        Task<IEnumerable<ComputerOut>> GetAllAsync(int? page, int? pageSize, string? uom);

        /// <summary>
        /// Gets a single computer
        /// </summary>
        /// <param name="id">The id of the computer</param>
        /// <param name="uom">The unit of measure to return the weight in (lb or kg)</param>
        /// <returns>A single computer</returns>
        Task<ComputerOut?> GetAsync(int id, string? uom);

        /// <summary>
        /// Adds a new computer
        /// </summary>
        /// <param name="computer">The new computer</param>
        /// <returns>The newly added computer</returns>
        Task<ComputerOut> AddAsync(ComputerIn computer);
    }
}
