using CultureServices.Resources;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace CultureServices.Services
{
    public partial interface ICultureService
    {
        List<string> AllowableCultures { get; }
        void SetCulture(string culture);
    }
    public partial class CultureService : ICultureService
    {
        public List<string> AllowableCultures { get; }
        public CultureService()
        {
            AllowableCultures = new List<string>() { "en-CA", "fr-CA" };
            SetCulture("en-CA"); 
        }

        public void SetCulture(string culture)
        {
            if (!AllowableCultures.Contains(culture))
            {
                culture = AllowableCultures[0];
            }

            CultureEnumsRes.Culture = new CultureInfo(culture);
            CultureModelsRes.Culture = new CultureInfo(culture);
            CultureServicesRes.Culture = new CultureInfo(culture);
            CulturePolSourcesRes.Culture = new CultureInfo(culture);
        }
    }
}
