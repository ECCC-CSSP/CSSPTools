///* 
// *  Manually Edited
// *  
// */

//using CSSPCultureServices.Resources;
//using CSSPDBModels;
//using CSSPEnums;
//using CSSPHelperModels;
//using CSSPReadGzFileServices;
//using CSSPWebModels;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Threading.Tasks;
//using Xunit;
//using System.Text.Json;
//using ManageServices;

//namespace CSSPDBLocalServices.Tests
//{
//    public partial class TVItemLocalServiceTest : CSSPDBLocalServiceTest
//    {
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task ModifyTVItemLocal_Root_Country_Good_Test(string culture)
//        {
//            Assert.True(await TVItemLocalServiceSetup(culture));

//            WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, 0);

//            TVItem tvItemParent = webRoot.TVItemModel.TVItem;
//            TVTypeEnum tvType = TVTypeEnum.Country;
//            string TVTextEN = "New Item";
//            string TVTextFR = "Nouveau Item";

//            TVItemModel tvItemModel = await TVItemLocalService.ModifyTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
//            Assert.NotNull(tvItemModel);

//            CheckNewTVItemAndTVItemLanguageList(tvItemModel, TVTextEN, TVTextFR);
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task ModifyTVItemLocal_Root_Address_Good_Test(string culture)
//        {
//            Assert.True(await TVItemLocalServiceSetup(culture));

//            WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, 0);

//            TVItem tvItemParent = webRoot.TVItemModel.TVItem;
//            TVTypeEnum tvType = TVTypeEnum.Address;
//            string TVTextEN = "New Item";
//            string TVTextFR = "Nouveau Item";

//            TVItemModel tvItemModel = await TVItemLocalService.ModifyTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
//            Assert.NotNull(tvItemModel);

//            CheckNewTVItemAndTVItemLanguageList(tvItemModel, TVTextEN, TVTextFR);
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task ModifyTVItemLocal_Root_Email_Good_Test(string culture)
//        {
//            Assert.True(await TVItemLocalServiceSetup(culture));

//            WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, 0);

//            TVItem tvItemParent = webRoot.TVItemModel.TVItem;
//            TVTypeEnum tvType = TVTypeEnum.Email;
//            string TVTextEN = "New Item";
//            string TVTextFR = "Nouveau Item";

//            TVItemModel tvItemModel = await TVItemLocalService.ModifyTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
//            Assert.NotNull(tvItemModel);

//            CheckNewTVItemAndTVItemLanguageList(tvItemModel, TVTextEN, TVTextFR);
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task ModifyTVItemLocal_Root_Tel_Good_Test(string culture)
//        {
//            Assert.True(await TVItemLocalServiceSetup(culture));

//            WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, 0);

//            TVItem tvItemParent = webRoot.TVItemModel.TVItem;
//            TVTypeEnum tvType = TVTypeEnum.Tel;
//            string TVTextEN = "New Item";
//            string TVTextFR = "Nouveau Item";

//            TVItemModel tvItemModel = await TVItemLocalService.ModifyTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
//            Assert.NotNull(tvItemModel);

//            CheckNewTVItemAndTVItemLanguageList(tvItemModel, TVTextEN, TVTextFR);
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task ModifyTVItemLocal_Root_File_Good_Test(string culture)
//        {
//            Assert.True(await TVItemLocalServiceSetup(culture));

//            WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, 0);

//            TVItem tvItemParent = webRoot.TVItemModel.TVItem;
//            TVTypeEnum tvType = TVTypeEnum.File;
//            string TVTextEN = "New Item";
//            string TVTextFR = "Nouveau Item";

//            TVItemModel tvItemModel = await TVItemLocalService.ModifyTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
//            Assert.NotNull(tvItemModel);

//            CheckNewTVItemAndTVItemLanguageList(tvItemModel, TVTextEN, TVTextFR);
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task ModifyTVItemLocal_Root_Spill_Error_Test(string culture)
//        {
//            Assert.True(await TVItemLocalServiceSetup(culture));

//            WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, 0);

//            TVItem tvItemParent = webRoot.TVItemModel.TVItem;
//            TVTypeEnum tvType = TVTypeEnum.Spill;
//            string TVTextEN = "New Item";
//            string TVTextFR = "Nouveau Item";

//            TVItemModel tvItemModel = await TVItemLocalService.ModifyTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
//            Assert.Null(tvItemModel);

//            //CheckNewTVItemAndTVItemLanguageList(tvItemModel, TVTextEN, TVTextFR);
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task ModifyTVItemLocal_Country_Province_Good_Test(string culture)
//        {
//            Assert.True(await TVItemLocalServiceSetup(culture));

//            int TVItemID = 5;

//            WebCountry webCountry = await CSSPReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, TVItemID);

