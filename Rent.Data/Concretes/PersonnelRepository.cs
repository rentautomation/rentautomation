using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rent.Common.Concretes;
using Rent.Data.Abstracts;
using Rent.Model.Abstracts;
using Rent.Model.Concretes;

namespace Rent.Data.Concretes
{
    public class PersonnelRepository : IRepository<Personnel>
    {
        public bool Delete(int personnelnumber)
        {
            try
            {
                Personnel personnel = SelectedByNumber(personnelnumber);

                MemberRepository repository = new MemberRepository();
                repository.Delete(personnel.membernumber);
            }
            catch (Exception ex)
            {
                throw new Exception("CustomersRepository::Delete:Error occured.", ex);
            }
            return true;
        }

        public bool Insert(Personnel entity)
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
                query.Append("INSERT [dbo].[personneltable] ");
                query.Append("( [membernumber], [companynumber] ) ");
                query.Append("VALUES ");
                query.Append("(@membernumber, @companynumber) ");



                var commandText = query.ToString();
                query.Clear();

                DBHelper.Open();
                var cmd = DBHelper.GetSqlCommand(commandText);

                cmd.Parameters.Add("@membernumber", member.membernumber);
                cmd.Parameters.Add("@companynumber", entity.companynumber);
                cmd.ExecuteNonQuery();

                DBHelper.Close();

            }
            catch (Exception ex)
            {
                throw new Exception("PersonnelRepository::Insert:Error occured.", ex);
            }
            return true;
        }

        public IList<Personnel> SelectAll()
        {
            IList<Personnel> personnels = new List<Personnel>();
            try
            {
                var query = new StringBuilder();
                query.Append("SELECT [username], [name], [lastname], [birthdate], [age], [isactive], [companynumber] ");
                query.Append("FROM [dbo].[membertable] ");
                query.Append("INNER JOIN [dbo].[personneltable] ON ");
                query.Append("[personneltable].membernumber = [membertable].membernumber ");
                query.Append("WHERE [isactive] = 1 ");


                var commandText = query.ToString();
                query.Clear();

                DBHelper.Open();
                var cmd = DBHelper.GetSqlCommand(commandText);

                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var personnel = new Personnel();

                        personnel.username = reader.GetString(0);
                        personnel.name = reader.GetString(1);
                        personnel.lastname = reader.GetString(2);
                        personnel.birthdate = reader.GetDateTime(3);
                        personnel.age = reader.GetInt32(4);
                        personnel.isactive = reader.GetInt32(5);
                        personnel.companynumber = reader.GetInt32(6);
                        personnel.membernumber = 0;
                        personnel.password = "";
                        personnels.Add(personnel);
                    }
                }


                DBHelper.Close();

            }
            catch (Exception ex)
            {
                throw new Exception("CustomersRepository::SelectAll:Error occured.", ex);
            }
            return personnels;
        }

        public Personnel SelectedByUsername(string username)
        {
            Personnel personnel = null;
            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append("[personnelnumber], [membernumber], [name], [lastname], [username], [birthdate], [age], [isactive], [companynumber] ");
                query.Append("FROM [dbo].[membertable] ");
                query.Append("INSERT JOIN [dbo].[personneltable] ON ");
                query.Append("[dbo].[personneltable].membernumber = [dbo].[membertable].membernumber ");
                query.Append("WHERE username = @username AND isactive = 1 ");

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
                        personnel = new Personnel();

                        personnel.personnelnumber = reader.GetInt32(0);
                        personnel.membernumber = reader.GetInt32(1);
                        personnel.username = reader.GetString(2);
                        personnel.name = reader.GetString(3);
                        personnel.lastname = reader.GetString(4);
                        personnel.birthdate = reader.GetDateTime(5);
                        personnel.age = reader.GetInt32(6);
                        personnel.isactive = reader.GetInt32(7);
                        personnel.companynumber = reader.GetInt32(8);
                        personnel.password = "";
                    }
                }


                DBHelper.Close();

            }
            catch (Exception ex)
            {
                throw new Exception("PersonnelRepository::SelectedByUser:Error occured.", ex);
            }


            return personnel;
        }

        public Personnel SelectedByNumber(int personnelnumber)
        {
            Personnel personnel = null;
            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append("[personnelnumber], [membernumber], [name], [lastname], [username], [birthdate], [age], [isactive] ");
                query.Append("FROM [dbo].[membertable] ");
                query.Append("INSERT JOIN [dbo].[personneltable] ON ");
                query.Append("[dbo].[personneltable].membernumber = [dbo].[membertable].membernumber ");
                query.Append("WHERE [dbo].[personneltable].[personnelnumber] = @personnelnumber ");

                var commandText = query.ToString();
                query.Clear();

                DBHelper.Open();
                var cmd = DBHelper.GetSqlCommand(commandText);
                cmd.Parameters.Add("@personnelnumber", personnelnumber);

                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        personnel = new Personnel();
                        personnel.personnelnumber = reader.GetInt32(0);
                        personnel.membernumber = reader.GetInt32(1);
                        personnel.username = reader.GetString(2);
                        personnel.name = reader.GetString(3);
                        personnel.lastname = reader.GetString(4);
                        personnel.birthdate = reader.GetDateTime(5);
                        personnel.age = reader.GetInt32(6);
                        personnel.isactive = reader.GetInt32(7);
                        personnel.password = "";
                    }
                }


                DBHelper.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("CustomerRepository::SelectedByUser:Error occured.", ex);
            }


            return personnel;
        }

        public bool Update(Personnel entity)
        {
            throw new NotImplementedException();
        }
    }
}
