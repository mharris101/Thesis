using ThesisAPI.DTOs;
using ThesisAPI.Models;

namespace ThesisAPI.Converters
{
    public static class ComputerConverter
    {
        public static ComputerEntity ToEntity(this ComputerIn dto) => new()
        {
            ComputerId = dto.ComputerId,
            DiskId = dto.DiskId,
            VideoCardId = dto.VideoCardId,
            WeightAmount = dto.WeightAmount,
            WeightUnitId = dto.WeightUnitId,
            PowerSupplyId = dto.PowerSupplyId,
            ProcessorId = dto.ProcessorId,
            MemoryId = dto.MemoryId
        };
    }
}
