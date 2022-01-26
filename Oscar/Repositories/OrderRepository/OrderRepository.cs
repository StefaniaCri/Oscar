using Microsoft.EntityFrameworkCore;
using Oscar.Data;
using Oscar.Models.Entities;
using Oscar.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oscar.Repositories.OrderRepository
{
    public class OrderRepository: GenericRepository<Order>,IOrderRepository
    {
        public OrderRepository(DataContext context) : base(context) { }
        public async Task<List<Order>> GetAllAuthorsWithAddress(int CustomerId)
        {
            return await _context.Orders.Include(a => a.Customer).Where(c=> CustomerId ==c.CustomerId).ToListAsync();
        }


    }
}
