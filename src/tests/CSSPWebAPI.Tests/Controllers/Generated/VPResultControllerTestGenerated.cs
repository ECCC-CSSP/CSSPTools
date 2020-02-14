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
    public partial class VPResultControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public VPResultControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void VPResult_Controller_GetVPResultList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    VPResultController vpResultController = new VPResultController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(vpResultController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, vpResultController.DatabaseType);

                    VPResult vpResultFirst = new VPResult();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        VPResultService vpResultService = new VPResultService(query, db, ContactID);
                        vpResultFirst = (from c in db.VPResults select c).FirstOrDefault();
                        count = (from c in db.VPResults select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with VPResult info
                    IActionResult jsonRet = vpResultController.GetVPResultList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(vpResultFirst.VPResultID, ((List<VPResult>)ret.Value)[0].VPResultID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<VPResult>)ret.Value).Count);

                    List<VPResult> vpResultList = new List<VPResult>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        VPResultService vpResultService = new VPResultService(query, db, ContactID);
                        vpResultList = (from c in db.VPResults select c).OrderBy(c => c.VPResultID).Skip(0).Take(2).ToList();
                        count = (from c in db.VPResults select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with VPResult info
                        jsonRet = vpResultController.GetVPResultList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(vpResultList[0].VPResultID, ((List<VPResult>)ret.Value)[0].VPResultID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<VPResult>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with VPResult info
                           IActionResult jsonRet2 = vpResultController.GetVPResultList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(vpResultList[1].VPResultID, ((List<VPResult>)ret2.Value)[0].VPResultID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<VPResult>)ret2.Value).Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void VPResult_Controller_GetVPResultWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    VPResultController vpResultController = new VPResultController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(vpResultController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, vpResultController.DatabaseType);

                    VPResult vpResultFirst = new VPResult();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        VPResultService vpResultService = new VPResultService(new Query(), db, ContactID);
                        vpResultFirst = (from c in db.VPResults select c).FirstOrDefault();
                    }

                    // ok with VPResult info
                    IActionResult jsonRet = vpResultController.GetVPResultWithID(vpResultFirst.VPResultID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(vpResultFirst.VPResultID, ((VPResult)ret.Value).VPResultID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = vpResultController.GetVPResultWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult vpResultRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(vpResultRet2);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void VPResult_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    VPResultController vpResultController = new VPResultController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(vpResultController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, vpResultController.DatabaseType);

                    VPResult vpResultLast = new VPResult();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        VPResultService vpResultService = new VPResultService(query, db, ContactID);
                        vpResultLast = (from c in db.VPResults select c).FirstOrDefault();
                    }

                    // ok with VPResult info
                    IActionResult jsonRet = vpResultController.GetVPResultWithID(vpResultLast.VPResultID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    VPResult vpResultRet = (VPResult)ret.Value;
                    Assert.Equal(vpResultLast.VPResultID, vpResultRet.VPResultID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because VPResultID exist
                    IActionResult jsonRet2 = vpResultController.Post(vpResultRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added VPResult
                    vpResultRet.VPResultID = 0;
                    IActionResult jsonRet3 = vpResultController.Post(vpResultRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = vpResultController.Delete(vpResultRet, LanguageRequest.ToString());
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
        public void VPResult_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    VPResultController vpResultController = new VPResultController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(vpResultController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, vpResultController.DatabaseType);

                    VPResult vpResultLast = new VPResult();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        VPResultService vpResultService = new VPResultService(query, db, ContactID);
                        vpResultLast = (from c in db.VPResults select c).FirstOrDefault();
                    }

                    // ok with VPResult info
                    IActionResult jsonRet = vpResultController.GetVPResultWithID(vpResultLast.VPResultID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    VPResult vpResultRet = (VPResult)Ret.Value;
                    Assert.Equal(vpResultLast.VPResultID, vpResultRet.VPResultID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = vpResultController.Put(vpResultRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult vpResultRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(vpResultRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because VPResultID of 0 does not exist
                    vpResultRet.VPResultID = 0;
                    IActionResult jsonRet3 = vpResultController.Put(vpResultRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult vpResultRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(vpResultRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void VPResult_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    VPResultController vpResultController = new VPResultController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(vpResultController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, vpResultController.DatabaseType);

                    VPResult vpResultLast = new VPResult();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        VPResultService vpResultService = new VPResultService(query, db, ContactID);
                        vpResultLast = (from c in db.VPResults select c).FirstOrDefault();
                    }

                    // ok with VPResult info
                    IActionResult jsonRet = vpResultController.GetVPResultWithID(vpResultLast.VPResultID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    VPResult vpResultRet = (VPResult)Ret.Value;
                    Assert.Equal(vpResultLast.VPResultID, vpResultRet.VPResultID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added VPResult
                    vpResultRet.VPResultID = 0;
                    IActionResult jsonRet3 = vpResultController.Post(vpResultRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    VPResult vpResult = (VPResult)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = vpResultController.Delete(vpResultRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because VPResultID of 0 does not exist
                    vpResultRet.VPResultID = 0;
                    IActionResult jsonRet4 = vpResultController.Delete(vpResultRet, LanguageRequest.ToString());
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
