using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Xunit;
using CSSPWebAPI.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;

namespace CSSPWebAPI.Tests.Controllers
{
    public partial class VPScenarioLanguageControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public VPScenarioLanguageControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void VPScenarioLanguage_Controller_GetVPScenarioLanguageList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    VPScenarioLanguageController vpScenarioLanguageController = new VPScenarioLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(vpScenarioLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, vpScenarioLanguageController.DatabaseType);

                    VPScenarioLanguage vpScenarioLanguageFirst = new VPScenarioLanguage();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        VPScenarioLanguageService vpScenarioLanguageService = new VPScenarioLanguageService(query, db, ContactID);
                        vpScenarioLanguageFirst = (from c in db.VPScenarioLanguages select c).FirstOrDefault();
                        count = (from c in db.VPScenarioLanguages select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with VPScenarioLanguage info
                    IHttpActionResult jsonRet = vpScenarioLanguageController.GetVPScenarioLanguageList();
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<List<VPScenarioLanguage>> ret = jsonRet as OkNegotiatedContentResult<List<VPScenarioLanguage>>;
                    Assert.Equal(vpScenarioLanguageFirst.VPScenarioLanguageID, ret.Content[0].VPScenarioLanguageID);
                    Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<VPScenarioLanguage> vpScenarioLanguageList = new List<VPScenarioLanguage>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        VPScenarioLanguageService vpScenarioLanguageService = new VPScenarioLanguageService(query, db, ContactID);
                        vpScenarioLanguageList = (from c in db.VPScenarioLanguages select c).OrderBy(c => c.VPScenarioLanguageID).Skip(0).Take(2).ToList();
                        count = (from c in db.VPScenarioLanguages select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with VPScenarioLanguage info
                        jsonRet = vpScenarioLanguageController.GetVPScenarioLanguageList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.NotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<VPScenarioLanguage>>;
                        Assert.Equal(vpScenarioLanguageList[0].VPScenarioLanguageID, ret.Content[0].VPScenarioLanguageID);
                        Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with VPScenarioLanguage info
                           IHttpActionResult jsonRet2 = vpScenarioLanguageController.GetVPScenarioLanguageList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkNegotiatedContentResult<List<VPScenarioLanguage>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<VPScenarioLanguage>>;
                           Assert.Equal(vpScenarioLanguageList[1].VPScenarioLanguageID, ret2.Content[0].VPScenarioLanguageID);
                           Assert.Equal((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void VPScenarioLanguage_Controller_GetVPScenarioLanguageWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    VPScenarioLanguageController vpScenarioLanguageController = new VPScenarioLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(vpScenarioLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, vpScenarioLanguageController.DatabaseType);

                    VPScenarioLanguage vpScenarioLanguageFirst = new VPScenarioLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        VPScenarioLanguageService vpScenarioLanguageService = new VPScenarioLanguageService(new Query(), db, ContactID);
                        vpScenarioLanguageFirst = (from c in db.VPScenarioLanguages select c).FirstOrDefault();
                    }

                    // ok with VPScenarioLanguage info
                    IHttpActionResult jsonRet = vpScenarioLanguageController.GetVPScenarioLanguageWithID(vpScenarioLanguageFirst.VPScenarioLanguageID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<VPScenarioLanguage> Ret = jsonRet as OkNegotiatedContentResult<VPScenarioLanguage>;
                    VPScenarioLanguage vpScenarioLanguageRet = Ret.Content;
                    Assert.Equal(vpScenarioLanguageFirst.VPScenarioLanguageID, vpScenarioLanguageRet.VPScenarioLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = vpScenarioLanguageController.GetVPScenarioLanguageWithID(0);
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<VPScenarioLanguage> vpScenarioLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<VPScenarioLanguage>;
                    Assert.IsNull(vpScenarioLanguageRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.NotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void VPScenarioLanguage_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    VPScenarioLanguageController vpScenarioLanguageController = new VPScenarioLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(vpScenarioLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, vpScenarioLanguageController.DatabaseType);

                    VPScenarioLanguage vpScenarioLanguageLast = new VPScenarioLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        VPScenarioLanguageService vpScenarioLanguageService = new VPScenarioLanguageService(query, db, ContactID);
                        vpScenarioLanguageLast = (from c in db.VPScenarioLanguages select c).FirstOrDefault();
                    }

                    // ok with VPScenarioLanguage info
                    IHttpActionResult jsonRet = vpScenarioLanguageController.GetVPScenarioLanguageWithID(vpScenarioLanguageLast.VPScenarioLanguageID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<VPScenarioLanguage> Ret = jsonRet as OkNegotiatedContentResult<VPScenarioLanguage>;
                    VPScenarioLanguage vpScenarioLanguageRet = Ret.Content;
                    Assert.Equal(vpScenarioLanguageLast.VPScenarioLanguageID, vpScenarioLanguageRet.VPScenarioLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because VPScenarioLanguageID exist
                    IHttpActionResult jsonRet2 = vpScenarioLanguageController.Post(vpScenarioLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<VPScenarioLanguage> vpScenarioLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<VPScenarioLanguage>;
                    Assert.IsNull(vpScenarioLanguageRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added VPScenarioLanguage
                    vpScenarioLanguageRet.VPScenarioLanguageID = 0;
                    vpScenarioLanguageController.Request = new System.Net.Http.HttpRequestMessage();
                    vpScenarioLanguageController.Request.RequestUri = new System.Uri("http://localhost:5000/api/vpScenarioLanguage");
                    IHttpActionResult jsonRet3 = vpScenarioLanguageController.Post(vpScenarioLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<VPScenarioLanguage> vpScenarioLanguageRet3 = jsonRet3 as CreatedNegotiatedContentResult<VPScenarioLanguage>;
                    Assert.NotNull(vpScenarioLanguageRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = vpScenarioLanguageController.Delete(vpScenarioLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<VPScenarioLanguage> vpScenarioLanguageRet4 = jsonRet4 as OkNegotiatedContentResult<VPScenarioLanguage>;
                    Assert.NotNull(vpScenarioLanguageRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [Fact]
        public void VPScenarioLanguage_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    VPScenarioLanguageController vpScenarioLanguageController = new VPScenarioLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(vpScenarioLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, vpScenarioLanguageController.DatabaseType);

                    VPScenarioLanguage vpScenarioLanguageLast = new VPScenarioLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        VPScenarioLanguageService vpScenarioLanguageService = new VPScenarioLanguageService(query, db, ContactID);
                        vpScenarioLanguageLast = (from c in db.VPScenarioLanguages select c).FirstOrDefault();
                    }

                    // ok with VPScenarioLanguage info
                    IHttpActionResult jsonRet = vpScenarioLanguageController.GetVPScenarioLanguageWithID(vpScenarioLanguageLast.VPScenarioLanguageID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<VPScenarioLanguage> Ret = jsonRet as OkNegotiatedContentResult<VPScenarioLanguage>;
                    VPScenarioLanguage vpScenarioLanguageRet = Ret.Content;
                    Assert.Equal(vpScenarioLanguageLast.VPScenarioLanguageID, vpScenarioLanguageRet.VPScenarioLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = vpScenarioLanguageController.Put(vpScenarioLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<VPScenarioLanguage> vpScenarioLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<VPScenarioLanguage>;
                    Assert.NotNull(vpScenarioLanguageRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because VPScenarioLanguageID of 0 does not exist
                    vpScenarioLanguageRet.VPScenarioLanguageID = 0;
                    IHttpActionResult jsonRet3 = vpScenarioLanguageController.Put(vpScenarioLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    OkNegotiatedContentResult<VPScenarioLanguage> vpScenarioLanguageRet3 = jsonRet3 as OkNegotiatedContentResult<VPScenarioLanguage>;
                    Assert.IsNull(vpScenarioLanguageRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void VPScenarioLanguage_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    VPScenarioLanguageController vpScenarioLanguageController = new VPScenarioLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(vpScenarioLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, vpScenarioLanguageController.DatabaseType);

                    VPScenarioLanguage vpScenarioLanguageLast = new VPScenarioLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        VPScenarioLanguageService vpScenarioLanguageService = new VPScenarioLanguageService(query, db, ContactID);
                        vpScenarioLanguageLast = (from c in db.VPScenarioLanguages select c).FirstOrDefault();
                    }

                    // ok with VPScenarioLanguage info
                    IHttpActionResult jsonRet = vpScenarioLanguageController.GetVPScenarioLanguageWithID(vpScenarioLanguageLast.VPScenarioLanguageID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<VPScenarioLanguage> Ret = jsonRet as OkNegotiatedContentResult<VPScenarioLanguage>;
                    VPScenarioLanguage vpScenarioLanguageRet = Ret.Content;
                    Assert.Equal(vpScenarioLanguageLast.VPScenarioLanguageID, vpScenarioLanguageRet.VPScenarioLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added VPScenarioLanguage
                    vpScenarioLanguageRet.VPScenarioLanguageID = 0;
                    vpScenarioLanguageController.Request = new System.Net.Http.HttpRequestMessage();
                    vpScenarioLanguageController.Request.RequestUri = new System.Uri("http://localhost:5000/api/vpScenarioLanguage");
                    IHttpActionResult jsonRet3 = vpScenarioLanguageController.Post(vpScenarioLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<VPScenarioLanguage> vpScenarioLanguageRet3 = jsonRet3 as CreatedNegotiatedContentResult<VPScenarioLanguage>;
                    Assert.NotNull(vpScenarioLanguageRet3);
                    VPScenarioLanguage vpScenarioLanguage = vpScenarioLanguageRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = vpScenarioLanguageController.Delete(vpScenarioLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<VPScenarioLanguage> vpScenarioLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<VPScenarioLanguage>;
                    Assert.NotNull(vpScenarioLanguageRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because VPScenarioLanguageID of 0 does not exist
                    vpScenarioLanguageRet.VPScenarioLanguageID = 0;
                    IHttpActionResult jsonRet4 = vpScenarioLanguageController.Delete(vpScenarioLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<VPScenarioLanguage> vpScenarioLanguageRet4 = jsonRet4 as OkNegotiatedContentResult<VPScenarioLanguage>;
                    Assert.IsNull(vpScenarioLanguageRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
