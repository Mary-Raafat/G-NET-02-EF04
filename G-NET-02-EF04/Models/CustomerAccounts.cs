using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_NET_02_EF04.Models
{
    public class CustomerAccount
    {

        public int AccountId { get; set; }
        public Account Account { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public DateTime OwnershipStartDate { get; set; }
        public string OwnershipType { get; set; }
        public string AccountStatus { get; set; }
    }
}
