namespace CSSPCultureServices.Services;

public partial interface ICSSPCultureService
{
    List<string> AllowableCultures { get; }
    int LangID { get; set; }
    void SetCulture(string culture);
}
