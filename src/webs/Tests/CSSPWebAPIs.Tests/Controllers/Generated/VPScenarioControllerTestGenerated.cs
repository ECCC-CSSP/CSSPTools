using CSSPEnums;
using CSSPModels;
using CSSPServices;
using CSSPWebAPI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;

namespace CSSPWebAPI.Tests.Controllers
{
    [TestClass]
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
        [TestMethod]
        public void VPScenario_Controller_GetVPScenarioList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    VPScenarioController vpScenarioController = new VPScenarioController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(vpScenarioController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, vpScenarioController.DatabaseType);

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
                    IHttpActionResult jsonRet = vpScenarioController.GetVPScenarioList();
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<List<VPScenario>> ret = jsonRet as OkNegotiatedContentResult<List<VPScenario>>;
                    Assert.AreEqual(vpScenarioFirst.VPScenarioID, ret.Content[0].VPScenarioID);
                    Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

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
                        Assert.IsNotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<VPScenario>>;
                        Assert.AreEqual(vpScenarioList[0].VPScenarioID, ret.Content[0].VPScenarioID);
                        Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with VPScenario info
                           IHttpActionResult jsonRet2 = vpScenarioController.GetVPScenarioList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.IsNotNull(jsonRet2);

                           OkNegotiatedContentResult<List<VPScenario>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<VPScenario>>;
                           Assert.AreEqual(vpScenarioList[1].VPScenarioID, ret2.Content[0].VPScenarioID);
                           Assert.AreEqual((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [TestMethod]
        public void VPScenario_Controller_GetVPScenarioWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    VPScenarioController vpScenarioController = new VPScenarioController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(vpScenarioController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, vpScenarioController.DatabaseType);

                    VPScenario vpScenarioFirst = new VPScenario();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        VPScenarioService vpScenarioService = new VPScenarioService(new Query(), db, ContactID);
                        vpScenarioFirst = (from c in db.VPScenarios select c).FirstOrDefault();
                    }

                    // ok with VPScenario info
                    IHttpActionResult jsonRet = vpScenarioController.GetVPScenarioWithID(vpScenarioFirst.VPScenarioID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<VPScenario> Ret = jsonRet as OkNegotiatedContentResult<VPScenario>;
                    VPScenario vpScenarioRet = Ret.Content;
                    Assert.AreEqual(vpScenarioFirst.VPScenarioID, vpScenarioRet.VPScenarioID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = vpScenarioController.GetVPScenarioWithID(0);
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<VPScenario> vpScenarioRet2 = jsonRet2 as OkNegotiatedContentResult<VPScenario>;
                    Assert.IsNull(vpScenarioRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.IsNotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [TestMethod]
        public void VPScenario_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    VPScenarioController vpScenarioController = new VPScenarioController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(vpScenarioController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, vpScenarioController.DatabaseType);

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
                    IHttpActionResult jsonRet = vpScenarioController.GetVPScenarioWithID(vpScenarioLast.VPScenarioID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<VPScenario> Ret = jsonRet as OkNegotiatedContentResult<VPScenario>;
                    VPScenario vpScenarioRet = Ret.Content;
                    Assert.AreEqual(vpScenarioLast.VPScenarioID, vpScenarioRet.VPScenarioID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because VPScenarioID exist
                    IHttpActionResult jsonRet2 = vpScenarioController.Post(vpScenarioRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<VPScenario> vpScenarioRet2 = jsonRet2 as OkNegotiatedContentResult<VPScenario>;
                    Assert.IsNull(vpScenarioRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest2);

                    // Post to return newly added VPScenario
                    vpScenarioRet.VPScenarioID = 0;
                    vpScenarioController.Request = new System.Net.Http.HttpRequestMessage();
                    vpScenarioController.Request.RequestUri = new System.Uri("http://localhost:5000/api/vpScenario");
                    IHttpActionResult jsonRet3 = vpScenarioController.Post(vpScenarioRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<VPScenario> vpScenarioRet3 = jsonRet3 as CreatedNegotiatedContentResult<VPScenario>;
                    Assert.IsNotNull(vpScenarioRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = vpScenarioController.Delete(vpScenarioRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<VPScenario> vpScenarioRet4 = jsonRet4 as OkNegotiatedContentResult<VPScenario>;
                    Assert.IsNotNull(vpScenarioRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [TestMethod]
        public void VPScenario_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    VPScenarioController vpScenarioController = new VPScenarioController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(vpScenarioController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, vpScenarioController.DatabaseType);

                    VPScenario vpScenarioLast = new VPScenario();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        VPScenarioService vpScenarioService = new VPScenarioService(query, db, ContactID);
                        vpScenarioLast = (from c in db.VPScenarios select c).FirstOrDefault();
                    }

                    // ok with VPScenario info
                    IHttpActionResult jsonRet = vpScenarioController.GetVPScenarioWithID(vpScenarioLast.VPScenarioID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<VPScenario> Ret = jsonRet as OkNegotiatedContentResult<VPScenario>;
                    VPScenario vpScenarioRet = Ret.Content;
                    Assert.AreEqual(vpScenarioLast.VPScenarioID, vpScenarioRet.VPScenarioID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = vpScenarioController.Put(vpScenarioRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<VPScenario> vpScenarioRet2 = jsonRet2 as OkNegotiatedContentResult<VPScenario>;
                    Assert.IsNotNull(vpScenarioRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because VPScenarioID of 0 does not exist
                    vpScenarioRet.VPScenarioID = 0;
                    IHttpActionResult jsonRet3 = vpScenarioController.Put(vpScenarioRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    OkNegotiatedContentResult<VPScenario> vpScenarioRet3 = jsonRet3 as OkNegotiatedContentResult<VPScenario>;
                    Assert.IsNull(vpScenarioRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [TestMethod]
        public void VPScenario_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    VPScenarioController vpScenarioController = new VPScenarioController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(vpScenarioController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, vpScenarioController.DatabaseType);

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
                    IHttpActionResult jsonRet = vpScenarioController.GetVPScenarioWithID(vpScenarioLast.VPScenarioID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<VPScenario> Ret = jsonRet as OkNegotiatedContentResult<VPScenario>;
                    VPScenario vpScenarioRet = Ret.Content;
                    Assert.AreEqual(vpScenarioLast.VPScenarioID, vpScenarioRet.VPScenarioID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added VPScenario
                    vpScenarioRet.VPScenarioID = 0;
                    vpScenarioController.Request = new System.Net.Http.HttpRequestMessage();
                    vpScenarioController.Request.RequestUri = new System.Uri("http://localhost:5000/api/vpScenario");
                    IHttpActionResult jsonRet3 = vpScenarioController.Post(vpScenarioRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<VPScenario> vpScenarioRet3 = jsonRet3 as CreatedNegotiatedContentResult<VPScenario>;
                    Assert.IsNotNull(vpScenarioRet3);
                    VPScenario vpScenario = vpScenarioRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = vpScenarioController.Delete(vpScenarioRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<VPScenario> vpScenarioRet2 = jsonRet2 as OkNegotiatedContentResult<VPScenario>;
                    Assert.IsNotNull(vpScenarioRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because VPScenarioID of 0 does not exist
                    vpScenarioRet.VPScenarioID = 0;
                    IHttpActionResult jsonRet4 = vpScenarioController.Delete(vpScenarioRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<VPScenario> vpScenarioRet4 = jsonRet4 as OkNegotiatedContentResult<VPScenario>;
                    Assert.IsNull(vpScenarioRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
