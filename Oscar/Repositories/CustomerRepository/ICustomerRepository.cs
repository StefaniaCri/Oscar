using Oscar.Models.Entities;
using Oscar.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oscar.Repositories.CustomerRepository { 
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task<List<Customer>> GetAllCLientswithAdress();
    }
}
