using CSSPEnums;
using CSSPDBModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Xunit;
using System.Collections.Generic;

namespace CreateGzFileLocalServices.Tests
{
    public partial class CreateGzFileLocalServiceTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        // see Helpers.cs
        #endregion Constructors

        #region Tests 
        [Theory(Skip = "not yet implemented")]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileService_CreateWebNNNNNNNNN_Unauthorized__Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo.LoggedInContact = null;

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
                WebTypeEnum.WebAllTels,
                WebTypeEnum.WebAllTideLocations,
                WebTypeEnum.WebAllTVItemLanguages,
                WebTypeEnum.WebAllTVItems,
                WebTypeEnum.WebArea,
                WebTypeEnum.WebClimateDataValue,
                WebTypeEnum.WebClimateSites,
                WebTypeEnum.WebCountry,
                WebTypeEnum.WebDrogueRuns,
                WebTypeEnum.WebHydrometricDataValue,
                WebTypeEnum.WebHydrometricSites,
                WebTypeEnum.WebInfrastructures,
                WebTypeEnum.WebLabSheets,
                WebTypeEnum.WebMikeScenario,
                WebTypeEnum.WebMikeScenarios,
                WebTypeEnum.WebMunicipalities,
                WebTypeEnum.WebMunicipality,
                WebTypeEnum.WebMWQMRuns,
                //WebTypeEnum.WebMWQMSamples,
                WebTypeEnum.WebMWQMSites,
                WebTypeEnum.WebPolSourceSites,
                WebTypeEnum.WebProvince,
                WebTypeEnum.WebRoot,
                WebTypeEnum.WebSamplingPlan,
                WebTypeEnum.WebSector,
                WebTypeEnum.WebSubsector,
                WebTypeEnum.WebTideDataValue,
                WebTypeEnum.WebTideSites,
            };

            foreach (WebTypeEnum webTypeToTry in webTypeList)
            {
                WebTypeEnum webType = webTypeToTry;
                int TVItemID = 1; // not important for this test
               
                var actionRes = await CreateGzFileLocalService.CreateGzFileLocal(webType, TVItemID);
                Assert.Equal(401, ((UnauthorizedResult)actionRes.Result).StatusCode);
            }
        }
        #endregion Tests 

        #region Functions private
        #endregion Functions private
    }
}
