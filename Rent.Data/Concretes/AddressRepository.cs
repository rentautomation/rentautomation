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
    public class AddressRepository : IRepository<Address>
    {
        public bool Delete(int addressnumber)
        {
            try
            {
                 CommonRepository.Delete(DataTypes.addresstable, DataTypeNumbers.addressnumber, addressnumber);
            }
            catch (Exception ex)
            {
                throw new Exception("CompanyRepository::Delete:Error occured.", ex);
            }
            return true;
        }

        public bool Insert(Address entity)
        {
            try
            {
                var query = new StringBuilder();
                query.Append("INSERT [dbo].[addresstable] ");
                query.Append("([neighborhood], [district], [street], [city], [buildnumber], [isactive]) ");
                query.Append("VALUES ");
                query.Append("(@neighborhood, @district, @street, @city, @buildnumber, @isactive)");

                var commandText = query.ToString();
                query.Clear();

                DBHelper.Open();
                var cmd = DBHelper.GetSqlCommand(commandText);

                cmd.Parameters.AddWithValue("@neighborhood", entity.neighborhood);
                cmd.Parameters.AddWithValue("@district", entity.district);
                cmd.Parameters.AddWithValue("@street", entity.street);
                cmd.Parameters.AddWithValue("@city", entity.city);
                cmd.Parameters.AddWithValue("@buildnumber", entity.buildnumber);
                cmd.Parameters.AddWithValue("@isactive", entity.isactive);

                cmd.ExecuteNonQuery();
                DBHelper.Close();

            }
            catch (Exception ex)
            {
                throw new Exception("AddressRepository::Insert:Error occured.", ex);
            }
            return true;
        }

        public IList<Address> SelectAll()
        {
            throw new NotImplementedException();
        }

        public Address SelectedByNumber(int addressnumber)
        {
            Address address = new Address();
            try
            {
                var query = new StringBuilder();
                query.Append("SELECT  ");
                query.Append("[addressnumber], [neighborhood], [district], [street], [city], [buildnumber], [isactive] ");
                query.Append("FROM [dbo].[addresstable] ");
                query.Append("WHERE [addressnumber] = @addressnumber AND [isactive] = 1 ");

                var commandText = query.ToString();
                query.Clear();

                DBHelper.Open();
                var cmd = DBHelper.GetSqlCommand(commandText);
                cmd.Parameters.AddWithValue("@addressnumber", addressnumber);

                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        address.addressnumber = reader.GetInt32(0);
                        address.neighborhood = reader.GetString(1);
                        address.district = reader.GetString(2);
                        address.street = reader.GetString(3);
                        address.city = reader.GetString(4);
                        address.buildnumber = reader.GetInt32(5);
                        address.isactive = reader.GetInt32(6);
                    }
                }


                DBHelper.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("AddressRepository::SelectedByNumber:Error occured.", ex);
            }


            return address;
        }

        public bool Update(Address entity)
        {
            throw new NotImplementedException();
        }
    }
}
