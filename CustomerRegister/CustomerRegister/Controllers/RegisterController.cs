using CustomerRegister.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace CustomerRegister.Controllers
{
    public class RegisterController : ApiController
    {

        // Get the stored data
        private CustomerRegister register = (CustomerRegister) HttpContext.Current.Cache["CustomerRegister"];

        // GET: /api/Register/GetAllCustomers
        public IEnumerable<Customer> GetAllCustomers()
        {
            return register.GetAll();
        }

        // GET: /api/Register/GetCustomer/<id>
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = register.Get(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        // POST: /api/Register/DeleteCustomer
        [HttpPost]
        public void DeleteCustomer([FromBody]Customer customer)
        {
            register.Remove(customer);
        }

        // POST: /api/Register/UpdateCustomer
        [HttpPost]
        public void UpdateCustomer([FromBody]Customer customer)
        {
            register.UpdateEntry(customer);
        }

        // POST: /api/Register/AddCustomer
        [HttpPost]
        public void AddCustomer([FromBody]Customer customer)
        {
            register.Add(customer);
        }
    }
}