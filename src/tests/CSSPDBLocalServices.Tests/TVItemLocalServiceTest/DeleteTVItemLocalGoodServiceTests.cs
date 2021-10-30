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
        public async Task DeleteTVItemLocal_Root_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            // not allowed to delete a Root type
        }
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

            var actionTVItemModelExist = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelExist);
            Assert.Equal(400, ((ObjectResult)actionTVItemModelExist.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionTVItemModelExist.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModelExist.Result).Value;
            Assert.NotEmpty(errRes.ErrList);

            //-----------------------------------------------------------------------------------------

            Assert.True(await TVItemLocalServiceSetup(culture));

            webRoot = await CSSPReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, 0);

            tvItemParent = webRoot.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.Country;
            string TVTextEN = "New Item";
            string TVTextFR = "Nouveau Item";

            var actionTVItemModelAdded = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModelAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModelAdded.Result).Value);
            TVItemModel tvItemModelAdded = (TVItemModel)((OkObjectResult)actionTVItemModelAdded.Result).Value;
            Assert.NotNull(tvItemModelAdded);

            CheckTVItem(tvItemModelAdded, DBCommandEnum.Created);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

            webRoot = await CSSPReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, 0);

            var actionTVItemModel = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelAdded);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            CheckTVItem(tvItemModel, DBCommandEnum.Deleted);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Deleted, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Deleted, TVTextFR, LanguageEnum.fr);

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

            var actionTVItemModelExist = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelExist);
            Assert.Equal(400, ((ObjectResult)actionTVItemModelExist.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionTVItemModelExist.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModelExist.Result).Value;
            Assert.NotEmpty(errRes.ErrList);

            //-----------------------------------------------------------------------------------------

            Assert.True(await TVItemLocalServiceSetup(culture));

            webCountry = await CSSPReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, TVItemID);

            tvItemParent = webCountry.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.Province;
            string TVTextEN = "New Item";
            string TVTextFR = "Nouveau Item";

            var actionTVItemModelAdded = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModelAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModelAdded.Result).Value);
            TVItemModel tvItemModelAdded = (TVItemModel)((OkObjectResult)actionTVItemModelAdded.Result).Value;
            Assert.NotNull(tvItemModelAdded);

            CheckTVItem(tvItemModelAdded, DBCommandEnum.Created);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

            webCountry = await CSSPReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, TVItemID);

            var actionTVItemModel = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelAdded);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            CheckTVItem(tvItemModel, DBCommandEnum.Deleted);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Deleted, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Deleted, TVTextFR, LanguageEnum.fr);

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

            var actionTVItemModelExist = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelExist);
            Assert.Equal(400, ((ObjectResult)actionTVItemModelExist.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionTVItemModelExist.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModelExist.Result).Value;
            Assert.NotEmpty(errRes.ErrList);

            //-----------------------------------------------------------------------------------------

            Assert.True(await TVItemLocalServiceSetup(culture));

            webCountry = await CSSPReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, TVItemID);

            tvItemParent = webCountry.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.RainExceedance;
            string TVTextEN = "New Item";
            string TVTextFR = "Nouveau Item";

            var actionTVItemModelAdded = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModelAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModelAdded.Result).Value);
            TVItemModel tvItemModelAdded = (TVItemModel)((OkObjectResult)actionTVItemModelAdded.Result).Value;
            Assert.NotNull(tvItemModelAdded);

            CheckTVItem(tvItemModelAdded, DBCommandEnum.Created);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

            webCountry = await CSSPReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, TVItemID);

            tvItemParent = tvItemModelAdded.TVItem;

            var actionTVItemModel = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelAdded);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            CheckTVItem(tvItemModel, DBCommandEnum.Deleted);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Deleted, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Deleted, TVTextFR, LanguageEnum.fr);

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

            CheckTVItem(tvItemModelAdded, DBCommandEnum.Created);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

            webCountry = await CSSPReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, TVItemID);

            tvItemParent = tvItemModelAdded.TVItem;

            var actionTVItemModel = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelAdded);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            CheckTVItem(tvItemModel, DBCommandEnum.Deleted);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Deleted, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Deleted, TVTextFR, LanguageEnum.fr);

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

            var actionTVItemModelExist = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelExist);
            Assert.Equal(400, ((ObjectResult)actionTVItemModelExist.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionTVItemModelExist.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModelExist.Result).Value;
            Assert.NotEmpty(errRes.ErrList);

            //-----------------------------------------------------------------------------------------

            Assert.True(await TVItemLocalServiceSetup(culture));

            webProvince = await CSSPReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

            tvItemParent = webProvince.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.Area;
            string TVTextEN = "New Item";
            string TVTextFR = "Nouveau Item";

            var actionTVItemModelAdded = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModelAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModelAdded.Result).Value);
            TVItemModel tvItemModelAdded = (TVItemModel)((OkObjectResult)actionTVItemModelAdded.Result).Value;
            Assert.NotNull(tvItemModelAdded);

            CheckTVItem(tvItemModelAdded, DBCommandEnum.Created);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

            webProvince = await CSSPReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

            var actionTVItemModel = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelAdded);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            CheckTVItem(tvItemModel, DBCommandEnum.Deleted);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Deleted, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Deleted, TVTextFR, LanguageEnum.fr);

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

            CheckTVItem(tvItemModelAdded, DBCommandEnum.Created);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

            webProvince = await CSSPReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

            var actionTVItemModel = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelAdded);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            CheckTVItem(tvItemModel, DBCommandEnum.Deleted);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Deleted, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Deleted, TVTextFR, LanguageEnum.fr);

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

            var actionTVItemModelExist = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelExist);
            Assert.Equal(400, ((ObjectResult)actionTVItemModelExist.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionTVItemModelExist.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModelExist.Result).Value;
            Assert.NotEmpty(errRes.ErrList);

            //-----------------------------------------------------------------------------------------

            Assert.True(await TVItemLocalServiceSetup(culture));

            webProvince = await CSSPReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

            tvItemParent = webProvince.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.Municipality;
            string TVTextEN = "New Item";
            string TVTextFR = "Nouveau Item";

            var actionTVItemModelAdded = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModelAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModelAdded.Result).Value);
            TVItemModel tvItemModelAdded = (TVItemModel)((OkObjectResult)actionTVItemModelAdded.Result).Value;
            Assert.NotNull(tvItemModelAdded);

            CheckTVItem(tvItemModelAdded, DBCommandEnum.Created);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

            webProvince = await CSSPReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

            var actionTVItemModel = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelAdded);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            CheckTVItem(tvItemModel, DBCommandEnum.Deleted);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Deleted, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Deleted, TVTextFR, LanguageEnum.fr);

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

            var actionTVItemModelExist = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelExist);
            Assert.Equal(400, ((ObjectResult)actionTVItemModelExist.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionTVItemModelExist.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModelExist.Result).Value;
            Assert.NotEmpty(errRes.ErrList);

            //-----------------------------------------------------------------------------------------

            Assert.True(await TVItemLocalServiceSetup(culture));

            webClimateSites = await CSSPReadGzFileService.GetUncompressJSON<WebClimateSites>(WebTypeEnum.WebClimateSites, TVItemID);

            tvItemParent = webClimateSites.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.ClimateSite;
            string TVTextEN = "New Item";
            string TVTextFR = "Nouveau Item";

            var actionTVItemModelAdded = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModelAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModelAdded.Result).Value);
            TVItemModel tvItemModelAdded = (TVItemModel)((OkObjectResult)actionTVItemModelAdded.Result).Value;
            Assert.NotNull(tvItemModelAdded);

            CheckTVItem(tvItemModelAdded, DBCommandEnum.Created);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

            webClimateSites = await CSSPReadGzFileService.GetUncompressJSON<WebClimateSites>(WebTypeEnum.WebClimateSites, TVItemID);

            var actionTVItemModel = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelAdded);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            CheckTVItem(tvItemModel, DBCommandEnum.Deleted);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Deleted, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Deleted, TVTextFR, LanguageEnum.fr);

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

            var actionTVItemModelExist = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelExist);
            Assert.Equal(400, ((ObjectResult)actionTVItemModelExist.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionTVItemModelExist.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModelExist.Result).Value;
            Assert.NotEmpty(errRes.ErrList);

            //-----------------------------------------------------------------------------------------

            Assert.True(await TVItemLocalServiceSetup(culture));

            webHydrometricSites = await CSSPReadGzFileService.GetUncompressJSON<WebHydrometricSites>(WebTypeEnum.WebHydrometricSites, TVItemID);

            tvItemParent = webHydrometricSites.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.HydrometricSite;
            string TVTextEN = "New Item";
            string TVTextFR = "Nouveau Item";

            var actionTVItemModelAdded = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModelAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModelAdded.Result).Value);
            TVItemModel tvItemModelAdded = (TVItemModel)((OkObjectResult)actionTVItemModelAdded.Result).Value;
            Assert.NotNull(tvItemModelAdded);

            CheckTVItem(tvItemModelAdded, DBCommandEnum.Created);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

            webHydrometricSites = await CSSPReadGzFileService.GetUncompressJSON<WebHydrometricSites>(WebTypeEnum.WebHydrometricSites, TVItemID);

            var actionTVItemModel = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelAdded);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            CheckTVItem(tvItemModel, DBCommandEnum.Deleted);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Deleted, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Deleted, TVTextFR, LanguageEnum.fr);

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

            var actionTVItemModelExist = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelExist);
            Assert.Equal(400, ((ObjectResult)actionTVItemModelExist.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionTVItemModelExist.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModelExist.Result).Value;
            Assert.NotEmpty(errRes.ErrList);

            //-----------------------------------------------------------------------------------------

            Assert.True(await TVItemLocalServiceSetup(culture));

            webTideSites = await CSSPReadGzFileService.GetUncompressJSON<WebTideSites>(WebTypeEnum.WebTideSites, TVItemID);

            tvItemParent = webTideSites.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.TideSite;
            string TVTextEN = "New Item";
            string TVTextFR = "Nouveau Item";

            var actionTVItemModelAdded = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModelAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModelAdded.Result).Value);
            TVItemModel tvItemModelAdded = (TVItemModel)((OkObjectResult)actionTVItemModelAdded.Result).Value;
            Assert.NotNull(tvItemModelAdded);

            CheckTVItem(tvItemModelAdded, DBCommandEnum.Created);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

            webTideSites = await CSSPReadGzFileService.GetUncompressJSON<WebTideSites>(WebTypeEnum.WebTideSites, TVItemID);

            var actionTVItemModel = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelAdded);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            CheckTVItem(tvItemModel, DBCommandEnum.Deleted);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Deleted, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Deleted, TVTextFR, LanguageEnum.fr);

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

            var actionTVItemModelExist = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelExist);
            Assert.Equal(400, ((ObjectResult)actionTVItemModelExist.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionTVItemModelExist.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModelExist.Result).Value;
            Assert.NotEmpty(errRes.ErrList);

            //-----------------------------------------------------------------------------------------

            Assert.True(await TVItemLocalServiceSetup(culture));

            webMunicipality = await CSSPReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, TVItemID);

            tvItemParent = webMunicipality.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.Infrastructure;
            string TVTextEN = "New Item";
            string TVTextFR = "Nouveau Item";

            var actionTVItemModelAdded = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModelAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModelAdded.Result).Value);
            TVItemModel tvItemModelAdded = (TVItemModel)((OkObjectResult)actionTVItemModelAdded.Result).Value;
            Assert.NotNull(tvItemModelAdded);

            CheckTVItem(tvItemModelAdded, DBCommandEnum.Created);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

            webMunicipality = await CSSPReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, TVItemID);

            var actionTVItemModel = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelAdded);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            CheckTVItem(tvItemModel, DBCommandEnum.Deleted);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Deleted, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Deleted, TVTextFR, LanguageEnum.fr);

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

            var actionTVItemModelExist = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelExist);
            Assert.Equal(400, ((ObjectResult)actionTVItemModelExist.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionTVItemModelExist.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModelExist.Result).Value;
            Assert.NotEmpty(errRes.ErrList);

            //-----------------------------------------------------------------------------------------

            Assert.True(await TVItemLocalServiceSetup(culture));

            webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, TVItemID);

            tvItemParent = webMikeScenarios.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.MikeScenario;
            string TVTextEN = "New Item";
            string TVTextFR = "Nouveau Item";

            var actionTVItemModelAdded = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModelAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModelAdded.Result).Value);
            TVItemModel tvItemModelAdded = (TVItemModel)((OkObjectResult)actionTVItemModelAdded.Result).Value;
            Assert.NotNull(tvItemModelAdded);

            CheckTVItem(tvItemModelAdded, DBCommandEnum.Created);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

            webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, TVItemID);

            var actionTVItemModel = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelAdded);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            CheckTVItem(tvItemModel, DBCommandEnum.Deleted);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Deleted, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Deleted, TVTextFR, LanguageEnum.fr);

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

            var actionTVItemModelExist = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelExist);
            Assert.Equal(400, ((ObjectResult)actionTVItemModelExist.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionTVItemModelExist.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModelExist.Result).Value;
            Assert.NotEmpty(errRes.ErrList);

            //-----------------------------------------------------------------------------------------

            Assert.True(await TVItemLocalServiceSetup(culture));

            webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, TVItemID);

            tvItemParent = webMikeScenarios.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.MikeSource;
            string TVTextEN = "New Item";
            string TVTextFR = "Nouveau Item";

            tvItemParent = mikeScenarioModel.TVItemModel.TVItem;

            var actionTVItemModelAdded = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModelAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModelAdded.Result).Value);
            TVItemModel tvItemModelAdded = (TVItemModel)((OkObjectResult)actionTVItemModelAdded.Result).Value;
            Assert.NotNull(tvItemModelAdded);

            CheckTVItem(tvItemModelAdded, DBCommandEnum.Created);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

            webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, TVItemID);

            var actionTVItemModel = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelAdded);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            CheckTVItem(tvItemModel, DBCommandEnum.Deleted);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Deleted, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Deleted, TVTextFR, LanguageEnum.fr);

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

            var actionTVItemModelExist = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelExist);
            Assert.Equal(400, ((ObjectResult)actionTVItemModelExist.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionTVItemModelExist.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModelExist.Result).Value;
            Assert.NotEmpty(errRes.ErrList);

            //-----------------------------------------------------------------------------------------

            Assert.True(await TVItemLocalServiceSetup(culture));

            webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, TVItemID);

            tvItemParent = webMikeScenarios.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.MikeBoundaryConditionMesh;
            string TVTextEN = "New Item";
            string TVTextFR = "Nouveau Item";

            tvItemParent = mikeScenarioModel.TVItemModel.TVItem;

            var actionTVItemModelAdded = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModelAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModelAdded.Result).Value);
            TVItemModel tvItemModelAdded = (TVItemModel)((OkObjectResult)actionTVItemModelAdded.Result).Value;
            Assert.NotNull(tvItemModelAdded);

            CheckTVItem(tvItemModelAdded, DBCommandEnum.Created);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

            webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, TVItemID);

            var actionTVItemModel = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelAdded);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            CheckTVItem(tvItemModel, DBCommandEnum.Deleted);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Deleted, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Deleted, TVTextFR, LanguageEnum.fr);

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

            var actionTVItemModelExist = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelExist);
            Assert.Equal(400, ((ObjectResult)actionTVItemModelExist.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionTVItemModelExist.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModelExist.Result).Value;
            Assert.NotEmpty(errRes.ErrList);

            //-----------------------------------------------------------------------------------------

            Assert.True(await TVItemLocalServiceSetup(culture));

            webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, TVItemID);

            tvItemParent = webMikeScenarios.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.MikeBoundaryConditionWebTide;
            string TVTextEN = "New Item";
            string TVTextFR = "Nouveau Item";

            tvItemParent = mikeScenarioModel.TVItemModel.TVItem;

            var actionTVItemModelAdded = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModelAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModelAdded.Result).Value);
            TVItemModel tvItemModelAdded = (TVItemModel)((OkObjectResult)actionTVItemModelAdded.Result).Value;
            Assert.NotNull(tvItemModelAdded);

            CheckTVItem(tvItemModelAdded, DBCommandEnum.Created);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

            webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, TVItemID);

            var actionTVItemModel = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelAdded);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            CheckTVItem(tvItemModel, DBCommandEnum.Deleted);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Deleted, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Deleted, TVTextFR, LanguageEnum.fr);

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

            var actionTVItemModelExist = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelExist);
            Assert.Equal(400, ((ObjectResult)actionTVItemModelExist.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionTVItemModelExist.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModelExist.Result).Value;
            Assert.NotEmpty(errRes.ErrList);

            //-----------------------------------------------------------------------------------------

            Assert.True(await TVItemLocalServiceSetup(culture));

            webArea = await CSSPReadGzFileService.GetUncompressJSON<WebArea>(WebTypeEnum.WebArea, TVItemID);

            tvItemParent = webArea.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.Sector;
            string TVTextEN = "New Item";
            string TVTextFR = "Nouveau Item";

            var actionTVItemModelAdded = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModelAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModelAdded.Result).Value);
            TVItemModel tvItemModelAdded = (TVItemModel)((OkObjectResult)actionTVItemModelAdded.Result).Value;
            Assert.NotNull(tvItemModelAdded);

            CheckTVItem(tvItemModelAdded, DBCommandEnum.Created);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

            webArea = await CSSPReadGzFileService.GetUncompressJSON<WebArea>(WebTypeEnum.WebArea, TVItemID);

            var actionTVItemModel = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelAdded);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            CheckTVItem(tvItemModel, DBCommandEnum.Deleted);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Deleted, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Deleted, TVTextFR, LanguageEnum.fr);

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

            var actionTVItemModelExist = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelExist);
            Assert.Equal(400, ((ObjectResult)actionTVItemModelExist.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionTVItemModelExist.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModelExist.Result).Value;
            Assert.NotEmpty(errRes.ErrList);

            //-----------------------------------------------------------------------------------------

            Assert.True(await TVItemLocalServiceSetup(culture));

            webSector = await CSSPReadGzFileService.GetUncompressJSON<WebSector>(WebTypeEnum.WebSector, TVItemID);

            tvItemParent = webSector.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.Subsector;
            string TVTextEN = "New Item";
            string TVTextFR = "Nouveau Item";

            var actionTVItemModelAdded = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModelAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModelAdded.Result).Value);
            TVItemModel tvItemModelAdded = (TVItemModel)((OkObjectResult)actionTVItemModelAdded.Result).Value;
            Assert.NotNull(tvItemModelAdded);

            CheckTVItem(tvItemModelAdded, DBCommandEnum.Created);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

            webSector = await CSSPReadGzFileService.GetUncompressJSON<WebSector>(WebTypeEnum.WebSector, TVItemID);

            var actionTVItemModel = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelAdded);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            CheckTVItem(tvItemModel, DBCommandEnum.Deleted);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Deleted, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Deleted, TVTextFR, LanguageEnum.fr);

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

            var actionTVItemModelExist = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelExist);
            Assert.Equal(400, ((ObjectResult)actionTVItemModelExist.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionTVItemModelExist.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModelExist.Result).Value;
            Assert.NotEmpty(errRes.ErrList);

            //-----------------------------------------------------------------------------------------

            Assert.True(await TVItemLocalServiceSetup(culture));

            webMWQMRuns = await CSSPReadGzFileService.GetUncompressJSON<WebMWQMRuns>(WebTypeEnum.WebMWQMRuns, TVItemID);

            tvItemParent = webMWQMRuns.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.MWQMRun;
            string TVTextEN = "New Item";
            string TVTextFR = "Nouveau Item";

            var actionTVItemModelAdded = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModelAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModelAdded.Result).Value);
            TVItemModel tvItemModelAdded = (TVItemModel)((OkObjectResult)actionTVItemModelAdded.Result).Value;
            Assert.NotNull(tvItemModelAdded);

            CheckTVItem(tvItemModelAdded, DBCommandEnum.Created);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

            webMWQMRuns = await CSSPReadGzFileService.GetUncompressJSON<WebMWQMRuns>(WebTypeEnum.WebMWQMRuns, TVItemID);

            var actionTVItemModel = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelAdded);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            CheckTVItem(tvItemModel, DBCommandEnum.Deleted);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Deleted, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Deleted, TVTextFR, LanguageEnum.fr);

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

            var actionTVItemModelExist = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelExist);
            Assert.Equal(400, ((ObjectResult)actionTVItemModelExist.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionTVItemModelExist.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModelExist.Result).Value;
            Assert.NotEmpty(errRes.ErrList);

            //-----------------------------------------------------------------------------------------

            Assert.True(await TVItemLocalServiceSetup(culture));

            webMWQMSites = await CSSPReadGzFileService.GetUncompressJSON<WebMWQMSites>(WebTypeEnum.WebMWQMSites, TVItemID);

            tvItemParent = webMWQMSites.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.MWQMSite;
            string TVTextEN = "New Item";
            string TVTextFR = "Nouveau Item";

            var actionTVItemModelAdded = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModelAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModelAdded.Result).Value);
            TVItemModel tvItemModelAdded = (TVItemModel)((OkObjectResult)actionTVItemModelAdded.Result).Value;
            Assert.NotNull(tvItemModelAdded);

            CheckTVItem(tvItemModelAdded, DBCommandEnum.Created);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

            webMWQMSites = await CSSPReadGzFileService.GetUncompressJSON<WebMWQMSites>(WebTypeEnum.WebMWQMSites, TVItemID);

            var actionTVItemModel = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelAdded);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            CheckTVItem(tvItemModel, DBCommandEnum.Deleted);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Deleted, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Deleted, TVTextFR, LanguageEnum.fr);

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

            var actionTVItemModelExist = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelExist);
            Assert.Equal(400, ((ObjectResult)actionTVItemModelExist.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionTVItemModelExist.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModelExist.Result).Value;
            Assert.NotEmpty(errRes.ErrList);

            //-----------------------------------------------------------------------------------------

            Assert.True(await TVItemLocalServiceSetup(culture));

            webPolSourceSites = await CSSPReadGzFileService.GetUncompressJSON<WebPolSourceSites>(WebTypeEnum.WebPolSourceSites, TVItemID);

            tvItemParent = webPolSourceSites.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.PolSourceSite;
            string TVTextEN = "New Item";
            string TVTextFR = "Nouveau Item";

            var actionTVItemModelAdded = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModelAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModelAdded.Result).Value);
            TVItemModel tvItemModelAdded = (TVItemModel)((OkObjectResult)actionTVItemModelAdded.Result).Value;
            Assert.NotNull(tvItemModelAdded);

            CheckTVItem(tvItemModelAdded, DBCommandEnum.Created);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

            webPolSourceSites = await CSSPReadGzFileService.GetUncompressJSON<WebPolSourceSites>(WebTypeEnum.WebPolSourceSites, TVItemID);

            var actionTVItemModel = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelAdded);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            CheckTVItem(tvItemModel, DBCommandEnum.Deleted);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Deleted, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Deleted, TVTextFR, LanguageEnum.fr);

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

            webSubsector = await CSSPReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, TVItemID);

            tvItemParent = webSubsector.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.Classification;
            string TVTextEN = "New Item";
            string TVTextFR = "Nouveau Item";

            var actionTVItemModelAdded = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModelAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModelAdded.Result).Value);
            TVItemModel tvItemModelAdded = (TVItemModel)((OkObjectResult)actionTVItemModelAdded.Result).Value;
            Assert.NotNull(tvItemModelAdded);

            CheckTVItem(tvItemModelAdded, DBCommandEnum.Created);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

            webSubsector = await CSSPReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, TVItemID);

            var actionTVItemModel = await TVItemLocalService.DeleteTVItemLocal(tvItemParent, tvItemModelAdded);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            CheckTVItem(tvItemModel, DBCommandEnum.Deleted);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Deleted, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Deleted, TVTextFR, LanguageEnum.fr);

            List<TVItemModel> tvItemModelParentList = webSubsector.TVItemModelParentList;

            tvItemModelParentList.Add(tvItemModel);

            CheckDBLocal(tvItemModelParentList);
            CheckLocalJsonFileCreated(tvItemModelParentList);
        }
    }
}
