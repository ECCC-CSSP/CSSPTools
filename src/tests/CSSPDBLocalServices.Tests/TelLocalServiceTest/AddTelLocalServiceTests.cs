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
    public partial class TelLocalServiceTest : CSSPDBLocalServiceTest
    {
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTelLocal_Good_Test(string culture)
        {
            Assert.True(await TelLocalServiceSetup(culture));

            Tel telLocal = FillTel();

            var actionTelRes = await TelLocalService.AddTelLocal(telLocal);
            Assert.Equal(200, ((ObjectResult)actionTelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTelRes.Result).Value);
            Tel telLocalRet = (Tel)((OkObjectResult)actionTelRes.Result).Value;
            Assert.NotNull(telLocalRet);

            Assert.Equal(1, (from c in dbLocal.Tels select c).Count());
            Assert.Equal(2, (from c in dbLocal.TVItems select c).Count());
            Assert.Equal(4, (from c in dbLocal.TVItemLanguages select c).Count());

            Tel telDB = (from c in dbLocal.Tels
                             where c.TelID == -1
                             select c).FirstOrDefault();
            Assert.NotNull(telDB);

            Assert.Equal(JsonSerializer.Serialize(telDB), JsonSerializer.Serialize(telLocalRet));

            WebAllTels webAllTels = await CSSPReadGzFileService.GetUncompressJSON<WebAllTels>(WebTypeEnum.WebAllTels, 0);

            Tel telWeb = (from c in webAllTels.TelList
                              where c.TelID == -1
                              select c).FirstOrDefault();
            Assert.NotNull(telWeb);
            await CSSPLogService.Save();

            List<CommandLog> commandLogList = (from c in dbManage.CommandLogs
                                               select c).ToList();

            Assert.Single(commandLogList);
            Assert.Contains("TelLocalService.AddTelLocal(Tel tel)", commandLogList[0].Log);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTelLocal_TelID_Error_Test(string culture)
        {
            Assert.True(await TelLocalServiceSetup(culture));

            Tel telLocal = FillTel();

            telLocal.TelID = 10;

            var actionTelRes = await TelLocalService.AddTelLocal(telLocal);
            Assert.Equal(400, ((ObjectResult)actionTelRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Equal(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "TelID", "0"), errRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTelLocal_TelNumber_Error_Test(string culture)
        {
            Assert.True(await TelLocalServiceSetup(culture));

            Tel telLocal = FillTel();

            telLocal.TelNumber = "";

            var actionTelRes = await TelLocalService.AddTelLocal(telLocal);
            Assert.Equal(400, ((ObjectResult)actionTelRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "TelNumber"), errRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTelLocal_TelType_Error_Test(string culture)
        {
            Assert.True(await TelLocalServiceSetup(culture));

            Tel telLocal = FillTel();

            telLocal.TelType = (TelTypeEnum)10000;

            var actionTelRes = await TelLocalService.AddTelLocal(telLocal);
            Assert.Equal(400, ((ObjectResult)actionTelRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "TelType"), errRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTelLocal_Return_Existing_Tel_As_It_Already_Exist_Test(string culture)
        {
            Assert.True(await TelLocalServiceSetup(culture));

            WebAllTels webAllTels = await CSSPReadGzFileService.GetUncompressJSON<WebAllTels>(WebTypeEnum.WebAllTels, 0);

            Assert.True(webAllTels.TelList.Count > 10);

            Tel telLocal = FillTel();

            telLocal = webAllTels.TelList[7];

            int TelID = telLocal.TelID;

            telLocal.TelID = 0;

            var actionTelRes = await TelLocalService.AddTelLocal(telLocal);
            Assert.Equal(200, ((ObjectResult)actionTelRes.Result).StatusCode);
            Tel telLocalRet = (Tel)((OkObjectResult)actionTelRes.Result).Value;
            telLocal.TelID = TelID;
            Assert.Equal(JsonSerializer.Serialize(telLocal), JsonSerializer.Serialize(telLocalRet));
        }
    }
}
