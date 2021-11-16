using CSSPEnums;
using CSSPHelperModels;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace CSSPReadGzFileServices.Tests
{
    public partial class CSSPReadGzFileServiceTests
    {
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadJSON_WebNNNNN_Unauthorized_Error_Test(string culture)
        {
            List<WebTypeEnum> webTypeList = new List<WebTypeEnum>()
            {
                WebTypeEnum.WebAllAddresses,
                WebTypeEnum.WebAllContacts,
                WebTypeEnum.WebAllCountries,
                WebTypeEnum.WebAllEmails,
                WebTypeEnum.WebAllHelpDocs,
                WebTypeEnum.WebAllMunicipalities,
                WebTypeEnum.WebAllMWQMLookupMPNs,
                WebTypeEnum.WebAllPolSourceGroupings,
                WebTypeEnum.WebAllPolSourceSiteEffectTerms,
                WebTypeEnum.WebAllProvinces,
                WebTypeEnum.WebAllReportTypes,
                WebTypeEnum.WebAllSearch,
                WebTypeEnum.WebAllTels,
                WebTypeEnum.WebAllTideLocations,
                WebTypeEnum.WebArea,
                WebTypeEnum.WebClimateSites,
                WebTypeEnum.WebCountry,
                WebTypeEnum.WebDrogueRuns,
                WebTypeEnum.WebHydrometricSites,
                WebTypeEnum.WebLabSheets,
                WebTypeEnum.WebMikeScenarios,
                WebTypeEnum.WebMunicipality,
                WebTypeEnum.WebMWQMRuns,
                WebTypeEnum.WebMWQMSamples1980_2020,
                WebTypeEnum.WebMWQMSamples2021_2060,
                WebTypeEnum.WebMWQMSites,
                WebTypeEnum.WebPolSourceSites,
                WebTypeEnum.WebProvince,
                WebTypeEnum.WebRoot,
                WebTypeEnum.WebSector,
                WebTypeEnum.WebSubsector,
                WebTypeEnum.WebTideSites,
            };

            foreach (WebTypeEnum webTypeToTry in webTypeList)
            {
                Assert.True(await CSSPReadGzFileServiceSetup(culture));

                CSSPLocalLoggedInService.LoggedInContactInfo = null;

                WebTypeEnum webType = webTypeToTry;

                var actionWeb = await CSSPReadGzFileService.ReadJSON<WebAllAddresses /* type not important */>(webType);
                Assert.Equal(401, ((UnauthorizedObjectResult)actionWeb.Result).StatusCode);
                ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionWeb.Result).Value;
                Assert.NotEmpty(errRes.ErrList);
            }
        }
    }
}
