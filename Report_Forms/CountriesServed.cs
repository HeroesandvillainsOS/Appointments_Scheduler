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

namespace Appointments_Scheduler.Report_Forms
{
    public partial class CountriesServed : Form
    {
        public static CountriesServed instance { get; private set; }

        public BindingList<String> AllUniqueCountries { get; private set; }

        public CountriesServed()
        {
            InitializeComponent();

            BindingList<String> allCountries = Country.GetAllCountryNamesAsString();
            int totalCountries = 0;

            // Uses a Lambda expression to add each country from the Binding List to the List View
            allCountries.ToList().ForEach(country => listView_CountriesServed.Items.Add(country));

            // Tallies up the total amount of unique countries
            for (int i = 0; i < allCountries.Count; i++)
            {
                totalCountries++;
            }

            // Displays the total amount of unique countries in the Total Countries Text Box
            txtBox_TotalCountries.Text = totalCountries.ToString();

            txtBox_TotalCountries.Select(0, 0);
        }
    }
}
