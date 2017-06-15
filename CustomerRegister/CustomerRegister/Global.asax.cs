using CustomerRegister.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace CustomerRegister
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            CustomerRegister Register = new CustomerRegister();
            HttpContext.Current.Cache["CustomerRegister"] = Register;


            Register.Add(new Customer { Id = -1, Email = "test@example.com", FirstName = "Endre", LastName = "Larsen", Address = "gata 1", PostalCode = "0000" });
            Register.Add(new Customer { Id = -1, Email = "test2@example.com", FirstName = "Lars", LastName = "Endresen", Address = "gata 2", PostalCode = "0001" });
        }
    }
}
