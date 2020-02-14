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
    public partial class MikeScenarioResultControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MikeScenarioResultControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void MikeScenarioResult_Controller_GetMikeScenarioResultList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MikeScenarioResultController mikeScenarioResultController = new MikeScenarioResultController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mikeScenarioResultController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mikeScenarioResultController.DatabaseType);

                    MikeScenarioResult mikeScenarioResultFirst = new MikeScenarioResult();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        MikeScenarioResultService mikeScenarioResultService = new MikeScenarioResultService(query, db, ContactID);
                        mikeScenarioResultFirst = (from c in db.MikeScenarioResults select c).FirstOrDefault();
                        count = (from c in db.MikeScenarioResults select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with MikeScenarioResult info
                    IActionResult jsonRet = mikeScenarioResultController.GetMikeScenarioResultList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(mikeScenarioResultFirst.MikeScenarioResultID, ((List<MikeScenarioResult>)ret.Value)[0].MikeScenarioResultID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<MikeScenarioResult>)ret.Value).Count);

                    List<MikeScenarioResult> mikeScenarioResultList = new List<MikeScenarioResult>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        MikeScenarioResultService mikeScenarioResultService = new MikeScenarioResultService(query, db, ContactID);
                        mikeScenarioResultList = (from c in db.MikeScenarioResults select c).OrderBy(c => c.MikeScenarioResultID).Skip(0).Take(2).ToList();
                        count = (from c in db.MikeScenarioResults select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with MikeScenarioResult info
                        jsonRet = mikeScenarioResultController.GetMikeScenarioResultList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(mikeScenarioResultList[0].MikeScenarioResultID, ((List<MikeScenarioResult>)ret.Value)[0].MikeScenarioResultID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<MikeScenarioResult>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with MikeScenarioResult info
                           IActionResult jsonRet2 = mikeScenarioResultController.GetMikeScenarioResultList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(mikeScenarioResultList[1].MikeScenarioResultID, ((List<MikeScenarioResult>)ret2.Value)[0].MikeScenarioResultID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<MikeScenarioResult>)ret2.Value).Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void MikeScenarioResult_Controller_GetMikeScenarioResultWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MikeScenarioResultController mikeScenarioResultController = new MikeScenarioResultController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mikeScenarioResultController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mikeScenarioResultController.DatabaseType);

                    MikeScenarioResult mikeScenarioResultFirst = new MikeScenarioResult();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        MikeScenarioResultService mikeScenarioResultService = new MikeScenarioResultService(new Query(), db, ContactID);
                        mikeScenarioResultFirst = (from c in db.MikeScenarioResults select c).FirstOrDefault();
                    }

                    // ok with MikeScenarioResult info
                    IActionResult jsonRet = mikeScenarioResultController.GetMikeScenarioResultWithID(mikeScenarioResultFirst.MikeScenarioResultID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(mikeScenarioResultFirst.MikeScenarioResultID, ((MikeScenarioResult)ret.Value).MikeScenarioResultID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = mikeScenarioResultController.GetMikeScenarioResultWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult mikeScenarioResultRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(mikeScenarioResultRet2);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void MikeScenarioResult_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MikeScenarioResultController mikeScenarioResultController = new MikeScenarioResultController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mikeScenarioResultController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mikeScenarioResultController.DatabaseType);

                    MikeScenarioResult mikeScenarioResultLast = new MikeScenarioResult();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MikeScenarioResultService mikeScenarioResultService = new MikeScenarioResultService(query, db, ContactID);
                        mikeScenarioResultLast = (from c in db.MikeScenarioResults select c).FirstOrDefault();
                    }

                    // ok with MikeScenarioResult info
                    IActionResult jsonRet = mikeScenarioResultController.GetMikeScenarioResultWithID(mikeScenarioResultLast.MikeScenarioResultID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    MikeScenarioResult mikeScenarioResultRet = (MikeScenarioResult)ret.Value;
                    Assert.Equal(mikeScenarioResultLast.MikeScenarioResultID, mikeScenarioResultRet.MikeScenarioResultID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because MikeScenarioResultID exist
                    IActionResult jsonRet2 = mikeScenarioResultController.Post(mikeScenarioResultRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added MikeScenarioResult
                    mikeScenarioResultRet.MikeScenarioResultID = 0;
                    IActionResult jsonRet3 = mikeScenarioResultController.Post(mikeScenarioResultRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = mikeScenarioResultController.Delete(mikeScenarioResultRet, LanguageRequest.ToString());
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
        public void MikeScenarioResult_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MikeScenarioResultController mikeScenarioResultController = new MikeScenarioResultController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mikeScenarioResultController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mikeScenarioResultController.DatabaseType);

                    MikeScenarioResult mikeScenarioResultLast = new MikeScenarioResult();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        MikeScenarioResultService mikeScenarioResultService = new MikeScenarioResultService(query, db, ContactID);
                        mikeScenarioResultLast = (from c in db.MikeScenarioResults select c).FirstOrDefault();
                    }

                    // ok with MikeScenarioResult info
                    IActionResult jsonRet = mikeScenarioResultController.GetMikeScenarioResultWithID(mikeScenarioResultLast.MikeScenarioResultID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    MikeScenarioResult mikeScenarioResultRet = (MikeScenarioResult)Ret.Value;
                    Assert.Equal(mikeScenarioResultLast.MikeScenarioResultID, mikeScenarioResultRet.MikeScenarioResultID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = mikeScenarioResultController.Put(mikeScenarioResultRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult mikeScenarioResultRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(mikeScenarioResultRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because MikeScenarioResultID of 0 does not exist
                    mikeScenarioResultRet.MikeScenarioResultID = 0;
                    IActionResult jsonRet3 = mikeScenarioResultController.Put(mikeScenarioResultRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult mikeScenarioResultRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(mikeScenarioResultRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void MikeScenarioResult_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MikeScenarioResultController mikeScenarioResultController = new MikeScenarioResultController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mikeScenarioResultController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mikeScenarioResultController.DatabaseType);

                    MikeScenarioResult mikeScenarioResultLast = new MikeScenarioResult();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MikeScenarioResultService mikeScenarioResultService = new MikeScenarioResultService(query, db, ContactID);
                        mikeScenarioResultLast = (from c in db.MikeScenarioResults select c).FirstOrDefault();
                    }

                    // ok with MikeScenarioResult info
                    IActionResult jsonRet = mikeScenarioResultController.GetMikeScenarioResultWithID(mikeScenarioResultLast.MikeScenarioResultID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    MikeScenarioResult mikeScenarioResultRet = (MikeScenarioResult)Ret.Value;
                    Assert.Equal(mikeScenarioResultLast.MikeScenarioResultID, mikeScenarioResultRet.MikeScenarioResultID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added MikeScenarioResult
                    mikeScenarioResultRet.MikeScenarioResultID = 0;
                    IActionResult jsonRet3 = mikeScenarioResultController.Post(mikeScenarioResultRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    MikeScenarioResult mikeScenarioResult = (MikeScenarioResult)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = mikeScenarioResultController.Delete(mikeScenarioResultRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because MikeScenarioResultID of 0 does not exist
                    mikeScenarioResultRet.MikeScenarioResultID = 0;
                    IActionResult jsonRet4 = mikeScenarioResultController.Delete(mikeScenarioResultRet, LanguageRequest.ToString());
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
