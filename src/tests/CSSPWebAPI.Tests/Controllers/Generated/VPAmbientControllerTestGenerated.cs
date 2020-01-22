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
    public partial class VPAmbientControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public VPAmbientControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void VPAmbient_Controller_GetVPAmbientList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    VPAmbientController vpAmbientController = new VPAmbientController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(vpAmbientController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, vpAmbientController.DatabaseType);

                    VPAmbient vpAmbientFirst = new VPAmbient();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        VPAmbientService vpAmbientService = new VPAmbientService(query, db, ContactID);
                        vpAmbientFirst = (from c in db.VPAmbients select c).FirstOrDefault();
                        count = (from c in db.VPAmbients select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with VPAmbient info
                    IActionResult jsonRet = vpAmbientController.GetVPAmbientList();
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<List<VPAmbient>> ret = jsonRet as OkNegotiatedContentResult<List<VPAmbient>>;
                    Assert.Equal(vpAmbientFirst.VPAmbientID, ret.Content[0].VPAmbientID);
                    Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<VPAmbient> vpAmbientList = new List<VPAmbient>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        VPAmbientService vpAmbientService = new VPAmbientService(query, db, ContactID);
                        vpAmbientList = (from c in db.VPAmbients select c).OrderBy(c => c.VPAmbientID).Skip(0).Take(2).ToList();
                        count = (from c in db.VPAmbients select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with VPAmbient info
                        jsonRet = vpAmbientController.GetVPAmbientList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.NotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<VPAmbient>>;
                        Assert.Equal(vpAmbientList[0].VPAmbientID, ret.Content[0].VPAmbientID);
                        Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with VPAmbient info
                           IActionResult jsonRet2 = vpAmbientController.GetVPAmbientList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkNegotiatedContentResult<List<VPAmbient>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<VPAmbient>>;
                           Assert.Equal(vpAmbientList[1].VPAmbientID, ret2.Content[0].VPAmbientID);
                           Assert.Equal((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void VPAmbient_Controller_GetVPAmbientWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    VPAmbientController vpAmbientController = new VPAmbientController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(vpAmbientController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, vpAmbientController.DatabaseType);

                    VPAmbient vpAmbientFirst = new VPAmbient();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        VPAmbientService vpAmbientService = new VPAmbientService(new Query(), db, ContactID);
                        vpAmbientFirst = (from c in db.VPAmbients select c).FirstOrDefault();
                    }

                    // ok with VPAmbient info
                    IActionResult jsonRet = vpAmbientController.GetVPAmbientWithID(vpAmbientFirst.VPAmbientID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<VPAmbient> Ret = jsonRet as OkNegotiatedContentResult<VPAmbient>;
                    VPAmbient vpAmbientRet = Ret.Content;
                    Assert.Equal(vpAmbientFirst.VPAmbientID, vpAmbientRet.VPAmbientID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = vpAmbientController.GetVPAmbientWithID(0);
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<VPAmbient> vpAmbientRet2 = jsonRet2 as OkNegotiatedContentResult<VPAmbient>;
                    Assert.Null(vpAmbientRet2);

                    NotFoundObjectResult notFoundRequest = jsonRet2 as NotFoundObjectResult;
                    Assert.NotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void VPAmbient_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    VPAmbientController vpAmbientController = new VPAmbientController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(vpAmbientController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, vpAmbientController.DatabaseType);

                    VPAmbient vpAmbientLast = new VPAmbient();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        VPAmbientService vpAmbientService = new VPAmbientService(query, db, ContactID);
                        vpAmbientLast = (from c in db.VPAmbients select c).FirstOrDefault();
                    }

                    // ok with VPAmbient info
                    IActionResult jsonRet = vpAmbientController.GetVPAmbientWithID(vpAmbientLast.VPAmbientID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<VPAmbient> Ret = jsonRet as OkNegotiatedContentResult<VPAmbient>;
                    VPAmbient vpAmbientRet = Ret.Content;
                    Assert.Equal(vpAmbientLast.VPAmbientID, vpAmbientRet.VPAmbientID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because VPAmbientID exist
                    IActionResult jsonRet2 = vpAmbientController.Post(vpAmbientRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<VPAmbient> vpAmbientRet2 = jsonRet2 as OkNegotiatedContentResult<VPAmbient>;
                    Assert.Null(vpAmbientRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added VPAmbient
                    vpAmbientRet.VPAmbientID = 0;
                    vpAmbientController.Request = new System.Net.Http.HttpRequestMessage();
                    vpAmbientController.Request.RequestUri = new System.Uri("http://localhost:5000/api/vpAmbient");
                    IActionResult jsonRet3 = vpAmbientController.Post(vpAmbientRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<VPAmbient> vpAmbientRet3 = jsonRet3 as CreatedNegotiatedContentResult<VPAmbient>;
                    Assert.NotNull(vpAmbientRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = vpAmbientController.Delete(vpAmbientRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<VPAmbient> vpAmbientRet4 = jsonRet4 as OkNegotiatedContentResult<VPAmbient>;
                    Assert.NotNull(vpAmbientRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [Fact]
        public void VPAmbient_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    VPAmbientController vpAmbientController = new VPAmbientController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(vpAmbientController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, vpAmbientController.DatabaseType);

                    VPAmbient vpAmbientLast = new VPAmbient();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        VPAmbientService vpAmbientService = new VPAmbientService(query, db, ContactID);
                        vpAmbientLast = (from c in db.VPAmbients select c).FirstOrDefault();
                    }

                    // ok with VPAmbient info
                    IActionResult jsonRet = vpAmbientController.GetVPAmbientWithID(vpAmbientLast.VPAmbientID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<VPAmbient> Ret = jsonRet as OkNegotiatedContentResult<VPAmbient>;
                    VPAmbient vpAmbientRet = Ret.Content;
                    Assert.Equal(vpAmbientLast.VPAmbientID, vpAmbientRet.VPAmbientID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = vpAmbientController.Put(vpAmbientRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<VPAmbient> vpAmbientRet2 = jsonRet2 as OkNegotiatedContentResult<VPAmbient>;
                    Assert.NotNull(vpAmbientRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because VPAmbientID of 0 does not exist
                    vpAmbientRet.VPAmbientID = 0;
                    IActionResult jsonRet3 = vpAmbientController.Put(vpAmbientRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    OkNegotiatedContentResult<VPAmbient> vpAmbientRet3 = jsonRet3 as OkNegotiatedContentResult<VPAmbient>;
                    Assert.Null(vpAmbientRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void VPAmbient_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    VPAmbientController vpAmbientController = new VPAmbientController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(vpAmbientController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, vpAmbientController.DatabaseType);

                    VPAmbient vpAmbientLast = new VPAmbient();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        VPAmbientService vpAmbientService = new VPAmbientService(query, db, ContactID);
                        vpAmbientLast = (from c in db.VPAmbients select c).FirstOrDefault();
                    }

                    // ok with VPAmbient info
                    IActionResult jsonRet = vpAmbientController.GetVPAmbientWithID(vpAmbientLast.VPAmbientID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<VPAmbient> Ret = jsonRet as OkNegotiatedContentResult<VPAmbient>;
                    VPAmbient vpAmbientRet = Ret.Content;
                    Assert.Equal(vpAmbientLast.VPAmbientID, vpAmbientRet.VPAmbientID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return newly added VPAmbient
                    vpAmbientRet.VPAmbientID = 0;
                    vpAmbientController.Request = new System.Net.Http.HttpRequestMessage();
                    vpAmbientController.Request.RequestUri = new System.Uri("http://localhost:5000/api/vpAmbient");
                    IActionResult jsonRet3 = vpAmbientController.Post(vpAmbientRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<VPAmbient> vpAmbientRet3 = jsonRet3 as CreatedNegotiatedContentResult<VPAmbient>;
                    Assert.NotNull(vpAmbientRet3);
                    VPAmbient vpAmbient = vpAmbientRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = vpAmbientController.Delete(vpAmbientRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<VPAmbient> vpAmbientRet2 = jsonRet2 as OkNegotiatedContentResult<VPAmbient>;
                    Assert.NotNull(vpAmbientRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because VPAmbientID of 0 does not exist
                    vpAmbientRet.VPAmbientID = 0;
                    IActionResult jsonRet4 = vpAmbientController.Delete(vpAmbientRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<VPAmbient> vpAmbientRet4 = jsonRet4 as OkNegotiatedContentResult<VPAmbient>;
                    Assert.Null(vpAmbientRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
