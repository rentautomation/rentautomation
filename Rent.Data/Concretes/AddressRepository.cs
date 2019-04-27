using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rent.Data.Abstracts;
using Rent.Model.Concretes;

namespace Rent.Data.Concretes
{
    public class AddressRepository : IRepository<Address>
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Address entity)
        {
            throw new NotImplementedException();
        }

        public IList<Address> SelectAll()
        {
            throw new NotImplementedException();
        }

        public Address SelectedByNumber(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Address entity)
        {
            throw new NotImplementedException();
        }
    }
}
