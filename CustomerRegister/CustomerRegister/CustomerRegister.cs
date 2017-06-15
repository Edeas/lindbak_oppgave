using CustomerRegister.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerRegister
{
    public class CustomerRegister
    {
        private Dictionary<int, Customer> Register = new Dictionary<int, Customer>();
        private int NextId = 0;

        public bool Add(Customer customer)
        {
            // Give a new customer a unique new id
            if (customer.Id == -1) customer.Id = NextId++;

            // Check if customer already is in list
            else if (Register.ContainsKey(customer.Id)) return false;

            this.Register.Add(customer.Id, customer);
            return true;
        }

        public bool Remove(Customer customer)
        {
            // Check if customer is in list
            if (Register.ContainsKey(customer.Id))
            {
                Register.Remove(customer.Id);
                return true;
            }
            else return false;
        }

        public bool UpdateEntry(Customer customer)
        {
            if (!this.Remove(customer)) return false;
            return this.Add(customer);
        }

        public Customer Get(int id)
        {
            return this.Register[id];
        }

        public List<Customer> GetAll()
        {
            return this.Register.Values.ToList<Customer>();
        }
    }
}