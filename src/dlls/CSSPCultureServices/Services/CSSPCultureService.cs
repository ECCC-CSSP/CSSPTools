using CSSPCultureServices.Resources;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace CSSPCultureServices.Services
{
    public partial interface ICSSPCultureService
    {
        List<string> AllowableCultures { get; }
        void SetCulture(string culture);
    }
    public partial class CSSPCultureService : ICSSPCultureService
    {
        public List<string> AllowableCultures { get; }
        public CSSPCultureService()
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

            CSSPCultureDesktopRes.Culture = new CultureInfo(culture);
            CSSPCultureEnumsRes.Culture = new CultureInfo(culture);
            CSSPCultureModelsRes.Culture = new CultureInfo(culture);
            CSSPCultureServicesRes.Culture = new CultureInfo(culture);
            CSSPCulturePolSourcesRes.Culture = new CultureInfo(culture);
        }
    }
}
