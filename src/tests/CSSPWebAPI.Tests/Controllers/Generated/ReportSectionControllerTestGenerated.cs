using CSSPEnums;
using CSSPModels;
using CSSPServices;
using CSSPWebAPI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;

namespace CSSPWebAPI.Tests.Controllers
{
    [TestClass]
    public partial class ReportSectionControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ReportSectionControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [TestMethod]
        public void ReportSection_Controller_GetReportSectionList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ReportSectionController reportSectionController = new ReportSectionController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(reportSectionController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, reportSectionController.DatabaseType);

                    ReportSection reportSectionFirst = new ReportSection();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        ReportSectionService reportSectionService = new ReportSectionService(query, db, ContactID);
                        reportSectionFirst = (from c in db.ReportSections select c).FirstOrDefault();
                        count = (from c in db.ReportSections select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with ReportSection info
                    IHttpActionResult jsonRet = reportSectionController.GetReportSectionList();
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<List<ReportSection>> ret = jsonRet as OkNegotiatedContentResult<List<ReportSection>>;
                    Assert.AreEqual(reportSectionFirst.ReportSectionID, ret.Content[0].ReportSectionID);
                    Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<ReportSection> reportSectionList = new List<ReportSection>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        ReportSectionService reportSectionService = new ReportSectionService(query, db, ContactID);
                        reportSectionList = (from c in db.ReportSections select c).OrderBy(c => c.ReportSectionID).Skip(0).Take(2).ToList();
                        count = (from c in db.ReportSections select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with ReportSection info
                        jsonRet = reportSectionController.GetReportSectionList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsNotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<ReportSection>>;
                        Assert.AreEqual(reportSectionList[0].ReportSectionID, ret.Content[0].ReportSectionID);
                        Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with ReportSection info
                           IHttpActionResult jsonRet2 = reportSectionController.GetReportSectionList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.IsNotNull(jsonRet2);

                           OkNegotiatedContentResult<List<ReportSection>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<ReportSection>>;
                           Assert.AreEqual(reportSectionList[1].ReportSectionID, ret2.Content[0].ReportSectionID);
                           Assert.AreEqual((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [TestMethod]
        public void ReportSection_Controller_GetReportSectionWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ReportSectionController reportSectionController = new ReportSectionController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(reportSectionController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, reportSectionController.DatabaseType);

                    ReportSection reportSectionFirst = new ReportSection();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        ReportSectionService reportSectionService = new ReportSectionService(new Query(), db, ContactID);
                        reportSectionFirst = (from c in db.ReportSections select c).FirstOrDefault();
                    }

                    // ok with ReportSection info
                    IHttpActionResult jsonRet = reportSectionController.GetReportSectionWithID(reportSectionFirst.ReportSectionID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<ReportSection> Ret = jsonRet as OkNegotiatedContentResult<ReportSection>;
                    ReportSection reportSectionRet = Ret.Content;
                    Assert.AreEqual(reportSectionFirst.ReportSectionID, reportSectionRet.ReportSectionID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = reportSectionController.GetReportSectionWithID(0);
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<ReportSection> reportSectionRet2 = jsonRet2 as OkNegotiatedContentResult<ReportSection>;
                    Assert.IsNull(reportSectionRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.IsNotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [TestMethod]
        public void ReportSection_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ReportSectionController reportSectionController = new ReportSectionController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(reportSectionController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, reportSectionController.DatabaseType);

                    ReportSection reportSectionLast = new ReportSection();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        ReportSectionService reportSectionService = new ReportSectionService(query, db, ContactID);
                        reportSectionLast = (from c in db.ReportSections select c).FirstOrDefault();
                    }

                    // ok with ReportSection info
                    IHttpActionResult jsonRet = reportSectionController.GetReportSectionWithID(reportSectionLast.ReportSectionID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<ReportSection> Ret = jsonRet as OkNegotiatedContentResult<ReportSection>;
                    ReportSection reportSectionRet = Ret.Content;
                    Assert.AreEqual(reportSectionLast.ReportSectionID, reportSectionRet.ReportSectionID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because ReportSectionID exist
                    IHttpActionResult jsonRet2 = reportSectionController.Post(reportSectionRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<ReportSection> reportSectionRet2 = jsonRet2 as OkNegotiatedContentResult<ReportSection>;
                    Assert.IsNull(reportSectionRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest2);

                    // Post to return newly added ReportSection
                    reportSectionRet.ReportSectionID = 0;
                    reportSectionController.Request = new System.Net.Http.HttpRequestMessage();
                    reportSectionController.Request.RequestUri = new System.Uri("http://localhost:5000/api/reportSection");
                    IHttpActionResult jsonRet3 = reportSectionController.Post(reportSectionRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<ReportSection> reportSectionRet3 = jsonRet3 as CreatedNegotiatedContentResult<ReportSection>;
                    Assert.IsNotNull(reportSectionRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = reportSectionController.Delete(reportSectionRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<ReportSection> reportSectionRet4 = jsonRet4 as OkNegotiatedContentResult<ReportSection>;
                    Assert.IsNotNull(reportSectionRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [TestMethod]
        public void ReportSection_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ReportSectionController reportSectionController = new ReportSectionController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(reportSectionController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, reportSectionController.DatabaseType);

                    ReportSection reportSectionLast = new ReportSection();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        ReportSectionService reportSectionService = new ReportSectionService(query, db, ContactID);
                        reportSectionLast = (from c in db.ReportSections select c).FirstOrDefault();
                    }

                    // ok with ReportSection info
                    IHttpActionResult jsonRet = reportSectionController.GetReportSectionWithID(reportSectionLast.ReportSectionID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<ReportSection> Ret = jsonRet as OkNegotiatedContentResult<ReportSection>;
                    ReportSection reportSectionRet = Ret.Content;
                    Assert.AreEqual(reportSectionLast.ReportSectionID, reportSectionRet.ReportSectionID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = reportSectionController.Put(reportSectionRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<ReportSection> reportSectionRet2 = jsonRet2 as OkNegotiatedContentResult<ReportSection>;
                    Assert.IsNotNull(reportSectionRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because ReportSectionID of 0 does not exist
                    reportSectionRet.ReportSectionID = 0;
                    IHttpActionResult jsonRet3 = reportSectionController.Put(reportSectionRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    OkNegotiatedContentResult<ReportSection> reportSectionRet3 = jsonRet3 as OkNegotiatedContentResult<ReportSection>;
                    Assert.IsNull(reportSectionRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [TestMethod]
        public void ReportSection_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ReportSectionController reportSectionController = new ReportSectionController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(reportSectionController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, reportSectionController.DatabaseType);

                    ReportSection reportSectionLast = new ReportSection();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        ReportSectionService reportSectionService = new ReportSectionService(query, db, ContactID);
                        reportSectionLast = (from c in db.ReportSections select c).FirstOrDefault();
                    }

                    // ok with ReportSection info
                    IHttpActionResult jsonRet = reportSectionController.GetReportSectionWithID(reportSectionLast.ReportSectionID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<ReportSection> Ret = jsonRet as OkNegotiatedContentResult<ReportSection>;
                    ReportSection reportSectionRet = Ret.Content;
                    Assert.AreEqual(reportSectionLast.ReportSectionID, reportSectionRet.ReportSectionID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added ReportSection
                    reportSectionRet.ReportSectionID = 0;
                    reportSectionController.Request = new System.Net.Http.HttpRequestMessage();
                    reportSectionController.Request.RequestUri = new System.Uri("http://localhost:5000/api/reportSection");
                    IHttpActionResult jsonRet3 = reportSectionController.Post(reportSectionRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<ReportSection> reportSectionRet3 = jsonRet3 as CreatedNegotiatedContentResult<ReportSection>;
                    Assert.IsNotNull(reportSectionRet3);
                    ReportSection reportSection = reportSectionRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = reportSectionController.Delete(reportSectionRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<ReportSection> reportSectionRet2 = jsonRet2 as OkNegotiatedContentResult<ReportSection>;
                    Assert.IsNotNull(reportSectionRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because ReportSectionID of 0 does not exist
                    reportSectionRet.ReportSectionID = 0;
                    IHttpActionResult jsonRet4 = reportSectionController.Delete(reportSectionRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<ReportSection> reportSectionRet4 = jsonRet4 as OkNegotiatedContentResult<ReportSection>;
                    Assert.IsNull(reportSectionRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
