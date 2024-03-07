#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ThesisAPI.Models
{
    public partial class PowerSupplyEntity
    {
        public PowerSupplyEntity()
        {
            Computers = new HashSet<ComputerEntity>();
        }

        [Key]
        public int PowerSupplyId { get; set; }
        public string PowerSupplyDesc { get; set; }

        public virtual ICollection<ComputerEntity> Computers { get; set; }
    }
}