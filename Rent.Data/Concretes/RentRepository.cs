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
    public class RentRepository : IRepository<RentModel>
    {
        public bool Delete(int rentnumber)
        {
            try
            {
                var query = new StringBuilder();
                query.Append("UPDATE [dbo].[renttable] ");
                query.Append("SET [isactive] = 0 ");
                query.Append("WHERE [rentnumber] = @rentnumber");

                var commandText = query.ToString();
                query.Clear();

                DBHelper.Open();
                var cmd = DBHelper.GetSqlCommand(commandText);

                cmd.Parameters.Add("@rentnumber", rentnumber);
                cmd.ExecuteNonQuery();

                DBHelper.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("RentRepository::Delete:Error occured.", ex);
            }
            return true;
        }

        public bool Insert(RentModel entity)
        {
            try
            {
                var query = new StringBuilder();
                query.Append("INSERT [dbo].[renttable] ");
                query.Append("( [membernumber], [vehiclenumber], [rentdatebegin], [rentdateend], [beginkm], [endkm], [totalprice], [isactive] ) ");
                query.Append("VALUES ");
                query.Append(
                    "( @membernumber, @vehiclenumber, @rentdatebegin, @rentdateend, @beginkm, @endkm, @totalprice, @isactive ) ");


                var commandText = query.ToString();
                query.Clear();

                DBHelper.Open();
                var cmd = DBHelper.GetSqlCommand(commandText);

                cmd.Parameters.Add("@membernumber", entity.membernumber);
                cmd.Parameters.Add("@vehiclenumber", entity.vehiclenumber);
                cmd.Parameters.Add("@rentdatebegin", entity.rentdatebegin);
                cmd.Parameters.Add("@rentdateend", entity.rentdateend);
                cmd.Parameters.Add("@beginkm", entity.beginkm);
                cmd.Parameters.Add("@endkm", entity.endkm);
                cmd.Parameters.Add("@totalprice", entity.totalprice);
                cmd.Parameters.Add("@isactive", entity.isactive);
                cmd.ExecuteNonQuery();

                DBHelper.Close();

            }
            catch (Exception ex)
            {
                throw new Exception("RentRepository::Insert:Error occured.", ex);
            }
            return true;
        }

        public IList<RentModel> SelectAll()
        {
            IList<RentModel> rents = new List<RentModel>();
            try
            {
                var query = new StringBuilder();
                query.Append("SELECT [rentnumber], [membernumber], [vehiclenumber], [rentdatebegin], [rentdateend], [beginkm], [endkm], [totalprice], [isactive] ");
                query.Append("FROM [dbo].[renttable] ");
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
                        var rent = new RentModel();

                        rent.rentnumber = reader.GetInt32(0);
                        rent.membernumber = reader.GetInt32(1);
                        rent.vehiclenumber = reader.GetInt32(2);
                        rent.rentdatebegin = reader.GetDateTime(3);
                        rent.rentdateend = reader.GetDateTime(4);
                        rent.beginkm = reader.GetInt32(5);
                        rent.endkm = reader.GetInt32(6);
                        rent.totalprice = reader.GetDecimal(7);
                        rent.isactive = reader.GetInt32(8);

                        rents.Add(rent);
                    }
                }


                DBHelper.Close();

            }
            catch (Exception ex)
            {
                throw new Exception("RentRepository::SelectAll:Error occured.", ex);
            }
            return rents;
        }

        public IList<RentModel> SelectAllByMemberNumber(int membernumber)
        {
            IList<RentModel> rents = new List<RentModel>();
            try
            {
                var query = new StringBuilder();
                query.Append("SELECT [rentnumber], [membernumber], [vehiclenumber], [rentdatebegin], [rentdateend], [beginkm], [endkm], [totalprice], [isactive] ");
                query.Append("FROM [dbo].[renttable] ");
                query.Append("WHERE [isactive] = 1 AND [membernumber] = @membernumber");


                var commandText = query.ToString();
                query.Clear();

                DBHelper.Open();
                var cmd = DBHelper.GetSqlCommand(commandText);
                cmd.Parameters.Add("@membernumber", membernumber);

                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var rent = new RentModel();

                        rent.rentnumber = reader.GetInt32(0);
                        rent.membernumber = reader.GetInt32(1);
                        rent.vehiclenumber = reader.GetInt32(2);
                        rent.rentdatebegin = reader.GetDateTime(3);
                        rent.rentdateend = reader.GetDateTime(4);
                        rent.beginkm = reader.GetInt32(5);
                        rent.endkm = reader.GetInt32(6);
                        rent.totalprice = reader.GetDecimal(7);
                        rent.isactive = reader.GetInt32(8);

                        rents.Add(rent);
                    }
                }


                DBHelper.Close();

            }
            catch (Exception ex)
            {
                throw new Exception("RentRepository::SelectAllByMembernumber:Error occured.", ex);
            }
            return rents;
        }

        public RentModel SelectedByNumber(int rentnumber)
        {
            RentModel rent = new RentModel();
            try
            {
                var query = new StringBuilder();
                query.Append("SELECT [rentnumber], [membernumber], [vehiclenumber], [rentdatebegin], [rentdateend], [beginkm], [endkm], [totalprice], [isactive] ");
                query.Append("FROM [dbo].[renttable] ");
                query.Append("WHERE [rentnumber] = @rentnumber [isactive] = 1 ");

                var commandText = query.ToString();
                query.Clear();

                DBHelper.Open();
                var cmd = DBHelper.GetSqlCommand(commandText);
                cmd.Parameters.Add("@rentnumber", rentnumber);

                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        rent.rentnumber = reader.GetInt32(0);
                        rent.membernumber = reader.GetInt32(1);
                        rent.vehiclenumber = reader.GetInt32(2);
                        rent.rentdatebegin = reader.GetDateTime(3);
                        rent.rentdateend = reader.GetDateTime(4);
                        rent.beginkm = reader.GetInt32(5);
                        rent.endkm = reader.GetInt32(6);
                        rent.totalprice = reader.GetDecimal(7);
                        rent.isactive = reader.GetInt32(8);
                    }
                }


                DBHelper.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("RentRepository::SelectedByNumber:Error occured.", ex);
            }


            return rent;
        }

        public RentModel SelectedByVehicleNumber(int vehiclenumber)
        {
            RentModel rent = new RentModel();
            try
            {
                var query = new StringBuilder();
                query.Append("SELECT [rentnumber], [membernumber], [vehiclenumber], [rentdatebegin], [rentdateend], [beginkm], [endkm], [totalprice], [isactive] ");
                query.Append("FROM [dbo].[renttable] ");
                query.Append("WHERE [vehiclenumber] = @vehiclenumber [isactive] = 1 ");

                var commandText = query.ToString();
                query.Clear();

                DBHelper.Open();
                var cmd = DBHelper.GetSqlCommand(commandText);
                cmd.Parameters.Add("@vehiclenumber", vehiclenumber);

                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        rent.rentnumber = reader.GetInt32(0);
                        rent.membernumber = reader.GetInt32(1);
                        rent.vehiclenumber = reader.GetInt32(2);
                        rent.rentdatebegin = reader.GetDateTime(3);
                        rent.rentdateend = reader.GetDateTime(4);
                        rent.beginkm = reader.GetInt32(5);
                        rent.endkm = reader.GetInt32(6);
                        rent.totalprice = reader.GetDecimal(7);
                        rent.isactive = reader.GetInt32(8);
                    }
                }


                DBHelper.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("RentRepository::SelectedByVehiclenumber:Error occured.", ex);
            }


            return rent;
        }

        

        public bool Update(RentModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
