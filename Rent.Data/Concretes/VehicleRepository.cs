using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rent.Data.Abstracts;
using Rent.Model.Concretes;

namespace Rent.Data.Concretes
{
    class VehicleRepository : IRepository<Vehicle>
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Vehicle entity)
        {
            throw new NotImplementedException();
        }

        public IList<Vehicle> SelectAll()
        {
            throw new NotImplementedException();
        }

        public Vehicle SelectedByNumber(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Vehicle entity)
        {
            throw new NotImplementedException();
        }
    }
}
