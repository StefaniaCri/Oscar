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

        public string Name { get; set; }

        public AdressDTO Adress { get; set; }

        public String Phone { get; set; }
    

    }
}
