using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Controllers.api
{
    public class CustomerController : ApiController
    {
        private VidlyContext _context;
        public CustomerController()
        {
            _context = new VidlyContext();

        }

        // get all customers
        public IHttpActionResult GetCustomers()
        {
            return Ok(_context.Customers.ToList().Select(Mapper.Map < Customer, CustomerDto>));

        }
        //get specific customer
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.Id == id);
            if (customer == null)
                return NotFound();

            else
            {
                return Ok(Mapper.Map<Customer, CustomerDto>(customer));
            }
        }
        //add new customer
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerdto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var cust = Mapper.Map<CustomerDto, Customer>(customerdto);
            _context.Customers.Add(cust);
            _context.SaveChanges();
            customerdto.Id = cust.Id;

            return Created(new Uri(Request.RequestUri + "/" + cust.Id), customerdto);

        }

        //edit customer
        [HttpPut]
        public IHttpActionResult EditCustomer(int id,CustomerDto customerdto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var cust = _context.Customers.SingleOrDefault(x => x.Id ==id);
            if (cust == null)
                return NotFound();
            Mapper.Map<CustomerDto, Customer>(customerdto, cust);
            _context.SaveChanges();
            return Ok(customerdto);

        }

        //delete customer
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var cust = _context.Customers.SingleOrDefault(x => x.Id == id);
            if (cust == null)
                return NotFound();
            _context.Customers.Remove(cust);
            _context.SaveChanges();
            return Ok();

        }
   
    }
}
