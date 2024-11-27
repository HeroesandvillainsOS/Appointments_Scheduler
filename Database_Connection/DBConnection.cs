using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Appointments_Scheduler.Database
{
    internal class DBConnection
    {
        public static MySqlConnection connection { get; set; }

        public static void StartConnection()
        {
            try
            {
                // Stores the connection string data from App.config
                string connectionString = ConfigurationManager.ConnectionStrings["localDb"].ConnectionString;
                // Creates the database connection object
                connection = new MySqlConnection(connectionString);
                // Opens the database connection
                connection.Open();
                //MessageBox.Show("Connection successful!", "Database Test");

            }
            catch (MySqlException ex)
            {
                // Returns a MessageBox error if no database connection can be established
                MessageBox.Show($"An error occurred: {ex.Message}", "Database Error");
                return; // Exit if the database connection fails
            }
        }

        public static void CloseConnection()
        {
            try
            {
                if (connection != null)
                {
                    connection.Close();
                }
                connection = null;
            }
            catch (MySqlException ex)
            {
                // Returns a MessageBox error if no database connection can be found
                MessageBox.Show($"An error occurred: {ex.Message}", "Database Error");
                return; // Exit if a database connection can't be found
            }
        }
    }
}
