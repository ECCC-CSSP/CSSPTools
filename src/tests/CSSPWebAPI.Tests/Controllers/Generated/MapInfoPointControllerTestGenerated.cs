using CSSPEnums;
using CSSPModels;
using CSSPServices;
using CSSPWebAPI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;

namespace CSSPWebAPI.Tests.Controllers
{
    [TestClass]
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
        [TestMethod]
        public void MapInfoPoint_Controller_GetMapInfoPointList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MapInfoPointController mapInfoPointController = new MapInfoPointController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mapInfoPointController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mapInfoPointController.DatabaseType);

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
                    IHttpActionResult jsonRet = mapInfoPointController.GetMapInfoPointList();
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<List<MapInfoPoint>> ret = jsonRet as OkNegotiatedContentResult<List<MapInfoPoint>>;
                    Assert.AreEqual(mapInfoPointFirst.MapInfoPointID, ret.Content[0].MapInfoPointID);
                    Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

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
                        Assert.IsNotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<MapInfoPoint>>;
                        Assert.AreEqual(mapInfoPointList[0].MapInfoPointID, ret.Content[0].MapInfoPointID);
                        Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with MapInfoPoint info
                           IHttpActionResult jsonRet2 = mapInfoPointController.GetMapInfoPointList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.IsNotNull(jsonRet2);

                           OkNegotiatedContentResult<List<MapInfoPoint>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<MapInfoPoint>>;
                           Assert.AreEqual(mapInfoPointList[1].MapInfoPointID, ret2.Content[0].MapInfoPointID);
                           Assert.AreEqual((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [TestMethod]
        public void MapInfoPoint_Controller_GetMapInfoPointWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MapInfoPointController mapInfoPointController = new MapInfoPointController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mapInfoPointController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mapInfoPointController.DatabaseType);

                    MapInfoPoint mapInfoPointFirst = new MapInfoPoint();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        MapInfoPointService mapInfoPointService = new MapInfoPointService(new Query(), db, ContactID);
                        mapInfoPointFirst = (from c in db.MapInfoPoints select c).FirstOrDefault();
                    }

                    // ok with MapInfoPoint info
                    IHttpActionResult jsonRet = mapInfoPointController.GetMapInfoPointWithID(mapInfoPointFirst.MapInfoPointID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<MapInfoPoint> Ret = jsonRet as OkNegotiatedContentResult<MapInfoPoint>;
                    MapInfoPoint mapInfoPointRet = Ret.Content;
                    Assert.AreEqual(mapInfoPointFirst.MapInfoPointID, mapInfoPointRet.MapInfoPointID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = mapInfoPointController.GetMapInfoPointWithID(0);
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<MapInfoPoint> mapInfoPointRet2 = jsonRet2 as OkNegotiatedContentResult<MapInfoPoint>;
                    Assert.IsNull(mapInfoPointRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.IsNotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [TestMethod]
        public void MapInfoPoint_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MapInfoPointController mapInfoPointController = new MapInfoPointController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mapInfoPointController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mapInfoPointController.DatabaseType);

                    MapInfoPoint mapInfoPointLast = new MapInfoPoint();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MapInfoPointService mapInfoPointService = new MapInfoPointService(query, db, ContactID);
                        mapInfoPointLast = (from c in db.MapInfoPoints select c).FirstOrDefault();
                    }

                    // ok with MapInfoPoint info
                    IHttpActionResult jsonRet = mapInfoPointController.GetMapInfoPointWithID(mapInfoPointLast.MapInfoPointID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<MapInfoPoint> Ret = jsonRet as OkNegotiatedContentResult<MapInfoPoint>;
                    MapInfoPoint mapInfoPointRet = Ret.Content;
                    Assert.AreEqual(mapInfoPointLast.MapInfoPointID, mapInfoPointRet.MapInfoPointID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because MapInfoPointID exist
                    IHttpActionResult jsonRet2 = mapInfoPointController.Post(mapInfoPointRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<MapInfoPoint> mapInfoPointRet2 = jsonRet2 as OkNegotiatedContentResult<MapInfoPoint>;
                    Assert.IsNull(mapInfoPointRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest2);

                    // Post to return newly added MapInfoPoint
                    mapInfoPointRet.MapInfoPointID = 0;
                    mapInfoPointController.Request = new System.Net.Http.HttpRequestMessage();
                    mapInfoPointController.Request.RequestUri = new System.Uri("http://localhost:5000/api/mapInfoPoint");
                    IHttpActionResult jsonRet3 = mapInfoPointController.Post(mapInfoPointRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<MapInfoPoint> mapInfoPointRet3 = jsonRet3 as CreatedNegotiatedContentResult<MapInfoPoint>;
                    Assert.IsNotNull(mapInfoPointRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = mapInfoPointController.Delete(mapInfoPointRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<MapInfoPoint> mapInfoPointRet4 = jsonRet4 as OkNegotiatedContentResult<MapInfoPoint>;
                    Assert.IsNotNull(mapInfoPointRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [TestMethod]
        public void MapInfoPoint_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MapInfoPointController mapInfoPointController = new MapInfoPointController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mapInfoPointController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mapInfoPointController.DatabaseType);

                    MapInfoPoint mapInfoPointLast = new MapInfoPoint();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        MapInfoPointService mapInfoPointService = new MapInfoPointService(query, db, ContactID);
                        mapInfoPointLast = (from c in db.MapInfoPoints select c).FirstOrDefault();
                    }

                    // ok with MapInfoPoint info
                    IHttpActionResult jsonRet = mapInfoPointController.GetMapInfoPointWithID(mapInfoPointLast.MapInfoPointID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<MapInfoPoint> Ret = jsonRet as OkNegotiatedContentResult<MapInfoPoint>;
                    MapInfoPoint mapInfoPointRet = Ret.Content;
                    Assert.AreEqual(mapInfoPointLast.MapInfoPointID, mapInfoPointRet.MapInfoPointID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = mapInfoPointController.Put(mapInfoPointRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<MapInfoPoint> mapInfoPointRet2 = jsonRet2 as OkNegotiatedContentResult<MapInfoPoint>;
                    Assert.IsNotNull(mapInfoPointRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because MapInfoPointID of 0 does not exist
                    mapInfoPointRet.MapInfoPointID = 0;
                    IHttpActionResult jsonRet3 = mapInfoPointController.Put(mapInfoPointRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    OkNegotiatedContentResult<MapInfoPoint> mapInfoPointRet3 = jsonRet3 as OkNegotiatedContentResult<MapInfoPoint>;
                    Assert.IsNull(mapInfoPointRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [TestMethod]
        public void MapInfoPoint_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MapInfoPointController mapInfoPointController = new MapInfoPointController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mapInfoPointController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mapInfoPointController.DatabaseType);

                    MapInfoPoint mapInfoPointLast = new MapInfoPoint();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MapInfoPointService mapInfoPointService = new MapInfoPointService(query, db, ContactID);
                        mapInfoPointLast = (from c in db.MapInfoPoints select c).FirstOrDefault();
                    }

                    // ok with MapInfoPoint info
                    IHttpActionResult jsonRet = mapInfoPointController.GetMapInfoPointWithID(mapInfoPointLast.MapInfoPointID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<MapInfoPoint> Ret = jsonRet as OkNegotiatedContentResult<MapInfoPoint>;
                    MapInfoPoint mapInfoPointRet = Ret.Content;
                    Assert.AreEqual(mapInfoPointLast.MapInfoPointID, mapInfoPointRet.MapInfoPointID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added MapInfoPoint
                    mapInfoPointRet.MapInfoPointID = 0;
                    mapInfoPointController.Request = new System.Net.Http.HttpRequestMessage();
                    mapInfoPointController.Request.RequestUri = new System.Uri("http://localhost:5000/api/mapInfoPoint");
                    IHttpActionResult jsonRet3 = mapInfoPointController.Post(mapInfoPointRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<MapInfoPoint> mapInfoPointRet3 = jsonRet3 as CreatedNegotiatedContentResult<MapInfoPoint>;
                    Assert.IsNotNull(mapInfoPointRet3);
                    MapInfoPoint mapInfoPoint = mapInfoPointRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = mapInfoPointController.Delete(mapInfoPointRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<MapInfoPoint> mapInfoPointRet2 = jsonRet2 as OkNegotiatedContentResult<MapInfoPoint>;
                    Assert.IsNotNull(mapInfoPointRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because MapInfoPointID of 0 does not exist
                    mapInfoPointRet.MapInfoPointID = 0;
                    IHttpActionResult jsonRet4 = mapInfoPointController.Delete(mapInfoPointRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<MapInfoPoint> mapInfoPointRet4 = jsonRet4 as OkNegotiatedContentResult<MapInfoPoint>;
                    Assert.IsNull(mapInfoPointRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
