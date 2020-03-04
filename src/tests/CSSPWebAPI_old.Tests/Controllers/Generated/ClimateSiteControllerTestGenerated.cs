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
    public partial class ClimateSiteControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ClimateSiteControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void ClimateSite_Controller_GetClimateSiteList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ClimateSiteController climateSiteController = new ClimateSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(climateSiteController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, climateSiteController.DatabaseType);

                    ClimateSite climateSiteFirst = new ClimateSite();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        ClimateSiteService climateSiteService = new ClimateSiteService(query, db, ContactID);
                        climateSiteFirst = (from c in db.ClimateSites select c).FirstOrDefault();
                        count = (from c in db.ClimateSites select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with ClimateSite info
                    IActionResult jsonRet = climateSiteController.GetClimateSiteList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(climateSiteFirst.ClimateSiteID, ((List<ClimateSite>)ret.Value)[0].ClimateSiteID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<ClimateSite>)ret.Value).Count);

                    List<ClimateSite> climateSiteList = new List<ClimateSite>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        ClimateSiteService climateSiteService = new ClimateSiteService(query, db, ContactID);
                        climateSiteList = (from c in db.ClimateSites select c).OrderBy(c => c.ClimateSiteID).Skip(0).Take(2).ToList();
                        count = (from c in db.ClimateSites select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with ClimateSite info
                        jsonRet = climateSiteController.GetClimateSiteList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(climateSiteList[0].ClimateSiteID, ((List<ClimateSite>)ret.Value)[0].ClimateSiteID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<ClimateSite>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with ClimateSite info
                           IActionResult jsonRet2 = climateSiteController.GetClimateSiteList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(climateSiteList[1].ClimateSiteID, ((List<ClimateSite>)ret2.Value)[0].ClimateSiteID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<ClimateSite>)ret2.Value).Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void ClimateSite_Controller_GetClimateSiteWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ClimateSiteController climateSiteController = new ClimateSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(climateSiteController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, climateSiteController.DatabaseType);

                    ClimateSite climateSiteFirst = new ClimateSite();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        ClimateSiteService climateSiteService = new ClimateSiteService(new Query(), db, ContactID);
                        climateSiteFirst = (from c in db.ClimateSites select c).FirstOrDefault();
                    }

                    // ok with ClimateSite info
                    IActionResult jsonRet = climateSiteController.GetClimateSiteWithID(climateSiteFirst.ClimateSiteID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(climateSiteFirst.ClimateSiteID, ((ClimateSite)ret.Value).ClimateSiteID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = climateSiteController.GetClimateSiteWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult climateSiteRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(climateSiteRet2);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void ClimateSite_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ClimateSiteController climateSiteController = new ClimateSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(climateSiteController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, climateSiteController.DatabaseType);

                    ClimateSite climateSiteFirst = new ClimateSite();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        ClimateSiteService climateSiteService = new ClimateSiteService(query, db, ContactID);
                        climateSiteFirst = (from c in db.ClimateSites select c).FirstOrDefault();
                    }

                    // ok with ClimateSite info
                    IActionResult jsonRet = climateSiteController.GetClimateSiteWithID(climateSiteFirst.ClimateSiteID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    ClimateSite climateSiteRet = (ClimateSite)ret.Value;
                    Assert.Equal(climateSiteFirst.ClimateSiteID, climateSiteRet.ClimateSiteID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because ClimateSiteID exist
                    IActionResult jsonRet2 = climateSiteController.Post(climateSiteRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added ClimateSite
                    climateSiteRet.ClimateSiteID = 0;
                    IActionResult jsonRet3 = climateSiteController.Post(climateSiteRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = climateSiteController.Delete(climateSiteRet, LanguageRequest.ToString());
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
        public void ClimateSite_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ClimateSiteController climateSiteController = new ClimateSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(climateSiteController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, climateSiteController.DatabaseType);

                    ClimateSite climateSiteFirst = new ClimateSite();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        ClimateSiteService climateSiteService = new ClimateSiteService(query, db, ContactID);
                        climateSiteFirst = (from c in db.ClimateSites select c).FirstOrDefault();
                    }

                    // ok with ClimateSite info
                    IActionResult jsonRet = climateSiteController.GetClimateSiteWithID(climateSiteFirst.ClimateSiteID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    ClimateSite climateSiteRet = (ClimateSite)Ret.Value;
                    Assert.Equal(climateSiteFirst.ClimateSiteID, climateSiteRet.ClimateSiteID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = climateSiteController.Put(climateSiteRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult climateSiteRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(climateSiteRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because ClimateSiteID of 0 does not exist
                    climateSiteRet.ClimateSiteID = 0;
                    IActionResult jsonRet3 = climateSiteController.Put(climateSiteRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult climateSiteRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(climateSiteRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void ClimateSite_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ClimateSiteController climateSiteController = new ClimateSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(climateSiteController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, climateSiteController.DatabaseType);

                    ClimateSite climateSiteFirst = new ClimateSite();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        ClimateSiteService climateSiteService = new ClimateSiteService(query, db, ContactID);
                        climateSiteFirst = (from c in db.ClimateSites select c).FirstOrDefault();
                    }

                    // ok with ClimateSite info
                    IActionResult jsonRet = climateSiteController.GetClimateSiteWithID(climateSiteFirst.ClimateSiteID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    ClimateSite climateSiteRet = (ClimateSite)Ret.Value;
                    Assert.Equal(climateSiteFirst.ClimateSiteID, climateSiteRet.ClimateSiteID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added ClimateSite
                    climateSiteRet.ClimateSiteID = 0;
                    IActionResult jsonRet3 = climateSiteController.Post(climateSiteRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    ClimateSite climateSite = (ClimateSite)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = climateSiteController.Delete(climateSiteRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because ClimateSiteID of 0 does not exist
                    climateSiteRet.ClimateSiteID = 0;
                    IActionResult jsonRet4 = climateSiteController.Delete(climateSiteRet, LanguageRequest.ToString());
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
