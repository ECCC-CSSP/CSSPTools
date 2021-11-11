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
using System.IO;

namespace CSSPDBLocalServices.Tests
{
    public partial class ProvinceLocalServiceTest : CSSPDBLocalServiceTest
    {
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DeleteProvinceLocal_Good_Test(string culture)
        {
            Assert.True(await ProvinceLocalServiceSetup(culture));

            int ParentTVItemID = 5;

            WebCountry webCountry = await CSSPReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, ParentTVItemID);

            var actionProvinceRes = await ProvinceLocalService.AddProvinceLocalAsync(webCountry.TVItemModel.TVItem.TVItemID);
            Assert.Equal(200, ((ObjectResult)actionProvinceRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionProvinceRes.Result).Value);
            TVItemModel tvItemModelRet = (TVItemModel)((OkObjectResult)actionProvinceRes.Result).Value;
            Assert.NotNull(tvItemModelRet);

            // see AddProvinceLocal test for more detail testing

            var actionProvinceRes2 = await ProvinceLocalService.DeleteProvinceLocalAsync(ParentTVItemID, tvItemModelRet.TVItem.TVItemID);
            Assert.Equal(200, ((ObjectResult)actionProvinceRes2.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionProvinceRes2.Result).Value);
            TVItemModel tvItemModelDeleteRet = (TVItemModel)((OkObjectResult)actionProvinceRes2.Result).Value;
            Assert.NotNull(tvItemModelDeleteRet);

            webCountry = await CSSPReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, ParentTVItemID);

            tvItemModelRet = (from c in webCountry.TVItemModelProvinceList
                              where c.TVItem.TVItemID == tvItemModelRet.TVItem.TVItemID
                              select c).FirstOrDefault();

            Assert.NotNull(tvItemModelRet);

            foreach (MapInfoModel mapInfoModel in tvItemModelRet.MapInfoModelList)
            {
                CheckMapInfo(mapInfoModel.MapInfo, DBCommandEnum.Deleted);

                foreach (MapInfoPoint mapInfoPoint in mapInfoModel.MapInfoPointList)
                {
                    CheckMapInfoPoint(mapInfoPoint, DBCommandEnum.Deleted);
                }
            }

            CheckTVItem(webCountry.TVItemModel, DBCommandEnum.Original);
            CheckTVItemLanguage(webCountry.TVItemModel, DBCommandEnum.Original, "Canada", LanguageEnum.en);
            CheckTVItemLanguage(webCountry.TVItemModel, DBCommandEnum.Original, "Canada", LanguageEnum.fr);

            CheckTVItem(tvItemModelRet, DBCommandEnum.Deleted);
            CheckTVItemLanguage(tvItemModelRet, DBCommandEnum.Deleted, "New Province 1", LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelRet, DBCommandEnum.Deleted, "Nouveau Pays 1", LanguageEnum.fr);

            List<TVItemModel> tvItemModelList = new List<TVItemModel>()
            {
                webCountry.TVItemModel,
                tvItemModelDeleteRet,
            };

            CheckDBLocal(tvItemModelList);

            DirectoryInfo di = new DirectoryInfo(Configuration["CSSPJSONPathLocal"]);

            Assert.True(di.Exists);

            List<FileInfo> fiList = di.GetFiles().ToList();

            Assert.Equal(3, fiList.Count);

            Assert.True(fiList.Where(c => c.Name == $"{ WebTypeEnum.WebAllProvinces }.gz").Any());
            Assert.True(fiList.Where(c => c.Name == $"{ WebTypeEnum.WebProvince }_{ tvItemModelRet.TVItem.TVItemID }.gz").Any());
            Assert.True(fiList.Where(c => c.Name == $"{ WebTypeEnum.WebCountry }_{ ParentTVItemID }.gz").Any());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DeleteProvinceLocal_ParentTVItemID_Error_Test(string culture)
        {
            Assert.True(await ProvinceLocalServiceSetup(culture));

            int ParentTVItemID = 0;
            int TVItemID = 7;

            var actionProvinceRes = await ProvinceLocalService.DeleteProvinceLocalAsync(ParentTVItemID, TVItemID);
            Assert.Equal(400, ((ObjectResult)actionProvinceRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionProvinceRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "ParentTVItemID"), errRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DeleteProvinceLocal_TVItemID_Error_Test(string culture)
        {
            Assert.True(await ProvinceLocalServiceSetup(culture));

            int ParentTVItemID = 5;
            int TVItemID = 0;

            var actionProvinceRes = await ProvinceLocalService.DeleteProvinceLocalAsync(ParentTVItemID, TVItemID);
            Assert.Equal(400, ((ObjectResult)actionProvinceRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionProvinceRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "TVItemID"), errRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DeleteProvinceLocal_CouldNotFind_WebCountry_Error_Test(string culture)
        {
            Assert.True(await ProvinceLocalServiceSetup(culture));

            int ParentTVItemID = 10000;
            int TVItemID = 7;

            string fileName = await BaseGzFileService.GetFileName(WebTypeEnum.WebCountry, ParentTVItemID);

            var actionProvinceRes = await ProvinceLocalService.DeleteProvinceLocalAsync(ParentTVItemID, TVItemID);
            Assert.Equal(400, ((ObjectResult)actionProvinceRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionProvinceRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Equal(string.Format(CSSPCultureServicesRes.FileNotFound_, fileName), errRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DeleteProvinceLocal_CouldNotFind_ProvinceItem_Error_Test(string culture)
        {
            Assert.True(await ProvinceLocalServiceSetup(culture));

            int ParentTVItemID = 5;
            int TVItemID = 10000;

            var actionProvinceRes = await ProvinceLocalService.DeleteProvinceLocalAsync(ParentTVItemID, TVItemID);
            Assert.Equal(400, ((ObjectResult)actionProvinceRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionProvinceRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Equal(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItemModel", "TVItemID", $"{ TVItemID }"), errRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DeleteProvinceLocal_Children_Exist_Error_Test(string culture)
        {
            Assert.True(await ProvinceLocalServiceSetup(culture));

            int ParentTVItemID = 5;

            WebCountry webCountry = await CSSPReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, ParentTVItemID);

            Assert.NotEmpty(webCountry.TVItemModelProvinceList);

            TVItemModel tvItemModelProvinceToDelete = webCountry.TVItemModelProvinceList[0];

            var actionProvinceRes = await ProvinceLocalService.DeleteProvinceLocalAsync(webCountry.TVItemModel.TVItem.TVItemID, tvItemModelProvinceToDelete.TVItem.TVItemID);
            Assert.Equal(400, ((ObjectResult)actionProvinceRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionProvinceRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Equal(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem Province", "Area"), errRes.ErrList[0]);
        }
    }
}
