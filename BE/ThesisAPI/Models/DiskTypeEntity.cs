#nullable disable
using System;
using System.Collections.Generic;

namespace ThesisAPI.Models
{
    public partial class DiskTypeEntity
    {
        public DiskTypeEntity()
        {
            Disks = new HashSet<DiskEntity>();
        }

        public int DiskTypeId { get; set; }
        public string DiskTypeDesc { get; set; }

        public virtual ICollection<DiskEntity> Disks { get; set; }
    }
}