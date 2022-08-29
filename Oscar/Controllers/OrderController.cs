using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Oscar.Models.DTO;
using Oscar.Models.Entities;
using Oscar.Repositories.CustomerRepository;
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
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;

        public OrderController(IOrderRepository repository, IMapper mapper, ICustomerRepository customerRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        //adaugarea unei comenzi
        
        [HttpPost]
        public async Task<IActionResult> CreateOrder(AddOrder dto)
        {
            var order = _mapper.Map<Order>(dto);
            order.Customer = await _customerRepository.GetByIdAsync(dto.CustomerId);
            _repository.Create(order);
            await _repository.SaveAsync();
            return Ok(order);
        }
        
        [HttpGet]
        [ProducesResponseType(typeof(OrderDTO),200)]
        public async Task<IActionResult> GetAllOrdersAsync()
        {
            var orders = await _repository.GetAll().Include(c=>c.Customer).ToListAsync();
            var ordersDTO = _mapper.Map<List<OrderDTO>>(orders);
            return Ok(ordersDTO);

        }
        
        //aduce toate comenzile date de un client
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllOrderofClient(int id)
        {
            var orders = await _repository.GetAll().Include(c=>c.Customer).Where(p => p.CustomerId == id).Include(a => a.Customer.Adress).ToListAsync();

            var returnOrders = _mapper.Map<List<OrderDTO>>(orders);

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

            return Ok(_mapper.Map<OrderDTO>(order));
        }
      
    }
}
