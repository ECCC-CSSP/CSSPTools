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
        public async Task AddTVItemLocal_Root_Spill_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, 0);

            TVItem tvItemParent = webRoot.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.Spill;
            string TVTextEN = "New Item";
            string TVTextFR = "Nouveau Item";

            var actionTVItemModel = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(400, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionTVItemModel.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(errRes);
            Assert.Equal(0, (from c in dbLocal.TVItems select c).Count());
            Assert.Equal(0, (from c in dbLocal.TVItemLanguages select c).Count());
            Assert.Equal(string.Format(CSSPCultureServicesRes._IsNotAParentTypeOf_, tvItemParent.TVType.ToString(), tvType.ToString()), CSSPLogService.ErrRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_Country_Spill_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            int TVItemID = 5;

            WebCountry webCountry = await CSSPReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, TVItemID);

            TVItem tvItemParent = webCountry.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.Spill;
            string TVTextEN = "New Item";
            string TVTextFR = "Nouveau Item";

            var actionTVItemModel = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(400, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionTVItemModel.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(errRes);
            Assert.Equal(0, (from c in dbLocal.TVItems select c).Count());
            Assert.Equal(0, (from c in dbLocal.TVItemLanguages select c).Count());
            Assert.Equal(string.Format(CSSPCultureServicesRes._IsNotAParentTypeOf_, tvItemParent.TVType.ToString(), tvType.ToString()), CSSPLogService.ErrRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_Province_Spill_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            int TVItemID = 7;

            WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

            TVItem tvItemParent = webProvince.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.Spill;
            string TVTextEN = "New Item";
            string TVTextFR = "Nouveau Item";

            var actionTVItemModel = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(400, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionTVItemModel.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(errRes);
            Assert.Equal(0, (from c in dbLocal.TVItems select c).Count());
            Assert.Equal(0, (from c in dbLocal.TVItemLanguages select c).Count());
            Assert.Equal(string.Format(CSSPCultureServicesRes._IsNotAParentTypeOf_, tvItemParent.TVType.ToString(), tvType.ToString()), CSSPLogService.ErrRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_Municipality_Spill_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            int TVItemID = 27764;

            WebMunicipality webMunicipality = await CSSPReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, TVItemID);

            TVItem tvItemParent = webMunicipality.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.Spill;
            string TVTextEN = "New Item";
            string TVTextFR = "Nouveau Item";

            var actionTVItemModel = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(400, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionTVItemModel.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(errRes);
            Assert.Equal(0, (from c in dbLocal.TVItems select c).Count());
            Assert.Equal(0, (from c in dbLocal.TVItemLanguages select c).Count());
            Assert.Equal(string.Format(CSSPCultureServicesRes._IsNotAParentTypeOf_, tvItemParent.TVType.ToString(), tvType.ToString()), CSSPLogService.ErrRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_Infrastructure_Spill_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            int TVItemID = 27764;

            WebMunicipality webMunicipality = await CSSPReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, TVItemID);

            TVItem tvItemParent = webMunicipality.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.Spill;
            string TVTextEN = "New Item";
            string TVTextFR = "Nouveau Item";

            InfrastructureModel infrastructureModel = webMunicipality.InfrastructureModelList[0];
            Assert.NotNull(infrastructureModel);

            tvItemParent = infrastructureModel.TVItemModel.TVItem;
            Assert.NotNull(tvItemParent);

            var actionTVItemModel = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(400, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionTVItemModel.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(errRes);
            Assert.Equal(0, (from c in dbLocal.TVItems select c).Count());
            Assert.Equal(0, (from c in dbLocal.TVItemLanguages select c).Count());
            Assert.Equal(string.Format(CSSPCultureServicesRes._IsNotAParentTypeOf_, tvItemParent.TVType.ToString(), tvType.ToString()), CSSPLogService.ErrRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_MikeScenario_Spill_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            int TVItemID = 27764;

            WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, TVItemID);

            TVItem tvItemParent = webMikeScenarios.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.Spill;
            string TVTextEN = "New Item";
            string TVTextFR = "Nouveau Item";

            MikeScenarioModel mikeScenarioModel = webMikeScenarios.MikeScenarioModelList[0];
            Assert.NotNull(mikeScenarioModel);

            tvItemParent = mikeScenarioModel.TVItemModel.TVItem;
            Assert.NotNull(tvItemParent);

            var actionTVItemModel = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(400, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionTVItemModel.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(errRes);
            Assert.Equal(0, (from c in dbLocal.TVItems select c).Count());
            Assert.Equal(0, (from c in dbLocal.TVItemLanguages select c).Count());
            Assert.Equal(string.Format(CSSPCultureServicesRes._IsNotAParentTypeOf_, tvItemParent.TVType.ToString(), tvType.ToString()), CSSPLogService.ErrRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_Area_Spill_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            int TVItemID = 629;

            WebArea webArea = await CSSPReadGzFileService.GetUncompressJSON<WebArea>(WebTypeEnum.WebArea, TVItemID);

            TVItem tvItemParent = webArea.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.Spill;
            string TVTextEN = "New Item";
            string TVTextFR = "Nouveau Item";

            tvItemParent = webArea.TVItemModel.TVItem;
            Assert.NotNull(tvItemParent);

            var actionTVItemModel = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(400, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionTVItemModel.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(errRes);
            Assert.Equal(0, (from c in dbLocal.TVItems select c).Count());
            Assert.Equal(0, (from c in dbLocal.TVItemLanguages select c).Count());
            Assert.Equal(string.Format(CSSPCultureServicesRes._IsNotAParentTypeOf_, tvItemParent.TVType.ToString(), tvType.ToString()), CSSPLogService.ErrRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_Sector_Spill_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            int TVItemID = 633;

            WebSector webSector = await CSSPReadGzFileService.GetUncompressJSON<WebSector>(WebTypeEnum.WebSector, TVItemID);

            TVItem tvItemParent = webSector.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.Spill;
            string TVTextEN = "New Item";
            string TVTextFR = "Nouveau Item";

            tvItemParent = webSector.TVItemModel.TVItem;
            Assert.NotNull(tvItemParent);

            var actionTVItemModel = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(400, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionTVItemModel.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(errRes);
            Assert.Equal(0, (from c in dbLocal.TVItems select c).Count());
            Assert.Equal(0, (from c in dbLocal.TVItemLanguages select c).Count());
            Assert.Equal(string.Format(CSSPCultureServicesRes._IsNotAParentTypeOf_, tvItemParent.TVType.ToString(), tvType.ToString()), CSSPLogService.ErrRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_Subsector_Spill_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            int TVItemID = 635;

            WebSubsector webSubsector = await CSSPReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, TVItemID);

            TVItem tvItemParent = webSubsector.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.Spill;
            string TVTextEN = "New Item";
            string TVTextFR = "Nouveau Item";

            tvItemParent = webSubsector.TVItemModel.TVItem;
            Assert.NotNull(tvItemParent);

            var actionTVItemModel = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(400, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionTVItemModel.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(errRes);
            Assert.Equal(0, (from c in dbLocal.TVItems select c).Count());
            Assert.Equal(0, (from c in dbLocal.TVItemLanguages select c).Count());
            Assert.Equal(string.Format(CSSPCultureServicesRes._IsNotAParentTypeOf_, tvItemParent.TVType.ToString(), tvType.ToString()), CSSPLogService.ErrRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_MWQMSite_Spill_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            int TVItemID = 635;

            WebMWQMSites webMWQMSites = await CSSPReadGzFileService.GetUncompressJSON<WebMWQMSites>(WebTypeEnum.WebMWQMSites, TVItemID);

            TVItem tvItemParent = webMWQMSites.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.Spill;
            string TVTextEN = "New Item";
            string TVTextFR = "Nouveau Item";

            MWQMSiteModel mwqmSiteModel = webMWQMSites.MWQMSiteModelList[0];
            Assert.NotNull(mwqmSiteModel);

            tvItemParent = mwqmSiteModel.TVItemModel.TVItem;
            Assert.NotNull(tvItemParent);

            var actionTVItemModel = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(400, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionTVItemModel.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(errRes);
            Assert.Equal(0, (from c in dbLocal.TVItems select c).Count());
            Assert.Equal(0, (from c in dbLocal.TVItemLanguages select c).Count());
            Assert.Equal(string.Format(CSSPCultureServicesRes._IsNotAParentTypeOf_, tvItemParent.TVType.ToString(), tvType.ToString()), CSSPLogService.ErrRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_PolSourceSite_Spill_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            int TVItemID = 635;

            WebPolSourceSites webPolSourceSites = await CSSPReadGzFileService.GetUncompressJSON<WebPolSourceSites>(WebTypeEnum.WebPolSourceSites, TVItemID);

            TVItem tvItemParent = webPolSourceSites.TVItemModel.TVItem;
            TVTypeEnum tvType = TVTypeEnum.Spill;
            string TVTextEN = "New Item";
            string TVTextFR = "Nouveau Item";

            PolSourceSiteModel polSourceSiteModel = webPolSourceSites.PolSourceSiteModelList[0];
            Assert.NotNull(polSourceSiteModel);

            tvItemParent = polSourceSiteModel.TVItemModel.TVItem;
            Assert.NotNull(tvItemParent);

            var actionTVItemModel = await TVItemLocalService.AddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);
            Assert.Equal(400, ((ObjectResult)actionTVItemModel.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionTVItemModel.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModel.Result).Value;
            Assert.NotNull(errRes);
            Assert.Equal(0, (from c in dbLocal.TVItems select c).Count());
            Assert.Equal(0, (from c in dbLocal.TVItemLanguages select c).Count());
            Assert.Equal(string.Format(CSSPCultureServicesRes._IsNotAParentTypeOf_, tvItemParent.TVType.ToString(), tvType.ToString()), CSSPLogService.ErrRes.ErrList[0]);
        }
    }
}
