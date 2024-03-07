#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ThesisAPI.Models
{
    public partial class DiskEntity
    {
        public DiskEntity()
        {
            Computers = new HashSet<ComputerEntity>();
        }

        [Key]
        public int DiskId { get; set; }
        public string DiskSize { get; set; }
        public int DiskTypeId { get; set; }

        public virtual DiskTypeEntity DiskType { get; set; }
        public virtual ICollection<ComputerEntity> Computers { get; set; }
    }
}