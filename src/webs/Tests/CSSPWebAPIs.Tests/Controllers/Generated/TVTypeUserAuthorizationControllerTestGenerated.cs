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
    public partial class TVTypeUserAuthorizationControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TVTypeUserAuthorizationControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [TestMethod]
        public void TVTypeUserAuthorization_Controller_GetTVTypeUserAuthorizationList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVTypeUserAuthorizationController tvTypeUserAuthorizationController = new TVTypeUserAuthorizationController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(tvTypeUserAuthorizationController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, tvTypeUserAuthorizationController.DatabaseType);

                    TVTypeUserAuthorization tvTypeUserAuthorizationFirst = new TVTypeUserAuthorization();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        TVTypeUserAuthorizationService tvTypeUserAuthorizationService = new TVTypeUserAuthorizationService(query, db, ContactID);
                        tvTypeUserAuthorizationFirst = (from c in db.TVTypeUserAuthorizations select c).FirstOrDefault();
                        count = (from c in db.TVTypeUserAuthorizations select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with TVTypeUserAuthorization info
                    IHttpActionResult jsonRet = tvTypeUserAuthorizationController.GetTVTypeUserAuthorizationList();
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<List<TVTypeUserAuthorization>> ret = jsonRet as OkNegotiatedContentResult<List<TVTypeUserAuthorization>>;
                    Assert.AreEqual(tvTypeUserAuthorizationFirst.TVTypeUserAuthorizationID, ret.Content[0].TVTypeUserAuthorizationID);
                    Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<TVTypeUserAuthorization> tvTypeUserAuthorizationList = new List<TVTypeUserAuthorization>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        TVTypeUserAuthorizationService tvTypeUserAuthorizationService = new TVTypeUserAuthorizationService(query, db, ContactID);
                        tvTypeUserAuthorizationList = (from c in db.TVTypeUserAuthorizations select c).OrderBy(c => c.TVTypeUserAuthorizationID).Skip(0).Take(2).ToList();
                        count = (from c in db.TVTypeUserAuthorizations select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with TVTypeUserAuthorization info
                        jsonRet = tvTypeUserAuthorizationController.GetTVTypeUserAuthorizationList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsNotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<TVTypeUserAuthorization>>;
                        Assert.AreEqual(tvTypeUserAuthorizationList[0].TVTypeUserAuthorizationID, ret.Content[0].TVTypeUserAuthorizationID);
                        Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with TVTypeUserAuthorization info
                           IHttpActionResult jsonRet2 = tvTypeUserAuthorizationController.GetTVTypeUserAuthorizationList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.IsNotNull(jsonRet2);

                           OkNegotiatedContentResult<List<TVTypeUserAuthorization>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<TVTypeUserAuthorization>>;
                           Assert.AreEqual(tvTypeUserAuthorizationList[1].TVTypeUserAuthorizationID, ret2.Content[0].TVTypeUserAuthorizationID);
                           Assert.AreEqual((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [TestMethod]
        public void TVTypeUserAuthorization_Controller_GetTVTypeUserAuthorizationWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVTypeUserAuthorizationController tvTypeUserAuthorizationController = new TVTypeUserAuthorizationController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(tvTypeUserAuthorizationController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, tvTypeUserAuthorizationController.DatabaseType);

                    TVTypeUserAuthorization tvTypeUserAuthorizationFirst = new TVTypeUserAuthorization();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        TVTypeUserAuthorizationService tvTypeUserAuthorizationService = new TVTypeUserAuthorizationService(new Query(), db, ContactID);
                        tvTypeUserAuthorizationFirst = (from c in db.TVTypeUserAuthorizations select c).FirstOrDefault();
                    }

                    // ok with TVTypeUserAuthorization info
                    IHttpActionResult jsonRet = tvTypeUserAuthorizationController.GetTVTypeUserAuthorizationWithID(tvTypeUserAuthorizationFirst.TVTypeUserAuthorizationID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<TVTypeUserAuthorization> Ret = jsonRet as OkNegotiatedContentResult<TVTypeUserAuthorization>;
                    TVTypeUserAuthorization tvTypeUserAuthorizationRet = Ret.Content;
                    Assert.AreEqual(tvTypeUserAuthorizationFirst.TVTypeUserAuthorizationID, tvTypeUserAuthorizationRet.TVTypeUserAuthorizationID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = tvTypeUserAuthorizationController.GetTVTypeUserAuthorizationWithID(0);
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<TVTypeUserAuthorization> tvTypeUserAuthorizationRet2 = jsonRet2 as OkNegotiatedContentResult<TVTypeUserAuthorization>;
                    Assert.IsNull(tvTypeUserAuthorizationRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.IsNotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [TestMethod]
        public void TVTypeUserAuthorization_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVTypeUserAuthorizationController tvTypeUserAuthorizationController = new TVTypeUserAuthorizationController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(tvTypeUserAuthorizationController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, tvTypeUserAuthorizationController.DatabaseType);

                    TVTypeUserAuthorization tvTypeUserAuthorizationLast = new TVTypeUserAuthorization();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        TVTypeUserAuthorizationService tvTypeUserAuthorizationService = new TVTypeUserAuthorizationService(query, db, ContactID);
                        tvTypeUserAuthorizationLast = (from c in db.TVTypeUserAuthorizations select c).FirstOrDefault();
                    }

                    // ok with TVTypeUserAuthorization info
                    IHttpActionResult jsonRet = tvTypeUserAuthorizationController.GetTVTypeUserAuthorizationWithID(tvTypeUserAuthorizationLast.TVTypeUserAuthorizationID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<TVTypeUserAuthorization> Ret = jsonRet as OkNegotiatedContentResult<TVTypeUserAuthorization>;
                    TVTypeUserAuthorization tvTypeUserAuthorizationRet = Ret.Content;
                    Assert.AreEqual(tvTypeUserAuthorizationLast.TVTypeUserAuthorizationID, tvTypeUserAuthorizationRet.TVTypeUserAuthorizationID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because TVTypeUserAuthorizationID exist
                    IHttpActionResult jsonRet2 = tvTypeUserAuthorizationController.Post(tvTypeUserAuthorizationRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<TVTypeUserAuthorization> tvTypeUserAuthorizationRet2 = jsonRet2 as OkNegotiatedContentResult<TVTypeUserAuthorization>;
                    Assert.IsNull(tvTypeUserAuthorizationRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest2);

                    // Post to return newly added TVTypeUserAuthorization
                    tvTypeUserAuthorizationRet.TVTypeUserAuthorizationID = 0;
                    tvTypeUserAuthorizationController.Request = new System.Net.Http.HttpRequestMessage();
                    tvTypeUserAuthorizationController.Request.RequestUri = new System.Uri("http://localhost:5000/api/tvTypeUserAuthorization");
                    IHttpActionResult jsonRet3 = tvTypeUserAuthorizationController.Post(tvTypeUserAuthorizationRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<TVTypeUserAuthorization> tvTypeUserAuthorizationRet3 = jsonRet3 as CreatedNegotiatedContentResult<TVTypeUserAuthorization>;
                    Assert.IsNotNull(tvTypeUserAuthorizationRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = tvTypeUserAuthorizationController.Delete(tvTypeUserAuthorizationRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<TVTypeUserAuthorization> tvTypeUserAuthorizationRet4 = jsonRet4 as OkNegotiatedContentResult<TVTypeUserAuthorization>;
                    Assert.IsNotNull(tvTypeUserAuthorizationRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [TestMethod]
        public void TVTypeUserAuthorization_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVTypeUserAuthorizationController tvTypeUserAuthorizationController = new TVTypeUserAuthorizationController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(tvTypeUserAuthorizationController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, tvTypeUserAuthorizationController.DatabaseType);

                    TVTypeUserAuthorization tvTypeUserAuthorizationLast = new TVTypeUserAuthorization();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        TVTypeUserAuthorizationService tvTypeUserAuthorizationService = new TVTypeUserAuthorizationService(query, db, ContactID);
                        tvTypeUserAuthorizationLast = (from c in db.TVTypeUserAuthorizations select c).FirstOrDefault();
                    }

                    // ok with TVTypeUserAuthorization info
                    IHttpActionResult jsonRet = tvTypeUserAuthorizationController.GetTVTypeUserAuthorizationWithID(tvTypeUserAuthorizationLast.TVTypeUserAuthorizationID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<TVTypeUserAuthorization> Ret = jsonRet as OkNegotiatedContentResult<TVTypeUserAuthorization>;
                    TVTypeUserAuthorization tvTypeUserAuthorizationRet = Ret.Content;
                    Assert.AreEqual(tvTypeUserAuthorizationLast.TVTypeUserAuthorizationID, tvTypeUserAuthorizationRet.TVTypeUserAuthorizationID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = tvTypeUserAuthorizationController.Put(tvTypeUserAuthorizationRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<TVTypeUserAuthorization> tvTypeUserAuthorizationRet2 = jsonRet2 as OkNegotiatedContentResult<TVTypeUserAuthorization>;
                    Assert.IsNotNull(tvTypeUserAuthorizationRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because TVTypeUserAuthorizationID of 0 does not exist
                    tvTypeUserAuthorizationRet.TVTypeUserAuthorizationID = 0;
                    IHttpActionResult jsonRet3 = tvTypeUserAuthorizationController.Put(tvTypeUserAuthorizationRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    OkNegotiatedContentResult<TVTypeUserAuthorization> tvTypeUserAuthorizationRet3 = jsonRet3 as OkNegotiatedContentResult<TVTypeUserAuthorization>;
                    Assert.IsNull(tvTypeUserAuthorizationRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [TestMethod]
        public void TVTypeUserAuthorization_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVTypeUserAuthorizationController tvTypeUserAuthorizationController = new TVTypeUserAuthorizationController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(tvTypeUserAuthorizationController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, tvTypeUserAuthorizationController.DatabaseType);

                    TVTypeUserAuthorization tvTypeUserAuthorizationLast = new TVTypeUserAuthorization();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        TVTypeUserAuthorizationService tvTypeUserAuthorizationService = new TVTypeUserAuthorizationService(query, db, ContactID);
                        tvTypeUserAuthorizationLast = (from c in db.TVTypeUserAuthorizations select c).FirstOrDefault();
                    }

                    // ok with TVTypeUserAuthorization info
                    IHttpActionResult jsonRet = tvTypeUserAuthorizationController.GetTVTypeUserAuthorizationWithID(tvTypeUserAuthorizationLast.TVTypeUserAuthorizationID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<TVTypeUserAuthorization> Ret = jsonRet as OkNegotiatedContentResult<TVTypeUserAuthorization>;
                    TVTypeUserAuthorization tvTypeUserAuthorizationRet = Ret.Content;
                    Assert.AreEqual(tvTypeUserAuthorizationLast.TVTypeUserAuthorizationID, tvTypeUserAuthorizationRet.TVTypeUserAuthorizationID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added TVTypeUserAuthorization
                    tvTypeUserAuthorizationRet.TVTypeUserAuthorizationID = 0;
                    tvTypeUserAuthorizationController.Request = new System.Net.Http.HttpRequestMessage();
                    tvTypeUserAuthorizationController.Request.RequestUri = new System.Uri("http://localhost:5000/api/tvTypeUserAuthorization");
                    IHttpActionResult jsonRet3 = tvTypeUserAuthorizationController.Post(tvTypeUserAuthorizationRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<TVTypeUserAuthorization> tvTypeUserAuthorizationRet3 = jsonRet3 as CreatedNegotiatedContentResult<TVTypeUserAuthorization>;
                    Assert.IsNotNull(tvTypeUserAuthorizationRet3);
                    TVTypeUserAuthorization tvTypeUserAuthorization = tvTypeUserAuthorizationRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = tvTypeUserAuthorizationController.Delete(tvTypeUserAuthorizationRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<TVTypeUserAuthorization> tvTypeUserAuthorizationRet2 = jsonRet2 as OkNegotiatedContentResult<TVTypeUserAuthorization>;
                    Assert.IsNotNull(tvTypeUserAuthorizationRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because TVTypeUserAuthorizationID of 0 does not exist
                    tvTypeUserAuthorizationRet.TVTypeUserAuthorizationID = 0;
                    IHttpActionResult jsonRet4 = tvTypeUserAuthorizationController.Delete(tvTypeUserAuthorizationRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<TVTypeUserAuthorization> tvTypeUserAuthorizationRet4 = jsonRet4 as OkNegotiatedContentResult<TVTypeUserAuthorization>;
                    Assert.IsNull(tvTypeUserAuthorizationRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
