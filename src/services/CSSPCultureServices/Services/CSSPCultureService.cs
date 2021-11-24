namespace CSSPCultureServices.Services;

public partial class CSSPCultureService : ICSSPCultureService
{
    public List<string> AllowableCultures { get; }
    public int LangID { get; set; }
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

        if (culture == "fr-CA")
        {
            LangID = 1;
        }
        else
        {
            LangID = 0;
        }

        CSSPCultureDesktopRes.Culture = new CultureInfo(culture);
        CSSPCultureEnumsRes.Culture = new CultureInfo(culture);
        CSSPCultureModelsRes.Culture = new CultureInfo(culture);
        CSSPCulturePolSourcesRes.Culture = new CultureInfo(culture);
        CSSPCultureServicesRes.Culture = new CultureInfo(culture);
    }
}

