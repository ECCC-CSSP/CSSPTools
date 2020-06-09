using CultureServices.Resources;
using System.Globalization;
using System.Threading.Tasks;

namespace CultureServices.Services
{
    public partial class CultureService : ICultureService
    {
        public CultureService()
        {
            SetCulture("en-CA");
        }

        public void SetCulture(string culture)
        {
            if (culture != "fr-CA")
            {
                culture = "en-CA";
            }

            CultureEnumsRes.Culture = new CultureInfo(culture);
            CultureModelsRes.Culture = new CultureInfo(culture);
            CultureServicesRes.Culture = new CultureInfo(culture);
            CulturePolSourcesRes.Culture = new CultureInfo(culture);
        }
    }
}
