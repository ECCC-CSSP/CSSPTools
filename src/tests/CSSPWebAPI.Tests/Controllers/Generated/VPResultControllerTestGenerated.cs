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
    public partial class VPResultControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public VPResultControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void VPResult_Controller_GetVPResultList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    VPResultController vpResultController = new VPResultController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(vpResultController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, vpResultController.DatabaseType);

                    VPResult vpResultFirst = new VPResult();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        VPResultService vpResultService = new VPResultService(query, db, ContactID);
                        vpResultFirst = (from c in db.VPResults select c).FirstOrDefault();
                        count = (from c in db.VPResults select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with VPResult info
                    IActionResult jsonRet = vpResultController.GetVPResultList();
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<List<VPResult>> ret = jsonRet as OkNegotiatedContentResult<List<VPResult>>;
                    Assert.Equal(vpResultFirst.VPResultID, ret.Content[0].VPResultID);
                    Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<VPResult> vpResultList = new List<VPResult>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        VPResultService vpResultService = new VPResultService(query, db, ContactID);
                        vpResultList = (from c in db.VPResults select c).OrderBy(c => c.VPResultID).Skip(0).Take(2).ToList();
                        count = (from c in db.VPResults select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with VPResult info
                        jsonRet = vpResultController.GetVPResultList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.NotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<VPResult>>;
                        Assert.Equal(vpResultList[0].VPResultID, ret.Content[0].VPResultID);
                        Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with VPResult info
                           IActionResult jsonRet2 = vpResultController.GetVPResultList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkNegotiatedContentResult<List<VPResult>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<VPResult>>;
                           Assert.Equal(vpResultList[1].VPResultID, ret2.Content[0].VPResultID);
                           Assert.Equal((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void VPResult_Controller_GetVPResultWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    VPResultController vpResultController = new VPResultController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(vpResultController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, vpResultController.DatabaseType);

                    VPResult vpResultFirst = new VPResult();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        VPResultService vpResultService = new VPResultService(new Query(), db, ContactID);
                        vpResultFirst = (from c in db.VPResults select c).FirstOrDefault();
                    }

                    // ok with VPResult info
                    IActionResult jsonRet = vpResultController.GetVPResultWithID(vpResultFirst.VPResultID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<VPResult> Ret = jsonRet as OkNegotiatedContentResult<VPResult>;
                    VPResult vpResultRet = Ret.Content;
                    Assert.Equal(vpResultFirst.VPResultID, vpResultRet.VPResultID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = vpResultController.GetVPResultWithID(0);
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<VPResult> vpResultRet2 = jsonRet2 as OkNegotiatedContentResult<VPResult>;
                    Assert.Null(vpResultRet2);

                    NotFoundObjectResult notFoundRequest = jsonRet2 as NotFoundObjectResult;
                    Assert.NotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void VPResult_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    VPResultController vpResultController = new VPResultController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(vpResultController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, vpResultController.DatabaseType);

                    VPResult vpResultLast = new VPResult();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        VPResultService vpResultService = new VPResultService(query, db, ContactID);
                        vpResultLast = (from c in db.VPResults select c).FirstOrDefault();
                    }

                    // ok with VPResult info
                    IActionResult jsonRet = vpResultController.GetVPResultWithID(vpResultLast.VPResultID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<VPResult> Ret = jsonRet as OkNegotiatedContentResult<VPResult>;
                    VPResult vpResultRet = Ret.Content;
                    Assert.Equal(vpResultLast.VPResultID, vpResultRet.VPResultID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because VPResultID exist
                    IActionResult jsonRet2 = vpResultController.Post(vpResultRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<VPResult> vpResultRet2 = jsonRet2 as OkNegotiatedContentResult<VPResult>;
                    Assert.Null(vpResultRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added VPResult
                    vpResultRet.VPResultID = 0;
                    IActionResult jsonRet3 = vpResultController.Post(vpResultRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<VPResult> vpResultRet3 = jsonRet3 as CreatedNegotiatedContentResult<VPResult>;
                    Assert.NotNull(vpResultRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = vpResultController.Delete(vpResultRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<VPResult> vpResultRet4 = jsonRet4 as OkNegotiatedContentResult<VPResult>;
                    Assert.NotNull(vpResultRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [Fact]
        public void VPResult_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    VPResultController vpResultController = new VPResultController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(vpResultController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, vpResultController.DatabaseType);

                    VPResult vpResultLast = new VPResult();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        VPResultService vpResultService = new VPResultService(query, db, ContactID);
                        vpResultLast = (from c in db.VPResults select c).FirstOrDefault();
                    }

                    // ok with VPResult info
                    IActionResult jsonRet = vpResultController.GetVPResultWithID(vpResultLast.VPResultID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<VPResult> Ret = jsonRet as OkNegotiatedContentResult<VPResult>;
                    VPResult vpResultRet = Ret.Content;
                    Assert.Equal(vpResultLast.VPResultID, vpResultRet.VPResultID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = vpResultController.Put(vpResultRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<VPResult> vpResultRet2 = jsonRet2 as OkNegotiatedContentResult<VPResult>;
                    Assert.NotNull(vpResultRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because VPResultID of 0 does not exist
                    vpResultRet.VPResultID = 0;
                    IActionResult jsonRet3 = vpResultController.Put(vpResultRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    OkNegotiatedContentResult<VPResult> vpResultRet3 = jsonRet3 as OkNegotiatedContentResult<VPResult>;
                    Assert.Null(vpResultRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void VPResult_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    VPResultController vpResultController = new VPResultController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(vpResultController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, vpResultController.DatabaseType);

                    VPResult vpResultLast = new VPResult();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        VPResultService vpResultService = new VPResultService(query, db, ContactID);
                        vpResultLast = (from c in db.VPResults select c).FirstOrDefault();
                    }

                    // ok with VPResult info
                    IActionResult jsonRet = vpResultController.GetVPResultWithID(vpResultLast.VPResultID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<VPResult> Ret = jsonRet as OkNegotiatedContentResult<VPResult>;
                    VPResult vpResultRet = Ret.Content;
                    Assert.Equal(vpResultLast.VPResultID, vpResultRet.VPResultID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return newly added VPResult
                    vpResultRet.VPResultID = 0;
                    IActionResult jsonRet3 = vpResultController.Post(vpResultRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<VPResult> vpResultRet3 = jsonRet3 as CreatedNegotiatedContentResult<VPResult>;
                    Assert.NotNull(vpResultRet3);
                    VPResult vpResult = vpResultRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = vpResultController.Delete(vpResultRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<VPResult> vpResultRet2 = jsonRet2 as OkNegotiatedContentResult<VPResult>;
                    Assert.NotNull(vpResultRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because VPResultID of 0 does not exist
                    vpResultRet.VPResultID = 0;
                    IActionResult jsonRet4 = vpResultController.Delete(vpResultRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<VPResult> vpResultRet4 = jsonRet4 as OkNegotiatedContentResult<VPResult>;
                    Assert.Null(vpResultRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
