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
    public partial class UseOfSiteControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public UseOfSiteControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void UseOfSite_Controller_GetUseOfSiteList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    UseOfSiteController useOfSiteController = new UseOfSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(useOfSiteController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, useOfSiteController.DatabaseType);

                    UseOfSite useOfSiteFirst = new UseOfSite();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        UseOfSiteService useOfSiteService = new UseOfSiteService(query, db, ContactID);
                        useOfSiteFirst = (from c in db.UseOfSites select c).FirstOrDefault();
                        count = (from c in db.UseOfSites select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with UseOfSite info
                    IActionResult jsonRet = useOfSiteController.GetUseOfSiteList();
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<List<UseOfSite>> ret = jsonRet as OkNegotiatedContentResult<List<UseOfSite>>;
                    Assert.Equal(useOfSiteFirst.UseOfSiteID, ret.Content[0].UseOfSiteID);
                    Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<UseOfSite> useOfSiteList = new List<UseOfSite>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        UseOfSiteService useOfSiteService = new UseOfSiteService(query, db, ContactID);
                        useOfSiteList = (from c in db.UseOfSites select c).OrderBy(c => c.UseOfSiteID).Skip(0).Take(2).ToList();
                        count = (from c in db.UseOfSites select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with UseOfSite info
                        jsonRet = useOfSiteController.GetUseOfSiteList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.NotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<UseOfSite>>;
                        Assert.Equal(useOfSiteList[0].UseOfSiteID, ret.Content[0].UseOfSiteID);
                        Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with UseOfSite info
                           IActionResult jsonRet2 = useOfSiteController.GetUseOfSiteList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkNegotiatedContentResult<List<UseOfSite>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<UseOfSite>>;
                           Assert.Equal(useOfSiteList[1].UseOfSiteID, ret2.Content[0].UseOfSiteID);
                           Assert.Equal((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void UseOfSite_Controller_GetUseOfSiteWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    UseOfSiteController useOfSiteController = new UseOfSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(useOfSiteController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, useOfSiteController.DatabaseType);

                    UseOfSite useOfSiteFirst = new UseOfSite();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        UseOfSiteService useOfSiteService = new UseOfSiteService(new Query(), db, ContactID);
                        useOfSiteFirst = (from c in db.UseOfSites select c).FirstOrDefault();
                    }

                    // ok with UseOfSite info
                    IActionResult jsonRet = useOfSiteController.GetUseOfSiteWithID(useOfSiteFirst.UseOfSiteID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<UseOfSite> Ret = jsonRet as OkNegotiatedContentResult<UseOfSite>;
                    UseOfSite useOfSiteRet = Ret.Content;
                    Assert.Equal(useOfSiteFirst.UseOfSiteID, useOfSiteRet.UseOfSiteID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = useOfSiteController.GetUseOfSiteWithID(0);
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<UseOfSite> useOfSiteRet2 = jsonRet2 as OkNegotiatedContentResult<UseOfSite>;
                    Assert.Null(useOfSiteRet2);

                    NotFoundObjectResult notFoundRequest = jsonRet2 as NotFoundObjectResult;
                    Assert.NotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void UseOfSite_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    UseOfSiteController useOfSiteController = new UseOfSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(useOfSiteController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, useOfSiteController.DatabaseType);

                    UseOfSite useOfSiteLast = new UseOfSite();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        UseOfSiteService useOfSiteService = new UseOfSiteService(query, db, ContactID);
                        useOfSiteLast = (from c in db.UseOfSites select c).FirstOrDefault();
                    }

                    // ok with UseOfSite info
                    IActionResult jsonRet = useOfSiteController.GetUseOfSiteWithID(useOfSiteLast.UseOfSiteID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<UseOfSite> Ret = jsonRet as OkNegotiatedContentResult<UseOfSite>;
                    UseOfSite useOfSiteRet = Ret.Content;
                    Assert.Equal(useOfSiteLast.UseOfSiteID, useOfSiteRet.UseOfSiteID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because UseOfSiteID exist
                    IActionResult jsonRet2 = useOfSiteController.Post(useOfSiteRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<UseOfSite> useOfSiteRet2 = jsonRet2 as OkNegotiatedContentResult<UseOfSite>;
                    Assert.Null(useOfSiteRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added UseOfSite
                    useOfSiteRet.UseOfSiteID = 0;
                    useOfSiteController.Request = new System.Net.Http.HttpRequestMessage();
                    useOfSiteController.Request.RequestUri = new System.Uri("http://localhost:5000/api/useOfSite");
                    IActionResult jsonRet3 = useOfSiteController.Post(useOfSiteRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<UseOfSite> useOfSiteRet3 = jsonRet3 as CreatedNegotiatedContentResult<UseOfSite>;
                    Assert.NotNull(useOfSiteRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = useOfSiteController.Delete(useOfSiteRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<UseOfSite> useOfSiteRet4 = jsonRet4 as OkNegotiatedContentResult<UseOfSite>;
                    Assert.NotNull(useOfSiteRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [Fact]
        public void UseOfSite_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    UseOfSiteController useOfSiteController = new UseOfSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(useOfSiteController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, useOfSiteController.DatabaseType);

                    UseOfSite useOfSiteLast = new UseOfSite();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        UseOfSiteService useOfSiteService = new UseOfSiteService(query, db, ContactID);
                        useOfSiteLast = (from c in db.UseOfSites select c).FirstOrDefault();
                    }

                    // ok with UseOfSite info
                    IActionResult jsonRet = useOfSiteController.GetUseOfSiteWithID(useOfSiteLast.UseOfSiteID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<UseOfSite> Ret = jsonRet as OkNegotiatedContentResult<UseOfSite>;
                    UseOfSite useOfSiteRet = Ret.Content;
                    Assert.Equal(useOfSiteLast.UseOfSiteID, useOfSiteRet.UseOfSiteID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = useOfSiteController.Put(useOfSiteRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<UseOfSite> useOfSiteRet2 = jsonRet2 as OkNegotiatedContentResult<UseOfSite>;
                    Assert.NotNull(useOfSiteRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because UseOfSiteID of 0 does not exist
                    useOfSiteRet.UseOfSiteID = 0;
                    IActionResult jsonRet3 = useOfSiteController.Put(useOfSiteRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    OkNegotiatedContentResult<UseOfSite> useOfSiteRet3 = jsonRet3 as OkNegotiatedContentResult<UseOfSite>;
                    Assert.Null(useOfSiteRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void UseOfSite_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    UseOfSiteController useOfSiteController = new UseOfSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(useOfSiteController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, useOfSiteController.DatabaseType);

                    UseOfSite useOfSiteLast = new UseOfSite();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        UseOfSiteService useOfSiteService = new UseOfSiteService(query, db, ContactID);
                        useOfSiteLast = (from c in db.UseOfSites select c).FirstOrDefault();
                    }

                    // ok with UseOfSite info
                    IActionResult jsonRet = useOfSiteController.GetUseOfSiteWithID(useOfSiteLast.UseOfSiteID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<UseOfSite> Ret = jsonRet as OkNegotiatedContentResult<UseOfSite>;
                    UseOfSite useOfSiteRet = Ret.Content;
                    Assert.Equal(useOfSiteLast.UseOfSiteID, useOfSiteRet.UseOfSiteID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return newly added UseOfSite
                    useOfSiteRet.UseOfSiteID = 0;
                    useOfSiteController.Request = new System.Net.Http.HttpRequestMessage();
                    useOfSiteController.Request.RequestUri = new System.Uri("http://localhost:5000/api/useOfSite");
                    IActionResult jsonRet3 = useOfSiteController.Post(useOfSiteRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<UseOfSite> useOfSiteRet3 = jsonRet3 as CreatedNegotiatedContentResult<UseOfSite>;
                    Assert.NotNull(useOfSiteRet3);
                    UseOfSite useOfSite = useOfSiteRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = useOfSiteController.Delete(useOfSiteRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<UseOfSite> useOfSiteRet2 = jsonRet2 as OkNegotiatedContentResult<UseOfSite>;
                    Assert.NotNull(useOfSiteRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because UseOfSiteID of 0 does not exist
                    useOfSiteRet.UseOfSiteID = 0;
                    IActionResult jsonRet4 = useOfSiteController.Delete(useOfSiteRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<UseOfSite> useOfSiteRet4 = jsonRet4 as OkNegotiatedContentResult<UseOfSite>;
                    Assert.Null(useOfSiteRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
