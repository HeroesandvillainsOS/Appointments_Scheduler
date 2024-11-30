﻿using Appointments_Scheduler.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments_Scheduler.Database_Table_Classes
{
    internal class City
    {
       public static int GetCityID(string city, int countryID, DateTime createDate, string createdBy, 
           DateTime lastUpdate, string lastUpdateBy)
        {
            int cityID = 0;

            string getCityQuery = @"SELECT cityID FROM city
                                     WHERE city = @city
                                     AND countryID = @countryID
                                     AND createDate = @createDate
                                     AND createdBy = @createdBy
                                     AND lastUpdate = @lastUpdate
                                     AND lastUpdateBY = @lastUpdateBy";

            using (var command = new MySqlCommand(getCityQuery, DBConnection.connection))
            {
                command.Parameters.AddWithValue("@city", city);
                command.Parameters.AddWithValue("@countryID", countryID);
                command.Parameters.AddWithValue("@createDate", createDate);
                command.Parameters.AddWithValue("@createdBy", createdBy);
                command.Parameters.AddWithValue("@lastUpdate", lastUpdate);
                command.Parameters.AddWithValue("@lastUpdateBy", lastUpdateBy);

                object result = command.ExecuteScalar();

                if (result != null)
                {
                    cityID = Convert.ToInt32(result);
                }
            }

            if (cityID == 0)
            {
                string insertCountryQuery = @"INSERT INTO city(city, countryID, createDate, createdBy, lastUpdate, lastUpdateBy)
                                            VALUES(@city, @countryID, @createDate, @createdBy, @lastUpdate, @lastUpdateBy)
                                            SELECT LAST_INSERT_ID();";

                using (var command = new MySqlCommand(insertCountryQuery, DBConnection.connection))
                {
                    command.Parameters.AddWithValue("@city", city);
                    command.Parameters.AddWithValue("@countryID", countryID);
                    command.Parameters.AddWithValue("@createDate", createDate);
                    command.Parameters.AddWithValue("@createdBy", createdBy);
                    command.Parameters.AddWithValue("@lastUpdate", lastUpdate);
                    command.Parameters.AddWithValue("@lastUpdateBy", lastUpdateBy);

                    cityID = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            return cityID;
        } 
    }
}