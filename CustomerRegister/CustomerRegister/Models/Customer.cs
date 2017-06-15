using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerRegister.Models
{
    public class Customer
    {
      
        public string Email      { get; set; }
        public string FirstName  { get; set; }
        public string LastName   { get; set; }
        public string Address    { get; set; }
        public string PostalCode { get; set; }
        public int Id { get; set; } = -1;
    }
}