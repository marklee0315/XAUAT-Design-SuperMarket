using System;
using System.Collections.Generic;

namespace Supermarket.Models
{
    public partial class Member
    {
        public Member()
        {
            MemberGoodMapping = new HashSet<MemberGoodMapping>();
            MemberLevelMapping = new HashSet<MemberLevelMapping>();
            Statistics = new HashSet<Statistics>();
        }

        public int Id { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        public double? Credit { get; set; }
        public string Password { get; set; }

        public virtual ICollection<MemberGoodMapping> MemberGoodMapping { get; set; }
        public virtual ICollection<MemberLevelMapping> MemberLevelMapping { get; set; }
        public virtual ICollection<Statistics> Statistics { get; set; }
    }
}
