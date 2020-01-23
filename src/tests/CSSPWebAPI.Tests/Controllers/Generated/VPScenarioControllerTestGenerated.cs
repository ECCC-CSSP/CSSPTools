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
    public partial class VPScenarioControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public VPScenarioControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void VPScenario_Controller_GetVPScenarioList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    VPScenarioController vpScenarioController = new VPScenarioController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(vpScenarioController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, vpScenarioController.DatabaseType);

                    VPScenario vpScenarioFirst = new VPScenario();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        VPScenarioService vpScenarioService = new VPScenarioService(query, db, ContactID);
                        vpScenarioFirst = (from c in db.VPScenarios select c).FirstOrDefault();
                        count = (from c in db.VPScenarios select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with VPScenario info
                    IActionResult jsonRet = vpScenarioController.GetVPScenarioList();
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<List<VPScenario>> ret = jsonRet as OkNegotiatedContentResult<List<VPScenario>>;
                    Assert.Equal(vpScenarioFirst.VPScenarioID, ret.Content[0].VPScenarioID);
                    Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<VPScenario> vpScenarioList = new List<VPScenario>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        VPScenarioService vpScenarioService = new VPScenarioService(query, db, ContactID);
                        vpScenarioList = (from c in db.VPScenarios select c).OrderBy(c => c.VPScenarioID).Skip(0).Take(2).ToList();
                        count = (from c in db.VPScenarios select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with VPScenario info
                        jsonRet = vpScenarioController.GetVPScenarioList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.NotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<VPScenario>>;
                        Assert.Equal(vpScenarioList[0].VPScenarioID, ret.Content[0].VPScenarioID);
                        Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with VPScenario info
                           IActionResult jsonRet2 = vpScenarioController.GetVPScenarioList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkNegotiatedContentResult<List<VPScenario>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<VPScenario>>;
                           Assert.Equal(vpScenarioList[1].VPScenarioID, ret2.Content[0].VPScenarioID);
                           Assert.Equal((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void VPScenario_Controller_GetVPScenarioWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    VPScenarioController vpScenarioController = new VPScenarioController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(vpScenarioController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, vpScenarioController.DatabaseType);

                    VPScenario vpScenarioFirst = new VPScenario();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        VPScenarioService vpScenarioService = new VPScenarioService(new Query(), db, ContactID);
                        vpScenarioFirst = (from c in db.VPScenarios select c).FirstOrDefault();
                    }

                    // ok with VPScenario info
                    IActionResult jsonRet = vpScenarioController.GetVPScenarioWithID(vpScenarioFirst.VPScenarioID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<VPScenario> Ret = jsonRet as OkNegotiatedContentResult<VPScenario>;
                    VPScenario vpScenarioRet = Ret.Content;
                    Assert.Equal(vpScenarioFirst.VPScenarioID, vpScenarioRet.VPScenarioID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = vpScenarioController.GetVPScenarioWithID(0);
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<VPScenario> vpScenarioRet2 = jsonRet2 as OkNegotiatedContentResult<VPScenario>;
                    Assert.Null(vpScenarioRet2);

                    NotFoundObjectResult notFoundRequest = jsonRet2 as NotFoundObjectResult;
                    Assert.NotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void VPScenario_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    VPScenarioController vpScenarioController = new VPScenarioController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(vpScenarioController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, vpScenarioController.DatabaseType);

                    VPScenario vpScenarioLast = new VPScenario();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        VPScenarioService vpScenarioService = new VPScenarioService(query, db, ContactID);
                        vpScenarioLast = (from c in db.VPScenarios select c).FirstOrDefault();
                    }

                    // ok with VPScenario info
                    IActionResult jsonRet = vpScenarioController.GetVPScenarioWithID(vpScenarioLast.VPScenarioID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<VPScenario> Ret = jsonRet as OkNegotiatedContentResult<VPScenario>;
                    VPScenario vpScenarioRet = Ret.Content;
                    Assert.Equal(vpScenarioLast.VPScenarioID, vpScenarioRet.VPScenarioID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because VPScenarioID exist
                    IActionResult jsonRet2 = vpScenarioController.Post(vpScenarioRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<VPScenario> vpScenarioRet2 = jsonRet2 as OkNegotiatedContentResult<VPScenario>;
                    Assert.Null(vpScenarioRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added VPScenario
                    vpScenarioRet.VPScenarioID = 0;
                    IActionResult jsonRet3 = vpScenarioController.Post(vpScenarioRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<VPScenario> vpScenarioRet3 = jsonRet3 as CreatedNegotiatedContentResult<VPScenario>;
                    Assert.NotNull(vpScenarioRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = vpScenarioController.Delete(vpScenarioRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<VPScenario> vpScenarioRet4 = jsonRet4 as OkNegotiatedContentResult<VPScenario>;
                    Assert.NotNull(vpScenarioRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [Fact]
        public void VPScenario_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    VPScenarioController vpScenarioController = new VPScenarioController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(vpScenarioController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, vpScenarioController.DatabaseType);

                    VPScenario vpScenarioLast = new VPScenario();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        VPScenarioService vpScenarioService = new VPScenarioService(query, db, ContactID);
                        vpScenarioLast = (from c in db.VPScenarios select c).FirstOrDefault();
                    }

                    // ok with VPScenario info
                    IActionResult jsonRet = vpScenarioController.GetVPScenarioWithID(vpScenarioLast.VPScenarioID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<VPScenario> Ret = jsonRet as OkNegotiatedContentResult<VPScenario>;
                    VPScenario vpScenarioRet = Ret.Content;
                    Assert.Equal(vpScenarioLast.VPScenarioID, vpScenarioRet.VPScenarioID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = vpScenarioController.Put(vpScenarioRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<VPScenario> vpScenarioRet2 = jsonRet2 as OkNegotiatedContentResult<VPScenario>;
                    Assert.NotNull(vpScenarioRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because VPScenarioID of 0 does not exist
                    vpScenarioRet.VPScenarioID = 0;
                    IActionResult jsonRet3 = vpScenarioController.Put(vpScenarioRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    OkNegotiatedContentResult<VPScenario> vpScenarioRet3 = jsonRet3 as OkNegotiatedContentResult<VPScenario>;
                    Assert.Null(vpScenarioRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void VPScenario_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    VPScenarioController vpScenarioController = new VPScenarioController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(vpScenarioController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, vpScenarioController.DatabaseType);

                    VPScenario vpScenarioLast = new VPScenario();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        VPScenarioService vpScenarioService = new VPScenarioService(query, db, ContactID);
                        vpScenarioLast = (from c in db.VPScenarios select c).FirstOrDefault();
                    }

                    // ok with VPScenario info
                    IActionResult jsonRet = vpScenarioController.GetVPScenarioWithID(vpScenarioLast.VPScenarioID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<VPScenario> Ret = jsonRet as OkNegotiatedContentResult<VPScenario>;
                    VPScenario vpScenarioRet = Ret.Content;
                    Assert.Equal(vpScenarioLast.VPScenarioID, vpScenarioRet.VPScenarioID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return newly added VPScenario
                    vpScenarioRet.VPScenarioID = 0;
                    IActionResult jsonRet3 = vpScenarioController.Post(vpScenarioRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<VPScenario> vpScenarioRet3 = jsonRet3 as CreatedNegotiatedContentResult<VPScenario>;
                    Assert.NotNull(vpScenarioRet3);
                    VPScenario vpScenario = vpScenarioRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = vpScenarioController.Delete(vpScenarioRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<VPScenario> vpScenarioRet2 = jsonRet2 as OkNegotiatedContentResult<VPScenario>;
                    Assert.NotNull(vpScenarioRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because VPScenarioID of 0 does not exist
                    vpScenarioRet.VPScenarioID = 0;
                    IActionResult jsonRet4 = vpScenarioController.Delete(vpScenarioRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<VPScenario> vpScenarioRet4 = jsonRet4 as OkNegotiatedContentResult<VPScenario>;
                    Assert.Null(vpScenarioRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
