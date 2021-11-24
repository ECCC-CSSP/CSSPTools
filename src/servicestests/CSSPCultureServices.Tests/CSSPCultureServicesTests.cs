namespace CSSPCultureServices.Tests;

public partial class CultureServicesTests
{
    [Theory]
    [InlineData("en-CA")]
    [InlineData("fr-CA")]
    public async Task SetCulture_Good_Test(string culture)
    {
        Assert.True(await CSSPCultureServiceSetup(culture));


        CSSPCultureService.SetCulture(culture);

        Assert.Equal(new CultureInfo(culture), CSSPCultureDesktopRes.Culture);
        Assert.Equal(new CultureInfo(culture), CSSPCultureEnumsRes.Culture);
        Assert.Equal(new CultureInfo(culture), CSSPCultureModelsRes.Culture);
        Assert.Equal(new CultureInfo(culture), CSSPCulturePolSourcesRes.Culture);
        Assert.Equal(new CultureInfo(culture), CSSPCultureServicesRes.Culture);
    }
    [Theory]
    [InlineData("en-US")]
    [InlineData("fr-FR")]
    public async Task SetCulture_Unsuported_Culture_Should_Default_To_en_CA_Good_Test(string culture)
    {
        Assert.True(await CSSPCultureServiceSetup(culture));

        CSSPCultureService.SetCulture(culture);

        Assert.Equal(new CultureInfo(CSSPCultureService.AllowableCultures[0]), CSSPCultureDesktopRes.Culture);
        Assert.Equal(new CultureInfo(CSSPCultureService.AllowableCultures[0]), CSSPCultureEnumsRes.Culture);
        Assert.Equal(new CultureInfo(CSSPCultureService.AllowableCultures[0]), CSSPCultureModelsRes.Culture);
        Assert.Equal(new CultureInfo(CSSPCultureService.AllowableCultures[0]), CSSPCulturePolSourcesRes.Culture);
        Assert.Equal(new CultureInfo(CSSPCultureService.AllowableCultures[0]), CSSPCultureServicesRes.Culture);
    }
}

