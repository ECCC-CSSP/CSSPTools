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
    public partial class RatingCurveControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public RatingCurveControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [TestMethod]
        public void RatingCurve_Controller_GetRatingCurveList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    RatingCurveController ratingCurveController = new RatingCurveController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(ratingCurveController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, ratingCurveController.DatabaseType);

                    RatingCurve ratingCurveFirst = new RatingCurve();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        RatingCurveService ratingCurveService = new RatingCurveService(query, db, ContactID);
                        ratingCurveFirst = (from c in db.RatingCurves select c).FirstOrDefault();
                        count = (from c in db.RatingCurves select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with RatingCurve info
                    IHttpActionResult jsonRet = ratingCurveController.GetRatingCurveList();
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<List<RatingCurve>> ret = jsonRet as OkNegotiatedContentResult<List<RatingCurve>>;
                    Assert.AreEqual(ratingCurveFirst.RatingCurveID, ret.Content[0].RatingCurveID);
                    Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<RatingCurve> ratingCurveList = new List<RatingCurve>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        RatingCurveService ratingCurveService = new RatingCurveService(query, db, ContactID);
                        ratingCurveList = (from c in db.RatingCurves select c).OrderBy(c => c.RatingCurveID).Skip(0).Take(2).ToList();
                        count = (from c in db.RatingCurves select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with RatingCurve info
                        jsonRet = ratingCurveController.GetRatingCurveList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsNotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<RatingCurve>>;
                        Assert.AreEqual(ratingCurveList[0].RatingCurveID, ret.Content[0].RatingCurveID);
                        Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with RatingCurve info
                           IHttpActionResult jsonRet2 = ratingCurveController.GetRatingCurveList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.IsNotNull(jsonRet2);

                           OkNegotiatedContentResult<List<RatingCurve>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<RatingCurve>>;
                           Assert.AreEqual(ratingCurveList[1].RatingCurveID, ret2.Content[0].RatingCurveID);
                           Assert.AreEqual((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [TestMethod]
        public void RatingCurve_Controller_GetRatingCurveWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    RatingCurveController ratingCurveController = new RatingCurveController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(ratingCurveController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, ratingCurveController.DatabaseType);

                    RatingCurve ratingCurveFirst = new RatingCurve();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        RatingCurveService ratingCurveService = new RatingCurveService(new Query(), db, ContactID);
                        ratingCurveFirst = (from c in db.RatingCurves select c).FirstOrDefault();
                    }

                    // ok with RatingCurve info
                    IHttpActionResult jsonRet = ratingCurveController.GetRatingCurveWithID(ratingCurveFirst.RatingCurveID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<RatingCurve> Ret = jsonRet as OkNegotiatedContentResult<RatingCurve>;
                    RatingCurve ratingCurveRet = Ret.Content;
                    Assert.AreEqual(ratingCurveFirst.RatingCurveID, ratingCurveRet.RatingCurveID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = ratingCurveController.GetRatingCurveWithID(0);
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<RatingCurve> ratingCurveRet2 = jsonRet2 as OkNegotiatedContentResult<RatingCurve>;
                    Assert.IsNull(ratingCurveRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.IsNotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [TestMethod]
        public void RatingCurve_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    RatingCurveController ratingCurveController = new RatingCurveController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(ratingCurveController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, ratingCurveController.DatabaseType);

                    RatingCurve ratingCurveLast = new RatingCurve();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        RatingCurveService ratingCurveService = new RatingCurveService(query, db, ContactID);
                        ratingCurveLast = (from c in db.RatingCurves select c).FirstOrDefault();
                    }

                    // ok with RatingCurve info
                    IHttpActionResult jsonRet = ratingCurveController.GetRatingCurveWithID(ratingCurveLast.RatingCurveID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<RatingCurve> Ret = jsonRet as OkNegotiatedContentResult<RatingCurve>;
                    RatingCurve ratingCurveRet = Ret.Content;
                    Assert.AreEqual(ratingCurveLast.RatingCurveID, ratingCurveRet.RatingCurveID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because RatingCurveID exist
                    IHttpActionResult jsonRet2 = ratingCurveController.Post(ratingCurveRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<RatingCurve> ratingCurveRet2 = jsonRet2 as OkNegotiatedContentResult<RatingCurve>;
                    Assert.IsNull(ratingCurveRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest2);

                    // Post to return newly added RatingCurve
                    ratingCurveRet.RatingCurveID = 0;
                    ratingCurveController.Request = new System.Net.Http.HttpRequestMessage();
                    ratingCurveController.Request.RequestUri = new System.Uri("http://localhost:5000/api/ratingCurve");
                    IHttpActionResult jsonRet3 = ratingCurveController.Post(ratingCurveRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<RatingCurve> ratingCurveRet3 = jsonRet3 as CreatedNegotiatedContentResult<RatingCurve>;
                    Assert.IsNotNull(ratingCurveRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = ratingCurveController.Delete(ratingCurveRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<RatingCurve> ratingCurveRet4 = jsonRet4 as OkNegotiatedContentResult<RatingCurve>;
                    Assert.IsNotNull(ratingCurveRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [TestMethod]
        public void RatingCurve_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    RatingCurveController ratingCurveController = new RatingCurveController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(ratingCurveController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, ratingCurveController.DatabaseType);

                    RatingCurve ratingCurveLast = new RatingCurve();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        RatingCurveService ratingCurveService = new RatingCurveService(query, db, ContactID);
                        ratingCurveLast = (from c in db.RatingCurves select c).FirstOrDefault();
                    }

                    // ok with RatingCurve info
                    IHttpActionResult jsonRet = ratingCurveController.GetRatingCurveWithID(ratingCurveLast.RatingCurveID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<RatingCurve> Ret = jsonRet as OkNegotiatedContentResult<RatingCurve>;
                    RatingCurve ratingCurveRet = Ret.Content;
                    Assert.AreEqual(ratingCurveLast.RatingCurveID, ratingCurveRet.RatingCurveID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = ratingCurveController.Put(ratingCurveRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<RatingCurve> ratingCurveRet2 = jsonRet2 as OkNegotiatedContentResult<RatingCurve>;
                    Assert.IsNotNull(ratingCurveRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because RatingCurveID of 0 does not exist
                    ratingCurveRet.RatingCurveID = 0;
                    IHttpActionResult jsonRet3 = ratingCurveController.Put(ratingCurveRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    OkNegotiatedContentResult<RatingCurve> ratingCurveRet3 = jsonRet3 as OkNegotiatedContentResult<RatingCurve>;
                    Assert.IsNull(ratingCurveRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [TestMethod]
        public void RatingCurve_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    RatingCurveController ratingCurveController = new RatingCurveController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(ratingCurveController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, ratingCurveController.DatabaseType);

                    RatingCurve ratingCurveLast = new RatingCurve();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        RatingCurveService ratingCurveService = new RatingCurveService(query, db, ContactID);
                        ratingCurveLast = (from c in db.RatingCurves select c).FirstOrDefault();
                    }

                    // ok with RatingCurve info
                    IHttpActionResult jsonRet = ratingCurveController.GetRatingCurveWithID(ratingCurveLast.RatingCurveID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<RatingCurve> Ret = jsonRet as OkNegotiatedContentResult<RatingCurve>;
                    RatingCurve ratingCurveRet = Ret.Content;
                    Assert.AreEqual(ratingCurveLast.RatingCurveID, ratingCurveRet.RatingCurveID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added RatingCurve
                    ratingCurveRet.RatingCurveID = 0;
                    ratingCurveController.Request = new System.Net.Http.HttpRequestMessage();
                    ratingCurveController.Request.RequestUri = new System.Uri("http://localhost:5000/api/ratingCurve");
                    IHttpActionResult jsonRet3 = ratingCurveController.Post(ratingCurveRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<RatingCurve> ratingCurveRet3 = jsonRet3 as CreatedNegotiatedContentResult<RatingCurve>;
                    Assert.IsNotNull(ratingCurveRet3);
                    RatingCurve ratingCurve = ratingCurveRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = ratingCurveController.Delete(ratingCurveRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<RatingCurve> ratingCurveRet2 = jsonRet2 as OkNegotiatedContentResult<RatingCurve>;
                    Assert.IsNotNull(ratingCurveRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because RatingCurveID of 0 does not exist
                    ratingCurveRet.RatingCurveID = 0;
                    IHttpActionResult jsonRet4 = ratingCurveController.Delete(ratingCurveRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<RatingCurve> ratingCurveRet4 = jsonRet4 as OkNegotiatedContentResult<RatingCurve>;
                    Assert.IsNull(ratingCurveRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
