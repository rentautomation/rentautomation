﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rent.Data.Abstracts;
using Rent.Model.Concretes;


namespace Rent.Data.Concretes
{
    class CustomerRepository : IRepository<Customer>
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Customer entity)
        {
            throw new NotImplementedException();
        }

        public IList<Customer> SelectAll()
        {
            throw new NotImplementedException();
        }

        public Customer SelectedByNumber(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
