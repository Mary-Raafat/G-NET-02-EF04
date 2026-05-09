using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_NET_02_EF04.Models
{
    public class Branch
    {
        public string Code { get; set; }

        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;

        // one to one
        public int ManagerId { get; set; }
        public Manager Manager { get; set; }

        //one to many
        public ICollection<Account> Accounts { get; set; }

    }
}
