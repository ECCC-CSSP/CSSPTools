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
    public partial class MapInfoPointControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MapInfoPointControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void MapInfoPoint_Controller_GetMapInfoPointList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MapInfoPointController mapInfoPointController = new MapInfoPointController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mapInfoPointController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mapInfoPointController.DatabaseType);

                    MapInfoPoint mapInfoPointFirst = new MapInfoPoint();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        MapInfoPointService mapInfoPointService = new MapInfoPointService(query, db, ContactID);
                        mapInfoPointFirst = (from c in db.MapInfoPoints select c).FirstOrDefault();
                        count = (from c in db.MapInfoPoints select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with MapInfoPoint info
                    IActionResult jsonRet = mapInfoPointController.GetMapInfoPointList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(mapInfoPointFirst.MapInfoPointID, ((List<MapInfoPoint>)ret.Value)[0].MapInfoPointID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<MapInfoPoint>)ret.Value).Count);

                    List<MapInfoPoint> mapInfoPointList = new List<MapInfoPoint>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        MapInfoPointService mapInfoPointService = new MapInfoPointService(query, db, ContactID);
                        mapInfoPointList = (from c in db.MapInfoPoints select c).OrderBy(c => c.MapInfoPointID).Skip(0).Take(2).ToList();
                        count = (from c in db.MapInfoPoints select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with MapInfoPoint info
                        jsonRet = mapInfoPointController.GetMapInfoPointList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(mapInfoPointList[0].MapInfoPointID, ((List<MapInfoPoint>)ret.Value)[0].MapInfoPointID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<MapInfoPoint>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with MapInfoPoint info
                           IActionResult jsonRet2 = mapInfoPointController.GetMapInfoPointList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(mapInfoPointList[1].MapInfoPointID, ((List<MapInfoPoint>)ret2.Value)[0].MapInfoPointID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<MapInfoPoint>)ret2.Value).Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void MapInfoPoint_Controller_GetMapInfoPointWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MapInfoPointController mapInfoPointController = new MapInfoPointController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mapInfoPointController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mapInfoPointController.DatabaseType);

                    MapInfoPoint mapInfoPointFirst = new MapInfoPoint();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        MapInfoPointService mapInfoPointService = new MapInfoPointService(new Query(), db, ContactID);
                        mapInfoPointFirst = (from c in db.MapInfoPoints select c).FirstOrDefault();
                    }

                    // ok with MapInfoPoint info
                    IActionResult jsonRet = mapInfoPointController.GetMapInfoPointWithID(mapInfoPointFirst.MapInfoPointID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(mapInfoPointFirst.MapInfoPointID, ((MapInfoPoint)ret.Value).MapInfoPointID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = mapInfoPointController.GetMapInfoPointWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult mapInfoPointRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(mapInfoPointRet2);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void MapInfoPoint_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MapInfoPointController mapInfoPointController = new MapInfoPointController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mapInfoPointController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mapInfoPointController.DatabaseType);

                    MapInfoPoint mapInfoPointFirst = new MapInfoPoint();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MapInfoPointService mapInfoPointService = new MapInfoPointService(query, db, ContactID);
                        mapInfoPointFirst = (from c in db.MapInfoPoints select c).FirstOrDefault();
                    }

                    // ok with MapInfoPoint info
                    IActionResult jsonRet = mapInfoPointController.GetMapInfoPointWithID(mapInfoPointFirst.MapInfoPointID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    MapInfoPoint mapInfoPointRet = (MapInfoPoint)ret.Value;
                    Assert.Equal(mapInfoPointFirst.MapInfoPointID, mapInfoPointRet.MapInfoPointID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because MapInfoPointID exist
                    IActionResult jsonRet2 = mapInfoPointController.Post(mapInfoPointRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added MapInfoPoint
                    mapInfoPointRet.MapInfoPointID = 0;
                    IActionResult jsonRet3 = mapInfoPointController.Post(mapInfoPointRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = mapInfoPointController.Delete(mapInfoPointRet, LanguageRequest.ToString());
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
        public void MapInfoPoint_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MapInfoPointController mapInfoPointController = new MapInfoPointController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mapInfoPointController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mapInfoPointController.DatabaseType);

                    MapInfoPoint mapInfoPointFirst = new MapInfoPoint();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        MapInfoPointService mapInfoPointService = new MapInfoPointService(query, db, ContactID);
                        mapInfoPointFirst = (from c in db.MapInfoPoints select c).FirstOrDefault();
                    }

                    // ok with MapInfoPoint info
                    IActionResult jsonRet = mapInfoPointController.GetMapInfoPointWithID(mapInfoPointFirst.MapInfoPointID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    MapInfoPoint mapInfoPointRet = (MapInfoPoint)Ret.Value;
                    Assert.Equal(mapInfoPointFirst.MapInfoPointID, mapInfoPointRet.MapInfoPointID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = mapInfoPointController.Put(mapInfoPointRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult mapInfoPointRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(mapInfoPointRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because MapInfoPointID of 0 does not exist
                    mapInfoPointRet.MapInfoPointID = 0;
                    IActionResult jsonRet3 = mapInfoPointController.Put(mapInfoPointRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult mapInfoPointRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(mapInfoPointRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void MapInfoPoint_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MapInfoPointController mapInfoPointController = new MapInfoPointController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mapInfoPointController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mapInfoPointController.DatabaseType);

                    MapInfoPoint mapInfoPointFirst = new MapInfoPoint();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MapInfoPointService mapInfoPointService = new MapInfoPointService(query, db, ContactID);
                        mapInfoPointFirst = (from c in db.MapInfoPoints select c).FirstOrDefault();
                    }

                    // ok with MapInfoPoint info
                    IActionResult jsonRet = mapInfoPointController.GetMapInfoPointWithID(mapInfoPointFirst.MapInfoPointID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    MapInfoPoint mapInfoPointRet = (MapInfoPoint)Ret.Value;
                    Assert.Equal(mapInfoPointFirst.MapInfoPointID, mapInfoPointRet.MapInfoPointID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added MapInfoPoint
                    mapInfoPointRet.MapInfoPointID = 0;
                    IActionResult jsonRet3 = mapInfoPointController.Post(mapInfoPointRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    MapInfoPoint mapInfoPoint = (MapInfoPoint)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = mapInfoPointController.Delete(mapInfoPointRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because MapInfoPointID of 0 does not exist
                    mapInfoPointRet.MapInfoPointID = 0;
                    IActionResult jsonRet4 = mapInfoPointController.Delete(mapInfoPointRet, LanguageRequest.ToString());
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
