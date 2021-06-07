using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreGym.Models
{
    public class TransactionModel
    {
        public int? MembershipId { get; set; }
        public DateTime? Sold { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
       
        public string Name { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public int? RoleId { get; set; }
       
        public int? PaymentTypeId { get; set; }

        public string HolderName { get; set; }
        public string ExpDate { get; set; }
    }
}
