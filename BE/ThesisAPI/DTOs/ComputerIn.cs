#nullable disable
namespace ThesisAPI.DTOs
{
    public class ComputerIn
    {
        public int ComputerId { get; set; }
        public int DiskId { get; set; }
        public int VideoCardId { get; set; }
        public int WeightAmount { get; set; }
        public int WeightUnitId { get; set; }
        public int PowerSupplyId { get; set; }
        public int MemoryId { get; set; }
        public int ProcessorId { get; set; }

        public int[] UsbTypeIds { get; set; }
    }
}
