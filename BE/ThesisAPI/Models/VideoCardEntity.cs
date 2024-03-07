#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ThesisAPI.Models
{
    public partial class VideoCardEntity
    {
        public VideoCardEntity()
        {
            Computers = new HashSet<ComputerEntity>();
        }

        [Key]
        public int VideoCardId { get; set; }
        public string VideoCardDesc { get; set; }

        public virtual ICollection<ComputerEntity> Computers { get; set; }
    }
}