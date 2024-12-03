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
    public partial class Delete_Appointment : Form
    {
        public BindingList<Customer> AllCustomers { get; private set; }

        public BindingList<User> AllUsers { get; private set; }

        public Delete_Appointment(List<String> appointmentDetails)
        {
            InitializeComponent();

            AllCustomers = Customer.GetAllCustomers();
            AllUsers = User.GetAllUsers();

            txtBox_AppointmentID.Text = appointmentDetails[0];
            txtBox_CustomerName.Text = Customer.GetCustomerNameFromCustomerID(Convert.ToInt32(appointmentDetails[1]));
            txtBox_UserName.Text = User.GetUserNameFromUserID(Convert.ToInt32(appointmentDetails[2]));
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
        }
    }
}
