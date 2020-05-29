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
    public partial class TelControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TelControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [TestMethod]
        public void Tel_Controller_GetTelList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TelController telController = new TelController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(telController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, telController.DatabaseType);

                    Tel telFirst = new Tel();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        TelService telService = new TelService(query, db, ContactID);
                        telFirst = (from c in db.Tels select c).FirstOrDefault();
                        count = (from c in db.Tels select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with Tel info
                    IHttpActionResult jsonRet = telController.GetTelList();
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<List<Tel>> ret = jsonRet as OkNegotiatedContentResult<List<Tel>>;
                    Assert.AreEqual(telFirst.TelID, ret.Content[0].TelID);
                    Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<Tel> telList = new List<Tel>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        TelService telService = new TelService(query, db, ContactID);
                        telList = (from c in db.Tels select c).OrderBy(c => c.TelID).Skip(0).Take(2).ToList();
                        count = (from c in db.Tels select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with Tel info
                        jsonRet = telController.GetTelList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsNotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<Tel>>;
                        Assert.AreEqual(telList[0].TelID, ret.Content[0].TelID);
                        Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with Tel info
                           IHttpActionResult jsonRet2 = telController.GetTelList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.IsNotNull(jsonRet2);

                           OkNegotiatedContentResult<List<Tel>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<Tel>>;
                           Assert.AreEqual(telList[1].TelID, ret2.Content[0].TelID);
                           Assert.AreEqual((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [TestMethod]
        public void Tel_Controller_GetTelWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TelController telController = new TelController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(telController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, telController.DatabaseType);

                    Tel telFirst = new Tel();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        TelService telService = new TelService(new Query(), db, ContactID);
                        telFirst = (from c in db.Tels select c).FirstOrDefault();
                    }

                    // ok with Tel info
                    IHttpActionResult jsonRet = telController.GetTelWithID(telFirst.TelID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<Tel> Ret = jsonRet as OkNegotiatedContentResult<Tel>;
                    Tel telRet = Ret.Content;
                    Assert.AreEqual(telFirst.TelID, telRet.TelID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = telController.GetTelWithID(0);
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<Tel> telRet2 = jsonRet2 as OkNegotiatedContentResult<Tel>;
                    Assert.IsNull(telRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.IsNotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [TestMethod]
        public void Tel_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TelController telController = new TelController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(telController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, telController.DatabaseType);

                    Tel telLast = new Tel();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        TelService telService = new TelService(query, db, ContactID);
                        telLast = (from c in db.Tels select c).FirstOrDefault();
                    }

                    // ok with Tel info
                    IHttpActionResult jsonRet = telController.GetTelWithID(telLast.TelID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<Tel> Ret = jsonRet as OkNegotiatedContentResult<Tel>;
                    Tel telRet = Ret.Content;
                    Assert.AreEqual(telLast.TelID, telRet.TelID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because TelID exist
                    IHttpActionResult jsonRet2 = telController.Post(telRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<Tel> telRet2 = jsonRet2 as OkNegotiatedContentResult<Tel>;
                    Assert.IsNull(telRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest2);

                    // Post to return newly added Tel
                    telRet.TelID = 0;
                    telController.Request = new System.Net.Http.HttpRequestMessage();
                    telController.Request.RequestUri = new System.Uri("http://localhost:5000/api/tel");
                    IHttpActionResult jsonRet3 = telController.Post(telRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<Tel> telRet3 = jsonRet3 as CreatedNegotiatedContentResult<Tel>;
                    Assert.IsNotNull(telRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = telController.Delete(telRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<Tel> telRet4 = jsonRet4 as OkNegotiatedContentResult<Tel>;
                    Assert.IsNotNull(telRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [TestMethod]
        public void Tel_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TelController telController = new TelController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(telController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, telController.DatabaseType);

                    Tel telLast = new Tel();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        TelService telService = new TelService(query, db, ContactID);
                        telLast = (from c in db.Tels select c).FirstOrDefault();
                    }

                    // ok with Tel info
                    IHttpActionResult jsonRet = telController.GetTelWithID(telLast.TelID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<Tel> Ret = jsonRet as OkNegotiatedContentResult<Tel>;
                    Tel telRet = Ret.Content;
                    Assert.AreEqual(telLast.TelID, telRet.TelID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = telController.Put(telRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<Tel> telRet2 = jsonRet2 as OkNegotiatedContentResult<Tel>;
                    Assert.IsNotNull(telRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because TelID of 0 does not exist
                    telRet.TelID = 0;
                    IHttpActionResult jsonRet3 = telController.Put(telRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    OkNegotiatedContentResult<Tel> telRet3 = jsonRet3 as OkNegotiatedContentResult<Tel>;
                    Assert.IsNull(telRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [TestMethod]
        public void Tel_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TelController telController = new TelController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(telController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, telController.DatabaseType);

                    Tel telLast = new Tel();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        TelService telService = new TelService(query, db, ContactID);
                        telLast = (from c in db.Tels select c).FirstOrDefault();
                    }

                    // ok with Tel info
                    IHttpActionResult jsonRet = telController.GetTelWithID(telLast.TelID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<Tel> Ret = jsonRet as OkNegotiatedContentResult<Tel>;
                    Tel telRet = Ret.Content;
                    Assert.AreEqual(telLast.TelID, telRet.TelID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added Tel
                    telRet.TelID = 0;
                    telController.Request = new System.Net.Http.HttpRequestMessage();
                    telController.Request.RequestUri = new System.Uri("http://localhost:5000/api/tel");
                    IHttpActionResult jsonRet3 = telController.Post(telRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<Tel> telRet3 = jsonRet3 as CreatedNegotiatedContentResult<Tel>;
                    Assert.IsNotNull(telRet3);
                    Tel tel = telRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = telController.Delete(telRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<Tel> telRet2 = jsonRet2 as OkNegotiatedContentResult<Tel>;
                    Assert.IsNotNull(telRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because TelID of 0 does not exist
                    telRet.TelID = 0;
                    IHttpActionResult jsonRet4 = telController.Delete(telRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<Tel> telRet4 = jsonRet4 as OkNegotiatedContentResult<Tel>;
                    Assert.IsNull(telRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
