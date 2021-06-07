using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NetCoreGym.Models
{
    public partial class CreditCard
    {
        public int CreditId { get; set; }
        public string HolderName { get; set; }
        public string ExpDate { get; set; }
    }
}
