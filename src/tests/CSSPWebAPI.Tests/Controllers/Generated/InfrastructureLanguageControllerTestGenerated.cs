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
    public partial class InfrastructureLanguageControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public InfrastructureLanguageControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void InfrastructureLanguage_Controller_GetInfrastructureLanguageList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    InfrastructureLanguageController infrastructureLanguageController = new InfrastructureLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(infrastructureLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, infrastructureLanguageController.DatabaseType);

                    InfrastructureLanguage infrastructureLanguageFirst = new InfrastructureLanguage();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        InfrastructureLanguageService infrastructureLanguageService = new InfrastructureLanguageService(query, db, ContactID);
                        infrastructureLanguageFirst = (from c in db.InfrastructureLanguages select c).FirstOrDefault();
                        count = (from c in db.InfrastructureLanguages select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with InfrastructureLanguage info
                    IActionResult jsonRet = infrastructureLanguageController.GetInfrastructureLanguageList();
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<List<InfrastructureLanguage>> ret = jsonRet as OkNegotiatedContentResult<List<InfrastructureLanguage>>;
                    Assert.Equal(infrastructureLanguageFirst.InfrastructureLanguageID, ret.Content[0].InfrastructureLanguageID);
                    Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<InfrastructureLanguage> infrastructureLanguageList = new List<InfrastructureLanguage>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        InfrastructureLanguageService infrastructureLanguageService = new InfrastructureLanguageService(query, db, ContactID);
                        infrastructureLanguageList = (from c in db.InfrastructureLanguages select c).OrderBy(c => c.InfrastructureLanguageID).Skip(0).Take(2).ToList();
                        count = (from c in db.InfrastructureLanguages select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with InfrastructureLanguage info
                        jsonRet = infrastructureLanguageController.GetInfrastructureLanguageList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.NotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<InfrastructureLanguage>>;
                        Assert.Equal(infrastructureLanguageList[0].InfrastructureLanguageID, ret.Content[0].InfrastructureLanguageID);
                        Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with InfrastructureLanguage info
                           IActionResult jsonRet2 = infrastructureLanguageController.GetInfrastructureLanguageList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkNegotiatedContentResult<List<InfrastructureLanguage>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<InfrastructureLanguage>>;
                           Assert.Equal(infrastructureLanguageList[1].InfrastructureLanguageID, ret2.Content[0].InfrastructureLanguageID);
                           Assert.Equal((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void InfrastructureLanguage_Controller_GetInfrastructureLanguageWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    InfrastructureLanguageController infrastructureLanguageController = new InfrastructureLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(infrastructureLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, infrastructureLanguageController.DatabaseType);

                    InfrastructureLanguage infrastructureLanguageFirst = new InfrastructureLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        InfrastructureLanguageService infrastructureLanguageService = new InfrastructureLanguageService(new Query(), db, ContactID);
                        infrastructureLanguageFirst = (from c in db.InfrastructureLanguages select c).FirstOrDefault();
                    }

                    // ok with InfrastructureLanguage info
                    IActionResult jsonRet = infrastructureLanguageController.GetInfrastructureLanguageWithID(infrastructureLanguageFirst.InfrastructureLanguageID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<InfrastructureLanguage> Ret = jsonRet as OkNegotiatedContentResult<InfrastructureLanguage>;
                    InfrastructureLanguage infrastructureLanguageRet = Ret.Content;
                    Assert.Equal(infrastructureLanguageFirst.InfrastructureLanguageID, infrastructureLanguageRet.InfrastructureLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = infrastructureLanguageController.GetInfrastructureLanguageWithID(0);
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<InfrastructureLanguage> infrastructureLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<InfrastructureLanguage>;
                    Assert.Null(infrastructureLanguageRet2);

                    NotFoundObjectResult notFoundRequest = jsonRet2 as NotFoundObjectResult;
                    Assert.NotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void InfrastructureLanguage_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    InfrastructureLanguageController infrastructureLanguageController = new InfrastructureLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(infrastructureLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, infrastructureLanguageController.DatabaseType);

                    InfrastructureLanguage infrastructureLanguageLast = new InfrastructureLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        InfrastructureLanguageService infrastructureLanguageService = new InfrastructureLanguageService(query, db, ContactID);
                        infrastructureLanguageLast = (from c in db.InfrastructureLanguages select c).FirstOrDefault();
                    }

                    // ok with InfrastructureLanguage info
                    IActionResult jsonRet = infrastructureLanguageController.GetInfrastructureLanguageWithID(infrastructureLanguageLast.InfrastructureLanguageID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<InfrastructureLanguage> Ret = jsonRet as OkNegotiatedContentResult<InfrastructureLanguage>;
                    InfrastructureLanguage infrastructureLanguageRet = Ret.Content;
                    Assert.Equal(infrastructureLanguageLast.InfrastructureLanguageID, infrastructureLanguageRet.InfrastructureLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because InfrastructureLanguageID exist
                    IActionResult jsonRet2 = infrastructureLanguageController.Post(infrastructureLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<InfrastructureLanguage> infrastructureLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<InfrastructureLanguage>;
                    Assert.Null(infrastructureLanguageRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added InfrastructureLanguage
                    infrastructureLanguageRet.InfrastructureLanguageID = 0;
                    IActionResult jsonRet3 = infrastructureLanguageController.Post(infrastructureLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<InfrastructureLanguage> infrastructureLanguageRet3 = jsonRet3 as CreatedNegotiatedContentResult<InfrastructureLanguage>;
                    Assert.NotNull(infrastructureLanguageRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = infrastructureLanguageController.Delete(infrastructureLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<InfrastructureLanguage> infrastructureLanguageRet4 = jsonRet4 as OkNegotiatedContentResult<InfrastructureLanguage>;
                    Assert.NotNull(infrastructureLanguageRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [Fact]
        public void InfrastructureLanguage_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    InfrastructureLanguageController infrastructureLanguageController = new InfrastructureLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(infrastructureLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, infrastructureLanguageController.DatabaseType);

                    InfrastructureLanguage infrastructureLanguageLast = new InfrastructureLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        InfrastructureLanguageService infrastructureLanguageService = new InfrastructureLanguageService(query, db, ContactID);
                        infrastructureLanguageLast = (from c in db.InfrastructureLanguages select c).FirstOrDefault();
                    }

                    // ok with InfrastructureLanguage info
                    IActionResult jsonRet = infrastructureLanguageController.GetInfrastructureLanguageWithID(infrastructureLanguageLast.InfrastructureLanguageID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<InfrastructureLanguage> Ret = jsonRet as OkNegotiatedContentResult<InfrastructureLanguage>;
                    InfrastructureLanguage infrastructureLanguageRet = Ret.Content;
                    Assert.Equal(infrastructureLanguageLast.InfrastructureLanguageID, infrastructureLanguageRet.InfrastructureLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = infrastructureLanguageController.Put(infrastructureLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<InfrastructureLanguage> infrastructureLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<InfrastructureLanguage>;
                    Assert.NotNull(infrastructureLanguageRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because InfrastructureLanguageID of 0 does not exist
                    infrastructureLanguageRet.InfrastructureLanguageID = 0;
                    IActionResult jsonRet3 = infrastructureLanguageController.Put(infrastructureLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    OkNegotiatedContentResult<InfrastructureLanguage> infrastructureLanguageRet3 = jsonRet3 as OkNegotiatedContentResult<InfrastructureLanguage>;
                    Assert.Null(infrastructureLanguageRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void InfrastructureLanguage_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    InfrastructureLanguageController infrastructureLanguageController = new InfrastructureLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(infrastructureLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, infrastructureLanguageController.DatabaseType);

                    InfrastructureLanguage infrastructureLanguageLast = new InfrastructureLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        InfrastructureLanguageService infrastructureLanguageService = new InfrastructureLanguageService(query, db, ContactID);
                        infrastructureLanguageLast = (from c in db.InfrastructureLanguages select c).FirstOrDefault();
                    }

                    // ok with InfrastructureLanguage info
                    IActionResult jsonRet = infrastructureLanguageController.GetInfrastructureLanguageWithID(infrastructureLanguageLast.InfrastructureLanguageID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<InfrastructureLanguage> Ret = jsonRet as OkNegotiatedContentResult<InfrastructureLanguage>;
                    InfrastructureLanguage infrastructureLanguageRet = Ret.Content;
                    Assert.Equal(infrastructureLanguageLast.InfrastructureLanguageID, infrastructureLanguageRet.InfrastructureLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return newly added InfrastructureLanguage
                    infrastructureLanguageRet.InfrastructureLanguageID = 0;
                    IActionResult jsonRet3 = infrastructureLanguageController.Post(infrastructureLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<InfrastructureLanguage> infrastructureLanguageRet3 = jsonRet3 as CreatedNegotiatedContentResult<InfrastructureLanguage>;
                    Assert.NotNull(infrastructureLanguageRet3);
                    InfrastructureLanguage infrastructureLanguage = infrastructureLanguageRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = infrastructureLanguageController.Delete(infrastructureLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<InfrastructureLanguage> infrastructureLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<InfrastructureLanguage>;
                    Assert.NotNull(infrastructureLanguageRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because InfrastructureLanguageID of 0 does not exist
                    infrastructureLanguageRet.InfrastructureLanguageID = 0;
                    IActionResult jsonRet4 = infrastructureLanguageController.Delete(infrastructureLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<InfrastructureLanguage> infrastructureLanguageRet4 = jsonRet4 as OkNegotiatedContentResult<InfrastructureLanguage>;
                    Assert.Null(infrastructureLanguageRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
