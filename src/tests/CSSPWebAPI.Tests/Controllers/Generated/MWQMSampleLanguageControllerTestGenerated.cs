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
        [TestMethod]
        public void MWQMSampleLanguage_Controller_GetMWQMSampleLanguageList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMSampleLanguageController mwqmSampleLanguageController = new MWQMSampleLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mwqmSampleLanguageController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mwqmSampleLanguageController.DatabaseType);

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
                    IHttpActionResult jsonRet = mwqmSampleLanguageController.GetMWQMSampleLanguageList();
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<List<MWQMSampleLanguage>> ret = jsonRet as OkNegotiatedContentResult<List<MWQMSampleLanguage>>;
                    Assert.AreEqual(mwqmSampleLanguageFirst.MWQMSampleLanguageID, ret.Content[0].MWQMSampleLanguageID);
                    Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

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
                        Assert.IsNotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<MWQMSampleLanguage>>;
                        Assert.AreEqual(mwqmSampleLanguageList[0].MWQMSampleLanguageID, ret.Content[0].MWQMSampleLanguageID);
                        Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with MWQMSampleLanguage info
                           IHttpActionResult jsonRet2 = mwqmSampleLanguageController.GetMWQMSampleLanguageList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.IsNotNull(jsonRet2);

                           OkNegotiatedContentResult<List<MWQMSampleLanguage>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<MWQMSampleLanguage>>;
                           Assert.AreEqual(mwqmSampleLanguageList[1].MWQMSampleLanguageID, ret2.Content[0].MWQMSampleLanguageID);
                           Assert.AreEqual((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [TestMethod]
        public void MWQMSampleLanguage_Controller_GetMWQMSampleLanguageWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMSampleLanguageController mwqmSampleLanguageController = new MWQMSampleLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mwqmSampleLanguageController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mwqmSampleLanguageController.DatabaseType);

                    MWQMSampleLanguage mwqmSampleLanguageFirst = new MWQMSampleLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        MWQMSampleLanguageService mwqmSampleLanguageService = new MWQMSampleLanguageService(new Query(), db, ContactID);
                        mwqmSampleLanguageFirst = (from c in db.MWQMSampleLanguages select c).FirstOrDefault();
                    }

                    // ok with MWQMSampleLanguage info
                    IHttpActionResult jsonRet = mwqmSampleLanguageController.GetMWQMSampleLanguageWithID(mwqmSampleLanguageFirst.MWQMSampleLanguageID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<MWQMSampleLanguage> Ret = jsonRet as OkNegotiatedContentResult<MWQMSampleLanguage>;
                    MWQMSampleLanguage mwqmSampleLanguageRet = Ret.Content;
                    Assert.AreEqual(mwqmSampleLanguageFirst.MWQMSampleLanguageID, mwqmSampleLanguageRet.MWQMSampleLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = mwqmSampleLanguageController.GetMWQMSampleLanguageWithID(0);
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<MWQMSampleLanguage> mwqmSampleLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<MWQMSampleLanguage>;
                    Assert.IsNull(mwqmSampleLanguageRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.IsNotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [TestMethod]
        public void MWQMSampleLanguage_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMSampleLanguageController mwqmSampleLanguageController = new MWQMSampleLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mwqmSampleLanguageController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mwqmSampleLanguageController.DatabaseType);

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
                    IHttpActionResult jsonRet = mwqmSampleLanguageController.GetMWQMSampleLanguageWithID(mwqmSampleLanguageLast.MWQMSampleLanguageID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<MWQMSampleLanguage> Ret = jsonRet as OkNegotiatedContentResult<MWQMSampleLanguage>;
                    MWQMSampleLanguage mwqmSampleLanguageRet = Ret.Content;
                    Assert.AreEqual(mwqmSampleLanguageLast.MWQMSampleLanguageID, mwqmSampleLanguageRet.MWQMSampleLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because MWQMSampleLanguageID exist
                    IHttpActionResult jsonRet2 = mwqmSampleLanguageController.Post(mwqmSampleLanguageRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<MWQMSampleLanguage> mwqmSampleLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<MWQMSampleLanguage>;
                    Assert.IsNull(mwqmSampleLanguageRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest2);

                    // Post to return newly added MWQMSampleLanguage
                    mwqmSampleLanguageRet.MWQMSampleLanguageID = 0;
                    mwqmSampleLanguageController.Request = new System.Net.Http.HttpRequestMessage();
                    mwqmSampleLanguageController.Request.RequestUri = new System.Uri("http://localhost:5000/api/mwqmSampleLanguage");
                    IHttpActionResult jsonRet3 = mwqmSampleLanguageController.Post(mwqmSampleLanguageRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<MWQMSampleLanguage> mwqmSampleLanguageRet3 = jsonRet3 as CreatedNegotiatedContentResult<MWQMSampleLanguage>;
                    Assert.IsNotNull(mwqmSampleLanguageRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = mwqmSampleLanguageController.Delete(mwqmSampleLanguageRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<MWQMSampleLanguage> mwqmSampleLanguageRet4 = jsonRet4 as OkNegotiatedContentResult<MWQMSampleLanguage>;
                    Assert.IsNotNull(mwqmSampleLanguageRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [TestMethod]
        public void MWQMSampleLanguage_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMSampleLanguageController mwqmSampleLanguageController = new MWQMSampleLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mwqmSampleLanguageController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mwqmSampleLanguageController.DatabaseType);

                    MWQMSampleLanguage mwqmSampleLanguageLast = new MWQMSampleLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        MWQMSampleLanguageService mwqmSampleLanguageService = new MWQMSampleLanguageService(query, db, ContactID);
                        mwqmSampleLanguageLast = (from c in db.MWQMSampleLanguages select c).FirstOrDefault();
                    }

                    // ok with MWQMSampleLanguage info
                    IHttpActionResult jsonRet = mwqmSampleLanguageController.GetMWQMSampleLanguageWithID(mwqmSampleLanguageLast.MWQMSampleLanguageID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<MWQMSampleLanguage> Ret = jsonRet as OkNegotiatedContentResult<MWQMSampleLanguage>;
                    MWQMSampleLanguage mwqmSampleLanguageRet = Ret.Content;
                    Assert.AreEqual(mwqmSampleLanguageLast.MWQMSampleLanguageID, mwqmSampleLanguageRet.MWQMSampleLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = mwqmSampleLanguageController.Put(mwqmSampleLanguageRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<MWQMSampleLanguage> mwqmSampleLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<MWQMSampleLanguage>;
                    Assert.IsNotNull(mwqmSampleLanguageRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because MWQMSampleLanguageID of 0 does not exist
                    mwqmSampleLanguageRet.MWQMSampleLanguageID = 0;
                    IHttpActionResult jsonRet3 = mwqmSampleLanguageController.Put(mwqmSampleLanguageRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    OkNegotiatedContentResult<MWQMSampleLanguage> mwqmSampleLanguageRet3 = jsonRet3 as OkNegotiatedContentResult<MWQMSampleLanguage>;
                    Assert.IsNull(mwqmSampleLanguageRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [TestMethod]
        public void MWQMSampleLanguage_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMSampleLanguageController mwqmSampleLanguageController = new MWQMSampleLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mwqmSampleLanguageController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mwqmSampleLanguageController.DatabaseType);

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
                    IHttpActionResult jsonRet = mwqmSampleLanguageController.GetMWQMSampleLanguageWithID(mwqmSampleLanguageLast.MWQMSampleLanguageID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<MWQMSampleLanguage> Ret = jsonRet as OkNegotiatedContentResult<MWQMSampleLanguage>;
                    MWQMSampleLanguage mwqmSampleLanguageRet = Ret.Content;
                    Assert.AreEqual(mwqmSampleLanguageLast.MWQMSampleLanguageID, mwqmSampleLanguageRet.MWQMSampleLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added MWQMSampleLanguage
                    mwqmSampleLanguageRet.MWQMSampleLanguageID = 0;
                    mwqmSampleLanguageController.Request = new System.Net.Http.HttpRequestMessage();
                    mwqmSampleLanguageController.Request.RequestUri = new System.Uri("http://localhost:5000/api/mwqmSampleLanguage");
                    IHttpActionResult jsonRet3 = mwqmSampleLanguageController.Post(mwqmSampleLanguageRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<MWQMSampleLanguage> mwqmSampleLanguageRet3 = jsonRet3 as CreatedNegotiatedContentResult<MWQMSampleLanguage>;
                    Assert.IsNotNull(mwqmSampleLanguageRet3);
                    MWQMSampleLanguage mwqmSampleLanguage = mwqmSampleLanguageRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = mwqmSampleLanguageController.Delete(mwqmSampleLanguageRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<MWQMSampleLanguage> mwqmSampleLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<MWQMSampleLanguage>;
                    Assert.IsNotNull(mwqmSampleLanguageRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because MWQMSampleLanguageID of 0 does not exist
                    mwqmSampleLanguageRet.MWQMSampleLanguageID = 0;
                    IHttpActionResult jsonRet4 = mwqmSampleLanguageController.Delete(mwqmSampleLanguageRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<MWQMSampleLanguage> mwqmSampleLanguageRet4 = jsonRet4 as OkNegotiatedContentResult<MWQMSampleLanguage>;
                    Assert.IsNull(mwqmSampleLanguageRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
