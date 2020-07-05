using System;
using System.Collections.Generic;

namespace Supermarket.Models
{
    public partial class MemberGoodMapping
    {
        public string Id { get; set; }
        public int? MemberId { get; set; }
        public int? GoodId { get; set; }
        public int? Quantity { get; set; }
        public string CreateTime { get; set; }

        public virtual Good Good { get; set; }
        public virtual Member Member { get; set; }
    }
}
