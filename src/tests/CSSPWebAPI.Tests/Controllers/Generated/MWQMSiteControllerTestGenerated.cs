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
    public partial class MWQMSiteControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MWQMSiteControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void MWQMSite_Controller_GetMWQMSiteList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMSiteController mwqmSiteController = new MWQMSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mwqmSiteController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mwqmSiteController.DatabaseType);

                    MWQMSite mwqmSiteFirst = new MWQMSite();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        MWQMSiteService mwqmSiteService = new MWQMSiteService(query, db, ContactID);
                        mwqmSiteFirst = (from c in db.MWQMSites select c).FirstOrDefault();
                        count = (from c in db.MWQMSites select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with MWQMSite info
                    IHttpActionResult jsonRet = mwqmSiteController.GetMWQMSiteList();
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<List<MWQMSite>> ret = jsonRet as OkNegotiatedContentResult<List<MWQMSite>>;
                    Assert.Equal(mwqmSiteFirst.MWQMSiteID, ret.Content[0].MWQMSiteID);
                    Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<MWQMSite> mwqmSiteList = new List<MWQMSite>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        MWQMSiteService mwqmSiteService = new MWQMSiteService(query, db, ContactID);
                        mwqmSiteList = (from c in db.MWQMSites select c).OrderBy(c => c.MWQMSiteID).Skip(0).Take(2).ToList();
                        count = (from c in db.MWQMSites select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with MWQMSite info
                        jsonRet = mwqmSiteController.GetMWQMSiteList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.NotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<MWQMSite>>;
                        Assert.Equal(mwqmSiteList[0].MWQMSiteID, ret.Content[0].MWQMSiteID);
                        Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with MWQMSite info
                           IHttpActionResult jsonRet2 = mwqmSiteController.GetMWQMSiteList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkNegotiatedContentResult<List<MWQMSite>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<MWQMSite>>;
                           Assert.Equal(mwqmSiteList[1].MWQMSiteID, ret2.Content[0].MWQMSiteID);
                           Assert.Equal((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void MWQMSite_Controller_GetMWQMSiteWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMSiteController mwqmSiteController = new MWQMSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mwqmSiteController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mwqmSiteController.DatabaseType);

                    MWQMSite mwqmSiteFirst = new MWQMSite();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        MWQMSiteService mwqmSiteService = new MWQMSiteService(new Query(), db, ContactID);
                        mwqmSiteFirst = (from c in db.MWQMSites select c).FirstOrDefault();
                    }

                    // ok with MWQMSite info
                    IHttpActionResult jsonRet = mwqmSiteController.GetMWQMSiteWithID(mwqmSiteFirst.MWQMSiteID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<MWQMSite> Ret = jsonRet as OkNegotiatedContentResult<MWQMSite>;
                    MWQMSite mwqmSiteRet = Ret.Content;
                    Assert.Equal(mwqmSiteFirst.MWQMSiteID, mwqmSiteRet.MWQMSiteID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = mwqmSiteController.GetMWQMSiteWithID(0);
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<MWQMSite> mwqmSiteRet2 = jsonRet2 as OkNegotiatedContentResult<MWQMSite>;
                    Assert.IsNull(mwqmSiteRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.NotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void MWQMSite_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMSiteController mwqmSiteController = new MWQMSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mwqmSiteController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mwqmSiteController.DatabaseType);

                    MWQMSite mwqmSiteLast = new MWQMSite();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MWQMSiteService mwqmSiteService = new MWQMSiteService(query, db, ContactID);
                        mwqmSiteLast = (from c in db.MWQMSites select c).FirstOrDefault();
                    }

                    // ok with MWQMSite info
                    IHttpActionResult jsonRet = mwqmSiteController.GetMWQMSiteWithID(mwqmSiteLast.MWQMSiteID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<MWQMSite> Ret = jsonRet as OkNegotiatedContentResult<MWQMSite>;
                    MWQMSite mwqmSiteRet = Ret.Content;
                    Assert.Equal(mwqmSiteLast.MWQMSiteID, mwqmSiteRet.MWQMSiteID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because MWQMSiteID exist
                    IHttpActionResult jsonRet2 = mwqmSiteController.Post(mwqmSiteRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<MWQMSite> mwqmSiteRet2 = jsonRet2 as OkNegotiatedContentResult<MWQMSite>;
                    Assert.IsNull(mwqmSiteRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added MWQMSite
                    mwqmSiteRet.MWQMSiteID = 0;
                    mwqmSiteController.Request = new System.Net.Http.HttpRequestMessage();
                    mwqmSiteController.Request.RequestUri = new System.Uri("http://localhost:5000/api/mwqmSite");
                    IHttpActionResult jsonRet3 = mwqmSiteController.Post(mwqmSiteRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<MWQMSite> mwqmSiteRet3 = jsonRet3 as CreatedNegotiatedContentResult<MWQMSite>;
                    Assert.NotNull(mwqmSiteRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = mwqmSiteController.Delete(mwqmSiteRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<MWQMSite> mwqmSiteRet4 = jsonRet4 as OkNegotiatedContentResult<MWQMSite>;
                    Assert.NotNull(mwqmSiteRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [Fact]
        public void MWQMSite_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMSiteController mwqmSiteController = new MWQMSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mwqmSiteController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mwqmSiteController.DatabaseType);

                    MWQMSite mwqmSiteLast = new MWQMSite();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        MWQMSiteService mwqmSiteService = new MWQMSiteService(query, db, ContactID);
                        mwqmSiteLast = (from c in db.MWQMSites select c).FirstOrDefault();
                    }

                    // ok with MWQMSite info
                    IHttpActionResult jsonRet = mwqmSiteController.GetMWQMSiteWithID(mwqmSiteLast.MWQMSiteID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<MWQMSite> Ret = jsonRet as OkNegotiatedContentResult<MWQMSite>;
                    MWQMSite mwqmSiteRet = Ret.Content;
                    Assert.Equal(mwqmSiteLast.MWQMSiteID, mwqmSiteRet.MWQMSiteID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = mwqmSiteController.Put(mwqmSiteRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<MWQMSite> mwqmSiteRet2 = jsonRet2 as OkNegotiatedContentResult<MWQMSite>;
                    Assert.NotNull(mwqmSiteRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because MWQMSiteID of 0 does not exist
                    mwqmSiteRet.MWQMSiteID = 0;
                    IHttpActionResult jsonRet3 = mwqmSiteController.Put(mwqmSiteRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    OkNegotiatedContentResult<MWQMSite> mwqmSiteRet3 = jsonRet3 as OkNegotiatedContentResult<MWQMSite>;
                    Assert.IsNull(mwqmSiteRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void MWQMSite_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMSiteController mwqmSiteController = new MWQMSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mwqmSiteController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mwqmSiteController.DatabaseType);

                    MWQMSite mwqmSiteLast = new MWQMSite();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MWQMSiteService mwqmSiteService = new MWQMSiteService(query, db, ContactID);
                        mwqmSiteLast = (from c in db.MWQMSites select c).FirstOrDefault();
                    }

                    // ok with MWQMSite info
                    IHttpActionResult jsonRet = mwqmSiteController.GetMWQMSiteWithID(mwqmSiteLast.MWQMSiteID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<MWQMSite> Ret = jsonRet as OkNegotiatedContentResult<MWQMSite>;
                    MWQMSite mwqmSiteRet = Ret.Content;
                    Assert.Equal(mwqmSiteLast.MWQMSiteID, mwqmSiteRet.MWQMSiteID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added MWQMSite
                    mwqmSiteRet.MWQMSiteID = 0;
                    mwqmSiteController.Request = new System.Net.Http.HttpRequestMessage();
                    mwqmSiteController.Request.RequestUri = new System.Uri("http://localhost:5000/api/mwqmSite");
                    IHttpActionResult jsonRet3 = mwqmSiteController.Post(mwqmSiteRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<MWQMSite> mwqmSiteRet3 = jsonRet3 as CreatedNegotiatedContentResult<MWQMSite>;
                    Assert.NotNull(mwqmSiteRet3);
                    MWQMSite mwqmSite = mwqmSiteRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = mwqmSiteController.Delete(mwqmSiteRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<MWQMSite> mwqmSiteRet2 = jsonRet2 as OkNegotiatedContentResult<MWQMSite>;
                    Assert.NotNull(mwqmSiteRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because MWQMSiteID of 0 does not exist
                    mwqmSiteRet.MWQMSiteID = 0;
                    IHttpActionResult jsonRet4 = mwqmSiteController.Delete(mwqmSiteRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<MWQMSite> mwqmSiteRet4 = jsonRet4 as OkNegotiatedContentResult<MWQMSite>;
                    Assert.IsNull(mwqmSiteRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
