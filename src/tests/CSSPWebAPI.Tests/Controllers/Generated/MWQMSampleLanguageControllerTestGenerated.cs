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
    public partial class MWQMSampleLanguageControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MWQMSampleLanguageControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void MWQMSampleLanguage_Controller_GetMWQMSampleLanguageList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMSampleLanguageController mwqmSampleLanguageController = new MWQMSampleLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mwqmSampleLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mwqmSampleLanguageController.DatabaseType);

                    MWQMSampleLanguage mwqmSampleLanguageFirst = new MWQMSampleLanguage();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        MWQMSampleLanguageService mwqmSampleLanguageService = new MWQMSampleLanguageService(query, db, ContactID);
                        mwqmSampleLanguageFirst = (from c in db.MWQMSampleLanguages select c).FirstOrDefault();
                        count = (from c in db.MWQMSampleLanguages select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with MWQMSampleLanguage info
                    IActionResult jsonRet = mwqmSampleLanguageController.GetMWQMSampleLanguageList();
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<List<MWQMSampleLanguage>> ret = jsonRet as OkNegotiatedContentResult<List<MWQMSampleLanguage>>;
                    Assert.Equal(mwqmSampleLanguageFirst.MWQMSampleLanguageID, ret.Content[0].MWQMSampleLanguageID);
                    Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<MWQMSampleLanguage> mwqmSampleLanguageList = new List<MWQMSampleLanguage>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        MWQMSampleLanguageService mwqmSampleLanguageService = new MWQMSampleLanguageService(query, db, ContactID);
                        mwqmSampleLanguageList = (from c in db.MWQMSampleLanguages select c).OrderBy(c => c.MWQMSampleLanguageID).Skip(0).Take(2).ToList();
                        count = (from c in db.MWQMSampleLanguages select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with MWQMSampleLanguage info
                        jsonRet = mwqmSampleLanguageController.GetMWQMSampleLanguageList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.NotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<MWQMSampleLanguage>>;
                        Assert.Equal(mwqmSampleLanguageList[0].MWQMSampleLanguageID, ret.Content[0].MWQMSampleLanguageID);
                        Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with MWQMSampleLanguage info
                           IActionResult jsonRet2 = mwqmSampleLanguageController.GetMWQMSampleLanguageList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkNegotiatedContentResult<List<MWQMSampleLanguage>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<MWQMSampleLanguage>>;
                           Assert.Equal(mwqmSampleLanguageList[1].MWQMSampleLanguageID, ret2.Content[0].MWQMSampleLanguageID);
                           Assert.Equal((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void MWQMSampleLanguage_Controller_GetMWQMSampleLanguageWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMSampleLanguageController mwqmSampleLanguageController = new MWQMSampleLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mwqmSampleLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mwqmSampleLanguageController.DatabaseType);

                    MWQMSampleLanguage mwqmSampleLanguageFirst = new MWQMSampleLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        MWQMSampleLanguageService mwqmSampleLanguageService = new MWQMSampleLanguageService(new Query(), db, ContactID);
                        mwqmSampleLanguageFirst = (from c in db.MWQMSampleLanguages select c).FirstOrDefault();
                    }

                    // ok with MWQMSampleLanguage info
                    IActionResult jsonRet = mwqmSampleLanguageController.GetMWQMSampleLanguageWithID(mwqmSampleLanguageFirst.MWQMSampleLanguageID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<MWQMSampleLanguage> Ret = jsonRet as OkNegotiatedContentResult<MWQMSampleLanguage>;
                    MWQMSampleLanguage mwqmSampleLanguageRet = Ret.Content;
                    Assert.Equal(mwqmSampleLanguageFirst.MWQMSampleLanguageID, mwqmSampleLanguageRet.MWQMSampleLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = mwqmSampleLanguageController.GetMWQMSampleLanguageWithID(0);
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<MWQMSampleLanguage> mwqmSampleLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<MWQMSampleLanguage>;
                    Assert.Null(mwqmSampleLanguageRet2);

                    NotFoundObjectResult notFoundRequest = jsonRet2 as NotFoundObjectResult;
                    Assert.NotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void MWQMSampleLanguage_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMSampleLanguageController mwqmSampleLanguageController = new MWQMSampleLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mwqmSampleLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mwqmSampleLanguageController.DatabaseType);

                    MWQMSampleLanguage mwqmSampleLanguageLast = new MWQMSampleLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MWQMSampleLanguageService mwqmSampleLanguageService = new MWQMSampleLanguageService(query, db, ContactID);
                        mwqmSampleLanguageLast = (from c in db.MWQMSampleLanguages select c).FirstOrDefault();
                    }

                    // ok with MWQMSampleLanguage info
                    IActionResult jsonRet = mwqmSampleLanguageController.GetMWQMSampleLanguageWithID(mwqmSampleLanguageLast.MWQMSampleLanguageID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<MWQMSampleLanguage> Ret = jsonRet as OkNegotiatedContentResult<MWQMSampleLanguage>;
                    MWQMSampleLanguage mwqmSampleLanguageRet = Ret.Content;
                    Assert.Equal(mwqmSampleLanguageLast.MWQMSampleLanguageID, mwqmSampleLanguageRet.MWQMSampleLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because MWQMSampleLanguageID exist
                    IActionResult jsonRet2 = mwqmSampleLanguageController.Post(mwqmSampleLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<MWQMSampleLanguage> mwqmSampleLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<MWQMSampleLanguage>;
                    Assert.Null(mwqmSampleLanguageRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added MWQMSampleLanguage
                    mwqmSampleLanguageRet.MWQMSampleLanguageID = 0;
                    mwqmSampleLanguageController.Request = new System.Net.Http.HttpRequestMessage();
                    mwqmSampleLanguageController.Request.RequestUri = new System.Uri("http://localhost:5000/api/mwqmSampleLanguage");
                    IActionResult jsonRet3 = mwqmSampleLanguageController.Post(mwqmSampleLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<MWQMSampleLanguage> mwqmSampleLanguageRet3 = jsonRet3 as CreatedNegotiatedContentResult<MWQMSampleLanguage>;
                    Assert.NotNull(mwqmSampleLanguageRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = mwqmSampleLanguageController.Delete(mwqmSampleLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<MWQMSampleLanguage> mwqmSampleLanguageRet4 = jsonRet4 as OkNegotiatedContentResult<MWQMSampleLanguage>;
                    Assert.NotNull(mwqmSampleLanguageRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [Fact]
        public void MWQMSampleLanguage_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMSampleLanguageController mwqmSampleLanguageController = new MWQMSampleLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mwqmSampleLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mwqmSampleLanguageController.DatabaseType);

                    MWQMSampleLanguage mwqmSampleLanguageLast = new MWQMSampleLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        MWQMSampleLanguageService mwqmSampleLanguageService = new MWQMSampleLanguageService(query, db, ContactID);
                        mwqmSampleLanguageLast = (from c in db.MWQMSampleLanguages select c).FirstOrDefault();
                    }

                    // ok with MWQMSampleLanguage info
                    IActionResult jsonRet = mwqmSampleLanguageController.GetMWQMSampleLanguageWithID(mwqmSampleLanguageLast.MWQMSampleLanguageID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<MWQMSampleLanguage> Ret = jsonRet as OkNegotiatedContentResult<MWQMSampleLanguage>;
                    MWQMSampleLanguage mwqmSampleLanguageRet = Ret.Content;
                    Assert.Equal(mwqmSampleLanguageLast.MWQMSampleLanguageID, mwqmSampleLanguageRet.MWQMSampleLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = mwqmSampleLanguageController.Put(mwqmSampleLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<MWQMSampleLanguage> mwqmSampleLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<MWQMSampleLanguage>;
                    Assert.NotNull(mwqmSampleLanguageRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because MWQMSampleLanguageID of 0 does not exist
                    mwqmSampleLanguageRet.MWQMSampleLanguageID = 0;
                    IActionResult jsonRet3 = mwqmSampleLanguageController.Put(mwqmSampleLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    OkNegotiatedContentResult<MWQMSampleLanguage> mwqmSampleLanguageRet3 = jsonRet3 as OkNegotiatedContentResult<MWQMSampleLanguage>;
                    Assert.Null(mwqmSampleLanguageRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void MWQMSampleLanguage_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMSampleLanguageController mwqmSampleLanguageController = new MWQMSampleLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mwqmSampleLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mwqmSampleLanguageController.DatabaseType);

                    MWQMSampleLanguage mwqmSampleLanguageLast = new MWQMSampleLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MWQMSampleLanguageService mwqmSampleLanguageService = new MWQMSampleLanguageService(query, db, ContactID);
                        mwqmSampleLanguageLast = (from c in db.MWQMSampleLanguages select c).FirstOrDefault();
                    }

                    // ok with MWQMSampleLanguage info
                    IActionResult jsonRet = mwqmSampleLanguageController.GetMWQMSampleLanguageWithID(mwqmSampleLanguageLast.MWQMSampleLanguageID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<MWQMSampleLanguage> Ret = jsonRet as OkNegotiatedContentResult<MWQMSampleLanguage>;
                    MWQMSampleLanguage mwqmSampleLanguageRet = Ret.Content;
                    Assert.Equal(mwqmSampleLanguageLast.MWQMSampleLanguageID, mwqmSampleLanguageRet.MWQMSampleLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return newly added MWQMSampleLanguage
                    mwqmSampleLanguageRet.MWQMSampleLanguageID = 0;
                    mwqmSampleLanguageController.Request = new System.Net.Http.HttpRequestMessage();
                    mwqmSampleLanguageController.Request.RequestUri = new System.Uri("http://localhost:5000/api/mwqmSampleLanguage");
                    IActionResult jsonRet3 = mwqmSampleLanguageController.Post(mwqmSampleLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<MWQMSampleLanguage> mwqmSampleLanguageRet3 = jsonRet3 as CreatedNegotiatedContentResult<MWQMSampleLanguage>;
                    Assert.NotNull(mwqmSampleLanguageRet3);
                    MWQMSampleLanguage mwqmSampleLanguage = mwqmSampleLanguageRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = mwqmSampleLanguageController.Delete(mwqmSampleLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<MWQMSampleLanguage> mwqmSampleLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<MWQMSampleLanguage>;
                    Assert.NotNull(mwqmSampleLanguageRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because MWQMSampleLanguageID of 0 does not exist
                    mwqmSampleLanguageRet.MWQMSampleLanguageID = 0;
                    IActionResult jsonRet4 = mwqmSampleLanguageController.Delete(mwqmSampleLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<MWQMSampleLanguage> mwqmSampleLanguageRet4 = jsonRet4 as OkNegotiatedContentResult<MWQMSampleLanguage>;
                    Assert.Null(mwqmSampleLanguageRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
