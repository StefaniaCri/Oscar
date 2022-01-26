using Oscar.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oscar.Models.DTO
{
    public class CustomerDTO
    {
        public int Id { get; set; }

        public String FirstName { get; set; }

        public String LastName { get; set; }

        public Adress Adress { get; set; }

        public String Phone { get; set; }
        public CustomerDTO(Customer cust)
        {
            this.Id = cust.Id;
            this.FirstName = cust.FirstName;
            this.LastName = cust.LastName;
            this.Adress = cust.Adress;
            this.Phone = cust.Phone;
        }

    }
}
