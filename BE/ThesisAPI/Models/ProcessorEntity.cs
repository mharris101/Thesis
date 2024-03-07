#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ThesisAPI.Models
{
    public partial class ProcessorEntity
    {
        public ProcessorEntity()
        {
            Computers = new HashSet<ComputerEntity>();
        }

        [Key]
        public int ProcessorId { get; set; }
        public string ProcessorDesc { get; set; }

        public virtual ICollection<ComputerEntity> Computers { get; set; }
    }
}