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
    public partial class InfrastructureLanguageControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public InfrastructureLanguageControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void InfrastructureLanguage_Controller_GetInfrastructureLanguageList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    InfrastructureLanguageController infrastructureLanguageController = new InfrastructureLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(infrastructureLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, infrastructureLanguageController.DatabaseType);

                    InfrastructureLanguage infrastructureLanguageFirst = new InfrastructureLanguage();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        InfrastructureLanguageService infrastructureLanguageService = new InfrastructureLanguageService(query, db, ContactID);
                        infrastructureLanguageFirst = (from c in db.InfrastructureLanguages select c).FirstOrDefault();
                        count = (from c in db.InfrastructureLanguages select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with InfrastructureLanguage info
                    IActionResult jsonRet = infrastructureLanguageController.GetInfrastructureLanguageList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(infrastructureLanguageFirst.InfrastructureLanguageID, ((List<InfrastructureLanguage>)ret.Value)[0].InfrastructureLanguageID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<InfrastructureLanguage>)ret.Value).Count);

                    List<InfrastructureLanguage> infrastructureLanguageList = new List<InfrastructureLanguage>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        InfrastructureLanguageService infrastructureLanguageService = new InfrastructureLanguageService(query, db, ContactID);
                        infrastructureLanguageList = (from c in db.InfrastructureLanguages select c).OrderBy(c => c.InfrastructureLanguageID).Skip(0).Take(2).ToList();
                        count = (from c in db.InfrastructureLanguages select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with InfrastructureLanguage info
                        jsonRet = infrastructureLanguageController.GetInfrastructureLanguageList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(infrastructureLanguageList[0].InfrastructureLanguageID, ((List<InfrastructureLanguage>)ret.Value)[0].InfrastructureLanguageID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<InfrastructureLanguage>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with InfrastructureLanguage info
                           IActionResult jsonRet2 = infrastructureLanguageController.GetInfrastructureLanguageList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(infrastructureLanguageList[1].InfrastructureLanguageID, ((List<InfrastructureLanguage>)ret2.Value)[0].InfrastructureLanguageID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<InfrastructureLanguage>)ret2.Value).Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void InfrastructureLanguage_Controller_GetInfrastructureLanguageWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    InfrastructureLanguageController infrastructureLanguageController = new InfrastructureLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(infrastructureLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, infrastructureLanguageController.DatabaseType);

                    InfrastructureLanguage infrastructureLanguageFirst = new InfrastructureLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        InfrastructureLanguageService infrastructureLanguageService = new InfrastructureLanguageService(new Query(), db, ContactID);
                        infrastructureLanguageFirst = (from c in db.InfrastructureLanguages select c).FirstOrDefault();
                    }

                    // ok with InfrastructureLanguage info
                    IActionResult jsonRet = infrastructureLanguageController.GetInfrastructureLanguageWithID(infrastructureLanguageFirst.InfrastructureLanguageID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(infrastructureLanguageFirst.InfrastructureLanguageID, ((InfrastructureLanguage)ret.Value).InfrastructureLanguageID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = infrastructureLanguageController.GetInfrastructureLanguageWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult infrastructureLanguageRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(infrastructureLanguageRet2);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void InfrastructureLanguage_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    InfrastructureLanguageController infrastructureLanguageController = new InfrastructureLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(infrastructureLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, infrastructureLanguageController.DatabaseType);

                    InfrastructureLanguage infrastructureLanguageLast = new InfrastructureLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        InfrastructureLanguageService infrastructureLanguageService = new InfrastructureLanguageService(query, db, ContactID);
                        infrastructureLanguageLast = (from c in db.InfrastructureLanguages select c).FirstOrDefault();
                    }

                    // ok with InfrastructureLanguage info
                    IActionResult jsonRet = infrastructureLanguageController.GetInfrastructureLanguageWithID(infrastructureLanguageLast.InfrastructureLanguageID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    InfrastructureLanguage infrastructureLanguageRet = (InfrastructureLanguage)ret.Value;
                    Assert.Equal(infrastructureLanguageLast.InfrastructureLanguageID, infrastructureLanguageRet.InfrastructureLanguageID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because InfrastructureLanguageID exist
                    IActionResult jsonRet2 = infrastructureLanguageController.Post(infrastructureLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added InfrastructureLanguage
                    infrastructureLanguageRet.InfrastructureLanguageID = 0;
                    IActionResult jsonRet3 = infrastructureLanguageController.Post(infrastructureLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = infrastructureLanguageController.Delete(infrastructureLanguageRet, LanguageRequest.ToString());
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
        public void InfrastructureLanguage_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    InfrastructureLanguageController infrastructureLanguageController = new InfrastructureLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(infrastructureLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, infrastructureLanguageController.DatabaseType);

                    InfrastructureLanguage infrastructureLanguageLast = new InfrastructureLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        InfrastructureLanguageService infrastructureLanguageService = new InfrastructureLanguageService(query, db, ContactID);
                        infrastructureLanguageLast = (from c in db.InfrastructureLanguages select c).FirstOrDefault();
                    }

                    // ok with InfrastructureLanguage info
                    IActionResult jsonRet = infrastructureLanguageController.GetInfrastructureLanguageWithID(infrastructureLanguageLast.InfrastructureLanguageID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    InfrastructureLanguage infrastructureLanguageRet = (InfrastructureLanguage)Ret.Value;
                    Assert.Equal(infrastructureLanguageLast.InfrastructureLanguageID, infrastructureLanguageRet.InfrastructureLanguageID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = infrastructureLanguageController.Put(infrastructureLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult infrastructureLanguageRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(infrastructureLanguageRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because InfrastructureLanguageID of 0 does not exist
                    infrastructureLanguageRet.InfrastructureLanguageID = 0;
                    IActionResult jsonRet3 = infrastructureLanguageController.Put(infrastructureLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult infrastructureLanguageRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(infrastructureLanguageRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void InfrastructureLanguage_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    InfrastructureLanguageController infrastructureLanguageController = new InfrastructureLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(infrastructureLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, infrastructureLanguageController.DatabaseType);

                    InfrastructureLanguage infrastructureLanguageLast = new InfrastructureLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        InfrastructureLanguageService infrastructureLanguageService = new InfrastructureLanguageService(query, db, ContactID);
                        infrastructureLanguageLast = (from c in db.InfrastructureLanguages select c).FirstOrDefault();
                    }

                    // ok with InfrastructureLanguage info
                    IActionResult jsonRet = infrastructureLanguageController.GetInfrastructureLanguageWithID(infrastructureLanguageLast.InfrastructureLanguageID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    InfrastructureLanguage infrastructureLanguageRet = (InfrastructureLanguage)Ret.Value;
                    Assert.Equal(infrastructureLanguageLast.InfrastructureLanguageID, infrastructureLanguageRet.InfrastructureLanguageID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added InfrastructureLanguage
                    infrastructureLanguageRet.InfrastructureLanguageID = 0;
                    IActionResult jsonRet3 = infrastructureLanguageController.Post(infrastructureLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    InfrastructureLanguage infrastructureLanguage = (InfrastructureLanguage)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = infrastructureLanguageController.Delete(infrastructureLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because InfrastructureLanguageID of 0 does not exist
                    infrastructureLanguageRet.InfrastructureLanguageID = 0;
                    IActionResult jsonRet4 = infrastructureLanguageController.Delete(infrastructureLanguageRet, LanguageRequest.ToString());
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
