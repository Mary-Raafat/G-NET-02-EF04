using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_NET_02_EF04.Models
{
    public class Account
    {
        public int Id { get; set; }
        public decimal CurrentBalance { get; set; }
        public string AccountType { get; set; } = null!;

        public DateTime OpeningDate { get; set; }

        //one to many
        public string BranchId { get; set; }
        public Branch Branch { get; set; }

        //one to many 
        public ICollection<Transaction> Transactions { get; set; }

        //many to many
        public ICollection<CustomerAccount> CustomerAccounts { get; set; }

    }
}
