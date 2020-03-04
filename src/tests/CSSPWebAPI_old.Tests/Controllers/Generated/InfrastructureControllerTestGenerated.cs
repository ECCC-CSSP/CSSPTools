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
    public partial class InfrastructureControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public InfrastructureControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void Infrastructure_Controller_GetInfrastructureList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    InfrastructureController infrastructureController = new InfrastructureController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(infrastructureController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, infrastructureController.DatabaseType);

                    Infrastructure infrastructureFirst = new Infrastructure();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        InfrastructureService infrastructureService = new InfrastructureService(query, db, ContactID);
                        infrastructureFirst = (from c in db.Infrastructures select c).FirstOrDefault();
                        count = (from c in db.Infrastructures select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with Infrastructure info
                    IActionResult jsonRet = infrastructureController.GetInfrastructureList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(infrastructureFirst.InfrastructureID, ((List<Infrastructure>)ret.Value)[0].InfrastructureID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<Infrastructure>)ret.Value).Count);

                    List<Infrastructure> infrastructureList = new List<Infrastructure>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        InfrastructureService infrastructureService = new InfrastructureService(query, db, ContactID);
                        infrastructureList = (from c in db.Infrastructures select c).OrderBy(c => c.InfrastructureID).Skip(0).Take(2).ToList();
                        count = (from c in db.Infrastructures select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with Infrastructure info
                        jsonRet = infrastructureController.GetInfrastructureList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(infrastructureList[0].InfrastructureID, ((List<Infrastructure>)ret.Value)[0].InfrastructureID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<Infrastructure>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with Infrastructure info
                           IActionResult jsonRet2 = infrastructureController.GetInfrastructureList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(infrastructureList[1].InfrastructureID, ((List<Infrastructure>)ret2.Value)[0].InfrastructureID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<Infrastructure>)ret2.Value).Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void Infrastructure_Controller_GetInfrastructureWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    InfrastructureController infrastructureController = new InfrastructureController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(infrastructureController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, infrastructureController.DatabaseType);

                    Infrastructure infrastructureFirst = new Infrastructure();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        InfrastructureService infrastructureService = new InfrastructureService(new Query(), db, ContactID);
                        infrastructureFirst = (from c in db.Infrastructures select c).FirstOrDefault();
                    }

                    // ok with Infrastructure info
                    IActionResult jsonRet = infrastructureController.GetInfrastructureWithID(infrastructureFirst.InfrastructureID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(infrastructureFirst.InfrastructureID, ((Infrastructure)ret.Value).InfrastructureID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = infrastructureController.GetInfrastructureWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult infrastructureRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(infrastructureRet2);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void Infrastructure_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    InfrastructureController infrastructureController = new InfrastructureController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(infrastructureController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, infrastructureController.DatabaseType);

                    Infrastructure infrastructureFirst = new Infrastructure();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        InfrastructureService infrastructureService = new InfrastructureService(query, db, ContactID);
                        infrastructureFirst = (from c in db.Infrastructures select c).FirstOrDefault();
                    }

                    // ok with Infrastructure info
                    IActionResult jsonRet = infrastructureController.GetInfrastructureWithID(infrastructureFirst.InfrastructureID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Infrastructure infrastructureRet = (Infrastructure)ret.Value;
                    Assert.Equal(infrastructureFirst.InfrastructureID, infrastructureRet.InfrastructureID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because InfrastructureID exist
                    IActionResult jsonRet2 = infrastructureController.Post(infrastructureRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added Infrastructure
                    infrastructureRet.InfrastructureID = 0;
                    IActionResult jsonRet3 = infrastructureController.Post(infrastructureRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = infrastructureController.Delete(infrastructureRet, LanguageRequest.ToString());
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
        public void Infrastructure_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    InfrastructureController infrastructureController = new InfrastructureController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(infrastructureController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, infrastructureController.DatabaseType);

                    Infrastructure infrastructureFirst = new Infrastructure();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        InfrastructureService infrastructureService = new InfrastructureService(query, db, ContactID);
                        infrastructureFirst = (from c in db.Infrastructures select c).FirstOrDefault();
                    }

                    // ok with Infrastructure info
                    IActionResult jsonRet = infrastructureController.GetInfrastructureWithID(infrastructureFirst.InfrastructureID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    Infrastructure infrastructureRet = (Infrastructure)Ret.Value;
                    Assert.Equal(infrastructureFirst.InfrastructureID, infrastructureRet.InfrastructureID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = infrastructureController.Put(infrastructureRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult infrastructureRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(infrastructureRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because InfrastructureID of 0 does not exist
                    infrastructureRet.InfrastructureID = 0;
                    IActionResult jsonRet3 = infrastructureController.Put(infrastructureRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult infrastructureRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(infrastructureRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void Infrastructure_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    InfrastructureController infrastructureController = new InfrastructureController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(infrastructureController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, infrastructureController.DatabaseType);

                    Infrastructure infrastructureFirst = new Infrastructure();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        InfrastructureService infrastructureService = new InfrastructureService(query, db, ContactID);
                        infrastructureFirst = (from c in db.Infrastructures select c).FirstOrDefault();
                    }

                    // ok with Infrastructure info
                    IActionResult jsonRet = infrastructureController.GetInfrastructureWithID(infrastructureFirst.InfrastructureID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    Infrastructure infrastructureRet = (Infrastructure)Ret.Value;
                    Assert.Equal(infrastructureFirst.InfrastructureID, infrastructureRet.InfrastructureID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added Infrastructure
                    infrastructureRet.InfrastructureID = 0;
                    IActionResult jsonRet3 = infrastructureController.Post(infrastructureRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    Infrastructure infrastructure = (Infrastructure)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = infrastructureController.Delete(infrastructureRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because InfrastructureID of 0 does not exist
                    infrastructureRet.InfrastructureID = 0;
                    IActionResult jsonRet4 = infrastructureController.Delete(infrastructureRet, LanguageRequest.ToString());
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
