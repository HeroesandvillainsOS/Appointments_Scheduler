using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Appointments_Scheduler.Forms.Customer_Records
{
    public partial class Edit_Customer : Form
    {
        public Edit_Customer(List<String> customer)
        {
            InitializeComponent();

            // Fills the form with the selected customer's data
            txtBox_CustomerID.Text = customer[0];
            txtBox_CustomerName.Text = customer[1];
            txtBox_AddressID.Text = customer[2];
            if (Convert.ToInt32(customer[3]) == 0)
                radioBtn_Active.Checked = false;
            else
                radioBtn_Active.Checked = true;
            txtBox_CreateDate.Text = customer[4];
            txtBox_CreatedBy.Text = customer[5];
            txtBox_LastUpdate.Text = customer[6];
            txtBox_LastUpdateBy.Text = customer[7];

            // Deselects the customerName text box which is selected by default
            txtBox_CustomerName.Select(0, 0);
        }
    }
}
