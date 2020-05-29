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
    public partial class HelpDocControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public HelpDocControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [TestMethod]
        public void HelpDoc_Controller_GetHelpDocList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    HelpDocController helpDocController = new HelpDocController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(helpDocController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, helpDocController.DatabaseType);

                    HelpDoc helpDocFirst = new HelpDoc();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        HelpDocService helpDocService = new HelpDocService(query, db, ContactID);
                        helpDocFirst = (from c in db.HelpDocs select c).FirstOrDefault();
                        count = (from c in db.HelpDocs select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with HelpDoc info
                    IHttpActionResult jsonRet = helpDocController.GetHelpDocList();
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<List<HelpDoc>> ret = jsonRet as OkNegotiatedContentResult<List<HelpDoc>>;
                    Assert.AreEqual(helpDocFirst.HelpDocID, ret.Content[0].HelpDocID);
                    Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<HelpDoc> helpDocList = new List<HelpDoc>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        HelpDocService helpDocService = new HelpDocService(query, db, ContactID);
                        helpDocList = (from c in db.HelpDocs select c).OrderBy(c => c.HelpDocID).Skip(0).Take(2).ToList();
                        count = (from c in db.HelpDocs select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with HelpDoc info
                        jsonRet = helpDocController.GetHelpDocList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsNotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<HelpDoc>>;
                        Assert.AreEqual(helpDocList[0].HelpDocID, ret.Content[0].HelpDocID);
                        Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with HelpDoc info
                           IHttpActionResult jsonRet2 = helpDocController.GetHelpDocList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.IsNotNull(jsonRet2);

                           OkNegotiatedContentResult<List<HelpDoc>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<HelpDoc>>;
                           Assert.AreEqual(helpDocList[1].HelpDocID, ret2.Content[0].HelpDocID);
                           Assert.AreEqual((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [TestMethod]
        public void HelpDoc_Controller_GetHelpDocWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    HelpDocController helpDocController = new HelpDocController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(helpDocController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, helpDocController.DatabaseType);

                    HelpDoc helpDocFirst = new HelpDoc();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        HelpDocService helpDocService = new HelpDocService(new Query(), db, ContactID);
                        helpDocFirst = (from c in db.HelpDocs select c).FirstOrDefault();
                    }

                    // ok with HelpDoc info
                    IHttpActionResult jsonRet = helpDocController.GetHelpDocWithID(helpDocFirst.HelpDocID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<HelpDoc> Ret = jsonRet as OkNegotiatedContentResult<HelpDoc>;
                    HelpDoc helpDocRet = Ret.Content;
                    Assert.AreEqual(helpDocFirst.HelpDocID, helpDocRet.HelpDocID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = helpDocController.GetHelpDocWithID(0);
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<HelpDoc> helpDocRet2 = jsonRet2 as OkNegotiatedContentResult<HelpDoc>;
                    Assert.IsNull(helpDocRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.IsNotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [TestMethod]
        public void HelpDoc_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    HelpDocController helpDocController = new HelpDocController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(helpDocController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, helpDocController.DatabaseType);

                    HelpDoc helpDocLast = new HelpDoc();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        HelpDocService helpDocService = new HelpDocService(query, db, ContactID);
                        helpDocLast = (from c in db.HelpDocs select c).FirstOrDefault();
                    }

                    // ok with HelpDoc info
                    IHttpActionResult jsonRet = helpDocController.GetHelpDocWithID(helpDocLast.HelpDocID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<HelpDoc> Ret = jsonRet as OkNegotiatedContentResult<HelpDoc>;
                    HelpDoc helpDocRet = Ret.Content;
                    Assert.AreEqual(helpDocLast.HelpDocID, helpDocRet.HelpDocID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because HelpDocID exist
                    IHttpActionResult jsonRet2 = helpDocController.Post(helpDocRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<HelpDoc> helpDocRet2 = jsonRet2 as OkNegotiatedContentResult<HelpDoc>;
                    Assert.IsNull(helpDocRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest2);

                    // Post to return newly added HelpDoc
                    helpDocRet.HelpDocID = 0;
                    helpDocController.Request = new System.Net.Http.HttpRequestMessage();
                    helpDocController.Request.RequestUri = new System.Uri("http://localhost:5000/api/helpDoc");
                    IHttpActionResult jsonRet3 = helpDocController.Post(helpDocRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<HelpDoc> helpDocRet3 = jsonRet3 as CreatedNegotiatedContentResult<HelpDoc>;
                    Assert.IsNotNull(helpDocRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = helpDocController.Delete(helpDocRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<HelpDoc> helpDocRet4 = jsonRet4 as OkNegotiatedContentResult<HelpDoc>;
                    Assert.IsNotNull(helpDocRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [TestMethod]
        public void HelpDoc_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    HelpDocController helpDocController = new HelpDocController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(helpDocController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, helpDocController.DatabaseType);

                    HelpDoc helpDocLast = new HelpDoc();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        HelpDocService helpDocService = new HelpDocService(query, db, ContactID);
                        helpDocLast = (from c in db.HelpDocs select c).FirstOrDefault();
                    }

                    // ok with HelpDoc info
                    IHttpActionResult jsonRet = helpDocController.GetHelpDocWithID(helpDocLast.HelpDocID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<HelpDoc> Ret = jsonRet as OkNegotiatedContentResult<HelpDoc>;
                    HelpDoc helpDocRet = Ret.Content;
                    Assert.AreEqual(helpDocLast.HelpDocID, helpDocRet.HelpDocID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = helpDocController.Put(helpDocRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<HelpDoc> helpDocRet2 = jsonRet2 as OkNegotiatedContentResult<HelpDoc>;
                    Assert.IsNotNull(helpDocRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because HelpDocID of 0 does not exist
                    helpDocRet.HelpDocID = 0;
                    IHttpActionResult jsonRet3 = helpDocController.Put(helpDocRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    OkNegotiatedContentResult<HelpDoc> helpDocRet3 = jsonRet3 as OkNegotiatedContentResult<HelpDoc>;
                    Assert.IsNull(helpDocRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [TestMethod]
        public void HelpDoc_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    HelpDocController helpDocController = new HelpDocController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(helpDocController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, helpDocController.DatabaseType);

                    HelpDoc helpDocLast = new HelpDoc();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        HelpDocService helpDocService = new HelpDocService(query, db, ContactID);
                        helpDocLast = (from c in db.HelpDocs select c).FirstOrDefault();
                    }

                    // ok with HelpDoc info
                    IHttpActionResult jsonRet = helpDocController.GetHelpDocWithID(helpDocLast.HelpDocID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<HelpDoc> Ret = jsonRet as OkNegotiatedContentResult<HelpDoc>;
                    HelpDoc helpDocRet = Ret.Content;
                    Assert.AreEqual(helpDocLast.HelpDocID, helpDocRet.HelpDocID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added HelpDoc
                    helpDocRet.HelpDocID = 0;
                    helpDocController.Request = new System.Net.Http.HttpRequestMessage();
                    helpDocController.Request.RequestUri = new System.Uri("http://localhost:5000/api/helpDoc");
                    IHttpActionResult jsonRet3 = helpDocController.Post(helpDocRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<HelpDoc> helpDocRet3 = jsonRet3 as CreatedNegotiatedContentResult<HelpDoc>;
                    Assert.IsNotNull(helpDocRet3);
                    HelpDoc helpDoc = helpDocRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = helpDocController.Delete(helpDocRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<HelpDoc> helpDocRet2 = jsonRet2 as OkNegotiatedContentResult<HelpDoc>;
                    Assert.IsNotNull(helpDocRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because HelpDocID of 0 does not exist
                    helpDocRet.HelpDocID = 0;
                    IHttpActionResult jsonRet4 = helpDocController.Delete(helpDocRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<HelpDoc> helpDocRet4 = jsonRet4 as OkNegotiatedContentResult<HelpDoc>;
                    Assert.IsNull(helpDocRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
