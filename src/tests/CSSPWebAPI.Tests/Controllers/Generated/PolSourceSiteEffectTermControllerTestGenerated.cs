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
    public partial class PolSourceSiteEffectTermControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public PolSourceSiteEffectTermControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void PolSourceSiteEffectTerm_Controller_GetPolSourceSiteEffectTermList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    PolSourceSiteEffectTermController polSourceSiteEffectTermController = new PolSourceSiteEffectTermController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(polSourceSiteEffectTermController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, polSourceSiteEffectTermController.DatabaseType);

                    PolSourceSiteEffectTerm polSourceSiteEffectTermFirst = new PolSourceSiteEffectTerm();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        PolSourceSiteEffectTermService polSourceSiteEffectTermService = new PolSourceSiteEffectTermService(query, db, ContactID);
                        polSourceSiteEffectTermFirst = (from c in db.PolSourceSiteEffectTerms select c).FirstOrDefault();
                        count = (from c in db.PolSourceSiteEffectTerms select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with PolSourceSiteEffectTerm info
                    IHttpActionResult jsonRet = polSourceSiteEffectTermController.GetPolSourceSiteEffectTermList();
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<List<PolSourceSiteEffectTerm>> ret = jsonRet as OkNegotiatedContentResult<List<PolSourceSiteEffectTerm>>;
                    Assert.Equal(polSourceSiteEffectTermFirst.PolSourceSiteEffectTermID, ret.Content[0].PolSourceSiteEffectTermID);
                    Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<PolSourceSiteEffectTerm> polSourceSiteEffectTermList = new List<PolSourceSiteEffectTerm>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        PolSourceSiteEffectTermService polSourceSiteEffectTermService = new PolSourceSiteEffectTermService(query, db, ContactID);
                        polSourceSiteEffectTermList = (from c in db.PolSourceSiteEffectTerms select c).OrderBy(c => c.PolSourceSiteEffectTermID).Skip(0).Take(2).ToList();
                        count = (from c in db.PolSourceSiteEffectTerms select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with PolSourceSiteEffectTerm info
                        jsonRet = polSourceSiteEffectTermController.GetPolSourceSiteEffectTermList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.NotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<PolSourceSiteEffectTerm>>;
                        Assert.Equal(polSourceSiteEffectTermList[0].PolSourceSiteEffectTermID, ret.Content[0].PolSourceSiteEffectTermID);
                        Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with PolSourceSiteEffectTerm info
                           IHttpActionResult jsonRet2 = polSourceSiteEffectTermController.GetPolSourceSiteEffectTermList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkNegotiatedContentResult<List<PolSourceSiteEffectTerm>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<PolSourceSiteEffectTerm>>;
                           Assert.Equal(polSourceSiteEffectTermList[1].PolSourceSiteEffectTermID, ret2.Content[0].PolSourceSiteEffectTermID);
                           Assert.Equal((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void PolSourceSiteEffectTerm_Controller_GetPolSourceSiteEffectTermWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    PolSourceSiteEffectTermController polSourceSiteEffectTermController = new PolSourceSiteEffectTermController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(polSourceSiteEffectTermController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, polSourceSiteEffectTermController.DatabaseType);

                    PolSourceSiteEffectTerm polSourceSiteEffectTermFirst = new PolSourceSiteEffectTerm();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        PolSourceSiteEffectTermService polSourceSiteEffectTermService = new PolSourceSiteEffectTermService(new Query(), db, ContactID);
                        polSourceSiteEffectTermFirst = (from c in db.PolSourceSiteEffectTerms select c).FirstOrDefault();
                    }

                    // ok with PolSourceSiteEffectTerm info
                    IHttpActionResult jsonRet = polSourceSiteEffectTermController.GetPolSourceSiteEffectTermWithID(polSourceSiteEffectTermFirst.PolSourceSiteEffectTermID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<PolSourceSiteEffectTerm> Ret = jsonRet as OkNegotiatedContentResult<PolSourceSiteEffectTerm>;
                    PolSourceSiteEffectTerm polSourceSiteEffectTermRet = Ret.Content;
                    Assert.Equal(polSourceSiteEffectTermFirst.PolSourceSiteEffectTermID, polSourceSiteEffectTermRet.PolSourceSiteEffectTermID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = polSourceSiteEffectTermController.GetPolSourceSiteEffectTermWithID(0);
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<PolSourceSiteEffectTerm> polSourceSiteEffectTermRet2 = jsonRet2 as OkNegotiatedContentResult<PolSourceSiteEffectTerm>;
                    Assert.IsNull(polSourceSiteEffectTermRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.NotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void PolSourceSiteEffectTerm_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    PolSourceSiteEffectTermController polSourceSiteEffectTermController = new PolSourceSiteEffectTermController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(polSourceSiteEffectTermController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, polSourceSiteEffectTermController.DatabaseType);

                    PolSourceSiteEffectTerm polSourceSiteEffectTermLast = new PolSourceSiteEffectTerm();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        PolSourceSiteEffectTermService polSourceSiteEffectTermService = new PolSourceSiteEffectTermService(query, db, ContactID);
                        polSourceSiteEffectTermLast = (from c in db.PolSourceSiteEffectTerms select c).FirstOrDefault();
                    }

                    // ok with PolSourceSiteEffectTerm info
                    IHttpActionResult jsonRet = polSourceSiteEffectTermController.GetPolSourceSiteEffectTermWithID(polSourceSiteEffectTermLast.PolSourceSiteEffectTermID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<PolSourceSiteEffectTerm> Ret = jsonRet as OkNegotiatedContentResult<PolSourceSiteEffectTerm>;
                    PolSourceSiteEffectTerm polSourceSiteEffectTermRet = Ret.Content;
                    Assert.Equal(polSourceSiteEffectTermLast.PolSourceSiteEffectTermID, polSourceSiteEffectTermRet.PolSourceSiteEffectTermID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because PolSourceSiteEffectTermID exist
                    IHttpActionResult jsonRet2 = polSourceSiteEffectTermController.Post(polSourceSiteEffectTermRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<PolSourceSiteEffectTerm> polSourceSiteEffectTermRet2 = jsonRet2 as OkNegotiatedContentResult<PolSourceSiteEffectTerm>;
                    Assert.IsNull(polSourceSiteEffectTermRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added PolSourceSiteEffectTerm
                    polSourceSiteEffectTermRet.PolSourceSiteEffectTermID = 0;
                    polSourceSiteEffectTermController.Request = new System.Net.Http.HttpRequestMessage();
                    polSourceSiteEffectTermController.Request.RequestUri = new System.Uri("http://localhost:5000/api/polSourceSiteEffectTerm");
                    IHttpActionResult jsonRet3 = polSourceSiteEffectTermController.Post(polSourceSiteEffectTermRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<PolSourceSiteEffectTerm> polSourceSiteEffectTermRet3 = jsonRet3 as CreatedNegotiatedContentResult<PolSourceSiteEffectTerm>;
                    Assert.NotNull(polSourceSiteEffectTermRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = polSourceSiteEffectTermController.Delete(polSourceSiteEffectTermRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<PolSourceSiteEffectTerm> polSourceSiteEffectTermRet4 = jsonRet4 as OkNegotiatedContentResult<PolSourceSiteEffectTerm>;
                    Assert.NotNull(polSourceSiteEffectTermRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [Fact]
        public void PolSourceSiteEffectTerm_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    PolSourceSiteEffectTermController polSourceSiteEffectTermController = new PolSourceSiteEffectTermController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(polSourceSiteEffectTermController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, polSourceSiteEffectTermController.DatabaseType);

                    PolSourceSiteEffectTerm polSourceSiteEffectTermLast = new PolSourceSiteEffectTerm();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        PolSourceSiteEffectTermService polSourceSiteEffectTermService = new PolSourceSiteEffectTermService(query, db, ContactID);
                        polSourceSiteEffectTermLast = (from c in db.PolSourceSiteEffectTerms select c).FirstOrDefault();
                    }

                    // ok with PolSourceSiteEffectTerm info
                    IHttpActionResult jsonRet = polSourceSiteEffectTermController.GetPolSourceSiteEffectTermWithID(polSourceSiteEffectTermLast.PolSourceSiteEffectTermID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<PolSourceSiteEffectTerm> Ret = jsonRet as OkNegotiatedContentResult<PolSourceSiteEffectTerm>;
                    PolSourceSiteEffectTerm polSourceSiteEffectTermRet = Ret.Content;
                    Assert.Equal(polSourceSiteEffectTermLast.PolSourceSiteEffectTermID, polSourceSiteEffectTermRet.PolSourceSiteEffectTermID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = polSourceSiteEffectTermController.Put(polSourceSiteEffectTermRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<PolSourceSiteEffectTerm> polSourceSiteEffectTermRet2 = jsonRet2 as OkNegotiatedContentResult<PolSourceSiteEffectTerm>;
                    Assert.NotNull(polSourceSiteEffectTermRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because PolSourceSiteEffectTermID of 0 does not exist
                    polSourceSiteEffectTermRet.PolSourceSiteEffectTermID = 0;
                    IHttpActionResult jsonRet3 = polSourceSiteEffectTermController.Put(polSourceSiteEffectTermRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    OkNegotiatedContentResult<PolSourceSiteEffectTerm> polSourceSiteEffectTermRet3 = jsonRet3 as OkNegotiatedContentResult<PolSourceSiteEffectTerm>;
                    Assert.IsNull(polSourceSiteEffectTermRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void PolSourceSiteEffectTerm_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    PolSourceSiteEffectTermController polSourceSiteEffectTermController = new PolSourceSiteEffectTermController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(polSourceSiteEffectTermController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, polSourceSiteEffectTermController.DatabaseType);

                    PolSourceSiteEffectTerm polSourceSiteEffectTermLast = new PolSourceSiteEffectTerm();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        PolSourceSiteEffectTermService polSourceSiteEffectTermService = new PolSourceSiteEffectTermService(query, db, ContactID);
                        polSourceSiteEffectTermLast = (from c in db.PolSourceSiteEffectTerms select c).FirstOrDefault();
                    }

                    // ok with PolSourceSiteEffectTerm info
                    IHttpActionResult jsonRet = polSourceSiteEffectTermController.GetPolSourceSiteEffectTermWithID(polSourceSiteEffectTermLast.PolSourceSiteEffectTermID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<PolSourceSiteEffectTerm> Ret = jsonRet as OkNegotiatedContentResult<PolSourceSiteEffectTerm>;
                    PolSourceSiteEffectTerm polSourceSiteEffectTermRet = Ret.Content;
                    Assert.Equal(polSourceSiteEffectTermLast.PolSourceSiteEffectTermID, polSourceSiteEffectTermRet.PolSourceSiteEffectTermID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added PolSourceSiteEffectTerm
                    polSourceSiteEffectTermRet.PolSourceSiteEffectTermID = 0;
                    polSourceSiteEffectTermController.Request = new System.Net.Http.HttpRequestMessage();
                    polSourceSiteEffectTermController.Request.RequestUri = new System.Uri("http://localhost:5000/api/polSourceSiteEffectTerm");
                    IHttpActionResult jsonRet3 = polSourceSiteEffectTermController.Post(polSourceSiteEffectTermRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<PolSourceSiteEffectTerm> polSourceSiteEffectTermRet3 = jsonRet3 as CreatedNegotiatedContentResult<PolSourceSiteEffectTerm>;
                    Assert.NotNull(polSourceSiteEffectTermRet3);
                    PolSourceSiteEffectTerm polSourceSiteEffectTerm = polSourceSiteEffectTermRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = polSourceSiteEffectTermController.Delete(polSourceSiteEffectTermRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<PolSourceSiteEffectTerm> polSourceSiteEffectTermRet2 = jsonRet2 as OkNegotiatedContentResult<PolSourceSiteEffectTerm>;
                    Assert.NotNull(polSourceSiteEffectTermRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because PolSourceSiteEffectTermID of 0 does not exist
                    polSourceSiteEffectTermRet.PolSourceSiteEffectTermID = 0;
                    IHttpActionResult jsonRet4 = polSourceSiteEffectTermController.Delete(polSourceSiteEffectTermRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<PolSourceSiteEffectTerm> polSourceSiteEffectTermRet4 = jsonRet4 as OkNegotiatedContentResult<PolSourceSiteEffectTerm>;
                    Assert.IsNull(polSourceSiteEffectTermRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
