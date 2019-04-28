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
using Rent.Model.Abstracts;

namespace Rent.Data.Concretes
{
    public class CustomerRepository : IRepository<Customer>
    {

        public CustomerRepository()
        { 
        }

        public bool Delete(int membernumber)
        {
            try
            {

                MemberRepository repository = new MemberRepository();
                repository.Delete(membernumber);
            }
            catch (Exception ex)
            {
                throw new Exception("CustomersRepository::Delete:Error occured.", ex);
            }
            return true;
        }

        public bool Insert(Customer entity)
        {

            try
            {

                //First Add Member
                MemberRepository repository = new MemberRepository();
                repository.Insert(entity);
                //Get member
                Member member = repository.SelectedByUsername(entity.username);

                //Then add customer
                var query = new StringBuilder();
                query.Append("INSERT [dbo].[customertable] ");
                query.Append("( [membernumber] ) ");
                query.Append("VALUES ");
                query.Append("(@membernumber) ");



                var commandText = query.ToString();
                query.Clear();

                DBHelper.Open();
                var cmd = DBHelper.GetSqlCommand(commandText);

                cmd.Parameters.Add("@membernumber", member.membernumber);
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
            IList<Customer> customers = new List<Customer>();
            try
            {
                var query = new StringBuilder();
                query.Append("SELECT [username], [name], [lastname], [birthdate], [age], [isactive] ");
                query.Append("FROM [dbo].[membertable] ");
                query.Append("INNER JOIN [dbo].[customertable] ON ");
                query.Append("[dbo].[customertable].membernumber = [dbo].[membertable].membernumber ");
                query.Append("WHERE [isactive] = 1");


                var commandText = query.ToString();
                query.Clear();

                DBHelper.Open();
                var cmd = DBHelper.GetSqlCommand(commandText);

                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var customer = new Customer();

                        customer.username = reader.GetString(0);
                        customer.name = reader.GetString(1);
                        customer.lastname = reader.GetString(2);
                        customer.birthdate = reader.GetDateTime(3);
                        customer.age = reader.GetInt32(4);
                        customer.isactive = reader.GetInt32(5);
                        customer.membernumber = 0;
                        customer.password = "";
                        customers.Add(customer);
                    }
                }
                    

                DBHelper.Close();

            }
            catch (Exception ex)
            {
                throw new Exception("CustomersRepository::SelectAll:Error occured.", ex);
            }
            return customers;
        }


        public Customer SelectedByUsername(string username)
        {
            Customer customer = new Customer();
            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append("[dbo].[customertable].[customernumber], [dbo].[membertable].[membernumber], [name], [lastname], [username], [birthdate], [age], [isactive] ");
                query.Append("FROM [dbo].[membertable] ");
                query.Append("INNER JOIN [dbo].[customertable] ON ");
                query.Append("[dbo].[customertable].membernumber = [dbo].[membertable].membernumber ");
                query.Append("WHERE [dbo].[membertable].[username] = @username AND isactive = 1 ");

                var commandText = query.ToString();
                query.Clear();

                DBHelper.Open();
                var cmd = DBHelper.GetSqlCommand(commandText);
                cmd.Parameters.Add("@username", username);

                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        customer.customernumber = reader.GetInt32(0);
                        customer.membernumber = reader.GetInt32(1);
                        customer.username = reader.GetString(2);
                        customer.name = reader.GetString(3);
                        customer.lastname = reader.GetString(4);
                        customer.birthdate = reader.GetDateTime(5);
                        customer.age = reader.GetInt32(6);
                        customer.isactive = reader.GetInt32(7);
                        customer.password = "";
                    }
                }


                DBHelper.Close();

            }
            catch (Exception ex)
            {
                throw new Exception("CustomerRepository::SelectedByUser:Error occured.", ex);
            }


            return customer;
        }

        public Customer SelectedByNumber(int customernumber)
        {
            Customer customer = new Customer();
            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append("[customernumber], [membernumber], [name], [lastname], [username], [birthdate], [age], [isactive] ");
                query.Append("FROM [dbo].[membertable] ");
                query.Append("INSERT JOIN [dbo].[customertable] ON ");
                query.Append("[dbo].[customertable].membernumber = [dbo].[membertable].membernumber ");
                query.Append("WHERE [dbo].[customertable].[customernumber] = @customernumber ");

                var commandText = query.ToString();
                query.Clear();

                DBHelper.Open();
                var cmd = DBHelper.GetSqlCommand(commandText);
                cmd.Parameters.Add("@customernumber", customernumber);

                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        customer.customernumber = reader.GetInt32(0);
                        customer.membernumber = reader.GetInt32(1);
                        customer.username = reader.GetString(2);
                        customer.name = reader.GetString(3);
                        customer.lastname = reader.GetString(4);
                        customer.birthdate = reader.GetDateTime(5);
                        customer.age = reader.GetInt32(6);
                        customer.isactive = reader.GetInt32(7);
                        customer.password = "";
                    }
                }


                DBHelper.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("CustomerRepository::SelectedByUser:Error occured.", ex);
            }


            return customer;
        }

        public bool Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