//            TVItem tvItemParent = webCountry.TVItemModel.TVItem;
//            TVTypeEnum tvType = TVTypeEnum.Province;
//            string TVTextEN = "New Item";
//            string TVTextFR = "Nouveau Item";

//            TVItemModel tvItemModel = await TVItemLocalService.ModifyTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
//            Assert.NotNull(tvItemModel);

//            CheckNewTVItemAndTVItemLanguageList(tvItemModel, TVTextEN, TVTextFR);
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task ModifyTVItemLocal_Country_RainExceedance_Good_Test(string culture)
//        {
//            Assert.True(await TVItemLocalServiceSetup(culture));

//            int TVItemID = 5;

//            WebCountry webCountry = await CSSPReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, TVItemID);

//            TVItem tvItemParent = webCountry.TVItemModel.TVItem;
//            TVTypeEnum tvType = TVTypeEnum.RainExceedance;
//            string TVTextEN = "New Item";
//            string TVTextFR = "Nouveau Item";

//            TVItemModel tvItemModel = await TVItemLocalService.ModifyTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
//            Assert.NotNull(tvItemModel);

//            CheckNewTVItemAndTVItemLanguageList(tvItemModel, TVTextEN, TVTextFR);
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task ModifyTVItemLocal_Country_EmailDistributionList_Good_Test(string culture)
//        {
//            Assert.True(await TVItemLocalServiceSetup(culture));

//            int TVItemID = 5;

//            WebCountry webCountry = await CSSPReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, TVItemID);

//            TVItem tvItemParent = webCountry.TVItemModel.TVItem;
//            TVTypeEnum tvType = TVTypeEnum.EmailDistributionList;
//            string TVTextEN = "New Item";
//            string TVTextFR = "Nouveau Item";

//            TVItemModel tvItemModel = await TVItemLocalService.ModifyTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
//            Assert.NotNull(tvItemModel);

//            CheckNewTVItemAndTVItemLanguageList(tvItemModel, TVTextEN, TVTextFR);
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task ModifyTVItemLocal_Country_File_Good_Test(string culture)
//        {
//            Assert.True(await TVItemLocalServiceSetup(culture));

//            int TVItemID = 5;

//            WebCountry webCountry = await CSSPReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, TVItemID);

//            TVItem tvItemParent = webCountry.TVItemModel.TVItem;
//            TVTypeEnum tvType = TVTypeEnum.File;
//            string TVTextEN = "New Item";
//            string TVTextFR = "Nouveau Item";

//            TVItemModel tvItemModel = await TVItemLocalService.ModifyTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
//            Assert.NotNull(tvItemModel);

//            CheckNewTVItemAndTVItemLanguageList(tvItemModel, TVTextEN, TVTextFR);
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task ModifyTVItemLocal_Country_Spill_Error_Test(string culture)
//        {
//            Assert.True(await TVItemLocalServiceSetup(culture));

//            int TVItemID = 5;

//            WebCountry webCountry = await CSSPReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, TVItemID);

//            TVItem tvItemParent = webCountry.TVItemModel.TVItem;
//            TVTypeEnum tvType = TVTypeEnum.Spill;
//            string TVTextEN = "New Item";
//            string TVTextFR = "Nouveau Item";

//            TVItemModel tvItemModel = await TVItemLocalService.ModifyTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
//            Assert.Null(tvItemModel);
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task ModifyTVItemLocal_Province_Area_Good_Test(string culture)
//        {
//            Assert.True(await TVItemLocalServiceSetup(culture));

//            int TVItemID = 7;

//            WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

//            TVItem tvItemParent = webProvince.TVItemModel.TVItem;
//            TVTypeEnum tvType = TVTypeEnum.Area;
//            string TVTextEN = "New Item";
//            string TVTextFR = "Nouveau Item";

//            TVItemModel tvItemModel = await TVItemLocalService.ModifyTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
//            Assert.NotNull(tvItemModel);

//            CheckNewTVItemAndTVItemLanguageList(tvItemModel, TVTextEN, TVTextFR);
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task ModifyTVItemLocal_Province_SamplingPlan_Good_Test(string culture)
//        {
//            Assert.True(await TVItemLocalServiceSetup(culture));

//            int TVItemID = 7;

//            WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

//            TVItem tvItemParent = webProvince.TVItemModel.TVItem;
//            TVTypeEnum tvType = TVTypeEnum.SamplingPlan;
//            string TVTextEN = "New Item";
//            string TVTextFR = "Nouveau Item";

//            TVItemModel tvItemModel = await TVItemLocalService.ModifyTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
//            Assert.NotNull(tvItemModel);

//            CheckNewTVItemAndTVItemLanguageList(tvItemModel, TVTextEN, TVTextFR);
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task ModifyTVItemLocal_Province_Municipality_Good_Test(string culture)
//        {
//            Assert.True(await TVItemLocalServiceSetup(culture));

