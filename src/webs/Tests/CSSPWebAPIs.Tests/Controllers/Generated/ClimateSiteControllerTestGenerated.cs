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
    public partial class ClimateSiteControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ClimateSiteControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [TestMethod]
        public void ClimateSite_Controller_GetClimateSiteList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ClimateSiteController climateSiteController = new ClimateSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(climateSiteController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, climateSiteController.DatabaseType);

                    ClimateSite climateSiteFirst = new ClimateSite();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        ClimateSiteService climateSiteService = new ClimateSiteService(query, db, ContactID);
                        climateSiteFirst = (from c in db.ClimateSites select c).FirstOrDefault();
                        count = (from c in db.ClimateSites select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with ClimateSite info
                    IHttpActionResult jsonRet = climateSiteController.GetClimateSiteList();
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<List<ClimateSite>> ret = jsonRet as OkNegotiatedContentResult<List<ClimateSite>>;
                    Assert.AreEqual(climateSiteFirst.ClimateSiteID, ret.Content[0].ClimateSiteID);
                    Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<ClimateSite> climateSiteList = new List<ClimateSite>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        ClimateSiteService climateSiteService = new ClimateSiteService(query, db, ContactID);
                        climateSiteList = (from c in db.ClimateSites select c).OrderBy(c => c.ClimateSiteID).Skip(0).Take(2).ToList();
                        count = (from c in db.ClimateSites select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with ClimateSite info
                        jsonRet = climateSiteController.GetClimateSiteList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsNotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<ClimateSite>>;
                        Assert.AreEqual(climateSiteList[0].ClimateSiteID, ret.Content[0].ClimateSiteID);
                        Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with ClimateSite info
                           IHttpActionResult jsonRet2 = climateSiteController.GetClimateSiteList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.IsNotNull(jsonRet2);

                           OkNegotiatedContentResult<List<ClimateSite>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<ClimateSite>>;
                           Assert.AreEqual(climateSiteList[1].ClimateSiteID, ret2.Content[0].ClimateSiteID);
                           Assert.AreEqual((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [TestMethod]
        public void ClimateSite_Controller_GetClimateSiteWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ClimateSiteController climateSiteController = new ClimateSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(climateSiteController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, climateSiteController.DatabaseType);

                    ClimateSite climateSiteFirst = new ClimateSite();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        ClimateSiteService climateSiteService = new ClimateSiteService(new Query(), db, ContactID);
                        climateSiteFirst = (from c in db.ClimateSites select c).FirstOrDefault();
                    }

                    // ok with ClimateSite info
                    IHttpActionResult jsonRet = climateSiteController.GetClimateSiteWithID(climateSiteFirst.ClimateSiteID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<ClimateSite> Ret = jsonRet as OkNegotiatedContentResult<ClimateSite>;
                    ClimateSite climateSiteRet = Ret.Content;
                    Assert.AreEqual(climateSiteFirst.ClimateSiteID, climateSiteRet.ClimateSiteID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = climateSiteController.GetClimateSiteWithID(0);
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<ClimateSite> climateSiteRet2 = jsonRet2 as OkNegotiatedContentResult<ClimateSite>;
                    Assert.IsNull(climateSiteRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.IsNotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [TestMethod]
        public void ClimateSite_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ClimateSiteController climateSiteController = new ClimateSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(climateSiteController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, climateSiteController.DatabaseType);

                    ClimateSite climateSiteLast = new ClimateSite();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        ClimateSiteService climateSiteService = new ClimateSiteService(query, db, ContactID);
                        climateSiteLast = (from c in db.ClimateSites select c).FirstOrDefault();
                    }

                    // ok with ClimateSite info
                    IHttpActionResult jsonRet = climateSiteController.GetClimateSiteWithID(climateSiteLast.ClimateSiteID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<ClimateSite> Ret = jsonRet as OkNegotiatedContentResult<ClimateSite>;
                    ClimateSite climateSiteRet = Ret.Content;
                    Assert.AreEqual(climateSiteLast.ClimateSiteID, climateSiteRet.ClimateSiteID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because ClimateSiteID exist
                    IHttpActionResult jsonRet2 = climateSiteController.Post(climateSiteRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<ClimateSite> climateSiteRet2 = jsonRet2 as OkNegotiatedContentResult<ClimateSite>;
                    Assert.IsNull(climateSiteRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest2);

                    // Post to return newly added ClimateSite
                    climateSiteRet.ClimateSiteID = 0;
                    climateSiteController.Request = new System.Net.Http.HttpRequestMessage();
                    climateSiteController.Request.RequestUri = new System.Uri("http://localhost:5000/api/climateSite");
                    IHttpActionResult jsonRet3 = climateSiteController.Post(climateSiteRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<ClimateSite> climateSiteRet3 = jsonRet3 as CreatedNegotiatedContentResult<ClimateSite>;
                    Assert.IsNotNull(climateSiteRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = climateSiteController.Delete(climateSiteRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<ClimateSite> climateSiteRet4 = jsonRet4 as OkNegotiatedContentResult<ClimateSite>;
                    Assert.IsNotNull(climateSiteRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [TestMethod]
        public void ClimateSite_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ClimateSiteController climateSiteController = new ClimateSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(climateSiteController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, climateSiteController.DatabaseType);

                    ClimateSite climateSiteLast = new ClimateSite();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        ClimateSiteService climateSiteService = new ClimateSiteService(query, db, ContactID);
                        climateSiteLast = (from c in db.ClimateSites select c).FirstOrDefault();
                    }

                    // ok with ClimateSite info
                    IHttpActionResult jsonRet = climateSiteController.GetClimateSiteWithID(climateSiteLast.ClimateSiteID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<ClimateSite> Ret = jsonRet as OkNegotiatedContentResult<ClimateSite>;
                    ClimateSite climateSiteRet = Ret.Content;
                    Assert.AreEqual(climateSiteLast.ClimateSiteID, climateSiteRet.ClimateSiteID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = climateSiteController.Put(climateSiteRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<ClimateSite> climateSiteRet2 = jsonRet2 as OkNegotiatedContentResult<ClimateSite>;
                    Assert.IsNotNull(climateSiteRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because ClimateSiteID of 0 does not exist
                    climateSiteRet.ClimateSiteID = 0;
                    IHttpActionResult jsonRet3 = climateSiteController.Put(climateSiteRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    OkNegotiatedContentResult<ClimateSite> climateSiteRet3 = jsonRet3 as OkNegotiatedContentResult<ClimateSite>;
                    Assert.IsNull(climateSiteRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [TestMethod]
        public void ClimateSite_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ClimateSiteController climateSiteController = new ClimateSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(climateSiteController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, climateSiteController.DatabaseType);

                    ClimateSite climateSiteLast = new ClimateSite();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        ClimateSiteService climateSiteService = new ClimateSiteService(query, db, ContactID);
                        climateSiteLast = (from c in db.ClimateSites select c).FirstOrDefault();
                    }

                    // ok with ClimateSite info
                    IHttpActionResult jsonRet = climateSiteController.GetClimateSiteWithID(climateSiteLast.ClimateSiteID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<ClimateSite> Ret = jsonRet as OkNegotiatedContentResult<ClimateSite>;
                    ClimateSite climateSiteRet = Ret.Content;
                    Assert.AreEqual(climateSiteLast.ClimateSiteID, climateSiteRet.ClimateSiteID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added ClimateSite
                    climateSiteRet.ClimateSiteID = 0;
                    climateSiteController.Request = new System.Net.Http.HttpRequestMessage();
                    climateSiteController.Request.RequestUri = new System.Uri("http://localhost:5000/api/climateSite");
                    IHttpActionResult jsonRet3 = climateSiteController.Post(climateSiteRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<ClimateSite> climateSiteRet3 = jsonRet3 as CreatedNegotiatedContentResult<ClimateSite>;
                    Assert.IsNotNull(climateSiteRet3);
                    ClimateSite climateSite = climateSiteRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = climateSiteController.Delete(climateSiteRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<ClimateSite> climateSiteRet2 = jsonRet2 as OkNegotiatedContentResult<ClimateSite>;
                    Assert.IsNotNull(climateSiteRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because ClimateSiteID of 0 does not exist
                    climateSiteRet.ClimateSiteID = 0;
                    IHttpActionResult jsonRet4 = climateSiteController.Delete(climateSiteRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<ClimateSite> climateSiteRet4 = jsonRet4 as OkNegotiatedContentResult<ClimateSite>;
                    Assert.IsNull(climateSiteRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
