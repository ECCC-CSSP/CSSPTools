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
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(labSheetTubeMPNDetailFirst.LabSheetTubeMPNDetailID, ((List<LabSheetTubeMPNDetail>)ret.Value)[0].LabSheetTubeMPNDetailID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<LabSheetTubeMPNDetail>)ret.Value).Count);

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
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(labSheetTubeMPNDetailList[0].LabSheetTubeMPNDetailID, ((List<LabSheetTubeMPNDetail>)ret.Value)[0].LabSheetTubeMPNDetailID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<LabSheetTubeMPNDetail>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with LabSheetTubeMPNDetail info
                           IActionResult jsonRet2 = labSheetTubeMPNDetailController.GetLabSheetTubeMPNDetailList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(labSheetTubeMPNDetailList[1].LabSheetTubeMPNDetailID, ((List<LabSheetTubeMPNDetail>)ret2.Value)[0].LabSheetTubeMPNDetailID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<LabSheetTubeMPNDetail>)ret2.Value).Count);
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
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(labSheetTubeMPNDetailFirst.LabSheetTubeMPNDetailID, ((LabSheetTubeMPNDetail)ret.Value).LabSheetTubeMPNDetailID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = labSheetTubeMPNDetailController.GetLabSheetTubeMPNDetailWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult labSheetTubeMPNDetailRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(labSheetTubeMPNDetailRet2);
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
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    LabSheetTubeMPNDetail labSheetTubeMPNDetailRet = (LabSheetTubeMPNDetail)ret.Value;
                    Assert.Equal(labSheetTubeMPNDetailLast.LabSheetTubeMPNDetailID, labSheetTubeMPNDetailRet.LabSheetTubeMPNDetailID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because LabSheetTubeMPNDetailID exist
                    IActionResult jsonRet2 = labSheetTubeMPNDetailController.Post(labSheetTubeMPNDetailRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added LabSheetTubeMPNDetail
                    labSheetTubeMPNDetailRet.LabSheetTubeMPNDetailID = 0;
                    IActionResult jsonRet3 = labSheetTubeMPNDetailController.Post(labSheetTubeMPNDetailRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = labSheetTubeMPNDetailController.Delete(labSheetTubeMPNDetailRet, LanguageRequest.ToString());
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
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    LabSheetTubeMPNDetail labSheetTubeMPNDetailRet = (LabSheetTubeMPNDetail)Ret.Value;
                    Assert.Equal(labSheetTubeMPNDetailLast.LabSheetTubeMPNDetailID, labSheetTubeMPNDetailRet.LabSheetTubeMPNDetailID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = labSheetTubeMPNDetailController.Put(labSheetTubeMPNDetailRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult labSheetTubeMPNDetailRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(labSheetTubeMPNDetailRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because LabSheetTubeMPNDetailID of 0 does not exist
                    labSheetTubeMPNDetailRet.LabSheetTubeMPNDetailID = 0;
                    IActionResult jsonRet3 = labSheetTubeMPNDetailController.Put(labSheetTubeMPNDetailRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult labSheetTubeMPNDetailRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(labSheetTubeMPNDetailRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
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
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    LabSheetTubeMPNDetail labSheetTubeMPNDetailRet = (LabSheetTubeMPNDetail)Ret.Value;
                    Assert.Equal(labSheetTubeMPNDetailLast.LabSheetTubeMPNDetailID, labSheetTubeMPNDetailRet.LabSheetTubeMPNDetailID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added LabSheetTubeMPNDetail
                    labSheetTubeMPNDetailRet.LabSheetTubeMPNDetailID = 0;
                    IActionResult jsonRet3 = labSheetTubeMPNDetailController.Post(labSheetTubeMPNDetailRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    LabSheetTubeMPNDetail labSheetTubeMPNDetail = (LabSheetTubeMPNDetail)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = labSheetTubeMPNDetailController.Delete(labSheetTubeMPNDetailRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because LabSheetTubeMPNDetailID of 0 does not exist
                    labSheetTubeMPNDetailRet.LabSheetTubeMPNDetailID = 0;
                    IActionResult jsonRet4 = labSheetTubeMPNDetailController.Delete(labSheetTubeMPNDetailRet, LanguageRequest.ToString());
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
