using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rent.Data.Abstracts;
using Rent.Model.Concretes;

namespace Rent.Data.Concretes
{
    public class PersonnelRepository : IRepository<Personnel>
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Personnel entity)
        {
            throw new NotImplementedException();
        }

        public IList<Personnel> SelectAll()
        {
            throw new NotImplementedException();
        }

        public Personnel SelectedByNumber(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Personnel entity)
        {
            throw new NotImplementedException();
        }
    }
}
