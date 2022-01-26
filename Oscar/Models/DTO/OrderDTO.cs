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

        public int CustomerId { get; set; }

        public ICollection<ProductOrder> ProductOrders { get; set; }

        public OrderDTO(Order order)
        {
            this.Id = order.Id;
            this.OrderPlaced = order.OrderPlaced;
            this.OrderFulfiled = order.OrderFulfiled;
            this.CustomerId = order.CustomerId;
            this.ProductOrders = order.ProductOrders;
        }
    }
}