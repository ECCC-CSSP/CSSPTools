using CSSPEnums;
using CSSPDBModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Xunit;
using System.Collections.Generic;

namespace CreateGzFileServices.Tests
{
    public partial class CreateGzFileServiceTests
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
        public async Task CreateGzFileService_CreateGzFile_WebNNNNNNNNN_Unauthorized__Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

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
                WebTypeEnum.WebAllTVItemLanguages1980_2020,
                WebTypeEnum.WebAllTVItemLanguages2021_2060,
                WebTypeEnum.WebAllTVItems1980_2020,
                WebTypeEnum.WebAllTVItems2021_2060,
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
                int TVItemID = 1; // not important for this test

                // Create gz
                var actionRes = await CreateGzFileService.CreateGzFile(webType, TVItemID);
                Assert.Equal(401, ((UnauthorizedObjectResult)actionRes.Result).StatusCode);
            }
        }
        #endregion Tests 

        #region Functions private
        #endregion Functions private
    }
}
