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
        public async Task DeleteTVItemLocal_Root_Country_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, 0);

            TVItem tvItemParent = webRoot.TVItemModel.TVItem;

            Assert.NotEmpty(webRoot.TVItemModelCountryList);

            TVItemModel tvItemModelExist = webRoot.TVItemModelCountryList[0];

            string TVTextEN = tvItemModelExist.TVItemLanguageList[0].TVText;
            string TVTextFR = tvItemModelExist.TVItemLanguageList[1].TVText;

            var actionTVItemModelExist = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelExist);
            Assert.Equal(400, ((ObjectResult)actionTVItemModelExist.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionTVItemModelExist.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModelExist.Result).Value;
            Assert.NotEmpty(errRes.ErrList);
            Assert.Equal(4, errRes.ErrList.Count);
            Assert.Equal(string.Format(CSSPCultureServicesRes.CouldNotDelete_Because_ChildrenExist, "TVItem Country", "Province"), errRes.ErrList[0]);
            Assert.Equal(string.Format(CSSPCultureServicesRes.CouldNotDelete_Because_ChildrenExist, "TVItem Country", "RainExceedance"), errRes.ErrList[1]);
            Assert.Equal(string.Format(CSSPCultureServicesRes.CouldNotDelete_Because_ChildrenExist, "TVItem Country", "EmailDistributionList"), errRes.ErrList[2]);
            Assert.Equal(string.Format(CSSPCultureServicesRes.CouldNotDelete_Because_ChildrenExist, "TVItem Country", "File"), errRes.ErrList[3]);

            Assert.True(await TVItemLocalServiceSetup(culture));

            webRoot = await CSSPReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, 0);

            tvItemParent = webRoot.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.Country;
            TVTextEN = "New Item";
            TVTextFR = "Nouveau Item";

            var actionTVItemModelAdded = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModelAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModelAdded.Result).Value);
            TVItemModel tvItemModelAdded = (TVItemModel)((OkObjectResult)actionTVItemModelAdded.Result).Value;
            Assert.NotNull(tvItemModelAdded);

            CheckCreatedTVItemAndTVItemLanguageList(tvItemModelAdded, TVTextEN, TVTextFR);

            webRoot = await CSSPReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, 0);

            var actionTVItemModel = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelAdded);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            CheckDeletedTVItemAndTVItemLanguageList(tvItemModel, TVTextEN, TVTextFR);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DeleteTVItemLocal_Root_Address_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            // no testing required
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DeleteTVItemLocal_Root_Email_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            // no testing required
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DeleteTVItemLocal_Root_Tel_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            // no testing required
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DeleteTVItemLocal_Country_Province_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            int TVItemID = 5;

            WebCountry webCountry = await CSSPReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, TVItemID);

            TVItem tvItemParent = webCountry.TVItemModel.TVItem;

            Assert.NotEmpty(webCountry.TVItemModelProvinceList);

            TVItemModel tvItemModelExist = webCountry.TVItemModelProvinceList[0];

            string TVTextEN = tvItemModelExist.TVItemLanguageList[0].TVText;
            string TVTextFR = tvItemModelExist.TVItemLanguageList[1].TVText;

            var actionTVItemModelExist = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelExist);
            Assert.Equal(400, ((ObjectResult)actionTVItemModelExist.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionTVItemModelExist.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModelExist.Result).Value;
            Assert.NotEmpty(errRes.ErrList);
            Assert.Equal(4, errRes.ErrList.Count);
            Assert.Equal(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem Province", "Area"), errRes.ErrList[0]);
            Assert.Equal(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem Province", "SamplingPlan"), errRes.ErrList[1]);
            Assert.Equal(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem Province", "Municipality"), errRes.ErrList[2]);
            Assert.Equal(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem Province", "File"), errRes.ErrList[3]);

            Assert.True(await TVItemLocalServiceSetup(culture));

            webCountry = await CSSPReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, TVItemID);

            tvItemParent = webCountry.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.Province;
            TVTextEN = "New Item";
            TVTextFR = "Nouveau Item";

            var actionTVItemModelAdded = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModelAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModelAdded.Result).Value);
            TVItemModel tvItemModelAdded = (TVItemModel)((OkObjectResult)actionTVItemModelAdded.Result).Value;
            Assert.NotNull(tvItemModelAdded);

            CheckCreatedTVItemAndTVItemLanguageList(tvItemModelAdded, TVTextEN, TVTextFR);

            webCountry = await CSSPReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, TVItemID);

            var actionTVItemModel = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelAdded);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            CheckDeletedTVItemAndTVItemLanguageList(tvItemModel, TVTextEN, TVTextFR);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DeleteTVItemLocal_Country_RainExceedance_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            int TVItemID = 5;

            WebCountry webCountry = await CSSPReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, TVItemID);

            TVItem tvItemParent = webCountry.TVItemModel.TVItem;

            Assert.NotEmpty(webCountry.RainExceedanceModelList);

            TVItemModel tvItemModelExist = webCountry.RainExceedanceModelList[0].TVItemModel;

            tvItemParent = tvItemModelExist.TVItem;

            string TVTextEN = tvItemModelExist.TVItemLanguageList[0].TVText;
            string TVTextFR = tvItemModelExist.TVItemLanguageList[1].TVText;

            var actionTVItemModelExist = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelExist);
            Assert.Equal(400, ((ObjectResult)actionTVItemModelExist.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionTVItemModelExist.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModelExist.Result).Value;
            Assert.NotEmpty(errRes.ErrList);
            Assert.Single(errRes.ErrList);
            Assert.Equal(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem RainExceedance", "RainExceedance"), errRes.ErrList[0]);

            Assert.True(await TVItemLocalServiceSetup(culture));

            webCountry = await CSSPReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, TVItemID);

            tvItemParent = webCountry.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.RainExceedance;
            TVTextEN = "New Item";
            TVTextFR = "Nouveau Item";

            var actionTVItemModelAdded = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModelAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModelAdded.Result).Value);
            TVItemModel tvItemModelAdded = (TVItemModel)((OkObjectResult)actionTVItemModelAdded.Result).Value;
            Assert.NotNull(tvItemModelAdded);

            CheckCreatedTVItemAndTVItemLanguageList(tvItemModelAdded, TVTextEN, TVTextFR);

            webCountry = await CSSPReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, TVItemID);

            tvItemParent = tvItemModelAdded.TVItem;

            var actionTVItemModel = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelAdded);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            CheckDeletedTVItemAndTVItemLanguageList(tvItemModel, TVTextEN, TVTextFR);
        }
    }
}
