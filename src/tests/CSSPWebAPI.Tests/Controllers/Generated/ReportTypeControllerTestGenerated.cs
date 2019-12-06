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
        [TestMethod]
        public void ReportType_Controller_GetReportTypeList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ReportTypeController reportTypeController = new ReportTypeController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(reportTypeController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, reportTypeController.DatabaseType);

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
                    IHttpActionResult jsonRet = reportTypeController.GetReportTypeList();
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<List<ReportType>> ret = jsonRet as OkNegotiatedContentResult<List<ReportType>>;
                    Assert.AreEqual(reportTypeFirst.ReportTypeID, ret.Content[0].ReportTypeID);
                    Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

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
                        Assert.IsNotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<ReportType>>;
                        Assert.AreEqual(reportTypeList[0].ReportTypeID, ret.Content[0].ReportTypeID);
                        Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with ReportType info
                           IHttpActionResult jsonRet2 = reportTypeController.GetReportTypeList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.IsNotNull(jsonRet2);

                           OkNegotiatedContentResult<List<ReportType>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<ReportType>>;
                           Assert.AreEqual(reportTypeList[1].ReportTypeID, ret2.Content[0].ReportTypeID);
                           Assert.AreEqual((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [TestMethod]
        public void ReportType_Controller_GetReportTypeWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ReportTypeController reportTypeController = new ReportTypeController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(reportTypeController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, reportTypeController.DatabaseType);

                    ReportType reportTypeFirst = new ReportType();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        ReportTypeService reportTypeService = new ReportTypeService(new Query(), db, ContactID);
                        reportTypeFirst = (from c in db.ReportTypes select c).FirstOrDefault();
                    }

                    // ok with ReportType info
                    IHttpActionResult jsonRet = reportTypeController.GetReportTypeWithID(reportTypeFirst.ReportTypeID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<ReportType> Ret = jsonRet as OkNegotiatedContentResult<ReportType>;
                    ReportType reportTypeRet = Ret.Content;
                    Assert.AreEqual(reportTypeFirst.ReportTypeID, reportTypeRet.ReportTypeID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = reportTypeController.GetReportTypeWithID(0);
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<ReportType> reportTypeRet2 = jsonRet2 as OkNegotiatedContentResult<ReportType>;
                    Assert.IsNull(reportTypeRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.IsNotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [TestMethod]
        public void ReportType_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ReportTypeController reportTypeController = new ReportTypeController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(reportTypeController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, reportTypeController.DatabaseType);

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
                    IHttpActionResult jsonRet = reportTypeController.GetReportTypeWithID(reportTypeLast.ReportTypeID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<ReportType> Ret = jsonRet as OkNegotiatedContentResult<ReportType>;
                    ReportType reportTypeRet = Ret.Content;
                    Assert.AreEqual(reportTypeLast.ReportTypeID, reportTypeRet.ReportTypeID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because ReportTypeID exist
                    IHttpActionResult jsonRet2 = reportTypeController.Post(reportTypeRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<ReportType> reportTypeRet2 = jsonRet2 as OkNegotiatedContentResult<ReportType>;
                    Assert.IsNull(reportTypeRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest2);

                    // Post to return newly added ReportType
                    reportTypeRet.ReportTypeID = 0;
                    reportTypeController.Request = new System.Net.Http.HttpRequestMessage();
                    reportTypeController.Request.RequestUri = new System.Uri("http://localhost:5000/api/reportType");
                    IHttpActionResult jsonRet3 = reportTypeController.Post(reportTypeRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<ReportType> reportTypeRet3 = jsonRet3 as CreatedNegotiatedContentResult<ReportType>;
                    Assert.IsNotNull(reportTypeRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = reportTypeController.Delete(reportTypeRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<ReportType> reportTypeRet4 = jsonRet4 as OkNegotiatedContentResult<ReportType>;
                    Assert.IsNotNull(reportTypeRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [TestMethod]
        public void ReportType_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ReportTypeController reportTypeController = new ReportTypeController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(reportTypeController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, reportTypeController.DatabaseType);

                    ReportType reportTypeLast = new ReportType();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        ReportTypeService reportTypeService = new ReportTypeService(query, db, ContactID);
                        reportTypeLast = (from c in db.ReportTypes select c).FirstOrDefault();
                    }

                    // ok with ReportType info
                    IHttpActionResult jsonRet = reportTypeController.GetReportTypeWithID(reportTypeLast.ReportTypeID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<ReportType> Ret = jsonRet as OkNegotiatedContentResult<ReportType>;
                    ReportType reportTypeRet = Ret.Content;
                    Assert.AreEqual(reportTypeLast.ReportTypeID, reportTypeRet.ReportTypeID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = reportTypeController.Put(reportTypeRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<ReportType> reportTypeRet2 = jsonRet2 as OkNegotiatedContentResult<ReportType>;
                    Assert.IsNotNull(reportTypeRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because ReportTypeID of 0 does not exist
                    reportTypeRet.ReportTypeID = 0;
                    IHttpActionResult jsonRet3 = reportTypeController.Put(reportTypeRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    OkNegotiatedContentResult<ReportType> reportTypeRet3 = jsonRet3 as OkNegotiatedContentResult<ReportType>;
                    Assert.IsNull(reportTypeRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [TestMethod]
        public void ReportType_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ReportTypeController reportTypeController = new ReportTypeController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(reportTypeController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, reportTypeController.DatabaseType);

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
                    IHttpActionResult jsonRet = reportTypeController.GetReportTypeWithID(reportTypeLast.ReportTypeID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<ReportType> Ret = jsonRet as OkNegotiatedContentResult<ReportType>;
                    ReportType reportTypeRet = Ret.Content;
                    Assert.AreEqual(reportTypeLast.ReportTypeID, reportTypeRet.ReportTypeID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added ReportType
                    reportTypeRet.ReportTypeID = 0;
                    reportTypeController.Request = new System.Net.Http.HttpRequestMessage();
                    reportTypeController.Request.RequestUri = new System.Uri("http://localhost:5000/api/reportType");
                    IHttpActionResult jsonRet3 = reportTypeController.Post(reportTypeRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<ReportType> reportTypeRet3 = jsonRet3 as CreatedNegotiatedContentResult<ReportType>;
                    Assert.IsNotNull(reportTypeRet3);
                    ReportType reportType = reportTypeRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = reportTypeController.Delete(reportTypeRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<ReportType> reportTypeRet2 = jsonRet2 as OkNegotiatedContentResult<ReportType>;
                    Assert.IsNotNull(reportTypeRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because ReportTypeID of 0 does not exist
                    reportTypeRet.ReportTypeID = 0;
                    IHttpActionResult jsonRet4 = reportTypeController.Delete(reportTypeRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<ReportType> reportTypeRet4 = jsonRet4 as OkNegotiatedContentResult<ReportType>;
                    Assert.IsNull(reportTypeRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
