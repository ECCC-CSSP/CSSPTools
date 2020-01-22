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
    public partial class MikeScenarioControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MikeScenarioControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void MikeScenario_Controller_GetMikeScenarioList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MikeScenarioController mikeScenarioController = new MikeScenarioController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mikeScenarioController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mikeScenarioController.DatabaseType);

                    MikeScenario mikeScenarioFirst = new MikeScenario();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        MikeScenarioService mikeScenarioService = new MikeScenarioService(query, db, ContactID);
                        mikeScenarioFirst = (from c in db.MikeScenarios select c).FirstOrDefault();
                        count = (from c in db.MikeScenarios select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with MikeScenario info
                    IActionResult jsonRet = mikeScenarioController.GetMikeScenarioList();
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<List<MikeScenario>> ret = jsonRet as OkNegotiatedContentResult<List<MikeScenario>>;
                    Assert.Equal(mikeScenarioFirst.MikeScenarioID, ret.Content[0].MikeScenarioID);
                    Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<MikeScenario> mikeScenarioList = new List<MikeScenario>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        MikeScenarioService mikeScenarioService = new MikeScenarioService(query, db, ContactID);
                        mikeScenarioList = (from c in db.MikeScenarios select c).OrderBy(c => c.MikeScenarioID).Skip(0).Take(2).ToList();
                        count = (from c in db.MikeScenarios select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with MikeScenario info
                        jsonRet = mikeScenarioController.GetMikeScenarioList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.NotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<MikeScenario>>;
                        Assert.Equal(mikeScenarioList[0].MikeScenarioID, ret.Content[0].MikeScenarioID);
                        Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with MikeScenario info
                           IActionResult jsonRet2 = mikeScenarioController.GetMikeScenarioList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkNegotiatedContentResult<List<MikeScenario>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<MikeScenario>>;
                           Assert.Equal(mikeScenarioList[1].MikeScenarioID, ret2.Content[0].MikeScenarioID);
                           Assert.Equal((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void MikeScenario_Controller_GetMikeScenarioWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MikeScenarioController mikeScenarioController = new MikeScenarioController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mikeScenarioController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mikeScenarioController.DatabaseType);

                    MikeScenario mikeScenarioFirst = new MikeScenario();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        MikeScenarioService mikeScenarioService = new MikeScenarioService(new Query(), db, ContactID);
                        mikeScenarioFirst = (from c in db.MikeScenarios select c).FirstOrDefault();
                    }

                    // ok with MikeScenario info
                    IActionResult jsonRet = mikeScenarioController.GetMikeScenarioWithID(mikeScenarioFirst.MikeScenarioID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<MikeScenario> Ret = jsonRet as OkNegotiatedContentResult<MikeScenario>;
                    MikeScenario mikeScenarioRet = Ret.Content;
                    Assert.Equal(mikeScenarioFirst.MikeScenarioID, mikeScenarioRet.MikeScenarioID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = mikeScenarioController.GetMikeScenarioWithID(0);
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<MikeScenario> mikeScenarioRet2 = jsonRet2 as OkNegotiatedContentResult<MikeScenario>;
                    Assert.Null(mikeScenarioRet2);

                    NotFoundObjectResult notFoundRequest = jsonRet2 as NotFoundObjectResult;
                    Assert.NotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void MikeScenario_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MikeScenarioController mikeScenarioController = new MikeScenarioController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mikeScenarioController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mikeScenarioController.DatabaseType);

                    MikeScenario mikeScenarioLast = new MikeScenario();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MikeScenarioService mikeScenarioService = new MikeScenarioService(query, db, ContactID);
                        mikeScenarioLast = (from c in db.MikeScenarios select c).FirstOrDefault();
                    }

                    // ok with MikeScenario info
                    IActionResult jsonRet = mikeScenarioController.GetMikeScenarioWithID(mikeScenarioLast.MikeScenarioID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<MikeScenario> Ret = jsonRet as OkNegotiatedContentResult<MikeScenario>;
                    MikeScenario mikeScenarioRet = Ret.Content;
                    Assert.Equal(mikeScenarioLast.MikeScenarioID, mikeScenarioRet.MikeScenarioID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because MikeScenarioID exist
                    IActionResult jsonRet2 = mikeScenarioController.Post(mikeScenarioRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<MikeScenario> mikeScenarioRet2 = jsonRet2 as OkNegotiatedContentResult<MikeScenario>;
                    Assert.Null(mikeScenarioRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added MikeScenario
                    mikeScenarioRet.MikeScenarioID = 0;
                    mikeScenarioController.Request = new System.Net.Http.HttpRequestMessage();
                    mikeScenarioController.Request.RequestUri = new System.Uri("http://localhost:5000/api/mikeScenario");
                    IActionResult jsonRet3 = mikeScenarioController.Post(mikeScenarioRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<MikeScenario> mikeScenarioRet3 = jsonRet3 as CreatedNegotiatedContentResult<MikeScenario>;
                    Assert.NotNull(mikeScenarioRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = mikeScenarioController.Delete(mikeScenarioRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<MikeScenario> mikeScenarioRet4 = jsonRet4 as OkNegotiatedContentResult<MikeScenario>;
                    Assert.NotNull(mikeScenarioRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [Fact]
        public void MikeScenario_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MikeScenarioController mikeScenarioController = new MikeScenarioController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mikeScenarioController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mikeScenarioController.DatabaseType);

                    MikeScenario mikeScenarioLast = new MikeScenario();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        MikeScenarioService mikeScenarioService = new MikeScenarioService(query, db, ContactID);
                        mikeScenarioLast = (from c in db.MikeScenarios select c).FirstOrDefault();
                    }

                    // ok with MikeScenario info
                    IActionResult jsonRet = mikeScenarioController.GetMikeScenarioWithID(mikeScenarioLast.MikeScenarioID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<MikeScenario> Ret = jsonRet as OkNegotiatedContentResult<MikeScenario>;
                    MikeScenario mikeScenarioRet = Ret.Content;
                    Assert.Equal(mikeScenarioLast.MikeScenarioID, mikeScenarioRet.MikeScenarioID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = mikeScenarioController.Put(mikeScenarioRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<MikeScenario> mikeScenarioRet2 = jsonRet2 as OkNegotiatedContentResult<MikeScenario>;
                    Assert.NotNull(mikeScenarioRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because MikeScenarioID of 0 does not exist
                    mikeScenarioRet.MikeScenarioID = 0;
                    IActionResult jsonRet3 = mikeScenarioController.Put(mikeScenarioRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    OkNegotiatedContentResult<MikeScenario> mikeScenarioRet3 = jsonRet3 as OkNegotiatedContentResult<MikeScenario>;
                    Assert.Null(mikeScenarioRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void MikeScenario_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MikeScenarioController mikeScenarioController = new MikeScenarioController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mikeScenarioController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mikeScenarioController.DatabaseType);

                    MikeScenario mikeScenarioLast = new MikeScenario();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MikeScenarioService mikeScenarioService = new MikeScenarioService(query, db, ContactID);
                        mikeScenarioLast = (from c in db.MikeScenarios select c).FirstOrDefault();
                    }

                    // ok with MikeScenario info
                    IActionResult jsonRet = mikeScenarioController.GetMikeScenarioWithID(mikeScenarioLast.MikeScenarioID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<MikeScenario> Ret = jsonRet as OkNegotiatedContentResult<MikeScenario>;
                    MikeScenario mikeScenarioRet = Ret.Content;
                    Assert.Equal(mikeScenarioLast.MikeScenarioID, mikeScenarioRet.MikeScenarioID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return newly added MikeScenario
                    mikeScenarioRet.MikeScenarioID = 0;
                    mikeScenarioController.Request = new System.Net.Http.HttpRequestMessage();
                    mikeScenarioController.Request.RequestUri = new System.Uri("http://localhost:5000/api/mikeScenario");
                    IActionResult jsonRet3 = mikeScenarioController.Post(mikeScenarioRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<MikeScenario> mikeScenarioRet3 = jsonRet3 as CreatedNegotiatedContentResult<MikeScenario>;
                    Assert.NotNull(mikeScenarioRet3);
                    MikeScenario mikeScenario = mikeScenarioRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = mikeScenarioController.Delete(mikeScenarioRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<MikeScenario> mikeScenarioRet2 = jsonRet2 as OkNegotiatedContentResult<MikeScenario>;
                    Assert.NotNull(mikeScenarioRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because MikeScenarioID of 0 does not exist
                    mikeScenarioRet.MikeScenarioID = 0;
                    IActionResult jsonRet4 = mikeScenarioController.Delete(mikeScenarioRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<MikeScenario> mikeScenarioRet4 = jsonRet4 as OkNegotiatedContentResult<MikeScenario>;
                    Assert.Null(mikeScenarioRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
