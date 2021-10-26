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
    public partial class MWQMLookupMPNLocalServiceTest : CSSPDBLocalServiceTest
    {
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ModifyMWQMLookupMPNLocal_Good_Test(string culture)
        {
            Assert.True(await MWQMLookupMPNLocalServiceSetup(culture));

            WebAllMWQMLookupMPNs webAllMWQMLookupMPNs = await CSSPReadGzFileService.GetUncompressJSON<WebAllMWQMLookupMPNs>(WebTypeEnum.WebAllMWQMLookupMPNs, 0);
            Assert.NotNull(webAllMWQMLookupMPNs);
            Assert.NotEmpty(webAllMWQMLookupMPNs.MWQMLookupMPNList);
            Assert.True(webAllMWQMLookupMPNs.MWQMLookupMPNList.Count > 5);

            MWQMLookupMPNLocalModel mwqmLookupMPNLocalModel = new MWQMLookupMPNLocalModel() { MWQMLookupMPN = webAllMWQMLookupMPNs.MWQMLookupMPNList[3] };

            mwqmLookupMPNLocalModel.MWQMLookupMPN.MPN_100ml = 5432;

            var actionPostTVItemModelRes = await MWQMLookupMPNLocalService.ModifyMWQMLookupMPNLocal(mwqmLookupMPNLocalModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            MWQMLookupMPNLocalModel mwqmLookupMPNLocalModelRet = (MWQMLookupMPNLocalModel)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(mwqmLookupMPNLocalModelRet);

            MWQMLookupMPN mwqmLookupMPNDB = (from c in dbLocal.MWQMLookupMPNs
                                             where c.MWQMLookupMPNID == mwqmLookupMPNLocalModel.MWQMLookupMPN.MWQMLookupMPNID
                                             select c).FirstOrDefault();
            Assert.NotNull(mwqmLookupMPNDB);

            MWQMLookupMPNLocalModel mwqmLookupMPNLocalModelDB = new MWQMLookupMPNLocalModel()
            {
                MWQMLookupMPN = mwqmLookupMPNDB,
            };

            Assert.Equal(JsonSerializer.Serialize(mwqmLookupMPNLocalModelDB), JsonSerializer.Serialize(mwqmLookupMPNLocalModelRet));

            WebAllMWQMLookupMPNs webAllMWQMLookupMPNs2 = await CSSPReadGzFileService.GetUncompressJSON<WebAllMWQMLookupMPNs>(WebTypeEnum.WebAllMWQMLookupMPNs, 0);

            MWQMLookupMPN mwqmLookupMPNWeb = (from c in webAllMWQMLookupMPNs2.MWQMLookupMPNList
                                              where c.MWQMLookupMPNID == mwqmLookupMPNLocalModel.MWQMLookupMPN.MWQMLookupMPNID
                                              select c).FirstOrDefault();
            Assert.NotNull(mwqmLookupMPNWeb);

            await CSSPLogService.Save();

            List<CommandLog> commandLogList = (from c in dbManage.CommandLogs
                                               select c).ToList();

            Assert.Single(commandLogList);
            Assert.Contains("MWQMLookupMPNLocalService.ModifyMWQMLookupMPNLocal(MWQMLookupMPNLocalModel mwqmLookupMPNLocalModel)", commandLogList[0].Log);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ModifyMWQMLookupMPNLocal_MWQMLookupMPNID_Error_Test(string culture)
        {
            Assert.True(await MWQMLookupMPNLocalServiceSetup(culture));

            WebAllMWQMLookupMPNs webAllMWQMLookupMPNs = await CSSPReadGzFileService.GetUncompressJSON<WebAllMWQMLookupMPNs>(WebTypeEnum.WebAllMWQMLookupMPNs, 0);
            Assert.NotNull(webAllMWQMLookupMPNs);
            Assert.NotEmpty(webAllMWQMLookupMPNs.MWQMLookupMPNList);
            Assert.True(webAllMWQMLookupMPNs.MWQMLookupMPNList.Count > 5);

            MWQMLookupMPNLocalModel mwqmLookupMPNLocalModel = new MWQMLookupMPNLocalModel() { MWQMLookupMPN = webAllMWQMLookupMPNs.MWQMLookupMPNList[3] };

            mwqmLookupMPNLocalModel.MWQMLookupMPN.MWQMLookupMPNID = 0;

            var actionPostTVItemModelRes = await MWQMLookupMPNLocalService.ModifyMWQMLookupMPNLocal(mwqmLookupMPNLocalModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "MWQMLookupMPNID"), errRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ModifyMWQMLookupMPNLocal_Tube10_Error_Test(string culture)
        {
            Assert.True(await MWQMLookupMPNLocalServiceSetup(culture));

            WebAllMWQMLookupMPNs webAllMWQMLookupMPNs = await CSSPReadGzFileService.GetUncompressJSON<WebAllMWQMLookupMPNs>(WebTypeEnum.WebAllMWQMLookupMPNs, 0);
            Assert.NotNull(webAllMWQMLookupMPNs);
            Assert.NotEmpty(webAllMWQMLookupMPNs.MWQMLookupMPNList);
            Assert.True(webAllMWQMLookupMPNs.MWQMLookupMPNList.Count > 5);

            MWQMLookupMPNLocalModel mwqmLookupMPNLocalModel = new MWQMLookupMPNLocalModel() { MWQMLookupMPN = webAllMWQMLookupMPNs.MWQMLookupMPNList[3] };

            mwqmLookupMPNLocalModel.MWQMLookupMPN.Tubes10 = -1;

            var actionPostTVItemModelRes = await MWQMLookupMPNLocalService.ModifyMWQMLookupMPNLocal(mwqmLookupMPNLocalModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Equal(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Tubes10", "0", "5"), errRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ModifyMWQMLookupMPNLocal_Tube1_Error_Test(string culture)
        {
            Assert.True(await MWQMLookupMPNLocalServiceSetup(culture));

            WebAllMWQMLookupMPNs webAllMWQMLookupMPNs = await CSSPReadGzFileService.GetUncompressJSON<WebAllMWQMLookupMPNs>(WebTypeEnum.WebAllMWQMLookupMPNs, 0);
            Assert.NotNull(webAllMWQMLookupMPNs);
            Assert.NotEmpty(webAllMWQMLookupMPNs.MWQMLookupMPNList);
            Assert.True(webAllMWQMLookupMPNs.MWQMLookupMPNList.Count > 5);

            MWQMLookupMPNLocalModel mwqmLookupMPNLocalModel = new MWQMLookupMPNLocalModel() { MWQMLookupMPN = webAllMWQMLookupMPNs.MWQMLookupMPNList[3] };

            mwqmLookupMPNLocalModel.MWQMLookupMPN.Tubes1 = -1;

            var actionPostTVItemModelRes = await MWQMLookupMPNLocalService.ModifyMWQMLookupMPNLocal(mwqmLookupMPNLocalModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Equal(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Tubes1", "0", "5"), errRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ModifyMWQMLookupMPNLocal_Tube01_Error_Test(string culture)
        {
            Assert.True(await MWQMLookupMPNLocalServiceSetup(culture));

            WebAllMWQMLookupMPNs webAllMWQMLookupMPNs = await CSSPReadGzFileService.GetUncompressJSON<WebAllMWQMLookupMPNs>(WebTypeEnum.WebAllMWQMLookupMPNs, 0);
            Assert.NotNull(webAllMWQMLookupMPNs);
            Assert.NotEmpty(webAllMWQMLookupMPNs.MWQMLookupMPNList);
            Assert.True(webAllMWQMLookupMPNs.MWQMLookupMPNList.Count > 5);

            MWQMLookupMPNLocalModel mwqmLookupMPNLocalModel = new MWQMLookupMPNLocalModel() { MWQMLookupMPN = webAllMWQMLookupMPNs.MWQMLookupMPNList[3] };

            mwqmLookupMPNLocalModel.MWQMLookupMPN.Tubes01 = -1;

            var actionPostTVItemModelRes = await MWQMLookupMPNLocalService.ModifyMWQMLookupMPNLocal(mwqmLookupMPNLocalModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Equal(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Tubes01", "0", "5"), errRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ModifyMWQMLookupMPNLocal_MPN_100ml_Error_Test(string culture)
        {
            Assert.True(await MWQMLookupMPNLocalServiceSetup(culture));

            WebAllMWQMLookupMPNs webAllMWQMLookupMPNs = await CSSPReadGzFileService.GetUncompressJSON<WebAllMWQMLookupMPNs>(WebTypeEnum.WebAllMWQMLookupMPNs, 0);
            Assert.NotNull(webAllMWQMLookupMPNs);
            Assert.NotEmpty(webAllMWQMLookupMPNs.MWQMLookupMPNList);
            Assert.True(webAllMWQMLookupMPNs.MWQMLookupMPNList.Count > 5);

            MWQMLookupMPNLocalModel mwqmLookupMPNLocalModel = new MWQMLookupMPNLocalModel() { MWQMLookupMPN = webAllMWQMLookupMPNs.MWQMLookupMPNList[3] };

            mwqmLookupMPNLocalModel.MWQMLookupMPN.MPN_100ml = -1;

            var actionPostTVItemModelRes = await MWQMLookupMPNLocalService.ModifyMWQMLookupMPNLocal(mwqmLookupMPNLocalModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Equal(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "MPN_100ml", "1", "99000000"), errRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ModifyMWQMLookupMPNLocal_MWQMLookupMPNID_Not_Found_Error_Test(string culture)
        {
            Assert.True(await MWQMLookupMPNLocalServiceSetup(culture));

            WebAllMWQMLookupMPNs webAllMWQMLookupMPNs = await CSSPReadGzFileService.GetUncompressJSON<WebAllMWQMLookupMPNs>(WebTypeEnum.WebAllMWQMLookupMPNs, 0);
            Assert.NotNull(webAllMWQMLookupMPNs);
            Assert.NotEmpty(webAllMWQMLookupMPNs.MWQMLookupMPNList);
            Assert.True(webAllMWQMLookupMPNs.MWQMLookupMPNList.Count > 5);

            MWQMLookupMPNLocalModel mwqmLookupMPNLocalModel = new MWQMLookupMPNLocalModel() { MWQMLookupMPN = webAllMWQMLookupMPNs.MWQMLookupMPNList[3] };

            mwqmLookupMPNLocalModel.MWQMLookupMPN.MWQMLookupMPNID = 10000000;

            var actionPostTVItemModelRes = await MWQMLookupMPNLocalService.ModifyMWQMLookupMPNLocal(mwqmLookupMPNLocalModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Equal(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MWQMLookupMPN", "MWQMLookupMPNID", mwqmLookupMPNLocalModel.MWQMLookupMPN.MWQMLookupMPNID.ToString()), errRes.ErrList[0]);
        }
    }
}
