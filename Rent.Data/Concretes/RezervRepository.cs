using Rent.Data.Abstracts;
using Rent.Model.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Data.Concretes
{
    public class RezervRepository : IRepository<Rezerv>
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Rezerv entity)
        {
            throw new NotImplementedException();
        }

        public IList<Rezerv> SelectAll()
        {
            throw new NotImplementedException();
        }

        public Rezerv SelectedByNumber(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Rezerv entity)
        {
            throw new NotImplementedException();
        }
    }
}
