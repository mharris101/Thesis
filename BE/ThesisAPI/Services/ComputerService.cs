using Microsoft.EntityFrameworkCore;
using ThesisAPI.DTOs;
using ThesisAPI.Models;
using ThesisAPI.Services.Interfaces;

namespace ThesisAPI.Services
{
    public class ComputerService : IComputerService
    {
        public ThesisContext _db;

        public ComputerService(ThesisContext db)
        {
            _db = db;
        }

        public async Task<ComputerOut> AddAsync(ComputerOut computer)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ComputerOut>> GetAllAsync(int? page, int? pageSize)
        {
            var entities = _db.Computers.Select(c =>
                    new ComputerOut
                    {
                        ComputerId = c.ComputerId,
                        Disk = $"{c.Disk.DiskSize} {c.Disk.DiskType.DiskTypeDesc}",
                        VideoCard = c.VideoCard.VideoCardDesc,
                        Weight = $"{c.WeightAmount} {c.WeightUnit.WeightUnitDesc}",
                        PowerSupply = c.PowerSupply.PowerSupplyDesc,
                        Memory = c.Memory.MemoryDesc,
                        Processor = c.Processor.ProcessorDesc,
                        Usb = string.Join(", ", c.ComputerUsbs
                                                    .GroupBy(cu => cu.UsbType.UsbTypeDesc)
                                                    .Select(g => $"{g.Count()} x {g.Key}")
                        )
                    });

            if (page.HasValue && pageSize.HasValue)
            {
                var skip = (page.Value - 1) * pageSize.Value;
                entities = entities.Skip(skip).Take(pageSize.Value);
            }

            var entitiesList = await entities.ToListAsync();
            return entitiesList;
        }

        public async Task<ComputerOut?> GetAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
