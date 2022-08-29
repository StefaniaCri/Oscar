using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Oscar.Models.DTO;
using Oscar.Models.Entities;
using Oscar.Repositories.CustomerRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oscar.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _repository;

        public CustomerController(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]

        //adaugarea unui nou client in BD
        public async Task<IActionResult> CreateCustomer(CreateClient dto)
        {
            var customer = _mapper.Map<Customer>(dto);

            _repository.Create(customer);
            await _repository.SaveAsync();
            return Ok(customer);

        }

        //Toti clientii si adresele lor
        [HttpGet]
        public async Task<IActionResult> GetAllClients()
        {
            var customers = await _repository.GetAll().Include(a => a.Adress).ToListAsync();
            var customerDTO = _mapper.Map<List<CustomerDTO>>(customers);
            return Ok(customerDTO);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerbyId(int id)
        {
            var customer = await _repository.GetByIdAsync(id);
            var customerDTO = _mapper.Map<CustomerDTO>(customer);
            if (customerDTO == null)
            {
                return NotFound("Customer not found");
            }
            return Ok(customerDTO);
        }
        
        //Update pentru client: isi poate schimba numele sau numarul de telefon
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, string phone = "idem", string first = "idem",string last="idem")
        {
            Customer cust = await _repository.GetByIdAsync(id);

            if (cust == null)
            {
                return NotFound("Customer does not exist!");
            }
            if(phone != "idem")
                cust.Phone = phone;

            if (first != "idem")
                cust.FirstName = first;

            if (last != "idem")
                cust.LastName = last;
            await _repository.SaveAsync();

            var customerDTO = _mapper.Map<CustomerDTO>(cust);
            return Ok(customerDTO);

        }

        //stergerea unui client din db
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCust(int id)
        {
            var cust = await _repository.GetByIdAsync(id);

            if (cust == null)
            {
                return NotFound("Customer does not exist!");
            }

            _repository.Delete(cust);

            await _repository.SaveAsync();

            return NoContent();
        }

  
    }
    }

