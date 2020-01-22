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
        [Fact]
        public void TVTypeUserAuthorization_Controller_GetTVTypeUserAuthorizationList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVTypeUserAuthorizationController tvTypeUserAuthorizationController = new TVTypeUserAuthorizationController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tvTypeUserAuthorizationController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tvTypeUserAuthorizationController.DatabaseType);

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
                    IActionResult jsonRet = tvTypeUserAuthorizationController.GetTVTypeUserAuthorizationList();
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<List<TVTypeUserAuthorization>> ret = jsonRet as OkNegotiatedContentResult<List<TVTypeUserAuthorization>>;
                    Assert.Equal(tvTypeUserAuthorizationFirst.TVTypeUserAuthorizationID, ret.Content[0].TVTypeUserAuthorizationID);
                    Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

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
                        Assert.NotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<TVTypeUserAuthorization>>;
                        Assert.Equal(tvTypeUserAuthorizationList[0].TVTypeUserAuthorizationID, ret.Content[0].TVTypeUserAuthorizationID);
                        Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with TVTypeUserAuthorization info
                           IActionResult jsonRet2 = tvTypeUserAuthorizationController.GetTVTypeUserAuthorizationList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkNegotiatedContentResult<List<TVTypeUserAuthorization>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<TVTypeUserAuthorization>>;
                           Assert.Equal(tvTypeUserAuthorizationList[1].TVTypeUserAuthorizationID, ret2.Content[0].TVTypeUserAuthorizationID);
                           Assert.Equal((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void TVTypeUserAuthorization_Controller_GetTVTypeUserAuthorizationWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVTypeUserAuthorizationController tvTypeUserAuthorizationController = new TVTypeUserAuthorizationController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tvTypeUserAuthorizationController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tvTypeUserAuthorizationController.DatabaseType);

                    TVTypeUserAuthorization tvTypeUserAuthorizationFirst = new TVTypeUserAuthorization();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        TVTypeUserAuthorizationService tvTypeUserAuthorizationService = new TVTypeUserAuthorizationService(new Query(), db, ContactID);
                        tvTypeUserAuthorizationFirst = (from c in db.TVTypeUserAuthorizations select c).FirstOrDefault();
                    }

                    // ok with TVTypeUserAuthorization info
                    IActionResult jsonRet = tvTypeUserAuthorizationController.GetTVTypeUserAuthorizationWithID(tvTypeUserAuthorizationFirst.TVTypeUserAuthorizationID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<TVTypeUserAuthorization> Ret = jsonRet as OkNegotiatedContentResult<TVTypeUserAuthorization>;
                    TVTypeUserAuthorization tvTypeUserAuthorizationRet = Ret.Content;
                    Assert.Equal(tvTypeUserAuthorizationFirst.TVTypeUserAuthorizationID, tvTypeUserAuthorizationRet.TVTypeUserAuthorizationID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = tvTypeUserAuthorizationController.GetTVTypeUserAuthorizationWithID(0);
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<TVTypeUserAuthorization> tvTypeUserAuthorizationRet2 = jsonRet2 as OkNegotiatedContentResult<TVTypeUserAuthorization>;
                    Assert.Null(tvTypeUserAuthorizationRet2);

                    NotFoundObjectResult notFoundRequest = jsonRet2 as NotFoundObjectResult;
                    Assert.NotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void TVTypeUserAuthorization_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVTypeUserAuthorizationController tvTypeUserAuthorizationController = new TVTypeUserAuthorizationController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tvTypeUserAuthorizationController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tvTypeUserAuthorizationController.DatabaseType);

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
                    IActionResult jsonRet = tvTypeUserAuthorizationController.GetTVTypeUserAuthorizationWithID(tvTypeUserAuthorizationLast.TVTypeUserAuthorizationID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<TVTypeUserAuthorization> Ret = jsonRet as OkNegotiatedContentResult<TVTypeUserAuthorization>;
                    TVTypeUserAuthorization tvTypeUserAuthorizationRet = Ret.Content;
                    Assert.Equal(tvTypeUserAuthorizationLast.TVTypeUserAuthorizationID, tvTypeUserAuthorizationRet.TVTypeUserAuthorizationID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because TVTypeUserAuthorizationID exist
                    IActionResult jsonRet2 = tvTypeUserAuthorizationController.Post(tvTypeUserAuthorizationRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<TVTypeUserAuthorization> tvTypeUserAuthorizationRet2 = jsonRet2 as OkNegotiatedContentResult<TVTypeUserAuthorization>;
                    Assert.Null(tvTypeUserAuthorizationRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added TVTypeUserAuthorization
                    tvTypeUserAuthorizationRet.TVTypeUserAuthorizationID = 0;
                    tvTypeUserAuthorizationController.Request = new System.Net.Http.HttpRequestMessage();
                    tvTypeUserAuthorizationController.Request.RequestUri = new System.Uri("http://localhost:5000/api/tvTypeUserAuthorization");
                    IActionResult jsonRet3 = tvTypeUserAuthorizationController.Post(tvTypeUserAuthorizationRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<TVTypeUserAuthorization> tvTypeUserAuthorizationRet3 = jsonRet3 as CreatedNegotiatedContentResult<TVTypeUserAuthorization>;
                    Assert.NotNull(tvTypeUserAuthorizationRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = tvTypeUserAuthorizationController.Delete(tvTypeUserAuthorizationRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<TVTypeUserAuthorization> tvTypeUserAuthorizationRet4 = jsonRet4 as OkNegotiatedContentResult<TVTypeUserAuthorization>;
                    Assert.NotNull(tvTypeUserAuthorizationRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [Fact]
        public void TVTypeUserAuthorization_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVTypeUserAuthorizationController tvTypeUserAuthorizationController = new TVTypeUserAuthorizationController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tvTypeUserAuthorizationController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tvTypeUserAuthorizationController.DatabaseType);

                    TVTypeUserAuthorization tvTypeUserAuthorizationLast = new TVTypeUserAuthorization();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        TVTypeUserAuthorizationService tvTypeUserAuthorizationService = new TVTypeUserAuthorizationService(query, db, ContactID);
                        tvTypeUserAuthorizationLast = (from c in db.TVTypeUserAuthorizations select c).FirstOrDefault();
                    }

                    // ok with TVTypeUserAuthorization info
                    IActionResult jsonRet = tvTypeUserAuthorizationController.GetTVTypeUserAuthorizationWithID(tvTypeUserAuthorizationLast.TVTypeUserAuthorizationID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<TVTypeUserAuthorization> Ret = jsonRet as OkNegotiatedContentResult<TVTypeUserAuthorization>;
                    TVTypeUserAuthorization tvTypeUserAuthorizationRet = Ret.Content;
                    Assert.Equal(tvTypeUserAuthorizationLast.TVTypeUserAuthorizationID, tvTypeUserAuthorizationRet.TVTypeUserAuthorizationID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = tvTypeUserAuthorizationController.Put(tvTypeUserAuthorizationRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<TVTypeUserAuthorization> tvTypeUserAuthorizationRet2 = jsonRet2 as OkNegotiatedContentResult<TVTypeUserAuthorization>;
                    Assert.NotNull(tvTypeUserAuthorizationRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because TVTypeUserAuthorizationID of 0 does not exist
                    tvTypeUserAuthorizationRet.TVTypeUserAuthorizationID = 0;
                    IActionResult jsonRet3 = tvTypeUserAuthorizationController.Put(tvTypeUserAuthorizationRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    OkNegotiatedContentResult<TVTypeUserAuthorization> tvTypeUserAuthorizationRet3 = jsonRet3 as OkNegotiatedContentResult<TVTypeUserAuthorization>;
                    Assert.Null(tvTypeUserAuthorizationRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void TVTypeUserAuthorization_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVTypeUserAuthorizationController tvTypeUserAuthorizationController = new TVTypeUserAuthorizationController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tvTypeUserAuthorizationController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tvTypeUserAuthorizationController.DatabaseType);

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
                    IActionResult jsonRet = tvTypeUserAuthorizationController.GetTVTypeUserAuthorizationWithID(tvTypeUserAuthorizationLast.TVTypeUserAuthorizationID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<TVTypeUserAuthorization> Ret = jsonRet as OkNegotiatedContentResult<TVTypeUserAuthorization>;
                    TVTypeUserAuthorization tvTypeUserAuthorizationRet = Ret.Content;
                    Assert.Equal(tvTypeUserAuthorizationLast.TVTypeUserAuthorizationID, tvTypeUserAuthorizationRet.TVTypeUserAuthorizationID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return newly added TVTypeUserAuthorization
                    tvTypeUserAuthorizationRet.TVTypeUserAuthorizationID = 0;
                    tvTypeUserAuthorizationController.Request = new System.Net.Http.HttpRequestMessage();
                    tvTypeUserAuthorizationController.Request.RequestUri = new System.Uri("http://localhost:5000/api/tvTypeUserAuthorization");
                    IActionResult jsonRet3 = tvTypeUserAuthorizationController.Post(tvTypeUserAuthorizationRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<TVTypeUserAuthorization> tvTypeUserAuthorizationRet3 = jsonRet3 as CreatedNegotiatedContentResult<TVTypeUserAuthorization>;
                    Assert.NotNull(tvTypeUserAuthorizationRet3);
                    TVTypeUserAuthorization tvTypeUserAuthorization = tvTypeUserAuthorizationRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = tvTypeUserAuthorizationController.Delete(tvTypeUserAuthorizationRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<TVTypeUserAuthorization> tvTypeUserAuthorizationRet2 = jsonRet2 as OkNegotiatedContentResult<TVTypeUserAuthorization>;
                    Assert.NotNull(tvTypeUserAuthorizationRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because TVTypeUserAuthorizationID of 0 does not exist
                    tvTypeUserAuthorizationRet.TVTypeUserAuthorizationID = 0;
                    IActionResult jsonRet4 = tvTypeUserAuthorizationController.Delete(tvTypeUserAuthorizationRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<TVTypeUserAuthorization> tvTypeUserAuthorizationRet4 = jsonRet4 as OkNegotiatedContentResult<TVTypeUserAuthorization>;
                    Assert.Null(tvTypeUserAuthorizationRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
