using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oscar.Models.Entities
{
    public class Customer
    {
        public int Id { get; set; }

        public String FirstName { get; set; }

        public String LastName { get; set; }

        public Adress Adress { get; set; }

        public String Phone { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
