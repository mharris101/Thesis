#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ThesisAPI.Models
{
    public partial class UsbTypeEntity
    {
        public UsbTypeEntity()
        {
            ComputerUsbs = new HashSet<ComputerUsbEntity>();
        }

        [Key]
        public int UsbTypeId { get; set; }
        public string UsbTypeDesc { get; set; }

        public virtual ICollection<ComputerUsbEntity> ComputerUsbs { get; set; }
    }
}