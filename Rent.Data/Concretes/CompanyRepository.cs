using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rent.Data.Abstracts;
using Rent.Model.Concretes;

namespace Rent.Data.Concretes
{
    public class CompanyRepository : IRepository<Company>
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Company entity)
        {
            throw new NotImplementedException();
        }

        public IList<Company> SelectAll()
        {
            throw new NotImplementedException();
        }

        public Company SelectedByNumber(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Company entity)
        {
            throw new NotImplementedException();
        }
    }
}
