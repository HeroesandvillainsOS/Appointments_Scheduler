using Appointments_Scheduler.Database_Table_Classes;
using Appointments_Scheduler.Report_Forms;
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Appointments_Scheduler.Forms
{
    public partial class Main_Menu : Form
    {
        public Main_Menu(string userName)
        {
            InitializeComponent();

            // Translates the Main Menu into Spanish if the Spanish culture is detected 
            if (Login.myCurrentCulture.Name.StartsWith("es-"))
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

            // Logs each successful login to Login_History.txt
            string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
            // Moves up two directories because the program points to bin\debug for some reason
            string folderPath = Path.Combine(projectDirectory, "..", "..", "Text Files");  
            string filePath = Path.Combine(folderPath, "Login_History.txt");
            string loggedInUser = userName;
            DateTime currentTime = DateTime.Now;

            // Writes to the txt file
            using (StreamWriter sw = new StreamWriter(filePath, append: true))
            {
                sw.WriteLine($"User: {loggedInUser} Logged in at {currentTime}");
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

            if (Thread.CurrentThread.CurrentCulture.Name == "es-ES")
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

        // Opens the Reports menu when the respective button is clicked
        private void btn_Reports_Click(object sender, EventArgs e)
        {
            Reports reports = new Reports();
            reports.Show();
        }
    }
}

