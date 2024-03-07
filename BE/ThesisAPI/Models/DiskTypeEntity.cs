#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ThesisAPI.Models
{
    public partial class DiskTypeEntity
    {
        public DiskTypeEntity()
        {
            Disks = new HashSet<DiskEntity>();
        }

        [Key]
        public int DiskTypeId { get; set; }
        public string DiskTypeDesc { get; set; }

        public virtual ICollection<DiskEntity> Disks { get; set; }
    }
}