//            int TVItemID = 7;

//            WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

//            TVItem tvItemParent = webProvince.TVItemModel.TVItem;
//            TVTypeEnum tvType = TVTypeEnum.Municipality;
//            string TVTextEN = "New Item";
//            string TVTextFR = "Nouveau Item";

//            TVItemModel tvItemModel = await TVItemLocalService.ModifyTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
//            Assert.NotNull(tvItemModel);

//            CheckNewTVItemAndTVItemLanguageList(tvItemModel, TVTextEN, TVTextFR);
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task ModifyTVItemLocal_Province_ClimateSite_Good_Test(string culture)
//        {
//            Assert.True(await TVItemLocalServiceSetup(culture));

//            int TVItemID = 7;

//            WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

//            TVItem tvItemParent = webProvince.TVItemModel.TVItem;
//            TVTypeEnum tvType = TVTypeEnum.ClimateSite;
//            string TVTextEN = "New Item";
//            string TVTextFR = "Nouveau Item";

//            TVItemModel tvItemModel = await TVItemLocalService.ModifyTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
//            Assert.NotNull(tvItemModel);

//            CheckNewTVItemAndTVItemLanguageList(tvItemModel, TVTextEN, TVTextFR);
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task ModifyTVItemLocal_Province_HydrometricSite_Good_Test(string culture)
//        {
//            Assert.True(await TVItemLocalServiceSetup(culture));

//            int TVItemID = 7;

//            WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

//            TVItem tvItemParent = webProvince.TVItemModel.TVItem;
//            TVTypeEnum tvType = TVTypeEnum.HydrometricSite;
//            string TVTextEN = "New Item";
//            string TVTextFR = "Nouveau Item";

//            TVItemModel tvItemModel = await TVItemLocalService.ModifyTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
//            Assert.NotNull(tvItemModel);

//            CheckNewTVItemAndTVItemLanguageList(tvItemModel, TVTextEN, TVTextFR);
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task ModifyTVItemLocal_Province_TideSite_Good_Test(string culture)
//        {
//            Assert.True(await TVItemLocalServiceSetup(culture));

//            int TVItemID = 7;

//            WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

//            TVItem tvItemParent = webProvince.TVItemModel.TVItem;
//            TVTypeEnum tvType = TVTypeEnum.TideSite;
//            string TVTextEN = "New Item";
//            string TVTextFR = "Nouveau Item";

//            TVItemModel tvItemModel = await TVItemLocalService.ModifyTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
//            Assert.NotNull(tvItemModel);

//            CheckNewTVItemAndTVItemLanguageList(tvItemModel, TVTextEN, TVTextFR);
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task ModifyTVItemLocal_Province_File_Good_Test(string culture)
//        {
//            Assert.True(await TVItemLocalServiceSetup(culture));

//            int TVItemID = 7;

//            WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

//            TVItem tvItemParent = webProvince.TVItemModel.TVItem;
//            TVTypeEnum tvType = TVTypeEnum.File;
//            string TVTextEN = "New Item";
//            string TVTextFR = "Nouveau Item";

//            TVItemModel tvItemModel = await TVItemLocalService.ModifyTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
//            Assert.NotNull(tvItemModel);

//            CheckNewTVItemAndTVItemLanguageList(tvItemModel, TVTextEN, TVTextFR);
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task ModifyTVItemLocal_Province_Spill_Error_Test(string culture)
//        {
//            Assert.True(await TVItemLocalServiceSetup(culture));

//            int TVItemID = 7;

//            WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

//            TVItem tvItemParent = webProvince.TVItemModel.TVItem;
//            TVTypeEnum tvType = TVTypeEnum.Spill;
//            string TVTextEN = "New Item";
//            string TVTextFR = "Nouveau Item";

//            TVItemModel tvItemModel = await TVItemLocalService.ModifyTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
//            Assert.Null(tvItemModel);
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task ModifyTVItemLocal_Municipality_Infrastructure_Good_Test(string culture)
//        {
//            Assert.True(await TVItemLocalServiceSetup(culture));

//            int TVItemID = 27764;

//            WebMunicipality webMunicipality = await CSSPReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, TVItemID);

//            TVItem tvItemParent = webMunicipality.TVItemModel.TVItem;
//            TVTypeEnum tvType = TVTypeEnum.Infrastructure;
//            string TVTextEN = "New Item";
//            string TVTextFR = "Nouveau Item";

//            TVItemModel tvItemModel = await TVItemLocalService.ModifyTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
//            Assert.NotNull(tvItemModel);

//            CheckNewTVItemAndTVItemLanguageList(tvItemModel, TVTextEN, TVTextFR);
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task ModifyTVItemLocal_Municipality_MikeScenario_Good_Test(string culture)
//        {
//            Assert.True(await TVItemLocalServiceSetup(culture));

