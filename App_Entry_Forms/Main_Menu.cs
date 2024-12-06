using Appointments_Scheduler.Database_Table_Classes;
using System;
using System.Windows.Forms;

namespace Appointments_Scheduler.Forms
{
    public partial class Main_Menu : Form
    {
        public Main_Menu(string userName)
        {
            InitializeComponent();

            // Translates the Main Menu into Spanish if the Spanish culture is detected 
            if (Culture.CultureName == "es-ES")
            {
                btn_CustomerRecords.Text = "Registros de Clientes";
                btn_Appointments.Text = "Citas";
                btn_Reports.Text = "Informes";
                btn_Exit.Text = "Salida";
            }
            else
            {
                btn_CustomerRecords.Text = "Customer Records";
                btn_Appointments.Text = "Appointments";
                btn_Reports.Text = "Reports";
                btn_Exit.Text = "Exit";
            }

            // Sends a message to the logged in user if they have an appointment within 15 minutes of logging in
            bool hasAppointmentWithin15Minutes = Appointment.UserHasAppointmentWithin15Minutes(userName, DateTime.Now);

            if (hasAppointmentWithin15Minutes)
            {
                MessageBox.Show("Reminder that you have an appointment within 15 minutes.", "Appointment Reminder",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Ensures the program closes when the X button is pressed
        private void Main_Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        // Handles logic for exiting the program when the Exit button is pressed
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            DialogResult result;

            if (Culture.CultureName == "es-ES")
            {
                result = MessageBox.Show("¿Estás seguro de que quieres cerrar el programa?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                result = MessageBox.Show("Are you sure you want to exit the application?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }

            if (result == DialogResult.Cancel)
            {
                return;
            }
            else
            {
                Application.Exit();
            }
        }

        // Opens the Customer Records form when the respective button is clicked
        private void btn_CustomerRecords_Click(object sender, EventArgs e)
        {
            var customerRecords = new Customer_Forms.Customer_Records();
            customerRecords.Show();
        }

        // Opens the Appointment Records form when the respective button is clicked
        private void btn_Appointments_Click(object sender, EventArgs e)
        {
            var appointmentRecords = new Appointment_Forms.Appointment_Records();
            appointmentRecords.Show();
        }
    }
}

