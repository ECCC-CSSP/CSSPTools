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
    public partial class LabSheetDetailControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public LabSheetDetailControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void LabSheetDetail_Controller_GetLabSheetDetailList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    LabSheetDetailController labSheetDetailController = new LabSheetDetailController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(labSheetDetailController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, labSheetDetailController.DatabaseType);

                    LabSheetDetail labSheetDetailFirst = new LabSheetDetail();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        LabSheetDetailService labSheetDetailService = new LabSheetDetailService(query, db, ContactID);
                        labSheetDetailFirst = (from c in db.LabSheetDetails select c).FirstOrDefault();
                        count = (from c in db.LabSheetDetails select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with LabSheetDetail info
                    IActionResult jsonRet = labSheetDetailController.GetLabSheetDetailList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(labSheetDetailFirst.LabSheetDetailID, ((List<LabSheetDetail>)ret.Value)[0].LabSheetDetailID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<LabSheetDetail>)ret.Value).Count);

                    List<LabSheetDetail> labSheetDetailList = new List<LabSheetDetail>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        LabSheetDetailService labSheetDetailService = new LabSheetDetailService(query, db, ContactID);
                        labSheetDetailList = (from c in db.LabSheetDetails select c).OrderBy(c => c.LabSheetDetailID).Skip(0).Take(2).ToList();
                        count = (from c in db.LabSheetDetails select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with LabSheetDetail info
                        jsonRet = labSheetDetailController.GetLabSheetDetailList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(labSheetDetailList[0].LabSheetDetailID, ((List<LabSheetDetail>)ret.Value)[0].LabSheetDetailID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<LabSheetDetail>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with LabSheetDetail info
                           IActionResult jsonRet2 = labSheetDetailController.GetLabSheetDetailList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(labSheetDetailList[1].LabSheetDetailID, ((List<LabSheetDetail>)ret2.Value)[0].LabSheetDetailID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<LabSheetDetail>)ret2.Value).Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void LabSheetDetail_Controller_GetLabSheetDetailWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    LabSheetDetailController labSheetDetailController = new LabSheetDetailController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(labSheetDetailController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, labSheetDetailController.DatabaseType);

                    LabSheetDetail labSheetDetailFirst = new LabSheetDetail();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        LabSheetDetailService labSheetDetailService = new LabSheetDetailService(new Query(), db, ContactID);
                        labSheetDetailFirst = (from c in db.LabSheetDetails select c).FirstOrDefault();
                    }

                    // ok with LabSheetDetail info
                    IActionResult jsonRet = labSheetDetailController.GetLabSheetDetailWithID(labSheetDetailFirst.LabSheetDetailID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(labSheetDetailFirst.LabSheetDetailID, ((LabSheetDetail)ret.Value).LabSheetDetailID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = labSheetDetailController.GetLabSheetDetailWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult labSheetDetailRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(labSheetDetailRet2);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void LabSheetDetail_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    LabSheetDetailController labSheetDetailController = new LabSheetDetailController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(labSheetDetailController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, labSheetDetailController.DatabaseType);

                    LabSheetDetail labSheetDetailFirst = new LabSheetDetail();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        LabSheetDetailService labSheetDetailService = new LabSheetDetailService(query, db, ContactID);
                        labSheetDetailFirst = (from c in db.LabSheetDetails select c).FirstOrDefault();
                    }

                    // ok with LabSheetDetail info
                    IActionResult jsonRet = labSheetDetailController.GetLabSheetDetailWithID(labSheetDetailFirst.LabSheetDetailID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    LabSheetDetail labSheetDetailRet = (LabSheetDetail)ret.Value;
                    Assert.Equal(labSheetDetailFirst.LabSheetDetailID, labSheetDetailRet.LabSheetDetailID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because LabSheetDetailID exist
                    IActionResult jsonRet2 = labSheetDetailController.Post(labSheetDetailRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added LabSheetDetail
                    labSheetDetailRet.LabSheetDetailID = 0;
                    IActionResult jsonRet3 = labSheetDetailController.Post(labSheetDetailRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = labSheetDetailController.Delete(labSheetDetailRet, LanguageRequest.ToString());
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
        public void LabSheetDetail_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    LabSheetDetailController labSheetDetailController = new LabSheetDetailController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(labSheetDetailController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, labSheetDetailController.DatabaseType);

                    LabSheetDetail labSheetDetailFirst = new LabSheetDetail();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        LabSheetDetailService labSheetDetailService = new LabSheetDetailService(query, db, ContactID);
                        labSheetDetailFirst = (from c in db.LabSheetDetails select c).FirstOrDefault();
                    }

                    // ok with LabSheetDetail info
                    IActionResult jsonRet = labSheetDetailController.GetLabSheetDetailWithID(labSheetDetailFirst.LabSheetDetailID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    LabSheetDetail labSheetDetailRet = (LabSheetDetail)Ret.Value;
                    Assert.Equal(labSheetDetailFirst.LabSheetDetailID, labSheetDetailRet.LabSheetDetailID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = labSheetDetailController.Put(labSheetDetailRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult labSheetDetailRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(labSheetDetailRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because LabSheetDetailID of 0 does not exist
                    labSheetDetailRet.LabSheetDetailID = 0;
                    IActionResult jsonRet3 = labSheetDetailController.Put(labSheetDetailRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult labSheetDetailRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(labSheetDetailRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void LabSheetDetail_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    LabSheetDetailController labSheetDetailController = new LabSheetDetailController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(labSheetDetailController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, labSheetDetailController.DatabaseType);

                    LabSheetDetail labSheetDetailFirst = new LabSheetDetail();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        LabSheetDetailService labSheetDetailService = new LabSheetDetailService(query, db, ContactID);
                        labSheetDetailFirst = (from c in db.LabSheetDetails select c).FirstOrDefault();
                    }

                    // ok with LabSheetDetail info
                    IActionResult jsonRet = labSheetDetailController.GetLabSheetDetailWithID(labSheetDetailFirst.LabSheetDetailID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    LabSheetDetail labSheetDetailRet = (LabSheetDetail)Ret.Value;
                    Assert.Equal(labSheetDetailFirst.LabSheetDetailID, labSheetDetailRet.LabSheetDetailID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added LabSheetDetail
                    labSheetDetailRet.LabSheetDetailID = 0;
                    IActionResult jsonRet3 = labSheetDetailController.Post(labSheetDetailRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    LabSheetDetail labSheetDetail = (LabSheetDetail)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = labSheetDetailController.Delete(labSheetDetailRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because LabSheetDetailID of 0 does not exist
                    labSheetDetailRet.LabSheetDetailID = 0;
                    IActionResult jsonRet4 = labSheetDetailController.Delete(labSheetDetailRet, LanguageRequest.ToString());
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
