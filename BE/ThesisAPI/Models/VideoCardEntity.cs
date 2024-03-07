#nullable disable
using System;
using System.Collections.Generic;

namespace ThesisAPI.Models
{
    public partial class VideoCardEntity
    {
        public VideoCardEntity()
        {
            Computers = new HashSet<ComputerEntity>();
        }

        public int VideoCardId { get; set; }
        public string VideoCardDesc { get; set; }

        public virtual ICollection<ComputerEntity> Computers { get; set; }
    }
}