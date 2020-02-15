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
    public partial class SpillControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public SpillControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void Spill_Controller_GetSpillList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    SpillController spillController = new SpillController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(spillController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, spillController.DatabaseType);

                    Spill spillFirst = new Spill();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        SpillService spillService = new SpillService(query, db, ContactID);
                        spillFirst = (from c in db.Spills select c).FirstOrDefault();
                        count = (from c in db.Spills select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with Spill info
                    IActionResult jsonRet = spillController.GetSpillList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(spillFirst.SpillID, ((List<Spill>)ret.Value)[0].SpillID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<Spill>)ret.Value).Count);

                    List<Spill> spillList = new List<Spill>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        SpillService spillService = new SpillService(query, db, ContactID);
                        spillList = (from c in db.Spills select c).OrderBy(c => c.SpillID).Skip(0).Take(2).ToList();
                        count = (from c in db.Spills select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with Spill info
                        jsonRet = spillController.GetSpillList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(spillList[0].SpillID, ((List<Spill>)ret.Value)[0].SpillID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<Spill>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with Spill info
                           IActionResult jsonRet2 = spillController.GetSpillList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(spillList[1].SpillID, ((List<Spill>)ret2.Value)[0].SpillID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<Spill>)ret2.Value).Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void Spill_Controller_GetSpillWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    SpillController spillController = new SpillController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(spillController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, spillController.DatabaseType);

                    Spill spillFirst = new Spill();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        SpillService spillService = new SpillService(new Query(), db, ContactID);
                        spillFirst = (from c in db.Spills select c).FirstOrDefault();
                    }

                    // ok with Spill info
                    IActionResult jsonRet = spillController.GetSpillWithID(spillFirst.SpillID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(spillFirst.SpillID, ((Spill)ret.Value).SpillID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = spillController.GetSpillWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult spillRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(spillRet2);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void Spill_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    SpillController spillController = new SpillController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(spillController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, spillController.DatabaseType);

                    Spill spillFirst = new Spill();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        SpillService spillService = new SpillService(query, db, ContactID);
                        spillFirst = (from c in db.Spills select c).FirstOrDefault();
                    }

                    // ok with Spill info
                    IActionResult jsonRet = spillController.GetSpillWithID(spillFirst.SpillID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Spill spillRet = (Spill)ret.Value;
                    Assert.Equal(spillFirst.SpillID, spillRet.SpillID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because SpillID exist
                    IActionResult jsonRet2 = spillController.Post(spillRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added Spill
                    spillRet.SpillID = 0;
                    IActionResult jsonRet3 = spillController.Post(spillRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = spillController.Delete(spillRet, LanguageRequest.ToString());
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
        public void Spill_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    SpillController spillController = new SpillController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(spillController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, spillController.DatabaseType);

                    Spill spillFirst = new Spill();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        SpillService spillService = new SpillService(query, db, ContactID);
                        spillFirst = (from c in db.Spills select c).FirstOrDefault();
                    }

                    // ok with Spill info
                    IActionResult jsonRet = spillController.GetSpillWithID(spillFirst.SpillID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    Spill spillRet = (Spill)Ret.Value;
                    Assert.Equal(spillFirst.SpillID, spillRet.SpillID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = spillController.Put(spillRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult spillRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(spillRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because SpillID of 0 does not exist
                    spillRet.SpillID = 0;
                    IActionResult jsonRet3 = spillController.Put(spillRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult spillRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(spillRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void Spill_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    SpillController spillController = new SpillController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(spillController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, spillController.DatabaseType);

                    Spill spillFirst = new Spill();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        SpillService spillService = new SpillService(query, db, ContactID);
                        spillFirst = (from c in db.Spills select c).FirstOrDefault();
                    }

                    // ok with Spill info
                    IActionResult jsonRet = spillController.GetSpillWithID(spillFirst.SpillID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    Spill spillRet = (Spill)Ret.Value;
                    Assert.Equal(spillFirst.SpillID, spillRet.SpillID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added Spill
                    spillRet.SpillID = 0;
                    IActionResult jsonRet3 = spillController.Post(spillRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    Spill spill = (Spill)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = spillController.Delete(spillRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because SpillID of 0 does not exist
                    spillRet.SpillID = 0;
                    IActionResult jsonRet4 = spillController.Delete(spillRet, LanguageRequest.ToString());
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
