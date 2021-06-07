using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NetCoreGym.Models
{
    public partial class Invoices
    {
        public int Id { get; set; }
        public int? MembershipId { get; set; }
        public int? MemberId { get; set; }
        public int? PaymentId { get; set; }
        public DateTime? Sold { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
    }
}
