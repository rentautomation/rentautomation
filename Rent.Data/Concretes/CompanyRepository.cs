using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rent.Common.Concretes;
using Rent.Data.Abstracts;
using Rent.Model.Concretes;

namespace Rent.Data.Concretes
{
    public class CompanyRepository : IRepository<Company>
    {
        public bool Delete(int companynumber)
        {
            try
            {
                var query = new StringBuilder();
                query.Append("UPDATE [dbo].[companytable] ");
                query.Append("SET [isactive] = 0 ");
                query.Append("WHERE [companynumber] = @companynumber");

                var commandText = query.ToString();
                query.Clear();

                DBHelper.Open();
                var cmd = DBHelper.GetSqlCommand(commandText);

                cmd.Parameters.Add("@companynumber", companynumber);
                cmd.ExecuteNonQuery();

                DBHelper.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("CompanyRepository::Delete:Error occured.", ex);
            }
            return true;
        }

        public bool Insert(Company entity)
        {
            try
            {
                var query = new StringBuilder();
                query.Append("INSERT [dbo].[companytable] ");
                query.Append("([companyname], [city], [addressnumber], [vehiclecount], [rate]) ");
                query.Append("VALUES ");
                query.Append("(@companyname, @city, @addressnumber, @vehiclecount, @rate)");

                var commandText = query.ToString();
                query.Clear();

                DBHelper.Open();
                var cmd = DBHelper.GetSqlCommand(commandText);

                cmd.Parameters.Add("@companyname", entity.companyname);
                cmd.Parameters.Add("@city", entity.city);
                cmd.Parameters.Add("@addressnumber", entity.addressnumber);
                cmd.Parameters.Add("@vehiclecount", entity.vehiclecount);
                cmd.Parameters.Add("@rate", entity.rate);

                cmd.ExecuteNonQuery();
                DBHelper.Close();

            }
            catch(Exception ex)
            {
                throw new Exception("CompanyRepository::Insert:Error occured.", ex);
            }
            return true;
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
