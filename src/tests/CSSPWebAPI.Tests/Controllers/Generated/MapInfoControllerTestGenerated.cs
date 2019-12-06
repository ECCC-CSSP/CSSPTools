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
        [TestMethod]
        public void MapInfo_Controller_GetMapInfoList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MapInfoController mapInfoController = new MapInfoController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mapInfoController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mapInfoController.DatabaseType);

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
                    IHttpActionResult jsonRet = mapInfoController.GetMapInfoList();
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<List<MapInfo>> ret = jsonRet as OkNegotiatedContentResult<List<MapInfo>>;
                    Assert.AreEqual(mapInfoFirst.MapInfoID, ret.Content[0].MapInfoID);
                    Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

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
                        Assert.IsNotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<MapInfo>>;
                        Assert.AreEqual(mapInfoList[0].MapInfoID, ret.Content[0].MapInfoID);
                        Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with MapInfo info
                           IHttpActionResult jsonRet2 = mapInfoController.GetMapInfoList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.IsNotNull(jsonRet2);

                           OkNegotiatedContentResult<List<MapInfo>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<MapInfo>>;
                           Assert.AreEqual(mapInfoList[1].MapInfoID, ret2.Content[0].MapInfoID);
                           Assert.AreEqual((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [TestMethod]
        public void MapInfo_Controller_GetMapInfoWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MapInfoController mapInfoController = new MapInfoController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mapInfoController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mapInfoController.DatabaseType);

                    MapInfo mapInfoFirst = new MapInfo();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        MapInfoService mapInfoService = new MapInfoService(new Query(), db, ContactID);
                        mapInfoFirst = (from c in db.MapInfos select c).FirstOrDefault();
                    }

                    // ok with MapInfo info
                    IHttpActionResult jsonRet = mapInfoController.GetMapInfoWithID(mapInfoFirst.MapInfoID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<MapInfo> Ret = jsonRet as OkNegotiatedContentResult<MapInfo>;
                    MapInfo mapInfoRet = Ret.Content;
                    Assert.AreEqual(mapInfoFirst.MapInfoID, mapInfoRet.MapInfoID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = mapInfoController.GetMapInfoWithID(0);
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<MapInfo> mapInfoRet2 = jsonRet2 as OkNegotiatedContentResult<MapInfo>;
                    Assert.IsNull(mapInfoRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.IsNotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [TestMethod]
        public void MapInfo_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MapInfoController mapInfoController = new MapInfoController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mapInfoController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mapInfoController.DatabaseType);

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
                    IHttpActionResult jsonRet = mapInfoController.GetMapInfoWithID(mapInfoLast.MapInfoID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<MapInfo> Ret = jsonRet as OkNegotiatedContentResult<MapInfo>;
                    MapInfo mapInfoRet = Ret.Content;
                    Assert.AreEqual(mapInfoLast.MapInfoID, mapInfoRet.MapInfoID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because MapInfoID exist
                    IHttpActionResult jsonRet2 = mapInfoController.Post(mapInfoRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<MapInfo> mapInfoRet2 = jsonRet2 as OkNegotiatedContentResult<MapInfo>;
                    Assert.IsNull(mapInfoRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest2);

                    // Post to return newly added MapInfo
                    mapInfoRet.MapInfoID = 0;
                    mapInfoController.Request = new System.Net.Http.HttpRequestMessage();
                    mapInfoController.Request.RequestUri = new System.Uri("http://localhost:5000/api/mapInfo");
                    IHttpActionResult jsonRet3 = mapInfoController.Post(mapInfoRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<MapInfo> mapInfoRet3 = jsonRet3 as CreatedNegotiatedContentResult<MapInfo>;
                    Assert.IsNotNull(mapInfoRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = mapInfoController.Delete(mapInfoRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<MapInfo> mapInfoRet4 = jsonRet4 as OkNegotiatedContentResult<MapInfo>;
                    Assert.IsNotNull(mapInfoRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [TestMethod]
        public void MapInfo_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MapInfoController mapInfoController = new MapInfoController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mapInfoController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mapInfoController.DatabaseType);

                    MapInfo mapInfoLast = new MapInfo();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        MapInfoService mapInfoService = new MapInfoService(query, db, ContactID);
                        mapInfoLast = (from c in db.MapInfos select c).FirstOrDefault();
                    }

                    // ok with MapInfo info
                    IHttpActionResult jsonRet = mapInfoController.GetMapInfoWithID(mapInfoLast.MapInfoID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<MapInfo> Ret = jsonRet as OkNegotiatedContentResult<MapInfo>;
                    MapInfo mapInfoRet = Ret.Content;
                    Assert.AreEqual(mapInfoLast.MapInfoID, mapInfoRet.MapInfoID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = mapInfoController.Put(mapInfoRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<MapInfo> mapInfoRet2 = jsonRet2 as OkNegotiatedContentResult<MapInfo>;
                    Assert.IsNotNull(mapInfoRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because MapInfoID of 0 does not exist
                    mapInfoRet.MapInfoID = 0;
                    IHttpActionResult jsonRet3 = mapInfoController.Put(mapInfoRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    OkNegotiatedContentResult<MapInfo> mapInfoRet3 = jsonRet3 as OkNegotiatedContentResult<MapInfo>;
                    Assert.IsNull(mapInfoRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [TestMethod]
        public void MapInfo_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MapInfoController mapInfoController = new MapInfoController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mapInfoController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mapInfoController.DatabaseType);

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
                    IHttpActionResult jsonRet = mapInfoController.GetMapInfoWithID(mapInfoLast.MapInfoID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<MapInfo> Ret = jsonRet as OkNegotiatedContentResult<MapInfo>;
                    MapInfo mapInfoRet = Ret.Content;
                    Assert.AreEqual(mapInfoLast.MapInfoID, mapInfoRet.MapInfoID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added MapInfo
                    mapInfoRet.MapInfoID = 0;
                    mapInfoController.Request = new System.Net.Http.HttpRequestMessage();
                    mapInfoController.Request.RequestUri = new System.Uri("http://localhost:5000/api/mapInfo");
                    IHttpActionResult jsonRet3 = mapInfoController.Post(mapInfoRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<MapInfo> mapInfoRet3 = jsonRet3 as CreatedNegotiatedContentResult<MapInfo>;
                    Assert.IsNotNull(mapInfoRet3);
                    MapInfo mapInfo = mapInfoRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = mapInfoController.Delete(mapInfoRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<MapInfo> mapInfoRet2 = jsonRet2 as OkNegotiatedContentResult<MapInfo>;
                    Assert.IsNotNull(mapInfoRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because MapInfoID of 0 does not exist
                    mapInfoRet.MapInfoID = 0;
                    IHttpActionResult jsonRet4 = mapInfoController.Delete(mapInfoRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<MapInfo> mapInfoRet4 = jsonRet4 as OkNegotiatedContentResult<MapInfo>;
                    Assert.IsNull(mapInfoRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
