using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rent.Common.Concretes;
using Rent.Data.Abstracts;
using Rent.Data.Data;
using Rent.Model.Concretes;

namespace Rent.Data.Concretes
{
    public class VehicleRepository : IRepository<Vehicle>
    {
        public bool Delete(int vehiclenumber)
        {
            try
            {
                CommonRepository.Delete(DataTypes.vehicletable, DataTypeNumbers.vehiclenumber, vehiclenumber);
            }
            catch (Exception ex)
            {
                throw new Exception("VehicleRepository::Delete:Error occured.", ex);
            }
            return true;
        }

        public bool Insert(Vehicle entity)
        {
            try
            {
                var query = new StringBuilder();
                query.Append("INSERT [dbo].[vehicletable] ");
                query.Append("( [name], [model], [licenseage], [minimumagelimit]," +
                    " [dailykmlimit], [currentkm], [airbag], [trunkvolume], [seatcount]," +
                    " [dailyrentprice], [companynumber], [isactive], [istaken]) ");
                query.Append("VALUES ");
                query.Append(
                    "( @name, @model, @licenseage, @minimumagelimit," +
                    " @dailykmlimit, @currentkm, @airbag, @trunkvolume, @seatcount" +
                    " @dailyrentprice, @companynumber, @isactive, @istaken) ");


                var commandText = query.ToString();
                query.Clear();

                DBHelper.Open();
                var cmd = DBHelper.GetSqlCommand(commandText);

                cmd.Parameters.AddWithValue("@name", entity.name);
                cmd.Parameters.AddWithValue("@model", entity.model);
                cmd.Parameters.AddWithValue("@licenseage", entity.licenseage);
                cmd.Parameters.AddWithValue("@minimumagelimit", entity.minimumagelimit);
                cmd.Parameters.AddWithValue("@dailykmlimit", entity.dailykmlimit);
                cmd.Parameters.AddWithValue("@currentkm", entity.currentkm);
                cmd.Parameters.AddWithValue("@airbag", entity.airbag);
                cmd.Parameters.AddWithValue("@trunkvolume", entity.trunkvolume);
                cmd.Parameters.AddWithValue("@seatcount", entity.seatcount);
                cmd.Parameters.AddWithValue("@dailyrentprice", entity.dailyrentprice);
                cmd.Parameters.AddWithValue("@companynumber", entity.companynumber);
                cmd.Parameters.AddWithValue("@isactive", entity.isactive);
                cmd.Parameters.AddWithValue("@istaken", entity.istaken);

                cmd.ExecuteNonQuery();

                DBHelper.Close();

            }
            catch (Exception ex)
            {
                throw new Exception("VehicleRepository::Insert:Error occured.", ex);
            }
            return true;
        }

        public IList<Vehicle> SelectAll()
        {
            IList<Vehicle> vehicles = new List<Vehicle>();
            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append("[vehiclenumber], [name], [model], [licenseage], [minimumagelimit]," +
                    " [dailykmlimit], [currentkm], [airbag], [trunkvolume], [seatcount]," +
                    " [dailyrentprice], [companynumber], [isactive], [istaken] ");
                query.Append("FROM [dbo].[vehicletable] ");
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
                        var vehicle = new Vehicle();

                        vehicle.vehiclenumber = reader.GetInt32(0);
                        vehicle.name = reader.GetString(1);
                        vehicle.model = reader.GetString(2);
                        vehicle.licenseage = reader.GetInt32(3);
                        vehicle.minimumagelimit = reader.GetInt32(4);
                        vehicle.dailykmlimit = reader.GetInt32(5);
                        vehicle.currentkm = reader.GetInt32(6);
                        vehicle.airbag = reader.GetInt32(7);
                        vehicle.trunkvolume = reader.GetFloat(8);
                        vehicle.seatcount = reader.GetInt32(9);
                        vehicle.dailyrentprice = reader.GetDecimal(10);
                        vehicle.companynumber = reader.GetInt32(11);
                        vehicle.isactive = reader.GetInt32(12);
                        vehicle.istaken = reader.GetInt32(13);

                        vehicles.Add(vehicle);
                    }
                }


