using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Xunit;
using CSSPWebAPI.Controllers;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System;
using CSSPWebAPI.Controllers.Resources;

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
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(mapInfoFirst.MapInfoID, ((List<MapInfo>)ret.Value)[0].MapInfoID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<MapInfo>)ret.Value).Count);

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
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(mapInfoList[0].MapInfoID, ((List<MapInfo>)ret.Value)[0].MapInfoID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<MapInfo>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with MapInfo info
                           IActionResult jsonRet2 = mapInfoController.GetMapInfoList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(mapInfoList[1].MapInfoID, ((List<MapInfo>)ret2.Value)[0].MapInfoID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<MapInfo>)ret2.Value).Count);
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
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(mapInfoFirst.MapInfoID, ((MapInfo)ret.Value).MapInfoID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = mapInfoController.GetMapInfoWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult mapInfoRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(mapInfoRet2);
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

                    MapInfo mapInfoFirst = new MapInfo();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MapInfoService mapInfoService = new MapInfoService(query, db, ContactID);
                        mapInfoFirst = (from c in db.MapInfos select c).FirstOrDefault();
                    }

                    // ok with MapInfo info
                    IActionResult jsonRet = mapInfoController.GetMapInfoWithID(mapInfoFirst.MapInfoID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    MapInfo mapInfoRet = (MapInfo)ret.Value;
                    Assert.Equal(mapInfoFirst.MapInfoID, mapInfoRet.MapInfoID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because MapInfoID exist
                    IActionResult jsonRet2 = mapInfoController.Post(mapInfoRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added MapInfo
                    mapInfoRet.MapInfoID = 0;
                    IActionResult jsonRet3 = mapInfoController.Post(mapInfoRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = mapInfoController.Delete(mapInfoRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet4);

                    OkObjectResult ret4 = jsonRet4 as OkObjectResult;
                    Assert.NotNull(ret4);

                    BadRequestResult badRequest4 = jsonRet4 as BadRequestResult;
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

                    MapInfo mapInfoFirst = new MapInfo();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        MapInfoService mapInfoService = new MapInfoService(query, db, ContactID);
                        mapInfoFirst = (from c in db.MapInfos select c).FirstOrDefault();
                    }

                    // ok with MapInfo info
                    IActionResult jsonRet = mapInfoController.GetMapInfoWithID(mapInfoFirst.MapInfoID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    MapInfo mapInfoRet = (MapInfo)Ret.Value;
                    Assert.Equal(mapInfoFirst.MapInfoID, mapInfoRet.MapInfoID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = mapInfoController.Put(mapInfoRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult mapInfoRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(mapInfoRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because MapInfoID of 0 does not exist
                    mapInfoRet.MapInfoID = 0;
                    IActionResult jsonRet3 = mapInfoController.Put(mapInfoRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult mapInfoRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(mapInfoRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
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

                    MapInfo mapInfoFirst = new MapInfo();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MapInfoService mapInfoService = new MapInfoService(query, db, ContactID);
                        mapInfoFirst = (from c in db.MapInfos select c).FirstOrDefault();
                    }

                    // ok with MapInfo info
                    IActionResult jsonRet = mapInfoController.GetMapInfoWithID(mapInfoFirst.MapInfoID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    MapInfo mapInfoRet = (MapInfo)Ret.Value;
                    Assert.Equal(mapInfoFirst.MapInfoID, mapInfoRet.MapInfoID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added MapInfo
                    mapInfoRet.MapInfoID = 0;
                    IActionResult jsonRet3 = mapInfoController.Post(mapInfoRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    MapInfo mapInfo = (MapInfo)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = mapInfoController.Delete(mapInfoRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because MapInfoID of 0 does not exist
                    mapInfoRet.MapInfoID = 0;
                    IActionResult jsonRet4 = mapInfoController.Delete(mapInfoRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet4);

                    OkObjectResult ret4 = jsonRet4 as OkObjectResult;
                    Assert.Null(ret4);

                    BadRequestObjectResult badRequest4 = jsonRet4 as BadRequestObjectResult;
                    Assert.NotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
