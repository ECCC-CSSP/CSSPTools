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
    public partial class MikeScenarioControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MikeScenarioControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void MikeScenario_Controller_GetMikeScenarioList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MikeScenarioController mikeScenarioController = new MikeScenarioController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mikeScenarioController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mikeScenarioController.DatabaseType);

                    MikeScenario mikeScenarioFirst = new MikeScenario();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        MikeScenarioService mikeScenarioService = new MikeScenarioService(query, db, ContactID);
                        mikeScenarioFirst = (from c in db.MikeScenarios select c).FirstOrDefault();
                        count = (from c in db.MikeScenarios select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with MikeScenario info
                    IActionResult jsonRet = mikeScenarioController.GetMikeScenarioList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(mikeScenarioFirst.MikeScenarioID, ((List<MikeScenario>)ret.Value)[0].MikeScenarioID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<MikeScenario>)ret.Value).Count);

                    List<MikeScenario> mikeScenarioList = new List<MikeScenario>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        MikeScenarioService mikeScenarioService = new MikeScenarioService(query, db, ContactID);
                        mikeScenarioList = (from c in db.MikeScenarios select c).OrderBy(c => c.MikeScenarioID).Skip(0).Take(2).ToList();
                        count = (from c in db.MikeScenarios select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with MikeScenario info
                        jsonRet = mikeScenarioController.GetMikeScenarioList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(mikeScenarioList[0].MikeScenarioID, ((List<MikeScenario>)ret.Value)[0].MikeScenarioID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<MikeScenario>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with MikeScenario info
                           IActionResult jsonRet2 = mikeScenarioController.GetMikeScenarioList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(mikeScenarioList[1].MikeScenarioID, ((List<MikeScenario>)ret2.Value)[0].MikeScenarioID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<MikeScenario>)ret2.Value).Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void MikeScenario_Controller_GetMikeScenarioWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MikeScenarioController mikeScenarioController = new MikeScenarioController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mikeScenarioController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mikeScenarioController.DatabaseType);

                    MikeScenario mikeScenarioFirst = new MikeScenario();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        MikeScenarioService mikeScenarioService = new MikeScenarioService(new Query(), db, ContactID);
                        mikeScenarioFirst = (from c in db.MikeScenarios select c).FirstOrDefault();
                    }

                    // ok with MikeScenario info
                    IActionResult jsonRet = mikeScenarioController.GetMikeScenarioWithID(mikeScenarioFirst.MikeScenarioID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(mikeScenarioFirst.MikeScenarioID, ((MikeScenario)ret.Value).MikeScenarioID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = mikeScenarioController.GetMikeScenarioWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult mikeScenarioRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(mikeScenarioRet2);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void MikeScenario_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MikeScenarioController mikeScenarioController = new MikeScenarioController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mikeScenarioController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mikeScenarioController.DatabaseType);

                    MikeScenario mikeScenarioLast = new MikeScenario();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MikeScenarioService mikeScenarioService = new MikeScenarioService(query, db, ContactID);
                        mikeScenarioLast = (from c in db.MikeScenarios select c).FirstOrDefault();
                    }

                    // ok with MikeScenario info
                    IActionResult jsonRet = mikeScenarioController.GetMikeScenarioWithID(mikeScenarioLast.MikeScenarioID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    MikeScenario mikeScenarioRet = (MikeScenario)ret.Value;
                    Assert.Equal(mikeScenarioLast.MikeScenarioID, mikeScenarioRet.MikeScenarioID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because MikeScenarioID exist
                    IActionResult jsonRet2 = mikeScenarioController.Post(mikeScenarioRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added MikeScenario
                    mikeScenarioRet.MikeScenarioID = 0;
                    IActionResult jsonRet3 = mikeScenarioController.Post(mikeScenarioRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = mikeScenarioController.Delete(mikeScenarioRet, LanguageRequest.ToString());
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
        public void MikeScenario_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MikeScenarioController mikeScenarioController = new MikeScenarioController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mikeScenarioController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mikeScenarioController.DatabaseType);

                    MikeScenario mikeScenarioLast = new MikeScenario();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        MikeScenarioService mikeScenarioService = new MikeScenarioService(query, db, ContactID);
                        mikeScenarioLast = (from c in db.MikeScenarios select c).FirstOrDefault();
                    }

                    // ok with MikeScenario info
                    IActionResult jsonRet = mikeScenarioController.GetMikeScenarioWithID(mikeScenarioLast.MikeScenarioID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    MikeScenario mikeScenarioRet = (MikeScenario)Ret.Value;
                    Assert.Equal(mikeScenarioLast.MikeScenarioID, mikeScenarioRet.MikeScenarioID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = mikeScenarioController.Put(mikeScenarioRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult mikeScenarioRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(mikeScenarioRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because MikeScenarioID of 0 does not exist
                    mikeScenarioRet.MikeScenarioID = 0;
                    IActionResult jsonRet3 = mikeScenarioController.Put(mikeScenarioRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult mikeScenarioRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(mikeScenarioRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void MikeScenario_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MikeScenarioController mikeScenarioController = new MikeScenarioController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mikeScenarioController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mikeScenarioController.DatabaseType);

                    MikeScenario mikeScenarioLast = new MikeScenario();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MikeScenarioService mikeScenarioService = new MikeScenarioService(query, db, ContactID);
                        mikeScenarioLast = (from c in db.MikeScenarios select c).FirstOrDefault();
                    }

                    // ok with MikeScenario info
                    IActionResult jsonRet = mikeScenarioController.GetMikeScenarioWithID(mikeScenarioLast.MikeScenarioID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    MikeScenario mikeScenarioRet = (MikeScenario)Ret.Value;
                    Assert.Equal(mikeScenarioLast.MikeScenarioID, mikeScenarioRet.MikeScenarioID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added MikeScenario
                    mikeScenarioRet.MikeScenarioID = 0;
                    IActionResult jsonRet3 = mikeScenarioController.Post(mikeScenarioRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    MikeScenario mikeScenario = (MikeScenario)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = mikeScenarioController.Delete(mikeScenarioRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because MikeScenarioID of 0 does not exist
                    mikeScenarioRet.MikeScenarioID = 0;
                    IActionResult jsonRet4 = mikeScenarioController.Delete(mikeScenarioRet, LanguageRequest.ToString());
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
