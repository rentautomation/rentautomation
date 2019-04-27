using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rent.Data.Abstracts;
using Rent.Model.Concretes;
using System.Data.Common;
using System.Data.SqlClient;
using Rent.Common.Concretes;

namespace Rent.Data.Concretes
{
    public class CustomerRepository : IRepository<Customer>
    {

        public CustomerRepository()
        { 
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Customer entity)
        {

            try
            {
                var query = new StringBuilder();
                query.Append("INSERT [dbo].[membertable] ");
                query.Append("( [name], [lastname], [username], [password], [birthdate], [age] ) ");
                query.Append("VALUES ");
                query.Append(
                    "( @name, @lastname, @username, @password, @birthdate, @age ) ");
                

                var commandText = query.ToString();
                query.Clear();

                DBHelper.Open();
                var cmd = DBHelper.GetSqlCommand(commandText);

                cmd.Parameters.Add("@name", entity.name);
                cmd.Parameters.Add("@lastname", entity.lastname);
                cmd.Parameters.Add("@username", entity.username);
                cmd.Parameters.Add("@password", entity.password);
                cmd.Parameters.Add("@birthdate", entity.birthdate);
                cmd.Parameters.Add("@age", entity.age);
                cmd.ExecuteNonQuery();

                DBHelper.Close();

            }
            catch(Exception ex)
            {
                throw new Exception("CustomersRepository::Insert:Error occured.", ex);
            }
            return true;              
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
