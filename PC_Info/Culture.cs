using System.Globalization;
using System.Diagnostics;

namespace Appointments_Scheduler
{
    public class Culture
    {
        public CultureInfo CurrentCulture { get; private set; } = CultureInfo.CurrentCulture;

        public void SetCulture(CultureInfo culture)
        {
            CurrentCulture = culture;
        }

        public string GetCultureName(CultureInfo cultureInfo)
        {
            return CurrentCulture.Name;
        }

        public void PrintCurrentCulture()
        {
            Debug.WriteLine($"Current Culture: {CurrentCulture.Name}");
        }
    }
}
