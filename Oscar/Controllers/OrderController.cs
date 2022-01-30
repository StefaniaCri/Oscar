using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Oscar.Models.DTO;
using Oscar.Models.Entities;
using Oscar.Repositories.OrderRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oscar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _repository;

        public OrderController(IOrderRepository repository)
        {
            _repository = repository;
        }

        //adaugarea unei comenzi
        [HttpPost]
        public async Task<IActionResult> CreateOrder(AddOrder dto)
        {
            Order newOrder = new Order();

            newOrder.OrderPlaced = dto.OrderPlaced;
            newOrder.OrderFulfiled = dto.OrderFulfiled;
            newOrder.CustomerId = dto.CustomerId;
            newOrder.ProductOrders = dto.ProductOrders;
            _repository.Create(newOrder);

            await _repository.SaveAsync();

            return Ok(new OrderDTO(newOrder));
        }

        //aduce toate comenzile date de un client
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllOrderofClient(int id)
        {
            var orders = await _repository.GetAll().Where(p => p.CustomerId == id).ToListAsync();

            var returnOrders = new List<OrderDTO>();

            foreach (var order in orders)
            {
                returnOrders.Add(new OrderDTO(order));
            }

            return Ok(returnOrders);
        }

        //update pentru cand o comanda a fost livrata
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id)
        {
            Order order = await _repository.GetByIdAsync(id);

            if (order == null)
            {
                return NotFound("Order does not exist!");
            }

            order.OrderFulfiled = true;

            await _repository.SaveAsync();

            return Ok(new OrderDTO(order));

        }
    }
}
