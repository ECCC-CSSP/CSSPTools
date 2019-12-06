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
    public partial class DocTemplateControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public DocTemplateControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [TestMethod]
        public void DocTemplate_Controller_GetDocTemplateList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    DocTemplateController docTemplateController = new DocTemplateController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(docTemplateController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, docTemplateController.DatabaseType);

                    DocTemplate docTemplateFirst = new DocTemplate();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        DocTemplateService docTemplateService = new DocTemplateService(query, db, ContactID);
                        docTemplateFirst = (from c in db.DocTemplates select c).FirstOrDefault();
                        count = (from c in db.DocTemplates select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with DocTemplate info
                    IHttpActionResult jsonRet = docTemplateController.GetDocTemplateList();
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<List<DocTemplate>> ret = jsonRet as OkNegotiatedContentResult<List<DocTemplate>>;
                    Assert.AreEqual(docTemplateFirst.DocTemplateID, ret.Content[0].DocTemplateID);
                    Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<DocTemplate> docTemplateList = new List<DocTemplate>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        DocTemplateService docTemplateService = new DocTemplateService(query, db, ContactID);
                        docTemplateList = (from c in db.DocTemplates select c).OrderBy(c => c.DocTemplateID).Skip(0).Take(2).ToList();
                        count = (from c in db.DocTemplates select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with DocTemplate info
                        jsonRet = docTemplateController.GetDocTemplateList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsNotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<DocTemplate>>;
                        Assert.AreEqual(docTemplateList[0].DocTemplateID, ret.Content[0].DocTemplateID);
                        Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with DocTemplate info
                           IHttpActionResult jsonRet2 = docTemplateController.GetDocTemplateList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.IsNotNull(jsonRet2);

                           OkNegotiatedContentResult<List<DocTemplate>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<DocTemplate>>;
                           Assert.AreEqual(docTemplateList[1].DocTemplateID, ret2.Content[0].DocTemplateID);
                           Assert.AreEqual((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [TestMethod]
        public void DocTemplate_Controller_GetDocTemplateWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    DocTemplateController docTemplateController = new DocTemplateController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(docTemplateController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, docTemplateController.DatabaseType);

                    DocTemplate docTemplateFirst = new DocTemplate();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        DocTemplateService docTemplateService = new DocTemplateService(new Query(), db, ContactID);
                        docTemplateFirst = (from c in db.DocTemplates select c).FirstOrDefault();
                    }

                    // ok with DocTemplate info
                    IHttpActionResult jsonRet = docTemplateController.GetDocTemplateWithID(docTemplateFirst.DocTemplateID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<DocTemplate> Ret = jsonRet as OkNegotiatedContentResult<DocTemplate>;
                    DocTemplate docTemplateRet = Ret.Content;
                    Assert.AreEqual(docTemplateFirst.DocTemplateID, docTemplateRet.DocTemplateID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = docTemplateController.GetDocTemplateWithID(0);
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<DocTemplate> docTemplateRet2 = jsonRet2 as OkNegotiatedContentResult<DocTemplate>;
                    Assert.IsNull(docTemplateRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.IsNotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [TestMethod]
        public void DocTemplate_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    DocTemplateController docTemplateController = new DocTemplateController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(docTemplateController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, docTemplateController.DatabaseType);

                    DocTemplate docTemplateLast = new DocTemplate();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        DocTemplateService docTemplateService = new DocTemplateService(query, db, ContactID);
                        docTemplateLast = (from c in db.DocTemplates select c).FirstOrDefault();
                    }

                    // ok with DocTemplate info
                    IHttpActionResult jsonRet = docTemplateController.GetDocTemplateWithID(docTemplateLast.DocTemplateID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<DocTemplate> Ret = jsonRet as OkNegotiatedContentResult<DocTemplate>;
                    DocTemplate docTemplateRet = Ret.Content;
                    Assert.AreEqual(docTemplateLast.DocTemplateID, docTemplateRet.DocTemplateID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because DocTemplateID exist
                    IHttpActionResult jsonRet2 = docTemplateController.Post(docTemplateRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<DocTemplate> docTemplateRet2 = jsonRet2 as OkNegotiatedContentResult<DocTemplate>;
                    Assert.IsNull(docTemplateRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest2);

                    // Post to return newly added DocTemplate
                    docTemplateRet.DocTemplateID = 0;
                    docTemplateController.Request = new System.Net.Http.HttpRequestMessage();
                    docTemplateController.Request.RequestUri = new System.Uri("http://localhost:5000/api/docTemplate");
                    IHttpActionResult jsonRet3 = docTemplateController.Post(docTemplateRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<DocTemplate> docTemplateRet3 = jsonRet3 as CreatedNegotiatedContentResult<DocTemplate>;
                    Assert.IsNotNull(docTemplateRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = docTemplateController.Delete(docTemplateRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<DocTemplate> docTemplateRet4 = jsonRet4 as OkNegotiatedContentResult<DocTemplate>;
                    Assert.IsNotNull(docTemplateRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [TestMethod]
        public void DocTemplate_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    DocTemplateController docTemplateController = new DocTemplateController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(docTemplateController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, docTemplateController.DatabaseType);

                    DocTemplate docTemplateLast = new DocTemplate();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        DocTemplateService docTemplateService = new DocTemplateService(query, db, ContactID);
                        docTemplateLast = (from c in db.DocTemplates select c).FirstOrDefault();
                    }

                    // ok with DocTemplate info
                    IHttpActionResult jsonRet = docTemplateController.GetDocTemplateWithID(docTemplateLast.DocTemplateID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<DocTemplate> Ret = jsonRet as OkNegotiatedContentResult<DocTemplate>;
                    DocTemplate docTemplateRet = Ret.Content;
                    Assert.AreEqual(docTemplateLast.DocTemplateID, docTemplateRet.DocTemplateID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = docTemplateController.Put(docTemplateRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<DocTemplate> docTemplateRet2 = jsonRet2 as OkNegotiatedContentResult<DocTemplate>;
                    Assert.IsNotNull(docTemplateRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because DocTemplateID of 0 does not exist
                    docTemplateRet.DocTemplateID = 0;
                    IHttpActionResult jsonRet3 = docTemplateController.Put(docTemplateRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    OkNegotiatedContentResult<DocTemplate> docTemplateRet3 = jsonRet3 as OkNegotiatedContentResult<DocTemplate>;
                    Assert.IsNull(docTemplateRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [TestMethod]
        public void DocTemplate_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    DocTemplateController docTemplateController = new DocTemplateController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(docTemplateController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, docTemplateController.DatabaseType);

                    DocTemplate docTemplateLast = new DocTemplate();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        DocTemplateService docTemplateService = new DocTemplateService(query, db, ContactID);
                        docTemplateLast = (from c in db.DocTemplates select c).FirstOrDefault();
                    }

                    // ok with DocTemplate info
                    IHttpActionResult jsonRet = docTemplateController.GetDocTemplateWithID(docTemplateLast.DocTemplateID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<DocTemplate> Ret = jsonRet as OkNegotiatedContentResult<DocTemplate>;
                    DocTemplate docTemplateRet = Ret.Content;
                    Assert.AreEqual(docTemplateLast.DocTemplateID, docTemplateRet.DocTemplateID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added DocTemplate
                    docTemplateRet.DocTemplateID = 0;
                    docTemplateController.Request = new System.Net.Http.HttpRequestMessage();
                    docTemplateController.Request.RequestUri = new System.Uri("http://localhost:5000/api/docTemplate");
                    IHttpActionResult jsonRet3 = docTemplateController.Post(docTemplateRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<DocTemplate> docTemplateRet3 = jsonRet3 as CreatedNegotiatedContentResult<DocTemplate>;
                    Assert.IsNotNull(docTemplateRet3);
                    DocTemplate docTemplate = docTemplateRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = docTemplateController.Delete(docTemplateRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<DocTemplate> docTemplateRet2 = jsonRet2 as OkNegotiatedContentResult<DocTemplate>;
                    Assert.IsNotNull(docTemplateRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because DocTemplateID of 0 does not exist
                    docTemplateRet.DocTemplateID = 0;
                    IHttpActionResult jsonRet4 = docTemplateController.Delete(docTemplateRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<DocTemplate> docTemplateRet4 = jsonRet4 as OkNegotiatedContentResult<DocTemplate>;
                    Assert.IsNull(docTemplateRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
