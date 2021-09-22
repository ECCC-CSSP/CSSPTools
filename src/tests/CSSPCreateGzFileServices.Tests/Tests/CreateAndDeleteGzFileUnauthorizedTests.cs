using CSSPEnums;
using CSSPDBModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Xunit;
using System.Collections.Generic;
using ManageServices;
using System.Linq;

namespace CreateGzFileServices.Tests
{
    public partial class CreateGzFileServiceTests
    {
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFile_DeleteGzFile_WebNNNNNNNNN_Unauthorized__Test(string culture)
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
                Assert.True(await CSSPCreateGzFileServiceSetup(culture));

                Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

                LoggedInService.LoggedInContactInfo = null;

                WebTypeEnum webType = webTypeToTry;
                int TVItemID = 1; // not important for this test

                CSSPLogService.CSSPAppName = "AppNameTest";
                CSSPLogService.CSSPCommandName = "CommandNameTest";

                WriteTimeSpan(webType);

                // Create gz
                var actionRes = await CreateGzFileService.CreateGzFile(webType, TVItemID);
                Assert.Equal(401, ((UnauthorizedObjectResult)actionRes.Result).StatusCode);

                List<CommandLog> commandLogList = (from c in dbManage.CommandLogs
                                                   where c.AppName == CSSPLogService.CSSPAppName
                                                   && c.CommandName == CSSPLogService.CSSPCommandName
                                                   select c).ToList();

                Assert.True(commandLogList.Count == 1);
                Assert.False(string.IsNullOrWhiteSpace(commandLogList[0].Error));

                Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());

                WriteTimeSpan(webType);
            }

            foreach (WebTypeEnum webTypeToTry in webTypeList)
            {
                Assert.True(await CSSPCreateGzFileServiceSetup(culture));

                Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

                LoggedInService.LoggedInContactInfo = null;

                WebTypeEnum webType = webTypeToTry;
                int TVItemID = 1; // not important for this test

                CSSPLogService.CSSPAppName = "AppNameTest";
                CSSPLogService.CSSPCommandName = "CommandNameTest";

                WriteTimeSpan(webType);

                // Delete gz
                var actionRes = await CreateGzFileService.DeleteGzFile(webType, TVItemID);
                Assert.Equal(401, ((UnauthorizedObjectResult)actionRes.Result).StatusCode);

                List<CommandLog> commandLogList = (from c in dbManage.CommandLogs
                                                   where c.AppName == CSSPLogService.CSSPAppName
                                                   && c.CommandName == CSSPLogService.CSSPCommandName
                                                   select c).ToList();

                Assert.True(commandLogList.Count == 1);
                Assert.False(string.IsNullOrWhiteSpace(commandLogList[0].Error));

                Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());

                WriteTimeSpan(webType);
            }
        }
    }
}
