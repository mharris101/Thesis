#nullable disable
using System;
using System.Collections.Generic;

namespace ThesisAPI.Models
{
    public partial class WeightUnitEntity
    {
        public WeightUnitEntity()
        {
            Computers = new HashSet<ComputerEntity>();
        }

        public int WeightUnitId { get; set; }
        public string WeightUnitDesc { get; set; }

        public virtual ICollection<ComputerEntity> Computers { get; set; }
    }
}