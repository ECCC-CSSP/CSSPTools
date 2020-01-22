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
    public partial class LabSheetTubeMPNDetailControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public LabSheetTubeMPNDetailControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void LabSheetTubeMPNDetail_Controller_GetLabSheetTubeMPNDetailList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    LabSheetTubeMPNDetailController labSheetTubeMPNDetailController = new LabSheetTubeMPNDetailController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(labSheetTubeMPNDetailController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, labSheetTubeMPNDetailController.DatabaseType);

                    LabSheetTubeMPNDetail labSheetTubeMPNDetailFirst = new LabSheetTubeMPNDetail();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        LabSheetTubeMPNDetailService labSheetTubeMPNDetailService = new LabSheetTubeMPNDetailService(query, db, ContactID);
                        labSheetTubeMPNDetailFirst = (from c in db.LabSheetTubeMPNDetails select c).FirstOrDefault();
                        count = (from c in db.LabSheetTubeMPNDetails select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with LabSheetTubeMPNDetail info
                    IActionResult jsonRet = labSheetTubeMPNDetailController.GetLabSheetTubeMPNDetailList();
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<List<LabSheetTubeMPNDetail>> ret = jsonRet as OkNegotiatedContentResult<List<LabSheetTubeMPNDetail>>;
                    Assert.Equal(labSheetTubeMPNDetailFirst.LabSheetTubeMPNDetailID, ret.Content[0].LabSheetTubeMPNDetailID);
                    Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<LabSheetTubeMPNDetail> labSheetTubeMPNDetailList = new List<LabSheetTubeMPNDetail>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        LabSheetTubeMPNDetailService labSheetTubeMPNDetailService = new LabSheetTubeMPNDetailService(query, db, ContactID);
                        labSheetTubeMPNDetailList = (from c in db.LabSheetTubeMPNDetails select c).OrderBy(c => c.LabSheetTubeMPNDetailID).Skip(0).Take(2).ToList();
                        count = (from c in db.LabSheetTubeMPNDetails select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with LabSheetTubeMPNDetail info
                        jsonRet = labSheetTubeMPNDetailController.GetLabSheetTubeMPNDetailList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.NotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<LabSheetTubeMPNDetail>>;
                        Assert.Equal(labSheetTubeMPNDetailList[0].LabSheetTubeMPNDetailID, ret.Content[0].LabSheetTubeMPNDetailID);
                        Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with LabSheetTubeMPNDetail info
                           IActionResult jsonRet2 = labSheetTubeMPNDetailController.GetLabSheetTubeMPNDetailList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkNegotiatedContentResult<List<LabSheetTubeMPNDetail>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<LabSheetTubeMPNDetail>>;
                           Assert.Equal(labSheetTubeMPNDetailList[1].LabSheetTubeMPNDetailID, ret2.Content[0].LabSheetTubeMPNDetailID);
                           Assert.Equal((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void LabSheetTubeMPNDetail_Controller_GetLabSheetTubeMPNDetailWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    LabSheetTubeMPNDetailController labSheetTubeMPNDetailController = new LabSheetTubeMPNDetailController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(labSheetTubeMPNDetailController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, labSheetTubeMPNDetailController.DatabaseType);

                    LabSheetTubeMPNDetail labSheetTubeMPNDetailFirst = new LabSheetTubeMPNDetail();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        LabSheetTubeMPNDetailService labSheetTubeMPNDetailService = new LabSheetTubeMPNDetailService(new Query(), db, ContactID);
                        labSheetTubeMPNDetailFirst = (from c in db.LabSheetTubeMPNDetails select c).FirstOrDefault();
                    }

                    // ok with LabSheetTubeMPNDetail info
                    IActionResult jsonRet = labSheetTubeMPNDetailController.GetLabSheetTubeMPNDetailWithID(labSheetTubeMPNDetailFirst.LabSheetTubeMPNDetailID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<LabSheetTubeMPNDetail> Ret = jsonRet as OkNegotiatedContentResult<LabSheetTubeMPNDetail>;
                    LabSheetTubeMPNDetail labSheetTubeMPNDetailRet = Ret.Content;
                    Assert.Equal(labSheetTubeMPNDetailFirst.LabSheetTubeMPNDetailID, labSheetTubeMPNDetailRet.LabSheetTubeMPNDetailID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = labSheetTubeMPNDetailController.GetLabSheetTubeMPNDetailWithID(0);
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<LabSheetTubeMPNDetail> labSheetTubeMPNDetailRet2 = jsonRet2 as OkNegotiatedContentResult<LabSheetTubeMPNDetail>;
                    Assert.Null(labSheetTubeMPNDetailRet2);

                    NotFoundObjectResult notFoundRequest = jsonRet2 as NotFoundObjectResult;
                    Assert.NotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void LabSheetTubeMPNDetail_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    LabSheetTubeMPNDetailController labSheetTubeMPNDetailController = new LabSheetTubeMPNDetailController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(labSheetTubeMPNDetailController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, labSheetTubeMPNDetailController.DatabaseType);

                    LabSheetTubeMPNDetail labSheetTubeMPNDetailLast = new LabSheetTubeMPNDetail();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        LabSheetTubeMPNDetailService labSheetTubeMPNDetailService = new LabSheetTubeMPNDetailService(query, db, ContactID);
                        labSheetTubeMPNDetailLast = (from c in db.LabSheetTubeMPNDetails select c).FirstOrDefault();
                    }

                    // ok with LabSheetTubeMPNDetail info
                    IActionResult jsonRet = labSheetTubeMPNDetailController.GetLabSheetTubeMPNDetailWithID(labSheetTubeMPNDetailLast.LabSheetTubeMPNDetailID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<LabSheetTubeMPNDetail> Ret = jsonRet as OkNegotiatedContentResult<LabSheetTubeMPNDetail>;
                    LabSheetTubeMPNDetail labSheetTubeMPNDetailRet = Ret.Content;
                    Assert.Equal(labSheetTubeMPNDetailLast.LabSheetTubeMPNDetailID, labSheetTubeMPNDetailRet.LabSheetTubeMPNDetailID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because LabSheetTubeMPNDetailID exist
                    IActionResult jsonRet2 = labSheetTubeMPNDetailController.Post(labSheetTubeMPNDetailRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<LabSheetTubeMPNDetail> labSheetTubeMPNDetailRet2 = jsonRet2 as OkNegotiatedContentResult<LabSheetTubeMPNDetail>;
                    Assert.Null(labSheetTubeMPNDetailRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added LabSheetTubeMPNDetail
                    labSheetTubeMPNDetailRet.LabSheetTubeMPNDetailID = 0;
                    labSheetTubeMPNDetailController.Request = new System.Net.Http.HttpRequestMessage();
                    labSheetTubeMPNDetailController.Request.RequestUri = new System.Uri("http://localhost:5000/api/labSheetTubeMPNDetail");
                    IActionResult jsonRet3 = labSheetTubeMPNDetailController.Post(labSheetTubeMPNDetailRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<LabSheetTubeMPNDetail> labSheetTubeMPNDetailRet3 = jsonRet3 as CreatedNegotiatedContentResult<LabSheetTubeMPNDetail>;
                    Assert.NotNull(labSheetTubeMPNDetailRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = labSheetTubeMPNDetailController.Delete(labSheetTubeMPNDetailRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<LabSheetTubeMPNDetail> labSheetTubeMPNDetailRet4 = jsonRet4 as OkNegotiatedContentResult<LabSheetTubeMPNDetail>;
                    Assert.NotNull(labSheetTubeMPNDetailRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [Fact]
        public void LabSheetTubeMPNDetail_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    LabSheetTubeMPNDetailController labSheetTubeMPNDetailController = new LabSheetTubeMPNDetailController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(labSheetTubeMPNDetailController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, labSheetTubeMPNDetailController.DatabaseType);

                    LabSheetTubeMPNDetail labSheetTubeMPNDetailLast = new LabSheetTubeMPNDetail();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        LabSheetTubeMPNDetailService labSheetTubeMPNDetailService = new LabSheetTubeMPNDetailService(query, db, ContactID);
                        labSheetTubeMPNDetailLast = (from c in db.LabSheetTubeMPNDetails select c).FirstOrDefault();
                    }

                    // ok with LabSheetTubeMPNDetail info
                    IActionResult jsonRet = labSheetTubeMPNDetailController.GetLabSheetTubeMPNDetailWithID(labSheetTubeMPNDetailLast.LabSheetTubeMPNDetailID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<LabSheetTubeMPNDetail> Ret = jsonRet as OkNegotiatedContentResult<LabSheetTubeMPNDetail>;
                    LabSheetTubeMPNDetail labSheetTubeMPNDetailRet = Ret.Content;
                    Assert.Equal(labSheetTubeMPNDetailLast.LabSheetTubeMPNDetailID, labSheetTubeMPNDetailRet.LabSheetTubeMPNDetailID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = labSheetTubeMPNDetailController.Put(labSheetTubeMPNDetailRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<LabSheetTubeMPNDetail> labSheetTubeMPNDetailRet2 = jsonRet2 as OkNegotiatedContentResult<LabSheetTubeMPNDetail>;
                    Assert.NotNull(labSheetTubeMPNDetailRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because LabSheetTubeMPNDetailID of 0 does not exist
                    labSheetTubeMPNDetailRet.LabSheetTubeMPNDetailID = 0;
                    IActionResult jsonRet3 = labSheetTubeMPNDetailController.Put(labSheetTubeMPNDetailRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    OkNegotiatedContentResult<LabSheetTubeMPNDetail> labSheetTubeMPNDetailRet3 = jsonRet3 as OkNegotiatedContentResult<LabSheetTubeMPNDetail>;
                    Assert.Null(labSheetTubeMPNDetailRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void LabSheetTubeMPNDetail_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    LabSheetTubeMPNDetailController labSheetTubeMPNDetailController = new LabSheetTubeMPNDetailController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(labSheetTubeMPNDetailController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, labSheetTubeMPNDetailController.DatabaseType);

                    LabSheetTubeMPNDetail labSheetTubeMPNDetailLast = new LabSheetTubeMPNDetail();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        LabSheetTubeMPNDetailService labSheetTubeMPNDetailService = new LabSheetTubeMPNDetailService(query, db, ContactID);
                        labSheetTubeMPNDetailLast = (from c in db.LabSheetTubeMPNDetails select c).FirstOrDefault();
                    }

                    // ok with LabSheetTubeMPNDetail info
                    IActionResult jsonRet = labSheetTubeMPNDetailController.GetLabSheetTubeMPNDetailWithID(labSheetTubeMPNDetailLast.LabSheetTubeMPNDetailID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<LabSheetTubeMPNDetail> Ret = jsonRet as OkNegotiatedContentResult<LabSheetTubeMPNDetail>;
                    LabSheetTubeMPNDetail labSheetTubeMPNDetailRet = Ret.Content;
                    Assert.Equal(labSheetTubeMPNDetailLast.LabSheetTubeMPNDetailID, labSheetTubeMPNDetailRet.LabSheetTubeMPNDetailID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return newly added LabSheetTubeMPNDetail
                    labSheetTubeMPNDetailRet.LabSheetTubeMPNDetailID = 0;
                    labSheetTubeMPNDetailController.Request = new System.Net.Http.HttpRequestMessage();
                    labSheetTubeMPNDetailController.Request.RequestUri = new System.Uri("http://localhost:5000/api/labSheetTubeMPNDetail");
                    IActionResult jsonRet3 = labSheetTubeMPNDetailController.Post(labSheetTubeMPNDetailRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<LabSheetTubeMPNDetail> labSheetTubeMPNDetailRet3 = jsonRet3 as CreatedNegotiatedContentResult<LabSheetTubeMPNDetail>;
                    Assert.NotNull(labSheetTubeMPNDetailRet3);
                    LabSheetTubeMPNDetail labSheetTubeMPNDetail = labSheetTubeMPNDetailRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = labSheetTubeMPNDetailController.Delete(labSheetTubeMPNDetailRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<LabSheetTubeMPNDetail> labSheetTubeMPNDetailRet2 = jsonRet2 as OkNegotiatedContentResult<LabSheetTubeMPNDetail>;
                    Assert.NotNull(labSheetTubeMPNDetailRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because LabSheetTubeMPNDetailID of 0 does not exist
                    labSheetTubeMPNDetailRet.LabSheetTubeMPNDetailID = 0;
                    IActionResult jsonRet4 = labSheetTubeMPNDetailController.Delete(labSheetTubeMPNDetailRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<LabSheetTubeMPNDetail> labSheetTubeMPNDetailRet4 = jsonRet4 as OkNegotiatedContentResult<LabSheetTubeMPNDetail>;
                    Assert.Null(labSheetTubeMPNDetailRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
