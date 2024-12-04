using Appointments_Scheduler.Database_Table_Classes;
using Appointments_Scheduler.Forms.Customer_Forms;
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

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            int appointmentID = Convert.ToInt32(txtBox_AppointmentID.Text);
            
            // Asks the user to verify they want to permanently delete this appointment
            DialogResult result = MessageBox.Show(@"Are you sure you want to delete this appointment from the database? This action cannot be undone.",
                "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Cancel)
            {
                return;
            }

            // Deletes the appointment from the Database
            Appointment.DeleteAppointmentFromDatabase(appointmentID);

            // Deletes the appointment entry from the Binding List'
            foreach (Appointment appointment in Appointment_Records.Instance.AllAppointments.ToList())
            {
                if (appointment.AppointmentID == appointmentID)
                {
                    Appointment_Records.Instance.AllAppointments.Remove(appointment);
                }
            }

            // Refreshes the Data Grid view's data
            Appointment_Records.Instance.DgvAppointments.Refresh();

            // Ensures the form closes after adding the customer data
            this.Close();
        }
    }
}
