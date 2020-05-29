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
    public partial class RainExceedanceControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public RainExceedanceControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [TestMethod]
        public void RainExceedance_Controller_GetRainExceedanceList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    RainExceedanceController rainExceedanceController = new RainExceedanceController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(rainExceedanceController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, rainExceedanceController.DatabaseType);

                    RainExceedance rainExceedanceFirst = new RainExceedance();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        RainExceedanceService rainExceedanceService = new RainExceedanceService(query, db, ContactID);
                        rainExceedanceFirst = (from c in db.RainExceedances select c).FirstOrDefault();
                        count = (from c in db.RainExceedances select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with RainExceedance info
                    IHttpActionResult jsonRet = rainExceedanceController.GetRainExceedanceList();
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<List<RainExceedance>> ret = jsonRet as OkNegotiatedContentResult<List<RainExceedance>>;
                    Assert.AreEqual(rainExceedanceFirst.RainExceedanceID, ret.Content[0].RainExceedanceID);
                    Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<RainExceedance> rainExceedanceList = new List<RainExceedance>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        RainExceedanceService rainExceedanceService = new RainExceedanceService(query, db, ContactID);
                        rainExceedanceList = (from c in db.RainExceedances select c).OrderBy(c => c.RainExceedanceID).Skip(0).Take(2).ToList();
                        count = (from c in db.RainExceedances select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with RainExceedance info
                        jsonRet = rainExceedanceController.GetRainExceedanceList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsNotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<RainExceedance>>;
                        Assert.AreEqual(rainExceedanceList[0].RainExceedanceID, ret.Content[0].RainExceedanceID);
                        Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with RainExceedance info
                           IHttpActionResult jsonRet2 = rainExceedanceController.GetRainExceedanceList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.IsNotNull(jsonRet2);

                           OkNegotiatedContentResult<List<RainExceedance>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<RainExceedance>>;
                           Assert.AreEqual(rainExceedanceList[1].RainExceedanceID, ret2.Content[0].RainExceedanceID);
                           Assert.AreEqual((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [TestMethod]
        public void RainExceedance_Controller_GetRainExceedanceWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    RainExceedanceController rainExceedanceController = new RainExceedanceController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(rainExceedanceController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, rainExceedanceController.DatabaseType);

                    RainExceedance rainExceedanceFirst = new RainExceedance();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        RainExceedanceService rainExceedanceService = new RainExceedanceService(new Query(), db, ContactID);
                        rainExceedanceFirst = (from c in db.RainExceedances select c).FirstOrDefault();
                    }

                    // ok with RainExceedance info
                    IHttpActionResult jsonRet = rainExceedanceController.GetRainExceedanceWithID(rainExceedanceFirst.RainExceedanceID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<RainExceedance> Ret = jsonRet as OkNegotiatedContentResult<RainExceedance>;
                    RainExceedance rainExceedanceRet = Ret.Content;
                    Assert.AreEqual(rainExceedanceFirst.RainExceedanceID, rainExceedanceRet.RainExceedanceID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = rainExceedanceController.GetRainExceedanceWithID(0);
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<RainExceedance> rainExceedanceRet2 = jsonRet2 as OkNegotiatedContentResult<RainExceedance>;
                    Assert.IsNull(rainExceedanceRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.IsNotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [TestMethod]
        public void RainExceedance_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    RainExceedanceController rainExceedanceController = new RainExceedanceController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(rainExceedanceController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, rainExceedanceController.DatabaseType);

                    RainExceedance rainExceedanceLast = new RainExceedance();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        RainExceedanceService rainExceedanceService = new RainExceedanceService(query, db, ContactID);
                        rainExceedanceLast = (from c in db.RainExceedances select c).FirstOrDefault();
                    }

                    // ok with RainExceedance info
                    IHttpActionResult jsonRet = rainExceedanceController.GetRainExceedanceWithID(rainExceedanceLast.RainExceedanceID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<RainExceedance> Ret = jsonRet as OkNegotiatedContentResult<RainExceedance>;
                    RainExceedance rainExceedanceRet = Ret.Content;
                    Assert.AreEqual(rainExceedanceLast.RainExceedanceID, rainExceedanceRet.RainExceedanceID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because RainExceedanceID exist
                    IHttpActionResult jsonRet2 = rainExceedanceController.Post(rainExceedanceRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<RainExceedance> rainExceedanceRet2 = jsonRet2 as OkNegotiatedContentResult<RainExceedance>;
                    Assert.IsNull(rainExceedanceRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest2);

                    // Post to return newly added RainExceedance
                    rainExceedanceRet.RainExceedanceID = 0;
                    rainExceedanceController.Request = new System.Net.Http.HttpRequestMessage();
                    rainExceedanceController.Request.RequestUri = new System.Uri("http://localhost:5000/api/rainExceedance");
                    IHttpActionResult jsonRet3 = rainExceedanceController.Post(rainExceedanceRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<RainExceedance> rainExceedanceRet3 = jsonRet3 as CreatedNegotiatedContentResult<RainExceedance>;
                    Assert.IsNotNull(rainExceedanceRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = rainExceedanceController.Delete(rainExceedanceRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<RainExceedance> rainExceedanceRet4 = jsonRet4 as OkNegotiatedContentResult<RainExceedance>;
                    Assert.IsNotNull(rainExceedanceRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [TestMethod]
        public void RainExceedance_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    RainExceedanceController rainExceedanceController = new RainExceedanceController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(rainExceedanceController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, rainExceedanceController.DatabaseType);

                    RainExceedance rainExceedanceLast = new RainExceedance();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        RainExceedanceService rainExceedanceService = new RainExceedanceService(query, db, ContactID);
                        rainExceedanceLast = (from c in db.RainExceedances select c).FirstOrDefault();
                    }

                    // ok with RainExceedance info
                    IHttpActionResult jsonRet = rainExceedanceController.GetRainExceedanceWithID(rainExceedanceLast.RainExceedanceID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<RainExceedance> Ret = jsonRet as OkNegotiatedContentResult<RainExceedance>;
                    RainExceedance rainExceedanceRet = Ret.Content;
                    Assert.AreEqual(rainExceedanceLast.RainExceedanceID, rainExceedanceRet.RainExceedanceID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = rainExceedanceController.Put(rainExceedanceRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<RainExceedance> rainExceedanceRet2 = jsonRet2 as OkNegotiatedContentResult<RainExceedance>;
                    Assert.IsNotNull(rainExceedanceRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because RainExceedanceID of 0 does not exist
                    rainExceedanceRet.RainExceedanceID = 0;
                    IHttpActionResult jsonRet3 = rainExceedanceController.Put(rainExceedanceRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    OkNegotiatedContentResult<RainExceedance> rainExceedanceRet3 = jsonRet3 as OkNegotiatedContentResult<RainExceedance>;
                    Assert.IsNull(rainExceedanceRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [TestMethod]
        public void RainExceedance_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    RainExceedanceController rainExceedanceController = new RainExceedanceController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(rainExceedanceController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, rainExceedanceController.DatabaseType);

                    RainExceedance rainExceedanceLast = new RainExceedance();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        RainExceedanceService rainExceedanceService = new RainExceedanceService(query, db, ContactID);
                        rainExceedanceLast = (from c in db.RainExceedances select c).FirstOrDefault();
                    }

                    // ok with RainExceedance info
                    IHttpActionResult jsonRet = rainExceedanceController.GetRainExceedanceWithID(rainExceedanceLast.RainExceedanceID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<RainExceedance> Ret = jsonRet as OkNegotiatedContentResult<RainExceedance>;
                    RainExceedance rainExceedanceRet = Ret.Content;
                    Assert.AreEqual(rainExceedanceLast.RainExceedanceID, rainExceedanceRet.RainExceedanceID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added RainExceedance
                    rainExceedanceRet.RainExceedanceID = 0;
                    rainExceedanceController.Request = new System.Net.Http.HttpRequestMessage();
                    rainExceedanceController.Request.RequestUri = new System.Uri("http://localhost:5000/api/rainExceedance");
                    IHttpActionResult jsonRet3 = rainExceedanceController.Post(rainExceedanceRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<RainExceedance> rainExceedanceRet3 = jsonRet3 as CreatedNegotiatedContentResult<RainExceedance>;
                    Assert.IsNotNull(rainExceedanceRet3);
                    RainExceedance rainExceedance = rainExceedanceRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = rainExceedanceController.Delete(rainExceedanceRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<RainExceedance> rainExceedanceRet2 = jsonRet2 as OkNegotiatedContentResult<RainExceedance>;
                    Assert.IsNotNull(rainExceedanceRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because RainExceedanceID of 0 does not exist
                    rainExceedanceRet.RainExceedanceID = 0;
                    IHttpActionResult jsonRet4 = rainExceedanceController.Delete(rainExceedanceRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<RainExceedance> rainExceedanceRet4 = jsonRet4 as OkNegotiatedContentResult<RainExceedance>;
                    Assert.IsNull(rainExceedanceRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
