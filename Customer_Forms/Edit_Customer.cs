using System.Windows.Forms;


namespace Appointments_Scheduler.Forms.Customer_Records
{
    public partial class Edit_Customer : Form
    {
        public Edit_Customer(string customerID, string customerName, string addressID, int active, string createDate,
            string createdBy, string lastUpdate, string lastUpdateBy)
        {
            InitializeComponent();

            // Fills the form with the selected customer's data
            txtBox_CustomerID.Text = customerID;
            txtBox_CustomerName.Text = customerName;
            txtBox_AddressID.Text = addressID;
            if (active == 0)
                radioBtn_Active.Checked = false;
            else
                radioBtn_Active.Checked = true;
            txtBox_CreateDate.Text = createDate;
            txtBox_CreatedBy.Text = createdBy;
            txtBox_LastUpdate.Text = lastUpdate;
            txtBox_LastUpdateBy.Text = lastUpdateBy;
        }
    }
}
