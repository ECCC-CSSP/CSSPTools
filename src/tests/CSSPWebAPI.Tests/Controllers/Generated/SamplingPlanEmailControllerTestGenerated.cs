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
        [Fact]
        public void SamplingPlanEmail_Controller_GetSamplingPlanEmailList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    SamplingPlanEmailController samplingPlanEmailController = new SamplingPlanEmailController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(samplingPlanEmailController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, samplingPlanEmailController.DatabaseType);

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
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<List<SamplingPlanEmail>> ret = jsonRet as OkNegotiatedContentResult<List<SamplingPlanEmail>>;
                    Assert.Equal(samplingPlanEmailFirst.SamplingPlanEmailID, ret.Content[0].SamplingPlanEmailID);
                    Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

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
                        Assert.NotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<SamplingPlanEmail>>;
                        Assert.Equal(samplingPlanEmailList[0].SamplingPlanEmailID, ret.Content[0].SamplingPlanEmailID);
                        Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with SamplingPlanEmail info
                           IHttpActionResult jsonRet2 = samplingPlanEmailController.GetSamplingPlanEmailList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkNegotiatedContentResult<List<SamplingPlanEmail>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<SamplingPlanEmail>>;
                           Assert.Equal(samplingPlanEmailList[1].SamplingPlanEmailID, ret2.Content[0].SamplingPlanEmailID);
                           Assert.Equal((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void SamplingPlanEmail_Controller_GetSamplingPlanEmailWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    SamplingPlanEmailController samplingPlanEmailController = new SamplingPlanEmailController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(samplingPlanEmailController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, samplingPlanEmailController.DatabaseType);

                    SamplingPlanEmail samplingPlanEmailFirst = new SamplingPlanEmail();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        SamplingPlanEmailService samplingPlanEmailService = new SamplingPlanEmailService(new Query(), db, ContactID);
                        samplingPlanEmailFirst = (from c in db.SamplingPlanEmails select c).FirstOrDefault();
                    }

                    // ok with SamplingPlanEmail info
                    IHttpActionResult jsonRet = samplingPlanEmailController.GetSamplingPlanEmailWithID(samplingPlanEmailFirst.SamplingPlanEmailID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<SamplingPlanEmail> Ret = jsonRet as OkNegotiatedContentResult<SamplingPlanEmail>;
                    SamplingPlanEmail samplingPlanEmailRet = Ret.Content;
                    Assert.Equal(samplingPlanEmailFirst.SamplingPlanEmailID, samplingPlanEmailRet.SamplingPlanEmailID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = samplingPlanEmailController.GetSamplingPlanEmailWithID(0);
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<SamplingPlanEmail> samplingPlanEmailRet2 = jsonRet2 as OkNegotiatedContentResult<SamplingPlanEmail>;
                    Assert.IsNull(samplingPlanEmailRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.NotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void SamplingPlanEmail_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    SamplingPlanEmailController samplingPlanEmailController = new SamplingPlanEmailController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(samplingPlanEmailController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, samplingPlanEmailController.DatabaseType);

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
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<SamplingPlanEmail> Ret = jsonRet as OkNegotiatedContentResult<SamplingPlanEmail>;
                    SamplingPlanEmail samplingPlanEmailRet = Ret.Content;
                    Assert.Equal(samplingPlanEmailLast.SamplingPlanEmailID, samplingPlanEmailRet.SamplingPlanEmailID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because SamplingPlanEmailID exist
                    IHttpActionResult jsonRet2 = samplingPlanEmailController.Post(samplingPlanEmailRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<SamplingPlanEmail> samplingPlanEmailRet2 = jsonRet2 as OkNegotiatedContentResult<SamplingPlanEmail>;
                    Assert.IsNull(samplingPlanEmailRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added SamplingPlanEmail
                    samplingPlanEmailRet.SamplingPlanEmailID = 0;
                    samplingPlanEmailController.Request = new System.Net.Http.HttpRequestMessage();
                    samplingPlanEmailController.Request.RequestUri = new System.Uri("http://localhost:5000/api/samplingPlanEmail");
                    IHttpActionResult jsonRet3 = samplingPlanEmailController.Post(samplingPlanEmailRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<SamplingPlanEmail> samplingPlanEmailRet3 = jsonRet3 as CreatedNegotiatedContentResult<SamplingPlanEmail>;
                    Assert.NotNull(samplingPlanEmailRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = samplingPlanEmailController.Delete(samplingPlanEmailRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<SamplingPlanEmail> samplingPlanEmailRet4 = jsonRet4 as OkNegotiatedContentResult<SamplingPlanEmail>;
                    Assert.NotNull(samplingPlanEmailRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [Fact]
        public void SamplingPlanEmail_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    SamplingPlanEmailController samplingPlanEmailController = new SamplingPlanEmailController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(samplingPlanEmailController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, samplingPlanEmailController.DatabaseType);

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
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<SamplingPlanEmail> Ret = jsonRet as OkNegotiatedContentResult<SamplingPlanEmail>;
                    SamplingPlanEmail samplingPlanEmailRet = Ret.Content;
                    Assert.Equal(samplingPlanEmailLast.SamplingPlanEmailID, samplingPlanEmailRet.SamplingPlanEmailID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = samplingPlanEmailController.Put(samplingPlanEmailRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<SamplingPlanEmail> samplingPlanEmailRet2 = jsonRet2 as OkNegotiatedContentResult<SamplingPlanEmail>;
                    Assert.NotNull(samplingPlanEmailRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because SamplingPlanEmailID of 0 does not exist
                    samplingPlanEmailRet.SamplingPlanEmailID = 0;
                    IHttpActionResult jsonRet3 = samplingPlanEmailController.Put(samplingPlanEmailRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    OkNegotiatedContentResult<SamplingPlanEmail> samplingPlanEmailRet3 = jsonRet3 as OkNegotiatedContentResult<SamplingPlanEmail>;
                    Assert.IsNull(samplingPlanEmailRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void SamplingPlanEmail_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    SamplingPlanEmailController samplingPlanEmailController = new SamplingPlanEmailController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(samplingPlanEmailController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, samplingPlanEmailController.DatabaseType);

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
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<SamplingPlanEmail> Ret = jsonRet as OkNegotiatedContentResult<SamplingPlanEmail>;
                    SamplingPlanEmail samplingPlanEmailRet = Ret.Content;
                    Assert.Equal(samplingPlanEmailLast.SamplingPlanEmailID, samplingPlanEmailRet.SamplingPlanEmailID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added SamplingPlanEmail
                    samplingPlanEmailRet.SamplingPlanEmailID = 0;
                    samplingPlanEmailController.Request = new System.Net.Http.HttpRequestMessage();
                    samplingPlanEmailController.Request.RequestUri = new System.Uri("http://localhost:5000/api/samplingPlanEmail");
                    IHttpActionResult jsonRet3 = samplingPlanEmailController.Post(samplingPlanEmailRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<SamplingPlanEmail> samplingPlanEmailRet3 = jsonRet3 as CreatedNegotiatedContentResult<SamplingPlanEmail>;
                    Assert.NotNull(samplingPlanEmailRet3);
                    SamplingPlanEmail samplingPlanEmail = samplingPlanEmailRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = samplingPlanEmailController.Delete(samplingPlanEmailRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<SamplingPlanEmail> samplingPlanEmailRet2 = jsonRet2 as OkNegotiatedContentResult<SamplingPlanEmail>;
                    Assert.NotNull(samplingPlanEmailRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because SamplingPlanEmailID of 0 does not exist
                    samplingPlanEmailRet.SamplingPlanEmailID = 0;
                    IHttpActionResult jsonRet4 = samplingPlanEmailController.Delete(samplingPlanEmailRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<SamplingPlanEmail> samplingPlanEmailRet4 = jsonRet4 as OkNegotiatedContentResult<SamplingPlanEmail>;
                    Assert.IsNull(samplingPlanEmailRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