//            int TVItemID = 27764;

//            WebMunicipality webMunicipality = await CSSPReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, TVItemID);

//            TVItem tvItemParent = webMunicipality.TVItemModel.TVItem;
//            TVTypeEnum tvType = TVTypeEnum.MikeScenario;
//            string TVTextEN = "New Item";
//            string TVTextFR = "Nouveau Item";

//            TVItemModel tvItemModel = await TVItemLocalService.ModifyTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
//            Assert.NotNull(tvItemModel);

//            CheckNewTVItemAndTVItemLanguageList(tvItemModel, TVTextEN, TVTextFR);
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task ModifyTVItemLocal_Municipality_File_Good_Test(string culture)
//        {
//            Assert.True(await TVItemLocalServiceSetup(culture));

//            int TVItemID = 27764;

//            WebMunicipality webMunicipality = await CSSPReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, TVItemID);

//            TVItem tvItemParent = webMunicipality.TVItemModel.TVItem;
//            TVTypeEnum tvType = TVTypeEnum.File;
//            string TVTextEN = "New Item";
//            string TVTextFR = "Nouveau Item";

//            TVItemModel tvItemModel = await TVItemLocalService.ModifyTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
//            Assert.NotNull(tvItemModel);

//            CheckNewTVItemAndTVItemLanguageList(tvItemModel, TVTextEN, TVTextFR);
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task ModifyTVItemLocal_Municipality_Spill_Error_Test(string culture)
//        {
//            Assert.True(await TVItemLocalServiceSetup(culture));

//            int TVItemID = 27764;

//            WebMunicipality webMunicipality = await CSSPReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, TVItemID);

//            TVItem tvItemParent = webMunicipality.TVItemModel.TVItem;
//            TVTypeEnum tvType = TVTypeEnum.Spill;
//            string TVTextEN = "New Item";
//            string TVTextFR = "Nouveau Item";

//            TVItemModel tvItemModel = await TVItemLocalService.ModifyTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
//            Assert.Null(tvItemModel);
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task ModifyTVItemLocal_Infrastructure_File_Good_Test(string culture)
//        {
//            Assert.True(await TVItemLocalServiceSetup(culture));

//            int TVItemID = 27764;

//            WebMunicipality webMunicipality = await CSSPReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, TVItemID);

//            TVItem tvItemParent = webMunicipality.TVItemModel.TVItem;
//            TVTypeEnum tvType = TVTypeEnum.File;
//            string TVTextEN = "New Item";
//            string TVTextFR = "Nouveau Item";

//            InfrastructureModel infrastructureModel = webMunicipality.InfrastructureModelList[0];
//            Assert.NotNull(infrastructureModel);

//            tvItemParent = infrastructureModel.TVItemModel.TVItem;
//            Assert.NotNull(tvItemParent);

//            TVItemModel tvItemModel = await TVItemLocalService.ModifyTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
//            Assert.NotNull(tvItemModel);

//            CheckNewTVItemAndTVItemLanguageList(tvItemModel, TVTextEN, TVTextFR);
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task ModifyTVItemLocal_Infrastructure_Spill_Error_Test(string culture)
//        {
//            Assert.True(await TVItemLocalServiceSetup(culture));

//            int TVItemID = 27764;

//            WebMunicipality webMunicipality = await CSSPReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, TVItemID);

//            TVItem tvItemParent = webMunicipality.TVItemModel.TVItem;
//            TVTypeEnum tvType = TVTypeEnum.Spill;
//            string TVTextEN = "New Item";
//            string TVTextFR = "Nouveau Item";

//            InfrastructureModel infrastructureModel = webMunicipality.InfrastructureModelList[0];
//            Assert.NotNull(infrastructureModel);

//            tvItemParent = infrastructureModel.TVItemModel.TVItem;
//            Assert.NotNull(tvItemParent);

//            TVItemModel tvItemModel = await TVItemLocalService.ModifyTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
//            Assert.Null(tvItemModel);
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task ModifyTVItemLocal_MikeScenario_MikeSource_Good_Test(string culture)
//        {
//            Assert.True(await TVItemLocalServiceSetup(culture));

//            int TVItemID = 27764;

//            WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, TVItemID);

//            TVItem tvItemParent = webMikeScenarios.TVItemModel.TVItem;
//            TVTypeEnum tvType = TVTypeEnum.MikeSource;
//            string TVTextEN = "New Item";
//            string TVTextFR = "Nouveau Item";

//            MikeScenarioModel mikeScenarioModel = webMikeScenarios.MikeScenarioModelList[0];
//            Assert.NotNull(mikeScenarioModel);

//            tvItemParent = mikeScenarioModel.TVItemModel.TVItem;
//            Assert.NotNull(tvItemParent);

