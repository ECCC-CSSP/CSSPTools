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
    public partial class MWQMRunLanguageControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MWQMRunLanguageControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void MWQMRunLanguage_Controller_GetMWQMRunLanguageList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMRunLanguageController mwqmRunLanguageController = new MWQMRunLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mwqmRunLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mwqmRunLanguageController.DatabaseType);

                    MWQMRunLanguage mwqmRunLanguageFirst = new MWQMRunLanguage();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        MWQMRunLanguageService mwqmRunLanguageService = new MWQMRunLanguageService(query, db, ContactID);
                        mwqmRunLanguageFirst = (from c in db.MWQMRunLanguages select c).FirstOrDefault();
                        count = (from c in db.MWQMRunLanguages select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with MWQMRunLanguage info
                    IActionResult jsonRet = mwqmRunLanguageController.GetMWQMRunLanguageList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(mwqmRunLanguageFirst.MWQMRunLanguageID, ((List<MWQMRunLanguage>)ret.Value)[0].MWQMRunLanguageID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<MWQMRunLanguage>)ret.Value).Count);

                    List<MWQMRunLanguage> mwqmRunLanguageList = new List<MWQMRunLanguage>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        MWQMRunLanguageService mwqmRunLanguageService = new MWQMRunLanguageService(query, db, ContactID);
                        mwqmRunLanguageList = (from c in db.MWQMRunLanguages select c).OrderBy(c => c.MWQMRunLanguageID).Skip(0).Take(2).ToList();
                        count = (from c in db.MWQMRunLanguages select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with MWQMRunLanguage info
                        jsonRet = mwqmRunLanguageController.GetMWQMRunLanguageList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(mwqmRunLanguageList[0].MWQMRunLanguageID, ((List<MWQMRunLanguage>)ret.Value)[0].MWQMRunLanguageID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<MWQMRunLanguage>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with MWQMRunLanguage info
                           IActionResult jsonRet2 = mwqmRunLanguageController.GetMWQMRunLanguageList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(mwqmRunLanguageList[1].MWQMRunLanguageID, ((List<MWQMRunLanguage>)ret2.Value)[0].MWQMRunLanguageID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<MWQMRunLanguage>)ret2.Value).Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void MWQMRunLanguage_Controller_GetMWQMRunLanguageWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMRunLanguageController mwqmRunLanguageController = new MWQMRunLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mwqmRunLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mwqmRunLanguageController.DatabaseType);

                    MWQMRunLanguage mwqmRunLanguageFirst = new MWQMRunLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        MWQMRunLanguageService mwqmRunLanguageService = new MWQMRunLanguageService(new Query(), db, ContactID);
                        mwqmRunLanguageFirst = (from c in db.MWQMRunLanguages select c).FirstOrDefault();
                    }

                    // ok with MWQMRunLanguage info
                    IActionResult jsonRet = mwqmRunLanguageController.GetMWQMRunLanguageWithID(mwqmRunLanguageFirst.MWQMRunLanguageID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(mwqmRunLanguageFirst.MWQMRunLanguageID, ((MWQMRunLanguage)ret.Value).MWQMRunLanguageID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = mwqmRunLanguageController.GetMWQMRunLanguageWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult mwqmRunLanguageRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(mwqmRunLanguageRet2);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void MWQMRunLanguage_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMRunLanguageController mwqmRunLanguageController = new MWQMRunLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mwqmRunLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mwqmRunLanguageController.DatabaseType);

                    MWQMRunLanguage mwqmRunLanguageFirst = new MWQMRunLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MWQMRunLanguageService mwqmRunLanguageService = new MWQMRunLanguageService(query, db, ContactID);
                        mwqmRunLanguageFirst = (from c in db.MWQMRunLanguages select c).FirstOrDefault();
                    }

                    // ok with MWQMRunLanguage info
                    IActionResult jsonRet = mwqmRunLanguageController.GetMWQMRunLanguageWithID(mwqmRunLanguageFirst.MWQMRunLanguageID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    MWQMRunLanguage mwqmRunLanguageRet = (MWQMRunLanguage)ret.Value;
                    Assert.Equal(mwqmRunLanguageFirst.MWQMRunLanguageID, mwqmRunLanguageRet.MWQMRunLanguageID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because MWQMRunLanguageID exist
                    IActionResult jsonRet2 = mwqmRunLanguageController.Post(mwqmRunLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added MWQMRunLanguage
                    mwqmRunLanguageRet.MWQMRunLanguageID = 0;
                    IActionResult jsonRet3 = mwqmRunLanguageController.Post(mwqmRunLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = mwqmRunLanguageController.Delete(mwqmRunLanguageRet, LanguageRequest.ToString());
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
        public void MWQMRunLanguage_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMRunLanguageController mwqmRunLanguageController = new MWQMRunLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mwqmRunLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mwqmRunLanguageController.DatabaseType);

                    MWQMRunLanguage mwqmRunLanguageFirst = new MWQMRunLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        MWQMRunLanguageService mwqmRunLanguageService = new MWQMRunLanguageService(query, db, ContactID);
                        mwqmRunLanguageFirst = (from c in db.MWQMRunLanguages select c).FirstOrDefault();
                    }

                    // ok with MWQMRunLanguage info
                    IActionResult jsonRet = mwqmRunLanguageController.GetMWQMRunLanguageWithID(mwqmRunLanguageFirst.MWQMRunLanguageID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    MWQMRunLanguage mwqmRunLanguageRet = (MWQMRunLanguage)Ret.Value;
                    Assert.Equal(mwqmRunLanguageFirst.MWQMRunLanguageID, mwqmRunLanguageRet.MWQMRunLanguageID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = mwqmRunLanguageController.Put(mwqmRunLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult mwqmRunLanguageRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(mwqmRunLanguageRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because MWQMRunLanguageID of 0 does not exist
                    mwqmRunLanguageRet.MWQMRunLanguageID = 0;
                    IActionResult jsonRet3 = mwqmRunLanguageController.Put(mwqmRunLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult mwqmRunLanguageRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(mwqmRunLanguageRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void MWQMRunLanguage_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMRunLanguageController mwqmRunLanguageController = new MWQMRunLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mwqmRunLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mwqmRunLanguageController.DatabaseType);

                    MWQMRunLanguage mwqmRunLanguageFirst = new MWQMRunLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MWQMRunLanguageService mwqmRunLanguageService = new MWQMRunLanguageService(query, db, ContactID);
                        mwqmRunLanguageFirst = (from c in db.MWQMRunLanguages select c).FirstOrDefault();
                    }

                    // ok with MWQMRunLanguage info
                    IActionResult jsonRet = mwqmRunLanguageController.GetMWQMRunLanguageWithID(mwqmRunLanguageFirst.MWQMRunLanguageID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    MWQMRunLanguage mwqmRunLanguageRet = (MWQMRunLanguage)Ret.Value;
                    Assert.Equal(mwqmRunLanguageFirst.MWQMRunLanguageID, mwqmRunLanguageRet.MWQMRunLanguageID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added MWQMRunLanguage
                    mwqmRunLanguageRet.MWQMRunLanguageID = 0;
                    IActionResult jsonRet3 = mwqmRunLanguageController.Post(mwqmRunLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    MWQMRunLanguage mwqmRunLanguage = (MWQMRunLanguage)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = mwqmRunLanguageController.Delete(mwqmRunLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because MWQMRunLanguageID of 0 does not exist
                    mwqmRunLanguageRet.MWQMRunLanguageID = 0;
                    IActionResult jsonRet4 = mwqmRunLanguageController.Delete(mwqmRunLanguageRet, LanguageRequest.ToString());
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
