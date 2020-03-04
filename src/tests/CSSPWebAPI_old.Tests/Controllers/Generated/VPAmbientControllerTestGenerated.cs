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
    public partial class VPAmbientControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public VPAmbientControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void VPAmbient_Controller_GetVPAmbientList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    VPAmbientController vpAmbientController = new VPAmbientController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(vpAmbientController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, vpAmbientController.DatabaseType);

                    VPAmbient vpAmbientFirst = new VPAmbient();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        VPAmbientService vpAmbientService = new VPAmbientService(query, db, ContactID);
                        vpAmbientFirst = (from c in db.VPAmbients select c).FirstOrDefault();
                        count = (from c in db.VPAmbients select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with VPAmbient info
                    IActionResult jsonRet = vpAmbientController.GetVPAmbientList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(vpAmbientFirst.VPAmbientID, ((List<VPAmbient>)ret.Value)[0].VPAmbientID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<VPAmbient>)ret.Value).Count);

                    List<VPAmbient> vpAmbientList = new List<VPAmbient>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        VPAmbientService vpAmbientService = new VPAmbientService(query, db, ContactID);
                        vpAmbientList = (from c in db.VPAmbients select c).OrderBy(c => c.VPAmbientID).Skip(0).Take(2).ToList();
                        count = (from c in db.VPAmbients select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with VPAmbient info
                        jsonRet = vpAmbientController.GetVPAmbientList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(vpAmbientList[0].VPAmbientID, ((List<VPAmbient>)ret.Value)[0].VPAmbientID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<VPAmbient>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with VPAmbient info
                           IActionResult jsonRet2 = vpAmbientController.GetVPAmbientList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(vpAmbientList[1].VPAmbientID, ((List<VPAmbient>)ret2.Value)[0].VPAmbientID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<VPAmbient>)ret2.Value).Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void VPAmbient_Controller_GetVPAmbientWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    VPAmbientController vpAmbientController = new VPAmbientController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(vpAmbientController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, vpAmbientController.DatabaseType);

                    VPAmbient vpAmbientFirst = new VPAmbient();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        VPAmbientService vpAmbientService = new VPAmbientService(new Query(), db, ContactID);
                        vpAmbientFirst = (from c in db.VPAmbients select c).FirstOrDefault();
                    }

                    // ok with VPAmbient info
                    IActionResult jsonRet = vpAmbientController.GetVPAmbientWithID(vpAmbientFirst.VPAmbientID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(vpAmbientFirst.VPAmbientID, ((VPAmbient)ret.Value).VPAmbientID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = vpAmbientController.GetVPAmbientWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult vpAmbientRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(vpAmbientRet2);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void VPAmbient_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    VPAmbientController vpAmbientController = new VPAmbientController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(vpAmbientController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, vpAmbientController.DatabaseType);

                    VPAmbient vpAmbientFirst = new VPAmbient();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        VPAmbientService vpAmbientService = new VPAmbientService(query, db, ContactID);
                        vpAmbientFirst = (from c in db.VPAmbients select c).FirstOrDefault();
                    }

                    // ok with VPAmbient info
                    IActionResult jsonRet = vpAmbientController.GetVPAmbientWithID(vpAmbientFirst.VPAmbientID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    VPAmbient vpAmbientRet = (VPAmbient)ret.Value;
                    Assert.Equal(vpAmbientFirst.VPAmbientID, vpAmbientRet.VPAmbientID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because VPAmbientID exist
                    IActionResult jsonRet2 = vpAmbientController.Post(vpAmbientRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added VPAmbient
                    vpAmbientRet.VPAmbientID = 0;
                    IActionResult jsonRet3 = vpAmbientController.Post(vpAmbientRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = vpAmbientController.Delete(vpAmbientRet, LanguageRequest.ToString());
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
        public void VPAmbient_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    VPAmbientController vpAmbientController = new VPAmbientController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(vpAmbientController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, vpAmbientController.DatabaseType);

                    VPAmbient vpAmbientFirst = new VPAmbient();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        VPAmbientService vpAmbientService = new VPAmbientService(query, db, ContactID);
                        vpAmbientFirst = (from c in db.VPAmbients select c).FirstOrDefault();
                    }

                    // ok with VPAmbient info
                    IActionResult jsonRet = vpAmbientController.GetVPAmbientWithID(vpAmbientFirst.VPAmbientID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    VPAmbient vpAmbientRet = (VPAmbient)Ret.Value;
                    Assert.Equal(vpAmbientFirst.VPAmbientID, vpAmbientRet.VPAmbientID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = vpAmbientController.Put(vpAmbientRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult vpAmbientRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(vpAmbientRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because VPAmbientID of 0 does not exist
                    vpAmbientRet.VPAmbientID = 0;
                    IActionResult jsonRet3 = vpAmbientController.Put(vpAmbientRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult vpAmbientRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(vpAmbientRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void VPAmbient_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    VPAmbientController vpAmbientController = new VPAmbientController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(vpAmbientController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, vpAmbientController.DatabaseType);

                    VPAmbient vpAmbientFirst = new VPAmbient();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        VPAmbientService vpAmbientService = new VPAmbientService(query, db, ContactID);
                        vpAmbientFirst = (from c in db.VPAmbients select c).FirstOrDefault();
                    }

                    // ok with VPAmbient info
                    IActionResult jsonRet = vpAmbientController.GetVPAmbientWithID(vpAmbientFirst.VPAmbientID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    VPAmbient vpAmbientRet = (VPAmbient)Ret.Value;
                    Assert.Equal(vpAmbientFirst.VPAmbientID, vpAmbientRet.VPAmbientID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added VPAmbient
                    vpAmbientRet.VPAmbientID = 0;
                    IActionResult jsonRet3 = vpAmbientController.Post(vpAmbientRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    VPAmbient vpAmbient = (VPAmbient)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = vpAmbientController.Delete(vpAmbientRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because VPAmbientID of 0 does not exist
                    vpAmbientRet.VPAmbientID = 0;
                    IActionResult jsonRet4 = vpAmbientController.Delete(vpAmbientRet, LanguageRequest.ToString());
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
