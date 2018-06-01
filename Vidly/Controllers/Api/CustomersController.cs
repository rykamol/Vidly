using AutoMapper;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: api/Customers
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(_context.Customers.Include(x => x.MemberShipType).ToList().Select(Mapper.Map<Customer, CustomerDto>));
        }

        // GET: api/Customers/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var customer = _context.Customers.Single(x => x.Id == id);
            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        // POST: api/Customers
        [HttpPost]
        public IHttpActionResult Post(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        // PUT: api/Customers/5
        [HttpPut]
        public IHttpActionResult Put(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == customerDto.Id);
            if (customerInDb == null)
                return NotFound();

            Mapper.Map(customerDto, customerInDb);
            _context.SaveChanges();
            return Ok(customerDto);
        }

        // DELETE: api/Customers/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                return NotFound();

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
