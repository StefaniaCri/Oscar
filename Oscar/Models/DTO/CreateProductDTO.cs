using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oscar.Models.DTO
{
    public class CreateProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string PhotoFileName { get; set; }
    }
}
