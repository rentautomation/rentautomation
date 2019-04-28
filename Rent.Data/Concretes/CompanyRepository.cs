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
    public class CompanyRepository : IRepository<Company>
    {
        public bool Delete(int companynumber)
        {
            try
            {
                CommonRepository.Delete(DataTypes.companytable, DataTypeNumbers.companynumber, companynumber);
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
                query.Append("([companyname], [city], [addressnumber], [vehiclecount], [rate], [isactive]) ");
                query.Append("VALUES ");
                query.Append("(@companyname, @city, @addressnumber, @vehiclecount, @rate, @isactive)");

                var commandText = query.ToString();
                query.Clear();

                DBHelper.Open();
                var cmd = DBHelper.GetSqlCommand(commandText);

                cmd.Parameters.AddWithValue("@companyname", entity.companyname);
                cmd.Parameters.AddWithValue("@city", entity.city);
                cmd.Parameters.AddWithValue("@addressnumber", entity.addressnumber);
                cmd.Parameters.AddWithValue("@vehiclecount", entity.vehiclecount);
                cmd.Parameters.AddWithValue("@rate", entity.rate);
                cmd.Parameters.AddWithValue("@isactive", entity.isactive);

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
            IList<Company> companies = new List<Company>();
            try
            {
                var query = new StringBuilder();
                query.Append("SELECT  ");
                query.Append("[companynumber], [companyname], [city], [addressnumber], [vehiclecount], [rate] ");
                query.Append("FROM [dbo].[companytable] ");
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
                        var company = new Company();

                        company.companynumber = reader.GetInt32(0);
                        company.companyname = reader.GetString(1);
                        company.city = reader.GetString(2);
                        company.addressnumber = reader.GetInt32(3);
                        company.vehiclecount = reader.GetInt32(4);
                        company.rate = reader.GetInt32(5);

                        companies.Add(company);
                    }
                }


                DBHelper.Close();

            }
            catch (Exception ex)
            {
                throw new Exception("CompanyRepository::SelectAll:Error occured.", ex);
            }
            return companies;
        }

        public Company SelectedByNumber(int companynumber)
        {
            Company company = new Company();
            try
            {
                var query = new StringBuilder();
                query.Append("SELECT  ");
                query.Append("[companynumber], [companyname], [city], [addressnumber], [vehiclecount], [rate], [isactive]");
                query.Append("FROM [dbo].[companytable] ");
                query.Append("WHERE [companynumber] = @companynumber AND [isactive] = 1");

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
                        company.companynumber = reader.GetInt32(0);
                        company.companyname = reader.GetString(1);
                        company.city = reader.GetString(2);
                        company.addressnumber = reader.GetInt32(3);
                        company.vehiclecount = reader.GetInt32(4);
                        company.rate = reader.GetInt32(5);
                        company.isactive = reader.GetInt32(6);
                    }
                }


                DBHelper.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("CompanyRepository::SelectedByNumber:Error occured.", ex);
            }


            return company;
        }

        public bool Update(Company entity)
        {
            throw new NotImplementedException();
        }
    }
}
