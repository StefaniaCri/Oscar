using Microsoft.EntityFrameworkCore;
using Oscar.Data;
using Oscar.Models.Entities;
using Oscar.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oscar.Repositories.CustomerRepository
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DataContext context) : base(context) { }

        public async Task<List<Customer>> GetAllCLientswithAdress()
        {
            return await _context.Customers.Include(a => a.Adress).ToListAsync();
        }
    }
}
