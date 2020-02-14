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
    public partial class DrogueRunPositionControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public DrogueRunPositionControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void DrogueRunPosition_Controller_GetDrogueRunPositionList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    DrogueRunPositionController drogueRunPositionController = new DrogueRunPositionController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(drogueRunPositionController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, drogueRunPositionController.DatabaseType);

                    DrogueRunPosition drogueRunPositionFirst = new DrogueRunPosition();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        DrogueRunPositionService drogueRunPositionService = new DrogueRunPositionService(query, db, ContactID);
                        drogueRunPositionFirst = (from c in db.DrogueRunPositions select c).FirstOrDefault();
                        count = (from c in db.DrogueRunPositions select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with DrogueRunPosition info
                    IActionResult jsonRet = drogueRunPositionController.GetDrogueRunPositionList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(drogueRunPositionFirst.DrogueRunPositionID, ((List<DrogueRunPosition>)ret.Value)[0].DrogueRunPositionID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<DrogueRunPosition>)ret.Value).Count);

                    List<DrogueRunPosition> drogueRunPositionList = new List<DrogueRunPosition>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        DrogueRunPositionService drogueRunPositionService = new DrogueRunPositionService(query, db, ContactID);
                        drogueRunPositionList = (from c in db.DrogueRunPositions select c).OrderBy(c => c.DrogueRunPositionID).Skip(0).Take(2).ToList();
                        count = (from c in db.DrogueRunPositions select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with DrogueRunPosition info
                        jsonRet = drogueRunPositionController.GetDrogueRunPositionList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(drogueRunPositionList[0].DrogueRunPositionID, ((List<DrogueRunPosition>)ret.Value)[0].DrogueRunPositionID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<DrogueRunPosition>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with DrogueRunPosition info
                           IActionResult jsonRet2 = drogueRunPositionController.GetDrogueRunPositionList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(drogueRunPositionList[1].DrogueRunPositionID, ((List<DrogueRunPosition>)ret2.Value)[0].DrogueRunPositionID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<DrogueRunPosition>)ret2.Value).Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void DrogueRunPosition_Controller_GetDrogueRunPositionWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    DrogueRunPositionController drogueRunPositionController = new DrogueRunPositionController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(drogueRunPositionController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, drogueRunPositionController.DatabaseType);

                    DrogueRunPosition drogueRunPositionFirst = new DrogueRunPosition();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        DrogueRunPositionService drogueRunPositionService = new DrogueRunPositionService(new Query(), db, ContactID);
                        drogueRunPositionFirst = (from c in db.DrogueRunPositions select c).FirstOrDefault();
                    }

                    // ok with DrogueRunPosition info
                    IActionResult jsonRet = drogueRunPositionController.GetDrogueRunPositionWithID(drogueRunPositionFirst.DrogueRunPositionID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(drogueRunPositionFirst.DrogueRunPositionID, ((DrogueRunPosition)ret.Value).DrogueRunPositionID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = drogueRunPositionController.GetDrogueRunPositionWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult drogueRunPositionRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(drogueRunPositionRet2);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void DrogueRunPosition_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    DrogueRunPositionController drogueRunPositionController = new DrogueRunPositionController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(drogueRunPositionController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, drogueRunPositionController.DatabaseType);

                    DrogueRunPosition drogueRunPositionLast = new DrogueRunPosition();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        DrogueRunPositionService drogueRunPositionService = new DrogueRunPositionService(query, db, ContactID);
                        drogueRunPositionLast = (from c in db.DrogueRunPositions select c).FirstOrDefault();
                    }

                    // ok with DrogueRunPosition info
                    IActionResult jsonRet = drogueRunPositionController.GetDrogueRunPositionWithID(drogueRunPositionLast.DrogueRunPositionID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    DrogueRunPosition drogueRunPositionRet = (DrogueRunPosition)ret.Value;
                    Assert.Equal(drogueRunPositionLast.DrogueRunPositionID, drogueRunPositionRet.DrogueRunPositionID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because DrogueRunPositionID exist
                    IActionResult jsonRet2 = drogueRunPositionController.Post(drogueRunPositionRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added DrogueRunPosition
                    drogueRunPositionRet.DrogueRunPositionID = 0;
                    IActionResult jsonRet3 = drogueRunPositionController.Post(drogueRunPositionRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = drogueRunPositionController.Delete(drogueRunPositionRet, LanguageRequest.ToString());
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
        public void DrogueRunPosition_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    DrogueRunPositionController drogueRunPositionController = new DrogueRunPositionController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(drogueRunPositionController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, drogueRunPositionController.DatabaseType);

                    DrogueRunPosition drogueRunPositionLast = new DrogueRunPosition();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        DrogueRunPositionService drogueRunPositionService = new DrogueRunPositionService(query, db, ContactID);
                        drogueRunPositionLast = (from c in db.DrogueRunPositions select c).FirstOrDefault();
                    }

                    // ok with DrogueRunPosition info
                    IActionResult jsonRet = drogueRunPositionController.GetDrogueRunPositionWithID(drogueRunPositionLast.DrogueRunPositionID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    DrogueRunPosition drogueRunPositionRet = (DrogueRunPosition)Ret.Value;
                    Assert.Equal(drogueRunPositionLast.DrogueRunPositionID, drogueRunPositionRet.DrogueRunPositionID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = drogueRunPositionController.Put(drogueRunPositionRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult drogueRunPositionRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(drogueRunPositionRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because DrogueRunPositionID of 0 does not exist
                    drogueRunPositionRet.DrogueRunPositionID = 0;
                    IActionResult jsonRet3 = drogueRunPositionController.Put(drogueRunPositionRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult drogueRunPositionRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(drogueRunPositionRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void DrogueRunPosition_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    DrogueRunPositionController drogueRunPositionController = new DrogueRunPositionController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(drogueRunPositionController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, drogueRunPositionController.DatabaseType);

                    DrogueRunPosition drogueRunPositionLast = new DrogueRunPosition();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        DrogueRunPositionService drogueRunPositionService = new DrogueRunPositionService(query, db, ContactID);
                        drogueRunPositionLast = (from c in db.DrogueRunPositions select c).FirstOrDefault();
                    }

                    // ok with DrogueRunPosition info
                    IActionResult jsonRet = drogueRunPositionController.GetDrogueRunPositionWithID(drogueRunPositionLast.DrogueRunPositionID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    DrogueRunPosition drogueRunPositionRet = (DrogueRunPosition)Ret.Value;
                    Assert.Equal(drogueRunPositionLast.DrogueRunPositionID, drogueRunPositionRet.DrogueRunPositionID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added DrogueRunPosition
                    drogueRunPositionRet.DrogueRunPositionID = 0;
                    IActionResult jsonRet3 = drogueRunPositionController.Post(drogueRunPositionRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    DrogueRunPosition drogueRunPosition = (DrogueRunPosition)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = drogueRunPositionController.Delete(drogueRunPositionRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because DrogueRunPositionID of 0 does not exist
                    drogueRunPositionRet.DrogueRunPositionID = 0;
                    IActionResult jsonRet4 = drogueRunPositionController.Delete(drogueRunPositionRet, LanguageRequest.ToString());
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
