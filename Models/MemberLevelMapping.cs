using System;
using System.Collections.Generic;

namespace Supermarket.Models
{
    public partial class MemberLevelMapping
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int LevelId { get; set; }

        public virtual Level Level { get; set; }
        public virtual Member Member { get; set; }
    }
}
