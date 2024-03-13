#nullable disable
using System.ComponentModel.DataAnnotations;

namespace ThesisAPI.Models
{
    public partial class ComputerEntity
    {
        public ComputerEntity()
        {
            ComputerUsbs = new HashSet<ComputerUsbEntity>();
        }

        [Key]
        public int ComputerId { get; set; }
        public int? DiskId { get; set; }
        public int? VideoCardId { get; set; }
        public int? WeightAmount { get; set; }
        public int? WeightUnitId { get; set; }
        public int? PowerSupplyId { get; set; }
        public int? ProcessorId { get; set; }
        public int? MemoryId { get; set; }

        public virtual DiskEntity Disk { get; set; }
        public virtual PowerSupplyEntity PowerSupply { get; set; }
        public virtual ProcessorEntity Processor { get; set; }
        public virtual VideoCardEntity VideoCard { get; set; }
        public virtual WeightUnitEntity WeightUnit { get; set; }
        public virtual MemoryEntity Memory { get; set; }
        public virtual ICollection<ComputerUsbEntity> ComputerUsbs { get; set; }
    }
}