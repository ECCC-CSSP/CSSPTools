using CSSPAzureLoginServices.Services;
using CSSPSQLiteServices;

namespace CSSPDBLocalServices.Tests;

public partial class CSSPDBLocalServiceTest
{
    private async Task GetdbLocalProviderServicesAsync(string culture)
    {

        AddressLocalService = Provider.GetService<IAddressLocalService>();
        Assert.NotNull(AddressLocalService);

        AppTaskLocalService = Provider.GetService<IAppTaskLocalService>();
        Assert.NotNull(AppTaskLocalService);

        ClassificationLocalService = Provider.GetService<IClassificationLocalService>();
        Assert.NotNull(ClassificationLocalService);

        CountryLocalService = Provider.GetService<ICountryLocalService>();
        Assert.NotNull(CountryLocalService);

        EmailLocalService = Provider.GetService<IEmailLocalService>();
        Assert.NotNull(EmailLocalService);

        HelpDocLocalService = Provider.GetService<IHelpDocLocalService>();
        Assert.NotNull(HelpDocLocalService);

        HelperLocalService = Provider.GetService<IHelperLocalService>();
        Assert.NotNull(HelperLocalService);

        MapInfoLocalService = Provider.GetService<IMapInfoLocalService>();
        Assert.NotNull(MapInfoLocalService);

        MWQMLookupMPNLocalService = Provider.GetService<IMWQMLookupMPNLocalService>();
        Assert.NotNull(MWQMLookupMPNLocalService);

        ProvinceLocalService = Provider.GetService<IProvinceLocalService>();
        Assert.NotNull(ProvinceLocalService);

        RootLocalService = Provider.GetService<IRootLocalService>();
        Assert.NotNull(RootLocalService);

        TelLocalService = Provider.GetService<ITelLocalService>();
        Assert.NotNull(TelLocalService);

        TVItemLocalService = Provider.GetService<ITVItemLocalService>();
        Assert.NotNull(TVItemLocalService);

        await CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync();

        Assert.NotNull(CSSPLocalLoggedInService.LoggedInContactInfo);
        Assert.NotNull(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact);
    }
}

