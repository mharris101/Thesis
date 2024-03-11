using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThesisAPI.DTOs;
using ThesisAPI.Models;

namespace ThesisAPI.Controllers
{
    public static class ComputerEndpoints
    {
        public static void MapComputerEndpoints(this IEndpointRouteBuilder routes)
        {
            // GET All
            routes.MapGet("/api/Computers", async ([FromQuery] int? page, [FromQuery] int? pageSize, ThesisContext db) =>
            {
                page ??= 1;
                pageSize ??= 10;
                var skip = (page.Value - 1) * pageSize.Value;

                var computers = await db.Computers.Select(c =>
                    new Computer
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
                    }).ToListAsync();

                return computers;
            })
            .WithName("GetAllComputers")
            .Produces<List<Computer>>(StatusCodes.Status200OK);

        }
    }
}