                DBHelper.Close();

            }
            catch (Exception ex)
            {
                throw new Exception("VehicleRepository::SelectAll:Error occured.", ex);
            }
            return vehicles;
        }

        public Vehicle SelectedByNumber(int vehiclenumber)
        {
            Vehicle vehicle = null;
            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append("[vehiclenumber], [name], [model], [licenseage], [minimumagelimit]," +
                    " [dailykmlimit], [currentkm], [airbag], [trunkvolume], [seatcount]," +
                    " [dailyrentprice], [companynumber], [isactive], [istaken] ");
                query.Append("FROM [dbo].[vehicletable] ");
                query.Append("WHERE [isactive] = 1 AND [vehiclenumber] = @vehiclenumber");


                var commandText = query.ToString();
                query.Clear();

                DBHelper.Open();
                var cmd = DBHelper.GetSqlCommand(commandText);
                cmd.Parameters.AddWithValue("@vehiclenumber", vehiclenumber);

                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        vehicle = new Vehicle();
                        vehicle.vehiclenumber = reader.GetInt32(0);
                        vehicle.name = reader.GetString(1);
                        vehicle.model = reader.GetString(2);
                        vehicle.licenseage = reader.GetInt32(3);
                        vehicle.minimumagelimit = reader.GetInt32(4);
                        vehicle.dailykmlimit = reader.GetInt32(5);
                        vehicle.currentkm = reader.GetInt32(6);
                        vehicle.airbag = reader.GetInt32(7);
                        vehicle.trunkvolume = reader.GetFloat(8);
                        vehicle.seatcount = reader.GetInt32(9);
                        vehicle.dailyrentprice = reader.GetDecimal(10);
                        vehicle.companynumber = reader.GetInt32(11);
                        vehicle.isactive = reader.GetInt32(12);
                        vehicle.istaken = reader.GetInt32(13);

                    }
                }


                DBHelper.Close();

            }
            catch (Exception ex)
            {
                throw new Exception("VehicleRepository::SelectAll:Error occured.", ex);
            }
            return vehicle;
        }

        public Vehicle SelectedByCompanyNumber(int companynumber)
        {
            var vehicle = new Vehicle();
            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append("[vehiclenumber], [name], [model], [licenseage], [minimumagelimit]," +
                    " [dailykmlimit], [currentkm], [airbag], [trunkvolume], [seatcount]," +
                    " [dailyrentprice], [companynumber], [isactive], [istaken] ");
                query.Append("FROM [dbo].[vehicletable] ");
                query.Append("WHERE [isactive] = 1 AND [companynumber] = @companynumber");


                var commandText = query.ToString();
                query.Clear();

                DBHelper.Open();
                var cmd = DBHelper.GetSqlCommand(commandText);
                cmd.Parameters.AddWithValue("@companynumber", companynumber);

                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {


                        vehicle.vehiclenumber = reader.GetInt32(0);
                        vehicle.name = reader.GetString(1);
                        vehicle.model = reader.GetString(2);
                        vehicle.licenseage = reader.GetInt32(3);
                        vehicle.minimumagelimit = reader.GetInt32(4);
                        vehicle.dailykmlimit = reader.GetInt32(5);
                        vehicle.currentkm = reader.GetInt32(6);
                        vehicle.airbag = reader.GetInt32(7);
                        vehicle.trunkvolume = reader.GetFloat(8);
                        vehicle.seatcount = reader.GetInt32(9);
                        vehicle.dailyrentprice = reader.GetDecimal(10);
                        vehicle.companynumber = reader.GetInt32(11);
                        vehicle.isactive = reader.GetInt32(12);
                        vehicle.istaken = reader.GetInt32(13);

                    }
                }


                DBHelper.Close();

            }
            catch (Exception ex)
            {
                throw new Exception("VehicleRepository::SelectAll:Error occured.", ex);
            }
            return vehicle;
        }

        public bool VehicleIsTaken(int vehiclenumber)
        {
            bool istaken = false;
            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append("[istaken] ");
                query.Append("FROM [dbo].[vehicletable] ");
                query.Append("WHERE [vehiclenumber] = @vehiclenumber AND [isactive] = 1");

                var commandText = query.ToString();
                query.Clear();

                DBHelper.Open();
                var cmd = DBHelper.GetSqlCommand(commandText);
                cmd.Parameters.AddWithValue("@vehiclenumber", vehiclenumber);

                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        istaken = reader.GetInt32(13) == 1 ? true : false;
                    }
                }


                DBHelper.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("VehicleRepository::VehichleIsTaken:Error occured.", ex);
            }

            return istaken;
        }

        public bool Update(Vehicle entity)
        {
            try
            {
                var query = new StringBuilder();
                query.Append("UPDATE [dbo].[vehicletable] ");
                query.Append("SET [name] = @name, [model] =  @model, [licenseage]= @licenseage, [minimumagelimit] = @minimumagelimit," +
                    " [dailykmlimit] = @dailykmlimit, [currentkm] =  @currentkm, [airbag] = @airbag, [trunkvolume] =  @trunkvolume, [seatcount] = @seatcount," +
                    " [dailyrentprice] = @dailyrentprice, [companynumber] = @companynumber, [isactive] =  @isactive, [istaken]= @istaken ");
                query.Append("WHERE [vehiclenumber] = @vehiclenumber ");
                


                var commandText = query.ToString();
                query.Clear();

                DBHelper.Open();
                var cmd = DBHelper.GetSqlCommand(commandText);

                cmd.Parameters.AddWithValue("@name", entity.name);
                cmd.Parameters.AddWithValue("@model", entity.model);
                cmd.Parameters.AddWithValue("@licenseage", entity.licenseage);
                cmd.Parameters.AddWithValue("@minimumagelimit", entity.minimumagelimit);
                cmd.Parameters.AddWithValue("@dailykmlimit", entity.dailykmlimit);
                cmd.Parameters.AddWithValue("@currentkm", entity.currentkm);
                cmd.Parameters.AddWithValue("@airbag", entity.airbag);
                cmd.Parameters.AddWithValue("@trunkvolume", entity.trunkvolume);
                cmd.Parameters.AddWithValue("@seatcount", entity.seatcount);
                cmd.Parameters.AddWithValue("@dailyrentprice", entity.dailyrentprice);
                cmd.Parameters.AddWithValue("@companynumber", entity.companynumber);
                cmd.Parameters.AddWithValue("@isactive", entity.isactive);
                cmd.Parameters.AddWithValue("@istaken", entity.istaken);
                cmd.Parameters.AddWithValue("@vehiclenumber", entity.vehiclenumber);

                cmd.ExecuteNonQuery();

                DBHelper.Close();

            }
            catch (Exception ex)
            {
                throw new Exception("VehicleRepository::Update:Error occured.", ex);
            }
            return true;
        }
    }
}
