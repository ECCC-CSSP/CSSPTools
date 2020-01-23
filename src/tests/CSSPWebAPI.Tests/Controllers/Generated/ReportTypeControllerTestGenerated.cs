using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Xunit;
using CSSPWebAPI.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.AspNetCore.Mvc;

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
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<List<ReportType>> ret = jsonRet as OkNegotiatedContentResult<List<ReportType>>;
                    Assert.Equal(reportTypeFirst.ReportTypeID, ret.Content[0].ReportTypeID);
                    Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

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
                        Assert.NotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<ReportType>>;
                        Assert.Equal(reportTypeList[0].ReportTypeID, ret.Content[0].ReportTypeID);
                        Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with ReportType info
                           IActionResult jsonRet2 = reportTypeController.GetReportTypeList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkNegotiatedContentResult<List<ReportType>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<ReportType>>;
                           Assert.Equal(reportTypeList[1].ReportTypeID, ret2.Content[0].ReportTypeID);
                           Assert.Equal((count > query.Take ? query.Take : count), ret2.Content.Count);
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
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<ReportType> Ret = jsonRet as OkNegotiatedContentResult<ReportType>;
                    ReportType reportTypeRet = Ret.Content;
                    Assert.Equal(reportTypeFirst.ReportTypeID, reportTypeRet.ReportTypeID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = reportTypeController.GetReportTypeWithID(0);
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<ReportType> reportTypeRet2 = jsonRet2 as OkNegotiatedContentResult<ReportType>;
                    Assert.Null(reportTypeRet2);

                    NotFoundObjectResult notFoundRequest = jsonRet2 as NotFoundObjectResult;
                    Assert.NotNull(notFoundRequest);
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

                    ReportType reportTypeLast = new ReportType();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        ReportTypeService reportTypeService = new ReportTypeService(query, db, ContactID);
                        reportTypeLast = (from c in db.ReportTypes select c).FirstOrDefault();
                    }

                    // ok with ReportType info
                    IActionResult jsonRet = reportTypeController.GetReportTypeWithID(reportTypeLast.ReportTypeID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<ReportType> Ret = jsonRet as OkNegotiatedContentResult<ReportType>;
                    ReportType reportTypeRet = Ret.Content;
                    Assert.Equal(reportTypeLast.ReportTypeID, reportTypeRet.ReportTypeID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because ReportTypeID exist
                    IActionResult jsonRet2 = reportTypeController.Post(reportTypeRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<ReportType> reportTypeRet2 = jsonRet2 as OkNegotiatedContentResult<ReportType>;
                    Assert.Null(reportTypeRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added ReportType
                    reportTypeRet.ReportTypeID = 0;
                    IActionResult jsonRet3 = reportTypeController.Post(reportTypeRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<ReportType> reportTypeRet3 = jsonRet3 as CreatedNegotiatedContentResult<ReportType>;
                    Assert.NotNull(reportTypeRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = reportTypeController.Delete(reportTypeRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<ReportType> reportTypeRet4 = jsonRet4 as OkNegotiatedContentResult<ReportType>;
                    Assert.NotNull(reportTypeRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
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

                    ReportType reportTypeLast = new ReportType();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        ReportTypeService reportTypeService = new ReportTypeService(query, db, ContactID);
                        reportTypeLast = (from c in db.ReportTypes select c).FirstOrDefault();
                    }

                    // ok with ReportType info
                    IActionResult jsonRet = reportTypeController.GetReportTypeWithID(reportTypeLast.ReportTypeID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<ReportType> Ret = jsonRet as OkNegotiatedContentResult<ReportType>;
                    ReportType reportTypeRet = Ret.Content;
                    Assert.Equal(reportTypeLast.ReportTypeID, reportTypeRet.ReportTypeID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = reportTypeController.Put(reportTypeRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<ReportType> reportTypeRet2 = jsonRet2 as OkNegotiatedContentResult<ReportType>;
                    Assert.NotNull(reportTypeRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because ReportTypeID of 0 does not exist
                    reportTypeRet.ReportTypeID = 0;
                    IActionResult jsonRet3 = reportTypeController.Put(reportTypeRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    OkNegotiatedContentResult<ReportType> reportTypeRet3 = jsonRet3 as OkNegotiatedContentResult<ReportType>;
                    Assert.Null(reportTypeRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
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

                    ReportType reportTypeLast = new ReportType();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        ReportTypeService reportTypeService = new ReportTypeService(query, db, ContactID);
                        reportTypeLast = (from c in db.ReportTypes select c).FirstOrDefault();
                    }

                    // ok with ReportType info
                    IActionResult jsonRet = reportTypeController.GetReportTypeWithID(reportTypeLast.ReportTypeID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<ReportType> Ret = jsonRet as OkNegotiatedContentResult<ReportType>;
                    ReportType reportTypeRet = Ret.Content;
                    Assert.Equal(reportTypeLast.ReportTypeID, reportTypeRet.ReportTypeID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return newly added ReportType
                    reportTypeRet.ReportTypeID = 0;
                    IActionResult jsonRet3 = reportTypeController.Post(reportTypeRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<ReportType> reportTypeRet3 = jsonRet3 as CreatedNegotiatedContentResult<ReportType>;
                    Assert.NotNull(reportTypeRet3);
                    ReportType reportType = reportTypeRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = reportTypeController.Delete(reportTypeRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<ReportType> reportTypeRet2 = jsonRet2 as OkNegotiatedContentResult<ReportType>;
                    Assert.NotNull(reportTypeRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because ReportTypeID of 0 does not exist
                    reportTypeRet.ReportTypeID = 0;
                    IActionResult jsonRet4 = reportTypeController.Delete(reportTypeRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<ReportType> reportTypeRet4 = jsonRet4 as OkNegotiatedContentResult<ReportType>;
                    Assert.Null(reportTypeRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
