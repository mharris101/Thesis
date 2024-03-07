#nullable disable
using System;
using System.Collections.Generic;

namespace ThesisAPI.Models
{
    public partial class UsbTypeEntity
    {
        public UsbTypeEntity()
        {
            ComputerUsbs = new HashSet<ComputerUsbEntity>();
        }

        public int UsbTypeId { get; set; }
        public string UsbTypeDesc { get; set; }

        public virtual ICollection<ComputerUsbEntity> ComputerUsbs { get; set; }
    }
}