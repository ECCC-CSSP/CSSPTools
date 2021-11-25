/*
 * This document is manually edited.
 * 
 * All testing function are generated under documents
 * EnumsTestGenerated.cs and EnumsPolSourceObsInfoEnumTestGenerated.cs
 * 
 */

namespace CSSPEnums.Tests;

public partial class EnumsTest
{
    private IEnums enums { get; set; }
    private ICSSPCultureService CSSPCultureService { get; set; }
    public IServiceProvider Provider { get; set; }
    public IServiceCollection Services { get; set; }

    private async Task<bool> EnumsSetup(string culture)
    {
        Services = new ServiceCollection();
        Services.AddSingleton<IEnums, Enums>();
        Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();

        Provider = Services.BuildServiceProvider();
        Assert.NotNull(Provider);

        CSSPCultureService = Provider.GetService<ICSSPCultureService>();
        Assert.NotNull(CSSPCultureService);

        enums = Provider.GetService<IEnums>();
        Assert.NotNull(enums);

        return await Task.FromResult(true);
    }

}

