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
                    IActionResult jsonRet = reportTypeLanguageController.GetReportTypeLanguageList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(reportTypeLanguageFirst.ReportTypeLanguageID, ((List<ReportTypeLanguage>)ret.Value)[0].ReportTypeLanguageID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<ReportTypeLanguage>)ret.Value).Count);

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
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(reportTypeLanguageList[0].ReportTypeLanguageID, ((List<ReportTypeLanguage>)ret.Value)[0].ReportTypeLanguageID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<ReportTypeLanguage>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with ReportTypeLanguage info
                           IActionResult jsonRet2 = reportTypeLanguageController.GetReportTypeLanguageList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(reportTypeLanguageList[1].ReportTypeLanguageID, ((List<ReportTypeLanguage>)ret2.Value)[0].ReportTypeLanguageID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<ReportTypeLanguage>)ret2.Value).Count);
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
                    IActionResult jsonRet = reportTypeLanguageController.GetReportTypeLanguageWithID(reportTypeLanguageFirst.ReportTypeLanguageID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(reportTypeLanguageFirst.ReportTypeLanguageID, ((ReportTypeLanguage)ret.Value).ReportTypeLanguageID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = reportTypeLanguageController.GetReportTypeLanguageWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult reportTypeLanguageRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(reportTypeLanguageRet2);
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
                    IActionResult jsonRet = reportTypeLanguageController.GetReportTypeLanguageWithID(reportTypeLanguageLast.ReportTypeLanguageID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    ReportTypeLanguage reportTypeLanguageRet = (ReportTypeLanguage)ret.Value;
                    Assert.Equal(reportTypeLanguageLast.ReportTypeLanguageID, reportTypeLanguageRet.ReportTypeLanguageID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because ReportTypeLanguageID exist
                    IActionResult jsonRet2 = reportTypeLanguageController.Post(reportTypeLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added ReportTypeLanguage
                    reportTypeLanguageRet.ReportTypeLanguageID = 0;
                    IActionResult jsonRet3 = reportTypeLanguageController.Post(reportTypeLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = reportTypeLanguageController.Delete(reportTypeLanguageRet, LanguageRequest.ToString());
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
                    IActionResult jsonRet = reportTypeLanguageController.GetReportTypeLanguageWithID(reportTypeLanguageLast.ReportTypeLanguageID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    ReportTypeLanguage reportTypeLanguageRet = (ReportTypeLanguage)Ret.Value;
                    Assert.Equal(reportTypeLanguageLast.ReportTypeLanguageID, reportTypeLanguageRet.ReportTypeLanguageID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = reportTypeLanguageController.Put(reportTypeLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult reportTypeLanguageRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(reportTypeLanguageRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because ReportTypeLanguageID of 0 does not exist
                    reportTypeLanguageRet.ReportTypeLanguageID = 0;
                    IActionResult jsonRet3 = reportTypeLanguageController.Put(reportTypeLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult reportTypeLanguageRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(reportTypeLanguageRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
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
                    IActionResult jsonRet = reportTypeLanguageController.GetReportTypeLanguageWithID(reportTypeLanguageLast.ReportTypeLanguageID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    ReportTypeLanguage reportTypeLanguageRet = (ReportTypeLanguage)Ret.Value;
                    Assert.Equal(reportTypeLanguageLast.ReportTypeLanguageID, reportTypeLanguageRet.ReportTypeLanguageID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added ReportTypeLanguage
                    reportTypeLanguageRet.ReportTypeLanguageID = 0;
                    IActionResult jsonRet3 = reportTypeLanguageController.Post(reportTypeLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    ReportTypeLanguage reportTypeLanguage = (ReportTypeLanguage)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = reportTypeLanguageController.Delete(reportTypeLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because ReportTypeLanguageID of 0 does not exist
                    reportTypeLanguageRet.ReportTypeLanguageID = 0;
                    IActionResult jsonRet4 = reportTypeLanguageController.Delete(reportTypeLanguageRet, LanguageRequest.ToString());
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
