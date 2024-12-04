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
    public partial class Edit_Appointment : Form
    {

        public BindingList<Customer> AllCustomers { get; private set; }

        public BindingList<User> AllUsers { get; private set; }

        public Edit_Appointment(List<String> appointmentDetails)
        {
            InitializeComponent();
            AllCustomers = Customer.GetAllCustomers();
            AllUsers = User.GetAllUsers();

            txtBox_AppointmentID.Text = appointmentDetails[0];
            cmboBox_CustomerName.Text = Customer.GetCustomerNameFromCustomerID(Convert.ToInt32(appointmentDetails[1]));
            cmboBox_UserName.Text = User.GetUserNameFromUserID(Convert.ToInt32(appointmentDetails[2]));
            txtBox_Title.Text = appointmentDetails[3];
            txtBox_Description.Text = appointmentDetails[4];
            txtBox_Location.Text = appointmentDetails[5];
            txtBox_Type.Text = appointmentDetails[7];
            txtBox_Url.Text = appointmentDetails[8];
            txtBox_Start.Text = appointmentDetails[9];
            txtBox_End.Text = appointmentDetails[10];
            txtBox_CreateDate.Text = appointmentDetails[11];
            txtBox_CreatedBy.Text = appointmentDetails[12];
            txtBox_LastUpdate.Text = appointmentDetails[13];
            txtBox_LastUpdateBy.Text = appointmentDetails[14];

            // Deselects the Create Date text box which is highlighted by default
            txtBox_CreateDate.Select(0, 0);
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
