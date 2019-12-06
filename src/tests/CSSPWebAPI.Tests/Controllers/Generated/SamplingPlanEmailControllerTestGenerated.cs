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
    public partial class SamplingPlanEmailControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public SamplingPlanEmailControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [TestMethod]
        public void SamplingPlanEmail_Controller_GetSamplingPlanEmailList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    SamplingPlanEmailController samplingPlanEmailController = new SamplingPlanEmailController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(samplingPlanEmailController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, samplingPlanEmailController.DatabaseType);

                    SamplingPlanEmail samplingPlanEmailFirst = new SamplingPlanEmail();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        SamplingPlanEmailService samplingPlanEmailService = new SamplingPlanEmailService(query, db, ContactID);
                        samplingPlanEmailFirst = (from c in db.SamplingPlanEmails select c).FirstOrDefault();
                        count = (from c in db.SamplingPlanEmails select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with SamplingPlanEmail info
                    IHttpActionResult jsonRet = samplingPlanEmailController.GetSamplingPlanEmailList();
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<List<SamplingPlanEmail>> ret = jsonRet as OkNegotiatedContentResult<List<SamplingPlanEmail>>;
                    Assert.AreEqual(samplingPlanEmailFirst.SamplingPlanEmailID, ret.Content[0].SamplingPlanEmailID);
                    Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<SamplingPlanEmail> samplingPlanEmailList = new List<SamplingPlanEmail>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        SamplingPlanEmailService samplingPlanEmailService = new SamplingPlanEmailService(query, db, ContactID);
                        samplingPlanEmailList = (from c in db.SamplingPlanEmails select c).OrderBy(c => c.SamplingPlanEmailID).Skip(0).Take(2).ToList();
                        count = (from c in db.SamplingPlanEmails select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with SamplingPlanEmail info
                        jsonRet = samplingPlanEmailController.GetSamplingPlanEmailList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsNotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<SamplingPlanEmail>>;
                        Assert.AreEqual(samplingPlanEmailList[0].SamplingPlanEmailID, ret.Content[0].SamplingPlanEmailID);
                        Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with SamplingPlanEmail info
                           IHttpActionResult jsonRet2 = samplingPlanEmailController.GetSamplingPlanEmailList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.IsNotNull(jsonRet2);

                           OkNegotiatedContentResult<List<SamplingPlanEmail>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<SamplingPlanEmail>>;
                           Assert.AreEqual(samplingPlanEmailList[1].SamplingPlanEmailID, ret2.Content[0].SamplingPlanEmailID);
                           Assert.AreEqual((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [TestMethod]
        public void SamplingPlanEmail_Controller_GetSamplingPlanEmailWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    SamplingPlanEmailController samplingPlanEmailController = new SamplingPlanEmailController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(samplingPlanEmailController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, samplingPlanEmailController.DatabaseType);

                    SamplingPlanEmail samplingPlanEmailFirst = new SamplingPlanEmail();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        SamplingPlanEmailService samplingPlanEmailService = new SamplingPlanEmailService(new Query(), db, ContactID);
                        samplingPlanEmailFirst = (from c in db.SamplingPlanEmails select c).FirstOrDefault();
                    }

                    // ok with SamplingPlanEmail info
                    IHttpActionResult jsonRet = samplingPlanEmailController.GetSamplingPlanEmailWithID(samplingPlanEmailFirst.SamplingPlanEmailID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<SamplingPlanEmail> Ret = jsonRet as OkNegotiatedContentResult<SamplingPlanEmail>;
                    SamplingPlanEmail samplingPlanEmailRet = Ret.Content;
                    Assert.AreEqual(samplingPlanEmailFirst.SamplingPlanEmailID, samplingPlanEmailRet.SamplingPlanEmailID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = samplingPlanEmailController.GetSamplingPlanEmailWithID(0);
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<SamplingPlanEmail> samplingPlanEmailRet2 = jsonRet2 as OkNegotiatedContentResult<SamplingPlanEmail>;
                    Assert.IsNull(samplingPlanEmailRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.IsNotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [TestMethod]
        public void SamplingPlanEmail_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    SamplingPlanEmailController samplingPlanEmailController = new SamplingPlanEmailController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(samplingPlanEmailController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, samplingPlanEmailController.DatabaseType);

                    SamplingPlanEmail samplingPlanEmailLast = new SamplingPlanEmail();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        SamplingPlanEmailService samplingPlanEmailService = new SamplingPlanEmailService(query, db, ContactID);
                        samplingPlanEmailLast = (from c in db.SamplingPlanEmails select c).FirstOrDefault();
                    }

                    // ok with SamplingPlanEmail info
                    IHttpActionResult jsonRet = samplingPlanEmailController.GetSamplingPlanEmailWithID(samplingPlanEmailLast.SamplingPlanEmailID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<SamplingPlanEmail> Ret = jsonRet as OkNegotiatedContentResult<SamplingPlanEmail>;
                    SamplingPlanEmail samplingPlanEmailRet = Ret.Content;
                    Assert.AreEqual(samplingPlanEmailLast.SamplingPlanEmailID, samplingPlanEmailRet.SamplingPlanEmailID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because SamplingPlanEmailID exist
                    IHttpActionResult jsonRet2 = samplingPlanEmailController.Post(samplingPlanEmailRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<SamplingPlanEmail> samplingPlanEmailRet2 = jsonRet2 as OkNegotiatedContentResult<SamplingPlanEmail>;
                    Assert.IsNull(samplingPlanEmailRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest2);

                    // Post to return newly added SamplingPlanEmail
                    samplingPlanEmailRet.SamplingPlanEmailID = 0;
                    samplingPlanEmailController.Request = new System.Net.Http.HttpRequestMessage();
                    samplingPlanEmailController.Request.RequestUri = new System.Uri("http://localhost:5000/api/samplingPlanEmail");
                    IHttpActionResult jsonRet3 = samplingPlanEmailController.Post(samplingPlanEmailRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<SamplingPlanEmail> samplingPlanEmailRet3 = jsonRet3 as CreatedNegotiatedContentResult<SamplingPlanEmail>;
                    Assert.IsNotNull(samplingPlanEmailRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = samplingPlanEmailController.Delete(samplingPlanEmailRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<SamplingPlanEmail> samplingPlanEmailRet4 = jsonRet4 as OkNegotiatedContentResult<SamplingPlanEmail>;
                    Assert.IsNotNull(samplingPlanEmailRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [TestMethod]
        public void SamplingPlanEmail_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    SamplingPlanEmailController samplingPlanEmailController = new SamplingPlanEmailController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(samplingPlanEmailController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, samplingPlanEmailController.DatabaseType);

                    SamplingPlanEmail samplingPlanEmailLast = new SamplingPlanEmail();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        SamplingPlanEmailService samplingPlanEmailService = new SamplingPlanEmailService(query, db, ContactID);
                        samplingPlanEmailLast = (from c in db.SamplingPlanEmails select c).FirstOrDefault();
                    }

                    // ok with SamplingPlanEmail info
                    IHttpActionResult jsonRet = samplingPlanEmailController.GetSamplingPlanEmailWithID(samplingPlanEmailLast.SamplingPlanEmailID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<SamplingPlanEmail> Ret = jsonRet as OkNegotiatedContentResult<SamplingPlanEmail>;
                    SamplingPlanEmail samplingPlanEmailRet = Ret.Content;
                    Assert.AreEqual(samplingPlanEmailLast.SamplingPlanEmailID, samplingPlanEmailRet.SamplingPlanEmailID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = samplingPlanEmailController.Put(samplingPlanEmailRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<SamplingPlanEmail> samplingPlanEmailRet2 = jsonRet2 as OkNegotiatedContentResult<SamplingPlanEmail>;
                    Assert.IsNotNull(samplingPlanEmailRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because SamplingPlanEmailID of 0 does not exist
                    samplingPlanEmailRet.SamplingPlanEmailID = 0;
                    IHttpActionResult jsonRet3 = samplingPlanEmailController.Put(samplingPlanEmailRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    OkNegotiatedContentResult<SamplingPlanEmail> samplingPlanEmailRet3 = jsonRet3 as OkNegotiatedContentResult<SamplingPlanEmail>;
                    Assert.IsNull(samplingPlanEmailRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [TestMethod]
        public void SamplingPlanEmail_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    SamplingPlanEmailController samplingPlanEmailController = new SamplingPlanEmailController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(samplingPlanEmailController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, samplingPlanEmailController.DatabaseType);

                    SamplingPlanEmail samplingPlanEmailLast = new SamplingPlanEmail();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        SamplingPlanEmailService samplingPlanEmailService = new SamplingPlanEmailService(query, db, ContactID);
                        samplingPlanEmailLast = (from c in db.SamplingPlanEmails select c).FirstOrDefault();
                    }

                    // ok with SamplingPlanEmail info
                    IHttpActionResult jsonRet = samplingPlanEmailController.GetSamplingPlanEmailWithID(samplingPlanEmailLast.SamplingPlanEmailID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<SamplingPlanEmail> Ret = jsonRet as OkNegotiatedContentResult<SamplingPlanEmail>;
                    SamplingPlanEmail samplingPlanEmailRet = Ret.Content;
                    Assert.AreEqual(samplingPlanEmailLast.SamplingPlanEmailID, samplingPlanEmailRet.SamplingPlanEmailID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added SamplingPlanEmail
                    samplingPlanEmailRet.SamplingPlanEmailID = 0;
                    samplingPlanEmailController.Request = new System.Net.Http.HttpRequestMessage();
                    samplingPlanEmailController.Request.RequestUri = new System.Uri("http://localhost:5000/api/samplingPlanEmail");
                    IHttpActionResult jsonRet3 = samplingPlanEmailController.Post(samplingPlanEmailRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<SamplingPlanEmail> samplingPlanEmailRet3 = jsonRet3 as CreatedNegotiatedContentResult<SamplingPlanEmail>;
                    Assert.IsNotNull(samplingPlanEmailRet3);
                    SamplingPlanEmail samplingPlanEmail = samplingPlanEmailRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = samplingPlanEmailController.Delete(samplingPlanEmailRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<SamplingPlanEmail> samplingPlanEmailRet2 = jsonRet2 as OkNegotiatedContentResult<SamplingPlanEmail>;
                    Assert.IsNotNull(samplingPlanEmailRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because SamplingPlanEmailID of 0 does not exist
                    samplingPlanEmailRet.SamplingPlanEmailID = 0;
                    IHttpActionResult jsonRet4 = samplingPlanEmailController.Delete(samplingPlanEmailRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<SamplingPlanEmail> samplingPlanEmailRet4 = jsonRet4 as OkNegotiatedContentResult<SamplingPlanEmail>;
                    Assert.IsNull(samplingPlanEmailRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
