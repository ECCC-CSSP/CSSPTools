using CSSPEnums;
using CSSPDBModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Xunit;
using CSSPWebModels;
using CSSPCultureServices.Resources;
using System.Collections.Generic;

namespace ReadGzFileServices.Tests
{
    public partial class ReadGzFileServiceTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        // see Helpers.cs
        #endregion Constructors

        #region Tests 
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadJSON_WebNNNNN_Unauthorized_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

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
                WebTypeEnum webType = webTypeToTry;

                var actionWeb = await ReadGzFileService.ReadJSON<WebArea>(webType);
                Assert.Equal(401, ((UnauthorizedObjectResult)actionWeb.Result).StatusCode);
                Assert.Equal(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization), ((UnauthorizedObjectResult)actionWeb.Result).Value);
            }
        }
        #endregion Tests 

        #region Functions private
        #endregion Functions private
    }
}