//            TVItemModel tvItemModel = await TVItemLocalService.ModifyTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
//            Assert.NotNull(tvItemModel);

//            CheckNewTVItemAndTVItemLanguageList(tvItemModel, TVTextEN, TVTextFR);
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task ModifyTVItemLocal_MikeScenario_MikeBoundaryConditionMesh_Good_Test(string culture)
//        {
//            Assert.True(await TVItemLocalServiceSetup(culture));

//            int TVItemID = 27764;

//            WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, TVItemID);

//            TVItem tvItemParent = webMikeScenarios.TVItemModel.TVItem;
//            TVTypeEnum tvType = TVTypeEnum.MikeBoundaryConditionMesh;
//            string TVTextEN = "New Item";
//            string TVTextFR = "Nouveau Item";

//            MikeScenarioModel mikeScenarioModel = webMikeScenarios.MikeScenarioModelList[0];
//            Assert.NotNull(mikeScenarioModel);

//            tvItemParent = mikeScenarioModel.TVItemModel.TVItem;
//            Assert.NotNull(tvItemParent);

//            TVItemModel tvItemModel = await TVItemLocalService.ModifyTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
//            Assert.NotNull(tvItemModel);

//            CheckNewTVItemAndTVItemLanguageList(tvItemModel, TVTextEN, TVTextFR);
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task ModifyTVItemLocal_MikeScenario_MikeBoundaryConditionWebTide_Good_Test(string culture)
//        {
//            Assert.True(await TVItemLocalServiceSetup(culture));

//            int TVItemID = 27764;

//            WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, TVItemID);

//            TVItem tvItemParent = webMikeScenarios.TVItemModel.TVItem;
//            TVTypeEnum tvType = TVTypeEnum.MikeBoundaryConditionWebTide;
//            string TVTextEN = "New Item";
//            string TVTextFR = "Nouveau Item";

//            MikeScenarioModel mikeScenarioModel = webMikeScenarios.MikeScenarioModelList[0];
//            Assert.NotNull(mikeScenarioModel);

//            tvItemParent = mikeScenarioModel.TVItemModel.TVItem;
//            Assert.NotNull(tvItemParent);

//            TVItemModel tvItemModel = await TVItemLocalService.ModifyTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
//            Assert.NotNull(tvItemModel);

//            CheckNewTVItemAndTVItemLanguageList(tvItemModel, TVTextEN, TVTextFR);
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task ModifyTVItemLocal_MikeScenario_File_Good_Test(string culture)
//        {
//            Assert.True(await TVItemLocalServiceSetup(culture));

//            int TVItemID = 27764;

//            WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, TVItemID);

//            TVItem tvItemParent = webMikeScenarios.TVItemModel.TVItem;
//            TVTypeEnum tvType = TVTypeEnum.File;
//            string TVTextEN = "New Item";
//            string TVTextFR = "Nouveau Item";

//            MikeScenarioModel mikeScenarioModel = webMikeScenarios.MikeScenarioModelList[0];
//            Assert.NotNull(mikeScenarioModel);

//            tvItemParent = mikeScenarioModel.TVItemModel.TVItem;
//            Assert.NotNull(tvItemParent);

//            TVItemModel tvItemModel = await TVItemLocalService.ModifyTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
//            Assert.NotNull(tvItemModel);

//            CheckNewTVItemAndTVItemLanguageList(tvItemModel, TVTextEN, TVTextFR);
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task ModifyTVItemLocal_MikeScenario_Spill_Error_Test(string culture)
//        {
//            Assert.True(await TVItemLocalServiceSetup(culture));

//            int TVItemID = 27764;

//            WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, TVItemID);

//            TVItem tvItemParent = webMikeScenarios.TVItemModel.TVItem;
//            TVTypeEnum tvType = TVTypeEnum.Spill;
//            string TVTextEN = "New Item";
//            string TVTextFR = "Nouveau Item";

//            MikeScenarioModel mikeScenarioModel = webMikeScenarios.MikeScenarioModelList[0];
//            Assert.NotNull(mikeScenarioModel);

//            tvItemParent = mikeScenarioModel.TVItemModel.TVItem;
//            Assert.NotNull(tvItemParent);

//            TVItemModel tvItemModel = await TVItemLocalService.ModifyTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
//            Assert.Null(tvItemModel);
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task ModifyTVItemLocal_Area_Sector_Good_Test(string culture)
//        {
//            Assert.True(await TVItemLocalServiceSetup(culture));

//            int TVItemID = 629;

//            WebArea webArea = await CSSPReadGzFileService.GetUncompressJSON<WebArea>(WebTypeEnum.WebArea, TVItemID);

//            TVItem tvItemParent = webArea.TVItemModel.TVItem;
//            TVTypeEnum tvType = TVTypeEnum.Sector;
//            string TVTextEN = "New Item";
//            string TVTextFR = "Nouveau Item";

