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
        public async Task Parameters_AddMapInfoLocalFromAverage_tvItemParent_null_Error_Test(string culture)
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

            tvItemParent = null;

            var actionMapInfoLocalModelPoint = await MapInfoLocalService.AddMapInfoLocalFromAverage(tvItemParent, tvItemModel.TVItem, tvType, MapInfoDrawTypeEnum.Point);
            Assert.Equal(400, ((ObjectResult)actionMapInfoLocalModelPoint.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value;
            Assert.Equal(string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "tvItemParent"), errRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Parameters_AddMapInfoLocalFromAverage_tvItem_null_Error_Test(string culture)
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

            tvItemModel.TVItem = null;

            var actionMapInfoLocalModelPoint = await MapInfoLocalService.AddMapInfoLocalFromAverage(tvItemParent, tvItemModel.TVItem, tvType, MapInfoDrawTypeEnum.Point);
            Assert.Equal(400, ((ObjectResult)actionMapInfoLocalModelPoint.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value;
            Assert.Equal(string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "tvItem"), errRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Parameters_AddMapInfoLocalFromAverage_tvItemParent_TVItemID_Error_Test(string culture)
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

            tvItemParent.TVItemID = 0;

            var actionMapInfoLocalModelPoint = await MapInfoLocalService.AddMapInfoLocalFromAverage(tvItemParent, tvItemModel.TVItem, tvType, MapInfoDrawTypeEnum.Point);
            Assert.Equal(400, ((ObjectResult)actionMapInfoLocalModelPoint.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value;
            Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "tvItemParent.TVItemID"), errRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Parameters_AddMapInfoLocalFromAverage_tvItemParent_ParentID_Error_Test(string culture)
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

            tvItemParent.ParentID = 0;

            var actionMapInfoLocalModelPoint = await MapInfoLocalService.AddMapInfoLocalFromAverage(tvItemParent, tvItemModel.TVItem, tvType, MapInfoDrawTypeEnum.Point);
            Assert.Equal(400, ((ObjectResult)actionMapInfoLocalModelPoint.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value;
            Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "tvItemParent.ParentID"), errRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Parameters_AddMapInfoLocalFromAverage_tvItemParent_TVType_Error_Test(string culture)
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

            tvItemParent.TVType = (TVTypeEnum)1000;

            var actionMapInfoLocalModelPoint = await MapInfoLocalService.AddMapInfoLocalFromAverage(tvItemParent, tvItemModel.TVItem, tvType, MapInfoDrawTypeEnum.Point);
            Assert.Equal(400, ((ObjectResult)actionMapInfoLocalModelPoint.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value;
            Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "tvItemParent.TVType"), errRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Parameters_AddMapInfoLocalFromAverage_tvItem_TVItemID_Error_Test(string culture)
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

            tvItemModel.TVItem.TVItemID = 0;

            var actionMapInfoLocalModelPoint = await MapInfoLocalService.AddMapInfoLocalFromAverage(tvItemParent, tvItemModel.TVItem, tvType, MapInfoDrawTypeEnum.Point);
            Assert.Equal(400, ((ObjectResult)actionMapInfoLocalModelPoint.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value;
            Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "tvItem.TVItemID"), errRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Parameters_AddMapInfoLocalFromAverage_tvItem_ParentID_Error_Test(string culture)
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

            tvItemModel.TVItem.ParentID = 0;

            var actionMapInfoLocalModelPoint = await MapInfoLocalService.AddMapInfoLocalFromAverage(tvItemParent, tvItemModel.TVItem, tvType, MapInfoDrawTypeEnum.Point);
            Assert.Equal(400, ((ObjectResult)actionMapInfoLocalModelPoint.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value;
            Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "tvItem.ParentID"), errRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Parameters_AddMapInfoLocalFromAverage_tvItem_TVType_Error_Test(string culture)
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

            tvItemModel.TVItem.TVType = (TVTypeEnum)10000;

            var actionMapInfoLocalModelPoint = await MapInfoLocalService.AddMapInfoLocalFromAverage(tvItemParent, tvItemModel.TVItem, tvType, MapInfoDrawTypeEnum.Point);
            Assert.Equal(400, ((ObjectResult)actionMapInfoLocalModelPoint.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value;
            Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "tvItem.TVType"), errRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Parameters_AddMapInfoLocalFromAverage_tvType_Error_Test(string culture)
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

            tvType = (TVTypeEnum)10000;

            var actionMapInfoLocalModelPoint = await MapInfoLocalService.AddMapInfoLocalFromAverage(tvItemParent, tvItemModel.TVItem, tvType, MapInfoDrawTypeEnum.Point);
            Assert.Equal(400, ((ObjectResult)actionMapInfoLocalModelPoint.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value;
            Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "tvType"), errRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Parameters_AddMapInfoLocalFromAverage_mapInfoDrawType_Error_Test(string culture)
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

            MapInfoDrawTypeEnum mapInfoDrawType = (MapInfoDrawTypeEnum)10000;

            var actionMapInfoLocalModelPoint = await MapInfoLocalService.AddMapInfoLocalFromAverage(tvItemParent, tvItemModel.TVItem, tvType, mapInfoDrawType);
            Assert.Equal(400, ((ObjectResult)actionMapInfoLocalModelPoint.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value;
            Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "mapInfoDrawType"), errRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Parameters_AddMapInfoLocalFromAverage_CheckTVTypeParentAndTVType_Error_Test(string culture)
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

            tvType = TVTypeEnum.Country;

            var actionMapInfoLocalModelPoint = await MapInfoLocalService.AddMapInfoLocalFromAverage(tvItemParent, tvItemModel.TVItem, tvType, MapInfoDrawTypeEnum.Point);
            Assert.Equal(400, ((ObjectResult)actionMapInfoLocalModelPoint.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value;
            Assert.Equal(string.Format(CSSPCultureServicesRes._IsNotAParentTypeOf_, tvItemParent.TVType.ToString(), tvType.ToString()), errRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Parameters_AddMapInfoLocalFromAverage_CheckTVTypeParentAndTVType_notimplemented_Error_Test(string culture)
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

            tvItemParent.TVType = TVTypeEnum.Restricted;

            var actionMapInfoLocalModelPoint = await MapInfoLocalService.AddMapInfoLocalFromAverage(tvItemParent, tvItemModel.TVItem, tvType, MapInfoDrawTypeEnum.Point);
            Assert.Equal(400, ((ObjectResult)actionMapInfoLocalModelPoint.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value;
            Assert.Equal(string.Format(CSSPCultureServicesRes._NotImplementedYet, tvItemParent.TVType.ToString()) + " --- CSSPDBLocalServices.TVItemLocalService.CheckTVTypeParentAndTVType", errRes.ErrList[0]);
        }

        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Parameters_AddMapInfoLocalFromAverage_MapInfo_AlreadyExist_Error_Test(string culture)
        {
            Assert.True(await MapInfoLocalServiceSetup(culture));

            int TVItemID = 7;

            WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

            TVItem tvItemParent = webProvince.TVItemModel.TVItem;

            Assert.NotEmpty(webProvince.TVItemModelAreaList);

            TVItem tvItemAreaExist = webProvince.TVItemModelAreaList[0].TVItem;

            var actionMapInfoLocalModelPoint = await MapInfoLocalService.AddMapInfoLocalFromAverage(tvItemParent, tvItemAreaExist, tvItemAreaExist.TVType, MapInfoDrawTypeEnum.Point);
            Assert.Equal(400, ((ObjectResult)actionMapInfoLocalModelPoint.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value;
            Assert.Equal(string.Format(CSSPCultureServicesRes._AlreadyExists, "MapInfo"), errRes.ErrList[0]);
        }
    }
}
