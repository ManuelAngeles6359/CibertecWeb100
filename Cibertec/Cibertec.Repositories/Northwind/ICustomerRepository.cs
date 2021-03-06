﻿using Cibertec.Models;

namespace Cibertec.Repositories.Northwind
{
    public interface ICustomerRepository: IRepository<Customer>
    {

        Customer SearchByName(string firstName, string lastName);


    }
}
