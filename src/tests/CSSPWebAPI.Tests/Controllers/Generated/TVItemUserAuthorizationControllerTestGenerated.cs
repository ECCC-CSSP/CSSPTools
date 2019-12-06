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
    public partial class TVItemUserAuthorizationControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TVItemUserAuthorizationControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [TestMethod]
        public void TVItemUserAuthorization_Controller_GetTVItemUserAuthorizationList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVItemUserAuthorizationController tvItemUserAuthorizationController = new TVItemUserAuthorizationController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(tvItemUserAuthorizationController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, tvItemUserAuthorizationController.DatabaseType);

                    TVItemUserAuthorization tvItemUserAuthorizationFirst = new TVItemUserAuthorization();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        TVItemUserAuthorizationService tvItemUserAuthorizationService = new TVItemUserAuthorizationService(query, db, ContactID);
                        tvItemUserAuthorizationFirst = (from c in db.TVItemUserAuthorizations select c).FirstOrDefault();
                        count = (from c in db.TVItemUserAuthorizations select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with TVItemUserAuthorization info
                    IHttpActionResult jsonRet = tvItemUserAuthorizationController.GetTVItemUserAuthorizationList();
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<List<TVItemUserAuthorization>> ret = jsonRet as OkNegotiatedContentResult<List<TVItemUserAuthorization>>;
                    Assert.AreEqual(tvItemUserAuthorizationFirst.TVItemUserAuthorizationID, ret.Content[0].TVItemUserAuthorizationID);
                    Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<TVItemUserAuthorization> tvItemUserAuthorizationList = new List<TVItemUserAuthorization>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        TVItemUserAuthorizationService tvItemUserAuthorizationService = new TVItemUserAuthorizationService(query, db, ContactID);
                        tvItemUserAuthorizationList = (from c in db.TVItemUserAuthorizations select c).OrderBy(c => c.TVItemUserAuthorizationID).Skip(0).Take(2).ToList();
                        count = (from c in db.TVItemUserAuthorizations select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with TVItemUserAuthorization info
                        jsonRet = tvItemUserAuthorizationController.GetTVItemUserAuthorizationList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsNotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<TVItemUserAuthorization>>;
                        Assert.AreEqual(tvItemUserAuthorizationList[0].TVItemUserAuthorizationID, ret.Content[0].TVItemUserAuthorizationID);
                        Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with TVItemUserAuthorization info
                           IHttpActionResult jsonRet2 = tvItemUserAuthorizationController.GetTVItemUserAuthorizationList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.IsNotNull(jsonRet2);

                           OkNegotiatedContentResult<List<TVItemUserAuthorization>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<TVItemUserAuthorization>>;
                           Assert.AreEqual(tvItemUserAuthorizationList[1].TVItemUserAuthorizationID, ret2.Content[0].TVItemUserAuthorizationID);
                           Assert.AreEqual((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [TestMethod]
        public void TVItemUserAuthorization_Controller_GetTVItemUserAuthorizationWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVItemUserAuthorizationController tvItemUserAuthorizationController = new TVItemUserAuthorizationController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(tvItemUserAuthorizationController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, tvItemUserAuthorizationController.DatabaseType);

                    TVItemUserAuthorization tvItemUserAuthorizationFirst = new TVItemUserAuthorization();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        TVItemUserAuthorizationService tvItemUserAuthorizationService = new TVItemUserAuthorizationService(new Query(), db, ContactID);
                        tvItemUserAuthorizationFirst = (from c in db.TVItemUserAuthorizations select c).FirstOrDefault();
                    }

                    // ok with TVItemUserAuthorization info
                    IHttpActionResult jsonRet = tvItemUserAuthorizationController.GetTVItemUserAuthorizationWithID(tvItemUserAuthorizationFirst.TVItemUserAuthorizationID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<TVItemUserAuthorization> Ret = jsonRet as OkNegotiatedContentResult<TVItemUserAuthorization>;
                    TVItemUserAuthorization tvItemUserAuthorizationRet = Ret.Content;
                    Assert.AreEqual(tvItemUserAuthorizationFirst.TVItemUserAuthorizationID, tvItemUserAuthorizationRet.TVItemUserAuthorizationID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = tvItemUserAuthorizationController.GetTVItemUserAuthorizationWithID(0);
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<TVItemUserAuthorization> tvItemUserAuthorizationRet2 = jsonRet2 as OkNegotiatedContentResult<TVItemUserAuthorization>;
                    Assert.IsNull(tvItemUserAuthorizationRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.IsNotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [TestMethod]
        public void TVItemUserAuthorization_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVItemUserAuthorizationController tvItemUserAuthorizationController = new TVItemUserAuthorizationController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(tvItemUserAuthorizationController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, tvItemUserAuthorizationController.DatabaseType);

                    TVItemUserAuthorization tvItemUserAuthorizationLast = new TVItemUserAuthorization();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        TVItemUserAuthorizationService tvItemUserAuthorizationService = new TVItemUserAuthorizationService(query, db, ContactID);
                        tvItemUserAuthorizationLast = (from c in db.TVItemUserAuthorizations select c).FirstOrDefault();
                    }

                    // ok with TVItemUserAuthorization info
                    IHttpActionResult jsonRet = tvItemUserAuthorizationController.GetTVItemUserAuthorizationWithID(tvItemUserAuthorizationLast.TVItemUserAuthorizationID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<TVItemUserAuthorization> Ret = jsonRet as OkNegotiatedContentResult<TVItemUserAuthorization>;
                    TVItemUserAuthorization tvItemUserAuthorizationRet = Ret.Content;
                    Assert.AreEqual(tvItemUserAuthorizationLast.TVItemUserAuthorizationID, tvItemUserAuthorizationRet.TVItemUserAuthorizationID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because TVItemUserAuthorizationID exist
                    IHttpActionResult jsonRet2 = tvItemUserAuthorizationController.Post(tvItemUserAuthorizationRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<TVItemUserAuthorization> tvItemUserAuthorizationRet2 = jsonRet2 as OkNegotiatedContentResult<TVItemUserAuthorization>;
                    Assert.IsNull(tvItemUserAuthorizationRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest2);

                    // Post to return newly added TVItemUserAuthorization
                    tvItemUserAuthorizationRet.TVItemUserAuthorizationID = 0;
                    tvItemUserAuthorizationController.Request = new System.Net.Http.HttpRequestMessage();
                    tvItemUserAuthorizationController.Request.RequestUri = new System.Uri("http://localhost:5000/api/tvItemUserAuthorization");
                    IHttpActionResult jsonRet3 = tvItemUserAuthorizationController.Post(tvItemUserAuthorizationRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<TVItemUserAuthorization> tvItemUserAuthorizationRet3 = jsonRet3 as CreatedNegotiatedContentResult<TVItemUserAuthorization>;
                    Assert.IsNotNull(tvItemUserAuthorizationRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = tvItemUserAuthorizationController.Delete(tvItemUserAuthorizationRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<TVItemUserAuthorization> tvItemUserAuthorizationRet4 = jsonRet4 as OkNegotiatedContentResult<TVItemUserAuthorization>;
                    Assert.IsNotNull(tvItemUserAuthorizationRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [TestMethod]
        public void TVItemUserAuthorization_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVItemUserAuthorizationController tvItemUserAuthorizationController = new TVItemUserAuthorizationController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(tvItemUserAuthorizationController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, tvItemUserAuthorizationController.DatabaseType);

                    TVItemUserAuthorization tvItemUserAuthorizationLast = new TVItemUserAuthorization();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        TVItemUserAuthorizationService tvItemUserAuthorizationService = new TVItemUserAuthorizationService(query, db, ContactID);
                        tvItemUserAuthorizationLast = (from c in db.TVItemUserAuthorizations select c).FirstOrDefault();
                    }

                    // ok with TVItemUserAuthorization info
                    IHttpActionResult jsonRet = tvItemUserAuthorizationController.GetTVItemUserAuthorizationWithID(tvItemUserAuthorizationLast.TVItemUserAuthorizationID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<TVItemUserAuthorization> Ret = jsonRet as OkNegotiatedContentResult<TVItemUserAuthorization>;
                    TVItemUserAuthorization tvItemUserAuthorizationRet = Ret.Content;
                    Assert.AreEqual(tvItemUserAuthorizationLast.TVItemUserAuthorizationID, tvItemUserAuthorizationRet.TVItemUserAuthorizationID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = tvItemUserAuthorizationController.Put(tvItemUserAuthorizationRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<TVItemUserAuthorization> tvItemUserAuthorizationRet2 = jsonRet2 as OkNegotiatedContentResult<TVItemUserAuthorization>;
                    Assert.IsNotNull(tvItemUserAuthorizationRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because TVItemUserAuthorizationID of 0 does not exist
                    tvItemUserAuthorizationRet.TVItemUserAuthorizationID = 0;
                    IHttpActionResult jsonRet3 = tvItemUserAuthorizationController.Put(tvItemUserAuthorizationRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    OkNegotiatedContentResult<TVItemUserAuthorization> tvItemUserAuthorizationRet3 = jsonRet3 as OkNegotiatedContentResult<TVItemUserAuthorization>;
                    Assert.IsNull(tvItemUserAuthorizationRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [TestMethod]
        public void TVItemUserAuthorization_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVItemUserAuthorizationController tvItemUserAuthorizationController = new TVItemUserAuthorizationController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(tvItemUserAuthorizationController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, tvItemUserAuthorizationController.DatabaseType);

                    TVItemUserAuthorization tvItemUserAuthorizationLast = new TVItemUserAuthorization();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        TVItemUserAuthorizationService tvItemUserAuthorizationService = new TVItemUserAuthorizationService(query, db, ContactID);
                        tvItemUserAuthorizationLast = (from c in db.TVItemUserAuthorizations select c).FirstOrDefault();
                    }

                    // ok with TVItemUserAuthorization info
                    IHttpActionResult jsonRet = tvItemUserAuthorizationController.GetTVItemUserAuthorizationWithID(tvItemUserAuthorizationLast.TVItemUserAuthorizationID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<TVItemUserAuthorization> Ret = jsonRet as OkNegotiatedContentResult<TVItemUserAuthorization>;
                    TVItemUserAuthorization tvItemUserAuthorizationRet = Ret.Content;
                    Assert.AreEqual(tvItemUserAuthorizationLast.TVItemUserAuthorizationID, tvItemUserAuthorizationRet.TVItemUserAuthorizationID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added TVItemUserAuthorization
                    tvItemUserAuthorizationRet.TVItemUserAuthorizationID = 0;
                    tvItemUserAuthorizationController.Request = new System.Net.Http.HttpRequestMessage();
                    tvItemUserAuthorizationController.Request.RequestUri = new System.Uri("http://localhost:5000/api/tvItemUserAuthorization");
                    IHttpActionResult jsonRet3 = tvItemUserAuthorizationController.Post(tvItemUserAuthorizationRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<TVItemUserAuthorization> tvItemUserAuthorizationRet3 = jsonRet3 as CreatedNegotiatedContentResult<TVItemUserAuthorization>;
                    Assert.IsNotNull(tvItemUserAuthorizationRet3);
                    TVItemUserAuthorization tvItemUserAuthorization = tvItemUserAuthorizationRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = tvItemUserAuthorizationController.Delete(tvItemUserAuthorizationRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<TVItemUserAuthorization> tvItemUserAuthorizationRet2 = jsonRet2 as OkNegotiatedContentResult<TVItemUserAuthorization>;
                    Assert.IsNotNull(tvItemUserAuthorizationRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because TVItemUserAuthorizationID of 0 does not exist
                    tvItemUserAuthorizationRet.TVItemUserAuthorizationID = 0;
                    IHttpActionResult jsonRet4 = tvItemUserAuthorizationController.Delete(tvItemUserAuthorizationRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<TVItemUserAuthorization> tvItemUserAuthorizationRet4 = jsonRet4 as OkNegotiatedContentResult<TVItemUserAuthorization>;
                    Assert.IsNull(tvItemUserAuthorizationRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
