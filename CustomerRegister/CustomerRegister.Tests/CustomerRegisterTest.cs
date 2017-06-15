using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomerRegister.Models;
using System.Collections.Generic;

namespace CustomerRegister.Tests
{
    [TestClass]
    public class CustomerRegisterTest
    {
        [TestMethod]
        public void TestAdd()
        {
            CustomerRegister Register = new CustomerRegister();

            Register.Add(new Customer { Id = -1, Email = "test@example.com", FirstName = "Endre", LastName = "Larsen", Address = "gata 1", PostalCode = "0000" });

            Assert.IsTrue(Register.GetSize() == 1);

            Customer c = new Customer { Id = -1, Email = "test2@example.com", FirstName = "Lars", LastName = "Endresen", Address = "gata 2", PostalCode = "0001" };

            Register.Add(c);
            c.Id = 1;
            Assert.IsTrue(Register.GetSize() == 2);
            Assert.AreEqual(c, Register.Get(1));
        }

        [TestMethod]
        public void TestRemove()
        {
            CustomerRegister Register = new CustomerRegister();

            Register.Add(new Customer { Id = 0, Email = "test@example.com", FirstName = "Endre", LastName = "Larsen", Address = "gata 1", PostalCode = "0000" });
            Customer c = new Customer { Id = 1, Email = "test2@example.com", FirstName = "Lars", LastName = "Endresen", Address = "gata 2", PostalCode = "0001" };
            Register.Add(c);

            Assert.IsTrue(Register.GetSize() == 2);
            Register.Remove(c);

            Assert.IsTrue(Register.GetSize() == 1);
        }

        [TestMethod]
        public void TestGetAll()
        {
            CustomerRegister Register = new CustomerRegister();

            Customer c1 = new Customer { Id = 0, Email = "test@example.com", FirstName = "Endre", LastName = "Larsen", Address = "gata 1", PostalCode = "0000" };
            Customer c2 = new Customer { Id = 1, Email = "test2@example.com", FirstName = "Lars", LastName = "Endresen", Address = "gata 2", PostalCode = "0001" };
            Register.Add(c1);
            Register.Add(c2);

            List<Customer> list = Register.GetAll();

            Assert.IsTrue(list.Count == 2);
            Assert.AreEqual(c1, list[0]);
            Assert.AreEqual(c2, list[1]);
        }

        [TestMethod]
        public void TestUpdateEntry()
        {
            CustomerRegister Register = new CustomerRegister();

            Customer c1 = new Customer { Id = 0, Email = "test@example.com", FirstName = "Ender", LastName = "Larsen", Address = "gata 1", PostalCode = "0000" };
            Customer c2 = new Customer { Id = 1, Email = "test2@example.com", FirstName = "Lars", LastName = "Endresen", Address = "gata 2", PostalCode = "0001" };
            Register.Add(c1);
            Register.Add(c2);

            c1.FirstName = "Endre";

            Register.UpdateEntry(c1);
            
            Assert.AreEqual(c1, Register.Get(0));
        }
    }
}
