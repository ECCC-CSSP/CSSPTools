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
        public async Task ModifyHelpDocLocal_Good_Test(string culture)
        {
            Assert.True(await HelpDocLocalServiceSetup(culture));

            WebAllHelpDocs webAllHelpDocs = await CSSPReadGzFileService.GetUncompressJSON<WebAllHelpDocs>(WebTypeEnum.WebAllHelpDocs, 0);
            Assert.NotNull(webAllHelpDocs);
            Assert.NotEmpty(webAllHelpDocs.HelpDocList);
            Assert.True(webAllHelpDocs.HelpDocList.Count > 5);

            HelpDocLocalModel helpDocLocalModel = new HelpDocLocalModel() { HelpDoc = webAllHelpDocs.HelpDocList[3] };

            helpDocLocalModel.HelpDoc.DocHTMLText = "<html><head><title>The Title</title></head><body><p>Bonjour</p></body></html>";

            var actionPostTVItemModelRes = await HelpDocLocalService.ModifyHelpDocLocal(helpDocLocalModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            HelpDocLocalModel helpDocLocalModelRet = (HelpDocLocalModel)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(helpDocLocalModelRet);

            Assert.Equal(1, (from c in dbLocal.HelpDocs select c).Count());

            webAllHelpDocs = await CSSPReadGzFileService.GetUncompressJSON<WebAllHelpDocs>(WebTypeEnum.WebAllHelpDocs, 0);

            HelpDoc helpDoc = webAllHelpDocs.HelpDocList.Where(c => c.HelpDocID == -1).FirstOrDefault();
            Assert.NotNull(helpDoc);
            Assert.Equal(DBCommandEnum.Modified, helpDoc.DBCommand);
            Assert.Equal("<html><head><title>The Title</title></head><body><p>Bonjour</p></body></html>", helpDoc.DocHTMLText);

            Assert.Equal(-1, helpDocLocalModelRet.HelpDoc.HelpDocID);
            Assert.Equal(DBCommandEnum.Modified, helpDocLocalModelRet.HelpDoc.DBCommand);
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

            await CSSPLogService.Save();

            List<CommandLog> commandLogList = (from c in dbManage.CommandLogs
                                               select c).ToList();

            Assert.Single(commandLogList);
            Assert.Contains("HelpDocLocalService.ModifyHelpDocLocal(HelpDocLocalModel helpDocLocalModel)", commandLogList[0].Log);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ModifyHelpDocLocal_HelpDocID_Error_Test(string culture)
        {
            Assert.True(await HelpDocLocalServiceSetup(culture));

            WebAllHelpDocs webAllHelpDocs = await CSSPReadGzFileService.GetUncompressJSON<WebAllHelpDocs>(WebTypeEnum.WebAllHelpDocs, 0);
            Assert.NotNull(webAllHelpDocs);
            Assert.NotEmpty(webAllHelpDocs.HelpDocList);
            Assert.True(webAllHelpDocs.HelpDocList.Count > 5);

            HelpDocLocalModel helpDocLocalModel = new HelpDocLocalModel() { HelpDoc = webAllHelpDocs.HelpDocList[3] };

            helpDocLocalModel.HelpDoc.HelpDocID = 0;

            var actionPostTVItemModelRes = await HelpDocLocalService.ModifyHelpDocLocal(helpDocLocalModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Equal(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "HelpDocID", "0"), errRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ModifyHelpDocLocal_DocKey_Error_Test(string culture)
        {
            Assert.True(await HelpDocLocalServiceSetup(culture));

            WebAllHelpDocs webAllHelpDocs = await CSSPReadGzFileService.GetUncompressJSON<WebAllHelpDocs>(WebTypeEnum.WebAllHelpDocs, 0);
            Assert.NotNull(webAllHelpDocs);
            Assert.NotEmpty(webAllHelpDocs.HelpDocList);
            Assert.True(webAllHelpDocs.HelpDocList.Count > 5);

            HelpDocLocalModel helpDocLocalModel = new HelpDocLocalModel() { HelpDoc = webAllHelpDocs.HelpDocList[3] };

            helpDocLocalModel.HelpDoc.DocKey = "";

            var actionPostTVItemModelRes = await HelpDocLocalService.ModifyHelpDocLocal(helpDocLocalModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "DocKey"), errRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ModifyHelpDocLocal_Language_Error_Test(string culture)
        {
            Assert.True(await HelpDocLocalServiceSetup(culture));

            WebAllHelpDocs webAllHelpDocs = await CSSPReadGzFileService.GetUncompressJSON<WebAllHelpDocs>(WebTypeEnum.WebAllHelpDocs, 0);
            Assert.NotNull(webAllHelpDocs);
            Assert.NotEmpty(webAllHelpDocs.HelpDocList);
            Assert.True(webAllHelpDocs.HelpDocList.Count > 5);

            HelpDocLocalModel helpDocLocalModel = new HelpDocLocalModel() { HelpDoc = webAllHelpDocs.HelpDocList[3] };

            helpDocLocalModel.HelpDoc.Language = (LanguageEnum)10000;

            var actionPostTVItemModelRes = await HelpDocLocalService.ModifyHelpDocLocal(helpDocLocalModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "Language"), errRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ModifyHelpDocLocal_DocHTMLText_Error_Test(string culture)
        {
            Assert.True(await HelpDocLocalServiceSetup(culture));

            WebAllHelpDocs webAllHelpDocs = await CSSPReadGzFileService.GetUncompressJSON<WebAllHelpDocs>(WebTypeEnum.WebAllHelpDocs, 0);
            Assert.NotNull(webAllHelpDocs);
            Assert.NotEmpty(webAllHelpDocs.HelpDocList);
            Assert.True(webAllHelpDocs.HelpDocList.Count > 5);

            HelpDocLocalModel helpDocLocalModel = new HelpDocLocalModel() { HelpDoc = webAllHelpDocs.HelpDocList[3] };

            helpDocLocalModel.HelpDoc.DocHTMLText = "";

            var actionPostTVItemModelRes = await HelpDocLocalService.ModifyHelpDocLocal(helpDocLocalModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "DocHTMLText"), errRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ModifyHelpDocLocal_HelpDocID_Not_Found_Error_Test(string culture)
        {
            Assert.True(await HelpDocLocalServiceSetup(culture));

            WebAllHelpDocs webAllHelpDocs = await CSSPReadGzFileService.GetUncompressJSON<WebAllHelpDocs>(WebTypeEnum.WebAllHelpDocs, 0);
            Assert.NotNull(webAllHelpDocs);
            Assert.NotEmpty(webAllHelpDocs.HelpDocList);
            Assert.True(webAllHelpDocs.HelpDocList.Count > 5);

            HelpDocLocalModel helpDocLocalModel = new HelpDocLocalModel() { HelpDoc = webAllHelpDocs.HelpDocList[3] };

            helpDocLocalModel.HelpDoc.HelpDocID = 10000000;

            var actionPostTVItemModelRes = await HelpDocLocalService.ModifyHelpDocLocal(helpDocLocalModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Equal(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "HelpDoc", "HelpDocID", helpDocLocalModel.HelpDoc.HelpDocID.ToString()), errRes.ErrList[0]);
        }
    }
}
