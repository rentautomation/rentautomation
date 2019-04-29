using Rent.Common.Concretes;
using Rent.Data.Abstracts;
using Rent.Data.Data;
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
        public bool Delete(int rezervnumber)
        {
            try
            {
                CommonRepository.Delete(DataTypes.rezervtable, DataTypeNumbers.rezervnumber, rezervnumber);
            }
            catch (Exception ex)
            {
                throw new Exception("RezervRepository::Delete:Error occured.", ex);
            }
            return true;
        }

        public bool Insert(Rezerv entity)
        {
            try
            {
                var query = new StringBuilder();
                query.Append("INSERT [dbo].[rezervtable] ");
                query.Append("([membernumber], [vehiclenumber], [rezervdate],  [isactive]) ");
                query.Append("VALUES ");
                query.Append("(@membernumber, @vehiclenumber, @rezervdate, @isactive)");

                var commandText = query.ToString();
                query.Clear();

                DBHelper.Open();
                var cmd = DBHelper.GetSqlCommand(commandText);

                cmd.Parameters.AddWithValue("@membernumber", entity.membernumber);
                cmd.Parameters.AddWithValue("@vehiclenumber", entity.vehiclenumber);
                cmd.Parameters.AddWithValue("@rezervdate", entity.rezervdate);
                cmd.Parameters.AddWithValue("@isactive", entity.isactive);

                cmd.ExecuteNonQuery();
                DBHelper.Close();

            }
            catch (Exception ex)
            {
                throw new Exception("RezervRepository::Insert:Error occured.", ex);
            }
            return true;
        }

        public IList<Rezerv> SelectAll()
        {
            IList<Rezerv> rezervs = new List<Rezerv>();
            try
            {
                var query = new StringBuilder();
                query.Append("SELECT  ");
                query.Append("[rezervnumber], [membernumber], [vehiclenumber], [rezervdate],  [isactive] ");
                query.Append("FROM [dbo].[rezervtable] ");
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
                        var rezerv = new Rezerv();

                        rezerv.rezervnumber = reader.GetInt32(0);
                        rezerv.membernumber = reader.GetInt32(1);
                        rezerv.vehiclenumber = reader.GetInt32(2);
                        rezerv.rezervdate = reader.GetDateTime(3);
                        rezerv.isactive = reader.GetInt32(4);
                        

                        rezervs.Add(rezerv);
                    }
                }


                DBHelper.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("RezervRepository::SelectAll:Error occured.", ex);
            }
            return rezervs;
        }

        public Rezerv SelectedByNumber(int rezervnumber)
        {
            var rezerv = new Rezerv();
            try
            {
                var query = new StringBuilder();
                query.Append("SELECT  ");
                query.Append("[rezervnumber], [membernumber], [vehiclenumber], [rezervdate],  [isactive] ");
                query.Append("FROM [dbo].[rezervtable] ");
                query.Append("WHERE [isactive] = 1 AND [rezervnumber] = @rezervnumber ");


                var commandText = query.ToString();
                query.Clear();

                DBHelper.Open();
                var cmd = DBHelper.GetSqlCommand(commandText);
                cmd.Parameters.AddWithValue("@rezervnumber", rezervnumber);

                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        

                        rezerv.rezervnumber = reader.GetInt32(0);
                        rezerv.membernumber = reader.GetInt32(1);
                        rezerv.vehiclenumber = reader.GetInt32(2);
                        rezerv.rezervdate = reader.GetDateTime(3);
                        rezerv.isactive = reader.GetInt32(4);

                    }
                }


                DBHelper.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("CompanyRepository::SelectAll:Error occured.", ex);
            }
            return rezerv;
        }

        public Rezerv SelectedByVehicleAndMember(int vehiclenumber, int membernumber)
        {
            var rezerv = new Rezerv();
            try
            {
                var query = new StringBuilder();
                query.Append("SELECT  ");
                query.Append("[rezervnumber], [membernumber], [vehiclenumber], [rezervdate],  [isactive] ");
                query.Append("FROM [dbo].[rezervtable] ");
                query.Append("WHERE [vehiclenumber] = @vehiclenumber AND [membernumber] = @membernumber AND [isactive] = 1 ");

                var commandText = query.ToString();
                query.Clear();

                DBHelper.Open();
                var cmd = DBHelper.GetSqlCommand(commandText);
                cmd.Parameters.AddWithValue("@vehiclenumber", vehiclenumber);
                cmd.Parameters.AddWithValue("@membernumber", membernumber);


                

                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {


                        rezerv.rezervnumber = reader.GetInt32(0);
                        rezerv.membernumber = reader.GetInt32(1);
                        rezerv.vehiclenumber = reader.GetInt32(2);
                        rezerv.rezervdate = reader.GetDateTime(3);
                        rezerv.isactive = reader.GetInt32(4);

                    }
                }


                DBHelper.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("CompanyRepository::SelectAll:Error occured.", ex);
            }
            return rezerv;
        }

        public bool Update(Rezerv entity)
        {
            throw new NotImplementedException();
        }
    }
}
