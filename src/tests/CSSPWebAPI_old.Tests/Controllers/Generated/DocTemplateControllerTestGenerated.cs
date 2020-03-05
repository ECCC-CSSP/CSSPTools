using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Xunit;
using CSSPWebAPI.Controllers;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System;
using CSSPWebAPI.Controllers.Resources;

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
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(docTemplateFirst.DocTemplateID, ((List<DocTemplate>)ret.Value)[0].DocTemplateID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<DocTemplate>)ret.Value).Count);

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
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(docTemplateList[0].DocTemplateID, ((List<DocTemplate>)ret.Value)[0].DocTemplateID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<DocTemplate>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with DocTemplate info
                           IActionResult jsonRet2 = docTemplateController.GetDocTemplateList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(docTemplateList[1].DocTemplateID, ((List<DocTemplate>)ret2.Value)[0].DocTemplateID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<DocTemplate>)ret2.Value).Count);
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
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(docTemplateFirst.DocTemplateID, ((DocTemplate)ret.Value).DocTemplateID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = docTemplateController.GetDocTemplateWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult docTemplateRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(docTemplateRet2);
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

                    DocTemplate docTemplateFirst = new DocTemplate();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        DocTemplateService docTemplateService = new DocTemplateService(query, db, ContactID);
                        docTemplateFirst = (from c in db.DocTemplates select c).FirstOrDefault();
                    }

                    // ok with DocTemplate info
                    IActionResult jsonRet = docTemplateController.GetDocTemplateWithID(docTemplateFirst.DocTemplateID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    DocTemplate docTemplateRet = (DocTemplate)ret.Value;
                    Assert.Equal(docTemplateFirst.DocTemplateID, docTemplateRet.DocTemplateID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because DocTemplateID exist
                    IActionResult jsonRet2 = docTemplateController.Post(docTemplateRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added DocTemplate
                    docTemplateRet.DocTemplateID = 0;
                    IActionResult jsonRet3 = docTemplateController.Post(docTemplateRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = docTemplateController.Delete(docTemplateRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet4);

                    OkObjectResult ret4 = jsonRet4 as OkObjectResult;
                    Assert.NotNull(ret4);

                    BadRequestResult badRequest4 = jsonRet4 as BadRequestResult;
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

                    DocTemplate docTemplateFirst = new DocTemplate();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        DocTemplateService docTemplateService = new DocTemplateService(query, db, ContactID);
                        docTemplateFirst = (from c in db.DocTemplates select c).FirstOrDefault();
                    }

                    // ok with DocTemplate info
                    IActionResult jsonRet = docTemplateController.GetDocTemplateWithID(docTemplateFirst.DocTemplateID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    DocTemplate docTemplateRet = (DocTemplate)Ret.Value;
                    Assert.Equal(docTemplateFirst.DocTemplateID, docTemplateRet.DocTemplateID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = docTemplateController.Put(docTemplateRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult docTemplateRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(docTemplateRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because DocTemplateID of 0 does not exist
                    docTemplateRet.DocTemplateID = 0;
                    IActionResult jsonRet3 = docTemplateController.Put(docTemplateRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult docTemplateRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(docTemplateRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
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

                    DocTemplate docTemplateFirst = new DocTemplate();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        DocTemplateService docTemplateService = new DocTemplateService(query, db, ContactID);
                        docTemplateFirst = (from c in db.DocTemplates select c).FirstOrDefault();
                    }

                    // ok with DocTemplate info
                    IActionResult jsonRet = docTemplateController.GetDocTemplateWithID(docTemplateFirst.DocTemplateID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    DocTemplate docTemplateRet = (DocTemplate)Ret.Value;
                    Assert.Equal(docTemplateFirst.DocTemplateID, docTemplateRet.DocTemplateID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added DocTemplate
                    docTemplateRet.DocTemplateID = 0;
                    IActionResult jsonRet3 = docTemplateController.Post(docTemplateRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    DocTemplate docTemplate = (DocTemplate)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = docTemplateController.Delete(docTemplateRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because DocTemplateID of 0 does not exist
                    docTemplateRet.DocTemplateID = 0;
                    IActionResult jsonRet4 = docTemplateController.Delete(docTemplateRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet4);

                    OkObjectResult ret4 = jsonRet4 as OkObjectResult;
                    Assert.Null(ret4);

                    BadRequestObjectResult badRequest4 = jsonRet4 as BadRequestObjectResult;
                    Assert.NotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}