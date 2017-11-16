﻿using Cibertec.Models;
using Cibertec.Repositories.Northwind;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Cibertec.Repositories.EntityFramework.Northwind
{
    public class CustomerRepository : Repository<Customer>
    {
        public CustomerRepository(DbContext context) : base(context)
        {

        }

        public Customer SearchByName(string firstName, string lastName)
        {

            return _context.Set<Customer>().FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);

        }




    }
}
