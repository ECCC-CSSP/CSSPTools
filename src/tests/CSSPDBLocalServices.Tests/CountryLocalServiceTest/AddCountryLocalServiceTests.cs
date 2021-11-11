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
    public partial class CountryLocalServiceTest : CSSPDBLocalServiceTest
    {
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddCountryLocal_Good_Test(string culture)
        {
            Assert.True(await CountryLocalServiceSetup(culture));

            WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, 0);

            var actionCountryRes = await CountryLocalService.AddCountryLocalAsync(webRoot.TVItemModel.TVItem.TVItemID);
            Assert.Equal(200, ((ObjectResult)actionCountryRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionCountryRes.Result).Value);
            TVItemModel tvItemModelRet = (TVItemModel)((OkObjectResult)actionCountryRes.Result).Value;
            Assert.NotNull(tvItemModelRet);

            CheckTVItem(webRoot.TVItemModel, DBCommandEnum.Original);
            CheckTVItemLanguage(webRoot.TVItemModel, DBCommandEnum.Original, "Root", LanguageEnum.en);
            CheckTVItemLanguage(webRoot.TVItemModel, DBCommandEnum.Original, "Base", LanguageEnum.fr);

            foreach (MapInfoModel mapInfoModel in webRoot.TVItemModel.MapInfoModelList)
            {
                CheckMapInfoEmpty(mapInfoModel.MapInfo);
            }

            CheckTVItem(tvItemModelRet, DBCommandEnum.Created);
            CheckTVItemLanguage(tvItemModelRet, DBCommandEnum.Created, "New Country 1", LanguageEnum.en);
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
                webRoot.TVItemModel,
                tvItemModelRet,
            };

            CheckDBLocal(tvItemModelList);

            DirectoryInfo di = new DirectoryInfo(Configuration["CSSPJSONPathLocal"]);

            Assert.True(di.Exists);

            List<FileInfo> fiList = di.GetFiles().ToList();

            Assert.Equal(3, fiList.Count);

            Assert.True(fiList.Where(c => c.Name == $"{ WebTypeEnum.WebAllCountries }.gz").Any());
            Assert.True(fiList.Where(c => c.Name == $"{ WebTypeEnum.WebCountry }_{ tvItemModelRet.TVItem.TVItemID }.gz").Any());
            Assert.True(fiList.Where(c => c.Name == $"{ WebTypeEnum.WebRoot }.gz").Any());

            var actionCountryRes2 = await CountryLocalService.AddCountryLocalAsync(webRoot.TVItemModel.TVItem.TVItemID);
            Assert.Equal(200, ((ObjectResult)actionCountryRes2.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionCountryRes2.Result).Value);
            TVItemModel tvItemModelRet2 = (TVItemModel)((OkObjectResult)actionCountryRes2.Result).Value;
            Assert.NotNull(tvItemModelRet2);

            foreach (MapInfoModel mapInfoModel in tvItemModelRet2.MapInfoModelList)
            {
                CheckMapInfo(mapInfoModel.MapInfo, DBCommandEnum.Created);

                foreach (MapInfoPoint mapInfoPoint in mapInfoModel.MapInfoPointList)
                {
                    CheckMapInfoPoint(mapInfoPoint, DBCommandEnum.Created);
                }
            }

            CheckTVItem(webRoot.TVItemModel, DBCommandEnum.Original);
            CheckTVItemLanguage(webRoot.TVItemModel, DBCommandEnum.Original, "Root", LanguageEnum.en);
            CheckTVItemLanguage(webRoot.TVItemModel, DBCommandEnum.Original, "Base", LanguageEnum.fr);

            CheckTVItem(tvItemModelRet, DBCommandEnum.Created);
            CheckTVItemLanguage(tvItemModelRet, DBCommandEnum.Created, "New Country 1", LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelRet, DBCommandEnum.Created, "Nouveau Pays 1", LanguageEnum.fr);

            CheckTVItem(tvItemModelRet2, DBCommandEnum.Created);
            CheckTVItemLanguage(tvItemModelRet2, DBCommandEnum.Created, "New Country 2", LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelRet2, DBCommandEnum.Created, "Nouveau Pays 2", LanguageEnum.fr);

            List<TVItemModel> tvItemModelList2 = new List<TVItemModel>()
            {
                webRoot.TVItemModel,
                tvItemModelRet,
                tvItemModelRet2,
            };

            CheckDBLocal(tvItemModelList2);

            di = new DirectoryInfo(Configuration["CSSPJSONPathLocal"]);

            Assert.True(di.Exists);

            fiList = di.GetFiles().ToList();

            Assert.Equal(4, fiList.Count);

            Assert.True(fiList.Where(c => c.Name == $"{ WebTypeEnum.WebAllCountries }.gz").Any());
            Assert.True(fiList.Where(c => c.Name == $"{ WebTypeEnum.WebCountry }_{ tvItemModelRet.TVItem.TVItemID }.gz").Any());
            Assert.True(fiList.Where(c => c.Name == $"{ WebTypeEnum.WebCountry }_{ tvItemModelRet2.TVItem.TVItemID }.gz").Any());
            Assert.True(fiList.Where(c => c.Name == $"{ WebTypeEnum.WebRoot }.gz").Any());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddCountryLocal_ParentTVItemID_Error_Test(string culture)
        {
            Assert.True(await CountryLocalServiceSetup(culture));

            var actionCountryRes = await CountryLocalService.AddCountryLocalAsync(0);
            Assert.Equal(400, ((ObjectResult)actionCountryRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionCountryRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "ParentTVItemID"), errRes.ErrList[0]);
        }
    }
}
