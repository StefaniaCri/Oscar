using Oscar.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oscar.Models.DTO
{
    public class AdressDTO
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string Country { get; set; }

        public AdressDTO(Adress a)
        {
            this.City = a.City;
            this.Street = a.Street;
            this.Country = a.Country;
        }

    }
}
