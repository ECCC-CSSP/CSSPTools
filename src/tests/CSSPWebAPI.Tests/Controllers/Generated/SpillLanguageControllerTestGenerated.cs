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
    public partial class SpillLanguageControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public SpillLanguageControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void SpillLanguage_Controller_GetSpillLanguageList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    SpillLanguageController spillLanguageController = new SpillLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(spillLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, spillLanguageController.DatabaseType);

                    SpillLanguage spillLanguageFirst = new SpillLanguage();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        SpillLanguageService spillLanguageService = new SpillLanguageService(query, db, ContactID);
                        spillLanguageFirst = (from c in db.SpillLanguages select c).FirstOrDefault();
                        count = (from c in db.SpillLanguages select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with SpillLanguage info
                    IActionResult jsonRet = spillLanguageController.GetSpillLanguageList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(spillLanguageFirst.SpillLanguageID, ((List<SpillLanguage>)ret.Value)[0].SpillLanguageID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<SpillLanguage>)ret.Value).Count);

                    List<SpillLanguage> spillLanguageList = new List<SpillLanguage>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        SpillLanguageService spillLanguageService = new SpillLanguageService(query, db, ContactID);
                        spillLanguageList = (from c in db.SpillLanguages select c).OrderBy(c => c.SpillLanguageID).Skip(0).Take(2).ToList();
                        count = (from c in db.SpillLanguages select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with SpillLanguage info
                        jsonRet = spillLanguageController.GetSpillLanguageList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(spillLanguageList[0].SpillLanguageID, ((List<SpillLanguage>)ret.Value)[0].SpillLanguageID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<SpillLanguage>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with SpillLanguage info
                           IActionResult jsonRet2 = spillLanguageController.GetSpillLanguageList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(spillLanguageList[1].SpillLanguageID, ((List<SpillLanguage>)ret2.Value)[0].SpillLanguageID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<SpillLanguage>)ret2.Value).Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void SpillLanguage_Controller_GetSpillLanguageWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    SpillLanguageController spillLanguageController = new SpillLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(spillLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, spillLanguageController.DatabaseType);

                    SpillLanguage spillLanguageFirst = new SpillLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        SpillLanguageService spillLanguageService = new SpillLanguageService(new Query(), db, ContactID);
                        spillLanguageFirst = (from c in db.SpillLanguages select c).FirstOrDefault();
                    }

                    // ok with SpillLanguage info
                    IActionResult jsonRet = spillLanguageController.GetSpillLanguageWithID(spillLanguageFirst.SpillLanguageID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(spillLanguageFirst.SpillLanguageID, ((SpillLanguage)ret.Value).SpillLanguageID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = spillLanguageController.GetSpillLanguageWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult spillLanguageRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(spillLanguageRet2);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void SpillLanguage_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    SpillLanguageController spillLanguageController = new SpillLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(spillLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, spillLanguageController.DatabaseType);

                    SpillLanguage spillLanguageLast = new SpillLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        SpillLanguageService spillLanguageService = new SpillLanguageService(query, db, ContactID);
                        spillLanguageLast = (from c in db.SpillLanguages select c).FirstOrDefault();
                    }

                    // ok with SpillLanguage info
                    IActionResult jsonRet = spillLanguageController.GetSpillLanguageWithID(spillLanguageLast.SpillLanguageID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    SpillLanguage spillLanguageRet = (SpillLanguage)ret.Value;
                    Assert.Equal(spillLanguageLast.SpillLanguageID, spillLanguageRet.SpillLanguageID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because SpillLanguageID exist
                    IActionResult jsonRet2 = spillLanguageController.Post(spillLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added SpillLanguage
                    spillLanguageRet.SpillLanguageID = 0;
                    IActionResult jsonRet3 = spillLanguageController.Post(spillLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = spillLanguageController.Delete(spillLanguageRet, LanguageRequest.ToString());
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
        public void SpillLanguage_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    SpillLanguageController spillLanguageController = new SpillLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(spillLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, spillLanguageController.DatabaseType);

                    SpillLanguage spillLanguageLast = new SpillLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        SpillLanguageService spillLanguageService = new SpillLanguageService(query, db, ContactID);
                        spillLanguageLast = (from c in db.SpillLanguages select c).FirstOrDefault();
                    }

                    // ok with SpillLanguage info
                    IActionResult jsonRet = spillLanguageController.GetSpillLanguageWithID(spillLanguageLast.SpillLanguageID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    SpillLanguage spillLanguageRet = (SpillLanguage)Ret.Value;
                    Assert.Equal(spillLanguageLast.SpillLanguageID, spillLanguageRet.SpillLanguageID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = spillLanguageController.Put(spillLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult spillLanguageRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(spillLanguageRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because SpillLanguageID of 0 does not exist
                    spillLanguageRet.SpillLanguageID = 0;
                    IActionResult jsonRet3 = spillLanguageController.Put(spillLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult spillLanguageRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(spillLanguageRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void SpillLanguage_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    SpillLanguageController spillLanguageController = new SpillLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(spillLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, spillLanguageController.DatabaseType);

                    SpillLanguage spillLanguageLast = new SpillLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        SpillLanguageService spillLanguageService = new SpillLanguageService(query, db, ContactID);
                        spillLanguageLast = (from c in db.SpillLanguages select c).FirstOrDefault();
                    }

                    // ok with SpillLanguage info
                    IActionResult jsonRet = spillLanguageController.GetSpillLanguageWithID(spillLanguageLast.SpillLanguageID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    SpillLanguage spillLanguageRet = (SpillLanguage)Ret.Value;
                    Assert.Equal(spillLanguageLast.SpillLanguageID, spillLanguageRet.SpillLanguageID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added SpillLanguage
                    spillLanguageRet.SpillLanguageID = 0;
                    IActionResult jsonRet3 = spillLanguageController.Post(spillLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    SpillLanguage spillLanguage = (SpillLanguage)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = spillLanguageController.Delete(spillLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because SpillLanguageID of 0 does not exist
                    spillLanguageRet.SpillLanguageID = 0;
                    IActionResult jsonRet4 = spillLanguageController.Delete(spillLanguageRet, LanguageRequest.ToString());
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
