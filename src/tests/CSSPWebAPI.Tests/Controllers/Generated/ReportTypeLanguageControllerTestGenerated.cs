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
    public partial class ReportTypeLanguageControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ReportTypeLanguageControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void ReportTypeLanguage_Controller_GetReportTypeLanguageList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ReportTypeLanguageController reportTypeLanguageController = new ReportTypeLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(reportTypeLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, reportTypeLanguageController.DatabaseType);

                    ReportTypeLanguage reportTypeLanguageFirst = new ReportTypeLanguage();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        ReportTypeLanguageService reportTypeLanguageService = new ReportTypeLanguageService(query, db, ContactID);
                        reportTypeLanguageFirst = (from c in db.ReportTypeLanguages select c).FirstOrDefault();
                        count = (from c in db.ReportTypeLanguages select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with ReportTypeLanguage info
                    IHttpActionResult jsonRet = reportTypeLanguageController.GetReportTypeLanguageList();
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<List<ReportTypeLanguage>> ret = jsonRet as OkNegotiatedContentResult<List<ReportTypeLanguage>>;
                    Assert.Equal(reportTypeLanguageFirst.ReportTypeLanguageID, ret.Content[0].ReportTypeLanguageID);
                    Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<ReportTypeLanguage> reportTypeLanguageList = new List<ReportTypeLanguage>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        ReportTypeLanguageService reportTypeLanguageService = new ReportTypeLanguageService(query, db, ContactID);
                        reportTypeLanguageList = (from c in db.ReportTypeLanguages select c).OrderBy(c => c.ReportTypeLanguageID).Skip(0).Take(2).ToList();
                        count = (from c in db.ReportTypeLanguages select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with ReportTypeLanguage info
                        jsonRet = reportTypeLanguageController.GetReportTypeLanguageList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.NotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<ReportTypeLanguage>>;
                        Assert.Equal(reportTypeLanguageList[0].ReportTypeLanguageID, ret.Content[0].ReportTypeLanguageID);
                        Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with ReportTypeLanguage info
                           IHttpActionResult jsonRet2 = reportTypeLanguageController.GetReportTypeLanguageList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkNegotiatedContentResult<List<ReportTypeLanguage>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<ReportTypeLanguage>>;
                           Assert.Equal(reportTypeLanguageList[1].ReportTypeLanguageID, ret2.Content[0].ReportTypeLanguageID);
                           Assert.Equal((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void ReportTypeLanguage_Controller_GetReportTypeLanguageWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ReportTypeLanguageController reportTypeLanguageController = new ReportTypeLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(reportTypeLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, reportTypeLanguageController.DatabaseType);

                    ReportTypeLanguage reportTypeLanguageFirst = new ReportTypeLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        ReportTypeLanguageService reportTypeLanguageService = new ReportTypeLanguageService(new Query(), db, ContactID);
                        reportTypeLanguageFirst = (from c in db.ReportTypeLanguages select c).FirstOrDefault();
                    }

                    // ok with ReportTypeLanguage info
                    IHttpActionResult jsonRet = reportTypeLanguageController.GetReportTypeLanguageWithID(reportTypeLanguageFirst.ReportTypeLanguageID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<ReportTypeLanguage> Ret = jsonRet as OkNegotiatedContentResult<ReportTypeLanguage>;
                    ReportTypeLanguage reportTypeLanguageRet = Ret.Content;
                    Assert.Equal(reportTypeLanguageFirst.ReportTypeLanguageID, reportTypeLanguageRet.ReportTypeLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = reportTypeLanguageController.GetReportTypeLanguageWithID(0);
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<ReportTypeLanguage> reportTypeLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<ReportTypeLanguage>;
                    Assert.IsNull(reportTypeLanguageRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.NotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void ReportTypeLanguage_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ReportTypeLanguageController reportTypeLanguageController = new ReportTypeLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(reportTypeLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, reportTypeLanguageController.DatabaseType);

                    ReportTypeLanguage reportTypeLanguageLast = new ReportTypeLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        ReportTypeLanguageService reportTypeLanguageService = new ReportTypeLanguageService(query, db, ContactID);
                        reportTypeLanguageLast = (from c in db.ReportTypeLanguages select c).FirstOrDefault();
                    }

                    // ok with ReportTypeLanguage info
                    IHttpActionResult jsonRet = reportTypeLanguageController.GetReportTypeLanguageWithID(reportTypeLanguageLast.ReportTypeLanguageID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<ReportTypeLanguage> Ret = jsonRet as OkNegotiatedContentResult<ReportTypeLanguage>;
                    ReportTypeLanguage reportTypeLanguageRet = Ret.Content;
                    Assert.Equal(reportTypeLanguageLast.ReportTypeLanguageID, reportTypeLanguageRet.ReportTypeLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because ReportTypeLanguageID exist
                    IHttpActionResult jsonRet2 = reportTypeLanguageController.Post(reportTypeLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<ReportTypeLanguage> reportTypeLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<ReportTypeLanguage>;
                    Assert.IsNull(reportTypeLanguageRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added ReportTypeLanguage
                    reportTypeLanguageRet.ReportTypeLanguageID = 0;
                    reportTypeLanguageController.Request = new System.Net.Http.HttpRequestMessage();
                    reportTypeLanguageController.Request.RequestUri = new System.Uri("http://localhost:5000/api/reportTypeLanguage");
                    IHttpActionResult jsonRet3 = reportTypeLanguageController.Post(reportTypeLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<ReportTypeLanguage> reportTypeLanguageRet3 = jsonRet3 as CreatedNegotiatedContentResult<ReportTypeLanguage>;
                    Assert.NotNull(reportTypeLanguageRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = reportTypeLanguageController.Delete(reportTypeLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<ReportTypeLanguage> reportTypeLanguageRet4 = jsonRet4 as OkNegotiatedContentResult<ReportTypeLanguage>;
                    Assert.NotNull(reportTypeLanguageRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [Fact]
        public void ReportTypeLanguage_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ReportTypeLanguageController reportTypeLanguageController = new ReportTypeLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(reportTypeLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, reportTypeLanguageController.DatabaseType);

                    ReportTypeLanguage reportTypeLanguageLast = new ReportTypeLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        ReportTypeLanguageService reportTypeLanguageService = new ReportTypeLanguageService(query, db, ContactID);
                        reportTypeLanguageLast = (from c in db.ReportTypeLanguages select c).FirstOrDefault();
                    }

                    // ok with ReportTypeLanguage info
                    IHttpActionResult jsonRet = reportTypeLanguageController.GetReportTypeLanguageWithID(reportTypeLanguageLast.ReportTypeLanguageID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<ReportTypeLanguage> Ret = jsonRet as OkNegotiatedContentResult<ReportTypeLanguage>;
                    ReportTypeLanguage reportTypeLanguageRet = Ret.Content;
                    Assert.Equal(reportTypeLanguageLast.ReportTypeLanguageID, reportTypeLanguageRet.ReportTypeLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = reportTypeLanguageController.Put(reportTypeLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<ReportTypeLanguage> reportTypeLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<ReportTypeLanguage>;
                    Assert.NotNull(reportTypeLanguageRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because ReportTypeLanguageID of 0 does not exist
                    reportTypeLanguageRet.ReportTypeLanguageID = 0;
                    IHttpActionResult jsonRet3 = reportTypeLanguageController.Put(reportTypeLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    OkNegotiatedContentResult<ReportTypeLanguage> reportTypeLanguageRet3 = jsonRet3 as OkNegotiatedContentResult<ReportTypeLanguage>;
                    Assert.IsNull(reportTypeLanguageRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void ReportTypeLanguage_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ReportTypeLanguageController reportTypeLanguageController = new ReportTypeLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(reportTypeLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, reportTypeLanguageController.DatabaseType);

                    ReportTypeLanguage reportTypeLanguageLast = new ReportTypeLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        ReportTypeLanguageService reportTypeLanguageService = new ReportTypeLanguageService(query, db, ContactID);
                        reportTypeLanguageLast = (from c in db.ReportTypeLanguages select c).FirstOrDefault();
                    }

                    // ok with ReportTypeLanguage info
                    IHttpActionResult jsonRet = reportTypeLanguageController.GetReportTypeLanguageWithID(reportTypeLanguageLast.ReportTypeLanguageID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<ReportTypeLanguage> Ret = jsonRet as OkNegotiatedContentResult<ReportTypeLanguage>;
                    ReportTypeLanguage reportTypeLanguageRet = Ret.Content;
                    Assert.Equal(reportTypeLanguageLast.ReportTypeLanguageID, reportTypeLanguageRet.ReportTypeLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added ReportTypeLanguage
                    reportTypeLanguageRet.ReportTypeLanguageID = 0;
                    reportTypeLanguageController.Request = new System.Net.Http.HttpRequestMessage();
                    reportTypeLanguageController.Request.RequestUri = new System.Uri("http://localhost:5000/api/reportTypeLanguage");
                    IHttpActionResult jsonRet3 = reportTypeLanguageController.Post(reportTypeLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<ReportTypeLanguage> reportTypeLanguageRet3 = jsonRet3 as CreatedNegotiatedContentResult<ReportTypeLanguage>;
                    Assert.NotNull(reportTypeLanguageRet3);
                    ReportTypeLanguage reportTypeLanguage = reportTypeLanguageRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = reportTypeLanguageController.Delete(reportTypeLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<ReportTypeLanguage> reportTypeLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<ReportTypeLanguage>;
                    Assert.NotNull(reportTypeLanguageRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because ReportTypeLanguageID of 0 does not exist
                    reportTypeLanguageRet.ReportTypeLanguageID = 0;
                    IHttpActionResult jsonRet4 = reportTypeLanguageController.Delete(reportTypeLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<ReportTypeLanguage> reportTypeLanguageRet4 = jsonRet4 as OkNegotiatedContentResult<ReportTypeLanguage>;
                    Assert.IsNull(reportTypeLanguageRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
