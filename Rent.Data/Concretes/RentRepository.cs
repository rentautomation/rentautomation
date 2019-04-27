using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rent.Data.Abstracts;
using Rent.Model.Concretes;

namespace Rent.Data.Concretes
{
    public class RentRepository : IRepository<Rent>
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Rent entity)
        {
            throw new NotImplementedException();
        }

        public IList<Rent> SelectAll()
        {
            throw new NotImplementedException();
        }

        public Rent SelectedByNumber(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Rent entity)
        {
            throw new NotImplementedException();
        }
    }
}
