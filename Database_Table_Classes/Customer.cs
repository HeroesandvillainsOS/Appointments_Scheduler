using Appointments_Scheduler.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments_Scheduler.Database_Table_Classes
{
    internal class Customer
    {
        public int CustomerID { get; set; } // Primary Key
        public string CustomerName { get; set; }
        public int AddressID { get; set; } // Foreign Key
        public int Active { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdate { get; set; }
        public string LastUpdateBy { get; set; }

        public Customer(int customerID, string customerName, int addressID, int active, DateTime createDate, 
            string createdBy, DateTime lastUpdate, string lastUpdateBy)
        {
            CustomerID = customerID;
            CustomerName = customerName;
            AddressID = addressID;
            Active = active;
            CreateDate = createDate;
            CreatedBy = createdBy;
            LastUpdate = lastUpdate;
            LastUpdateBy = lastUpdateBy;
        }
    }
}
