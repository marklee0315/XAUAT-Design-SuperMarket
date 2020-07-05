using System;
using System.Collections.Generic;

namespace Supermarket.Models
{
    public partial class Level
    {
        public Level()
        {
            MemberLevelMapping = new HashSet<MemberLevelMapping>();
        }

        public int Id { get; set; }
        public string Grade { get; set; }
        public double? DiscountRate { get; set; }

        public virtual ICollection<MemberLevelMapping> MemberLevelMapping { get; set; }
    }
}
