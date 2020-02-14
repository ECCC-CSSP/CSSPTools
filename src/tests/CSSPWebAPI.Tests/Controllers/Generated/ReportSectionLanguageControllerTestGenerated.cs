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
    public partial class ReportSectionLanguageControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ReportSectionLanguageControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void ReportSectionLanguage_Controller_GetReportSectionLanguageList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ReportSectionLanguageController reportSectionLanguageController = new ReportSectionLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(reportSectionLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, reportSectionLanguageController.DatabaseType);

                    ReportSectionLanguage reportSectionLanguageFirst = new ReportSectionLanguage();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        ReportSectionLanguageService reportSectionLanguageService = new ReportSectionLanguageService(query, db, ContactID);
                        reportSectionLanguageFirst = (from c in db.ReportSectionLanguages select c).FirstOrDefault();
                        count = (from c in db.ReportSectionLanguages select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with ReportSectionLanguage info
                    IActionResult jsonRet = reportSectionLanguageController.GetReportSectionLanguageList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(reportSectionLanguageFirst.ReportSectionLanguageID, ((List<ReportSectionLanguage>)ret.Value)[0].ReportSectionLanguageID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<ReportSectionLanguage>)ret.Value).Count);

                    List<ReportSectionLanguage> reportSectionLanguageList = new List<ReportSectionLanguage>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        ReportSectionLanguageService reportSectionLanguageService = new ReportSectionLanguageService(query, db, ContactID);
                        reportSectionLanguageList = (from c in db.ReportSectionLanguages select c).OrderBy(c => c.ReportSectionLanguageID).Skip(0).Take(2).ToList();
                        count = (from c in db.ReportSectionLanguages select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with ReportSectionLanguage info
                        jsonRet = reportSectionLanguageController.GetReportSectionLanguageList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(reportSectionLanguageList[0].ReportSectionLanguageID, ((List<ReportSectionLanguage>)ret.Value)[0].ReportSectionLanguageID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<ReportSectionLanguage>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with ReportSectionLanguage info
                           IActionResult jsonRet2 = reportSectionLanguageController.GetReportSectionLanguageList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(reportSectionLanguageList[1].ReportSectionLanguageID, ((List<ReportSectionLanguage>)ret2.Value)[0].ReportSectionLanguageID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<ReportSectionLanguage>)ret2.Value).Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void ReportSectionLanguage_Controller_GetReportSectionLanguageWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ReportSectionLanguageController reportSectionLanguageController = new ReportSectionLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(reportSectionLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, reportSectionLanguageController.DatabaseType);

                    ReportSectionLanguage reportSectionLanguageFirst = new ReportSectionLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        ReportSectionLanguageService reportSectionLanguageService = new ReportSectionLanguageService(new Query(), db, ContactID);
                        reportSectionLanguageFirst = (from c in db.ReportSectionLanguages select c).FirstOrDefault();
                    }

                    // ok with ReportSectionLanguage info
                    IActionResult jsonRet = reportSectionLanguageController.GetReportSectionLanguageWithID(reportSectionLanguageFirst.ReportSectionLanguageID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(reportSectionLanguageFirst.ReportSectionLanguageID, ((ReportSectionLanguage)ret.Value).ReportSectionLanguageID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = reportSectionLanguageController.GetReportSectionLanguageWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult reportSectionLanguageRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(reportSectionLanguageRet2);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void ReportSectionLanguage_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ReportSectionLanguageController reportSectionLanguageController = new ReportSectionLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(reportSectionLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, reportSectionLanguageController.DatabaseType);

                    ReportSectionLanguage reportSectionLanguageLast = new ReportSectionLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        ReportSectionLanguageService reportSectionLanguageService = new ReportSectionLanguageService(query, db, ContactID);
                        reportSectionLanguageLast = (from c in db.ReportSectionLanguages select c).FirstOrDefault();
                    }

                    // ok with ReportSectionLanguage info
                    IActionResult jsonRet = reportSectionLanguageController.GetReportSectionLanguageWithID(reportSectionLanguageLast.ReportSectionLanguageID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    ReportSectionLanguage reportSectionLanguageRet = (ReportSectionLanguage)ret.Value;
                    Assert.Equal(reportSectionLanguageLast.ReportSectionLanguageID, reportSectionLanguageRet.ReportSectionLanguageID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because ReportSectionLanguageID exist
                    IActionResult jsonRet2 = reportSectionLanguageController.Post(reportSectionLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added ReportSectionLanguage
                    reportSectionLanguageRet.ReportSectionLanguageID = 0;
                    IActionResult jsonRet3 = reportSectionLanguageController.Post(reportSectionLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = reportSectionLanguageController.Delete(reportSectionLanguageRet, LanguageRequest.ToString());
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
        public void ReportSectionLanguage_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ReportSectionLanguageController reportSectionLanguageController = new ReportSectionLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(reportSectionLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, reportSectionLanguageController.DatabaseType);

                    ReportSectionLanguage reportSectionLanguageLast = new ReportSectionLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        ReportSectionLanguageService reportSectionLanguageService = new ReportSectionLanguageService(query, db, ContactID);
                        reportSectionLanguageLast = (from c in db.ReportSectionLanguages select c).FirstOrDefault();
                    }

                    // ok with ReportSectionLanguage info
                    IActionResult jsonRet = reportSectionLanguageController.GetReportSectionLanguageWithID(reportSectionLanguageLast.ReportSectionLanguageID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    ReportSectionLanguage reportSectionLanguageRet = (ReportSectionLanguage)Ret.Value;
                    Assert.Equal(reportSectionLanguageLast.ReportSectionLanguageID, reportSectionLanguageRet.ReportSectionLanguageID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = reportSectionLanguageController.Put(reportSectionLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult reportSectionLanguageRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(reportSectionLanguageRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because ReportSectionLanguageID of 0 does not exist
                    reportSectionLanguageRet.ReportSectionLanguageID = 0;
                    IActionResult jsonRet3 = reportSectionLanguageController.Put(reportSectionLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult reportSectionLanguageRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(reportSectionLanguageRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void ReportSectionLanguage_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ReportSectionLanguageController reportSectionLanguageController = new ReportSectionLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(reportSectionLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, reportSectionLanguageController.DatabaseType);

                    ReportSectionLanguage reportSectionLanguageLast = new ReportSectionLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        ReportSectionLanguageService reportSectionLanguageService = new ReportSectionLanguageService(query, db, ContactID);
                        reportSectionLanguageLast = (from c in db.ReportSectionLanguages select c).FirstOrDefault();
                    }

                    // ok with ReportSectionLanguage info
                    IActionResult jsonRet = reportSectionLanguageController.GetReportSectionLanguageWithID(reportSectionLanguageLast.ReportSectionLanguageID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    ReportSectionLanguage reportSectionLanguageRet = (ReportSectionLanguage)Ret.Value;
                    Assert.Equal(reportSectionLanguageLast.ReportSectionLanguageID, reportSectionLanguageRet.ReportSectionLanguageID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added ReportSectionLanguage
                    reportSectionLanguageRet.ReportSectionLanguageID = 0;
                    IActionResult jsonRet3 = reportSectionLanguageController.Post(reportSectionLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    ReportSectionLanguage reportSectionLanguage = (ReportSectionLanguage)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = reportSectionLanguageController.Delete(reportSectionLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because ReportSectionLanguageID of 0 does not exist
                    reportSectionLanguageRet.ReportSectionLanguageID = 0;
                    IActionResult jsonRet4 = reportSectionLanguageController.Delete(reportSectionLanguageRet, LanguageRequest.ToString());
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
