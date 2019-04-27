using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rent.Data.Abstracts;
using Rent.Model.Concretes;

namespace Rent.Data.Concretes
{
    public class RentRepository : IRepository<RentModel>
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(RentModel entity)
        {
            throw new NotImplementedException();
        }

        public IList<RentModel> SelectAll()
        {
            throw new NotImplementedException();
        }

        public RentModel SelectedByNumber(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(RentModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
