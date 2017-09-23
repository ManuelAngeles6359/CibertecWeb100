using Cibertec.Models;
using Cibertec.Repositories;
using Cibertec.Repositories.EntityFramework.Northwind;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace Cibertec.Repositories.EntityFrameworkTests
{
    public class CustomerRepositoryTest
    {


        private readonly DbContext _context;
        private readonly CustomerRepository repo;


        public CustomerRepositoryTest()
        {
            _context = new NorthwindDBContext();
            repo = new CustomerRepository(_context);

        }

        


        [Fact(DisplayName ="[CustomerRepository]Get All")]
        public void Customer_Repository_GetAll()
        {

            //var repo = new RepositoryEF<Customer>(_context);
            var result = repo.GetList();
            Assert.True(result.Count() > 0);
        }



        [Fact(DisplayName = "[CustomerRepository]Insert")]
        public void Customer_Repository_Insert()
        {
            Customer customer = GetNewCustomer();
            //var repo = new RepositoryEF<Customer>(_context);
            var result = repo.Insert(customer);
            Assert.True(result > 0);
        }


        [Fact(DisplayName = "[CustomerRepository]Delete")]
        public void Customer_Repository_Delete()
        {
            var customer = GetNewCustomer();
            //var repo = new RepositoryEF<Customer>(_context);
            var result = repo.Insert(customer);
            Assert.True(repo.Delete(customer));
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
            var customer = repo.GetById(10);
            Assert.True(customer != null);
            customer.FirstName = $"Today {DateTime.Now.ToShortDateString()}";
            Assert.True(repo.Update(customer));
        }


        [Fact(DisplayName = "[CustomerRepository]Get By Id")]
        public void Customer_Repository_Get_By_Id()
        {
            //var repo = new RepositoryEF<Customer>(_context);
            var customer = repo.GetById(10);          
            Assert.True(customer != null);
        }



    }
}
