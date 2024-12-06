using System;
using System.Windows.Forms;

namespace Appointments_Scheduler.Report_Forms
{
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
        }

        // Handles the Appointment Types By Month click event
        private void btn_AppointmentTypesByMonth_Click(object sender, EventArgs e)
        {
            AppointmentTypesByMonth appointmentTypesByMonth = new AppointmentTypesByMonth();
            appointmentTypesByMonth.Show();
        }

        private void btn_UserSchedules_Click(object sender, EventArgs e)
        {
            UserSchedules userSchedules = new UserSchedules();
            userSchedules.Show();
        }

        private void btn_CustomersByCountry_Click(object sender, EventArgs e)
        {
            CustomersByCountry customersByCountry = new CustomersByCountry();
            customersByCountry.Show();  
        }
    }
}
