using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace Appointments_Scheduler
{
    internal class Culture
    {
        public CultureInfo CurrentCulture { get; private set; } = Thread.CurrentThread.CurrentCulture;
        public CultureInfo CurrentUICulture { get; private set; } = Thread.CurrentThread.CurrentUICulture;

        public void SetCulture(CultureInfo culture, CultureInfo cultureUI)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = cultureUI;
            CurrentCulture = culture;
            CurrentUICulture = cultureUI;
        }

        public string GetCultureName()
        {
            return Thread.CurrentThread.CurrentCulture.Name;
        }

        public string GetCultureUIName()
        {
            return Thread.CurrentThread.CurrentUICulture.Name;
        }

        public void PrintCurrentCulture()
        {
            Console.WriteLine($"Current Culture: {CurrentCulture.Name}, Current UI Culture: {CurrentUICulture}");
        }
      
    }
}
