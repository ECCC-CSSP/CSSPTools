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
    public partial class ReportTypeControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ReportTypeControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void ReportType_Controller_GetReportTypeList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ReportTypeController reportTypeController = new ReportTypeController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(reportTypeController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, reportTypeController.DatabaseType);

                    ReportType reportTypeFirst = new ReportType();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        ReportTypeService reportTypeService = new ReportTypeService(query, db, ContactID);
                        reportTypeFirst = (from c in db.ReportTypes select c).FirstOrDefault();
                        count = (from c in db.ReportTypes select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with ReportType info
                    IActionResult jsonRet = reportTypeController.GetReportTypeList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(reportTypeFirst.ReportTypeID, ((List<ReportType>)ret.Value)[0].ReportTypeID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<ReportType>)ret.Value).Count);

                    List<ReportType> reportTypeList = new List<ReportType>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        ReportTypeService reportTypeService = new ReportTypeService(query, db, ContactID);
                        reportTypeList = (from c in db.ReportTypes select c).OrderBy(c => c.ReportTypeID).Skip(0).Take(2).ToList();
                        count = (from c in db.ReportTypes select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with ReportType info
                        jsonRet = reportTypeController.GetReportTypeList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(reportTypeList[0].ReportTypeID, ((List<ReportType>)ret.Value)[0].ReportTypeID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<ReportType>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with ReportType info
                           IActionResult jsonRet2 = reportTypeController.GetReportTypeList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(reportTypeList[1].ReportTypeID, ((List<ReportType>)ret2.Value)[0].ReportTypeID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<ReportType>)ret2.Value).Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void ReportType_Controller_GetReportTypeWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ReportTypeController reportTypeController = new ReportTypeController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(reportTypeController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, reportTypeController.DatabaseType);

                    ReportType reportTypeFirst = new ReportType();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        ReportTypeService reportTypeService = new ReportTypeService(new Query(), db, ContactID);
                        reportTypeFirst = (from c in db.ReportTypes select c).FirstOrDefault();
                    }

                    // ok with ReportType info
                    IActionResult jsonRet = reportTypeController.GetReportTypeWithID(reportTypeFirst.ReportTypeID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(reportTypeFirst.ReportTypeID, ((ReportType)ret.Value).ReportTypeID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = reportTypeController.GetReportTypeWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult reportTypeRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(reportTypeRet2);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void ReportType_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ReportTypeController reportTypeController = new ReportTypeController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(reportTypeController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, reportTypeController.DatabaseType);

                    ReportType reportTypeFirst = new ReportType();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        ReportTypeService reportTypeService = new ReportTypeService(query, db, ContactID);
                        reportTypeFirst = (from c in db.ReportTypes select c).FirstOrDefault();
                    }

                    // ok with ReportType info
                    IActionResult jsonRet = reportTypeController.GetReportTypeWithID(reportTypeFirst.ReportTypeID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    ReportType reportTypeRet = (ReportType)ret.Value;
                    Assert.Equal(reportTypeFirst.ReportTypeID, reportTypeRet.ReportTypeID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because ReportTypeID exist
                    IActionResult jsonRet2 = reportTypeController.Post(reportTypeRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added ReportType
                    reportTypeRet.ReportTypeID = 0;
                    IActionResult jsonRet3 = reportTypeController.Post(reportTypeRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = reportTypeController.Delete(reportTypeRet, LanguageRequest.ToString());
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
        public void ReportType_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ReportTypeController reportTypeController = new ReportTypeController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(reportTypeController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, reportTypeController.DatabaseType);

                    ReportType reportTypeFirst = new ReportType();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        ReportTypeService reportTypeService = new ReportTypeService(query, db, ContactID);
                        reportTypeFirst = (from c in db.ReportTypes select c).FirstOrDefault();
                    }

                    // ok with ReportType info
                    IActionResult jsonRet = reportTypeController.GetReportTypeWithID(reportTypeFirst.ReportTypeID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    ReportType reportTypeRet = (ReportType)Ret.Value;
                    Assert.Equal(reportTypeFirst.ReportTypeID, reportTypeRet.ReportTypeID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = reportTypeController.Put(reportTypeRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult reportTypeRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(reportTypeRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because ReportTypeID of 0 does not exist
                    reportTypeRet.ReportTypeID = 0;
                    IActionResult jsonRet3 = reportTypeController.Put(reportTypeRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult reportTypeRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(reportTypeRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void ReportType_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ReportTypeController reportTypeController = new ReportTypeController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(reportTypeController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, reportTypeController.DatabaseType);

                    ReportType reportTypeFirst = new ReportType();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        ReportTypeService reportTypeService = new ReportTypeService(query, db, ContactID);
                        reportTypeFirst = (from c in db.ReportTypes select c).FirstOrDefault();
                    }

                    // ok with ReportType info
                    IActionResult jsonRet = reportTypeController.GetReportTypeWithID(reportTypeFirst.ReportTypeID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    ReportType reportTypeRet = (ReportType)Ret.Value;
                    Assert.Equal(reportTypeFirst.ReportTypeID, reportTypeRet.ReportTypeID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added ReportType
                    reportTypeRet.ReportTypeID = 0;
                    IActionResult jsonRet3 = reportTypeController.Post(reportTypeRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    ReportType reportType = (ReportType)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = reportTypeController.Delete(reportTypeRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because ReportTypeID of 0 does not exist
                    reportTypeRet.ReportTypeID = 0;
                    IActionResult jsonRet4 = reportTypeController.Delete(reportTypeRet, LanguageRequest.ToString());
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
