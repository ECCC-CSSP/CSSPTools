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
        [Fact]
        public void ReportSection_Controller_GetReportSectionList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ReportSectionController reportSectionController = new ReportSectionController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(reportSectionController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, reportSectionController.DatabaseType);

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
                    IActionResult jsonRet = reportSectionController.GetReportSectionList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(reportSectionFirst.ReportSectionID, ((List<ReportSection>)ret.Value)[0].ReportSectionID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<ReportSection>)ret.Value).Count);

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
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(reportSectionList[0].ReportSectionID, ((List<ReportSection>)ret.Value)[0].ReportSectionID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<ReportSection>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with ReportSection info
                           IActionResult jsonRet2 = reportSectionController.GetReportSectionList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(reportSectionList[1].ReportSectionID, ((List<ReportSection>)ret2.Value)[0].ReportSectionID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<ReportSection>)ret2.Value).Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void ReportSection_Controller_GetReportSectionWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ReportSectionController reportSectionController = new ReportSectionController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(reportSectionController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, reportSectionController.DatabaseType);

                    ReportSection reportSectionFirst = new ReportSection();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        ReportSectionService reportSectionService = new ReportSectionService(new Query(), db, ContactID);
                        reportSectionFirst = (from c in db.ReportSections select c).FirstOrDefault();
                    }

                    // ok with ReportSection info
                    IActionResult jsonRet = reportSectionController.GetReportSectionWithID(reportSectionFirst.ReportSectionID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(reportSectionFirst.ReportSectionID, ((ReportSection)ret.Value).ReportSectionID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = reportSectionController.GetReportSectionWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult reportSectionRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(reportSectionRet2);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void ReportSection_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ReportSectionController reportSectionController = new ReportSectionController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(reportSectionController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, reportSectionController.DatabaseType);

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
                    IActionResult jsonRet = reportSectionController.GetReportSectionWithID(reportSectionLast.ReportSectionID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    ReportSection reportSectionRet = (ReportSection)ret.Value;
                    Assert.Equal(reportSectionLast.ReportSectionID, reportSectionRet.ReportSectionID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because ReportSectionID exist
                    IActionResult jsonRet2 = reportSectionController.Post(reportSectionRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added ReportSection
                    reportSectionRet.ReportSectionID = 0;
                    IActionResult jsonRet3 = reportSectionController.Post(reportSectionRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = reportSectionController.Delete(reportSectionRet, LanguageRequest.ToString());
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
        public void ReportSection_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ReportSectionController reportSectionController = new ReportSectionController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(reportSectionController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, reportSectionController.DatabaseType);

                    ReportSection reportSectionLast = new ReportSection();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        ReportSectionService reportSectionService = new ReportSectionService(query, db, ContactID);
                        reportSectionLast = (from c in db.ReportSections select c).FirstOrDefault();
                    }

                    // ok with ReportSection info
                    IActionResult jsonRet = reportSectionController.GetReportSectionWithID(reportSectionLast.ReportSectionID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    ReportSection reportSectionRet = (ReportSection)Ret.Value;
                    Assert.Equal(reportSectionLast.ReportSectionID, reportSectionRet.ReportSectionID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = reportSectionController.Put(reportSectionRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult reportSectionRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(reportSectionRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because ReportSectionID of 0 does not exist
                    reportSectionRet.ReportSectionID = 0;
                    IActionResult jsonRet3 = reportSectionController.Put(reportSectionRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult reportSectionRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(reportSectionRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void ReportSection_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ReportSectionController reportSectionController = new ReportSectionController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(reportSectionController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, reportSectionController.DatabaseType);

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
                    IActionResult jsonRet = reportSectionController.GetReportSectionWithID(reportSectionLast.ReportSectionID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    ReportSection reportSectionRet = (ReportSection)Ret.Value;
                    Assert.Equal(reportSectionLast.ReportSectionID, reportSectionRet.ReportSectionID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added ReportSection
                    reportSectionRet.ReportSectionID = 0;
                    IActionResult jsonRet3 = reportSectionController.Post(reportSectionRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    ReportSection reportSection = (ReportSection)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = reportSectionController.Delete(reportSectionRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because ReportSectionID of 0 does not exist
                    reportSectionRet.ReportSectionID = 0;
                    IActionResult jsonRet4 = reportSectionController.Delete(reportSectionRet, LanguageRequest.ToString());
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
