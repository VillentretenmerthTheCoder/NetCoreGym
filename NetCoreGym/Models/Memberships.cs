using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NetCoreGym.Models
{
    public partial class Memberships
    {
        public int MembershipId { get; set; }
        public int? TypeId { get; set; }
        public bool? Active { get; set; }
        public int? Price { get; set; }
        public int? Valid { get; set; }
    }
}
