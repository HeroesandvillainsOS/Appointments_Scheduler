using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace Appointments_Scheduler
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

            // Creates a new instance of the Culture class
            Culture myCulture = new Culture();

            // Stores the system's current culture info
            CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
            CultureInfo currentUICulture = Thread.CurrentThread.CurrentUICulture;

            try
            {
                // Sets the system's current culture to Spanish
                CultureInfo spanishCulture = new CultureInfo("es-ES");
                myCulture.SetCulture(spanishCulture, spanishCulture);
                myCulture.PrintCurrentCulture();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Sets the system's current culture back to the original culture (English)
                //myCulture.SetCulture(currentCulture, currentUICulture); // Comment out to keep Culture Spanish
                //myCulture.PrintCurrentCulture();
            }

            // Changes the login page language to Spanish if a Spanish culture is detected
            if (myCulture.GetCultureName() == "es-ES")
            {
                lbl_Location.Text = "Ubicación - España";
                lbl_Username.Text = "Nombre de usuario:";
                lbl_Password.Text = "Contraseña:";
                btn_Submit.Text = "Enviar";
            }
            // Ensures the default login page language is English if any culture other than Spanish is detected
            else
            {
                lbl_Username.Text = "Username:";
                lbl_Password.Text = "Password:";
                btn_Submit.Text = "Submit";
            }
        }

        private void btn_Submit_MouseEnter(object sender, EventArgs e)
        {
            // Sets the cursor to the Hand icon when hovering over the Submit button 
            Cursor = Cursors.Hand;
        }

        private void btn_Submit_MouseLeave(object sender, EventArgs e)
        {
            // Sets the cursor back to the default icon when exiting the Submit button area
            Cursor = Cursors.Default;
        }

        private void lbl_Password_Click(object sender, EventArgs e)
        {

        }
    }
}
