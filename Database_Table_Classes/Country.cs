using Appointments_Scheduler.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Appointments_Scheduler.Database_Table_Classes
{
    internal class Country
    {
        public static int GetCountryID(string country, DateTime createDate, string createdBy, DateTime lastUpdate, 
            string lastUpdateBy)
        {
            int countryID = 0;

            string getCountryQuery = @"SELECT countryID FROM country
                                     WHERE country = @country
                                     AND createDate = @createDate
                                     AND createdBy = @createdBy
                                     AND lastUpdate = @lastUpdate
                                     AND lastUpdateBY = @lastUpdateBy";

            using (var command = new MySqlCommand(getCountryQuery, DBConnection.connection))
            {
                command.Parameters.AddWithValue("@country", country);
                command.Parameters.AddWithValue("@createDate", createDate);
                command.Parameters.AddWithValue("@createdBy", createdBy);
                command.Parameters.AddWithValue("@lastUpdate", lastUpdate);
                command.Parameters.AddWithValue("@lastUpdateBy", lastUpdateBy);

                object result = command.ExecuteScalar();

                if (result != null)
                {
                    countryID = Convert.ToInt32(result);
                }
            }
            
            if (countryID == 0)
            {
                string insertCountryQuery = @"INSERT INTO country(country, createDate, createdBy, lastUpdate, lastUpdateBy)
                                            VALUES(@country, @createDate, @createdBy, @lastUpdate, @lastUpdateBy)
                                            SELECT LAST_INSERT_ID();";

                using (var command = new MySqlCommand(insertCountryQuery, DBConnection.connection))
                {
                    command.Parameters.AddWithValue("@country", country);
                    command.Parameters.AddWithValue("@createDate", createDate);
                    command.Parameters.AddWithValue("@createdBy", createdBy);
                    command.Parameters.AddWithValue("@lastUpdate", lastUpdate);
                    command.Parameters.AddWithValue("@lastUpdateBy", lastUpdateBy);

                    countryID = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            return countryID;
        }
    }
}
