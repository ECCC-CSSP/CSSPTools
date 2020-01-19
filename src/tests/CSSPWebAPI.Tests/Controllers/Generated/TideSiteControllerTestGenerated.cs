using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Xunit;
using CSSPWebAPI.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;

namespace CSSPWebAPI.Tests.Controllers
{
    public partial class TideSiteControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TideSiteControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void TideSite_Controller_GetTideSiteList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TideSiteController tideSiteController = new TideSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tideSiteController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tideSiteController.DatabaseType);

                    TideSite tideSiteFirst = new TideSite();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        TideSiteService tideSiteService = new TideSiteService(query, db, ContactID);
                        tideSiteFirst = (from c in db.TideSites select c).FirstOrDefault();
                        count = (from c in db.TideSites select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with TideSite info
                    IHttpActionResult jsonRet = tideSiteController.GetTideSiteList();
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<List<TideSite>> ret = jsonRet as OkNegotiatedContentResult<List<TideSite>>;
                    Assert.Equal(tideSiteFirst.TideSiteID, ret.Content[0].TideSiteID);
                    Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<TideSite> tideSiteList = new List<TideSite>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        TideSiteService tideSiteService = new TideSiteService(query, db, ContactID);
                        tideSiteList = (from c in db.TideSites select c).OrderBy(c => c.TideSiteID).Skip(0).Take(2).ToList();
                        count = (from c in db.TideSites select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with TideSite info
                        jsonRet = tideSiteController.GetTideSiteList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.NotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<TideSite>>;
                        Assert.Equal(tideSiteList[0].TideSiteID, ret.Content[0].TideSiteID);
                        Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with TideSite info
                           IHttpActionResult jsonRet2 = tideSiteController.GetTideSiteList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkNegotiatedContentResult<List<TideSite>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<TideSite>>;
                           Assert.Equal(tideSiteList[1].TideSiteID, ret2.Content[0].TideSiteID);
                           Assert.Equal((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void TideSite_Controller_GetTideSiteWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TideSiteController tideSiteController = new TideSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tideSiteController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tideSiteController.DatabaseType);

                    TideSite tideSiteFirst = new TideSite();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        TideSiteService tideSiteService = new TideSiteService(new Query(), db, ContactID);
                        tideSiteFirst = (from c in db.TideSites select c).FirstOrDefault();
                    }

                    // ok with TideSite info
                    IHttpActionResult jsonRet = tideSiteController.GetTideSiteWithID(tideSiteFirst.TideSiteID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<TideSite> Ret = jsonRet as OkNegotiatedContentResult<TideSite>;
                    TideSite tideSiteRet = Ret.Content;
                    Assert.Equal(tideSiteFirst.TideSiteID, tideSiteRet.TideSiteID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = tideSiteController.GetTideSiteWithID(0);
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<TideSite> tideSiteRet2 = jsonRet2 as OkNegotiatedContentResult<TideSite>;
                    Assert.IsNull(tideSiteRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.NotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void TideSite_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TideSiteController tideSiteController = new TideSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tideSiteController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tideSiteController.DatabaseType);

                    TideSite tideSiteLast = new TideSite();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        TideSiteService tideSiteService = new TideSiteService(query, db, ContactID);
                        tideSiteLast = (from c in db.TideSites select c).FirstOrDefault();
                    }

                    // ok with TideSite info
                    IHttpActionResult jsonRet = tideSiteController.GetTideSiteWithID(tideSiteLast.TideSiteID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<TideSite> Ret = jsonRet as OkNegotiatedContentResult<TideSite>;
                    TideSite tideSiteRet = Ret.Content;
                    Assert.Equal(tideSiteLast.TideSiteID, tideSiteRet.TideSiteID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because TideSiteID exist
                    IHttpActionResult jsonRet2 = tideSiteController.Post(tideSiteRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<TideSite> tideSiteRet2 = jsonRet2 as OkNegotiatedContentResult<TideSite>;
                    Assert.IsNull(tideSiteRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added TideSite
                    tideSiteRet.TideSiteID = 0;
                    tideSiteController.Request = new System.Net.Http.HttpRequestMessage();
                    tideSiteController.Request.RequestUri = new System.Uri("http://localhost:5000/api/tideSite");
                    IHttpActionResult jsonRet3 = tideSiteController.Post(tideSiteRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<TideSite> tideSiteRet3 = jsonRet3 as CreatedNegotiatedContentResult<TideSite>;
                    Assert.NotNull(tideSiteRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = tideSiteController.Delete(tideSiteRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<TideSite> tideSiteRet4 = jsonRet4 as OkNegotiatedContentResult<TideSite>;
                    Assert.NotNull(tideSiteRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [Fact]
        public void TideSite_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TideSiteController tideSiteController = new TideSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tideSiteController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tideSiteController.DatabaseType);

                    TideSite tideSiteLast = new TideSite();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        TideSiteService tideSiteService = new TideSiteService(query, db, ContactID);
                        tideSiteLast = (from c in db.TideSites select c).FirstOrDefault();
                    }

                    // ok with TideSite info
                    IHttpActionResult jsonRet = tideSiteController.GetTideSiteWithID(tideSiteLast.TideSiteID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<TideSite> Ret = jsonRet as OkNegotiatedContentResult<TideSite>;
                    TideSite tideSiteRet = Ret.Content;
                    Assert.Equal(tideSiteLast.TideSiteID, tideSiteRet.TideSiteID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = tideSiteController.Put(tideSiteRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<TideSite> tideSiteRet2 = jsonRet2 as OkNegotiatedContentResult<TideSite>;
                    Assert.NotNull(tideSiteRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because TideSiteID of 0 does not exist
                    tideSiteRet.TideSiteID = 0;
                    IHttpActionResult jsonRet3 = tideSiteController.Put(tideSiteRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    OkNegotiatedContentResult<TideSite> tideSiteRet3 = jsonRet3 as OkNegotiatedContentResult<TideSite>;
                    Assert.IsNull(tideSiteRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void TideSite_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TideSiteController tideSiteController = new TideSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tideSiteController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tideSiteController.DatabaseType);

                    TideSite tideSiteLast = new TideSite();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        TideSiteService tideSiteService = new TideSiteService(query, db, ContactID);
                        tideSiteLast = (from c in db.TideSites select c).FirstOrDefault();
                    }

                    // ok with TideSite info
                    IHttpActionResult jsonRet = tideSiteController.GetTideSiteWithID(tideSiteLast.TideSiteID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<TideSite> Ret = jsonRet as OkNegotiatedContentResult<TideSite>;
                    TideSite tideSiteRet = Ret.Content;
                    Assert.Equal(tideSiteLast.TideSiteID, tideSiteRet.TideSiteID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added TideSite
                    tideSiteRet.TideSiteID = 0;
                    tideSiteController.Request = new System.Net.Http.HttpRequestMessage();
                    tideSiteController.Request.RequestUri = new System.Uri("http://localhost:5000/api/tideSite");
                    IHttpActionResult jsonRet3 = tideSiteController.Post(tideSiteRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<TideSite> tideSiteRet3 = jsonRet3 as CreatedNegotiatedContentResult<TideSite>;
                    Assert.NotNull(tideSiteRet3);
                    TideSite tideSite = tideSiteRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = tideSiteController.Delete(tideSiteRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<TideSite> tideSiteRet2 = jsonRet2 as OkNegotiatedContentResult<TideSite>;
                    Assert.NotNull(tideSiteRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because TideSiteID of 0 does not exist
                    tideSiteRet.TideSiteID = 0;
                    IHttpActionResult jsonRet4 = tideSiteController.Delete(tideSiteRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<TideSite> tideSiteRet4 = jsonRet4 as OkNegotiatedContentResult<TideSite>;
                    Assert.IsNull(tideSiteRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
