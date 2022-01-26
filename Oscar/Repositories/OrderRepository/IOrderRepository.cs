using Oscar.Models.Entities;
using Oscar.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oscar.Repositories.OrderRepository
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        public Task<List<Order>> GetAllAuthorsWithAddress(int CustomerId);

    }
}
