#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ThesisAPI.Models
{
    public partial class WeightUnitEntity
    {
        public WeightUnitEntity()
        {
            Computers = new HashSet<ComputerEntity>();
        }

        [Key]
        public int WeightUnitId { get; set; }
        public string WeightUnitDesc { get; set; }

        public virtual ICollection<ComputerEntity> Computers { get; set; }
    }
}