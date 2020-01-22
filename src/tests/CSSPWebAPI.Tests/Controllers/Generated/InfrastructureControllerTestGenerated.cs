using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Xunit;
using CSSPWebAPI.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.AspNetCore.Mvc;

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
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<List<Infrastructure>> ret = jsonRet as OkNegotiatedContentResult<List<Infrastructure>>;
                    Assert.Equal(infrastructureFirst.InfrastructureID, ret.Content[0].InfrastructureID);
                    Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

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
                        Assert.NotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<Infrastructure>>;
                        Assert.Equal(infrastructureList[0].InfrastructureID, ret.Content[0].InfrastructureID);
                        Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with Infrastructure info
                           IActionResult jsonRet2 = infrastructureController.GetInfrastructureList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkNegotiatedContentResult<List<Infrastructure>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<Infrastructure>>;
                           Assert.Equal(infrastructureList[1].InfrastructureID, ret2.Content[0].InfrastructureID);
                           Assert.Equal((count > query.Take ? query.Take : count), ret2.Content.Count);
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
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<Infrastructure> Ret = jsonRet as OkNegotiatedContentResult<Infrastructure>;
                    Infrastructure infrastructureRet = Ret.Content;
                    Assert.Equal(infrastructureFirst.InfrastructureID, infrastructureRet.InfrastructureID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = infrastructureController.GetInfrastructureWithID(0);
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<Infrastructure> infrastructureRet2 = jsonRet2 as OkNegotiatedContentResult<Infrastructure>;
                    Assert.Null(infrastructureRet2);

                    NotFoundObjectResult notFoundRequest = jsonRet2 as NotFoundObjectResult;
                    Assert.NotNull(notFoundRequest);
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

                    Infrastructure infrastructureLast = new Infrastructure();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        InfrastructureService infrastructureService = new InfrastructureService(query, db, ContactID);
                        infrastructureLast = (from c in db.Infrastructures select c).FirstOrDefault();
                    }

                    // ok with Infrastructure info
                    IActionResult jsonRet = infrastructureController.GetInfrastructureWithID(infrastructureLast.InfrastructureID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<Infrastructure> Ret = jsonRet as OkNegotiatedContentResult<Infrastructure>;
                    Infrastructure infrastructureRet = Ret.Content;
                    Assert.Equal(infrastructureLast.InfrastructureID, infrastructureRet.InfrastructureID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because InfrastructureID exist
                    IActionResult jsonRet2 = infrastructureController.Post(infrastructureRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<Infrastructure> infrastructureRet2 = jsonRet2 as OkNegotiatedContentResult<Infrastructure>;
                    Assert.Null(infrastructureRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added Infrastructure
                    infrastructureRet.InfrastructureID = 0;
                    infrastructureController.Request = new System.Net.Http.HttpRequestMessage();
                    infrastructureController.Request.RequestUri = new System.Uri("http://localhost:5000/api/infrastructure");
                    IActionResult jsonRet3 = infrastructureController.Post(infrastructureRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<Infrastructure> infrastructureRet3 = jsonRet3 as CreatedNegotiatedContentResult<Infrastructure>;
                    Assert.NotNull(infrastructureRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = infrastructureController.Delete(infrastructureRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<Infrastructure> infrastructureRet4 = jsonRet4 as OkNegotiatedContentResult<Infrastructure>;
                    Assert.NotNull(infrastructureRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
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

                    Infrastructure infrastructureLast = new Infrastructure();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        InfrastructureService infrastructureService = new InfrastructureService(query, db, ContactID);
                        infrastructureLast = (from c in db.Infrastructures select c).FirstOrDefault();
                    }

                    // ok with Infrastructure info
                    IActionResult jsonRet = infrastructureController.GetInfrastructureWithID(infrastructureLast.InfrastructureID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<Infrastructure> Ret = jsonRet as OkNegotiatedContentResult<Infrastructure>;
                    Infrastructure infrastructureRet = Ret.Content;
                    Assert.Equal(infrastructureLast.InfrastructureID, infrastructureRet.InfrastructureID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = infrastructureController.Put(infrastructureRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<Infrastructure> infrastructureRet2 = jsonRet2 as OkNegotiatedContentResult<Infrastructure>;
                    Assert.NotNull(infrastructureRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because InfrastructureID of 0 does not exist
                    infrastructureRet.InfrastructureID = 0;
                    IActionResult jsonRet3 = infrastructureController.Put(infrastructureRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    OkNegotiatedContentResult<Infrastructure> infrastructureRet3 = jsonRet3 as OkNegotiatedContentResult<Infrastructure>;
                    Assert.Null(infrastructureRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
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

                    Infrastructure infrastructureLast = new Infrastructure();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        InfrastructureService infrastructureService = new InfrastructureService(query, db, ContactID);
                        infrastructureLast = (from c in db.Infrastructures select c).FirstOrDefault();
                    }

                    // ok with Infrastructure info
                    IActionResult jsonRet = infrastructureController.GetInfrastructureWithID(infrastructureLast.InfrastructureID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<Infrastructure> Ret = jsonRet as OkNegotiatedContentResult<Infrastructure>;
                    Infrastructure infrastructureRet = Ret.Content;
                    Assert.Equal(infrastructureLast.InfrastructureID, infrastructureRet.InfrastructureID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return newly added Infrastructure
                    infrastructureRet.InfrastructureID = 0;
                    infrastructureController.Request = new System.Net.Http.HttpRequestMessage();
                    infrastructureController.Request.RequestUri = new System.Uri("http://localhost:5000/api/infrastructure");
                    IActionResult jsonRet3 = infrastructureController.Post(infrastructureRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<Infrastructure> infrastructureRet3 = jsonRet3 as CreatedNegotiatedContentResult<Infrastructure>;
                    Assert.NotNull(infrastructureRet3);
                    Infrastructure infrastructure = infrastructureRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = infrastructureController.Delete(infrastructureRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<Infrastructure> infrastructureRet2 = jsonRet2 as OkNegotiatedContentResult<Infrastructure>;
                    Assert.NotNull(infrastructureRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because InfrastructureID of 0 does not exist
                    infrastructureRet.InfrastructureID = 0;
                    IActionResult jsonRet4 = infrastructureController.Delete(infrastructureRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<Infrastructure> infrastructureRet4 = jsonRet4 as OkNegotiatedContentResult<Infrastructure>;
                    Assert.Null(infrastructureRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
