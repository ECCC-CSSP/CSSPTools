using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Xunit;
using CSSPWebAPI.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.AspNetCore.Mvc;

namespace CSSPWebAPI.Tests.Controllers
{
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
        [Fact]
        public void DocTemplate_Controller_GetDocTemplateList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    DocTemplateController docTemplateController = new DocTemplateController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(docTemplateController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, docTemplateController.DatabaseType);

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
                    IActionResult jsonRet = docTemplateController.GetDocTemplateList();
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<List<DocTemplate>> ret = jsonRet as OkNegotiatedContentResult<List<DocTemplate>>;
                    Assert.Equal(docTemplateFirst.DocTemplateID, ret.Content[0].DocTemplateID);
                    Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

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
                        Assert.NotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<DocTemplate>>;
                        Assert.Equal(docTemplateList[0].DocTemplateID, ret.Content[0].DocTemplateID);
                        Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with DocTemplate info
                           IActionResult jsonRet2 = docTemplateController.GetDocTemplateList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkNegotiatedContentResult<List<DocTemplate>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<DocTemplate>>;
                           Assert.Equal(docTemplateList[1].DocTemplateID, ret2.Content[0].DocTemplateID);
                           Assert.Equal((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void DocTemplate_Controller_GetDocTemplateWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    DocTemplateController docTemplateController = new DocTemplateController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(docTemplateController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, docTemplateController.DatabaseType);

                    DocTemplate docTemplateFirst = new DocTemplate();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        DocTemplateService docTemplateService = new DocTemplateService(new Query(), db, ContactID);
                        docTemplateFirst = (from c in db.DocTemplates select c).FirstOrDefault();
                    }

                    // ok with DocTemplate info
                    IActionResult jsonRet = docTemplateController.GetDocTemplateWithID(docTemplateFirst.DocTemplateID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<DocTemplate> Ret = jsonRet as OkNegotiatedContentResult<DocTemplate>;
                    DocTemplate docTemplateRet = Ret.Content;
                    Assert.Equal(docTemplateFirst.DocTemplateID, docTemplateRet.DocTemplateID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = docTemplateController.GetDocTemplateWithID(0);
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<DocTemplate> docTemplateRet2 = jsonRet2 as OkNegotiatedContentResult<DocTemplate>;
                    Assert.Null(docTemplateRet2);

                    NotFoundObjectResult notFoundRequest = jsonRet2 as NotFoundObjectResult;
                    Assert.NotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void DocTemplate_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    DocTemplateController docTemplateController = new DocTemplateController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(docTemplateController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, docTemplateController.DatabaseType);

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
                    IActionResult jsonRet = docTemplateController.GetDocTemplateWithID(docTemplateLast.DocTemplateID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<DocTemplate> Ret = jsonRet as OkNegotiatedContentResult<DocTemplate>;
                    DocTemplate docTemplateRet = Ret.Content;
                    Assert.Equal(docTemplateLast.DocTemplateID, docTemplateRet.DocTemplateID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because DocTemplateID exist
                    IActionResult jsonRet2 = docTemplateController.Post(docTemplateRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<DocTemplate> docTemplateRet2 = jsonRet2 as OkNegotiatedContentResult<DocTemplate>;
                    Assert.Null(docTemplateRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added DocTemplate
                    docTemplateRet.DocTemplateID = 0;
                    docTemplateController.Request = new System.Net.Http.HttpRequestMessage();
                    docTemplateController.Request.RequestUri = new System.Uri("http://localhost:5000/api/docTemplate");
                    IActionResult jsonRet3 = docTemplateController.Post(docTemplateRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<DocTemplate> docTemplateRet3 = jsonRet3 as CreatedNegotiatedContentResult<DocTemplate>;
                    Assert.NotNull(docTemplateRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = docTemplateController.Delete(docTemplateRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<DocTemplate> docTemplateRet4 = jsonRet4 as OkNegotiatedContentResult<DocTemplate>;
                    Assert.NotNull(docTemplateRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [Fact]
        public void DocTemplate_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    DocTemplateController docTemplateController = new DocTemplateController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(docTemplateController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, docTemplateController.DatabaseType);

                    DocTemplate docTemplateLast = new DocTemplate();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        DocTemplateService docTemplateService = new DocTemplateService(query, db, ContactID);
                        docTemplateLast = (from c in db.DocTemplates select c).FirstOrDefault();
                    }

                    // ok with DocTemplate info
                    IActionResult jsonRet = docTemplateController.GetDocTemplateWithID(docTemplateLast.DocTemplateID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<DocTemplate> Ret = jsonRet as OkNegotiatedContentResult<DocTemplate>;
                    DocTemplate docTemplateRet = Ret.Content;
                    Assert.Equal(docTemplateLast.DocTemplateID, docTemplateRet.DocTemplateID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = docTemplateController.Put(docTemplateRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<DocTemplate> docTemplateRet2 = jsonRet2 as OkNegotiatedContentResult<DocTemplate>;
                    Assert.NotNull(docTemplateRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because DocTemplateID of 0 does not exist
                    docTemplateRet.DocTemplateID = 0;
                    IActionResult jsonRet3 = docTemplateController.Put(docTemplateRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    OkNegotiatedContentResult<DocTemplate> docTemplateRet3 = jsonRet3 as OkNegotiatedContentResult<DocTemplate>;
                    Assert.Null(docTemplateRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void DocTemplate_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    DocTemplateController docTemplateController = new DocTemplateController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(docTemplateController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, docTemplateController.DatabaseType);

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
                    IActionResult jsonRet = docTemplateController.GetDocTemplateWithID(docTemplateLast.DocTemplateID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<DocTemplate> Ret = jsonRet as OkNegotiatedContentResult<DocTemplate>;
                    DocTemplate docTemplateRet = Ret.Content;
                    Assert.Equal(docTemplateLast.DocTemplateID, docTemplateRet.DocTemplateID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return newly added DocTemplate
                    docTemplateRet.DocTemplateID = 0;
                    docTemplateController.Request = new System.Net.Http.HttpRequestMessage();
                    docTemplateController.Request.RequestUri = new System.Uri("http://localhost:5000/api/docTemplate");
                    IActionResult jsonRet3 = docTemplateController.Post(docTemplateRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<DocTemplate> docTemplateRet3 = jsonRet3 as CreatedNegotiatedContentResult<DocTemplate>;
                    Assert.NotNull(docTemplateRet3);
                    DocTemplate docTemplate = docTemplateRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = docTemplateController.Delete(docTemplateRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<DocTemplate> docTemplateRet2 = jsonRet2 as OkNegotiatedContentResult<DocTemplate>;
                    Assert.NotNull(docTemplateRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because DocTemplateID of 0 does not exist
                    docTemplateRet.DocTemplateID = 0;
                    IActionResult jsonRet4 = docTemplateController.Delete(docTemplateRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<DocTemplate> docTemplateRet4 = jsonRet4 as OkNegotiatedContentResult<DocTemplate>;
                    Assert.Null(docTemplateRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
