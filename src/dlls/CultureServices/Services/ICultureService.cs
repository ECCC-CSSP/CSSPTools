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
}
