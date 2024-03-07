#nullable disable
using System;
using System.Collections.Generic;

namespace ThesisAPI.Models
{
    public partial class ProcessorEntity
    {
        public ProcessorEntity()
        {
            Computers = new HashSet<ComputerEntity>();
        }

        public int ProcessorId { get; set; }
        public string ProcessorDesc { get; set; }

        public virtual ICollection<ComputerEntity> Computers { get; set; }
    }
}