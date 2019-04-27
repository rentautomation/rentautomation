using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Rent.Data.Abstracts
{
    interface IRepository<TEntity> 
    {
        bool Insert(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(int id);
        TEntity SelectedByNumber(int id);
        IList<TEntity> SelectAll();
    }
}
