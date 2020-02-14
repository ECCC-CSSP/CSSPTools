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
    public partial class MWQMSampleLanguageControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MWQMSampleLanguageControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void MWQMSampleLanguage_Controller_GetMWQMSampleLanguageList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMSampleLanguageController mwqmSampleLanguageController = new MWQMSampleLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mwqmSampleLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mwqmSampleLanguageController.DatabaseType);

                    MWQMSampleLanguage mwqmSampleLanguageFirst = new MWQMSampleLanguage();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        MWQMSampleLanguageService mwqmSampleLanguageService = new MWQMSampleLanguageService(query, db, ContactID);
                        mwqmSampleLanguageFirst = (from c in db.MWQMSampleLanguages select c).FirstOrDefault();
                        count = (from c in db.MWQMSampleLanguages select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with MWQMSampleLanguage info
                    IActionResult jsonRet = mwqmSampleLanguageController.GetMWQMSampleLanguageList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(mwqmSampleLanguageFirst.MWQMSampleLanguageID, ((List<MWQMSampleLanguage>)ret.Value)[0].MWQMSampleLanguageID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<MWQMSampleLanguage>)ret.Value).Count);

                    List<MWQMSampleLanguage> mwqmSampleLanguageList = new List<MWQMSampleLanguage>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        MWQMSampleLanguageService mwqmSampleLanguageService = new MWQMSampleLanguageService(query, db, ContactID);
                        mwqmSampleLanguageList = (from c in db.MWQMSampleLanguages select c).OrderBy(c => c.MWQMSampleLanguageID).Skip(0).Take(2).ToList();
                        count = (from c in db.MWQMSampleLanguages select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with MWQMSampleLanguage info
                        jsonRet = mwqmSampleLanguageController.GetMWQMSampleLanguageList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(mwqmSampleLanguageList[0].MWQMSampleLanguageID, ((List<MWQMSampleLanguage>)ret.Value)[0].MWQMSampleLanguageID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<MWQMSampleLanguage>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with MWQMSampleLanguage info
                           IActionResult jsonRet2 = mwqmSampleLanguageController.GetMWQMSampleLanguageList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(mwqmSampleLanguageList[1].MWQMSampleLanguageID, ((List<MWQMSampleLanguage>)ret2.Value)[0].MWQMSampleLanguageID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<MWQMSampleLanguage>)ret2.Value).Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void MWQMSampleLanguage_Controller_GetMWQMSampleLanguageWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMSampleLanguageController mwqmSampleLanguageController = new MWQMSampleLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mwqmSampleLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mwqmSampleLanguageController.DatabaseType);

                    MWQMSampleLanguage mwqmSampleLanguageFirst = new MWQMSampleLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        MWQMSampleLanguageService mwqmSampleLanguageService = new MWQMSampleLanguageService(new Query(), db, ContactID);
                        mwqmSampleLanguageFirst = (from c in db.MWQMSampleLanguages select c).FirstOrDefault();
                    }

                    // ok with MWQMSampleLanguage info
                    IActionResult jsonRet = mwqmSampleLanguageController.GetMWQMSampleLanguageWithID(mwqmSampleLanguageFirst.MWQMSampleLanguageID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(mwqmSampleLanguageFirst.MWQMSampleLanguageID, ((MWQMSampleLanguage)ret.Value).MWQMSampleLanguageID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = mwqmSampleLanguageController.GetMWQMSampleLanguageWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult mwqmSampleLanguageRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(mwqmSampleLanguageRet2);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void MWQMSampleLanguage_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMSampleLanguageController mwqmSampleLanguageController = new MWQMSampleLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mwqmSampleLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mwqmSampleLanguageController.DatabaseType);

                    MWQMSampleLanguage mwqmSampleLanguageLast = new MWQMSampleLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MWQMSampleLanguageService mwqmSampleLanguageService = new MWQMSampleLanguageService(query, db, ContactID);
                        mwqmSampleLanguageLast = (from c in db.MWQMSampleLanguages select c).FirstOrDefault();
                    }

                    // ok with MWQMSampleLanguage info
                    IActionResult jsonRet = mwqmSampleLanguageController.GetMWQMSampleLanguageWithID(mwqmSampleLanguageLast.MWQMSampleLanguageID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    MWQMSampleLanguage mwqmSampleLanguageRet = (MWQMSampleLanguage)ret.Value;
                    Assert.Equal(mwqmSampleLanguageLast.MWQMSampleLanguageID, mwqmSampleLanguageRet.MWQMSampleLanguageID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because MWQMSampleLanguageID exist
                    IActionResult jsonRet2 = mwqmSampleLanguageController.Post(mwqmSampleLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added MWQMSampleLanguage
                    mwqmSampleLanguageRet.MWQMSampleLanguageID = 0;
                    IActionResult jsonRet3 = mwqmSampleLanguageController.Post(mwqmSampleLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = mwqmSampleLanguageController.Delete(mwqmSampleLanguageRet, LanguageRequest.ToString());
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
        public void MWQMSampleLanguage_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMSampleLanguageController mwqmSampleLanguageController = new MWQMSampleLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mwqmSampleLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mwqmSampleLanguageController.DatabaseType);

                    MWQMSampleLanguage mwqmSampleLanguageLast = new MWQMSampleLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        MWQMSampleLanguageService mwqmSampleLanguageService = new MWQMSampleLanguageService(query, db, ContactID);
                        mwqmSampleLanguageLast = (from c in db.MWQMSampleLanguages select c).FirstOrDefault();
                    }

                    // ok with MWQMSampleLanguage info
                    IActionResult jsonRet = mwqmSampleLanguageController.GetMWQMSampleLanguageWithID(mwqmSampleLanguageLast.MWQMSampleLanguageID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    MWQMSampleLanguage mwqmSampleLanguageRet = (MWQMSampleLanguage)Ret.Value;
                    Assert.Equal(mwqmSampleLanguageLast.MWQMSampleLanguageID, mwqmSampleLanguageRet.MWQMSampleLanguageID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = mwqmSampleLanguageController.Put(mwqmSampleLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult mwqmSampleLanguageRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(mwqmSampleLanguageRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because MWQMSampleLanguageID of 0 does not exist
                    mwqmSampleLanguageRet.MWQMSampleLanguageID = 0;
                    IActionResult jsonRet3 = mwqmSampleLanguageController.Put(mwqmSampleLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult mwqmSampleLanguageRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(mwqmSampleLanguageRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void MWQMSampleLanguage_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMSampleLanguageController mwqmSampleLanguageController = new MWQMSampleLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mwqmSampleLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mwqmSampleLanguageController.DatabaseType);

                    MWQMSampleLanguage mwqmSampleLanguageLast = new MWQMSampleLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MWQMSampleLanguageService mwqmSampleLanguageService = new MWQMSampleLanguageService(query, db, ContactID);
                        mwqmSampleLanguageLast = (from c in db.MWQMSampleLanguages select c).FirstOrDefault();
                    }

                    // ok with MWQMSampleLanguage info
                    IActionResult jsonRet = mwqmSampleLanguageController.GetMWQMSampleLanguageWithID(mwqmSampleLanguageLast.MWQMSampleLanguageID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    MWQMSampleLanguage mwqmSampleLanguageRet = (MWQMSampleLanguage)Ret.Value;
                    Assert.Equal(mwqmSampleLanguageLast.MWQMSampleLanguageID, mwqmSampleLanguageRet.MWQMSampleLanguageID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added MWQMSampleLanguage
                    mwqmSampleLanguageRet.MWQMSampleLanguageID = 0;
                    IActionResult jsonRet3 = mwqmSampleLanguageController.Post(mwqmSampleLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    MWQMSampleLanguage mwqmSampleLanguage = (MWQMSampleLanguage)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = mwqmSampleLanguageController.Delete(mwqmSampleLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because MWQMSampleLanguageID of 0 does not exist
                    mwqmSampleLanguageRet.MWQMSampleLanguageID = 0;
                    IActionResult jsonRet4 = mwqmSampleLanguageController.Delete(mwqmSampleLanguageRet, LanguageRequest.ToString());
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
