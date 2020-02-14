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
    public partial class MWQMSubsectorLanguageControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MWQMSubsectorLanguageControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void MWQMSubsectorLanguage_Controller_GetMWQMSubsectorLanguageList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMSubsectorLanguageController mwqmSubsectorLanguageController = new MWQMSubsectorLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mwqmSubsectorLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mwqmSubsectorLanguageController.DatabaseType);

                    MWQMSubsectorLanguage mwqmSubsectorLanguageFirst = new MWQMSubsectorLanguage();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        MWQMSubsectorLanguageService mwqmSubsectorLanguageService = new MWQMSubsectorLanguageService(query, db, ContactID);
                        mwqmSubsectorLanguageFirst = (from c in db.MWQMSubsectorLanguages select c).FirstOrDefault();
                        count = (from c in db.MWQMSubsectorLanguages select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with MWQMSubsectorLanguage info
                    IActionResult jsonRet = mwqmSubsectorLanguageController.GetMWQMSubsectorLanguageList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(mwqmSubsectorLanguageFirst.MWQMSubsectorLanguageID, ((List<MWQMSubsectorLanguage>)ret.Value)[0].MWQMSubsectorLanguageID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<MWQMSubsectorLanguage>)ret.Value).Count);

                    List<MWQMSubsectorLanguage> mwqmSubsectorLanguageList = new List<MWQMSubsectorLanguage>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        MWQMSubsectorLanguageService mwqmSubsectorLanguageService = new MWQMSubsectorLanguageService(query, db, ContactID);
                        mwqmSubsectorLanguageList = (from c in db.MWQMSubsectorLanguages select c).OrderBy(c => c.MWQMSubsectorLanguageID).Skip(0).Take(2).ToList();
                        count = (from c in db.MWQMSubsectorLanguages select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with MWQMSubsectorLanguage info
                        jsonRet = mwqmSubsectorLanguageController.GetMWQMSubsectorLanguageList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(mwqmSubsectorLanguageList[0].MWQMSubsectorLanguageID, ((List<MWQMSubsectorLanguage>)ret.Value)[0].MWQMSubsectorLanguageID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<MWQMSubsectorLanguage>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with MWQMSubsectorLanguage info
                           IActionResult jsonRet2 = mwqmSubsectorLanguageController.GetMWQMSubsectorLanguageList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(mwqmSubsectorLanguageList[1].MWQMSubsectorLanguageID, ((List<MWQMSubsectorLanguage>)ret2.Value)[0].MWQMSubsectorLanguageID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<MWQMSubsectorLanguage>)ret2.Value).Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void MWQMSubsectorLanguage_Controller_GetMWQMSubsectorLanguageWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMSubsectorLanguageController mwqmSubsectorLanguageController = new MWQMSubsectorLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mwqmSubsectorLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mwqmSubsectorLanguageController.DatabaseType);

                    MWQMSubsectorLanguage mwqmSubsectorLanguageFirst = new MWQMSubsectorLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        MWQMSubsectorLanguageService mwqmSubsectorLanguageService = new MWQMSubsectorLanguageService(new Query(), db, ContactID);
                        mwqmSubsectorLanguageFirst = (from c in db.MWQMSubsectorLanguages select c).FirstOrDefault();
                    }

                    // ok with MWQMSubsectorLanguage info
                    IActionResult jsonRet = mwqmSubsectorLanguageController.GetMWQMSubsectorLanguageWithID(mwqmSubsectorLanguageFirst.MWQMSubsectorLanguageID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(mwqmSubsectorLanguageFirst.MWQMSubsectorLanguageID, ((MWQMSubsectorLanguage)ret.Value).MWQMSubsectorLanguageID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = mwqmSubsectorLanguageController.GetMWQMSubsectorLanguageWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult mwqmSubsectorLanguageRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(mwqmSubsectorLanguageRet2);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void MWQMSubsectorLanguage_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMSubsectorLanguageController mwqmSubsectorLanguageController = new MWQMSubsectorLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mwqmSubsectorLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mwqmSubsectorLanguageController.DatabaseType);

                    MWQMSubsectorLanguage mwqmSubsectorLanguageLast = new MWQMSubsectorLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MWQMSubsectorLanguageService mwqmSubsectorLanguageService = new MWQMSubsectorLanguageService(query, db, ContactID);
                        mwqmSubsectorLanguageLast = (from c in db.MWQMSubsectorLanguages select c).FirstOrDefault();
                    }

                    // ok with MWQMSubsectorLanguage info
                    IActionResult jsonRet = mwqmSubsectorLanguageController.GetMWQMSubsectorLanguageWithID(mwqmSubsectorLanguageLast.MWQMSubsectorLanguageID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    MWQMSubsectorLanguage mwqmSubsectorLanguageRet = (MWQMSubsectorLanguage)ret.Value;
                    Assert.Equal(mwqmSubsectorLanguageLast.MWQMSubsectorLanguageID, mwqmSubsectorLanguageRet.MWQMSubsectorLanguageID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because MWQMSubsectorLanguageID exist
                    IActionResult jsonRet2 = mwqmSubsectorLanguageController.Post(mwqmSubsectorLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added MWQMSubsectorLanguage
                    mwqmSubsectorLanguageRet.MWQMSubsectorLanguageID = 0;
                    IActionResult jsonRet3 = mwqmSubsectorLanguageController.Post(mwqmSubsectorLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = mwqmSubsectorLanguageController.Delete(mwqmSubsectorLanguageRet, LanguageRequest.ToString());
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
        public void MWQMSubsectorLanguage_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMSubsectorLanguageController mwqmSubsectorLanguageController = new MWQMSubsectorLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mwqmSubsectorLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mwqmSubsectorLanguageController.DatabaseType);

                    MWQMSubsectorLanguage mwqmSubsectorLanguageLast = new MWQMSubsectorLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        MWQMSubsectorLanguageService mwqmSubsectorLanguageService = new MWQMSubsectorLanguageService(query, db, ContactID);
                        mwqmSubsectorLanguageLast = (from c in db.MWQMSubsectorLanguages select c).FirstOrDefault();
                    }

                    // ok with MWQMSubsectorLanguage info
                    IActionResult jsonRet = mwqmSubsectorLanguageController.GetMWQMSubsectorLanguageWithID(mwqmSubsectorLanguageLast.MWQMSubsectorLanguageID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    MWQMSubsectorLanguage mwqmSubsectorLanguageRet = (MWQMSubsectorLanguage)Ret.Value;
                    Assert.Equal(mwqmSubsectorLanguageLast.MWQMSubsectorLanguageID, mwqmSubsectorLanguageRet.MWQMSubsectorLanguageID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = mwqmSubsectorLanguageController.Put(mwqmSubsectorLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult mwqmSubsectorLanguageRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(mwqmSubsectorLanguageRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because MWQMSubsectorLanguageID of 0 does not exist
                    mwqmSubsectorLanguageRet.MWQMSubsectorLanguageID = 0;
                    IActionResult jsonRet3 = mwqmSubsectorLanguageController.Put(mwqmSubsectorLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult mwqmSubsectorLanguageRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(mwqmSubsectorLanguageRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void MWQMSubsectorLanguage_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMSubsectorLanguageController mwqmSubsectorLanguageController = new MWQMSubsectorLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mwqmSubsectorLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mwqmSubsectorLanguageController.DatabaseType);

                    MWQMSubsectorLanguage mwqmSubsectorLanguageLast = new MWQMSubsectorLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MWQMSubsectorLanguageService mwqmSubsectorLanguageService = new MWQMSubsectorLanguageService(query, db, ContactID);
                        mwqmSubsectorLanguageLast = (from c in db.MWQMSubsectorLanguages select c).FirstOrDefault();
                    }

                    // ok with MWQMSubsectorLanguage info
                    IActionResult jsonRet = mwqmSubsectorLanguageController.GetMWQMSubsectorLanguageWithID(mwqmSubsectorLanguageLast.MWQMSubsectorLanguageID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    MWQMSubsectorLanguage mwqmSubsectorLanguageRet = (MWQMSubsectorLanguage)Ret.Value;
                    Assert.Equal(mwqmSubsectorLanguageLast.MWQMSubsectorLanguageID, mwqmSubsectorLanguageRet.MWQMSubsectorLanguageID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added MWQMSubsectorLanguage
                    mwqmSubsectorLanguageRet.MWQMSubsectorLanguageID = 0;
                    IActionResult jsonRet3 = mwqmSubsectorLanguageController.Post(mwqmSubsectorLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    MWQMSubsectorLanguage mwqmSubsectorLanguage = (MWQMSubsectorLanguage)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = mwqmSubsectorLanguageController.Delete(mwqmSubsectorLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because MWQMSubsectorLanguageID of 0 does not exist
                    mwqmSubsectorLanguageRet.MWQMSubsectorLanguageID = 0;
                    IActionResult jsonRet4 = mwqmSubsectorLanguageController.Delete(mwqmSubsectorLanguageRet, LanguageRequest.ToString());
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
