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
    public partial class TVItemLocalServiceTest : CSSPDBLocalServiceTest
    {
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_Properties_TVItemParent_TVItemID_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, 0);

            TVItem tvItemParent = webRoot.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.Country;
            string TVTextEN = "New Country";
            string TVTextFR = "Nouveau Pays";

            tvItemParent.TVItemID = 0;

            var actionTVItemModel = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(400, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionTVItemModel.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(errRes);
            Assert.Equal(0, (from c in dbLocal.TVItems select c).Count());
            Assert.Equal(0, (from c in dbLocal.TVItemLanguages select c).Count());
            Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "TVItemID"), CSSPLogService.ErrRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_Properties_TVItemParent_TVLevel_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, 0);

            TVItem tvItemParent = webRoot.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.Country;
            string TVTextEN = "New Country";
            string TVTextFR = "Nouveau Pays";

            tvItemParent.TVLevel = -1;

            var actionTVItemModel = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(400, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionTVItemModel.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(errRes);
            Assert.Equal(0, (from c in dbLocal.TVItems select c).Count());
            Assert.Equal(0, (from c in dbLocal.TVItemLanguages select c).Count());
            Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "TVLevel"), CSSPLogService.ErrRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_Properties_TVItemParent_TVPath_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, 0);

            TVItem tvItemParent = webRoot.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.Country;
            string TVTextEN = "New Country";
            string TVTextFR = "Nouveau Pays";

            tvItemParent.TVPath = "";

            var actionTVItemModel = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(400, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionTVItemModel.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(errRes);
            Assert.Equal(0, (from c in dbLocal.TVItems select c).Count());
            Assert.Equal(0, (from c in dbLocal.TVItemLanguages select c).Count());
            Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "TVPath"), CSSPLogService.ErrRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_Properties_TVType_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, 0);

            TVItem tvItemParent = webRoot.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.Country;
            string TVTextEN = "New Country";
            string TVTextFR = "Nouveau Pays";

            tvType = (TVTypeEnum)10000;

            var actionTVItemModel = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(400, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionTVItemModel.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(errRes);
            Assert.Equal(0, (from c in dbLocal.TVItems select c).Count());
            Assert.Equal(0, (from c in dbLocal.TVItemLanguages select c).Count());
            Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "tvType"), CSSPLogService.ErrRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_Properties_TVTypeParent_Is_Truly_A_Parent_of_TVType_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, 0);

            TVItem tvItemParent = webRoot.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.Country;
            string TVTextEN = "New Country";
            string TVTextFR = "Nouveau Pays";

            tvType = TVTypeEnum.MWQMSite;

            var actionTVItemModel = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(400, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionTVItemModel.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(errRes);
            Assert.Equal(0, (from c in dbLocal.TVItems select c).Count());
            Assert.Equal(0, (from c in dbLocal.TVItemLanguages select c).Count());
            Assert.Equal(string.Format(CSSPCultureServicesRes._IsNotAParentTypeOf_, tvItemParent.TVType.ToString(), tvType.ToString()), CSSPLogService.ErrRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_Properties_TVTypeParent_Is_not_implemented_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, 0);

            TVItem tvItemParent = webRoot.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.Country;
            string TVTextEN = "New Country";
            string TVTextFR = "Nouveau Pays";

            tvItemParent.TVType = TVTypeEnum.BoxModel;
            tvItemParent.TVLevel = 1;

            var actionTVItemModel = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(400, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionTVItemModel.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(errRes);
            Assert.Equal(0, (from c in dbLocal.TVItems select c).Count());
            Assert.Equal(0, (from c in dbLocal.TVItemLanguages select c).Count());
            Assert.Equal(string.Format(CSSPCultureServicesRes._NotImplementedYet, tvItemParent.TVType.ToString()) + " --- CSSPDBLocalServices.TVItemLocalService.CheckTVTypeParentAndTVType", CSSPLogService.ErrRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_Properties_TVTextEN_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, 0);

            TVItem tvItemParent = webRoot.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.Country;
            string TVTextEN = "New Country";
            string TVTextFR = "Nouveau Pays";

            TVTextEN = "";

            var actionTVItemModel = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(400, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionTVItemModel.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(errRes);
            Assert.Equal(0, (from c in dbLocal.TVItems select c).Count());
            Assert.Equal(0, (from c in dbLocal.TVItemLanguages select c).Count());
            Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "TVTextEN"), CSSPLogService.ErrRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_Properties_TVTextFR_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, 0);

            TVItem tvItemParent = webRoot.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.Country;
            string TVTextEN = "New Country";
            string TVTextFR = "Nouveau Pays";

            TVTextFR = "";

            var actionTVItemModel = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(400, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionTVItemModel.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(errRes);
            Assert.Equal(0, (from c in dbLocal.TVItems select c).Count());
            Assert.Equal(0, (from c in dbLocal.TVItemLanguages select c).Count());
            Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "TVTextFR"), CSSPLogService.ErrRes.ErrList[0]);
        }
    }
}
