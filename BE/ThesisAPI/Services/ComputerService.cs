using Microsoft.EntityFrameworkCore;
using ThesisAPI.Converters;
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

        /// <inheritdoc />
        public async Task<ComputerOut> AddAsync(ComputerIn computer)
        {
            var computerEntity = new ComputerEntity();

            await _db.Database.BeginTransactionAsync();
            try
            {
                computerEntity = computer.ToEntity();
                await _db.Computers.AddAsync(computerEntity);
                await _db.SaveChangesAsync();

                var usbEntities = new List<ComputerUsbEntity>();
                foreach(var usbTypeId in computer.UsbTypeIds)
                {
                    usbEntities.Add(new ComputerUsbEntity() 
                    { 
                        ComputerId = computerEntity.ComputerId, 
                        UsbTypeId = usbTypeId 
                    });
                }
                await _db.ComputerUsbs.AddRangeAsync(usbEntities);
                await _db.SaveChangesAsync();

                await _db.Database.CommitTransactionAsync();
            }
            catch (Exception)
            {
                await _db.Database.RollbackTransactionAsync();
                throw;
            }

            return await GetAsync(computerEntity.ComputerId);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<ComputerOut>> GetAllAsync(int? page, int? pageSize, string? uom = "")
        {
            var entities = getComputerOutQueryable(uom);

            if (page.HasValue && pageSize.HasValue)
            {
                var skip = (page.Value - 1) * pageSize.Value;
                entities = entities.Skip(skip).Take(pageSize.Value);
            }

            var entitiesList = await entities.ToListAsync();
            return entitiesList;
        }

        /// <inheritdoc />
        public async Task<ComputerOut?> GetAsync(int id, string? uom = "")
        {
            return await getComputerOutQueryable(uom).FirstOrDefaultAsync(c => c.ComputerId == id);
        }

        /// <inheritdoc />
        private IQueryable<ComputerOut> getComputerOutQueryable(string? uom)
        {
            var co = new List<ComputerOut>().AsQueryable();
            co = _db.Computers.Select(c =>
                    new ComputerOut
                    {
                        ComputerId = c.ComputerId,
                        Disk = $"{c.Disk.DiskSize} {c.Disk.DiskType.DiskTypeDesc}",
                        VideoCard = c.VideoCard.VideoCardDesc,
                        Weight = ConvertWeight(c.WeightAmount.Value, c.WeightUnit.WeightUnitDesc, uom), //$"{c.WeightAmount} {c.WeightUnit.WeightUnitDesc}",
                        PowerSupply = c.PowerSupply.PowerSupplyDesc,
                        Memory = c.Memory.MemoryDesc,
                        Processor = c.Processor.ProcessorDesc,
                        Usb = string.Join(", ", c.ComputerUsbs
                                                    .GroupBy(cu => cu.UsbType.UsbTypeDesc)
                                                    .Select(g => $"{g.Count()} x {g.Key}")
                        )
                    });

            return co;
        }

        private static string ConvertWeight(int weightAmount, string currentUom, string? requestedUom)
        {
            if (currentUom == requestedUom || string.IsNullOrWhiteSpace(requestedUom))
            {
                return $"{weightAmount} {currentUom}";
            }

            decimal weight = 0.0m;
            if (currentUom == "kg" && requestedUom == "lb")
            {
                weight = ConvertKilogramsToPounds(weightAmount);
            }
            else if (currentUom == "lb" && requestedUom == "kg")
            {
                weight = ConvertPoundsToKilograms(weightAmount);
            }

            return $"{weight.ToString():0.0} {requestedUom}";
        }

        private static decimal ConvertPoundsToKilograms(decimal weight)
        {
            return decimal.Multiply(weight, 0.453m);
        }

        private static decimal ConvertKilogramsToPounds(decimal weight)
        {
            return decimal.Multiply(weight, 2.205m);
        }
    }
}
