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
    public partial class MWQMLookupMPNControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MWQMLookupMPNControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [TestMethod]
        public void MWQMLookupMPN_Controller_GetMWQMLookupMPNList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMLookupMPNController mwqmLookupMPNController = new MWQMLookupMPNController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mwqmLookupMPNController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mwqmLookupMPNController.DatabaseType);

                    MWQMLookupMPN mwqmLookupMPNFirst = new MWQMLookupMPN();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        MWQMLookupMPNService mwqmLookupMPNService = new MWQMLookupMPNService(query, db, ContactID);
                        mwqmLookupMPNFirst = (from c in db.MWQMLookupMPNs select c).FirstOrDefault();
                        count = (from c in db.MWQMLookupMPNs select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with MWQMLookupMPN info
                    IHttpActionResult jsonRet = mwqmLookupMPNController.GetMWQMLookupMPNList();
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<List<MWQMLookupMPN>> ret = jsonRet as OkNegotiatedContentResult<List<MWQMLookupMPN>>;
                    Assert.AreEqual(mwqmLookupMPNFirst.MWQMLookupMPNID, ret.Content[0].MWQMLookupMPNID);
                    Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<MWQMLookupMPN> mwqmLookupMPNList = new List<MWQMLookupMPN>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        MWQMLookupMPNService mwqmLookupMPNService = new MWQMLookupMPNService(query, db, ContactID);
                        mwqmLookupMPNList = (from c in db.MWQMLookupMPNs select c).OrderBy(c => c.MWQMLookupMPNID).Skip(0).Take(2).ToList();
                        count = (from c in db.MWQMLookupMPNs select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with MWQMLookupMPN info
                        jsonRet = mwqmLookupMPNController.GetMWQMLookupMPNList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsNotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<MWQMLookupMPN>>;
                        Assert.AreEqual(mwqmLookupMPNList[0].MWQMLookupMPNID, ret.Content[0].MWQMLookupMPNID);
                        Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with MWQMLookupMPN info
                           IHttpActionResult jsonRet2 = mwqmLookupMPNController.GetMWQMLookupMPNList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.IsNotNull(jsonRet2);

                           OkNegotiatedContentResult<List<MWQMLookupMPN>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<MWQMLookupMPN>>;
                           Assert.AreEqual(mwqmLookupMPNList[1].MWQMLookupMPNID, ret2.Content[0].MWQMLookupMPNID);
                           Assert.AreEqual((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [TestMethod]
        public void MWQMLookupMPN_Controller_GetMWQMLookupMPNWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMLookupMPNController mwqmLookupMPNController = new MWQMLookupMPNController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mwqmLookupMPNController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mwqmLookupMPNController.DatabaseType);

                    MWQMLookupMPN mwqmLookupMPNFirst = new MWQMLookupMPN();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        MWQMLookupMPNService mwqmLookupMPNService = new MWQMLookupMPNService(new Query(), db, ContactID);
                        mwqmLookupMPNFirst = (from c in db.MWQMLookupMPNs select c).FirstOrDefault();
                    }

                    // ok with MWQMLookupMPN info
                    IHttpActionResult jsonRet = mwqmLookupMPNController.GetMWQMLookupMPNWithID(mwqmLookupMPNFirst.MWQMLookupMPNID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<MWQMLookupMPN> Ret = jsonRet as OkNegotiatedContentResult<MWQMLookupMPN>;
                    MWQMLookupMPN mwqmLookupMPNRet = Ret.Content;
                    Assert.AreEqual(mwqmLookupMPNFirst.MWQMLookupMPNID, mwqmLookupMPNRet.MWQMLookupMPNID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = mwqmLookupMPNController.GetMWQMLookupMPNWithID(0);
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<MWQMLookupMPN> mwqmLookupMPNRet2 = jsonRet2 as OkNegotiatedContentResult<MWQMLookupMPN>;
                    Assert.IsNull(mwqmLookupMPNRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.IsNotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [TestMethod]
        public void MWQMLookupMPN_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMLookupMPNController mwqmLookupMPNController = new MWQMLookupMPNController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mwqmLookupMPNController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mwqmLookupMPNController.DatabaseType);

                    MWQMLookupMPN mwqmLookupMPNLast = new MWQMLookupMPN();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MWQMLookupMPNService mwqmLookupMPNService = new MWQMLookupMPNService(query, db, ContactID);
                        mwqmLookupMPNLast = (from c in db.MWQMLookupMPNs select c).FirstOrDefault();
                    }

                    // ok with MWQMLookupMPN info
                    IHttpActionResult jsonRet = mwqmLookupMPNController.GetMWQMLookupMPNWithID(mwqmLookupMPNLast.MWQMLookupMPNID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<MWQMLookupMPN> Ret = jsonRet as OkNegotiatedContentResult<MWQMLookupMPN>;
                    MWQMLookupMPN mwqmLookupMPNRet = Ret.Content;
                    Assert.AreEqual(mwqmLookupMPNLast.MWQMLookupMPNID, mwqmLookupMPNRet.MWQMLookupMPNID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because MWQMLookupMPNID exist
                    IHttpActionResult jsonRet2 = mwqmLookupMPNController.Post(mwqmLookupMPNRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<MWQMLookupMPN> mwqmLookupMPNRet2 = jsonRet2 as OkNegotiatedContentResult<MWQMLookupMPN>;
                    Assert.IsNull(mwqmLookupMPNRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest2);

                    // Post to return newly added MWQMLookupMPN
                    mwqmLookupMPNRet.MWQMLookupMPNID = 0;
                    mwqmLookupMPNRet.Tubes01 = 1;
                    mwqmLookupMPNRet.Tubes1 = 1;
                    mwqmLookupMPNRet.Tubes10 = 1;
                    mwqmLookupMPNRet.MPN_100ml = 6;
                    mwqmLookupMPNController.Request = new System.Net.Http.HttpRequestMessage();
                    mwqmLookupMPNController.Request.RequestUri = new System.Uri("http://localhost:5000/api/mwqmLookupMPN");
                    IHttpActionResult jsonRet3 = mwqmLookupMPNController.Post(mwqmLookupMPNRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<MWQMLookupMPN> mwqmLookupMPNRet3 = jsonRet3 as CreatedNegotiatedContentResult<MWQMLookupMPN>;
                    Assert.IsNotNull(mwqmLookupMPNRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = mwqmLookupMPNController.Delete(mwqmLookupMPNRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<MWQMLookupMPN> mwqmLookupMPNRet4 = jsonRet4 as OkNegotiatedContentResult<MWQMLookupMPN>;
                    Assert.IsNotNull(mwqmLookupMPNRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [TestMethod]
        public void MWQMLookupMPN_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMLookupMPNController mwqmLookupMPNController = new MWQMLookupMPNController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mwqmLookupMPNController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mwqmLookupMPNController.DatabaseType);

                    MWQMLookupMPN mwqmLookupMPNLast = new MWQMLookupMPN();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        MWQMLookupMPNService mwqmLookupMPNService = new MWQMLookupMPNService(query, db, ContactID);
                        mwqmLookupMPNLast = (from c in db.MWQMLookupMPNs select c).FirstOrDefault();
                    }

                    // ok with MWQMLookupMPN info
                    IHttpActionResult jsonRet = mwqmLookupMPNController.GetMWQMLookupMPNWithID(mwqmLookupMPNLast.MWQMLookupMPNID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<MWQMLookupMPN> Ret = jsonRet as OkNegotiatedContentResult<MWQMLookupMPN>;
                    MWQMLookupMPN mwqmLookupMPNRet = Ret.Content;
                    Assert.AreEqual(mwqmLookupMPNLast.MWQMLookupMPNID, mwqmLookupMPNRet.MWQMLookupMPNID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = mwqmLookupMPNController.Put(mwqmLookupMPNRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<MWQMLookupMPN> mwqmLookupMPNRet2 = jsonRet2 as OkNegotiatedContentResult<MWQMLookupMPN>;
                    Assert.IsNotNull(mwqmLookupMPNRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because MWQMLookupMPNID of 0 does not exist
                    mwqmLookupMPNRet.MWQMLookupMPNID = 0;
                    IHttpActionResult jsonRet3 = mwqmLookupMPNController.Put(mwqmLookupMPNRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    OkNegotiatedContentResult<MWQMLookupMPN> mwqmLookupMPNRet3 = jsonRet3 as OkNegotiatedContentResult<MWQMLookupMPN>;
                    Assert.IsNull(mwqmLookupMPNRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [TestMethod]
        public void MWQMLookupMPN_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMLookupMPNController mwqmLookupMPNController = new MWQMLookupMPNController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mwqmLookupMPNController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mwqmLookupMPNController.DatabaseType);

                    MWQMLookupMPN mwqmLookupMPNLast = new MWQMLookupMPN();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MWQMLookupMPNService mwqmLookupMPNService = new MWQMLookupMPNService(query, db, ContactID);
                        mwqmLookupMPNLast = (from c in db.MWQMLookupMPNs select c).FirstOrDefault();
                    }

                    // ok with MWQMLookupMPN info
                    IHttpActionResult jsonRet = mwqmLookupMPNController.GetMWQMLookupMPNWithID(mwqmLookupMPNLast.MWQMLookupMPNID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<MWQMLookupMPN> Ret = jsonRet as OkNegotiatedContentResult<MWQMLookupMPN>;
                    MWQMLookupMPN mwqmLookupMPNRet = Ret.Content;
                    Assert.AreEqual(mwqmLookupMPNLast.MWQMLookupMPNID, mwqmLookupMPNRet.MWQMLookupMPNID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added MWQMLookupMPN
                    mwqmLookupMPNRet.MWQMLookupMPNID = 0;
                    mwqmLookupMPNRet.Tubes01 = 1;
                    mwqmLookupMPNRet.Tubes1 = 1;
                    mwqmLookupMPNRet.Tubes10 = 1;
                    mwqmLookupMPNRet.MPN_100ml = 6;
                    mwqmLookupMPNController.Request = new System.Net.Http.HttpRequestMessage();
                    mwqmLookupMPNController.Request.RequestUri = new System.Uri("http://localhost:5000/api/mwqmLookupMPN");
                    IHttpActionResult jsonRet3 = mwqmLookupMPNController.Post(mwqmLookupMPNRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<MWQMLookupMPN> mwqmLookupMPNRet3 = jsonRet3 as CreatedNegotiatedContentResult<MWQMLookupMPN>;
                    Assert.IsNotNull(mwqmLookupMPNRet3);
                    MWQMLookupMPN mwqmLookupMPN = mwqmLookupMPNRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = mwqmLookupMPNController.Delete(mwqmLookupMPNRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<MWQMLookupMPN> mwqmLookupMPNRet2 = jsonRet2 as OkNegotiatedContentResult<MWQMLookupMPN>;
                    Assert.IsNotNull(mwqmLookupMPNRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because MWQMLookupMPNID of 0 does not exist
                    mwqmLookupMPNRet.MWQMLookupMPNID = 0;
                    IHttpActionResult jsonRet4 = mwqmLookupMPNController.Delete(mwqmLookupMPNRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<MWQMLookupMPN> mwqmLookupMPNRet4 = jsonRet4 as OkNegotiatedContentResult<MWQMLookupMPN>;
                    Assert.IsNull(mwqmLookupMPNRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
