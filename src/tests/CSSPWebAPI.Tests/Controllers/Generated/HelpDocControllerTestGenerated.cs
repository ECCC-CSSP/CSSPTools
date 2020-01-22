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
        [Fact]
        public void HelpDoc_Controller_GetHelpDocList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    HelpDocController helpDocController = new HelpDocController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(helpDocController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, helpDocController.DatabaseType);

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
                    IActionResult jsonRet = helpDocController.GetHelpDocList();
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<List<HelpDoc>> ret = jsonRet as OkNegotiatedContentResult<List<HelpDoc>>;
                    Assert.Equal(helpDocFirst.HelpDocID, ret.Content[0].HelpDocID);
                    Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

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
                        Assert.NotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<HelpDoc>>;
                        Assert.Equal(helpDocList[0].HelpDocID, ret.Content[0].HelpDocID);
                        Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with HelpDoc info
                           IActionResult jsonRet2 = helpDocController.GetHelpDocList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkNegotiatedContentResult<List<HelpDoc>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<HelpDoc>>;
                           Assert.Equal(helpDocList[1].HelpDocID, ret2.Content[0].HelpDocID);
                           Assert.Equal((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void HelpDoc_Controller_GetHelpDocWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    HelpDocController helpDocController = new HelpDocController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(helpDocController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, helpDocController.DatabaseType);

                    HelpDoc helpDocFirst = new HelpDoc();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        HelpDocService helpDocService = new HelpDocService(new Query(), db, ContactID);
                        helpDocFirst = (from c in db.HelpDocs select c).FirstOrDefault();
                    }

                    // ok with HelpDoc info
                    IActionResult jsonRet = helpDocController.GetHelpDocWithID(helpDocFirst.HelpDocID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<HelpDoc> Ret = jsonRet as OkNegotiatedContentResult<HelpDoc>;
                    HelpDoc helpDocRet = Ret.Content;
                    Assert.Equal(helpDocFirst.HelpDocID, helpDocRet.HelpDocID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = helpDocController.GetHelpDocWithID(0);
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<HelpDoc> helpDocRet2 = jsonRet2 as OkNegotiatedContentResult<HelpDoc>;
                    Assert.Null(helpDocRet2);

                    NotFoundObjectResult notFoundRequest = jsonRet2 as NotFoundObjectResult;
                    Assert.NotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void HelpDoc_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    HelpDocController helpDocController = new HelpDocController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(helpDocController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, helpDocController.DatabaseType);

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
                    IActionResult jsonRet = helpDocController.GetHelpDocWithID(helpDocLast.HelpDocID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<HelpDoc> Ret = jsonRet as OkNegotiatedContentResult<HelpDoc>;
                    HelpDoc helpDocRet = Ret.Content;
                    Assert.Equal(helpDocLast.HelpDocID, helpDocRet.HelpDocID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because HelpDocID exist
                    IActionResult jsonRet2 = helpDocController.Post(helpDocRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<HelpDoc> helpDocRet2 = jsonRet2 as OkNegotiatedContentResult<HelpDoc>;
                    Assert.Null(helpDocRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added HelpDoc
                    helpDocRet.HelpDocID = 0;
                    helpDocController.Request = new System.Net.Http.HttpRequestMessage();
                    helpDocController.Request.RequestUri = new System.Uri("http://localhost:5000/api/helpDoc");
                    IActionResult jsonRet3 = helpDocController.Post(helpDocRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<HelpDoc> helpDocRet3 = jsonRet3 as CreatedNegotiatedContentResult<HelpDoc>;
                    Assert.NotNull(helpDocRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = helpDocController.Delete(helpDocRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<HelpDoc> helpDocRet4 = jsonRet4 as OkNegotiatedContentResult<HelpDoc>;
                    Assert.NotNull(helpDocRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [Fact]
        public void HelpDoc_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    HelpDocController helpDocController = new HelpDocController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(helpDocController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, helpDocController.DatabaseType);

                    HelpDoc helpDocLast = new HelpDoc();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        HelpDocService helpDocService = new HelpDocService(query, db, ContactID);
                        helpDocLast = (from c in db.HelpDocs select c).FirstOrDefault();
                    }

                    // ok with HelpDoc info
                    IActionResult jsonRet = helpDocController.GetHelpDocWithID(helpDocLast.HelpDocID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<HelpDoc> Ret = jsonRet as OkNegotiatedContentResult<HelpDoc>;
                    HelpDoc helpDocRet = Ret.Content;
                    Assert.Equal(helpDocLast.HelpDocID, helpDocRet.HelpDocID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = helpDocController.Put(helpDocRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<HelpDoc> helpDocRet2 = jsonRet2 as OkNegotiatedContentResult<HelpDoc>;
                    Assert.NotNull(helpDocRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because HelpDocID of 0 does not exist
                    helpDocRet.HelpDocID = 0;
                    IActionResult jsonRet3 = helpDocController.Put(helpDocRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    OkNegotiatedContentResult<HelpDoc> helpDocRet3 = jsonRet3 as OkNegotiatedContentResult<HelpDoc>;
                    Assert.Null(helpDocRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void HelpDoc_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    HelpDocController helpDocController = new HelpDocController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(helpDocController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, helpDocController.DatabaseType);

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
                    IActionResult jsonRet = helpDocController.GetHelpDocWithID(helpDocLast.HelpDocID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<HelpDoc> Ret = jsonRet as OkNegotiatedContentResult<HelpDoc>;
                    HelpDoc helpDocRet = Ret.Content;
                    Assert.Equal(helpDocLast.HelpDocID, helpDocRet.HelpDocID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return newly added HelpDoc
                    helpDocRet.HelpDocID = 0;
                    helpDocController.Request = new System.Net.Http.HttpRequestMessage();
                    helpDocController.Request.RequestUri = new System.Uri("http://localhost:5000/api/helpDoc");
                    IActionResult jsonRet3 = helpDocController.Post(helpDocRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<HelpDoc> helpDocRet3 = jsonRet3 as CreatedNegotiatedContentResult<HelpDoc>;
                    Assert.NotNull(helpDocRet3);
                    HelpDoc helpDoc = helpDocRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = helpDocController.Delete(helpDocRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<HelpDoc> helpDocRet2 = jsonRet2 as OkNegotiatedContentResult<HelpDoc>;
                    Assert.NotNull(helpDocRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because HelpDocID of 0 does not exist
                    helpDocRet.HelpDocID = 0;
                    IActionResult jsonRet4 = helpDocController.Delete(helpDocRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<HelpDoc> helpDocRet4 = jsonRet4 as OkNegotiatedContentResult<HelpDoc>;
                    Assert.Null(helpDocRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
