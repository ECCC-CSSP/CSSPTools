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
    public partial class MWQMSubsectorLanguageControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MWQMSubsectorLanguageControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void MWQMSubsectorLanguage_Controller_GetMWQMSubsectorLanguageList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMSubsectorLanguageController mwqmSubsectorLanguageController = new MWQMSubsectorLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mwqmSubsectorLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mwqmSubsectorLanguageController.DatabaseType);

                    MWQMSubsectorLanguage mwqmSubsectorLanguageFirst = new MWQMSubsectorLanguage();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        MWQMSubsectorLanguageService mwqmSubsectorLanguageService = new MWQMSubsectorLanguageService(query, db, ContactID);
                        mwqmSubsectorLanguageFirst = (from c in db.MWQMSubsectorLanguages select c).FirstOrDefault();
                        count = (from c in db.MWQMSubsectorLanguages select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with MWQMSubsectorLanguage info
                    IActionResult jsonRet = mwqmSubsectorLanguageController.GetMWQMSubsectorLanguageList();
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<List<MWQMSubsectorLanguage>> ret = jsonRet as OkNegotiatedContentResult<List<MWQMSubsectorLanguage>>;
                    Assert.Equal(mwqmSubsectorLanguageFirst.MWQMSubsectorLanguageID, ret.Content[0].MWQMSubsectorLanguageID);
                    Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<MWQMSubsectorLanguage> mwqmSubsectorLanguageList = new List<MWQMSubsectorLanguage>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        MWQMSubsectorLanguageService mwqmSubsectorLanguageService = new MWQMSubsectorLanguageService(query, db, ContactID);
                        mwqmSubsectorLanguageList = (from c in db.MWQMSubsectorLanguages select c).OrderBy(c => c.MWQMSubsectorLanguageID).Skip(0).Take(2).ToList();
                        count = (from c in db.MWQMSubsectorLanguages select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with MWQMSubsectorLanguage info
                        jsonRet = mwqmSubsectorLanguageController.GetMWQMSubsectorLanguageList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.NotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<MWQMSubsectorLanguage>>;
                        Assert.Equal(mwqmSubsectorLanguageList[0].MWQMSubsectorLanguageID, ret.Content[0].MWQMSubsectorLanguageID);
                        Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with MWQMSubsectorLanguage info
                           IActionResult jsonRet2 = mwqmSubsectorLanguageController.GetMWQMSubsectorLanguageList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkNegotiatedContentResult<List<MWQMSubsectorLanguage>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<MWQMSubsectorLanguage>>;
                           Assert.Equal(mwqmSubsectorLanguageList[1].MWQMSubsectorLanguageID, ret2.Content[0].MWQMSubsectorLanguageID);
                           Assert.Equal((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void MWQMSubsectorLanguage_Controller_GetMWQMSubsectorLanguageWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMSubsectorLanguageController mwqmSubsectorLanguageController = new MWQMSubsectorLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mwqmSubsectorLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mwqmSubsectorLanguageController.DatabaseType);

                    MWQMSubsectorLanguage mwqmSubsectorLanguageFirst = new MWQMSubsectorLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        MWQMSubsectorLanguageService mwqmSubsectorLanguageService = new MWQMSubsectorLanguageService(new Query(), db, ContactID);
                        mwqmSubsectorLanguageFirst = (from c in db.MWQMSubsectorLanguages select c).FirstOrDefault();
                    }

                    // ok with MWQMSubsectorLanguage info
                    IActionResult jsonRet = mwqmSubsectorLanguageController.GetMWQMSubsectorLanguageWithID(mwqmSubsectorLanguageFirst.MWQMSubsectorLanguageID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<MWQMSubsectorLanguage> Ret = jsonRet as OkNegotiatedContentResult<MWQMSubsectorLanguage>;
                    MWQMSubsectorLanguage mwqmSubsectorLanguageRet = Ret.Content;
                    Assert.Equal(mwqmSubsectorLanguageFirst.MWQMSubsectorLanguageID, mwqmSubsectorLanguageRet.MWQMSubsectorLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = mwqmSubsectorLanguageController.GetMWQMSubsectorLanguageWithID(0);
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<MWQMSubsectorLanguage> mwqmSubsectorLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<MWQMSubsectorLanguage>;
                    Assert.Null(mwqmSubsectorLanguageRet2);

                    NotFoundObjectResult notFoundRequest = jsonRet2 as NotFoundObjectResult;
                    Assert.NotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void MWQMSubsectorLanguage_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMSubsectorLanguageController mwqmSubsectorLanguageController = new MWQMSubsectorLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mwqmSubsectorLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mwqmSubsectorLanguageController.DatabaseType);

                    MWQMSubsectorLanguage mwqmSubsectorLanguageLast = new MWQMSubsectorLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MWQMSubsectorLanguageService mwqmSubsectorLanguageService = new MWQMSubsectorLanguageService(query, db, ContactID);
                        mwqmSubsectorLanguageLast = (from c in db.MWQMSubsectorLanguages select c).FirstOrDefault();
                    }

                    // ok with MWQMSubsectorLanguage info
                    IActionResult jsonRet = mwqmSubsectorLanguageController.GetMWQMSubsectorLanguageWithID(mwqmSubsectorLanguageLast.MWQMSubsectorLanguageID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<MWQMSubsectorLanguage> Ret = jsonRet as OkNegotiatedContentResult<MWQMSubsectorLanguage>;
                    MWQMSubsectorLanguage mwqmSubsectorLanguageRet = Ret.Content;
                    Assert.Equal(mwqmSubsectorLanguageLast.MWQMSubsectorLanguageID, mwqmSubsectorLanguageRet.MWQMSubsectorLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because MWQMSubsectorLanguageID exist
                    IActionResult jsonRet2 = mwqmSubsectorLanguageController.Post(mwqmSubsectorLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<MWQMSubsectorLanguage> mwqmSubsectorLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<MWQMSubsectorLanguage>;
                    Assert.Null(mwqmSubsectorLanguageRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added MWQMSubsectorLanguage
                    mwqmSubsectorLanguageRet.MWQMSubsectorLanguageID = 0;
                    mwqmSubsectorLanguageController.Request = new System.Net.Http.HttpRequestMessage();
                    mwqmSubsectorLanguageController.Request.RequestUri = new System.Uri("http://localhost:5000/api/mwqmSubsectorLanguage");
                    IActionResult jsonRet3 = mwqmSubsectorLanguageController.Post(mwqmSubsectorLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<MWQMSubsectorLanguage> mwqmSubsectorLanguageRet3 = jsonRet3 as CreatedNegotiatedContentResult<MWQMSubsectorLanguage>;
                    Assert.NotNull(mwqmSubsectorLanguageRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = mwqmSubsectorLanguageController.Delete(mwqmSubsectorLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<MWQMSubsectorLanguage> mwqmSubsectorLanguageRet4 = jsonRet4 as OkNegotiatedContentResult<MWQMSubsectorLanguage>;
                    Assert.NotNull(mwqmSubsectorLanguageRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [Fact]
        public void MWQMSubsectorLanguage_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMSubsectorLanguageController mwqmSubsectorLanguageController = new MWQMSubsectorLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mwqmSubsectorLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mwqmSubsectorLanguageController.DatabaseType);

                    MWQMSubsectorLanguage mwqmSubsectorLanguageLast = new MWQMSubsectorLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        MWQMSubsectorLanguageService mwqmSubsectorLanguageService = new MWQMSubsectorLanguageService(query, db, ContactID);
                        mwqmSubsectorLanguageLast = (from c in db.MWQMSubsectorLanguages select c).FirstOrDefault();
                    }

                    // ok with MWQMSubsectorLanguage info
                    IActionResult jsonRet = mwqmSubsectorLanguageController.GetMWQMSubsectorLanguageWithID(mwqmSubsectorLanguageLast.MWQMSubsectorLanguageID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<MWQMSubsectorLanguage> Ret = jsonRet as OkNegotiatedContentResult<MWQMSubsectorLanguage>;
                    MWQMSubsectorLanguage mwqmSubsectorLanguageRet = Ret.Content;
                    Assert.Equal(mwqmSubsectorLanguageLast.MWQMSubsectorLanguageID, mwqmSubsectorLanguageRet.MWQMSubsectorLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = mwqmSubsectorLanguageController.Put(mwqmSubsectorLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<MWQMSubsectorLanguage> mwqmSubsectorLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<MWQMSubsectorLanguage>;
                    Assert.NotNull(mwqmSubsectorLanguageRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because MWQMSubsectorLanguageID of 0 does not exist
                    mwqmSubsectorLanguageRet.MWQMSubsectorLanguageID = 0;
                    IActionResult jsonRet3 = mwqmSubsectorLanguageController.Put(mwqmSubsectorLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    OkNegotiatedContentResult<MWQMSubsectorLanguage> mwqmSubsectorLanguageRet3 = jsonRet3 as OkNegotiatedContentResult<MWQMSubsectorLanguage>;
                    Assert.Null(mwqmSubsectorLanguageRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void MWQMSubsectorLanguage_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMSubsectorLanguageController mwqmSubsectorLanguageController = new MWQMSubsectorLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mwqmSubsectorLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mwqmSubsectorLanguageController.DatabaseType);

                    MWQMSubsectorLanguage mwqmSubsectorLanguageLast = new MWQMSubsectorLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MWQMSubsectorLanguageService mwqmSubsectorLanguageService = new MWQMSubsectorLanguageService(query, db, ContactID);
                        mwqmSubsectorLanguageLast = (from c in db.MWQMSubsectorLanguages select c).FirstOrDefault();
                    }

                    // ok with MWQMSubsectorLanguage info
                    IActionResult jsonRet = mwqmSubsectorLanguageController.GetMWQMSubsectorLanguageWithID(mwqmSubsectorLanguageLast.MWQMSubsectorLanguageID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<MWQMSubsectorLanguage> Ret = jsonRet as OkNegotiatedContentResult<MWQMSubsectorLanguage>;
                    MWQMSubsectorLanguage mwqmSubsectorLanguageRet = Ret.Content;
                    Assert.Equal(mwqmSubsectorLanguageLast.MWQMSubsectorLanguageID, mwqmSubsectorLanguageRet.MWQMSubsectorLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return newly added MWQMSubsectorLanguage
                    mwqmSubsectorLanguageRet.MWQMSubsectorLanguageID = 0;
                    mwqmSubsectorLanguageController.Request = new System.Net.Http.HttpRequestMessage();
                    mwqmSubsectorLanguageController.Request.RequestUri = new System.Uri("http://localhost:5000/api/mwqmSubsectorLanguage");
                    IActionResult jsonRet3 = mwqmSubsectorLanguageController.Post(mwqmSubsectorLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<MWQMSubsectorLanguage> mwqmSubsectorLanguageRet3 = jsonRet3 as CreatedNegotiatedContentResult<MWQMSubsectorLanguage>;
                    Assert.NotNull(mwqmSubsectorLanguageRet3);
                    MWQMSubsectorLanguage mwqmSubsectorLanguage = mwqmSubsectorLanguageRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = mwqmSubsectorLanguageController.Delete(mwqmSubsectorLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<MWQMSubsectorLanguage> mwqmSubsectorLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<MWQMSubsectorLanguage>;
                    Assert.NotNull(mwqmSubsectorLanguageRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because MWQMSubsectorLanguageID of 0 does not exist
                    mwqmSubsectorLanguageRet.MWQMSubsectorLanguageID = 0;
                    IActionResult jsonRet4 = mwqmSubsectorLanguageController.Delete(mwqmSubsectorLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<MWQMSubsectorLanguage> mwqmSubsectorLanguageRet4 = jsonRet4 as OkNegotiatedContentResult<MWQMSubsectorLanguage>;
                    Assert.Null(mwqmSubsectorLanguageRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
