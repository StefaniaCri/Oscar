using Oscar.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oscar.Models.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }

        public DateTime OrderPlaced { get; set; }

        public Boolean OrderFulfiled { get; set; }

        public CustomerDTO CustomerDto { get; set; }

        public ICollection<ProductOrder> ProductOrders { get; set; }


    }
}