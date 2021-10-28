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
        public async Task DeleteTVItemLocal_Country_Good_Test(string culture)
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

            List<TVItemModel> tvItemModelParentList = webRoot.TVItemModelParentList;

            tvItemModelParentList.Add(tvItemModel);

            CheckDBLocal(tvItemModelParentList);
            CheckLocalJsonFileCreated(tvItemModelParentList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DeleteTVItemLocal_Address_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            // no testing required
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DeleteTVItemLocal_Email_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            // no testing required
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DeleteTVItemLocal_Tel_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            // no testing required
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DeleteTVItemLocal_Province_Good_Test(string culture)
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

            List<TVItemModel> tvItemModelParentList = webCountry.TVItemModelParentList;

            tvItemModelParentList.Add(tvItemModel);

            CheckDBLocal(tvItemModelParentList);
            CheckLocalJsonFileCreated(tvItemModelParentList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DeleteTVItemLocal_RainExceedance_Good_Test(string culture)
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

            List<TVItemModel> tvItemModelParentList = webCountry.TVItemModelParentList;

            tvItemModelParentList.Add(tvItemModel);

            CheckDBLocal(tvItemModelParentList);
            CheckLocalJsonFileCreated(tvItemModelParentList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DeleteTVItemLocal_EmailDistributionList_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            int TVItemID = 5;

            WebCountry webCountry = await CSSPReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, TVItemID);

            TVItem tvItemParent = webCountry.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.EmailDistributionList;
            string TVTextEN = "New Item";
            string TVTextFR = "Nouveau Item";

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

            List<TVItemModel> tvItemModelParentList = webCountry.TVItemModelParentList;

            tvItemModelParentList.Add(tvItemModel);

            CheckDBLocal(tvItemModelParentList);
            CheckLocalJsonFileCreated(tvItemModelParentList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DeleteTVItemLocal_Area_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            int TVItemID = 7;

            WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

            TVItem tvItemParent = webProvince.TVItemModel.TVItem;

            Assert.NotEmpty(webProvince.TVItemModelAreaList);

            TVItemModel tvItemModelExist = webProvince.TVItemModelAreaList[0];

            string TVTextEN = tvItemModelExist.TVItemLanguageList[0].TVText;
            string TVTextFR = tvItemModelExist.TVItemLanguageList[1].TVText;

            var actionTVItemModelExist = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelExist);
            Assert.Equal(400, ((ObjectResult)actionTVItemModelExist.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionTVItemModelExist.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModelExist.Result).Value;
            Assert.NotEmpty(errRes.ErrList);

            Assert.True(await TVItemLocalServiceSetup(culture));

            webProvince = await CSSPReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

            tvItemParent = webProvince.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.Area;
            TVTextEN = "New Item";
            TVTextFR = "Nouveau Item";

            var actionTVItemModelAdded = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModelAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModelAdded.Result).Value);
            TVItemModel tvItemModelAdded = (TVItemModel)((OkObjectResult)actionTVItemModelAdded.Result).Value;
            Assert.NotNull(tvItemModelAdded);

            CheckCreatedTVItemAndTVItemLanguageList(tvItemModelAdded, TVTextEN, TVTextFR);

            webProvince = await CSSPReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

            var actionTVItemModel = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelAdded);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            CheckDeletedTVItemAndTVItemLanguageList(tvItemModel, TVTextEN, TVTextFR);

            List<TVItemModel> tvItemModelParentList = webProvince.TVItemModelParentList;

            tvItemModelParentList.Add(tvItemModel);

            CheckDBLocal(tvItemModelParentList);
            CheckLocalJsonFileCreated(tvItemModelParentList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DeleteTVItemLocal_SamplingPlan_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            int TVItemID = 7;

            WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

            TVItem tvItemParent = webProvince.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.SamplingPlan;
            string TVTextEN = "New Item";
            string TVTextFR = "Nouveau Item";

            var actionTVItemModelAdded = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModelAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModelAdded.Result).Value);
            TVItemModel tvItemModelAdded = (TVItemModel)((OkObjectResult)actionTVItemModelAdded.Result).Value;
            Assert.NotNull(tvItemModelAdded);

            CheckCreatedTVItemAndTVItemLanguageList(tvItemModelAdded, TVTextEN, TVTextFR);

            webProvince = await CSSPReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

            var actionTVItemModel = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelAdded);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            CheckDeletedTVItemAndTVItemLanguageList(tvItemModel, TVTextEN, TVTextFR);

            List<TVItemModel> tvItemModelParentList = webProvince.TVItemModelParentList;

            tvItemModelParentList.Add(tvItemModel);

            CheckDBLocal(tvItemModelParentList);
            CheckLocalJsonFileCreated(tvItemModelParentList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DeleteTVItemLocal_Municipality_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            int TVItemID = 7;

            WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

            TVItem tvItemParent = webProvince.TVItemModel.TVItem;

            Assert.NotEmpty(webProvince.TVItemModelMunicipalityList);

            TVItemModel tvItemModelExist = webProvince.TVItemModelMunicipalityList[0];

            string TVTextEN = tvItemModelExist.TVItemLanguageList[0].TVText;
            string TVTextFR = tvItemModelExist.TVItemLanguageList[1].TVText;

            var actionTVItemModelExist = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelExist);
            Assert.Equal(400, ((ObjectResult)actionTVItemModelExist.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionTVItemModelExist.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModelExist.Result).Value;
            Assert.NotEmpty(errRes.ErrList);

            Assert.True(await TVItemLocalServiceSetup(culture));

            webProvince = await CSSPReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

            tvItemParent = webProvince.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.Municipality;
            TVTextEN = "New Item";
            TVTextFR = "Nouveau Item";

            var actionTVItemModelAdded = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModelAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModelAdded.Result).Value);
            TVItemModel tvItemModelAdded = (TVItemModel)((OkObjectResult)actionTVItemModelAdded.Result).Value;
            Assert.NotNull(tvItemModelAdded);

            CheckCreatedTVItemAndTVItemLanguageList(tvItemModelAdded, TVTextEN, TVTextFR);

            webProvince = await CSSPReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

            var actionTVItemModel = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelAdded);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            CheckDeletedTVItemAndTVItemLanguageList(tvItemModel, TVTextEN, TVTextFR);

            List<TVItemModel> tvItemModelParentList = webProvince.TVItemModelParentList;

            tvItemModelParentList.Add(tvItemModel);

            CheckDBLocal(tvItemModelParentList);
            CheckLocalJsonFileCreated(tvItemModelParentList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DeleteTVItemLocal_ClimateSite_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            int TVItemID = 7;

            WebClimateSites webClimateSites = await CSSPReadGzFileService.GetUncompressJSON<WebClimateSites>(WebTypeEnum.WebClimateSites, TVItemID);

            TVItem tvItemParent = webClimateSites.TVItemModel.TVItem;

            Assert.NotEmpty(webClimateSites.ClimateSiteModelList);

            TVItemModel tvItemModelExist = webClimateSites.ClimateSiteModelList[0].TVItemModel;

            string TVTextEN = tvItemModelExist.TVItemLanguageList[0].TVText;
            string TVTextFR = tvItemModelExist.TVItemLanguageList[1].TVText;

            var actionTVItemModelExist = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelExist);
            Assert.Equal(400, ((ObjectResult)actionTVItemModelExist.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionTVItemModelExist.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModelExist.Result).Value;
            Assert.NotEmpty(errRes.ErrList);

            Assert.True(await TVItemLocalServiceSetup(culture));

            webClimateSites = await CSSPReadGzFileService.GetUncompressJSON<WebClimateSites>(WebTypeEnum.WebClimateSites, TVItemID);

            tvItemParent = webClimateSites.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.ClimateSite;
            TVTextEN = "New Item";
            TVTextFR = "Nouveau Item";

            var actionTVItemModelAdded = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModelAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModelAdded.Result).Value);
            TVItemModel tvItemModelAdded = (TVItemModel)((OkObjectResult)actionTVItemModelAdded.Result).Value;
            Assert.NotNull(tvItemModelAdded);

            CheckCreatedTVItemAndTVItemLanguageList(tvItemModelAdded, TVTextEN, TVTextFR);

            webClimateSites = await CSSPReadGzFileService.GetUncompressJSON<WebClimateSites>(WebTypeEnum.WebClimateSites, TVItemID);

            var actionTVItemModel = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelAdded);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            CheckDeletedTVItemAndTVItemLanguageList(tvItemModel, TVTextEN, TVTextFR);

            List<TVItemModel> tvItemModelParentList = webClimateSites.TVItemModelParentList;

            tvItemModelParentList.Add(tvItemModel);

            CheckDBLocal(tvItemModelParentList);
            CheckLocalJsonFileCreated(tvItemModelParentList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DeleteTVItemLocal_HydrometricSite_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            int TVItemID = 7;

            WebHydrometricSites webHydrometricSites = await CSSPReadGzFileService.GetUncompressJSON<WebHydrometricSites>(WebTypeEnum.WebHydrometricSites, TVItemID);

            TVItem tvItemParent = webHydrometricSites.TVItemModel.TVItem;

            Assert.NotEmpty(webHydrometricSites.HydrometricSiteModelList);

            TVItemModel tvItemModelExist = webHydrometricSites.HydrometricSiteModelList[0].TVItemModel;

            string TVTextEN = tvItemModelExist.TVItemLanguageList[0].TVText;
            string TVTextFR = tvItemModelExist.TVItemLanguageList[1].TVText;

            var actionTVItemModelExist = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelExist);
            Assert.Equal(400, ((ObjectResult)actionTVItemModelExist.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionTVItemModelExist.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModelExist.Result).Value;
            Assert.NotEmpty(errRes.ErrList);

            Assert.True(await TVItemLocalServiceSetup(culture));

            webHydrometricSites = await CSSPReadGzFileService.GetUncompressJSON<WebHydrometricSites>(WebTypeEnum.WebHydrometricSites, TVItemID);

            tvItemParent = webHydrometricSites.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.HydrometricSite;
            TVTextEN = "New Item";
            TVTextFR = "Nouveau Item";

            var actionTVItemModelAdded = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModelAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModelAdded.Result).Value);
            TVItemModel tvItemModelAdded = (TVItemModel)((OkObjectResult)actionTVItemModelAdded.Result).Value;
            Assert.NotNull(tvItemModelAdded);

            CheckCreatedTVItemAndTVItemLanguageList(tvItemModelAdded, TVTextEN, TVTextFR);

            webHydrometricSites = await CSSPReadGzFileService.GetUncompressJSON<WebHydrometricSites>(WebTypeEnum.WebHydrometricSites, TVItemID);

            var actionTVItemModel = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelAdded);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            CheckDeletedTVItemAndTVItemLanguageList(tvItemModel, TVTextEN, TVTextFR);

            List<TVItemModel> tvItemModelParentList = webHydrometricSites.TVItemModelParentList;

            tvItemModelParentList.Add(tvItemModel);

            CheckDBLocal(tvItemModelParentList);
            CheckLocalJsonFileCreated(tvItemModelParentList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DeleteTVItemLocal_TideSite_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            int TVItemID = 7;

            WebTideSites webTideSites = await CSSPReadGzFileService.GetUncompressJSON<WebTideSites>(WebTypeEnum.WebTideSites, TVItemID);

            TVItem tvItemParent = webTideSites.TVItemModel.TVItem;

            Assert.NotEmpty(webTideSites.TideSiteModelList);

            TVItemModel tvItemModelExist = webTideSites.TideSiteModelList[0].TVItemModel;

            string TVTextEN = tvItemModelExist.TVItemLanguageList[0].TVText;
            string TVTextFR = tvItemModelExist.TVItemLanguageList[1].TVText;

            var actionTVItemModelExist = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelExist);
            Assert.Equal(400, ((ObjectResult)actionTVItemModelExist.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionTVItemModelExist.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModelExist.Result).Value;
            Assert.NotEmpty(errRes.ErrList);

            Assert.True(await TVItemLocalServiceSetup(culture));

            webTideSites = await CSSPReadGzFileService.GetUncompressJSON<WebTideSites>(WebTypeEnum.WebTideSites, TVItemID);

            tvItemParent = webTideSites.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.TideSite;
            TVTextEN = "New Item";
            TVTextFR = "Nouveau Item";

            var actionTVItemModelAdded = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModelAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModelAdded.Result).Value);
            TVItemModel tvItemModelAdded = (TVItemModel)((OkObjectResult)actionTVItemModelAdded.Result).Value;
            Assert.NotNull(tvItemModelAdded);

            CheckCreatedTVItemAndTVItemLanguageList(tvItemModelAdded, TVTextEN, TVTextFR);

            webTideSites = await CSSPReadGzFileService.GetUncompressJSON<WebTideSites>(WebTypeEnum.WebTideSites, TVItemID);

            var actionTVItemModel = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelAdded);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            CheckDeletedTVItemAndTVItemLanguageList(tvItemModel, TVTextEN, TVTextFR);

            List<TVItemModel> tvItemModelParentList = webTideSites.TVItemModelParentList;

            tvItemModelParentList.Add(tvItemModel);

            CheckDBLocal(tvItemModelParentList);
            CheckLocalJsonFileCreated(tvItemModelParentList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DeleteTVItemLocal_Infrastructure_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            int TVItemID = 27764;

            WebMunicipality webMunicipality = await CSSPReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, TVItemID);

            TVItem tvItemParent = webMunicipality.TVItemModel.TVItem;

            Assert.NotEmpty(webMunicipality.InfrastructureModelList);

            TVItemModel tvItemModelExist = webMunicipality.InfrastructureModelList[0].TVItemModel;

            string TVTextEN = tvItemModelExist.TVItemLanguageList[0].TVText;
            string TVTextFR = tvItemModelExist.TVItemLanguageList[1].TVText;

            var actionTVItemModelExist = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelExist);
            Assert.Equal(400, ((ObjectResult)actionTVItemModelExist.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionTVItemModelExist.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModelExist.Result).Value;
            Assert.NotEmpty(errRes.ErrList);

            Assert.True(await TVItemLocalServiceSetup(culture));

            webMunicipality = await CSSPReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, TVItemID);

            tvItemParent = webMunicipality.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.Infrastructure;
            TVTextEN = "New Item";
            TVTextFR = "Nouveau Item";

            var actionTVItemModelAdded = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModelAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModelAdded.Result).Value);
            TVItemModel tvItemModelAdded = (TVItemModel)((OkObjectResult)actionTVItemModelAdded.Result).Value;
            Assert.NotNull(tvItemModelAdded);

            CheckCreatedTVItemAndTVItemLanguageList(tvItemModelAdded, TVTextEN, TVTextFR);

            webMunicipality = await CSSPReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, TVItemID);

            var actionTVItemModel = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelAdded);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            CheckDeletedTVItemAndTVItemLanguageList(tvItemModel, TVTextEN, TVTextFR);

            List<TVItemModel> tvItemModelParentList = webMunicipality.TVItemModelParentList;

            tvItemModelParentList.Add(tvItemModel);

            CheckDBLocal(tvItemModelParentList);
            CheckLocalJsonFileCreated(tvItemModelParentList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DeleteTVItemLocal_MikeScenario_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            int TVItemID = 27764;

            WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, TVItemID);

            TVItem tvItemParent = webMikeScenarios.TVItemModel.TVItem;

            Assert.NotEmpty(webMikeScenarios.MikeScenarioModelList);

            TVItemModel tvItemModelExist = webMikeScenarios.MikeScenarioModelList[0].TVItemModel;

            string TVTextEN = tvItemModelExist.TVItemLanguageList[0].TVText;
            string TVTextFR = tvItemModelExist.TVItemLanguageList[1].TVText;

            var actionTVItemModelExist = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelExist);
            Assert.Equal(400, ((ObjectResult)actionTVItemModelExist.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionTVItemModelExist.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModelExist.Result).Value;
            Assert.NotEmpty(errRes.ErrList);

            Assert.True(await TVItemLocalServiceSetup(culture));

            webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, TVItemID);

            tvItemParent = webMikeScenarios.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.MikeScenario;
            TVTextEN = "New Item";
            TVTextFR = "Nouveau Item";

            var actionTVItemModelAdded = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModelAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModelAdded.Result).Value);
            TVItemModel tvItemModelAdded = (TVItemModel)((OkObjectResult)actionTVItemModelAdded.Result).Value;
            Assert.NotNull(tvItemModelAdded);

            CheckCreatedTVItemAndTVItemLanguageList(tvItemModelAdded, TVTextEN, TVTextFR);

            webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, TVItemID);

            var actionTVItemModel = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelAdded);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            CheckDeletedTVItemAndTVItemLanguageList(tvItemModel, TVTextEN, TVTextFR);

            List<TVItemModel> tvItemModelParentList = webMikeScenarios.TVItemModelParentList;

            tvItemModelParentList.Add(tvItemModel);

            CheckDBLocal(tvItemModelParentList);
            CheckLocalJsonFileCreated(tvItemModelParentList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DeleteTVItemLocal_MikeSource_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            int TVItemID = 27764;

            WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, TVItemID);

            TVItem tvItemParent = webMikeScenarios.TVItemModel.TVItem;

            Assert.NotEmpty(webMikeScenarios.MikeScenarioModelList);

            MikeScenarioModel mikeScenarioModel = webMikeScenarios.MikeScenarioModelList[0];
            Assert.NotNull(mikeScenarioModel);

            Assert.NotEmpty(mikeScenarioModel.MikeSourceModelList);

            TVItemModel tvItemModelExist = mikeScenarioModel.MikeSourceModelList[0].TVItemModel;

            tvItemParent = mikeScenarioModel.TVItemModel.TVItem;

            string TVTextEN = tvItemModelExist.TVItemLanguageList[0].TVText;
            string TVTextFR = tvItemModelExist.TVItemLanguageList[1].TVText;

            var actionTVItemModelExist = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelExist);
            Assert.Equal(400, ((ObjectResult)actionTVItemModelExist.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionTVItemModelExist.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModelExist.Result).Value;
            Assert.NotEmpty(errRes.ErrList);

            Assert.True(await TVItemLocalServiceSetup(culture));

            webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, TVItemID);

            tvItemParent = webMikeScenarios.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.MikeSource;
            TVTextEN = "New Item";
            TVTextFR = "Nouveau Item";

            tvItemParent = mikeScenarioModel.TVItemModel.TVItem;

            var actionTVItemModelAdded = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModelAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModelAdded.Result).Value);
            TVItemModel tvItemModelAdded = (TVItemModel)((OkObjectResult)actionTVItemModelAdded.Result).Value;
            Assert.NotNull(tvItemModelAdded);

            CheckCreatedTVItemAndTVItemLanguageList(tvItemModelAdded, TVTextEN, TVTextFR);

            webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, TVItemID);

            var actionTVItemModel = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelAdded);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            CheckDeletedTVItemAndTVItemLanguageList(tvItemModel, TVTextEN, TVTextFR);

            List<TVItemModel> tvItemModelParentList = webMikeScenarios.TVItemModelParentList;

            tvItemModelParentList.Add(mikeScenarioModel.TVItemModel);
            tvItemModelParentList.Add(tvItemModel);

            CheckDBLocal(tvItemModelParentList);
            CheckLocalJsonFileCreated(tvItemModelParentList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DeleteTVItemLocal_MikeBoundaryConditionMesh_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            int TVItemID = 27764;

            WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, TVItemID);

            TVItem tvItemParent = webMikeScenarios.TVItemModel.TVItem;

            Assert.NotEmpty(webMikeScenarios.MikeScenarioModelList);

            MikeScenarioModel mikeScenarioModel = webMikeScenarios.MikeScenarioModelList[0];
            Assert.NotNull(mikeScenarioModel);

            Assert.NotEmpty(mikeScenarioModel.MikeBoundaryConditionModelList.Where(c => c.TVItemModel.TVItem.TVType == TVTypeEnum.MikeBoundaryConditionMesh));

            TVItemModel tvItemModelExist = mikeScenarioModel.MikeBoundaryConditionModelList.Where(c => c.TVItemModel.TVItem.TVType == TVTypeEnum.MikeBoundaryConditionMesh).ToList()[0].TVItemModel;

            tvItemParent = mikeScenarioModel.TVItemModel.TVItem;

            string TVTextEN = tvItemModelExist.TVItemLanguageList[0].TVText;
            string TVTextFR = tvItemModelExist.TVItemLanguageList[1].TVText;

            var actionTVItemModelExist = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelExist);
            Assert.Equal(400, ((ObjectResult)actionTVItemModelExist.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionTVItemModelExist.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModelExist.Result).Value;
            Assert.NotEmpty(errRes.ErrList);

            Assert.True(await TVItemLocalServiceSetup(culture));

            webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, TVItemID);

            tvItemParent = webMikeScenarios.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.MikeBoundaryConditionMesh;
            TVTextEN = "New Item";
            TVTextFR = "Nouveau Item";

            tvItemParent = mikeScenarioModel.TVItemModel.TVItem;

            var actionTVItemModelAdded = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModelAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModelAdded.Result).Value);
            TVItemModel tvItemModelAdded = (TVItemModel)((OkObjectResult)actionTVItemModelAdded.Result).Value;
            Assert.NotNull(tvItemModelAdded);

            CheckCreatedTVItemAndTVItemLanguageList(tvItemModelAdded, TVTextEN, TVTextFR);

            webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, TVItemID);

            var actionTVItemModel = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelAdded);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            CheckDeletedTVItemAndTVItemLanguageList(tvItemModel, TVTextEN, TVTextFR);

            List<TVItemModel> tvItemModelParentList = webMikeScenarios.TVItemModelParentList;

            tvItemModelParentList.Add(mikeScenarioModel.TVItemModel);
            tvItemModelParentList.Add(tvItemModel);

            CheckDBLocal(tvItemModelParentList);
            CheckLocalJsonFileCreated(tvItemModelParentList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DeleteTVItemLocal_MikeBoundaryConditionWebTide_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            int TVItemID = 27764;

            WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, TVItemID);

            TVItem tvItemParent = webMikeScenarios.TVItemModel.TVItem;

            Assert.NotEmpty(webMikeScenarios.MikeScenarioModelList);

            MikeScenarioModel mikeScenarioModel = webMikeScenarios.MikeScenarioModelList[0];
            Assert.NotNull(mikeScenarioModel);

            Assert.NotEmpty(mikeScenarioModel.MikeBoundaryConditionModelList.Where(c => c.TVItemModel.TVItem.TVType == TVTypeEnum.MikeBoundaryConditionWebTide));

            TVItemModel tvItemModelExist = mikeScenarioModel.MikeBoundaryConditionModelList.Where(c => c.TVItemModel.TVItem.TVType == TVTypeEnum.MikeBoundaryConditionWebTide).ToList()[0].TVItemModel;

            tvItemParent = mikeScenarioModel.TVItemModel.TVItem;

            string TVTextEN = tvItemModelExist.TVItemLanguageList[0].TVText;
            string TVTextFR = tvItemModelExist.TVItemLanguageList[1].TVText;

            var actionTVItemModelExist = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelExist);
            Assert.Equal(400, ((ObjectResult)actionTVItemModelExist.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionTVItemModelExist.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModelExist.Result).Value;
            Assert.NotEmpty(errRes.ErrList);

            Assert.True(await TVItemLocalServiceSetup(culture));

            webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, TVItemID);

            tvItemParent = webMikeScenarios.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.MikeBoundaryConditionWebTide;
            TVTextEN = "New Item";
            TVTextFR = "Nouveau Item";

            tvItemParent = mikeScenarioModel.TVItemModel.TVItem;

            var actionTVItemModelAdded = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModelAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModelAdded.Result).Value);
            TVItemModel tvItemModelAdded = (TVItemModel)((OkObjectResult)actionTVItemModelAdded.Result).Value;
            Assert.NotNull(tvItemModelAdded);

            CheckCreatedTVItemAndTVItemLanguageList(tvItemModelAdded, TVTextEN, TVTextFR);

            webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, TVItemID);

            var actionTVItemModel = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelAdded);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            CheckDeletedTVItemAndTVItemLanguageList(tvItemModel, TVTextEN, TVTextFR);

            List<TVItemModel> tvItemModelParentList = webMikeScenarios.TVItemModelParentList;

            tvItemModelParentList.Add(mikeScenarioModel.TVItemModel);
            tvItemModelParentList.Add(tvItemModel);

            CheckDBLocal(tvItemModelParentList);
            CheckLocalJsonFileCreated(tvItemModelParentList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DeleteTVItemLocal_Sector_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            int TVItemID = 629;

            WebArea webArea = await CSSPReadGzFileService.GetUncompressJSON<WebArea>(WebTypeEnum.WebArea, TVItemID);

            TVItem tvItemParent = webArea.TVItemModel.TVItem;

            Assert.NotEmpty(webArea.TVItemModelSectorList);

            TVItemModel tvItemModelExist = webArea.TVItemModelSectorList[0];

            string TVTextEN = tvItemModelExist.TVItemLanguageList[0].TVText;
            string TVTextFR = tvItemModelExist.TVItemLanguageList[1].TVText;

            var actionTVItemModelExist = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelExist);
            Assert.Equal(400, ((ObjectResult)actionTVItemModelExist.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionTVItemModelExist.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModelExist.Result).Value;
            Assert.NotEmpty(errRes.ErrList);

            Assert.True(await TVItemLocalServiceSetup(culture));

            webArea = await CSSPReadGzFileService.GetUncompressJSON<WebArea>(WebTypeEnum.WebArea, TVItemID);

            tvItemParent = webArea.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.Sector;
            TVTextEN = "New Item";
            TVTextFR = "Nouveau Item";

            var actionTVItemModelAdded = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModelAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModelAdded.Result).Value);
            TVItemModel tvItemModelAdded = (TVItemModel)((OkObjectResult)actionTVItemModelAdded.Result).Value;
            Assert.NotNull(tvItemModelAdded);

            CheckCreatedTVItemAndTVItemLanguageList(tvItemModelAdded, TVTextEN, TVTextFR);

            webArea = await CSSPReadGzFileService.GetUncompressJSON<WebArea>(WebTypeEnum.WebArea, TVItemID);

            var actionTVItemModel = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelAdded);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            CheckDeletedTVItemAndTVItemLanguageList(tvItemModel, TVTextEN, TVTextFR);

            List<TVItemModel> tvItemModelParentList = webArea.TVItemModelParentList;

            tvItemModelParentList.Add(tvItemModel);

            CheckDBLocal(tvItemModelParentList);
            CheckLocalJsonFileCreated(tvItemModelParentList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DeleteTVItemLocal_Subsector_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            int TVItemID = 633;

            WebSector webSector = await CSSPReadGzFileService.GetUncompressJSON<WebSector>(WebTypeEnum.WebSector, TVItemID);

            TVItem tvItemParent = webSector.TVItemModel.TVItem;

            Assert.NotEmpty(webSector.TVItemModelSubsectorList);

            TVItemModel tvItemModelExist = webSector.TVItemModelSubsectorList[0];

            string TVTextEN = tvItemModelExist.TVItemLanguageList[0].TVText;
            string TVTextFR = tvItemModelExist.TVItemLanguageList[1].TVText;

            var actionTVItemModelExist = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelExist);
            Assert.Equal(400, ((ObjectResult)actionTVItemModelExist.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionTVItemModelExist.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModelExist.Result).Value;
            Assert.NotEmpty(errRes.ErrList);

            Assert.True(await TVItemLocalServiceSetup(culture));

            webSector = await CSSPReadGzFileService.GetUncompressJSON<WebSector>(WebTypeEnum.WebSector, TVItemID);

            tvItemParent = webSector.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.Subsector;
            TVTextEN = "New Item";
            TVTextFR = "Nouveau Item";

            var actionTVItemModelAdded = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModelAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModelAdded.Result).Value);
            TVItemModel tvItemModelAdded = (TVItemModel)((OkObjectResult)actionTVItemModelAdded.Result).Value;
            Assert.NotNull(tvItemModelAdded);

            CheckCreatedTVItemAndTVItemLanguageList(tvItemModelAdded, TVTextEN, TVTextFR);

            webSector = await CSSPReadGzFileService.GetUncompressJSON<WebSector>(WebTypeEnum.WebSector, TVItemID);

            var actionTVItemModel = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelAdded);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            CheckDeletedTVItemAndTVItemLanguageList(tvItemModel, TVTextEN, TVTextFR);

            List<TVItemModel> tvItemModelParentList = webSector.TVItemModelParentList;

            tvItemModelParentList.Add(tvItemModel);

            CheckDBLocal(tvItemModelParentList);
            CheckLocalJsonFileCreated(tvItemModelParentList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DeleteTVItemLocal_MWQMRun_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            int TVItemID = 635;

            WebMWQMRuns webMWQMRuns = await CSSPReadGzFileService.GetUncompressJSON<WebMWQMRuns>(WebTypeEnum.WebMWQMRuns, TVItemID);

            TVItem tvItemParent = webMWQMRuns.TVItemModel.TVItem;

            Assert.NotEmpty(webMWQMRuns.MWQMRunModelList);

            TVItemModel tvItemModelExist = webMWQMRuns.MWQMRunModelList[0].TVItemModel;

            string TVTextEN = tvItemModelExist.TVItemLanguageList[0].TVText;
            string TVTextFR = tvItemModelExist.TVItemLanguageList[1].TVText;

            var actionTVItemModelExist = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelExist);
            Assert.Equal(400, ((ObjectResult)actionTVItemModelExist.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionTVItemModelExist.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModelExist.Result).Value;
            Assert.NotEmpty(errRes.ErrList);

            Assert.True(await TVItemLocalServiceSetup(culture));

            webMWQMRuns = await CSSPReadGzFileService.GetUncompressJSON<WebMWQMRuns>(WebTypeEnum.WebMWQMRuns, TVItemID);

            tvItemParent = webMWQMRuns.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.MWQMRun;
            TVTextEN = "New Item";
            TVTextFR = "Nouveau Item";

            var actionTVItemModelAdded = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModelAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModelAdded.Result).Value);
            TVItemModel tvItemModelAdded = (TVItemModel)((OkObjectResult)actionTVItemModelAdded.Result).Value;
            Assert.NotNull(tvItemModelAdded);

            CheckCreatedTVItemAndTVItemLanguageList(tvItemModelAdded, TVTextEN, TVTextFR);

            webMWQMRuns = await CSSPReadGzFileService.GetUncompressJSON<WebMWQMRuns>(WebTypeEnum.WebMWQMRuns, TVItemID);

            var actionTVItemModel = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelAdded);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            CheckDeletedTVItemAndTVItemLanguageList(tvItemModel, TVTextEN, TVTextFR);

            List<TVItemModel> tvItemModelParentList = webMWQMRuns.TVItemModelParentList;

            tvItemModelParentList.Add(tvItemModel);

            CheckDBLocal(tvItemModelParentList);
            CheckLocalJsonFileCreated(tvItemModelParentList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DeleteTVItemLocal_MWQMSite_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            int TVItemID = 635;

            WebMWQMSites webMWQMSites = await CSSPReadGzFileService.GetUncompressJSON<WebMWQMSites>(WebTypeEnum.WebMWQMSites, TVItemID);

            TVItem tvItemParent = webMWQMSites.TVItemModel.TVItem;

            Assert.NotEmpty(webMWQMSites.MWQMSiteModelList);

            TVItemModel tvItemModelExist = webMWQMSites.MWQMSiteModelList[0].TVItemModel;

            string TVTextEN = tvItemModelExist.TVItemLanguageList[0].TVText;
            string TVTextFR = tvItemModelExist.TVItemLanguageList[1].TVText;

            var actionTVItemModelExist = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelExist);
            Assert.Equal(400, ((ObjectResult)actionTVItemModelExist.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionTVItemModelExist.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModelExist.Result).Value;
            Assert.NotEmpty(errRes.ErrList);

            Assert.True(await TVItemLocalServiceSetup(culture));

            webMWQMSites = await CSSPReadGzFileService.GetUncompressJSON<WebMWQMSites>(WebTypeEnum.WebMWQMSites, TVItemID);

            tvItemParent = webMWQMSites.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.MWQMSite;
            TVTextEN = "New Item";
            TVTextFR = "Nouveau Item";

            var actionTVItemModelAdded = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModelAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModelAdded.Result).Value);
            TVItemModel tvItemModelAdded = (TVItemModel)((OkObjectResult)actionTVItemModelAdded.Result).Value;
            Assert.NotNull(tvItemModelAdded);

            CheckCreatedTVItemAndTVItemLanguageList(tvItemModelAdded, TVTextEN, TVTextFR);

            webMWQMSites = await CSSPReadGzFileService.GetUncompressJSON<WebMWQMSites>(WebTypeEnum.WebMWQMSites, TVItemID);

            var actionTVItemModel = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelAdded);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            CheckDeletedTVItemAndTVItemLanguageList(tvItemModel, TVTextEN, TVTextFR);

            List<TVItemModel> tvItemModelParentList = webMWQMSites.TVItemModelParentList;

            tvItemModelParentList.Add(tvItemModel);

            CheckDBLocal(tvItemModelParentList);
            CheckLocalJsonFileCreated(tvItemModelParentList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DeleteTVItemLocal_PolSourceSite_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            int TVItemID = 635;

            WebPolSourceSites webPolSourceSites = await CSSPReadGzFileService.GetUncompressJSON<WebPolSourceSites>(WebTypeEnum.WebPolSourceSites, TVItemID);

            TVItem tvItemParent = webPolSourceSites.TVItemModel.TVItem;

            Assert.NotEmpty(webPolSourceSites.PolSourceSiteModelList);

            TVItemModel tvItemModelExist = webPolSourceSites.PolSourceSiteModelList[0].TVItemModel;

            string TVTextEN = tvItemModelExist.TVItemLanguageList[0].TVText;
            string TVTextFR = tvItemModelExist.TVItemLanguageList[1].TVText;

            var actionTVItemModelExist = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelExist);
            Assert.Equal(400, ((ObjectResult)actionTVItemModelExist.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionTVItemModelExist.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModelExist.Result).Value;
            Assert.NotEmpty(errRes.ErrList);

            Assert.True(await TVItemLocalServiceSetup(culture));

            webPolSourceSites = await CSSPReadGzFileService.GetUncompressJSON<WebPolSourceSites>(WebTypeEnum.WebPolSourceSites, TVItemID);

            tvItemParent = webPolSourceSites.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.PolSourceSite;
            TVTextEN = "New Item";
            TVTextFR = "Nouveau Item";

            var actionTVItemModelAdded = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModelAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModelAdded.Result).Value);
            TVItemModel tvItemModelAdded = (TVItemModel)((OkObjectResult)actionTVItemModelAdded.Result).Value;
            Assert.NotNull(tvItemModelAdded);

            CheckCreatedTVItemAndTVItemLanguageList(tvItemModelAdded, TVTextEN, TVTextFR);

            webPolSourceSites = await CSSPReadGzFileService.GetUncompressJSON<WebPolSourceSites>(WebTypeEnum.WebPolSourceSites, TVItemID);

            var actionTVItemModel = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelAdded);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            CheckDeletedTVItemAndTVItemLanguageList(tvItemModel, TVTextEN, TVTextFR);

            List<TVItemModel> tvItemModelParentList = webPolSourceSites.TVItemModelParentList;

            tvItemModelParentList.Add(tvItemModel);

            CheckDBLocal(tvItemModelParentList);
            CheckLocalJsonFileCreated(tvItemModelParentList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DeleteTVItemLocal_Classification_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            int TVItemID = 635;

            WebSubsector webSubsector = await CSSPReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, TVItemID);

            TVItem tvItemParent = webSubsector.TVItemModel.TVItem;

            Assert.NotEmpty(webSubsector.TVItemModelClassificationList);

            TVItemModel tvItemModelExist = webSubsector.TVItemModelClassificationList[0];

            string TVTextEN = tvItemModelExist.TVItemLanguageList[0].TVText;
            string TVTextFR = tvItemModelExist.TVItemLanguageList[1].TVText;

            webSubsector = await CSSPReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, TVItemID);

            tvItemParent = webSubsector.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.Classification;
            TVTextEN = "New Item";
            TVTextFR = "Nouveau Item";

            var actionTVItemModelAdded = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModelAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModelAdded.Result).Value);
            TVItemModel tvItemModelAdded = (TVItemModel)((OkObjectResult)actionTVItemModelAdded.Result).Value;
            Assert.NotNull(tvItemModelAdded);

            CheckCreatedTVItemAndTVItemLanguageList(tvItemModelAdded, TVTextEN, TVTextFR);

            webSubsector = await CSSPReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, TVItemID);

            var actionTVItemModel = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelAdded);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            CheckDeletedTVItemAndTVItemLanguageList(tvItemModel, TVTextEN, TVTextFR);

            List<TVItemModel> tvItemModelParentList = webSubsector.TVItemModelParentList;

            tvItemModelParentList.Add(tvItemModel);

            CheckDBLocal(tvItemModelParentList);
            CheckLocalJsonFileCreated(tvItemModelParentList);
        }
    }
}
