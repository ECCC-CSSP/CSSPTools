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
    public partial class TVItemLanguageControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TVItemLanguageControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void TVItemLanguage_Controller_GetTVItemLanguageList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVItemLanguageController tvItemLanguageController = new TVItemLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tvItemLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tvItemLanguageController.DatabaseType);

                    TVItemLanguage tvItemLanguageFirst = new TVItemLanguage();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        TVItemLanguageService tvItemLanguageService = new TVItemLanguageService(query, db, ContactID);
                        tvItemLanguageFirst = (from c in db.TVItemLanguages select c).FirstOrDefault();
                        count = (from c in db.TVItemLanguages select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with TVItemLanguage info
                    IHttpActionResult jsonRet = tvItemLanguageController.GetTVItemLanguageList();
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<List<TVItemLanguage>> ret = jsonRet as OkNegotiatedContentResult<List<TVItemLanguage>>;
                    Assert.Equal(tvItemLanguageFirst.TVItemLanguageID, ret.Content[0].TVItemLanguageID);
                    Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<TVItemLanguage> tvItemLanguageList = new List<TVItemLanguage>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        TVItemLanguageService tvItemLanguageService = new TVItemLanguageService(query, db, ContactID);
                        tvItemLanguageList = (from c in db.TVItemLanguages select c).OrderBy(c => c.TVItemLanguageID).Skip(0).Take(2).ToList();
                        count = (from c in db.TVItemLanguages select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with TVItemLanguage info
                        jsonRet = tvItemLanguageController.GetTVItemLanguageList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.NotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<TVItemLanguage>>;
                        Assert.Equal(tvItemLanguageList[0].TVItemLanguageID, ret.Content[0].TVItemLanguageID);
                        Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with TVItemLanguage info
                           IHttpActionResult jsonRet2 = tvItemLanguageController.GetTVItemLanguageList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkNegotiatedContentResult<List<TVItemLanguage>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<TVItemLanguage>>;
                           Assert.Equal(tvItemLanguageList[1].TVItemLanguageID, ret2.Content[0].TVItemLanguageID);
                           Assert.Equal((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void TVItemLanguage_Controller_GetTVItemLanguageWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVItemLanguageController tvItemLanguageController = new TVItemLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tvItemLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tvItemLanguageController.DatabaseType);

                    TVItemLanguage tvItemLanguageFirst = new TVItemLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        TVItemLanguageService tvItemLanguageService = new TVItemLanguageService(new Query(), db, ContactID);
                        tvItemLanguageFirst = (from c in db.TVItemLanguages select c).FirstOrDefault();
                    }

                    // ok with TVItemLanguage info
                    IHttpActionResult jsonRet = tvItemLanguageController.GetTVItemLanguageWithID(tvItemLanguageFirst.TVItemLanguageID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<TVItemLanguage> Ret = jsonRet as OkNegotiatedContentResult<TVItemLanguage>;
                    TVItemLanguage tvItemLanguageRet = Ret.Content;
                    Assert.Equal(tvItemLanguageFirst.TVItemLanguageID, tvItemLanguageRet.TVItemLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = tvItemLanguageController.GetTVItemLanguageWithID(0);
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<TVItemLanguage> tvItemLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<TVItemLanguage>;
                    Assert.IsNull(tvItemLanguageRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.NotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void TVItemLanguage_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVItemLanguageController tvItemLanguageController = new TVItemLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tvItemLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tvItemLanguageController.DatabaseType);

                    TVItemLanguage tvItemLanguageLast = new TVItemLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        TVItemLanguageService tvItemLanguageService = new TVItemLanguageService(query, db, ContactID);
                        tvItemLanguageLast = (from c in db.TVItemLanguages select c).FirstOrDefault();
                    }

                    // ok with TVItemLanguage info
                    IHttpActionResult jsonRet = tvItemLanguageController.GetTVItemLanguageWithID(tvItemLanguageLast.TVItemLanguageID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<TVItemLanguage> Ret = jsonRet as OkNegotiatedContentResult<TVItemLanguage>;
                    TVItemLanguage tvItemLanguageRet = Ret.Content;
                    Assert.Equal(tvItemLanguageLast.TVItemLanguageID, tvItemLanguageRet.TVItemLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because TVItemLanguageID exist
                    IHttpActionResult jsonRet2 = tvItemLanguageController.Post(tvItemLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<TVItemLanguage> tvItemLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<TVItemLanguage>;
                    Assert.IsNull(tvItemLanguageRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added TVItemLanguage
                    tvItemLanguageRet.TVItemLanguageID = 0;
                    tvItemLanguageController.Request = new System.Net.Http.HttpRequestMessage();
                    tvItemLanguageController.Request.RequestUri = new System.Uri("http://localhost:5000/api/tvItemLanguage");
                    IHttpActionResult jsonRet3 = tvItemLanguageController.Post(tvItemLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<TVItemLanguage> tvItemLanguageRet3 = jsonRet3 as CreatedNegotiatedContentResult<TVItemLanguage>;
                    Assert.NotNull(tvItemLanguageRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = tvItemLanguageController.Delete(tvItemLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<TVItemLanguage> tvItemLanguageRet4 = jsonRet4 as OkNegotiatedContentResult<TVItemLanguage>;
                    Assert.NotNull(tvItemLanguageRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [Fact]
        public void TVItemLanguage_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVItemLanguageController tvItemLanguageController = new TVItemLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tvItemLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tvItemLanguageController.DatabaseType);

                    TVItemLanguage tvItemLanguageLast = new TVItemLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        TVItemLanguageService tvItemLanguageService = new TVItemLanguageService(query, db, ContactID);
                        tvItemLanguageLast = (from c in db.TVItemLanguages select c).FirstOrDefault();
                    }

                    // ok with TVItemLanguage info
                    IHttpActionResult jsonRet = tvItemLanguageController.GetTVItemLanguageWithID(tvItemLanguageLast.TVItemLanguageID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<TVItemLanguage> Ret = jsonRet as OkNegotiatedContentResult<TVItemLanguage>;
                    TVItemLanguage tvItemLanguageRet = Ret.Content;
                    Assert.Equal(tvItemLanguageLast.TVItemLanguageID, tvItemLanguageRet.TVItemLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = tvItemLanguageController.Put(tvItemLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<TVItemLanguage> tvItemLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<TVItemLanguage>;
                    Assert.NotNull(tvItemLanguageRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because TVItemLanguageID of 0 does not exist
                    tvItemLanguageRet.TVItemLanguageID = 0;
                    IHttpActionResult jsonRet3 = tvItemLanguageController.Put(tvItemLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    OkNegotiatedContentResult<TVItemLanguage> tvItemLanguageRet3 = jsonRet3 as OkNegotiatedContentResult<TVItemLanguage>;
                    Assert.IsNull(tvItemLanguageRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void TVItemLanguage_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVItemLanguageController tvItemLanguageController = new TVItemLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tvItemLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tvItemLanguageController.DatabaseType);

                    TVItemLanguage tvItemLanguageLast = new TVItemLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        TVItemLanguageService tvItemLanguageService = new TVItemLanguageService(query, db, ContactID);
                        tvItemLanguageLast = (from c in db.TVItemLanguages select c).FirstOrDefault();
                    }

                    // ok with TVItemLanguage info
                    IHttpActionResult jsonRet = tvItemLanguageController.GetTVItemLanguageWithID(tvItemLanguageLast.TVItemLanguageID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<TVItemLanguage> Ret = jsonRet as OkNegotiatedContentResult<TVItemLanguage>;
                    TVItemLanguage tvItemLanguageRet = Ret.Content;
                    Assert.Equal(tvItemLanguageLast.TVItemLanguageID, tvItemLanguageRet.TVItemLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added TVItemLanguage
                    tvItemLanguageRet.TVItemLanguageID = 0;
                    tvItemLanguageController.Request = new System.Net.Http.HttpRequestMessage();
                    tvItemLanguageController.Request.RequestUri = new System.Uri("http://localhost:5000/api/tvItemLanguage");
                    IHttpActionResult jsonRet3 = tvItemLanguageController.Post(tvItemLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<TVItemLanguage> tvItemLanguageRet3 = jsonRet3 as CreatedNegotiatedContentResult<TVItemLanguage>;
                    Assert.NotNull(tvItemLanguageRet3);
                    TVItemLanguage tvItemLanguage = tvItemLanguageRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = tvItemLanguageController.Delete(tvItemLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<TVItemLanguage> tvItemLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<TVItemLanguage>;
                    Assert.NotNull(tvItemLanguageRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because TVItemLanguageID of 0 does not exist
                    tvItemLanguageRet.TVItemLanguageID = 0;
                    IHttpActionResult jsonRet4 = tvItemLanguageController.Delete(tvItemLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<TVItemLanguage> tvItemLanguageRet4 = jsonRet4 as OkNegotiatedContentResult<TVItemLanguage>;
                    Assert.IsNull(tvItemLanguageRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
