using Appointments_Scheduler.Database_Table_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Appointments_Scheduler.Appointment_Forms
{
    public partial class Add_Appointment : Form
    {
        public BindingList<Customer> AllCustomers { get; private set; }

        public BindingList<User> AllUsers { get; private set; }

        public Add_Appointment()
        {
            InitializeComponent();
            AllCustomers = Customer.GetAllCustomers();
            AllUsers = User.GetAllUsers();
        }

        // Ensures only current customers in the database appear in the Customer Name dropdown
        private void cmboBox_CustomerName_DropDown(object sender, EventArgs e)
        {
            cmboBox_CustomerName.DataSource = null;
            List<String> allCustomerNames = Customer.GetAllCustomerNames(AllCustomers);
            cmboBox_CustomerName.DataSource = allCustomerNames;
        }

        // Ensures only current users in the database appear in the User Name dropdown
        private void cmboBox_UserName_DropDown(object sender, EventArgs e)
        {
            cmboBox_UserName.DataSource = null;
            List<String> allUserNames = User.GetAllUserNames(AllUsers);
            cmboBox_UserName.DataSource = allUserNames;
        }
    }
}
