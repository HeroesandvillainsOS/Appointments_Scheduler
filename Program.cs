using Appointments_Scheduler.Database;
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
        /// The main entry point for the application.
        [STAThread]
        static void Main()
        {         
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DBConnection.StartConnection();
            Application.Run(new Login());
            DBConnection.CloseConnection();
        }
    }
}
