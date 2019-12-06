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
    public partial class TideLocationControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TideLocationControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [TestMethod]
        public void TideLocation_Controller_GetTideLocationList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TideLocationController tideLocationController = new TideLocationController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(tideLocationController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, tideLocationController.DatabaseType);

                    TideLocation tideLocationFirst = new TideLocation();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        TideLocationService tideLocationService = new TideLocationService(query, db, ContactID);
                        tideLocationFirst = (from c in db.TideLocations select c).FirstOrDefault();
                        count = (from c in db.TideLocations select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with TideLocation info
                    IHttpActionResult jsonRet = tideLocationController.GetTideLocationList();
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<List<TideLocation>> ret = jsonRet as OkNegotiatedContentResult<List<TideLocation>>;
                    Assert.AreEqual(tideLocationFirst.TideLocationID, ret.Content[0].TideLocationID);
                    Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<TideLocation> tideLocationList = new List<TideLocation>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        TideLocationService tideLocationService = new TideLocationService(query, db, ContactID);
                        tideLocationList = (from c in db.TideLocations select c).OrderBy(c => c.TideLocationID).Skip(0).Take(2).ToList();
                        count = (from c in db.TideLocations select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with TideLocation info
                        jsonRet = tideLocationController.GetTideLocationList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsNotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<TideLocation>>;
                        Assert.AreEqual(tideLocationList[0].TideLocationID, ret.Content[0].TideLocationID);
                        Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with TideLocation info
                           IHttpActionResult jsonRet2 = tideLocationController.GetTideLocationList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.IsNotNull(jsonRet2);

                           OkNegotiatedContentResult<List<TideLocation>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<TideLocation>>;
                           Assert.AreEqual(tideLocationList[1].TideLocationID, ret2.Content[0].TideLocationID);
                           Assert.AreEqual((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [TestMethod]
        public void TideLocation_Controller_GetTideLocationWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TideLocationController tideLocationController = new TideLocationController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(tideLocationController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, tideLocationController.DatabaseType);

                    TideLocation tideLocationFirst = new TideLocation();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        TideLocationService tideLocationService = new TideLocationService(new Query(), db, ContactID);
                        tideLocationFirst = (from c in db.TideLocations select c).FirstOrDefault();
                    }

                    // ok with TideLocation info
                    IHttpActionResult jsonRet = tideLocationController.GetTideLocationWithID(tideLocationFirst.TideLocationID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<TideLocation> Ret = jsonRet as OkNegotiatedContentResult<TideLocation>;
                    TideLocation tideLocationRet = Ret.Content;
                    Assert.AreEqual(tideLocationFirst.TideLocationID, tideLocationRet.TideLocationID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = tideLocationController.GetTideLocationWithID(0);
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<TideLocation> tideLocationRet2 = jsonRet2 as OkNegotiatedContentResult<TideLocation>;
                    Assert.IsNull(tideLocationRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.IsNotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [TestMethod]
        public void TideLocation_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TideLocationController tideLocationController = new TideLocationController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(tideLocationController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, tideLocationController.DatabaseType);

                    TideLocation tideLocationLast = new TideLocation();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        TideLocationService tideLocationService = new TideLocationService(query, db, ContactID);
                        tideLocationLast = (from c in db.TideLocations select c).FirstOrDefault();
                    }

                    // ok with TideLocation info
                    IHttpActionResult jsonRet = tideLocationController.GetTideLocationWithID(tideLocationLast.TideLocationID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<TideLocation> Ret = jsonRet as OkNegotiatedContentResult<TideLocation>;
                    TideLocation tideLocationRet = Ret.Content;
                    Assert.AreEqual(tideLocationLast.TideLocationID, tideLocationRet.TideLocationID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because TideLocationID exist
                    IHttpActionResult jsonRet2 = tideLocationController.Post(tideLocationRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<TideLocation> tideLocationRet2 = jsonRet2 as OkNegotiatedContentResult<TideLocation>;
                    Assert.IsNull(tideLocationRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest2);

                    // Post to return newly added TideLocation
                    tideLocationRet.TideLocationID = 0;
                    tideLocationController.Request = new System.Net.Http.HttpRequestMessage();
                    tideLocationController.Request.RequestUri = new System.Uri("http://localhost:5000/api/tideLocation");
                    IHttpActionResult jsonRet3 = tideLocationController.Post(tideLocationRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<TideLocation> tideLocationRet3 = jsonRet3 as CreatedNegotiatedContentResult<TideLocation>;
                    Assert.IsNotNull(tideLocationRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = tideLocationController.Delete(tideLocationRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<TideLocation> tideLocationRet4 = jsonRet4 as OkNegotiatedContentResult<TideLocation>;
                    Assert.IsNotNull(tideLocationRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [TestMethod]
        public void TideLocation_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TideLocationController tideLocationController = new TideLocationController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(tideLocationController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, tideLocationController.DatabaseType);

                    TideLocation tideLocationLast = new TideLocation();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        TideLocationService tideLocationService = new TideLocationService(query, db, ContactID);
                        tideLocationLast = (from c in db.TideLocations select c).FirstOrDefault();
                    }

                    // ok with TideLocation info
                    IHttpActionResult jsonRet = tideLocationController.GetTideLocationWithID(tideLocationLast.TideLocationID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<TideLocation> Ret = jsonRet as OkNegotiatedContentResult<TideLocation>;
                    TideLocation tideLocationRet = Ret.Content;
                    Assert.AreEqual(tideLocationLast.TideLocationID, tideLocationRet.TideLocationID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = tideLocationController.Put(tideLocationRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<TideLocation> tideLocationRet2 = jsonRet2 as OkNegotiatedContentResult<TideLocation>;
                    Assert.IsNotNull(tideLocationRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because TideLocationID of 0 does not exist
                    tideLocationRet.TideLocationID = 0;
                    IHttpActionResult jsonRet3 = tideLocationController.Put(tideLocationRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    OkNegotiatedContentResult<TideLocation> tideLocationRet3 = jsonRet3 as OkNegotiatedContentResult<TideLocation>;
                    Assert.IsNull(tideLocationRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [TestMethod]
        public void TideLocation_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TideLocationController tideLocationController = new TideLocationController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(tideLocationController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, tideLocationController.DatabaseType);

                    TideLocation tideLocationLast = new TideLocation();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        TideLocationService tideLocationService = new TideLocationService(query, db, ContactID);
                        tideLocationLast = (from c in db.TideLocations select c).FirstOrDefault();
                    }

                    // ok with TideLocation info
                    IHttpActionResult jsonRet = tideLocationController.GetTideLocationWithID(tideLocationLast.TideLocationID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<TideLocation> Ret = jsonRet as OkNegotiatedContentResult<TideLocation>;
                    TideLocation tideLocationRet = Ret.Content;
                    Assert.AreEqual(tideLocationLast.TideLocationID, tideLocationRet.TideLocationID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added TideLocation
                    tideLocationRet.TideLocationID = 0;
                    tideLocationController.Request = new System.Net.Http.HttpRequestMessage();
                    tideLocationController.Request.RequestUri = new System.Uri("http://localhost:5000/api/tideLocation");
                    IHttpActionResult jsonRet3 = tideLocationController.Post(tideLocationRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<TideLocation> tideLocationRet3 = jsonRet3 as CreatedNegotiatedContentResult<TideLocation>;
                    Assert.IsNotNull(tideLocationRet3);
                    TideLocation tideLocation = tideLocationRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = tideLocationController.Delete(tideLocationRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<TideLocation> tideLocationRet2 = jsonRet2 as OkNegotiatedContentResult<TideLocation>;
                    Assert.IsNotNull(tideLocationRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because TideLocationID of 0 does not exist
                    tideLocationRet.TideLocationID = 0;
                    IHttpActionResult jsonRet4 = tideLocationController.Delete(tideLocationRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<TideLocation> tideLocationRet4 = jsonRet4 as OkNegotiatedContentResult<TideLocation>;
                    Assert.IsNull(tideLocationRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
