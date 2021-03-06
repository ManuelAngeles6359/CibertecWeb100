using Cibertec.Models;
using Cibertec.Repositories.Dapper.Northwind;
using System;
using System.Linq;
using Xunit;

namespace Cibertec.Repositories.DapperTests
{
    public class CustomerRepositoryTest
    {

                
        private readonly NorthwindUnitOfWork unit;


        public CustomerRepositoryTest()
        {
            
            unit = new NorthwindUnitOfWork("Server=.;Database=Northwind_Lite; Trusted_Connection=True;MultipleActiveResultSets=True");

        }

        [Fact(DisplayName = "[CustomerRepository]Get All")]
        public void Customer_Repository_GetAll()
        {

            //var repo = new RepositoryEF<Customer>(_context);
            var result = unit.Customers.GetList();
            Assert.True(result.Count() > 0);
        }



        [Fact(DisplayName = "[CustomerRepository]Insert")]
        public void Customer_Repository_Insert()
        {
            Customer customer = GetNewCustomer();
            //var repo = new RepositoryEF<Customer>(_context);
            var result = unit.Customers.Insert(customer);
            Assert.True(result > 0);
        }


        [Fact(DisplayName = "[CustomerRepository]Delete")]
        public void Customer_Repository_Delete()
        {
            var customer = GetNewCustomer();
            //var repo = new RepositoryEF<Customer>(_context);
            var result = unit.Customers.Insert(customer);
            Assert.True(unit.Customers.Delete(customer));
        }



        private Customer GetNewCustomer()
        {
            return new Customer
            {
                City = "Lima",
                Country = "Peru",
                FirstName = "Julio",
                LastName = "Velarde",
                Phone = "555-555-555"
            };
        }


        [Fact(DisplayName = "[CustomerRepository]Update")]
        public void Customer_Repository_Update()
        {
            //var repo = new RepositoryEF<Customer>(_context);
            var customer = unit.Customers.GetById(10);
            Assert.True(customer != null);
            customer.FirstName = $"Today {DateTime.Now.ToShortDateString()}";
            Assert.True(unit.Customers.Update(customer));
        }


        [Fact(DisplayName = "[CustomerRepository]Get By Id")]
        public void Customer_Repository_Get_By_Id()
        {
            //var repo = new RepositoryEF<Customer>(_context);
            var customer = unit.Customers.GetById(10);
            Assert.True(customer != null);
        }



        [Fact(DisplayName = "[CustomerRepository]Search By Names")]
        public void Customer_Repository_Search_By_Name()
        {

            var customer = unit.Customers.SearchByName("Maria", "Anders");
            Assert.True(customer != null);

        }



    }
}
