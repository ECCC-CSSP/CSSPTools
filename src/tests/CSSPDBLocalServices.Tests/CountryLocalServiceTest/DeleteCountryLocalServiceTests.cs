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
        public async Task DeleteCountryLocal_Good_Test(string culture)
        {
            Assert.True(await CountryLocalServiceSetup(culture));

            WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, 0);

            var actionCountryRes = await CountryLocalService.AddCountryLocal(webRoot.TVItemModel.TVItem.TVItemID);
            Assert.Equal(200, ((ObjectResult)actionCountryRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionCountryRes.Result).Value);
            TVItemModel tvItemModelRet = (TVItemModel)((OkObjectResult)actionCountryRes.Result).Value;
            Assert.NotNull(tvItemModelRet);

            // see AddCountryLocal test for more detail testing

            var actionCountryRes2 = await CountryLocalService.DeleteCountryLocal(tvItemModelRet.TVItem.TVItemID);
            Assert.Equal(200, ((ObjectResult)actionCountryRes2.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionCountryRes2.Result).Value);
            TVItemModel tvItemModelDeleteRet = (TVItemModel)((OkObjectResult)actionCountryRes2.Result).Value;
            Assert.NotNull(tvItemModelDeleteRet);

            webRoot = await CSSPReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, 0);

            tvItemModelRet = (from c in webRoot.TVItemModelCountryList
                              where c.TVItem.TVItemID == tvItemModelRet.TVItem.TVItemID
                              select c).FirstOrDefault();

            Assert.NotNull(tvItemModelRet);

            foreach (MapInfoModel mapInfoModel in tvItemModelDeleteRet.MapInfoModelList)
            {
                CheckMapInfo(mapInfoModel.MapInfo, DBCommandEnum.Deleted);

                foreach (MapInfoPoint mapInfoPoint in mapInfoModel.MapInfoPointList)
                {
                    CheckMapInfoPoint(mapInfoPoint, DBCommandEnum.Deleted);
                }
            }

            CheckTVItem(webRoot.TVItemModel, DBCommandEnum.Original);
            CheckTVItemLanguage(webRoot.TVItemModel, DBCommandEnum.Original, "Root", LanguageEnum.en);
            CheckTVItemLanguage(webRoot.TVItemModel, DBCommandEnum.Original, "Base", LanguageEnum.fr);

            CheckTVItem(tvItemModelRet, DBCommandEnum.Deleted);
            CheckTVItemLanguage(tvItemModelRet, DBCommandEnum.Deleted, "New Country 1", LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelRet, DBCommandEnum.Deleted, "Nouveau Pays 1", LanguageEnum.fr);

            List<TVItemModel> tvItemModelList = new List<TVItemModel>()
            {
                webRoot.TVItemModel,
                tvItemModelDeleteRet,
            };

            CheckDBLocal(tvItemModelList);

            DirectoryInfo di = new DirectoryInfo(Configuration["CSSPJSONPathLocal"]);

            Assert.True(di.Exists);

            List<FileInfo> fiList = di.GetFiles().ToList();

            Assert.Equal(3, fiList.Count);

            Assert.True(fiList.Where(c => c.Name == $"{ WebTypeEnum.WebAllCountries }.gz").Any());
            Assert.True(fiList.Where(c => c.Name == $"{ WebTypeEnum.WebCountry }_{ tvItemModelRet.TVItem.TVItemID }.gz").Any());
            Assert.True(fiList.Where(c => c.Name == $"{ WebTypeEnum.WebRoot }.gz").Any());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DeleteCountryLocal_TVItemID_Error_Test(string culture)
        {
            Assert.True(await CountryLocalServiceSetup(culture));

            var actionCountryRes = await CountryLocalService.DeleteCountryLocal(0);
            Assert.Equal(400, ((ObjectResult)actionCountryRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionCountryRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "TVItemID"), errRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DeleteCountryLocal_CouldNotFind_Error_Test(string culture)
        {
            Assert.True(await CountryLocalServiceSetup(culture));

            int TVItemID = 10000;

            var actionCountryRes = await CountryLocalService.DeleteCountryLocal(TVItemID);
            Assert.Equal(400, ((ObjectResult)actionCountryRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionCountryRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Equal(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItemModel", "TVItemID", $"{ TVItemID }"), errRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DeleteCountryLocal_Children_Exist_Error_Test(string culture)
        {
            Assert.True(await CountryLocalServiceSetup(culture));

            WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, 0);

            Assert.NotEmpty(webRoot.TVItemModelCountryList);

            TVItemModel tvItemModelCountryToDelete = webRoot.TVItemModelCountryList[0];

            var actionCountryRes = await CountryLocalService.DeleteCountryLocal(tvItemModelCountryToDelete.TVItem.TVItemID);
            Assert.Equal(400, ((ObjectResult)actionCountryRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionCountryRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Equal(string.Format(CSSPCultureServicesRes.CouldNotDelete_Because_ChildrenExist, "TVItem Country", "Province"), errRes.ErrList[0]);
        }
    }
}
