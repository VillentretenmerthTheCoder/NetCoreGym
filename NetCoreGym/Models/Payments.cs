using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NetCoreGym.Models
{
    public partial class Payments
    {
        public int PaymentId { get; set; }
        public int? CreditId { get; set; }
        public int? PaymentTypeId { get; set; }
    }
}