//            tvItemParent = webArea.TVItemModel.TVItem;
//            Assert.NotNull(tvItemParent);

//            TVItemModel tvItemModel = await TVItemLocalService.ModifyTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
//            Assert.NotNull(tvItemModel);

//            CheckNewTVItemAndTVItemLanguageList(tvItemModel, TVTextEN, TVTextFR);
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task ModifyTVItemLocal_Area_File_Good_Test(string culture)
//        {
//            Assert.True(await TVItemLocalServiceSetup(culture));

//            int TVItemID = 629;

//            WebArea webArea = await CSSPReadGzFileService.GetUncompressJSON<WebArea>(WebTypeEnum.WebArea, TVItemID);

//            TVItem tvItemParent = webArea.TVItemModel.TVItem;
//            TVTypeEnum tvType = TVTypeEnum.File;
//            string TVTextEN = "New Item";
//            string TVTextFR = "Nouveau Item";

//            tvItemParent = webArea.TVItemModel.TVItem;
//            Assert.NotNull(tvItemParent);

//            TVItemModel tvItemModel = await TVItemLocalService.ModifyTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
//            Assert.NotNull(tvItemModel);

//            CheckNewTVItemAndTVItemLanguageList(tvItemModel, TVTextEN, TVTextFR);
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task ModifyTVItemLocal_Area_Spill_Error_Test(string culture)
//        {
//            Assert.True(await TVItemLocalServiceSetup(culture));

//            int TVItemID = 629;

//            WebArea webArea = await CSSPReadGzFileService.GetUncompressJSON<WebArea>(WebTypeEnum.WebArea, TVItemID);

//            TVItem tvItemParent = webArea.TVItemModel.TVItem;
//            TVTypeEnum tvType = TVTypeEnum.Spill;
//            string TVTextEN = "New Item";
//            string TVTextFR = "Nouveau Item";

//            tvItemParent = webArea.TVItemModel.TVItem;
//            Assert.NotNull(tvItemParent);

//            TVItemModel tvItemModel = await TVItemLocalService.ModifyTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
//            Assert.Null(tvItemModel);
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task ModifyTVItemLocal_Sector_Subsector_Good_Test(string culture)
//        {
//            Assert.True(await TVItemLocalServiceSetup(culture));

//            int TVItemID = 633;

//            WebSector webSector = await CSSPReadGzFileService.GetUncompressJSON<WebSector>(WebTypeEnum.WebSector, TVItemID);

//            TVItem tvItemParent = webSector.TVItemModel.TVItem;
//            TVTypeEnum tvType = TVTypeEnum.Subsector;
//            string TVTextEN = "New Item";
//            string TVTextFR = "Nouveau Item";

//            tvItemParent = webSector.TVItemModel.TVItem;
//            Assert.NotNull(tvItemParent);

//            TVItemModel tvItemModel = await TVItemLocalService.ModifyTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
//            Assert.NotNull(tvItemModel);

//            CheckNewTVItemAndTVItemLanguageList(tvItemModel, TVTextEN, TVTextFR);
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task ModifyTVItemLocal_Sector_File_Good_Test(string culture)
//        {
//            Assert.True(await TVItemLocalServiceSetup(culture));

//            int TVItemID = 633;

//            WebSector webSector = await CSSPReadGzFileService.GetUncompressJSON<WebSector>(WebTypeEnum.WebSector, TVItemID);

//            TVItem tvItemParent = webSector.TVItemModel.TVItem;
//            TVTypeEnum tvType = TVTypeEnum.File;
//            string TVTextEN = "New Item";
//            string TVTextFR = "Nouveau Item";

//            tvItemParent = webSector.TVItemModel.TVItem;
//            Assert.NotNull(tvItemParent);

//            TVItemModel tvItemModel = await TVItemLocalService.ModifyTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
//            Assert.NotNull(tvItemModel);

//            CheckNewTVItemAndTVItemLanguageList(tvItemModel, TVTextEN, TVTextFR);
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task ModifyTVItemLocal_Sector_Spill_Error_Test(string culture)
//        {
//            Assert.True(await TVItemLocalServiceSetup(culture));

//            int TVItemID = 633;

//            WebSector webSector = await CSSPReadGzFileService.GetUncompressJSON<WebSector>(WebTypeEnum.WebSector, TVItemID);

//            TVItem tvItemParent = webSector.TVItemModel.TVItem;
//            TVTypeEnum tvType = TVTypeEnum.Spill;
//            string TVTextEN = "New Item";
//            string TVTextFR = "Nouveau Item";

//            tvItemParent = webSector.TVItemModel.TVItem;
//            Assert.NotNull(tvItemParent);

//            TVItemModel tvItemModel = await TVItemLocalService.ModifyTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
//            Assert.Null(tvItemModel);
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task ModifyTVItemLocal_Subsector_MWQMRun_Good_Test(string culture)
//        {
//            Assert.True(await TVItemLocalServiceSetup(culture));

