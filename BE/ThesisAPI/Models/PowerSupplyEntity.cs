#nullable disable
using System;
using System.Collections.Generic;

namespace ThesisAPI.Models
{
    public partial class PowerSupplyEntity
    {
        public PowerSupplyEntity()
        {
            Computers = new HashSet<ComputerEntity>();
        }

        public int PowerSupplyId { get; set; }
        public string PowerSupplyDesc { get; set; }

        public virtual ICollection<ComputerEntity> Computers { get; set; }
    }
}