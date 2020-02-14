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
    public partial class LabSheetControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public LabSheetControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void LabSheet_Controller_GetLabSheetList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    LabSheetController labSheetController = new LabSheetController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(labSheetController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, labSheetController.DatabaseType);

                    LabSheet labSheetFirst = new LabSheet();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        LabSheetService labSheetService = new LabSheetService(query, db, ContactID);
                        labSheetFirst = (from c in db.LabSheets select c).FirstOrDefault();
                        count = (from c in db.LabSheets select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with LabSheet info
                    IActionResult jsonRet = labSheetController.GetLabSheetList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(labSheetFirst.LabSheetID, ((List<LabSheet>)ret.Value)[0].LabSheetID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<LabSheet>)ret.Value).Count);

                    List<LabSheet> labSheetList = new List<LabSheet>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        LabSheetService labSheetService = new LabSheetService(query, db, ContactID);
                        labSheetList = (from c in db.LabSheets select c).OrderBy(c => c.LabSheetID).Skip(0).Take(2).ToList();
                        count = (from c in db.LabSheets select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with LabSheet info
                        jsonRet = labSheetController.GetLabSheetList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(labSheetList[0].LabSheetID, ((List<LabSheet>)ret.Value)[0].LabSheetID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<LabSheet>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with LabSheet info
                           IActionResult jsonRet2 = labSheetController.GetLabSheetList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(labSheetList[1].LabSheetID, ((List<LabSheet>)ret2.Value)[0].LabSheetID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<LabSheet>)ret2.Value).Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void LabSheet_Controller_GetLabSheetWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    LabSheetController labSheetController = new LabSheetController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(labSheetController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, labSheetController.DatabaseType);

                    LabSheet labSheetFirst = new LabSheet();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        LabSheetService labSheetService = new LabSheetService(new Query(), db, ContactID);
                        labSheetFirst = (from c in db.LabSheets select c).FirstOrDefault();
                    }

                    // ok with LabSheet info
                    IActionResult jsonRet = labSheetController.GetLabSheetWithID(labSheetFirst.LabSheetID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(labSheetFirst.LabSheetID, ((LabSheet)ret.Value).LabSheetID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = labSheetController.GetLabSheetWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult labSheetRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(labSheetRet2);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void LabSheet_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    LabSheetController labSheetController = new LabSheetController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(labSheetController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, labSheetController.DatabaseType);

                    LabSheet labSheetLast = new LabSheet();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        LabSheetService labSheetService = new LabSheetService(query, db, ContactID);
                        labSheetLast = (from c in db.LabSheets select c).FirstOrDefault();
                    }

                    // ok with LabSheet info
                    IActionResult jsonRet = labSheetController.GetLabSheetWithID(labSheetLast.LabSheetID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    LabSheet labSheetRet = (LabSheet)ret.Value;
                    Assert.Equal(labSheetLast.LabSheetID, labSheetRet.LabSheetID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because LabSheetID exist
                    IActionResult jsonRet2 = labSheetController.Post(labSheetRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added LabSheet
                    labSheetRet.LabSheetID = 0;
                    IActionResult jsonRet3 = labSheetController.Post(labSheetRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = labSheetController.Delete(labSheetRet, LanguageRequest.ToString());
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
        public void LabSheet_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    LabSheetController labSheetController = new LabSheetController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(labSheetController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, labSheetController.DatabaseType);

                    LabSheet labSheetLast = new LabSheet();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        LabSheetService labSheetService = new LabSheetService(query, db, ContactID);
                        labSheetLast = (from c in db.LabSheets select c).FirstOrDefault();
                    }

                    // ok with LabSheet info
                    IActionResult jsonRet = labSheetController.GetLabSheetWithID(labSheetLast.LabSheetID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    LabSheet labSheetRet = (LabSheet)Ret.Value;
                    Assert.Equal(labSheetLast.LabSheetID, labSheetRet.LabSheetID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = labSheetController.Put(labSheetRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult labSheetRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(labSheetRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because LabSheetID of 0 does not exist
                    labSheetRet.LabSheetID = 0;
                    IActionResult jsonRet3 = labSheetController.Put(labSheetRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult labSheetRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(labSheetRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void LabSheet_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    LabSheetController labSheetController = new LabSheetController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(labSheetController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, labSheetController.DatabaseType);

                    LabSheet labSheetLast = new LabSheet();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        LabSheetService labSheetService = new LabSheetService(query, db, ContactID);
                        labSheetLast = (from c in db.LabSheets select c).FirstOrDefault();
                    }

                    // ok with LabSheet info
                    IActionResult jsonRet = labSheetController.GetLabSheetWithID(labSheetLast.LabSheetID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    LabSheet labSheetRet = (LabSheet)Ret.Value;
                    Assert.Equal(labSheetLast.LabSheetID, labSheetRet.LabSheetID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added LabSheet
                    labSheetRet.LabSheetID = 0;
                    IActionResult jsonRet3 = labSheetController.Post(labSheetRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    LabSheet labSheet = (LabSheet)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = labSheetController.Delete(labSheetRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because LabSheetID of 0 does not exist
                    labSheetRet.LabSheetID = 0;
                    IActionResult jsonRet4 = labSheetController.Delete(labSheetRet, LanguageRequest.ToString());
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
