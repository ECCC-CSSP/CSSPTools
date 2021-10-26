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
        public async Task AddHelpDocLocal_Good_Test(string culture)
        {
            Assert.True(await HelpDocLocalServiceSetup(culture));

            HelpDocLocalModel helpDocLocalModel = FillHelpDocLocalModel();

            var actionPostTVItemModelRes = await HelpDocLocalService.AddHelpDocLocal(helpDocLocalModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            HelpDocLocalModel helpDocLocalModelRet = (HelpDocLocalModel)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(helpDocLocalModelRet);

            Assert.Equal(-1, helpDocLocalModelRet.HelpDoc.HelpDocID);
            Assert.Equal(DBCommandEnum.Created, helpDocLocalModelRet.HelpDoc.DBCommand);
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

            WebAllHelpDocs webAllHelpDocs = await CSSPReadGzFileService.GetUncompressJSON<WebAllHelpDocs>(WebTypeEnum.WebAllHelpDocs, 0);

            HelpDoc helpDocWeb = (from c in webAllHelpDocs.HelpDocList
                              where c.HelpDocID == -1
                              select c).FirstOrDefault();
            Assert.NotNull(helpDocWeb);

            await CSSPLogService.Save();

            List<CommandLog> commandLogList = (from c in dbManage.CommandLogs
                                               select c).ToList();

            Assert.Single(commandLogList);
            Assert.Contains("HelpDocLocalService.AddHelpDocLocal(HelpDocLocalModel helpDocLocalModel)", commandLogList[0].Log);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddHelpDocLocal_HelpDocID_Error_Test(string culture)
        {
            Assert.True(await HelpDocLocalServiceSetup(culture));

            HelpDocLocalModel helpDocLocalModel = FillHelpDocLocalModel();

            helpDocLocalModel.HelpDoc.HelpDocID = 10;

            var actionPostTVItemModelRes = await HelpDocLocalService.AddHelpDocLocal(helpDocLocalModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Equal(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "HelpDocID", "0"), errRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddHelpDocLocal_DocKey_Error_Test(string culture)
        {
            Assert.True(await HelpDocLocalServiceSetup(culture));

            HelpDocLocalModel helpDocLocalModel = FillHelpDocLocalModel();

            helpDocLocalModel.HelpDoc.DocKey = "";

            var actionPostTVItemModelRes = await HelpDocLocalService.AddHelpDocLocal(helpDocLocalModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "DocKey"), errRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddHelpDocLocal_Language_Error_Test(string culture)
        {
            Assert.True(await HelpDocLocalServiceSetup(culture));

            HelpDocLocalModel helpDocLocalModel = FillHelpDocLocalModel();

            helpDocLocalModel.HelpDoc.Language = (LanguageEnum)10000;

            var actionPostTVItemModelRes = await HelpDocLocalService.AddHelpDocLocal(helpDocLocalModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "Language"), errRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddHelpDocLocal_DocHTMLText_Error_Test(string culture)
        {
            Assert.True(await HelpDocLocalServiceSetup(culture));

            HelpDocLocalModel helpDocLocalModel = FillHelpDocLocalModel();

            helpDocLocalModel.HelpDoc.DocHTMLText = "";

            var actionPostTVItemModelRes = await HelpDocLocalService.AddHelpDocLocal(helpDocLocalModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "DocHTMLText"), errRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddHelpDocLocal_Return_Existing_HelpDoc_As_It_Already_Exist_Test(string culture)
        {
            Assert.True(await HelpDocLocalServiceSetup(culture));

            WebAllHelpDocs webAllHelpDocs = await CSSPReadGzFileService.GetUncompressJSON<WebAllHelpDocs>(WebTypeEnum.WebAllHelpDocs, 0);

            Assert.True(webAllHelpDocs.HelpDocList.Count > 10);

            HelpDocLocalModel helpDocLocalModel = FillHelpDocLocalModel();

            helpDocLocalModel.HelpDoc = webAllHelpDocs.HelpDocList[7];

            int HelpDocID = helpDocLocalModel.HelpDoc.HelpDocID;

            helpDocLocalModel.HelpDoc.HelpDocID = 0;

            var actionPostTVItemModelRes = await HelpDocLocalService.AddHelpDocLocal(helpDocLocalModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            HelpDocLocalModel helpDocLocalModelRet = (HelpDocLocalModel)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            helpDocLocalModel.HelpDoc.HelpDocID = HelpDocID;
            Assert.Equal(JsonSerializer.Serialize(helpDocLocalModel), JsonSerializer.Serialize(helpDocLocalModelRet));
        }
    }
}
