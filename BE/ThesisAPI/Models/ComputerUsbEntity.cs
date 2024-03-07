#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ThesisAPI.Models
{
    public partial class ComputerUsbEntity
    {
        [Key]
        public int ComputerUsbId { get; set; }
        public int? ComputerId { get; set; }
        public int? UsbTypeId { get; set; }

        public virtual ComputerEntity Computer { get; set; }
        public virtual UsbTypeEntity UsbType { get; set; }
    }
}