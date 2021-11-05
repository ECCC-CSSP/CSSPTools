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
        public async Task AddProvinceLocal_Good_Test(string culture)
        {
            Assert.True(await ProvinceLocalServiceSetup(culture));

            int ParentTVItemID = 5;
             
            WebCountry webCountry = await CSSPReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, ParentTVItemID);

            var actionProvinceRes = await ProvinceLocalService.AddProvinceLocal(webCountry.TVItemModel.TVItem.TVItemID);
            Assert.Equal(200, ((ObjectResult)actionProvinceRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionProvinceRes.Result).Value);
            TVItemModel tvItemModelRet = (TVItemModel)((OkObjectResult)actionProvinceRes.Result).Value;
            Assert.NotNull(tvItemModelRet);

            CheckTVItem(webCountry.TVItemModel, DBCommandEnum.Original);
            CheckTVItemLanguage(webCountry.TVItemModel, DBCommandEnum.Original, "Country", LanguageEnum.en);
            CheckTVItemLanguage(webCountry.TVItemModel, DBCommandEnum.Original, "Base", LanguageEnum.fr);

            foreach (MapInfoModel mapInfoModel in webCountry.TVItemModel.MapInfoModelList)
            {
                CheckMapInfoEmpty(mapInfoModel.MapInfo);
            }

            CheckTVItem(tvItemModelRet, DBCommandEnum.Created);
            CheckTVItemLanguage(tvItemModelRet, DBCommandEnum.Created, "New Province 1", LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelRet, DBCommandEnum.Created, "Nouveau Pays 1", LanguageEnum.fr);

            foreach (MapInfoModel mapInfoModel in tvItemModelRet.MapInfoModelList)
            {
                CheckMapInfo(mapInfoModel.MapInfo, DBCommandEnum.Created);

                foreach (MapInfoPoint mapInfoPoint in mapInfoModel.MapInfoPointList)
                {
                    CheckMapInfoPoint(mapInfoPoint, DBCommandEnum.Created);
                }
            }

            List<TVItemModel> tvItemModelList = new List<TVItemModel>()
            {
                webCountry.TVItemModel,
                tvItemModelRet,
            };

            CheckDBLocal(tvItemModelList);

            DirectoryInfo di = new DirectoryInfo(Configuration["CSSPJSONPathLocal"]);

            Assert.True(di.Exists);

            List<FileInfo> fiList = di.GetFiles().ToList();

            Assert.Equal(3, fiList.Count);

            Assert.True(fiList.Where(c => c.Name == $"{ WebTypeEnum.WebAllProvinces }.gz").Any());
            Assert.True(fiList.Where(c => c.Name == $"{ WebTypeEnum.WebProvince }_{ tvItemModelRet.TVItem.TVItemID }.gz").Any());
            Assert.True(fiList.Where(c => c.Name == $"{ WebTypeEnum.WebCountry }_{ ParentTVItemID }.gz").Any());

            var actionProvinceRes2 = await ProvinceLocalService.AddProvinceLocal(webCountry.TVItemModel.TVItem.TVItemID);
            Assert.Equal(200, ((ObjectResult)actionProvinceRes2.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionProvinceRes2.Result).Value);
            TVItemModel tvItemModelRet2 = (TVItemModel)((OkObjectResult)actionProvinceRes2.Result).Value;
            Assert.NotNull(tvItemModelRet2);

            foreach (MapInfoModel mapInfoModel in tvItemModelRet2.MapInfoModelList)
            {
                CheckMapInfo(mapInfoModel.MapInfo, DBCommandEnum.Created);

                foreach (MapInfoPoint mapInfoPoint in mapInfoModel.MapInfoPointList)
                {
                    CheckMapInfoPoint(mapInfoPoint, DBCommandEnum.Created);
                }
            }

            CheckTVItem(webCountry.TVItemModel, DBCommandEnum.Original);
            CheckTVItemLanguage(webCountry.TVItemModel, DBCommandEnum.Original, "Canada", LanguageEnum.en);
            CheckTVItemLanguage(webCountry.TVItemModel, DBCommandEnum.Original, "Canada", LanguageEnum.fr);

            CheckTVItem(tvItemModelRet, DBCommandEnum.Created);
            CheckTVItemLanguage(tvItemModelRet, DBCommandEnum.Created, "New Province 1", LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelRet, DBCommandEnum.Created, "Nouveau Pays 1", LanguageEnum.fr);

            CheckTVItem(tvItemModelRet2, DBCommandEnum.Created);
            CheckTVItemLanguage(tvItemModelRet2, DBCommandEnum.Created, "New Province 2", LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelRet2, DBCommandEnum.Created, "Nouveau Pays 2", LanguageEnum.fr);

            List<TVItemModel> tvItemModelList2 = new List<TVItemModel>()
            {
                webCountry.TVItemModel,
                tvItemModelRet,
                tvItemModelRet2,
            };

            CheckDBLocal(tvItemModelList2);

            di = new DirectoryInfo(Configuration["CSSPJSONPathLocal"]);

            Assert.True(di.Exists);

            fiList = di.GetFiles().ToList();

            Assert.Equal(4, fiList.Count);

            Assert.True(fiList.Where(c => c.Name == $"{ WebTypeEnum.WebAllProvinces }.gz").Any());
            Assert.True(fiList.Where(c => c.Name == $"{ WebTypeEnum.WebProvince }_{ tvItemModelRet.TVItem.TVItemID }.gz").Any());
            Assert.True(fiList.Where(c => c.Name == $"{ WebTypeEnum.WebProvince }_{ tvItemModelRet2.TVItem.TVItemID }.gz").Any());
            Assert.True(fiList.Where(c => c.Name == $"{ WebTypeEnum.WebCountry }_{ ParentTVItemID }.gz").Any());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddProvinceLocal_ParentTVItemID_Error_Test(string culture)
        {
            Assert.True(await ProvinceLocalServiceSetup(culture));

            int ParentTVItemID = 0;

            var actionProvinceRes = await ProvinceLocalService.AddProvinceLocal(ParentTVItemID);
            Assert.Equal(400, ((ObjectResult)actionProvinceRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionProvinceRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "ParentTVItemID"), errRes.ErrList[0]);
        }
    }
}
