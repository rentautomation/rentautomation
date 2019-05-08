using Rent.Common.Concretes;
using Rent.Data.Abstracts;
using Rent.Data.Data;
using Rent.Model.Abstracts;
using Rent.Model.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Data.Concretes
{
    public class MemberRepository : IRepository<Member>
    {
        public bool Delete(int membernumber)
        {
            try
            {
                CommonRepository.Delete(DataTypes.membertable, DataTypeNumbers.membernumber, membernumber);
            }
            catch (Exception ex)
            {
                throw new Exception("MemberRepository::Delete:Error occured.", ex);
            }

            return true;
        }

        public bool Insert(Member entity)
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

                cmd.Parameters.AddWithValue("@name", entity.name);
                cmd.Parameters.AddWithValue("@lastname", entity.lastname);
                cmd.Parameters.AddWithValue("@username", entity.username);
                cmd.Parameters.AddWithValue("@password", entity.password);
                cmd.Parameters.AddWithValue("@birthdate", entity.birthdate);
                cmd.Parameters.AddWithValue("@age", entity.age);
                cmd.ExecuteNonQuery();

                DBHelper.Close();

            }
            catch (Exception ex)
            {
                throw new Exception("MemberRepository::Insert:Error occured.", ex);
            }
            return true;
        }

        public IList<Member> SelectAll()
        {
            throw new NotImplementedException();
        }

        public Member SelectedByUsername(string username)
        {
            Member member = null;
            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append("[membernumber], [name], [lastname], [username], [birthdate], [age], [isactive] ");
                query.Append("FROM [dbo].[membertable] ");
                query.Append("WHERE username = @username AND isactive = 1 ");

                var commandText = query.ToString();
                query.Clear();

                DBHelper.Open();
                var cmd = DBHelper.GetSqlCommand(commandText);
                cmd.Parameters.AddWithValue("@username", username);

                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        member = new Customer();
                        member.membernumber = reader.GetInt32(0);
                        member.username = reader.GetString(1);
                        member.name = reader.GetString(2);
                        member.lastname = reader.GetString(3);
                        member.birthdate = reader.GetDateTime(4);
                        member.age = reader.GetInt32(5);
                        member.isactive = reader.GetInt32(6);
                        member.password = ""; 
                    }
                }


                DBHelper.Close();

            }catch (Exception ex)
            {
                throw new Exception("MemberRepository::SelectedByUser:Error occured.", ex);
            }


            return member;
        }

        //TODO
        public Member SelectedByNumber(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Member entity)
        {
            throw new NotImplementedException();
        }
    }
}
