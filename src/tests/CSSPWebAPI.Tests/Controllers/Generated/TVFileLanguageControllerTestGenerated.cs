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
    public partial class TVFileLanguageControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TVFileLanguageControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void TVFileLanguage_Controller_GetTVFileLanguageList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVFileLanguageController tvFileLanguageController = new TVFileLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tvFileLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tvFileLanguageController.DatabaseType);

                    TVFileLanguage tvFileLanguageFirst = new TVFileLanguage();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        TVFileLanguageService tvFileLanguageService = new TVFileLanguageService(query, db, ContactID);
                        tvFileLanguageFirst = (from c in db.TVFileLanguages select c).FirstOrDefault();
                        count = (from c in db.TVFileLanguages select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with TVFileLanguage info
                    IHttpActionResult jsonRet = tvFileLanguageController.GetTVFileLanguageList();
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<List<TVFileLanguage>> ret = jsonRet as OkNegotiatedContentResult<List<TVFileLanguage>>;
                    Assert.Equal(tvFileLanguageFirst.TVFileLanguageID, ret.Content[0].TVFileLanguageID);
                    Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<TVFileLanguage> tvFileLanguageList = new List<TVFileLanguage>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        TVFileLanguageService tvFileLanguageService = new TVFileLanguageService(query, db, ContactID);
                        tvFileLanguageList = (from c in db.TVFileLanguages select c).OrderBy(c => c.TVFileLanguageID).Skip(0).Take(2).ToList();
                        count = (from c in db.TVFileLanguages select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with TVFileLanguage info
                        jsonRet = tvFileLanguageController.GetTVFileLanguageList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.NotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<TVFileLanguage>>;
                        Assert.Equal(tvFileLanguageList[0].TVFileLanguageID, ret.Content[0].TVFileLanguageID);
                        Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with TVFileLanguage info
                           IHttpActionResult jsonRet2 = tvFileLanguageController.GetTVFileLanguageList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkNegotiatedContentResult<List<TVFileLanguage>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<TVFileLanguage>>;
                           Assert.Equal(tvFileLanguageList[1].TVFileLanguageID, ret2.Content[0].TVFileLanguageID);
                           Assert.Equal((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void TVFileLanguage_Controller_GetTVFileLanguageWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVFileLanguageController tvFileLanguageController = new TVFileLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tvFileLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tvFileLanguageController.DatabaseType);

                    TVFileLanguage tvFileLanguageFirst = new TVFileLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        TVFileLanguageService tvFileLanguageService = new TVFileLanguageService(new Query(), db, ContactID);
                        tvFileLanguageFirst = (from c in db.TVFileLanguages select c).FirstOrDefault();
                    }

                    // ok with TVFileLanguage info
                    IHttpActionResult jsonRet = tvFileLanguageController.GetTVFileLanguageWithID(tvFileLanguageFirst.TVFileLanguageID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<TVFileLanguage> Ret = jsonRet as OkNegotiatedContentResult<TVFileLanguage>;
                    TVFileLanguage tvFileLanguageRet = Ret.Content;
                    Assert.Equal(tvFileLanguageFirst.TVFileLanguageID, tvFileLanguageRet.TVFileLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = tvFileLanguageController.GetTVFileLanguageWithID(0);
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<TVFileLanguage> tvFileLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<TVFileLanguage>;
                    Assert.IsNull(tvFileLanguageRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.NotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void TVFileLanguage_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVFileLanguageController tvFileLanguageController = new TVFileLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tvFileLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tvFileLanguageController.DatabaseType);

                    TVFileLanguage tvFileLanguageLast = new TVFileLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        TVFileLanguageService tvFileLanguageService = new TVFileLanguageService(query, db, ContactID);
                        tvFileLanguageLast = (from c in db.TVFileLanguages select c).FirstOrDefault();
                    }

                    // ok with TVFileLanguage info
                    IHttpActionResult jsonRet = tvFileLanguageController.GetTVFileLanguageWithID(tvFileLanguageLast.TVFileLanguageID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<TVFileLanguage> Ret = jsonRet as OkNegotiatedContentResult<TVFileLanguage>;
                    TVFileLanguage tvFileLanguageRet = Ret.Content;
                    Assert.Equal(tvFileLanguageLast.TVFileLanguageID, tvFileLanguageRet.TVFileLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because TVFileLanguageID exist
                    IHttpActionResult jsonRet2 = tvFileLanguageController.Post(tvFileLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<TVFileLanguage> tvFileLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<TVFileLanguage>;
                    Assert.IsNull(tvFileLanguageRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added TVFileLanguage
                    tvFileLanguageRet.TVFileLanguageID = 0;
                    tvFileLanguageController.Request = new System.Net.Http.HttpRequestMessage();
                    tvFileLanguageController.Request.RequestUri = new System.Uri("http://localhost:5000/api/tvFileLanguage");
                    IHttpActionResult jsonRet3 = tvFileLanguageController.Post(tvFileLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<TVFileLanguage> tvFileLanguageRet3 = jsonRet3 as CreatedNegotiatedContentResult<TVFileLanguage>;
                    Assert.NotNull(tvFileLanguageRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = tvFileLanguageController.Delete(tvFileLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<TVFileLanguage> tvFileLanguageRet4 = jsonRet4 as OkNegotiatedContentResult<TVFileLanguage>;
                    Assert.NotNull(tvFileLanguageRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [Fact]
        public void TVFileLanguage_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVFileLanguageController tvFileLanguageController = new TVFileLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tvFileLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tvFileLanguageController.DatabaseType);

                    TVFileLanguage tvFileLanguageLast = new TVFileLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        TVFileLanguageService tvFileLanguageService = new TVFileLanguageService(query, db, ContactID);
                        tvFileLanguageLast = (from c in db.TVFileLanguages select c).FirstOrDefault();
                    }

                    // ok with TVFileLanguage info
                    IHttpActionResult jsonRet = tvFileLanguageController.GetTVFileLanguageWithID(tvFileLanguageLast.TVFileLanguageID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<TVFileLanguage> Ret = jsonRet as OkNegotiatedContentResult<TVFileLanguage>;
                    TVFileLanguage tvFileLanguageRet = Ret.Content;
                    Assert.Equal(tvFileLanguageLast.TVFileLanguageID, tvFileLanguageRet.TVFileLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = tvFileLanguageController.Put(tvFileLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<TVFileLanguage> tvFileLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<TVFileLanguage>;
                    Assert.NotNull(tvFileLanguageRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because TVFileLanguageID of 0 does not exist
                    tvFileLanguageRet.TVFileLanguageID = 0;
                    IHttpActionResult jsonRet3 = tvFileLanguageController.Put(tvFileLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    OkNegotiatedContentResult<TVFileLanguage> tvFileLanguageRet3 = jsonRet3 as OkNegotiatedContentResult<TVFileLanguage>;
                    Assert.IsNull(tvFileLanguageRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void TVFileLanguage_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVFileLanguageController tvFileLanguageController = new TVFileLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tvFileLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tvFileLanguageController.DatabaseType);

                    TVFileLanguage tvFileLanguageLast = new TVFileLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        TVFileLanguageService tvFileLanguageService = new TVFileLanguageService(query, db, ContactID);
                        tvFileLanguageLast = (from c in db.TVFileLanguages select c).FirstOrDefault();
                    }

                    // ok with TVFileLanguage info
                    IHttpActionResult jsonRet = tvFileLanguageController.GetTVFileLanguageWithID(tvFileLanguageLast.TVFileLanguageID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<TVFileLanguage> Ret = jsonRet as OkNegotiatedContentResult<TVFileLanguage>;
                    TVFileLanguage tvFileLanguageRet = Ret.Content;
                    Assert.Equal(tvFileLanguageLast.TVFileLanguageID, tvFileLanguageRet.TVFileLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added TVFileLanguage
                    tvFileLanguageRet.TVFileLanguageID = 0;
                    tvFileLanguageController.Request = new System.Net.Http.HttpRequestMessage();
                    tvFileLanguageController.Request.RequestUri = new System.Uri("http://localhost:5000/api/tvFileLanguage");
                    IHttpActionResult jsonRet3 = tvFileLanguageController.Post(tvFileLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<TVFileLanguage> tvFileLanguageRet3 = jsonRet3 as CreatedNegotiatedContentResult<TVFileLanguage>;
                    Assert.NotNull(tvFileLanguageRet3);
                    TVFileLanguage tvFileLanguage = tvFileLanguageRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = tvFileLanguageController.Delete(tvFileLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<TVFileLanguage> tvFileLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<TVFileLanguage>;
                    Assert.NotNull(tvFileLanguageRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because TVFileLanguageID of 0 does not exist
                    tvFileLanguageRet.TVFileLanguageID = 0;
                    IHttpActionResult jsonRet4 = tvFileLanguageController.Delete(tvFileLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<TVFileLanguage> tvFileLanguageRet4 = jsonRet4 as OkNegotiatedContentResult<TVFileLanguage>;
                    Assert.IsNull(tvFileLanguageRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
