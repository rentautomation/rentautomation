using Rent.Common.Concretes;
using Rent.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Data.Concretes
{
    public class CommonRepository
    {
        public static bool Delete(string dataTypes, string dataTypeNumbers, int number)
        {
            try
            {
                var query = new StringBuilder();
                query.Append(String.Format("UPDATE [dbo].[{0}] ", dataTypes));
                query.Append("SET [isactive] = 0 ");
                query.Append(String.Format("WHERE [{0}] = @number", dataTypeNumbers));

                var commandText = query.ToString();
                query.Clear();

                DBHelper.Open();
                var cmd = DBHelper.GetSqlCommand(commandText);

                cmd.Parameters.AddWithValue("@number", number);
                cmd.ExecuteNonQuery();

                DBHelper.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("CommonRepository::Delete:Error occured.", ex);
            }
            return true;
        }
    }
}