//            int TVItemID = 635;

//            WebSubsector webSubsector = await CSSPReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, TVItemID);

//            TVItem tvItemParent = webSubsector.TVItemModel.TVItem;
//            TVTypeEnum tvType = TVTypeEnum.MWQMRun;
//            string TVTextEN = "New Item";
//            string TVTextFR = "Nouveau Item";

//            tvItemParent = webSubsector.TVItemModel.TVItem;
//            Assert.NotNull(tvItemParent);

//            TVItemModel tvItemModel = await TVItemLocalService.ModifyTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
//            Assert.NotNull(tvItemModel);

//            CheckNewTVItemAndTVItemLanguageList(tvItemModel, TVTextEN, TVTextFR);
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task ModifyTVItemLocal_Subsector_MWQMSite_Good_Test(string culture)
//        {
//            Assert.True(await TVItemLocalServiceSetup(culture));

//            int TVItemID = 635;

//            WebSubsector webSubsector = await CSSPReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, TVItemID);

//            TVItem tvItemParent = webSubsector.TVItemModel.TVItem;
//            TVTypeEnum tvType = TVTypeEnum.MWQMSite;
//            string TVTextEN = "New Item";
//            string TVTextFR = "Nouveau Item";

//            tvItemParent = webSubsector.TVItemModel.TVItem;
//            Assert.NotNull(tvItemParent);

//            TVItemModel tvItemModel = await TVItemLocalService.ModifyTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
//            Assert.NotNull(tvItemModel);

//            CheckNewTVItemAndTVItemLanguageList(tvItemModel, TVTextEN, TVTextFR);
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task ModifyTVItemLocal_Subsector_PolSourceSite_Good_Test(string culture)
//        {
//            Assert.True(await TVItemLocalServiceSetup(culture));

//            int TVItemID = 635;

//            WebSubsector webSubsector = await CSSPReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, TVItemID);

//            TVItem tvItemParent = webSubsector.TVItemModel.TVItem;
//            TVTypeEnum tvType = TVTypeEnum.PolSourceSite;
//            string TVTextEN = "New Item";
//            string TVTextFR = "Nouveau Item";

//            tvItemParent = webSubsector.TVItemModel.TVItem;
//            Assert.NotNull(tvItemParent);

//            TVItemModel tvItemModel = await TVItemLocalService.ModifyTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
//            Assert.NotNull(tvItemModel);

//            CheckNewTVItemAndTVItemLanguageList(tvItemModel, TVTextEN, TVTextFR);
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task ModifyTVItemLocal_Subsector_Classification_Good_Test(string culture)
//        {
//            Assert.True(await TVItemLocalServiceSetup(culture));

//            int TVItemID = 635;

//            WebSubsector webSubsector = await CSSPReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, TVItemID);

//            TVItem tvItemParent = webSubsector.TVItemModel.TVItem;
//            TVTypeEnum tvType = TVTypeEnum.Classification;
//            string TVTextEN = "New Item";
//            string TVTextFR = "Nouveau Item";

//            tvItemParent = webSubsector.TVItemModel.TVItem;
//            Assert.NotNull(tvItemParent);

//            TVItemModel tvItemModel = await TVItemLocalService.ModifyTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
//            Assert.NotNull(tvItemModel);

//            CheckNewTVItemAndTVItemLanguageList(tvItemModel, TVTextEN, TVTextFR);
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task ModifyTVItemLocal_Subsector_File_Good_Test(string culture)
//        {
//            Assert.True(await TVItemLocalServiceSetup(culture));

//            int TVItemID = 635;

//            WebSubsector webSubsector = await CSSPReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, TVItemID);

//            TVItem tvItemParent = webSubsector.TVItemModel.TVItem;
//            TVTypeEnum tvType = TVTypeEnum.File;
//            string TVTextEN = "New Item";
//            string TVTextFR = "Nouveau Item";

//            tvItemParent = webSubsector.TVItemModel.TVItem;
//            Assert.NotNull(tvItemParent);

//            TVItemModel tvItemModel = await TVItemLocalService.ModifyTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
//            Assert.NotNull(tvItemModel);

//            CheckNewTVItemAndTVItemLanguageList(tvItemModel, TVTextEN, TVTextFR);
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task ModifyTVItemLocal_Subsector_Spill_Error_Test(string culture)
//        {
//            Assert.True(await TVItemLocalServiceSetup(culture));

//            int TVItemID = 635;

//            WebSubsector webSubsector = await CSSPReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, TVItemID);

//            TVItem tvItemParent = webSubsector.TVItemModel.TVItem;
//            TVTypeEnum tvType = TVTypeEnum.Spill;
//            string TVTextEN = "New Item";
//            string TVTextFR = "Nouveau Item";

