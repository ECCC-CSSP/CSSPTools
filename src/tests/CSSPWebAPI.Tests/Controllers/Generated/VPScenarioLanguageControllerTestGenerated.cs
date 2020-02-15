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
    public partial class VPScenarioLanguageControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public VPScenarioLanguageControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void VPScenarioLanguage_Controller_GetVPScenarioLanguageList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    VPScenarioLanguageController vpScenarioLanguageController = new VPScenarioLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(vpScenarioLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, vpScenarioLanguageController.DatabaseType);

                    VPScenarioLanguage vpScenarioLanguageFirst = new VPScenarioLanguage();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        VPScenarioLanguageService vpScenarioLanguageService = new VPScenarioLanguageService(query, db, ContactID);
                        vpScenarioLanguageFirst = (from c in db.VPScenarioLanguages select c).FirstOrDefault();
                        count = (from c in db.VPScenarioLanguages select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with VPScenarioLanguage info
                    IActionResult jsonRet = vpScenarioLanguageController.GetVPScenarioLanguageList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(vpScenarioLanguageFirst.VPScenarioLanguageID, ((List<VPScenarioLanguage>)ret.Value)[0].VPScenarioLanguageID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<VPScenarioLanguage>)ret.Value).Count);

                    List<VPScenarioLanguage> vpScenarioLanguageList = new List<VPScenarioLanguage>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        VPScenarioLanguageService vpScenarioLanguageService = new VPScenarioLanguageService(query, db, ContactID);
                        vpScenarioLanguageList = (from c in db.VPScenarioLanguages select c).OrderBy(c => c.VPScenarioLanguageID).Skip(0).Take(2).ToList();
                        count = (from c in db.VPScenarioLanguages select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with VPScenarioLanguage info
                        jsonRet = vpScenarioLanguageController.GetVPScenarioLanguageList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(vpScenarioLanguageList[0].VPScenarioLanguageID, ((List<VPScenarioLanguage>)ret.Value)[0].VPScenarioLanguageID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<VPScenarioLanguage>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with VPScenarioLanguage info
                           IActionResult jsonRet2 = vpScenarioLanguageController.GetVPScenarioLanguageList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(vpScenarioLanguageList[1].VPScenarioLanguageID, ((List<VPScenarioLanguage>)ret2.Value)[0].VPScenarioLanguageID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<VPScenarioLanguage>)ret2.Value).Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void VPScenarioLanguage_Controller_GetVPScenarioLanguageWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    VPScenarioLanguageController vpScenarioLanguageController = new VPScenarioLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(vpScenarioLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, vpScenarioLanguageController.DatabaseType);

                    VPScenarioLanguage vpScenarioLanguageFirst = new VPScenarioLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        VPScenarioLanguageService vpScenarioLanguageService = new VPScenarioLanguageService(new Query(), db, ContactID);
                        vpScenarioLanguageFirst = (from c in db.VPScenarioLanguages select c).FirstOrDefault();
                    }

                    // ok with VPScenarioLanguage info
                    IActionResult jsonRet = vpScenarioLanguageController.GetVPScenarioLanguageWithID(vpScenarioLanguageFirst.VPScenarioLanguageID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(vpScenarioLanguageFirst.VPScenarioLanguageID, ((VPScenarioLanguage)ret.Value).VPScenarioLanguageID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = vpScenarioLanguageController.GetVPScenarioLanguageWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult vpScenarioLanguageRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(vpScenarioLanguageRet2);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void VPScenarioLanguage_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    VPScenarioLanguageController vpScenarioLanguageController = new VPScenarioLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(vpScenarioLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, vpScenarioLanguageController.DatabaseType);

                    VPScenarioLanguage vpScenarioLanguageFirst = new VPScenarioLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        VPScenarioLanguageService vpScenarioLanguageService = new VPScenarioLanguageService(query, db, ContactID);
                        vpScenarioLanguageFirst = (from c in db.VPScenarioLanguages select c).FirstOrDefault();
                    }

                    // ok with VPScenarioLanguage info
                    IActionResult jsonRet = vpScenarioLanguageController.GetVPScenarioLanguageWithID(vpScenarioLanguageFirst.VPScenarioLanguageID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    VPScenarioLanguage vpScenarioLanguageRet = (VPScenarioLanguage)ret.Value;
                    Assert.Equal(vpScenarioLanguageFirst.VPScenarioLanguageID, vpScenarioLanguageRet.VPScenarioLanguageID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because VPScenarioLanguageID exist
                    IActionResult jsonRet2 = vpScenarioLanguageController.Post(vpScenarioLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added VPScenarioLanguage
                    vpScenarioLanguageRet.VPScenarioLanguageID = 0;
                    IActionResult jsonRet3 = vpScenarioLanguageController.Post(vpScenarioLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = vpScenarioLanguageController.Delete(vpScenarioLanguageRet, LanguageRequest.ToString());
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
        public void VPScenarioLanguage_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    VPScenarioLanguageController vpScenarioLanguageController = new VPScenarioLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(vpScenarioLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, vpScenarioLanguageController.DatabaseType);

                    VPScenarioLanguage vpScenarioLanguageFirst = new VPScenarioLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        VPScenarioLanguageService vpScenarioLanguageService = new VPScenarioLanguageService(query, db, ContactID);
                        vpScenarioLanguageFirst = (from c in db.VPScenarioLanguages select c).FirstOrDefault();
                    }

                    // ok with VPScenarioLanguage info
                    IActionResult jsonRet = vpScenarioLanguageController.GetVPScenarioLanguageWithID(vpScenarioLanguageFirst.VPScenarioLanguageID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    VPScenarioLanguage vpScenarioLanguageRet = (VPScenarioLanguage)Ret.Value;
                    Assert.Equal(vpScenarioLanguageFirst.VPScenarioLanguageID, vpScenarioLanguageRet.VPScenarioLanguageID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = vpScenarioLanguageController.Put(vpScenarioLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult vpScenarioLanguageRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(vpScenarioLanguageRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because VPScenarioLanguageID of 0 does not exist
                    vpScenarioLanguageRet.VPScenarioLanguageID = 0;
                    IActionResult jsonRet3 = vpScenarioLanguageController.Put(vpScenarioLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult vpScenarioLanguageRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(vpScenarioLanguageRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void VPScenarioLanguage_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    VPScenarioLanguageController vpScenarioLanguageController = new VPScenarioLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(vpScenarioLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, vpScenarioLanguageController.DatabaseType);

                    VPScenarioLanguage vpScenarioLanguageFirst = new VPScenarioLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        VPScenarioLanguageService vpScenarioLanguageService = new VPScenarioLanguageService(query, db, ContactID);
                        vpScenarioLanguageFirst = (from c in db.VPScenarioLanguages select c).FirstOrDefault();
                    }

                    // ok with VPScenarioLanguage info
                    IActionResult jsonRet = vpScenarioLanguageController.GetVPScenarioLanguageWithID(vpScenarioLanguageFirst.VPScenarioLanguageID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    VPScenarioLanguage vpScenarioLanguageRet = (VPScenarioLanguage)Ret.Value;
                    Assert.Equal(vpScenarioLanguageFirst.VPScenarioLanguageID, vpScenarioLanguageRet.VPScenarioLanguageID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added VPScenarioLanguage
                    vpScenarioLanguageRet.VPScenarioLanguageID = 0;
                    IActionResult jsonRet3 = vpScenarioLanguageController.Post(vpScenarioLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    VPScenarioLanguage vpScenarioLanguage = (VPScenarioLanguage)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = vpScenarioLanguageController.Delete(vpScenarioLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because VPScenarioLanguageID of 0 does not exist
                    vpScenarioLanguageRet.VPScenarioLanguageID = 0;
                    IActionResult jsonRet4 = vpScenarioLanguageController.Delete(vpScenarioLanguageRet, LanguageRequest.ToString());
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
