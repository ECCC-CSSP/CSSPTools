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
    public partial class MapInfoLocalServiceTest : CSSPDBLocalServiceTest
    {
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddMapInfoLocalFromAverage_Address_Good_Test(string culture)
        {
            Assert.True(await MapInfoLocalServiceSetup(culture));

            // no test needed
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddMapInfoLocalFromAverage_Area_Good_Test(string culture)
        {
            Assert.True(await MapInfoLocalServiceSetup(culture));

            int TVItemID = 7;

            WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

            TVItem tvItemParent = webProvince.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.Area;
            string TVTextEN = "New Item";
            string TVTextFR = "Nouveau Item";

            var actionTVItemModel = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            var actionMapInfoModel = await MapInfoLocalService.AddMapInfoLocalFromAverage(tvItemParent, tvItemModel.TVItem);
            Assert.Equal(200, ((ObjectResult)actionMapInfoModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMapInfoModel.Result).Value);
            List<MapInfoLocalModel> mapInfoLocalModelList = (List<MapInfoLocalModel>)((OkObjectResult)actionMapInfoModel.Result).Value;
            Assert.NotNull(mapInfoLocalModelList);
            Assert.NotEmpty(mapInfoLocalModelList);
            Assert.Equal(2, mapInfoLocalModelList.Count);

            foreach (MapInfoLocalModel mapInfoLocalModel in mapInfoLocalModelList)
            {
                CheckCreatedMapInfoAndMapInfoPointList(mapInfoLocalModel);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddMapInfoLocalFromAverage_Classification_Good_Test(string culture)
        {
            Assert.True(await MapInfoLocalServiceSetup(culture));

            int TVItemID = 635;

            WebSubsector webSubsector = await CSSPReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, TVItemID);

            TVItem tvItemParent = webSubsector.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.Classification;
            string TVTextEN = "New Item";
            string TVTextFR = "Nouveau Item";

            var actionTVItemModel = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            var actionMapInfoModel = await MapInfoLocalService.AddMapInfoLocalFromAverage(tvItemParent, tvItemModel.TVItem);
            Assert.Equal(200, ((ObjectResult)actionMapInfoModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMapInfoModel.Result).Value);
            List<MapInfoLocalModel> mapInfoLocalModelList = (List<MapInfoLocalModel>)((OkObjectResult)actionMapInfoModel.Result).Value;
            Assert.NotNull(mapInfoLocalModelList);
            Assert.NotEmpty(mapInfoLocalModelList);
            Assert.Equal(2, mapInfoLocalModelList.Count);

            foreach (MapInfoLocalModel mapInfoLocalModel in mapInfoLocalModelList)
            {
                CheckCreatedMapInfoAndMapInfoPointList(mapInfoLocalModel);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddMapInfoLocalFromAverage_ClimateSite_Good_Test(string culture)
        {
            Assert.True(await MapInfoLocalServiceSetup(culture));

            int TVItemID = 7;

            WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

            TVItem tvItemParent = webProvince.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.ClimateSite;
            string TVTextEN = "New Item";
            string TVTextFR = "Nouveau Item";

            var actionTVItemModel = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            var actionMapInfoModel = await MapInfoLocalService.AddMapInfoLocalFromAverage(tvItemParent, tvItemModel.TVItem);
            Assert.Equal(200, ((ObjectResult)actionMapInfoModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMapInfoModel.Result).Value);
            List<MapInfoLocalModel> mapInfoLocalModelList = (List<MapInfoLocalModel>)((OkObjectResult)actionMapInfoModel.Result).Value;
            Assert.NotNull(mapInfoLocalModelList);
            Assert.NotEmpty(mapInfoLocalModelList);
            Assert.Single(mapInfoLocalModelList);

            foreach (MapInfoLocalModel mapInfoLocalModel in mapInfoLocalModelList)
            {
                CheckCreatedMapInfoAndMapInfoPointList(mapInfoLocalModel);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddMapInfoLocalFromAverage_Country_Good_Test(string culture)
        {
            Assert.True(await MapInfoLocalServiceSetup(culture));

            WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, 0);

            TVItem tvItemParent = webRoot.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.Country;
            string TVTextEN = "New Item";
            string TVTextFR = "Nouveau Item";

            var actionTVItemModel = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            var actionMapInfoModel = await MapInfoLocalService.AddMapInfoLocalFromAverage(tvItemParent, tvItemModel.TVItem);
            Assert.Equal(200, ((ObjectResult)actionMapInfoModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMapInfoModel.Result).Value);
            List<MapInfoLocalModel> mapInfoLocalModelList = (List<MapInfoLocalModel>)((OkObjectResult)actionMapInfoModel.Result).Value;
            Assert.NotNull(mapInfoLocalModelList);
            Assert.NotEmpty(mapInfoLocalModelList);
            Assert.Equal(2, mapInfoLocalModelList.Count);

            foreach (MapInfoLocalModel mapInfoLocalModel in mapInfoLocalModelList)
            {
                CheckCreatedMapInfoAndMapInfoPointList(mapInfoLocalModel);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddMapInfoLocalFromAverage_Email_Good_Test(string culture)
        {
            Assert.True(await MapInfoLocalServiceSetup(culture));

            // no test needed
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddMapInfoLocalFromAverage_EmailDistributionList_Good_Test(string culture)
        {
            Assert.True(await MapInfoLocalServiceSetup(culture));

            // no test needed
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddMapInfoLocalFromAverage_File_Area_Good_Test(string culture)
        {
            Assert.True(await MapInfoLocalServiceSetup(culture));

            int TVItemID = 629;

            WebArea webArea = await CSSPReadGzFileService.GetUncompressJSON<WebArea>(WebTypeEnum.WebArea, TVItemID);

            TVItem tvItemParent = webArea.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.File;
            string TVTextEN = "New Item";
            string TVTextFR = "Nouveau Item";

            var actionTVItemModel = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            var actionMapInfoModel = await MapInfoLocalService.AddMapInfoLocalFromAverage(tvItemParent, tvItemModel.TVItem);
            Assert.Equal(200, ((ObjectResult)actionMapInfoModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMapInfoModel.Result).Value);
            List<MapInfoLocalModel> mapInfoLocalModelList = (List<MapInfoLocalModel>)((OkObjectResult)actionMapInfoModel.Result).Value;
            Assert.NotNull(mapInfoLocalModelList);
            Assert.NotEmpty(mapInfoLocalModelList);
            Assert.Single(mapInfoLocalModelList);

            foreach (MapInfoLocalModel mapInfoLocalModel in mapInfoLocalModelList)
            {
                CheckCreatedMapInfoAndMapInfoPointList(mapInfoLocalModel);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddMapInfoLocalFromAverage_File_Country_Good_Test(string culture)
        {
            Assert.True(await MapInfoLocalServiceSetup(culture));

            int TVItemID = 5;

            WebCountry webCountry = await CSSPReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, TVItemID);

            TVItem tvItemParent = webCountry.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.File;
            string TVTextEN = "New Item";
            string TVTextFR = "Nouveau Item";

            var actionTVItemModel = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            var actionMapInfoModel = await MapInfoLocalService.AddMapInfoLocalFromAverage(tvItemParent, tvItemModel.TVItem);
            Assert.Equal(200, ((ObjectResult)actionMapInfoModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMapInfoModel.Result).Value);
            List<MapInfoLocalModel> mapInfoLocalModelList = (List<MapInfoLocalModel>)((OkObjectResult)actionMapInfoModel.Result).Value;
            Assert.NotNull(mapInfoLocalModelList);
            Assert.NotEmpty(mapInfoLocalModelList);
            Assert.Single(mapInfoLocalModelList);

            foreach (MapInfoLocalModel mapInfoLocalModel in mapInfoLocalModelList)
            {
                CheckCreatedMapInfoAndMapInfoPointList(mapInfoLocalModel);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddMapInfoLocalFromAverage_File_Infrastructure_Good_Test(string culture)
        {
            Assert.True(await MapInfoLocalServiceSetup(culture));

            int TVItemID = 27764;

            WebMunicipality webMunicipality = await CSSPReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, TVItemID);

            TVItem tvItemParent = webMunicipality.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.File;
            string TVTextEN = "New Item";
            string TVTextFR = "Nouveau Item";

            Assert.NotEmpty(webMunicipality.InfrastructureModelList);

            InfrastructureModel infrastructureModel = webMunicipality.InfrastructureModelList[0];

            tvItemParent = infrastructureModel.TVItemModel.TVItem;

            var actionTVItemModel = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            var actionMapInfoModel = await MapInfoLocalService.AddMapInfoLocalFromAverage(tvItemParent, tvItemModel.TVItem);
            Assert.Equal(200, ((ObjectResult)actionMapInfoModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMapInfoModel.Result).Value);
            List<MapInfoLocalModel> mapInfoLocalModelList = (List<MapInfoLocalModel>)((OkObjectResult)actionMapInfoModel.Result).Value;
            Assert.NotNull(mapInfoLocalModelList);
            Assert.NotEmpty(mapInfoLocalModelList);
            Assert.Single(mapInfoLocalModelList);

            foreach (MapInfoLocalModel mapInfoLocalModel in mapInfoLocalModelList)
            {
                CheckCreatedMapInfoAndMapInfoPointList(mapInfoLocalModel);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddMapInfoLocalFromAverage_File_Province_Good_Test(string culture)
        {
            Assert.True(await MapInfoLocalServiceSetup(culture));

            int TVItemID = 7;

            WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

            TVItem tvItemParent = webProvince.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.File;
            string TVTextEN = "New Item";
            string TVTextFR = "Nouveau Item";

            var actionTVItemModel = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            var actionMapInfoModel = await MapInfoLocalService.AddMapInfoLocalFromAverage(tvItemParent, tvItemModel.TVItem);
            Assert.Equal(200, ((ObjectResult)actionMapInfoModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMapInfoModel.Result).Value);
            List<MapInfoLocalModel> mapInfoLocalModelList = (List<MapInfoLocalModel>)((OkObjectResult)actionMapInfoModel.Result).Value;
            Assert.NotNull(mapInfoLocalModelList);
            Assert.NotEmpty(mapInfoLocalModelList);
            Assert.Single(mapInfoLocalModelList);

            foreach (MapInfoLocalModel mapInfoLocalModel in mapInfoLocalModelList)
            {
                CheckCreatedMapInfoAndMapInfoPointList(mapInfoLocalModel);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddMapInfoLocalFromAverage_File_MikeScenario_Good_Test(string culture)
        {
            Assert.True(await MapInfoLocalServiceSetup(culture));

            int TVItemID = 27764;

            WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, TVItemID);

            TVItem tvItemParent = webMikeScenarios.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.File;
            string TVTextEN = "New Item";
            string TVTextFR = "Nouveau Item";

            Assert.NotEmpty(webMikeScenarios.MikeScenarioModelList);

            MikeScenarioModel mikeScenarioModel = webMikeScenarios.MikeScenarioModelList[0];

            tvItemParent = mikeScenarioModel.TVItemModel.TVItem;

            var actionTVItemModel = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            var actionMapInfoModel = await MapInfoLocalService.AddMapInfoLocalFromAverage(tvItemParent, tvItemModel.TVItem);
            Assert.Equal(200, ((ObjectResult)actionMapInfoModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMapInfoModel.Result).Value);
            List<MapInfoLocalModel> mapInfoLocalModelList = (List<MapInfoLocalModel>)((OkObjectResult)actionMapInfoModel.Result).Value;
            Assert.NotNull(mapInfoLocalModelList);
            Assert.NotEmpty(mapInfoLocalModelList);
            Assert.Single(mapInfoLocalModelList);

            foreach (MapInfoLocalModel mapInfoLocalModel in mapInfoLocalModelList)
            {
                CheckCreatedMapInfoAndMapInfoPointList(mapInfoLocalModel);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddMapInfoLocalFromAverage_File_Municipality_Good_Test(string culture)
        {
            Assert.True(await MapInfoLocalServiceSetup(culture));

            int TVItemID = 27764;

            WebMunicipality webMunicipality = await CSSPReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, TVItemID);

            TVItem tvItemParent = webMunicipality.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.File;
            string TVTextEN = "New Item";
            string TVTextFR = "Nouveau Item";

            var actionTVItemModel = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            var actionMapInfoModel = await MapInfoLocalService.AddMapInfoLocalFromAverage(tvItemParent, tvItemModel.TVItem);
            Assert.Equal(200, ((ObjectResult)actionMapInfoModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMapInfoModel.Result).Value);
            List<MapInfoLocalModel> mapInfoLocalModelList = (List<MapInfoLocalModel>)((OkObjectResult)actionMapInfoModel.Result).Value;
            Assert.NotNull(mapInfoLocalModelList);
            Assert.NotEmpty(mapInfoLocalModelList);
            Assert.Single(mapInfoLocalModelList);

            foreach (MapInfoLocalModel mapInfoLocalModel in mapInfoLocalModelList)
            {
                CheckCreatedMapInfoAndMapInfoPointList(mapInfoLocalModel);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddMapInfoLocalFromAverage_File_MWQMSite_Good_Test(string culture)
        {
            Assert.True(await MapInfoLocalServiceSetup(culture));

            int TVItemID = 635;

            WebMWQMSites webMWQMSites = await CSSPReadGzFileService.GetUncompressJSON<WebMWQMSites>(WebTypeEnum.WebMWQMSites, TVItemID);

            TVItem tvItemParent = webMWQMSites.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.File;
            string TVTextEN = "New Item";
            string TVTextFR = "Nouveau Item";

            Assert.NotEmpty(webMWQMSites.MWQMSiteModelList);

            MWQMSiteModel mwqmSiteModel = webMWQMSites.MWQMSiteModelList[0];

            tvItemParent = mwqmSiteModel.TVItemModel.TVItem;

            var actionTVItemModel = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            var actionMapInfoModel = await MapInfoLocalService.AddMapInfoLocalFromAverage(tvItemParent, tvItemModel.TVItem);
            Assert.Equal(200, ((ObjectResult)actionMapInfoModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMapInfoModel.Result).Value);
            List<MapInfoLocalModel> mapInfoLocalModelList = (List<MapInfoLocalModel>)((OkObjectResult)actionMapInfoModel.Result).Value;
            Assert.NotNull(mapInfoLocalModelList);
            Assert.NotEmpty(mapInfoLocalModelList);
            Assert.Single(mapInfoLocalModelList);

            foreach (MapInfoLocalModel mapInfoLocalModel in mapInfoLocalModelList)
            {
                CheckCreatedMapInfoAndMapInfoPointList(mapInfoLocalModel);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddMapInfoLocalFromAverage_File_PolSourceSite_Good_Test(string culture)
        {
            Assert.True(await MapInfoLocalServiceSetup(culture));

            int TVItemID = 635;

            WebPolSourceSites webPolSourceSites = await CSSPReadGzFileService.GetUncompressJSON<WebPolSourceSites>(WebTypeEnum.WebPolSourceSites, TVItemID);

            TVItem tvItemParent = webPolSourceSites.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.File;
            string TVTextEN = "New Item";
            string TVTextFR = "Nouveau Item";

            Assert.NotEmpty(webPolSourceSites.PolSourceSiteModelList);

            PolSourceSiteModel mwqmSiteModel = webPolSourceSites.PolSourceSiteModelList[0];

            tvItemParent = mwqmSiteModel.TVItemModel.TVItem;

            var actionTVItemModel = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            var actionMapInfoModel = await MapInfoLocalService.AddMapInfoLocalFromAverage(tvItemParent, tvItemModel.TVItem);
            Assert.Equal(200, ((ObjectResult)actionMapInfoModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMapInfoModel.Result).Value);
            List<MapInfoLocalModel> mapInfoLocalModelList = (List<MapInfoLocalModel>)((OkObjectResult)actionMapInfoModel.Result).Value;
            Assert.NotNull(mapInfoLocalModelList);
            Assert.NotEmpty(mapInfoLocalModelList);
            Assert.Single(mapInfoLocalModelList);

            foreach (MapInfoLocalModel mapInfoLocalModel in mapInfoLocalModelList)
            {
                CheckCreatedMapInfoAndMapInfoPointList(mapInfoLocalModel);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddMapInfoLocalFromAverage_File_Root_Good_Test(string culture)
        {
            Assert.True(await MapInfoLocalServiceSetup(culture));

            int TVItemID = 0;

            WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, TVItemID);

            TVItem tvItemParent = webRoot.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.File;
            string TVTextEN = "New Item";
            string TVTextFR = "Nouveau Item";

            var actionTVItemModel = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            var actionMapInfoModel = await MapInfoLocalService.AddMapInfoLocalFromAverage(tvItemParent, tvItemModel.TVItem);
            Assert.Equal(200, ((ObjectResult)actionMapInfoModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMapInfoModel.Result).Value);
            List<MapInfoLocalModel> mapInfoLocalModelList = (List<MapInfoLocalModel>)((OkObjectResult)actionMapInfoModel.Result).Value;
            Assert.NotNull(mapInfoLocalModelList);
            Assert.NotEmpty(mapInfoLocalModelList);
            Assert.Single(mapInfoLocalModelList);

            foreach (MapInfoLocalModel mapInfoLocalModel in mapInfoLocalModelList)
            {
                CheckCreatedMapInfoAndMapInfoPointList(mapInfoLocalModel);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddMapInfoLocalFromAverage_File_Sector_Good_Test(string culture)
        {
            Assert.True(await MapInfoLocalServiceSetup(culture));

            int TVItemID = 633;

            WebSector webSector = await CSSPReadGzFileService.GetUncompressJSON<WebSector>(WebTypeEnum.WebSector, TVItemID);

            TVItem tvItemParent = webSector.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.File;
            string TVTextEN = "New Item";
            string TVTextFR = "Nouveau Item";

            var actionTVItemModel = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            var actionMapInfoModel = await MapInfoLocalService.AddMapInfoLocalFromAverage(tvItemParent, tvItemModel.TVItem);
            Assert.Equal(200, ((ObjectResult)actionMapInfoModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMapInfoModel.Result).Value);
            List<MapInfoLocalModel> mapInfoLocalModelList = (List<MapInfoLocalModel>)((OkObjectResult)actionMapInfoModel.Result).Value;
            Assert.NotNull(mapInfoLocalModelList);
            Assert.NotEmpty(mapInfoLocalModelList);
            Assert.Single(mapInfoLocalModelList);

            foreach (MapInfoLocalModel mapInfoLocalModel in mapInfoLocalModelList)
            {
                CheckCreatedMapInfoAndMapInfoPointList(mapInfoLocalModel);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddMapInfoLocalFromAverage_File_Subsector_Good_Test(string culture)
        {
            Assert.True(await MapInfoLocalServiceSetup(culture));

            int TVItemID = 635;

            WebSubsector webSubsector = await CSSPReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, TVItemID);

            TVItem tvItemParent = webSubsector.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.File;
            string TVTextEN = "New Item";
            string TVTextFR = "Nouveau Item";

            var actionTVItemModel = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            var actionMapInfoModel = await MapInfoLocalService.AddMapInfoLocalFromAverage(tvItemParent, tvItemModel.TVItem);
            Assert.Equal(200, ((ObjectResult)actionMapInfoModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMapInfoModel.Result).Value);
            List<MapInfoLocalModel> mapInfoLocalModelList = (List<MapInfoLocalModel>)((OkObjectResult)actionMapInfoModel.Result).Value;
            Assert.NotNull(mapInfoLocalModelList);
            Assert.NotEmpty(mapInfoLocalModelList);
            Assert.Single(mapInfoLocalModelList);

            foreach (MapInfoLocalModel mapInfoLocalModel in mapInfoLocalModelList)
            {
                CheckCreatedMapInfoAndMapInfoPointList(mapInfoLocalModel);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddMapInfoLocalFromAverage_HydrometricSite_Good_Test(string culture)
        {
            Assert.True(await MapInfoLocalServiceSetup(culture));

            int TVItemID = 7;

            WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

            TVItem tvItemParent = webProvince.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.HydrometricSite;
            string TVTextEN = "New Item";
            string TVTextFR = "Nouveau Item";

            var actionTVItemModel = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            var actionMapInfoModel = await MapInfoLocalService.AddMapInfoLocalFromAverage(tvItemParent, tvItemModel.TVItem);
            Assert.Equal(200, ((ObjectResult)actionMapInfoModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMapInfoModel.Result).Value);
            List<MapInfoLocalModel> mapInfoLocalModelList = (List<MapInfoLocalModel>)((OkObjectResult)actionMapInfoModel.Result).Value;
            Assert.NotNull(mapInfoLocalModelList);
            Assert.NotEmpty(mapInfoLocalModelList);
            Assert.Single(mapInfoLocalModelList);

            foreach (MapInfoLocalModel mapInfoLocalModel in mapInfoLocalModelList)
            {
                CheckCreatedMapInfoAndMapInfoPointList(mapInfoLocalModel);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddMapInfoLocalFromAverage_Infrastructure_Good_Test(string culture)
        {
            Assert.True(await MapInfoLocalServiceSetup(culture));

            int TVItemID = 27764;

            WebMunicipality webMunicipality = await CSSPReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, TVItemID);

            TVItem tvItemParent = webMunicipality.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.Infrastructure;
            string TVTextEN = "New Item";
            string TVTextFR = "Nouveau Item";

            var actionTVItemModel = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            var actionMapInfoModel = await MapInfoLocalService.AddMapInfoLocalFromAverage(tvItemParent, tvItemModel.TVItem);
            Assert.Equal(200, ((ObjectResult)actionMapInfoModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMapInfoModel.Result).Value);
            List<MapInfoLocalModel> mapInfoLocalModelList = (List<MapInfoLocalModel>)((OkObjectResult)actionMapInfoModel.Result).Value;
            Assert.NotNull(mapInfoLocalModelList);
            Assert.NotEmpty(mapInfoLocalModelList);
            Assert.Equal(2, mapInfoLocalModelList.Count);

            foreach (MapInfoLocalModel mapInfoLocalModel in mapInfoLocalModelList)
            {
                CheckCreatedMapInfoAndMapInfoPointList(mapInfoLocalModel);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddMapInfoLocalFromAverage_MikeBoundaryConditionMesh_Good_Test(string culture)
        {
            Assert.True(await MapInfoLocalServiceSetup(culture));

            int TVItemID = 27764;

            WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, TVItemID);

            TVItem tvItemParent = webMikeScenarios.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.MikeBoundaryConditionMesh;
            string TVTextEN = "New Item";
            string TVTextFR = "Nouveau Item";

            Assert.NotEmpty(webMikeScenarios.MikeScenarioModelList);

            MikeScenarioModel mikeScenarioModel = webMikeScenarios.MikeScenarioModelList[0];

            tvItemParent = mikeScenarioModel.TVItemModel.TVItem;

            var actionTVItemModel = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            var actionMapInfoModel = await MapInfoLocalService.AddMapInfoLocalFromAverage(tvItemParent, tvItemModel.TVItem);
            Assert.Equal(200, ((ObjectResult)actionMapInfoModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMapInfoModel.Result).Value);
            List<MapInfoLocalModel> mapInfoLocalModelList = (List<MapInfoLocalModel>)((OkObjectResult)actionMapInfoModel.Result).Value;
            Assert.NotNull(mapInfoLocalModelList);
            Assert.NotEmpty(mapInfoLocalModelList);
            Assert.Single(mapInfoLocalModelList);

            foreach (MapInfoLocalModel mapInfoLocalModel in mapInfoLocalModelList)
            {
                CheckCreatedMapInfoAndMapInfoPointList(mapInfoLocalModel);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddMapInfoLocalFromAverage_MikeBoundaryConditionWebTide_Good_Test(string culture)
        {
            Assert.True(await MapInfoLocalServiceSetup(culture));

            int TVItemID = 27764;

            WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, TVItemID);

            TVItem tvItemParent = webMikeScenarios.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.MikeBoundaryConditionWebTide;
            string TVTextEN = "New Item";
            string TVTextFR = "Nouveau Item";

            Assert.NotEmpty(webMikeScenarios.MikeScenarioModelList);

            MikeScenarioModel mikeScenarioModel = webMikeScenarios.MikeScenarioModelList[0];

            tvItemParent = mikeScenarioModel.TVItemModel.TVItem;

            var actionTVItemModel = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            var actionMapInfoModel = await MapInfoLocalService.AddMapInfoLocalFromAverage(tvItemParent, tvItemModel.TVItem);
            Assert.Equal(200, ((ObjectResult)actionMapInfoModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMapInfoModel.Result).Value);
            List<MapInfoLocalModel> mapInfoLocalModelList = (List<MapInfoLocalModel>)((OkObjectResult)actionMapInfoModel.Result).Value;
            Assert.NotNull(mapInfoLocalModelList);
            Assert.NotEmpty(mapInfoLocalModelList);
            Assert.Single(mapInfoLocalModelList);

            foreach (MapInfoLocalModel mapInfoLocalModel in mapInfoLocalModelList)
            {
                CheckCreatedMapInfoAndMapInfoPointList(mapInfoLocalModel);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddMapInfoLocalFromAverage_MikeScenario_Good_Test(string culture)
        {
            Assert.True(await MapInfoLocalServiceSetup(culture));

            // no test needed
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddMapInfoLocalFromAverage_MikeSource_Good_Test(string culture)
        {
            Assert.True(await MapInfoLocalServiceSetup(culture));

            int TVItemID = 27764;

            WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, TVItemID);

            TVItem tvItemParent = webMikeScenarios.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.MikeSource;
            string TVTextEN = "New Item";
            string TVTextFR = "Nouveau Item";

            Assert.NotEmpty(webMikeScenarios.MikeScenarioModelList);

            MikeScenarioModel mikeScenarioModel = webMikeScenarios.MikeScenarioModelList[0];

            tvItemParent = mikeScenarioModel.TVItemModel.TVItem;

            var actionTVItemModel = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            var actionMapInfoModel = await MapInfoLocalService.AddMapInfoLocalFromAverage(tvItemParent, tvItemModel.TVItem);
            Assert.Equal(200, ((ObjectResult)actionMapInfoModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMapInfoModel.Result).Value);
            List<MapInfoLocalModel> mapInfoLocalModelList = (List<MapInfoLocalModel>)((OkObjectResult)actionMapInfoModel.Result).Value;
            Assert.NotNull(mapInfoLocalModelList);
            Assert.NotEmpty(mapInfoLocalModelList);
            Assert.Single(mapInfoLocalModelList);

            foreach (MapInfoLocalModel mapInfoLocalModel in mapInfoLocalModelList)
            {
                CheckCreatedMapInfoAndMapInfoPointList(mapInfoLocalModel);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddMapInfoLocalFromAverage_Municipality_Good_Test(string culture)
        {
            Assert.True(await MapInfoLocalServiceSetup(culture));

            int TVItemID = 7;

            WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

            TVItem tvItemParent = webProvince.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.Municipality;
            string TVTextEN = "New Item";
            string TVTextFR = "Nouveau Item";

            var actionTVItemModel = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            var actionMapInfoModel = await MapInfoLocalService.AddMapInfoLocalFromAverage(tvItemParent, tvItemModel.TVItem);
            Assert.Equal(200, ((ObjectResult)actionMapInfoModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMapInfoModel.Result).Value);
            List<MapInfoLocalModel> mapInfoLocalModelList = (List<MapInfoLocalModel>)((OkObjectResult)actionMapInfoModel.Result).Value;
            Assert.NotNull(mapInfoLocalModelList);
            Assert.NotEmpty(mapInfoLocalModelList);
            Assert.Single(mapInfoLocalModelList);

            foreach (MapInfoLocalModel mapInfoLocalModel in mapInfoLocalModelList)
            {
                CheckCreatedMapInfoAndMapInfoPointList(mapInfoLocalModel);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddMapInfoLocalFromAverage_MWQMRun_Good_Test(string culture)
        {
            Assert.True(await MapInfoLocalServiceSetup(culture));

            // no test needed
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddMapInfoLocalFromAverage_MWQMSite_Good_Test(string culture)
        {
            Assert.True(await MapInfoLocalServiceSetup(culture));

            int TVItemID = 635;

            WebSubsector webSubsector = await CSSPReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, TVItemID);

            TVItem tvItemParent = webSubsector.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.MWQMSite;
            string TVTextEN = "New Item";
            string TVTextFR = "Nouveau Item";

            var actionTVItemModel = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            var actionMapInfoModel = await MapInfoLocalService.AddMapInfoLocalFromAverage(tvItemParent, tvItemModel.TVItem);
            Assert.Equal(200, ((ObjectResult)actionMapInfoModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMapInfoModel.Result).Value);
            List<MapInfoLocalModel> mapInfoLocalModelList = (List<MapInfoLocalModel>)((OkObjectResult)actionMapInfoModel.Result).Value;
            Assert.NotNull(mapInfoLocalModelList);
            Assert.NotEmpty(mapInfoLocalModelList);
            Assert.Single(mapInfoLocalModelList);

            foreach (MapInfoLocalModel mapInfoLocalModel in mapInfoLocalModelList)
            {
                CheckCreatedMapInfoAndMapInfoPointList(mapInfoLocalModel);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddMapInfoLocalFromAverage_PolSourceSite_Good_Test(string culture)
        {
            Assert.True(await MapInfoLocalServiceSetup(culture));

            int TVItemID = 635;

            WebSubsector webSubsector = await CSSPReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, TVItemID);

            TVItem tvItemParent = webSubsector.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.PolSourceSite;
            string TVTextEN = "New Item";
            string TVTextFR = "Nouveau Item";

            var actionTVItemModel = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            var actionMapInfoModel = await MapInfoLocalService.AddMapInfoLocalFromAverage(tvItemParent, tvItemModel.TVItem);
            Assert.Equal(200, ((ObjectResult)actionMapInfoModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMapInfoModel.Result).Value);
            List<MapInfoLocalModel> mapInfoLocalModelList = (List<MapInfoLocalModel>)((OkObjectResult)actionMapInfoModel.Result).Value;
            Assert.NotNull(mapInfoLocalModelList);
            Assert.NotEmpty(mapInfoLocalModelList);
            Assert.Single(mapInfoLocalModelList);

            foreach (MapInfoLocalModel mapInfoLocalModel in mapInfoLocalModelList)
            {
                CheckCreatedMapInfoAndMapInfoPointList(mapInfoLocalModel);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddMapInfoLocalFromAverage_Province_Good_Test(string culture)
        {
            Assert.True(await MapInfoLocalServiceSetup(culture));

            int TVItemID = 5;

            WebCountry webCountry = await CSSPReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, TVItemID);

            TVItem tvItemParent = webCountry.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.Province;
            string TVTextEN = "New Item";
            string TVTextFR = "Nouveau Item";

            var actionTVItemModel = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            var actionMapInfoModel = await MapInfoLocalService.AddMapInfoLocalFromAverage(tvItemParent, tvItemModel.TVItem);
            Assert.Equal(200, ((ObjectResult)actionMapInfoModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMapInfoModel.Result).Value);
            List<MapInfoLocalModel> mapInfoLocalModelList = (List<MapInfoLocalModel>)((OkObjectResult)actionMapInfoModel.Result).Value;
            Assert.NotNull(mapInfoLocalModelList);
            Assert.NotEmpty(mapInfoLocalModelList);
            Assert.Equal(2, mapInfoLocalModelList.Count);

            foreach (MapInfoLocalModel mapInfoLocalModel in mapInfoLocalModelList)
            {
                CheckCreatedMapInfoAndMapInfoPointList(mapInfoLocalModel);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddMapInfoLocalFromAverage_RainExceedance_Good_Test(string culture)
        {
            Assert.True(await MapInfoLocalServiceSetup(culture));

            // no test needed
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddMapInfoLocalFromAverage_SamplingPlan_Good_Test(string culture)
        {
            Assert.True(await MapInfoLocalServiceSetup(culture));

            // no test needed
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddMapInfoLocalFromAverage_Sector_Good_Test(string culture)
        {
            Assert.True(await MapInfoLocalServiceSetup(culture));

            int TVItemID = 629;

            WebArea webArea = await CSSPReadGzFileService.GetUncompressJSON<WebArea>(WebTypeEnum.WebArea, TVItemID);

            TVItem tvItemParent = webArea.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.Sector;
            string TVTextEN = "New Item";
            string TVTextFR = "Nouveau Item";

            var actionTVItemModel = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            var actionMapInfoModel = await MapInfoLocalService.AddMapInfoLocalFromAverage(tvItemParent, tvItemModel.TVItem);
            Assert.Equal(200, ((ObjectResult)actionMapInfoModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMapInfoModel.Result).Value);
            List<MapInfoLocalModel> mapInfoLocalModelList = (List<MapInfoLocalModel>)((OkObjectResult)actionMapInfoModel.Result).Value;
            Assert.NotNull(mapInfoLocalModelList);
            Assert.NotEmpty(mapInfoLocalModelList);
            Assert.Equal(2, mapInfoLocalModelList.Count);

            foreach (MapInfoLocalModel mapInfoLocalModel in mapInfoLocalModelList)
            {
                CheckCreatedMapInfoAndMapInfoPointList(mapInfoLocalModel);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddMapInfoLocalFromAverage_Subsector_Good_Test(string culture)
        {
            Assert.True(await MapInfoLocalServiceSetup(culture));

            int TVItemID = 633;

            WebSector webSector = await CSSPReadGzFileService.GetUncompressJSON<WebSector>(WebTypeEnum.WebSector, TVItemID);

            TVItem tvItemParent = webSector.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.Subsector;
            string TVTextEN = "New Item";
            string TVTextFR = "Nouveau Item";

            var actionTVItemModel = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            var actionMapInfoModel = await MapInfoLocalService.AddMapInfoLocalFromAverage(tvItemParent, tvItemModel.TVItem);
            Assert.Equal(200, ((ObjectResult)actionMapInfoModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMapInfoModel.Result).Value);
            List<MapInfoLocalModel> mapInfoLocalModelList = (List<MapInfoLocalModel>)((OkObjectResult)actionMapInfoModel.Result).Value;
            Assert.NotNull(mapInfoLocalModelList);
            Assert.NotEmpty(mapInfoLocalModelList);
            Assert.Equal(2, mapInfoLocalModelList.Count);

            foreach (MapInfoLocalModel mapInfoLocalModel in mapInfoLocalModelList)
            {
                CheckCreatedMapInfoAndMapInfoPointList(mapInfoLocalModel);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddMapInfoLocalFromAverage_Tel_Good_Test(string culture)
        {
            Assert.True(await MapInfoLocalServiceSetup(culture));

            // no test needed
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddMapInfoLocalFromAverage_TideSite_Good_Test(string culture)
        {
            Assert.True(await MapInfoLocalServiceSetup(culture));

            int TVItemID = 7;

            WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

            TVItem tvItemParent = webProvince.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.TideSite;
            string TVTextEN = "New Item";
            string TVTextFR = "Nouveau Item";

            var actionTVItemModel = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
            TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(tvItemModel);

            var actionMapInfoModel = await MapInfoLocalService.AddMapInfoLocalFromAverage(tvItemParent, tvItemModel.TVItem);
            Assert.Equal(200, ((ObjectResult)actionMapInfoModel.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMapInfoModel.Result).Value);
            List<MapInfoLocalModel> mapInfoLocalModelList = (List<MapInfoLocalModel>)((OkObjectResult)actionMapInfoModel.Result).Value;
            Assert.NotNull(mapInfoLocalModelList);
            Assert.NotEmpty(mapInfoLocalModelList);
            Assert.Single(mapInfoLocalModelList);

            foreach (MapInfoLocalModel mapInfoLocalModel in mapInfoLocalModelList)
            {
                CheckCreatedMapInfoAndMapInfoPointList(mapInfoLocalModel);
            }
        }
    }
}
