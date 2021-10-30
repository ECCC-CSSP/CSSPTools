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
        public async Task ModifyTVItemLocal_Root_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, 0);

            TVItem tvItemParent = webRoot.TVItemModel.TVItem;
            string TVTextEN = "Modify Item";
            string TVTextFR = "Item modifié";

            webRoot.TVItemModel.TVItemLanguageList[0].TVText = TVTextEN;
            webRoot.TVItemModel.TVItemLanguageList[1].TVText = TVTextFR;

            var actionTVItemModel = await TVItemLocalService.ModifyTVTextLocal(tvItemParent, webRoot.TVItemModel);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            CheckTVItem(tvItemModel, DBCommandEnum.Original);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Modified, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Modified, TVTextFR, LanguageEnum.fr);

            List<TVItemModel> tvItemModelParentList = new List<TVItemModel>();
            
            tvItemModelParentList.Add(tvItemModel);

            CheckDBLocal(tvItemModelParentList);
            CheckLocalJsonFileCreated(tvItemModelParentList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ModifyTVItemLocal_Country_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            int TVItemID = 0;

            WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, TVItemID);

            TVItem tvItemParent = webRoot.TVItemModel.TVItem;
            string TVTextEN = "Modify Item";
            string TVTextFR = "Item modifié";

            Assert.NotEmpty(webRoot.TVItemModelCountryList);

            TVItemModel tvItemModelToModify = webRoot.TVItemModelCountryList[0];

            tvItemModelToModify .TVItemLanguageList[0].TVText = TVTextEN;
            tvItemModelToModify.TVItemLanguageList[1].TVText = TVTextFR;

            var actionTVItemModel = await TVItemLocalService.ModifyTVTextLocal(tvItemParent, tvItemModelToModify);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            CheckTVItem(tvItemModel, DBCommandEnum.Original);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Modified, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Modified, TVTextFR, LanguageEnum.fr);

            List<TVItemModel> tvItemModelParentList = webRoot.TVItemModelParentList;

            tvItemModelParentList.Add(tvItemModel);

            CheckDBLocal(tvItemModelParentList);
            CheckLocalJsonFileCreated(tvItemModelParentList);

            //-----------------------------------------------------------------------------------------

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

            CheckTVItem(tvItemModelAdded, DBCommandEnum.Created);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

            webRoot = await CSSPReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, 0);

            TVTextEN = "Modified New Item";
            TVTextFR = "Nouveau Item modifié";

            tvItemModelAdded.TVItemLanguageList[0].TVText = TVTextEN;
            tvItemModelAdded.TVItemLanguageList[1].TVText = TVTextFR;

            var actionTVItemModelModify = await TVItemLocalService.ModifyTVTextLocal(tvItemParent, tvItemModelAdded);
            Assert.Equal(200, ((ObjectResult)actionTVItemModelModify.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModelModify.Result).Value);
            TVItemModel tvItemModelModify = (TVItemModel)((OkObjectResult)actionTVItemModelModify.Result).Value;
            Assert.NotNull(tvItemModelModify);

            CheckTVItem(tvItemModelModify, DBCommandEnum.Created);
            CheckTVItemLanguage(tvItemModelModify, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelModify, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

            tvItemModelParentList = webRoot.TVItemModelParentList;

            tvItemModelParentList.Add(tvItemModelModify);

            CheckDBLocal(tvItemModelParentList);
            CheckLocalJsonFileCreated(tvItemModelParentList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ModifyTVItemLocal_Address_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            // not allowed to modify an Address type
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ModifyTVItemLocal_Email_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            // not allowed to modify an Email type
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ModifyTVItemLocal_Tel_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            // not allowed to modify an Tel type
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ModifyTVItemLocal_Province_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            int TVItemID = 5;

            WebCountry webCountry = await CSSPReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, TVItemID);

            TVItem tvItemParent = webCountry.TVItemModel.TVItem;
            string TVTextEN = "Modify Item";
            string TVTextFR = "Item modifié";

            Assert.NotEmpty(webCountry.TVItemModelProvinceList);

            TVItemModel tvItemModelToModify = webCountry.TVItemModelProvinceList[0];

            tvItemModelToModify.TVItemLanguageList[0].TVText = TVTextEN;
            tvItemModelToModify.TVItemLanguageList[1].TVText = TVTextFR;

            var actionTVItemModel = await TVItemLocalService.ModifyTVTextLocal(tvItemParent, tvItemModelToModify);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            CheckTVItem(tvItemModel, DBCommandEnum.Original);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Modified, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Modified, TVTextFR, LanguageEnum.fr);

            List<TVItemModel> tvItemModelParentList = webCountry.TVItemModelParentList;

            tvItemModelParentList.Add(tvItemModel);

            CheckDBLocal(tvItemModelParentList);
            CheckLocalJsonFileCreated(tvItemModelParentList);

            //-----------------------------------------------------------------------------------------

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

            CheckTVItem(tvItemModelAdded, DBCommandEnum.Created);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

            webCountry = await CSSPReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, TVItemID);

            TVTextEN = "Modified New Item";
            TVTextFR = "Nouveau Item modifié";

            tvItemModelAdded.TVItemLanguageList[0].TVText = TVTextEN;
            tvItemModelAdded.TVItemLanguageList[1].TVText = TVTextFR;

            var actionTVItemModelModify = await TVItemLocalService.ModifyTVTextLocal(tvItemParent, tvItemModelAdded);
            Assert.Equal(200, ((ObjectResult)actionTVItemModelModify.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModelModify.Result).Value);
            TVItemModel tvItemModelModify = (TVItemModel)((OkObjectResult)actionTVItemModelModify.Result).Value;
            Assert.NotNull(tvItemModelModify);

            CheckTVItem(tvItemModelModify, DBCommandEnum.Created);
            CheckTVItemLanguage(tvItemModelModify, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelModify, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

            tvItemModelParentList = webCountry.TVItemModelParentList;

            tvItemModelParentList.Add(tvItemModelModify);

            CheckDBLocal(tvItemModelParentList);
            CheckLocalJsonFileCreated(tvItemModelParentList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ModifyTVItemLocal_RainExceedance_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            int TVItemID = 5;

            WebCountry webCountry = await CSSPReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, TVItemID);

            TVItem tvItemParent = webCountry.TVItemModel.TVItem;
            string TVTextEN = "Modify Item";
            string TVTextFR = "Item modifié";

            Assert.NotEmpty(webCountry.RainExceedanceModelList);

            TVItemModel tvItemModelToModify = webCountry.RainExceedanceModelList[0].TVItemModel;

            tvItemModelToModify.TVItemLanguageList[0].TVText = TVTextEN;
            tvItemModelToModify.TVItemLanguageList[1].TVText = TVTextFR;

            var actionTVItemModel = await TVItemLocalService.ModifyTVTextLocal(tvItemParent, tvItemModelToModify);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            CheckTVItem(tvItemModel, DBCommandEnum.Original);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Modified, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Modified, TVTextFR, LanguageEnum.fr);

            List<TVItemModel> tvItemModelParentList = webCountry.TVItemModelParentList;

            tvItemModelParentList.Add(tvItemModel);

            CheckDBLocal(tvItemModelParentList);
            CheckLocalJsonFileCreated(tvItemModelParentList);

            //-----------------------------------------------------------------------------------------

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

            CheckTVItem(tvItemModelAdded, DBCommandEnum.Created);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

            webCountry = await CSSPReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, TVItemID);

            TVTextEN = "Modified New Item";
            TVTextFR = "Nouveau Item modifié";

            tvItemModelAdded.TVItemLanguageList[0].TVText = TVTextEN;
            tvItemModelAdded.TVItemLanguageList[1].TVText = TVTextFR;

            var actionTVItemModelModify = await TVItemLocalService.ModifyTVTextLocal(tvItemParent, tvItemModelAdded);
            Assert.Equal(200, ((ObjectResult)actionTVItemModelModify.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModelModify.Result).Value);
            TVItemModel tvItemModelModify = (TVItemModel)((OkObjectResult)actionTVItemModelModify.Result).Value;
            Assert.NotNull(tvItemModelModify);

            CheckTVItem(tvItemModelModify, DBCommandEnum.Created);
            CheckTVItemLanguage(tvItemModelModify, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelModify, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

            tvItemModelParentList = webCountry.TVItemModelParentList;

            tvItemModelParentList.Add(tvItemModelModify);

            CheckDBLocal(tvItemModelParentList);
            CheckLocalJsonFileCreated(tvItemModelParentList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ModifyTVItemLocal_EmailDistributionList_Good_Test(string culture)
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

            TVTextEN = "Modified New Item";
            TVTextFR = "Nouveau Item modifié";

            tvItemModelAdded.TVItemLanguageList[0].TVText = TVTextEN;
            tvItemModelAdded.TVItemLanguageList[1].TVText = TVTextFR;

            var actionTVItemModelModify = await TVItemLocalService.ModifyTVTextLocal(tvItemParent, tvItemModelAdded);
            Assert.Equal(200, ((ObjectResult)actionTVItemModelModify.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModelModify.Result).Value);
            TVItemModel tvItemModelModify = (TVItemModel)((OkObjectResult)actionTVItemModelModify.Result).Value;
            Assert.NotNull(tvItemModelModify);

            CheckTVItem(tvItemModelModify, DBCommandEnum.Created);
            CheckTVItemLanguage(tvItemModelModify, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelModify, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

            List<TVItemModel> tvItemModelParentList = webCountry.TVItemModelParentList;

            tvItemModelParentList = webCountry.TVItemModelParentList;

            tvItemModelParentList.Add(tvItemModelModify);

            CheckDBLocal(tvItemModelParentList);
            CheckLocalJsonFileCreated(tvItemModelParentList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ModifyTVItemLocal_Area_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            int TVItemID = 7;

            WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

            TVItem tvItemParent = webProvince.TVItemModel.TVItem;
            string TVTextEN = "Modify Item";
            string TVTextFR = "Item modifié";

            Assert.NotEmpty(webProvince.TVItemModelAreaList);

            TVItemModel tvItemModelToModify = webProvince.TVItemModelAreaList[0];

            tvItemModelToModify.TVItemLanguageList[0].TVText = TVTextEN;
            tvItemModelToModify.TVItemLanguageList[1].TVText = TVTextFR;

            var actionTVItemModel = await TVItemLocalService.ModifyTVTextLocal(tvItemParent, tvItemModelToModify);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            CheckTVItem(tvItemModel, DBCommandEnum.Original);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Modified, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Modified, TVTextFR, LanguageEnum.fr);

            List<TVItemModel> tvItemModelParentList = webProvince.TVItemModelParentList;

            tvItemModelParentList.Add(tvItemModel);

            CheckDBLocal(tvItemModelParentList);
            CheckLocalJsonFileCreated(tvItemModelParentList);

            //-----------------------------------------------------------------------------------------

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

            CheckTVItem(tvItemModelAdded, DBCommandEnum.Created);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

            webProvince = await CSSPReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

            TVTextEN = "Modified New Item";
            TVTextFR = "Nouveau Item modifié";

            tvItemModelAdded.TVItemLanguageList[0].TVText = TVTextEN;
            tvItemModelAdded.TVItemLanguageList[1].TVText = TVTextFR;

            var actionTVItemModelModify = await TVItemLocalService.ModifyTVTextLocal(tvItemParent, tvItemModelAdded);
            Assert.Equal(200, ((ObjectResult)actionTVItemModelModify.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModelModify.Result).Value);
            TVItemModel tvItemModelModify = (TVItemModel)((OkObjectResult)actionTVItemModelModify.Result).Value;
            Assert.NotNull(tvItemModelModify);

            CheckTVItem(tvItemModelModify, DBCommandEnum.Created);
            CheckTVItemLanguage(tvItemModelModify, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelModify, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

            tvItemModelParentList = webProvince.TVItemModelParentList;

            tvItemModelParentList.Add(tvItemModelModify);

            CheckDBLocal(tvItemModelParentList);
            CheckLocalJsonFileCreated(tvItemModelParentList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ModifyTVItemLocal_SamplingPlan_Good_Test(string culture)
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

            TVTextEN = "Modified New Item";
            TVTextFR = "Nouveau Item modifié";

            tvItemModelAdded.TVItemLanguageList[0].TVText = TVTextEN;
            tvItemModelAdded.TVItemLanguageList[1].TVText = TVTextFR;

            var actionTVItemModelModify = await TVItemLocalService.ModifyTVTextLocal(tvItemParent, tvItemModelAdded);
            Assert.Equal(200, ((ObjectResult)actionTVItemModelModify.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModelModify.Result).Value);
            TVItemModel tvItemModelModify = (TVItemModel)((OkObjectResult)actionTVItemModelModify.Result).Value;
            Assert.NotNull(tvItemModelModify);

            CheckTVItem(tvItemModelModify, DBCommandEnum.Created);
            CheckTVItemLanguage(tvItemModelModify, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelModify, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

            List<TVItemModel> tvItemModelParentList = webProvince.TVItemModelParentList;

            tvItemModelParentList = webProvince.TVItemModelParentList;

            tvItemModelParentList.Add(tvItemModelModify);

            CheckDBLocal(tvItemModelParentList);
            CheckLocalJsonFileCreated(tvItemModelParentList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ModifyTVItemLocal_ClimateSite_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            int TVItemID = 7;

            WebClimateSites webClimateSites = await CSSPReadGzFileService.GetUncompressJSON<WebClimateSites>(WebTypeEnum.WebClimateSites, TVItemID);

            TVItem tvItemParent = webClimateSites.TVItemModel.TVItem;
            string TVTextEN = "Modify Item";
            string TVTextFR = "Item modifié";

            Assert.NotEmpty(webClimateSites.ClimateSiteModelList);

            TVItemModel tvItemModelToModify = webClimateSites.ClimateSiteModelList[0].TVItemModel;

            tvItemModelToModify.TVItemLanguageList[0].TVText = TVTextEN;
            tvItemModelToModify.TVItemLanguageList[1].TVText = TVTextFR;

            var actionTVItemModel = await TVItemLocalService.ModifyTVTextLocal(tvItemParent, tvItemModelToModify);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            CheckTVItem(tvItemModel, DBCommandEnum.Original);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Modified, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Modified, TVTextFR, LanguageEnum.fr);

            List<TVItemModel> tvItemModelParentList = webClimateSites.TVItemModelParentList;

            tvItemModelParentList.Add(tvItemModel);

            CheckDBLocal(tvItemModelParentList);
            CheckLocalJsonFileCreated(tvItemModelParentList);

            //-----------------------------------------------------------------------------------------

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

            CheckTVItem(tvItemModelAdded, DBCommandEnum.Created);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

            webClimateSites = await CSSPReadGzFileService.GetUncompressJSON<WebClimateSites>(WebTypeEnum.WebClimateSites, TVItemID);

            TVTextEN = "Modified New Item";
            TVTextFR = "Nouveau Item modifié";

            tvItemModelAdded.TVItemLanguageList[0].TVText = TVTextEN;
            tvItemModelAdded.TVItemLanguageList[1].TVText = TVTextFR;

            var actionTVItemModelModify = await TVItemLocalService.ModifyTVTextLocal(tvItemParent, tvItemModelAdded);
            Assert.Equal(200, ((ObjectResult)actionTVItemModelModify.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModelModify.Result).Value);
            TVItemModel tvItemModelModify = (TVItemModel)((OkObjectResult)actionTVItemModelModify.Result).Value;
            Assert.NotNull(tvItemModelModify);

            CheckTVItem(tvItemModelModify, DBCommandEnum.Created);
            CheckTVItemLanguage(tvItemModelModify, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelModify, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

            tvItemModelParentList = webClimateSites.TVItemModelParentList;

            tvItemModelParentList.Add(tvItemModelModify);

            CheckDBLocal(tvItemModelParentList);
            CheckLocalJsonFileCreated(tvItemModelParentList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ModifyTVItemLocal_HydrometricSite_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            int TVItemID = 7;

            WebHydrometricSites webHydrometricSites = await CSSPReadGzFileService.GetUncompressJSON<WebHydrometricSites>(WebTypeEnum.WebHydrometricSites, TVItemID);

            TVItem tvItemParent = webHydrometricSites.TVItemModel.TVItem;
            string TVTextEN = "Modify Item";
            string TVTextFR = "Item modifié";

            Assert.NotEmpty(webHydrometricSites.HydrometricSiteModelList);

            TVItemModel tvItemModelToModify = webHydrometricSites.HydrometricSiteModelList[0].TVItemModel;

            tvItemModelToModify.TVItemLanguageList[0].TVText = TVTextEN;
            tvItemModelToModify.TVItemLanguageList[1].TVText = TVTextFR;

            var actionTVItemModel = await TVItemLocalService.ModifyTVTextLocal(tvItemParent, tvItemModelToModify);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            CheckTVItem(tvItemModel, DBCommandEnum.Original);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Modified, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Modified, TVTextFR, LanguageEnum.fr);

            List<TVItemModel> tvItemModelParentList = webHydrometricSites.TVItemModelParentList;

            tvItemModelParentList.Add(tvItemModel);

            CheckDBLocal(tvItemModelParentList);
            CheckLocalJsonFileCreated(tvItemModelParentList);

            //-----------------------------------------------------------------------------------------

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

            CheckTVItem(tvItemModelAdded, DBCommandEnum.Created);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

            webHydrometricSites = await CSSPReadGzFileService.GetUncompressJSON<WebHydrometricSites>(WebTypeEnum.WebHydrometricSites, TVItemID);

            TVTextEN = "Modified New Item";
            TVTextFR = "Nouveau Item modifié";

            tvItemModelAdded.TVItemLanguageList[0].TVText = TVTextEN;
            tvItemModelAdded.TVItemLanguageList[1].TVText = TVTextFR;

            var actionTVItemModelModify = await TVItemLocalService.ModifyTVTextLocal(tvItemParent, tvItemModelAdded);
            Assert.Equal(200, ((ObjectResult)actionTVItemModelModify.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModelModify.Result).Value);
            TVItemModel tvItemModelModify = (TVItemModel)((OkObjectResult)actionTVItemModelModify.Result).Value;
            Assert.NotNull(tvItemModelModify);

            CheckTVItem(tvItemModelModify, DBCommandEnum.Created);
            CheckTVItemLanguage(tvItemModelModify, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelModify, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

            tvItemModelParentList = webHydrometricSites.TVItemModelParentList;

            tvItemModelParentList.Add(tvItemModelModify);

            CheckDBLocal(tvItemModelParentList);
            CheckLocalJsonFileCreated(tvItemModelParentList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ModifyTVItemLocal_TideSite_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            int TVItemID = 7;

            WebTideSites webTideSites = await CSSPReadGzFileService.GetUncompressJSON<WebTideSites>(WebTypeEnum.WebTideSites, TVItemID);

            TVItem tvItemParent = webTideSites.TVItemModel.TVItem;
            string TVTextEN = "Modify Item";
            string TVTextFR = "Item modifié";

            Assert.NotEmpty(webTideSites.TideSiteModelList);

            TVItemModel tvItemModelToModify = webTideSites.TideSiteModelList[0].TVItemModel;

            tvItemModelToModify.TVItemLanguageList[0].TVText = TVTextEN;
            tvItemModelToModify.TVItemLanguageList[1].TVText = TVTextFR;

            var actionTVItemModel = await TVItemLocalService.ModifyTVTextLocal(tvItemParent, tvItemModelToModify);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            CheckTVItem(tvItemModel, DBCommandEnum.Original);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Modified, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Modified, TVTextFR, LanguageEnum.fr);

            List<TVItemModel> tvItemModelParentList = webTideSites.TVItemModelParentList;

            tvItemModelParentList.Add(tvItemModel);

            CheckDBLocal(tvItemModelParentList);
            CheckLocalJsonFileCreated(tvItemModelParentList);

            //-----------------------------------------------------------------------------------------

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

            CheckTVItem(tvItemModelAdded, DBCommandEnum.Created);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

            webTideSites = await CSSPReadGzFileService.GetUncompressJSON<WebTideSites>(WebTypeEnum.WebTideSites, TVItemID);

            TVTextEN = "Modified New Item";
            TVTextFR = "Nouveau Item modifié";

            tvItemModelAdded.TVItemLanguageList[0].TVText = TVTextEN;
            tvItemModelAdded.TVItemLanguageList[1].TVText = TVTextFR;

            var actionTVItemModelModify = await TVItemLocalService.ModifyTVTextLocal(tvItemParent, tvItemModelAdded);
            Assert.Equal(200, ((ObjectResult)actionTVItemModelModify.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModelModify.Result).Value);
            TVItemModel tvItemModelModify = (TVItemModel)((OkObjectResult)actionTVItemModelModify.Result).Value;
            Assert.NotNull(tvItemModelModify);

            CheckTVItem(tvItemModelModify, DBCommandEnum.Created);
            CheckTVItemLanguage(tvItemModelModify, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelModify, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

            tvItemModelParentList = webTideSites.TVItemModelParentList;

            tvItemModelParentList.Add(tvItemModelModify);

            CheckDBLocal(tvItemModelParentList);
            CheckLocalJsonFileCreated(tvItemModelParentList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ModifyTVItemLocal_Infrastructure_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            int TVItemID = 27764;

            WebMunicipality webMunicipality = await CSSPReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, TVItemID);

            TVItem tvItemParent = webMunicipality.TVItemModel.TVItem;
            string TVTextEN = "Modify Item";
            string TVTextFR = "Item modifié";

            Assert.NotEmpty(webMunicipality.InfrastructureModelList);

            TVItemModel tvItemModelToModify = webMunicipality.InfrastructureModelList[0].TVItemModel;

            tvItemModelToModify.TVItemLanguageList[0].TVText = TVTextEN;
            tvItemModelToModify.TVItemLanguageList[1].TVText = TVTextFR;

            var actionTVItemModel = await TVItemLocalService.ModifyTVTextLocal(tvItemParent, tvItemModelToModify);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            CheckTVItem(tvItemModel, DBCommandEnum.Original);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Modified, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Modified, TVTextFR, LanguageEnum.fr);

            List<TVItemModel> tvItemModelParentList = webMunicipality.TVItemModelParentList;

            tvItemModelParentList.Add(tvItemModel);

            CheckDBLocal(tvItemModelParentList);
            CheckLocalJsonFileCreated(tvItemModelParentList);

            //-----------------------------------------------------------------------------------------

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

            CheckTVItem(tvItemModelAdded, DBCommandEnum.Created);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

            webMunicipality = await CSSPReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, TVItemID);

            TVTextEN = "Modified New Item";
            TVTextFR = "Nouveau Item modifié";

            tvItemModelAdded.TVItemLanguageList[0].TVText = TVTextEN;
            tvItemModelAdded.TVItemLanguageList[1].TVText = TVTextFR;

            var actionTVItemModelModify = await TVItemLocalService.ModifyTVTextLocal(tvItemParent, tvItemModelAdded);
            Assert.Equal(200, ((ObjectResult)actionTVItemModelModify.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModelModify.Result).Value);
            TVItemModel tvItemModelModify = (TVItemModel)((OkObjectResult)actionTVItemModelModify.Result).Value;
            Assert.NotNull(tvItemModelModify);

            CheckTVItem(tvItemModelModify, DBCommandEnum.Created);
            CheckTVItemLanguage(tvItemModelModify, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelModify, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

            tvItemModelParentList = webMunicipality.TVItemModelParentList;

            tvItemModelParentList.Add(tvItemModelModify);

            CheckDBLocal(tvItemModelParentList);
            CheckLocalJsonFileCreated(tvItemModelParentList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ModifyTVItemLocal_MikeScenario_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            int TVItemID = 27764;

            WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, TVItemID);

            TVItem tvItemParent = webMikeScenarios.TVItemModel.TVItem;
            string TVTextEN = "Modify Item";
            string TVTextFR = "Item modifié";

            Assert.NotEmpty(webMikeScenarios.MikeScenarioModelList);

            TVItemModel tvItemModelToModify = webMikeScenarios.MikeScenarioModelList[0].TVItemModel;

            tvItemModelToModify.TVItemLanguageList[0].TVText = TVTextEN;
            tvItemModelToModify.TVItemLanguageList[1].TVText = TVTextFR;

            var actionTVItemModel = await TVItemLocalService.ModifyTVTextLocal(tvItemParent, tvItemModelToModify);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            CheckTVItem(tvItemModel, DBCommandEnum.Original);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Modified, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Modified, TVTextFR, LanguageEnum.fr);

            List<TVItemModel> tvItemModelParentList = webMikeScenarios.TVItemModelParentList;

            tvItemModelParentList.Add(tvItemModel);

            CheckDBLocal(tvItemModelParentList);
            CheckLocalJsonFileCreated(tvItemModelParentList);

            //-----------------------------------------------------------------------------------------

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

            CheckTVItem(tvItemModelAdded, DBCommandEnum.Created);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

            webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, TVItemID);

            TVTextEN = "Modified New Item";
            TVTextFR = "Nouveau Item modifié";

            tvItemModelAdded.TVItemLanguageList[0].TVText = TVTextEN;
            tvItemModelAdded.TVItemLanguageList[1].TVText = TVTextFR;

            var actionTVItemModelModify = await TVItemLocalService.ModifyTVTextLocal(tvItemParent, tvItemModelAdded);
            Assert.Equal(200, ((ObjectResult)actionTVItemModelModify.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModelModify.Result).Value);
            TVItemModel tvItemModelModify = (TVItemModel)((OkObjectResult)actionTVItemModelModify.Result).Value;
            Assert.NotNull(tvItemModelModify);

            CheckTVItem(tvItemModelModify, DBCommandEnum.Created);
            CheckTVItemLanguage(tvItemModelModify, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelModify, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

            tvItemModelParentList = webMikeScenarios.TVItemModelParentList;

            tvItemModelParentList.Add(tvItemModelModify);

            CheckDBLocal(tvItemModelParentList);
            CheckLocalJsonFileCreated(tvItemModelParentList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ModifyTVItemLocal_MikeSource_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            int TVItemID = 27764;

            WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, TVItemID);

            TVItem tvItemParent = webMikeScenarios.TVItemModel.TVItem;
            string TVTextEN = "Modify Item";
            string TVTextFR = "Item modifié";

            Assert.NotEmpty(webMikeScenarios.MikeScenarioModelList);

            MikeScenarioModel mikeScenarioModel = webMikeScenarios.MikeScenarioModelList[0];

            Assert.NotEmpty(mikeScenarioModel.MikeSourceModelList);

            tvItemParent = mikeScenarioModel.TVItemModel.TVItem;
            TVItemModel tvItemModelToModify = mikeScenarioModel.MikeSourceModelList[0].TVItemModel;

            tvItemModelToModify.TVItemLanguageList[0].TVText = TVTextEN;
            tvItemModelToModify.TVItemLanguageList[1].TVText = TVTextFR;

            var actionTVItemModel = await TVItemLocalService.ModifyTVTextLocal(tvItemParent, tvItemModelToModify);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            CheckTVItem(tvItemModel, DBCommandEnum.Original);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Modified, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Modified, TVTextFR, LanguageEnum.fr);

            List<TVItemModel> tvItemModelParentList = webMikeScenarios.TVItemModelParentList;

            tvItemModelParentList.Add(mikeScenarioModel.TVItemModel);
            tvItemModelParentList.Add(tvItemModel);

            CheckDBLocal(tvItemModelParentList);
            CheckLocalJsonFileCreated(tvItemModelParentList);

            //-----------------------------------------------------------------------------------------

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

            CheckTVItem(tvItemModelAdded, DBCommandEnum.Created);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

            webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, TVItemID);

            TVTextEN = "Modified New Item";
            TVTextFR = "Nouveau Item modifié";

            tvItemModelAdded.TVItemLanguageList[0].TVText = TVTextEN;
            tvItemModelAdded.TVItemLanguageList[1].TVText = TVTextFR;

            var actionTVItemModelModify = await TVItemLocalService.ModifyTVTextLocal(tvItemParent, tvItemModelAdded);
            Assert.Equal(200, ((ObjectResult)actionTVItemModelModify.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModelModify.Result).Value);
            TVItemModel tvItemModelModify = (TVItemModel)((OkObjectResult)actionTVItemModelModify.Result).Value;
            Assert.NotNull(tvItemModelModify);

            CheckTVItem(tvItemModelModify, DBCommandEnum.Created);
            CheckTVItemLanguage(tvItemModelModify, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelModify, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

            tvItemModelParentList = webMikeScenarios.TVItemModelParentList;

            tvItemModelParentList.Add(mikeScenarioModel.TVItemModel);
            tvItemModelParentList.Add(tvItemModelModify);

            CheckDBLocal(tvItemModelParentList);
            CheckLocalJsonFileCreated(tvItemModelParentList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ModifyTVItemLocal_MikeBoundaryConditionMesh_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            int TVItemID = 27764;

            WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, TVItemID);

            TVItem tvItemParent = webMikeScenarios.TVItemModel.TVItem;
            string TVTextEN = "Modify Item";
            string TVTextFR = "Item modifié";

            Assert.NotEmpty(webMikeScenarios.MikeScenarioModelList);

            MikeScenarioModel mikeScenarioModel = webMikeScenarios.MikeScenarioModelList[0];

            Assert.NotEmpty(mikeScenarioModel.MikeBoundaryConditionModelList);

            tvItemParent = mikeScenarioModel.TVItemModel.TVItem;
            TVItemModel tvItemModelToModify = mikeScenarioModel.MikeBoundaryConditionModelList[0].TVItemModel;

            tvItemModelToModify.TVItemLanguageList[0].TVText = TVTextEN;
            tvItemModelToModify.TVItemLanguageList[1].TVText = TVTextFR;

            var actionTVItemModel = await TVItemLocalService.ModifyTVTextLocal(tvItemParent, tvItemModelToModify);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            CheckTVItem(tvItemModel, DBCommandEnum.Original);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Modified, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Modified, TVTextFR, LanguageEnum.fr);

            List<TVItemModel> tvItemModelParentList = webMikeScenarios.TVItemModelParentList;

            tvItemModelParentList.Add(mikeScenarioModel.TVItemModel);
            tvItemModelParentList.Add(tvItemModel);

            CheckDBLocal(tvItemModelParentList);
            CheckLocalJsonFileCreated(tvItemModelParentList);

            //-----------------------------------------------------------------------------------------

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

            CheckTVItem(tvItemModelAdded, DBCommandEnum.Created);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

            webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, TVItemID);

            TVTextEN = "Modified New Item";
            TVTextFR = "Nouveau Item modifié";

            tvItemModelAdded.TVItemLanguageList[0].TVText = TVTextEN;
            tvItemModelAdded.TVItemLanguageList[1].TVText = TVTextFR;

            var actionTVItemModelModify = await TVItemLocalService.ModifyTVTextLocal(tvItemParent, tvItemModelAdded);
            Assert.Equal(200, ((ObjectResult)actionTVItemModelModify.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModelModify.Result).Value);
            TVItemModel tvItemModelModify = (TVItemModel)((OkObjectResult)actionTVItemModelModify.Result).Value;
            Assert.NotNull(tvItemModelModify);

            CheckTVItem(tvItemModelModify, DBCommandEnum.Created);
            CheckTVItemLanguage(tvItemModelModify, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelModify, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

            tvItemModelParentList = webMikeScenarios.TVItemModelParentList;

            tvItemModelParentList.Add(mikeScenarioModel.TVItemModel);
            tvItemModelParentList.Add(tvItemModelModify);

            CheckDBLocal(tvItemModelParentList);
            CheckLocalJsonFileCreated(tvItemModelParentList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ModifyTVItemLocal_MikeBoundaryConditionWebTide_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            int TVItemID = 27764;

            WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, TVItemID);

            TVItem tvItemParent = webMikeScenarios.TVItemModel.TVItem;
            string TVTextEN = "Modify Item";
            string TVTextFR = "Item modifié";

            Assert.NotEmpty(webMikeScenarios.MikeScenarioModelList);

            MikeScenarioModel mikeScenarioModel = webMikeScenarios.MikeScenarioModelList[0];

            Assert.NotEmpty(mikeScenarioModel.MikeBoundaryConditionModelList);

            tvItemParent = mikeScenarioModel.TVItemModel.TVItem;
            TVItemModel tvItemModelToModify = mikeScenarioModel.MikeBoundaryConditionModelList[0].TVItemModel;

            tvItemModelToModify.TVItemLanguageList[0].TVText = TVTextEN;
            tvItemModelToModify.TVItemLanguageList[1].TVText = TVTextFR;

            var actionTVItemModel = await TVItemLocalService.ModifyTVTextLocal(tvItemParent, tvItemModelToModify);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            CheckTVItem(tvItemModel, DBCommandEnum.Original);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Modified, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Modified, TVTextFR, LanguageEnum.fr);

            List<TVItemModel> tvItemModelParentList = webMikeScenarios.TVItemModelParentList;

            tvItemModelParentList.Add(mikeScenarioModel.TVItemModel);
            tvItemModelParentList.Add(tvItemModel);

            CheckDBLocal(tvItemModelParentList);
            CheckLocalJsonFileCreated(tvItemModelParentList);

            //-----------------------------------------------------------------------------------------

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

            CheckTVItem(tvItemModelAdded, DBCommandEnum.Created);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

            webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, TVItemID);

            TVTextEN = "Modified New Item";
            TVTextFR = "Nouveau Item modifié";

            tvItemModelAdded.TVItemLanguageList[0].TVText = TVTextEN;
            tvItemModelAdded.TVItemLanguageList[1].TVText = TVTextFR;

            var actionTVItemModelModify = await TVItemLocalService.ModifyTVTextLocal(tvItemParent, tvItemModelAdded);
            Assert.Equal(200, ((ObjectResult)actionTVItemModelModify.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModelModify.Result).Value);
            TVItemModel tvItemModelModify = (TVItemModel)((OkObjectResult)actionTVItemModelModify.Result).Value;
            Assert.NotNull(tvItemModelModify);

            CheckTVItem(tvItemModelModify, DBCommandEnum.Created);
            CheckTVItemLanguage(tvItemModelModify, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelModify, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

            tvItemModelParentList = webMikeScenarios.TVItemModelParentList;

            tvItemModelParentList.Add(mikeScenarioModel.TVItemModel);
            tvItemModelParentList.Add(tvItemModelModify);

            CheckDBLocal(tvItemModelParentList);
            CheckLocalJsonFileCreated(tvItemModelParentList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ModifyTVItemLocal_Sector_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            int TVItemID = 629;

            WebArea webArea = await CSSPReadGzFileService.GetUncompressJSON<WebArea>(WebTypeEnum.WebArea, TVItemID);

            TVItem tvItemParent = webArea.TVItemModel.TVItem;
            string TVTextEN = "Modify Item";
            string TVTextFR = "Item modifié";

            Assert.NotEmpty(webArea.TVItemModelSectorList);

            TVItemModel tvItemModelToModify = webArea.TVItemModelSectorList[0];

            tvItemModelToModify.TVItemLanguageList[0].TVText = TVTextEN;
            tvItemModelToModify.TVItemLanguageList[1].TVText = TVTextFR;

            var actionTVItemModel = await TVItemLocalService.ModifyTVTextLocal(tvItemParent, tvItemModelToModify);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            CheckTVItem(tvItemModel, DBCommandEnum.Original);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Modified, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Modified, TVTextFR, LanguageEnum.fr);

            List<TVItemModel> tvItemModelParentList = webArea.TVItemModelParentList;

            tvItemModelParentList.Add(tvItemModel);

            CheckDBLocal(tvItemModelParentList);
            CheckLocalJsonFileCreated(tvItemModelParentList);

            //-----------------------------------------------------------------------------------------

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

            CheckTVItem(tvItemModelAdded, DBCommandEnum.Created);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

            webArea = await CSSPReadGzFileService.GetUncompressJSON<WebArea>(WebTypeEnum.WebArea, TVItemID);

            TVTextEN = "Modified New Item";
            TVTextFR = "Nouveau Item modifié";

            tvItemModelAdded.TVItemLanguageList[0].TVText = TVTextEN;
            tvItemModelAdded.TVItemLanguageList[1].TVText = TVTextFR;

            var actionTVItemModelModify = await TVItemLocalService.ModifyTVTextLocal(tvItemParent, tvItemModelAdded);
            Assert.Equal(200, ((ObjectResult)actionTVItemModelModify.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModelModify.Result).Value);
            TVItemModel tvItemModelModify = (TVItemModel)((OkObjectResult)actionTVItemModelModify.Result).Value;
            Assert.NotNull(tvItemModelModify);

            CheckTVItem(tvItemModelModify, DBCommandEnum.Created);
            CheckTVItemLanguage(tvItemModelModify, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelModify, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

            tvItemModelParentList = webArea.TVItemModelParentList;

            tvItemModelParentList.Add(tvItemModelModify);

            CheckDBLocal(tvItemModelParentList);
            CheckLocalJsonFileCreated(tvItemModelParentList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ModifyTVItemLocal_Subsector_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            int TVItemID = 633;

            WebSector webSector = await CSSPReadGzFileService.GetUncompressJSON<WebSector>(WebTypeEnum.WebSector, TVItemID);

            TVItem tvItemParent = webSector.TVItemModel.TVItem;
            string TVTextEN = "Modify Item";
            string TVTextFR = "Item modifié";

            Assert.NotEmpty(webSector.TVItemModelSubsectorList);

            TVItemModel tvItemModelToModify = webSector.TVItemModelSubsectorList[0];

            tvItemModelToModify.TVItemLanguageList[0].TVText = TVTextEN;
            tvItemModelToModify.TVItemLanguageList[1].TVText = TVTextFR;

            var actionTVItemModel = await TVItemLocalService.ModifyTVTextLocal(tvItemParent, tvItemModelToModify);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            CheckTVItem(tvItemModel, DBCommandEnum.Original);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Modified, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Modified, TVTextFR, LanguageEnum.fr);

            List<TVItemModel> tvItemModelParentList = webSector.TVItemModelParentList;

            tvItemModelParentList.Add(tvItemModel);

            CheckDBLocal(tvItemModelParentList);
            CheckLocalJsonFileCreated(tvItemModelParentList);

            //-----------------------------------------------------------------------------------------

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

            CheckTVItem(tvItemModelAdded, DBCommandEnum.Created);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

            webSector = await CSSPReadGzFileService.GetUncompressJSON<WebSector>(WebTypeEnum.WebSector, TVItemID);

            TVTextEN = "Modified New Item";
            TVTextFR = "Nouveau Item modifié";

            tvItemModelAdded.TVItemLanguageList[0].TVText = TVTextEN;
            tvItemModelAdded.TVItemLanguageList[1].TVText = TVTextFR;

            var actionTVItemModelModify = await TVItemLocalService.ModifyTVTextLocal(tvItemParent, tvItemModelAdded);
            Assert.Equal(200, ((ObjectResult)actionTVItemModelModify.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModelModify.Result).Value);
            TVItemModel tvItemModelModify = (TVItemModel)((OkObjectResult)actionTVItemModelModify.Result).Value;
            Assert.NotNull(tvItemModelModify);

            CheckTVItem(tvItemModelModify, DBCommandEnum.Created);
            CheckTVItemLanguage(tvItemModelModify, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelModify, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

            tvItemModelParentList = webSector.TVItemModelParentList;

            tvItemModelParentList.Add(tvItemModelModify);

            CheckDBLocal(tvItemModelParentList);
            CheckLocalJsonFileCreated(tvItemModelParentList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ModifyTVItemLocal_MWQMRuns_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            int TVItemID = 635;

            WebMWQMRuns webMWQMRuns = await CSSPReadGzFileService.GetUncompressJSON<WebMWQMRuns>(WebTypeEnum.WebMWQMRuns, TVItemID);

            TVItem tvItemParent = webMWQMRuns.TVItemModel.TVItem;
            string TVTextEN = "Modify Item";
            string TVTextFR = "Item modifié";

            Assert.NotEmpty(webMWQMRuns.MWQMRunModelList);

            MWQMRunModel mwqmRunModel = webMWQMRuns.MWQMRunModelList[0];

            mwqmRunModel.TVItemModel.TVItemLanguageList[0].TVText = TVTextEN;
            mwqmRunModel.TVItemModel.TVItemLanguageList[1].TVText = TVTextFR;

            TVItemModel tvItemModelToModify = mwqmRunModel.TVItemModel;

            var actionTVItemModel = await TVItemLocalService.ModifyTVTextLocal(tvItemParent, tvItemModelToModify);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            CheckTVItem(tvItemModel, DBCommandEnum.Original);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Modified, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Modified, TVTextFR, LanguageEnum.fr);

            List<TVItemModel> tvItemModelParentList = webMWQMRuns.TVItemModelParentList;

            tvItemModelParentList.Add(tvItemModel);

            CheckDBLocal(tvItemModelParentList);
            CheckLocalJsonFileCreated(tvItemModelParentList);

            //-----------------------------------------------------------------------------------------

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

            CheckTVItem(tvItemModelAdded, DBCommandEnum.Created);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

            webMWQMRuns = await CSSPReadGzFileService.GetUncompressJSON<WebMWQMRuns>(WebTypeEnum.WebMWQMRuns, TVItemID);

            TVTextEN = "Modified New Item";
            TVTextFR = "Nouveau Item modifié";

            tvItemModelAdded.TVItemLanguageList[0].TVText = TVTextEN;
            tvItemModelAdded.TVItemLanguageList[1].TVText = TVTextFR;

            var actionTVItemModelModify = await TVItemLocalService.ModifyTVTextLocal(tvItemParent, tvItemModelAdded);
            Assert.Equal(200, ((ObjectResult)actionTVItemModelModify.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModelModify.Result).Value);
            TVItemModel tvItemModelModify = (TVItemModel)((OkObjectResult)actionTVItemModelModify.Result).Value;
            Assert.NotNull(tvItemModelModify);

            CheckTVItem(tvItemModelModify, DBCommandEnum.Created);
            CheckTVItemLanguage(tvItemModelModify, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelModify, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

            tvItemModelParentList = webMWQMRuns.TVItemModelParentList;

            tvItemModelParentList.Add(tvItemModelModify);

            CheckDBLocal(tvItemModelParentList);
            CheckLocalJsonFileCreated(tvItemModelParentList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ModifyTVItemLocal_MWQMSites_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            int TVItemID = 635;

            WebMWQMSites webMWQMSites = await CSSPReadGzFileService.GetUncompressJSON<WebMWQMSites>(WebTypeEnum.WebMWQMSites, TVItemID);

            TVItem tvItemParent = webMWQMSites.TVItemModel.TVItem;
            string TVTextEN = "Modify Item";
            string TVTextFR = "Item modifié";

            Assert.NotEmpty(webMWQMSites.MWQMSiteModelList);

            MWQMSiteModel mwqmRunModel = webMWQMSites.MWQMSiteModelList[0];

            mwqmRunModel.TVItemModel.TVItemLanguageList[0].TVText = TVTextEN;
            mwqmRunModel.TVItemModel.TVItemLanguageList[1].TVText = TVTextFR;

            TVItemModel tvItemModelToModify = mwqmRunModel.TVItemModel;

            var actionTVItemModel = await TVItemLocalService.ModifyTVTextLocal(tvItemParent, tvItemModelToModify);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            CheckTVItem(tvItemModel, DBCommandEnum.Original);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Modified, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Modified, TVTextFR, LanguageEnum.fr);

            List<TVItemModel> tvItemModelParentList = webMWQMSites.TVItemModelParentList;

            tvItemModelParentList.Add(tvItemModel);

            CheckDBLocal(tvItemModelParentList);
            CheckLocalJsonFileCreated(tvItemModelParentList);

            //-----------------------------------------------------------------------------------------

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

            CheckTVItem(tvItemModelAdded, DBCommandEnum.Created);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

            webMWQMSites = await CSSPReadGzFileService.GetUncompressJSON<WebMWQMSites>(WebTypeEnum.WebMWQMSites, TVItemID);

            TVTextEN = "Modified New Item";
            TVTextFR = "Nouveau Item modifié";

            tvItemModelAdded.TVItemLanguageList[0].TVText = TVTextEN;
            tvItemModelAdded.TVItemLanguageList[1].TVText = TVTextFR;

            var actionTVItemModelModify = await TVItemLocalService.ModifyTVTextLocal(tvItemParent, tvItemModelAdded);
            Assert.Equal(200, ((ObjectResult)actionTVItemModelModify.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModelModify.Result).Value);
            TVItemModel tvItemModelModify = (TVItemModel)((OkObjectResult)actionTVItemModelModify.Result).Value;
            Assert.NotNull(tvItemModelModify);

            CheckTVItem(tvItemModelModify, DBCommandEnum.Created);
            CheckTVItemLanguage(tvItemModelModify, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelModify, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

            tvItemModelParentList = webMWQMSites.TVItemModelParentList;

            tvItemModelParentList.Add(tvItemModelModify);

            CheckDBLocal(tvItemModelParentList);
            CheckLocalJsonFileCreated(tvItemModelParentList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ModifyTVItemLocal_PolSourceSites_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            int TVItemID = 635;

            WebPolSourceSites webPolSourceSites = await CSSPReadGzFileService.GetUncompressJSON<WebPolSourceSites>(WebTypeEnum.WebPolSourceSites, TVItemID);

            TVItem tvItemParent = webPolSourceSites.TVItemModel.TVItem;
            string TVTextEN = "Modify Item";
            string TVTextFR = "Item modifié";

            Assert.NotEmpty(webPolSourceSites.PolSourceSiteModelList);

            PolSourceSiteModel mwqmRunModel = webPolSourceSites.PolSourceSiteModelList[0];

            mwqmRunModel.TVItemModel.TVItemLanguageList[0].TVText = TVTextEN;
            mwqmRunModel.TVItemModel.TVItemLanguageList[1].TVText = TVTextFR;

            TVItemModel tvItemModelToModify = mwqmRunModel.TVItemModel;

            var actionTVItemModel = await TVItemLocalService.ModifyTVTextLocal(tvItemParent, tvItemModelToModify);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            CheckTVItem(tvItemModel, DBCommandEnum.Original);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Modified, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModel, DBCommandEnum.Modified, TVTextFR, LanguageEnum.fr);

            List<TVItemModel> tvItemModelParentList = webPolSourceSites.TVItemModelParentList;

            tvItemModelParentList.Add(tvItemModel);

            CheckDBLocal(tvItemModelParentList);
            CheckLocalJsonFileCreated(tvItemModelParentList);

            //-----------------------------------------------------------------------------------------

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

            CheckTVItem(tvItemModelAdded, DBCommandEnum.Created);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

            webPolSourceSites = await CSSPReadGzFileService.GetUncompressJSON<WebPolSourceSites>(WebTypeEnum.WebPolSourceSites, TVItemID);

            TVTextEN = "Modified New Item";
            TVTextFR = "Nouveau Item modifié";

            tvItemModelAdded.TVItemLanguageList[0].TVText = TVTextEN;
            tvItemModelAdded.TVItemLanguageList[1].TVText = TVTextFR;

            var actionTVItemModelModify = await TVItemLocalService.ModifyTVTextLocal(tvItemParent, tvItemModelAdded);
            Assert.Equal(200, ((ObjectResult)actionTVItemModelModify.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModelModify.Result).Value);
            TVItemModel tvItemModelModify = (TVItemModel)((OkObjectResult)actionTVItemModelModify.Result).Value;
            Assert.NotNull(tvItemModelModify);

            CheckTVItem(tvItemModelModify, DBCommandEnum.Created);
            CheckTVItemLanguage(tvItemModelModify, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelModify, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

            tvItemModelParentList = webPolSourceSites.TVItemModelParentList;

            tvItemModelParentList.Add(tvItemModelModify);

            CheckDBLocal(tvItemModelParentList);
            CheckLocalJsonFileCreated(tvItemModelParentList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ModifyTVItemLocal_Classifications_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            int TVItemID = 635;

            WebSubsector webSubsector = await CSSPReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, TVItemID);

            TVItem tvItemParent = webSubsector.TVItemModel.TVItem;
            string TVTextEN = "Modify Item";
            string TVTextFR = "Item modifié";

            Assert.NotEmpty(webSubsector.TVItemModelClassificationList);

            TVItemModel tvItemModelToModify = webSubsector.TVItemModelClassificationList[0];

            tvItemModelToModify.TVItemLanguageList[0].TVText = TVTextEN;
            tvItemModelToModify.TVItemLanguageList[1].TVText = TVTextFR;

            var actionTVItemModel = await TVItemLocalService.ModifyTVTextLocal(tvItemParent, tvItemModelToModify);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModelToModify);

            CheckTVItem(tvItemModelToModify, DBCommandEnum.Original);
            CheckTVItemLanguage(tvItemModelToModify, DBCommandEnum.Modified, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelToModify, DBCommandEnum.Modified, TVTextFR, LanguageEnum.fr);

            List<TVItemModel> tvItemModelParentList = webSubsector.TVItemModelParentList;

            tvItemModelParentList.Add(tvItemModelToModify);

            CheckDBLocal(tvItemModelParentList);
            CheckLocalJsonFileCreated(tvItemModelParentList);

            //-----------------------------------------------------------------------------------------

            Assert.True(await TVItemLocalServiceSetup(culture));

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

            CheckTVItem(tvItemModelAdded, DBCommandEnum.Created);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

            webSubsector = await CSSPReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, TVItemID);

            TVTextEN = "Modified New Item";
            TVTextFR = "Nouveau Item modifié";

            tvItemModelAdded.TVItemLanguageList[0].TVText = TVTextEN;
            tvItemModelAdded.TVItemLanguageList[1].TVText = TVTextFR;

            var actionTVItemModelModify = await TVItemLocalService.ModifyTVTextLocal(tvItemParent, tvItemModelAdded);
            Assert.Equal(200, ((ObjectResult)actionTVItemModelModify.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModelModify.Result).Value);
            TVItemModel tvItemModelModify = (TVItemModel)((OkObjectResult)actionTVItemModelModify.Result).Value;
            Assert.NotNull(tvItemModelModify);

            CheckTVItem(tvItemModelModify, DBCommandEnum.Created);
            CheckTVItemLanguage(tvItemModelModify, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelModify, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

            tvItemModelParentList = webSubsector.TVItemModelParentList;

            tvItemModelParentList.Add(tvItemModelModify);

            CheckDBLocal(tvItemModelParentList);
            CheckLocalJsonFileCreated(tvItemModelParentList);
        }
    }
}
