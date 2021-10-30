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
        public async Task DeleteTVItemLocal_File_Root_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, 0);

            TVItem tvItemParent = webRoot.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.File;
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
        public async Task DeleteTVItemLocal_File_Country_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            int TVItemID = 5;

            WebCountry webCountry = await CSSPReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, TVItemID);

            TVItem tvItemParent = webCountry.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.File;
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
        public async Task DeleteTVItemLocal_File_Province_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            int TVItemID = 7;

            WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

            TVItem tvItemParent = webProvince.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.File;
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
        public async Task DeleteTVItemLocal_File_Municipality_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            int TVItemID = 27764;

            WebMunicipality webMunicipality = await CSSPReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, TVItemID);

            TVItem tvItemParent = webMunicipality.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.File;
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
        public async Task DeleteTVItemLocal_File_Infrastructure_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            int TVItemID = 27764;

            WebMunicipality webMunicipality = await CSSPReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, TVItemID);

            TVItem tvItemParent = webMunicipality.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.File;
            string TVTextEN = "New Item";
            string TVTextFR = "Nouveau Item";

            InfrastructureModel infrastructureModel = webMunicipality.InfrastructureModelList[0];

            tvItemParent = infrastructureModel.TVItemModel.TVItem;

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

            tvItemModelParentList.Add(infrastructureModel.TVItemModel);
            tvItemModelParentList.Add(tvItemModel);

            CheckDBLocal(tvItemModelParentList);
            CheckLocalJsonFileCreated(tvItemModelParentList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DeleteTVItemLocal_File_MikeScenario_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            int TVItemID = 27764;

            WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, TVItemID);

            TVItem tvItemParent = webMikeScenarios.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.File;
            string TVTextEN = "New Item";
            string TVTextFR = "Nouveau Item";

            MikeScenarioModel mikeScenarioModel = webMikeScenarios.MikeScenarioModelList[0];

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
        public async Task DeleteTVItemLocal_File_Area_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            int TVItemID = 629;

            WebArea webArea = await CSSPReadGzFileService.GetUncompressJSON<WebArea>(WebTypeEnum.WebArea, TVItemID);

            TVItem tvItemParent = webArea.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.File;
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
        public async Task DeleteTVItemLocal_File_Sector_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            int TVItemID = 633;

            WebSector webSector = await CSSPReadGzFileService.GetUncompressJSON<WebSector>(WebTypeEnum.WebSector, TVItemID);

            TVItem tvItemParent = webSector.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.File;
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
        public async Task DeleteTVItemLocal_File_Subsector_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            int TVItemID = 635;

            WebSubsector webSubsector = await CSSPReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, TVItemID);

            TVItem tvItemParent = webSubsector.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.File;
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
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DeleteTVItemLocal_File_MWQMSite_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            int TVItemID = 635;

            WebMWQMSites webMWQMSites = await CSSPReadGzFileService.GetUncompressJSON<WebMWQMSites>(WebTypeEnum.WebMWQMSites, TVItemID);

            TVItem tvItemParent = webMWQMSites.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.File;
            string TVTextEN = "New Item";
            string TVTextFR = "Nouveau Item";

            MWQMSiteModel mwqmSiteModel = webMWQMSites.MWQMSiteModelList[0];

            tvItemParent = mwqmSiteModel.TVItemModel.TVItem;

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

            tvItemModelParentList.Add(mwqmSiteModel.TVItemModel);
            tvItemModelParentList.Add(tvItemModel);

            CheckDBLocal(tvItemModelParentList);
            CheckLocalJsonFileCreated(tvItemModelParentList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DeleteTVItemLocal_File_PolSourceSite_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            int TVItemID = 635;

            WebPolSourceSites webPolSourceSites = await CSSPReadGzFileService.GetUncompressJSON<WebPolSourceSites>(WebTypeEnum.WebPolSourceSites, TVItemID);

            TVItem tvItemParent = webPolSourceSites.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.File;
            string TVTextEN = "New Item";
            string TVTextFR = "Nouveau Item";

            PolSourceSiteModel mwqmSiteModel = webPolSourceSites.PolSourceSiteModelList[0];

            tvItemParent = mwqmSiteModel.TVItemModel.TVItem;

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

            tvItemModelParentList.Add(mwqmSiteModel.TVItemModel);
            tvItemModelParentList.Add(tvItemModel);

            CheckDBLocal(tvItemModelParentList);
            CheckLocalJsonFileCreated(tvItemModelParentList);
        }
    }
}
