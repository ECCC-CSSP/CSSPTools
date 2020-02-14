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
    public partial class PolSourceObservationIssueControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public PolSourceObservationIssueControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void PolSourceObservationIssue_Controller_GetPolSourceObservationIssueList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    PolSourceObservationIssueController polSourceObservationIssueController = new PolSourceObservationIssueController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(polSourceObservationIssueController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, polSourceObservationIssueController.DatabaseType);

                    PolSourceObservationIssue polSourceObservationIssueFirst = new PolSourceObservationIssue();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        PolSourceObservationIssueService polSourceObservationIssueService = new PolSourceObservationIssueService(query, db, ContactID);
                        polSourceObservationIssueFirst = (from c in db.PolSourceObservationIssues select c).FirstOrDefault();
                        count = (from c in db.PolSourceObservationIssues select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with PolSourceObservationIssue info
                    IActionResult jsonRet = polSourceObservationIssueController.GetPolSourceObservationIssueList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(polSourceObservationIssueFirst.PolSourceObservationIssueID, ((List<PolSourceObservationIssue>)ret.Value)[0].PolSourceObservationIssueID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<PolSourceObservationIssue>)ret.Value).Count);

                    List<PolSourceObservationIssue> polSourceObservationIssueList = new List<PolSourceObservationIssue>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        PolSourceObservationIssueService polSourceObservationIssueService = new PolSourceObservationIssueService(query, db, ContactID);
                        polSourceObservationIssueList = (from c in db.PolSourceObservationIssues select c).OrderBy(c => c.PolSourceObservationIssueID).Skip(0).Take(2).ToList();
                        count = (from c in db.PolSourceObservationIssues select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with PolSourceObservationIssue info
                        jsonRet = polSourceObservationIssueController.GetPolSourceObservationIssueList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(polSourceObservationIssueList[0].PolSourceObservationIssueID, ((List<PolSourceObservationIssue>)ret.Value)[0].PolSourceObservationIssueID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<PolSourceObservationIssue>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with PolSourceObservationIssue info
                           IActionResult jsonRet2 = polSourceObservationIssueController.GetPolSourceObservationIssueList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(polSourceObservationIssueList[1].PolSourceObservationIssueID, ((List<PolSourceObservationIssue>)ret2.Value)[0].PolSourceObservationIssueID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<PolSourceObservationIssue>)ret2.Value).Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void PolSourceObservationIssue_Controller_GetPolSourceObservationIssueWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    PolSourceObservationIssueController polSourceObservationIssueController = new PolSourceObservationIssueController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(polSourceObservationIssueController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, polSourceObservationIssueController.DatabaseType);

                    PolSourceObservationIssue polSourceObservationIssueFirst = new PolSourceObservationIssue();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        PolSourceObservationIssueService polSourceObservationIssueService = new PolSourceObservationIssueService(new Query(), db, ContactID);
                        polSourceObservationIssueFirst = (from c in db.PolSourceObservationIssues select c).FirstOrDefault();
                    }

                    // ok with PolSourceObservationIssue info
                    IActionResult jsonRet = polSourceObservationIssueController.GetPolSourceObservationIssueWithID(polSourceObservationIssueFirst.PolSourceObservationIssueID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(polSourceObservationIssueFirst.PolSourceObservationIssueID, ((PolSourceObservationIssue)ret.Value).PolSourceObservationIssueID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = polSourceObservationIssueController.GetPolSourceObservationIssueWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult polSourceObservationIssueRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(polSourceObservationIssueRet2);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void PolSourceObservationIssue_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    PolSourceObservationIssueController polSourceObservationIssueController = new PolSourceObservationIssueController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(polSourceObservationIssueController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, polSourceObservationIssueController.DatabaseType);

                    PolSourceObservationIssue polSourceObservationIssueLast = new PolSourceObservationIssue();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        PolSourceObservationIssueService polSourceObservationIssueService = new PolSourceObservationIssueService(query, db, ContactID);
                        polSourceObservationIssueLast = (from c in db.PolSourceObservationIssues select c).FirstOrDefault();
                    }

                    // ok with PolSourceObservationIssue info
                    IActionResult jsonRet = polSourceObservationIssueController.GetPolSourceObservationIssueWithID(polSourceObservationIssueLast.PolSourceObservationIssueID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    PolSourceObservationIssue polSourceObservationIssueRet = (PolSourceObservationIssue)ret.Value;
                    Assert.Equal(polSourceObservationIssueLast.PolSourceObservationIssueID, polSourceObservationIssueRet.PolSourceObservationIssueID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because PolSourceObservationIssueID exist
                    IActionResult jsonRet2 = polSourceObservationIssueController.Post(polSourceObservationIssueRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added PolSourceObservationIssue
                    polSourceObservationIssueRet.PolSourceObservationIssueID = 0;
                    IActionResult jsonRet3 = polSourceObservationIssueController.Post(polSourceObservationIssueRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = polSourceObservationIssueController.Delete(polSourceObservationIssueRet, LanguageRequest.ToString());
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
        public void PolSourceObservationIssue_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    PolSourceObservationIssueController polSourceObservationIssueController = new PolSourceObservationIssueController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(polSourceObservationIssueController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, polSourceObservationIssueController.DatabaseType);

                    PolSourceObservationIssue polSourceObservationIssueLast = new PolSourceObservationIssue();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        PolSourceObservationIssueService polSourceObservationIssueService = new PolSourceObservationIssueService(query, db, ContactID);
                        polSourceObservationIssueLast = (from c in db.PolSourceObservationIssues select c).FirstOrDefault();
                    }

                    // ok with PolSourceObservationIssue info
                    IActionResult jsonRet = polSourceObservationIssueController.GetPolSourceObservationIssueWithID(polSourceObservationIssueLast.PolSourceObservationIssueID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    PolSourceObservationIssue polSourceObservationIssueRet = (PolSourceObservationIssue)Ret.Value;
                    Assert.Equal(polSourceObservationIssueLast.PolSourceObservationIssueID, polSourceObservationIssueRet.PolSourceObservationIssueID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = polSourceObservationIssueController.Put(polSourceObservationIssueRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult polSourceObservationIssueRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(polSourceObservationIssueRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because PolSourceObservationIssueID of 0 does not exist
                    polSourceObservationIssueRet.PolSourceObservationIssueID = 0;
                    IActionResult jsonRet3 = polSourceObservationIssueController.Put(polSourceObservationIssueRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult polSourceObservationIssueRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(polSourceObservationIssueRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void PolSourceObservationIssue_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    PolSourceObservationIssueController polSourceObservationIssueController = new PolSourceObservationIssueController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(polSourceObservationIssueController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, polSourceObservationIssueController.DatabaseType);

                    PolSourceObservationIssue polSourceObservationIssueLast = new PolSourceObservationIssue();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        PolSourceObservationIssueService polSourceObservationIssueService = new PolSourceObservationIssueService(query, db, ContactID);
                        polSourceObservationIssueLast = (from c in db.PolSourceObservationIssues select c).FirstOrDefault();
                    }

                    // ok with PolSourceObservationIssue info
                    IActionResult jsonRet = polSourceObservationIssueController.GetPolSourceObservationIssueWithID(polSourceObservationIssueLast.PolSourceObservationIssueID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    PolSourceObservationIssue polSourceObservationIssueRet = (PolSourceObservationIssue)Ret.Value;
                    Assert.Equal(polSourceObservationIssueLast.PolSourceObservationIssueID, polSourceObservationIssueRet.PolSourceObservationIssueID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added PolSourceObservationIssue
                    polSourceObservationIssueRet.PolSourceObservationIssueID = 0;
                    IActionResult jsonRet3 = polSourceObservationIssueController.Post(polSourceObservationIssueRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    PolSourceObservationIssue polSourceObservationIssue = (PolSourceObservationIssue)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = polSourceObservationIssueController.Delete(polSourceObservationIssueRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because PolSourceObservationIssueID of 0 does not exist
                    polSourceObservationIssueRet.PolSourceObservationIssueID = 0;
                    IActionResult jsonRet4 = polSourceObservationIssueController.Delete(polSourceObservationIssueRet, LanguageRequest.ToString());
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
