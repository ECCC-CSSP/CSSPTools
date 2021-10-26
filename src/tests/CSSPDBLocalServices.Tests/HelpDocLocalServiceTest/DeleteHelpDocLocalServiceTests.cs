/* 
 *  Manually Edited
 *  
 */

using CSSPCultureServices.Resources;
using CSSPDBModels;
using CSSPEnums;
using CSSPHelperModels;
using CSSPReadGzFileServices;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using System.Text.Json;
using ManageServices;

namespace CSSPDBLocalServices.Tests
{
    public partial class HelpDocLocalServiceTest : CSSPDBLocalServiceTest
    {
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DeleteHelpDocLocal_Good_Test(string culture)
        {
            Assert.True(await HelpDocLocalServiceSetup(culture));

            WebAllHelpDocs webAllHelpDocs = await CSSPReadGzFileService.GetUncompressJSON<WebAllHelpDocs>(WebTypeEnum.WebAllHelpDocs, 0);
            Assert.NotNull(webAllHelpDocs);
            Assert.NotEmpty(webAllHelpDocs.HelpDocList);
            Assert.True(webAllHelpDocs.HelpDocList.Count > 5);

            HelpDocLocalModel helpDocLocalModel = new HelpDocLocalModel() { HelpDoc = webAllHelpDocs.HelpDocList[3] };

            var actionPostTVItemModelRes = await HelpDocLocalService.DeleteHelpDocLocal(helpDocLocalModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            HelpDocLocalModel helpDocLocalModelRet = (HelpDocLocalModel)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(helpDocLocalModelRet);

            Assert.Equal(-1, helpDocLocalModelRet.HelpDoc.HelpDocID);
            Assert.Equal(DBCommandEnum.Deleted, helpDocLocalModelRet.HelpDoc.DBCommand);
            Assert.Equal(helpDocLocalModel.HelpDoc.DocHTMLText, helpDocLocalModelRet.HelpDoc.DocHTMLText);
            Assert.Equal(helpDocLocalModel.HelpDoc.DocKey, helpDocLocalModelRet.HelpDoc.DocKey);
            Assert.Equal(helpDocLocalModel.HelpDoc.Language, helpDocLocalModelRet.HelpDoc.Language);
            Assert.Equal(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID, helpDocLocalModelRet.HelpDoc.LastUpdateContactTVItemID);
            Assert.True(DateTime.UtcNow.AddSeconds(-1) < helpDocLocalModelRet.HelpDoc.LastUpdateDate_UTC);
            Assert.True(DateTime.UtcNow.AddSeconds(1) > helpDocLocalModelRet.HelpDoc.LastUpdateDate_UTC);

            HelpDoc helpDocDB = (from c in dbLocal.HelpDocs
                                 where c.HelpDocID == -1
                                 select c).FirstOrDefault();
            Assert.NotNull(helpDocDB);

            HelpDocLocalModel helpDocLocalModelDB = new HelpDocLocalModel()
            {
                HelpDoc = helpDocDB,
            };

            Assert.Equal(JsonSerializer.Serialize(helpDocLocalModelDB), JsonSerializer.Serialize(helpDocLocalModelRet));

            webAllHelpDocs = await CSSPReadGzFileService.GetUncompressJSON<WebAllHelpDocs>(WebTypeEnum.WebAllHelpDocs, 0);

            HelpDoc helpDoc = webAllHelpDocs.HelpDocList.Where(c => c.HelpDocID == -1).FirstOrDefault();
            Assert.NotNull(helpDoc);
            Assert.Equal(DBCommandEnum.Deleted, helpDoc.DBCommand);

            await CSSPLogService.Save();

            List<CommandLog> commandLogList = (from c in dbManage.CommandLogs
                                               select c).ToList();

            Assert.Single(commandLogList);
            Assert.Contains("HelpDocLocalService.DeleteHelpDocLocal(HelpDocLocalModel helpDocLocalModel)", commandLogList[0].Log);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DeleteHelpDocLocal_HelpDocID_Error_Test(string culture)
        {
            Assert.True(await HelpDocLocalServiceSetup(culture));

            WebAllHelpDocs webAllHelpDocs = await CSSPReadGzFileService.GetUncompressJSON<WebAllHelpDocs>(WebTypeEnum.WebAllHelpDocs, 0);
            Assert.NotNull(webAllHelpDocs);
            Assert.NotEmpty(webAllHelpDocs.HelpDocList);
            Assert.True(webAllHelpDocs.HelpDocList.Count > 5);

            HelpDocLocalModel helpDocLocalModel = new HelpDocLocalModel() { HelpDoc = webAllHelpDocs.HelpDocList[3] };

            helpDocLocalModel.HelpDoc.HelpDocID = 0;

            var actionPostTVItemModelRes = await HelpDocLocalService.DeleteHelpDocLocal(helpDocLocalModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "HelpDocID"), errRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DeleteHelpDocLocal_Not_Found_Error_Test(string culture)
        {
            Assert.True(await HelpDocLocalServiceSetup(culture));

            WebAllHelpDocs webAllHelpDocs = await CSSPReadGzFileService.GetUncompressJSON<WebAllHelpDocs>(WebTypeEnum.WebAllHelpDocs, 0);
            Assert.NotNull(webAllHelpDocs);
            Assert.NotEmpty(webAllHelpDocs.HelpDocList);
            Assert.True(webAllHelpDocs.HelpDocList.Count > 5);

            HelpDocLocalModel helpDocLocalModel = new HelpDocLocalModel() { HelpDoc = webAllHelpDocs.HelpDocList[3] };

            helpDocLocalModel.HelpDoc.HelpDocID = 100000;

            var actionPostTVItemModelRes = await HelpDocLocalService.DeleteHelpDocLocal(helpDocLocalModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Equal(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "HelpDoc", "HelpDocID", helpDocLocalModel.HelpDoc.HelpDocID.ToString()), errRes.ErrList[0]);
        }
    }
}
