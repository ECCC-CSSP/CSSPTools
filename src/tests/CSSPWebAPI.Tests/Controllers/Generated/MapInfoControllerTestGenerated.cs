using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Xunit;
using CSSPWebAPI.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.AspNetCore.Mvc;

namespace CSSPWebAPI.Tests.Controllers
{
    public partial class MapInfoControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MapInfoControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void MapInfo_Controller_GetMapInfoList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MapInfoController mapInfoController = new MapInfoController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mapInfoController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mapInfoController.DatabaseType);

                    MapInfo mapInfoFirst = new MapInfo();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        MapInfoService mapInfoService = new MapInfoService(query, db, ContactID);
                        mapInfoFirst = (from c in db.MapInfos select c).FirstOrDefault();
                        count = (from c in db.MapInfos select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with MapInfo info
                    IActionResult jsonRet = mapInfoController.GetMapInfoList();
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<List<MapInfo>> ret = jsonRet as OkNegotiatedContentResult<List<MapInfo>>;
                    Assert.Equal(mapInfoFirst.MapInfoID, ret.Content[0].MapInfoID);
                    Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<MapInfo> mapInfoList = new List<MapInfo>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        MapInfoService mapInfoService = new MapInfoService(query, db, ContactID);
                        mapInfoList = (from c in db.MapInfos select c).OrderBy(c => c.MapInfoID).Skip(0).Take(2).ToList();
                        count = (from c in db.MapInfos select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with MapInfo info
                        jsonRet = mapInfoController.GetMapInfoList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.NotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<MapInfo>>;
                        Assert.Equal(mapInfoList[0].MapInfoID, ret.Content[0].MapInfoID);
                        Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with MapInfo info
                           IActionResult jsonRet2 = mapInfoController.GetMapInfoList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkNegotiatedContentResult<List<MapInfo>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<MapInfo>>;
                           Assert.Equal(mapInfoList[1].MapInfoID, ret2.Content[0].MapInfoID);
                           Assert.Equal((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void MapInfo_Controller_GetMapInfoWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MapInfoController mapInfoController = new MapInfoController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mapInfoController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mapInfoController.DatabaseType);

                    MapInfo mapInfoFirst = new MapInfo();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        MapInfoService mapInfoService = new MapInfoService(new Query(), db, ContactID);
                        mapInfoFirst = (from c in db.MapInfos select c).FirstOrDefault();
                    }

                    // ok with MapInfo info
                    IActionResult jsonRet = mapInfoController.GetMapInfoWithID(mapInfoFirst.MapInfoID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<MapInfo> Ret = jsonRet as OkNegotiatedContentResult<MapInfo>;
                    MapInfo mapInfoRet = Ret.Content;
                    Assert.Equal(mapInfoFirst.MapInfoID, mapInfoRet.MapInfoID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = mapInfoController.GetMapInfoWithID(0);
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<MapInfo> mapInfoRet2 = jsonRet2 as OkNegotiatedContentResult<MapInfo>;
                    Assert.Null(mapInfoRet2);

                    NotFoundObjectResult notFoundRequest = jsonRet2 as NotFoundObjectResult;
                    Assert.NotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void MapInfo_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MapInfoController mapInfoController = new MapInfoController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mapInfoController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mapInfoController.DatabaseType);

                    MapInfo mapInfoLast = new MapInfo();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MapInfoService mapInfoService = new MapInfoService(query, db, ContactID);
                        mapInfoLast = (from c in db.MapInfos select c).FirstOrDefault();
                    }

                    // ok with MapInfo info
                    IActionResult jsonRet = mapInfoController.GetMapInfoWithID(mapInfoLast.MapInfoID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<MapInfo> Ret = jsonRet as OkNegotiatedContentResult<MapInfo>;
                    MapInfo mapInfoRet = Ret.Content;
                    Assert.Equal(mapInfoLast.MapInfoID, mapInfoRet.MapInfoID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because MapInfoID exist
                    IActionResult jsonRet2 = mapInfoController.Post(mapInfoRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<MapInfo> mapInfoRet2 = jsonRet2 as OkNegotiatedContentResult<MapInfo>;
                    Assert.Null(mapInfoRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added MapInfo
                    mapInfoRet.MapInfoID = 0;
                    mapInfoController.Request = new System.Net.Http.HttpRequestMessage();
                    mapInfoController.Request.RequestUri = new System.Uri("http://localhost:5000/api/mapInfo");
                    IActionResult jsonRet3 = mapInfoController.Post(mapInfoRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<MapInfo> mapInfoRet3 = jsonRet3 as CreatedNegotiatedContentResult<MapInfo>;
                    Assert.NotNull(mapInfoRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = mapInfoController.Delete(mapInfoRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<MapInfo> mapInfoRet4 = jsonRet4 as OkNegotiatedContentResult<MapInfo>;
                    Assert.NotNull(mapInfoRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [Fact]
        public void MapInfo_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MapInfoController mapInfoController = new MapInfoController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mapInfoController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mapInfoController.DatabaseType);

                    MapInfo mapInfoLast = new MapInfo();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        MapInfoService mapInfoService = new MapInfoService(query, db, ContactID);
                        mapInfoLast = (from c in db.MapInfos select c).FirstOrDefault();
                    }

                    // ok with MapInfo info
                    IActionResult jsonRet = mapInfoController.GetMapInfoWithID(mapInfoLast.MapInfoID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<MapInfo> Ret = jsonRet as OkNegotiatedContentResult<MapInfo>;
                    MapInfo mapInfoRet = Ret.Content;
                    Assert.Equal(mapInfoLast.MapInfoID, mapInfoRet.MapInfoID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = mapInfoController.Put(mapInfoRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<MapInfo> mapInfoRet2 = jsonRet2 as OkNegotiatedContentResult<MapInfo>;
                    Assert.NotNull(mapInfoRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because MapInfoID of 0 does not exist
                    mapInfoRet.MapInfoID = 0;
                    IActionResult jsonRet3 = mapInfoController.Put(mapInfoRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    OkNegotiatedContentResult<MapInfo> mapInfoRet3 = jsonRet3 as OkNegotiatedContentResult<MapInfo>;
                    Assert.Null(mapInfoRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void MapInfo_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MapInfoController mapInfoController = new MapInfoController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mapInfoController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mapInfoController.DatabaseType);

                    MapInfo mapInfoLast = new MapInfo();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MapInfoService mapInfoService = new MapInfoService(query, db, ContactID);
                        mapInfoLast = (from c in db.MapInfos select c).FirstOrDefault();
                    }

                    // ok with MapInfo info
                    IActionResult jsonRet = mapInfoController.GetMapInfoWithID(mapInfoLast.MapInfoID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<MapInfo> Ret = jsonRet as OkNegotiatedContentResult<MapInfo>;
                    MapInfo mapInfoRet = Ret.Content;
                    Assert.Equal(mapInfoLast.MapInfoID, mapInfoRet.MapInfoID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return newly added MapInfo
                    mapInfoRet.MapInfoID = 0;
                    mapInfoController.Request = new System.Net.Http.HttpRequestMessage();
                    mapInfoController.Request.RequestUri = new System.Uri("http://localhost:5000/api/mapInfo");
                    IActionResult jsonRet3 = mapInfoController.Post(mapInfoRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<MapInfo> mapInfoRet3 = jsonRet3 as CreatedNegotiatedContentResult<MapInfo>;
                    Assert.NotNull(mapInfoRet3);
                    MapInfo mapInfo = mapInfoRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = mapInfoController.Delete(mapInfoRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<MapInfo> mapInfoRet2 = jsonRet2 as OkNegotiatedContentResult<MapInfo>;
                    Assert.NotNull(mapInfoRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because MapInfoID of 0 does not exist
                    mapInfoRet.MapInfoID = 0;
                    IActionResult jsonRet4 = mapInfoController.Delete(mapInfoRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<MapInfo> mapInfoRet4 = jsonRet4 as OkNegotiatedContentResult<MapInfo>;
                    Assert.Null(mapInfoRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
