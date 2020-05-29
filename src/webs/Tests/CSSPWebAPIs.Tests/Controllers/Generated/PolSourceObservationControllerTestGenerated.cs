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
    public partial class PolSourceObservationControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public PolSourceObservationControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [TestMethod]
        public void PolSourceObservation_Controller_GetPolSourceObservationList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    PolSourceObservationController polSourceObservationController = new PolSourceObservationController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(polSourceObservationController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, polSourceObservationController.DatabaseType);

                    PolSourceObservation polSourceObservationFirst = new PolSourceObservation();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        PolSourceObservationService polSourceObservationService = new PolSourceObservationService(query, db, ContactID);
                        polSourceObservationFirst = (from c in db.PolSourceObservations select c).FirstOrDefault();
                        count = (from c in db.PolSourceObservations select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with PolSourceObservation info
                    IHttpActionResult jsonRet = polSourceObservationController.GetPolSourceObservationList();
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<List<PolSourceObservation>> ret = jsonRet as OkNegotiatedContentResult<List<PolSourceObservation>>;
                    Assert.AreEqual(polSourceObservationFirst.PolSourceObservationID, ret.Content[0].PolSourceObservationID);
                    Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<PolSourceObservation> polSourceObservationList = new List<PolSourceObservation>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        PolSourceObservationService polSourceObservationService = new PolSourceObservationService(query, db, ContactID);
                        polSourceObservationList = (from c in db.PolSourceObservations select c).OrderBy(c => c.PolSourceObservationID).Skip(0).Take(2).ToList();
                        count = (from c in db.PolSourceObservations select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with PolSourceObservation info
                        jsonRet = polSourceObservationController.GetPolSourceObservationList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsNotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<PolSourceObservation>>;
                        Assert.AreEqual(polSourceObservationList[0].PolSourceObservationID, ret.Content[0].PolSourceObservationID);
                        Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with PolSourceObservation info
                           IHttpActionResult jsonRet2 = polSourceObservationController.GetPolSourceObservationList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.IsNotNull(jsonRet2);

                           OkNegotiatedContentResult<List<PolSourceObservation>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<PolSourceObservation>>;
                           Assert.AreEqual(polSourceObservationList[1].PolSourceObservationID, ret2.Content[0].PolSourceObservationID);
                           Assert.AreEqual((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [TestMethod]
        public void PolSourceObservation_Controller_GetPolSourceObservationWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    PolSourceObservationController polSourceObservationController = new PolSourceObservationController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(polSourceObservationController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, polSourceObservationController.DatabaseType);

                    PolSourceObservation polSourceObservationFirst = new PolSourceObservation();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        PolSourceObservationService polSourceObservationService = new PolSourceObservationService(new Query(), db, ContactID);
                        polSourceObservationFirst = (from c in db.PolSourceObservations select c).FirstOrDefault();
                    }

                    // ok with PolSourceObservation info
                    IHttpActionResult jsonRet = polSourceObservationController.GetPolSourceObservationWithID(polSourceObservationFirst.PolSourceObservationID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<PolSourceObservation> Ret = jsonRet as OkNegotiatedContentResult<PolSourceObservation>;
                    PolSourceObservation polSourceObservationRet = Ret.Content;
                    Assert.AreEqual(polSourceObservationFirst.PolSourceObservationID, polSourceObservationRet.PolSourceObservationID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = polSourceObservationController.GetPolSourceObservationWithID(0);
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<PolSourceObservation> polSourceObservationRet2 = jsonRet2 as OkNegotiatedContentResult<PolSourceObservation>;
                    Assert.IsNull(polSourceObservationRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.IsNotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [TestMethod]
        public void PolSourceObservation_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    PolSourceObservationController polSourceObservationController = new PolSourceObservationController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(polSourceObservationController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, polSourceObservationController.DatabaseType);

                    PolSourceObservation polSourceObservationLast = new PolSourceObservation();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        PolSourceObservationService polSourceObservationService = new PolSourceObservationService(query, db, ContactID);
                        polSourceObservationLast = (from c in db.PolSourceObservations select c).FirstOrDefault();
                    }

                    // ok with PolSourceObservation info
                    IHttpActionResult jsonRet = polSourceObservationController.GetPolSourceObservationWithID(polSourceObservationLast.PolSourceObservationID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<PolSourceObservation> Ret = jsonRet as OkNegotiatedContentResult<PolSourceObservation>;
                    PolSourceObservation polSourceObservationRet = Ret.Content;
                    Assert.AreEqual(polSourceObservationLast.PolSourceObservationID, polSourceObservationRet.PolSourceObservationID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because PolSourceObservationID exist
                    IHttpActionResult jsonRet2 = polSourceObservationController.Post(polSourceObservationRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<PolSourceObservation> polSourceObservationRet2 = jsonRet2 as OkNegotiatedContentResult<PolSourceObservation>;
                    Assert.IsNull(polSourceObservationRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest2);

                    // Post to return newly added PolSourceObservation
                    polSourceObservationRet.PolSourceObservationID = 0;
                    polSourceObservationController.Request = new System.Net.Http.HttpRequestMessage();
                    polSourceObservationController.Request.RequestUri = new System.Uri("http://localhost:5000/api/polSourceObservation");
                    IHttpActionResult jsonRet3 = polSourceObservationController.Post(polSourceObservationRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<PolSourceObservation> polSourceObservationRet3 = jsonRet3 as CreatedNegotiatedContentResult<PolSourceObservation>;
                    Assert.IsNotNull(polSourceObservationRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = polSourceObservationController.Delete(polSourceObservationRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<PolSourceObservation> polSourceObservationRet4 = jsonRet4 as OkNegotiatedContentResult<PolSourceObservation>;
                    Assert.IsNotNull(polSourceObservationRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [TestMethod]
        public void PolSourceObservation_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    PolSourceObservationController polSourceObservationController = new PolSourceObservationController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(polSourceObservationController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, polSourceObservationController.DatabaseType);

                    PolSourceObservation polSourceObservationLast = new PolSourceObservation();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        PolSourceObservationService polSourceObservationService = new PolSourceObservationService(query, db, ContactID);
                        polSourceObservationLast = (from c in db.PolSourceObservations select c).FirstOrDefault();
                    }

                    // ok with PolSourceObservation info
                    IHttpActionResult jsonRet = polSourceObservationController.GetPolSourceObservationWithID(polSourceObservationLast.PolSourceObservationID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<PolSourceObservation> Ret = jsonRet as OkNegotiatedContentResult<PolSourceObservation>;
                    PolSourceObservation polSourceObservationRet = Ret.Content;
                    Assert.AreEqual(polSourceObservationLast.PolSourceObservationID, polSourceObservationRet.PolSourceObservationID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = polSourceObservationController.Put(polSourceObservationRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<PolSourceObservation> polSourceObservationRet2 = jsonRet2 as OkNegotiatedContentResult<PolSourceObservation>;
                    Assert.IsNotNull(polSourceObservationRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because PolSourceObservationID of 0 does not exist
                    polSourceObservationRet.PolSourceObservationID = 0;
                    IHttpActionResult jsonRet3 = polSourceObservationController.Put(polSourceObservationRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    OkNegotiatedContentResult<PolSourceObservation> polSourceObservationRet3 = jsonRet3 as OkNegotiatedContentResult<PolSourceObservation>;
                    Assert.IsNull(polSourceObservationRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [TestMethod]
        public void PolSourceObservation_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    PolSourceObservationController polSourceObservationController = new PolSourceObservationController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(polSourceObservationController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, polSourceObservationController.DatabaseType);

                    PolSourceObservation polSourceObservationLast = new PolSourceObservation();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        PolSourceObservationService polSourceObservationService = new PolSourceObservationService(query, db, ContactID);
                        polSourceObservationLast = (from c in db.PolSourceObservations select c).FirstOrDefault();
                    }

                    // ok with PolSourceObservation info
                    IHttpActionResult jsonRet = polSourceObservationController.GetPolSourceObservationWithID(polSourceObservationLast.PolSourceObservationID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<PolSourceObservation> Ret = jsonRet as OkNegotiatedContentResult<PolSourceObservation>;
                    PolSourceObservation polSourceObservationRet = Ret.Content;
                    Assert.AreEqual(polSourceObservationLast.PolSourceObservationID, polSourceObservationRet.PolSourceObservationID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added PolSourceObservation
                    polSourceObservationRet.PolSourceObservationID = 0;
                    polSourceObservationController.Request = new System.Net.Http.HttpRequestMessage();
                    polSourceObservationController.Request.RequestUri = new System.Uri("http://localhost:5000/api/polSourceObservation");
                    IHttpActionResult jsonRet3 = polSourceObservationController.Post(polSourceObservationRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<PolSourceObservation> polSourceObservationRet3 = jsonRet3 as CreatedNegotiatedContentResult<PolSourceObservation>;
                    Assert.IsNotNull(polSourceObservationRet3);
                    PolSourceObservation polSourceObservation = polSourceObservationRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = polSourceObservationController.Delete(polSourceObservationRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<PolSourceObservation> polSourceObservationRet2 = jsonRet2 as OkNegotiatedContentResult<PolSourceObservation>;
                    Assert.IsNotNull(polSourceObservationRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because PolSourceObservationID of 0 does not exist
                    polSourceObservationRet.PolSourceObservationID = 0;
                    IHttpActionResult jsonRet4 = polSourceObservationController.Delete(polSourceObservationRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<PolSourceObservation> polSourceObservationRet4 = jsonRet4 as OkNegotiatedContentResult<PolSourceObservation>;
                    Assert.IsNull(polSourceObservationRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