//            tvItemParent = webSubsector.TVItemModel.TVItem;
//            Assert.NotNull(tvItemParent);

//            TVItemModel tvItemModel = await TVItemLocalService.ModifyTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
//            Assert.Null(tvItemModel);
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task ModifyTVItemLocal_MWQMSite_File_Good_Test(string culture)
//        {
//            Assert.True(await TVItemLocalServiceSetup(culture));

//            int TVItemID = 635;

//            WebMWQMSites webMWQMSites = await CSSPReadGzFileService.GetUncompressJSON<WebMWQMSites>(WebTypeEnum.WebMWQMSites, TVItemID);

//            TVItem tvItemParent = webMWQMSites.TVItemModel.TVItem;
//            TVTypeEnum tvType = TVTypeEnum.File;
//            string TVTextEN = "New Item";
//            string TVTextFR = "Nouveau Item";

//            MWQMSiteModel mwqmSiteModel = webMWQMSites.MWQMSiteModelList[0];
//            Assert.NotNull(mwqmSiteModel);

//            tvItemParent = mwqmSiteModel.TVItemModel.TVItem;
//            Assert.NotNull(tvItemParent);

//            TVItemModel tvItemModel = await TVItemLocalService.ModifyTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
//            Assert.NotNull(tvItemModel);

//            CheckNewTVItemAndTVItemLanguageList(tvItemModel, TVTextEN, TVTextFR);
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task ModifyTVItemLocal_MWQMSite_Spill_Error_Test(string culture)
//        {
//            Assert.True(await TVItemLocalServiceSetup(culture));

//            int TVItemID = 635;

//            WebMWQMSites webMWQMSites = await CSSPReadGzFileService.GetUncompressJSON<WebMWQMSites>(WebTypeEnum.WebMWQMSites, TVItemID);

//            TVItem tvItemParent = webMWQMSites.TVItemModel.TVItem;
//            TVTypeEnum tvType = TVTypeEnum.Spill;
//            string TVTextEN = "New Item";
//            string TVTextFR = "Nouveau Item";

//            MWQMSiteModel mwqmSiteModel = webMWQMSites.MWQMSiteModelList[0];
//            Assert.NotNull(mwqmSiteModel);

//            tvItemParent = mwqmSiteModel.TVItemModel.TVItem;
//            Assert.NotNull(tvItemParent);

//            TVItemModel tvItemModel = await TVItemLocalService.ModifyTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
//            Assert.Null(tvItemModel);
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task ModifyTVItemLocal_PolSourceSite_File_Good_Test(string culture)
//        {
//            Assert.True(await TVItemLocalServiceSetup(culture));

//            int TVItemID = 635;

//            WebPolSourceSites webPolSourceSites = await CSSPReadGzFileService.GetUncompressJSON<WebPolSourceSites>(WebTypeEnum.WebPolSourceSites, TVItemID);

//            TVItem tvItemParent = webPolSourceSites.TVItemModel.TVItem;
//            TVTypeEnum tvType = TVTypeEnum.File;
//            string TVTextEN = "New Item";
//            string TVTextFR = "Nouveau Item";

//            PolSourceSiteModel polSourceSiteModel = webPolSourceSites.PolSourceSiteModelList[0];
//            Assert.NotNull(polSourceSiteModel);

//            tvItemParent = polSourceSiteModel.TVItemModel.TVItem;
//            Assert.NotNull(tvItemParent);

//            TVItemModel tvItemModel = await TVItemLocalService.ModifyTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
//            Assert.NotNull(tvItemModel);

//            CheckNewTVItemAndTVItemLanguageList(tvItemModel, TVTextEN, TVTextFR);
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task ModifyTVItemLocal_PolSourceSite_Spill_Error_Test(string culture)
//        {
//            Assert.True(await TVItemLocalServiceSetup(culture));

//            int TVItemID = 635;

//            WebPolSourceSites webPolSourceSites = await CSSPReadGzFileService.GetUncompressJSON<WebPolSourceSites>(WebTypeEnum.WebPolSourceSites, TVItemID);

//            TVItem tvItemParent = webPolSourceSites.TVItemModel.TVItem;
//            TVTypeEnum tvType = TVTypeEnum.Spill;
//            string TVTextEN = "New Item";
//            string TVTextFR = "Nouveau Item";

//            PolSourceSiteModel polSourceSiteModel = webPolSourceSites.PolSourceSiteModelList[0];
//            Assert.NotNull(polSourceSiteModel);

//            tvItemParent = polSourceSiteModel.TVItemModel.TVItem;
//            Assert.NotNull(tvItemParent);

//            TVItemModel tvItemModel = await TVItemLocalService.ModifyTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
//            Assert.Null(tvItemModel);
//        }
//    }
//}
