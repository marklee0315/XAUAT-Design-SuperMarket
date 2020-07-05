using System;
using System.Collections.Generic;

namespace Supermarket.Models
{
    public partial class Good
    {
        public Good()
        {
            MemberGoodMapping = new HashSet<MemberGoodMapping>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double? Price { get; set; }

        public virtual ICollection<MemberGoodMapping> MemberGoodMapping { get; set; }
    }
}
