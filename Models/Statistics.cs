using System;
using System.Collections.Generic;

namespace Supermarket.Models
{
    public partial class Statistics
    {
        public int Id { get; set; }
        public int? MemberId { get; set; }
        public double? TotalPayment { get; set; }
        public double? TotalDiscount { get; set; }
        public double? CreditsChange { get; set; }

        public virtual Member Member { get; set; }
    }
}
