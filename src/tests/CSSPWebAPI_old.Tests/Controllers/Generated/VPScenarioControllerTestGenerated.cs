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
    public partial class VPScenarioControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public VPScenarioControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void VPScenario_Controller_GetVPScenarioList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    VPScenarioController vpScenarioController = new VPScenarioController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(vpScenarioController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, vpScenarioController.DatabaseType);

                    VPScenario vpScenarioFirst = new VPScenario();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        VPScenarioService vpScenarioService = new VPScenarioService(query, db, ContactID);
                        vpScenarioFirst = (from c in db.VPScenarios select c).FirstOrDefault();
                        count = (from c in db.VPScenarios select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with VPScenario info
                    IActionResult jsonRet = vpScenarioController.GetVPScenarioList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(vpScenarioFirst.VPScenarioID, ((List<VPScenario>)ret.Value)[0].VPScenarioID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<VPScenario>)ret.Value).Count);

                    List<VPScenario> vpScenarioList = new List<VPScenario>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        VPScenarioService vpScenarioService = new VPScenarioService(query, db, ContactID);
                        vpScenarioList = (from c in db.VPScenarios select c).OrderBy(c => c.VPScenarioID).Skip(0).Take(2).ToList();
                        count = (from c in db.VPScenarios select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with VPScenario info
                        jsonRet = vpScenarioController.GetVPScenarioList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(vpScenarioList[0].VPScenarioID, ((List<VPScenario>)ret.Value)[0].VPScenarioID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<VPScenario>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with VPScenario info
                           IActionResult jsonRet2 = vpScenarioController.GetVPScenarioList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(vpScenarioList[1].VPScenarioID, ((List<VPScenario>)ret2.Value)[0].VPScenarioID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<VPScenario>)ret2.Value).Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void VPScenario_Controller_GetVPScenarioWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    VPScenarioController vpScenarioController = new VPScenarioController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(vpScenarioController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, vpScenarioController.DatabaseType);

                    VPScenario vpScenarioFirst = new VPScenario();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        VPScenarioService vpScenarioService = new VPScenarioService(new Query(), db, ContactID);
                        vpScenarioFirst = (from c in db.VPScenarios select c).FirstOrDefault();
                    }

                    // ok with VPScenario info
                    IActionResult jsonRet = vpScenarioController.GetVPScenarioWithID(vpScenarioFirst.VPScenarioID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(vpScenarioFirst.VPScenarioID, ((VPScenario)ret.Value).VPScenarioID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = vpScenarioController.GetVPScenarioWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult vpScenarioRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(vpScenarioRet2);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void VPScenario_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    VPScenarioController vpScenarioController = new VPScenarioController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(vpScenarioController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, vpScenarioController.DatabaseType);

                    VPScenario vpScenarioFirst = new VPScenario();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        VPScenarioService vpScenarioService = new VPScenarioService(query, db, ContactID);
                        vpScenarioFirst = (from c in db.VPScenarios select c).FirstOrDefault();
                    }

                    // ok with VPScenario info
                    IActionResult jsonRet = vpScenarioController.GetVPScenarioWithID(vpScenarioFirst.VPScenarioID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    VPScenario vpScenarioRet = (VPScenario)ret.Value;
                    Assert.Equal(vpScenarioFirst.VPScenarioID, vpScenarioRet.VPScenarioID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because VPScenarioID exist
                    IActionResult jsonRet2 = vpScenarioController.Post(vpScenarioRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added VPScenario
                    vpScenarioRet.VPScenarioID = 0;
                    IActionResult jsonRet3 = vpScenarioController.Post(vpScenarioRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = vpScenarioController.Delete(vpScenarioRet, LanguageRequest.ToString());
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
        public void VPScenario_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    VPScenarioController vpScenarioController = new VPScenarioController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(vpScenarioController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, vpScenarioController.DatabaseType);

                    VPScenario vpScenarioFirst = new VPScenario();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        VPScenarioService vpScenarioService = new VPScenarioService(query, db, ContactID);
                        vpScenarioFirst = (from c in db.VPScenarios select c).FirstOrDefault();
                    }

                    // ok with VPScenario info
                    IActionResult jsonRet = vpScenarioController.GetVPScenarioWithID(vpScenarioFirst.VPScenarioID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    VPScenario vpScenarioRet = (VPScenario)Ret.Value;
                    Assert.Equal(vpScenarioFirst.VPScenarioID, vpScenarioRet.VPScenarioID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = vpScenarioController.Put(vpScenarioRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult vpScenarioRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(vpScenarioRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because VPScenarioID of 0 does not exist
                    vpScenarioRet.VPScenarioID = 0;
                    IActionResult jsonRet3 = vpScenarioController.Put(vpScenarioRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult vpScenarioRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(vpScenarioRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void VPScenario_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    VPScenarioController vpScenarioController = new VPScenarioController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(vpScenarioController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, vpScenarioController.DatabaseType);

                    VPScenario vpScenarioFirst = new VPScenario();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        VPScenarioService vpScenarioService = new VPScenarioService(query, db, ContactID);
                        vpScenarioFirst = (from c in db.VPScenarios select c).FirstOrDefault();
                    }

                    // ok with VPScenario info
                    IActionResult jsonRet = vpScenarioController.GetVPScenarioWithID(vpScenarioFirst.VPScenarioID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    VPScenario vpScenarioRet = (VPScenario)Ret.Value;
                    Assert.Equal(vpScenarioFirst.VPScenarioID, vpScenarioRet.VPScenarioID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added VPScenario
                    vpScenarioRet.VPScenarioID = 0;
                    IActionResult jsonRet3 = vpScenarioController.Post(vpScenarioRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    VPScenario vpScenario = (VPScenario)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = vpScenarioController.Delete(vpScenarioRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because VPScenarioID of 0 does not exist
                    vpScenarioRet.VPScenarioID = 0;
                    IActionResult jsonRet4 = vpScenarioController.Delete(vpScenarioRet, LanguageRequest.ToString());
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
