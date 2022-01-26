using Microsoft.EntityFrameworkCore;
using Oscar.Data;
using Oscar.Models.Entities;
using Oscar.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oscar.Repositories.ProductRepository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(DataContext context) : base(context) { }

    }
}
