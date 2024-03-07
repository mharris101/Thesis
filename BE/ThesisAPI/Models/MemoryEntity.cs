#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ThesisAPI.Models
{
    public partial class MemoryEntity
    {
        [Key]
        public int MemoryId { get; set; }
        public string MemoryDesc { get; set; }
    }
}