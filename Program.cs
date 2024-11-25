﻿using Appointments_Scheduler.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Appointments_Scheduler
{
    internal static class Program
    {
        // Ensures the database connection can be reached from anywhere in the program
        public static MySqlConnection connection { get; private set; }
       
        /// The main entry point for the application.
        [STAThread]
        static void Main()
        {         
            // Stores the connection string data from App.config
            string connectionString = ConfigurationManager.ConnectionStrings["localDb"].ConnectionString;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DBConnection.StartConnection();
            Application.Run(new Login());
            DBConnection.CloseConnection();
        }
    }
}
