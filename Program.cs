using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Appointments_Scheduler
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string connectionString = "server=localhost;user=sqlUser;database=client_schedule;port=3306;password=Passw0rd!";

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MessageBox.Show("Connection successful!", "Database Test");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Database Error");
                return; // Exit if the database connection fails
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }
}
