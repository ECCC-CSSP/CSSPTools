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
    public partial class PolSourceSiteEffectControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public PolSourceSiteEffectControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void PolSourceSiteEffect_Controller_GetPolSourceSiteEffectList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    PolSourceSiteEffectController polSourceSiteEffectController = new PolSourceSiteEffectController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(polSourceSiteEffectController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, polSourceSiteEffectController.DatabaseType);

                    PolSourceSiteEffect polSourceSiteEffectFirst = new PolSourceSiteEffect();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        PolSourceSiteEffectService polSourceSiteEffectService = new PolSourceSiteEffectService(query, db, ContactID);
                        polSourceSiteEffectFirst = (from c in db.PolSourceSiteEffects select c).FirstOrDefault();
                        count = (from c in db.PolSourceSiteEffects select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with PolSourceSiteEffect info
                    IHttpActionResult jsonRet = polSourceSiteEffectController.GetPolSourceSiteEffectList();
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<List<PolSourceSiteEffect>> ret = jsonRet as OkNegotiatedContentResult<List<PolSourceSiteEffect>>;
                    Assert.Equal(polSourceSiteEffectFirst.PolSourceSiteEffectID, ret.Content[0].PolSourceSiteEffectID);
                    Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<PolSourceSiteEffect> polSourceSiteEffectList = new List<PolSourceSiteEffect>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        PolSourceSiteEffectService polSourceSiteEffectService = new PolSourceSiteEffectService(query, db, ContactID);
                        polSourceSiteEffectList = (from c in db.PolSourceSiteEffects select c).OrderBy(c => c.PolSourceSiteEffectID).Skip(0).Take(2).ToList();
                        count = (from c in db.PolSourceSiteEffects select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with PolSourceSiteEffect info
                        jsonRet = polSourceSiteEffectController.GetPolSourceSiteEffectList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.NotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<PolSourceSiteEffect>>;
                        Assert.Equal(polSourceSiteEffectList[0].PolSourceSiteEffectID, ret.Content[0].PolSourceSiteEffectID);
                        Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with PolSourceSiteEffect info
                           IHttpActionResult jsonRet2 = polSourceSiteEffectController.GetPolSourceSiteEffectList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkNegotiatedContentResult<List<PolSourceSiteEffect>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<PolSourceSiteEffect>>;
                           Assert.Equal(polSourceSiteEffectList[1].PolSourceSiteEffectID, ret2.Content[0].PolSourceSiteEffectID);
                           Assert.Equal((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void PolSourceSiteEffect_Controller_GetPolSourceSiteEffectWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    PolSourceSiteEffectController polSourceSiteEffectController = new PolSourceSiteEffectController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(polSourceSiteEffectController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, polSourceSiteEffectController.DatabaseType);

                    PolSourceSiteEffect polSourceSiteEffectFirst = new PolSourceSiteEffect();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        PolSourceSiteEffectService polSourceSiteEffectService = new PolSourceSiteEffectService(new Query(), db, ContactID);
                        polSourceSiteEffectFirst = (from c in db.PolSourceSiteEffects select c).FirstOrDefault();
                    }

                    // ok with PolSourceSiteEffect info
                    IHttpActionResult jsonRet = polSourceSiteEffectController.GetPolSourceSiteEffectWithID(polSourceSiteEffectFirst.PolSourceSiteEffectID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<PolSourceSiteEffect> Ret = jsonRet as OkNegotiatedContentResult<PolSourceSiteEffect>;
                    PolSourceSiteEffect polSourceSiteEffectRet = Ret.Content;
                    Assert.Equal(polSourceSiteEffectFirst.PolSourceSiteEffectID, polSourceSiteEffectRet.PolSourceSiteEffectID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = polSourceSiteEffectController.GetPolSourceSiteEffectWithID(0);
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<PolSourceSiteEffect> polSourceSiteEffectRet2 = jsonRet2 as OkNegotiatedContentResult<PolSourceSiteEffect>;
                    Assert.IsNull(polSourceSiteEffectRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.NotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void PolSourceSiteEffect_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    PolSourceSiteEffectController polSourceSiteEffectController = new PolSourceSiteEffectController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(polSourceSiteEffectController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, polSourceSiteEffectController.DatabaseType);

                    PolSourceSiteEffect polSourceSiteEffectLast = new PolSourceSiteEffect();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        PolSourceSiteEffectService polSourceSiteEffectService = new PolSourceSiteEffectService(query, db, ContactID);
                        polSourceSiteEffectLast = (from c in db.PolSourceSiteEffects select c).FirstOrDefault();
                    }

                    // ok with PolSourceSiteEffect info
                    IHttpActionResult jsonRet = polSourceSiteEffectController.GetPolSourceSiteEffectWithID(polSourceSiteEffectLast.PolSourceSiteEffectID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<PolSourceSiteEffect> Ret = jsonRet as OkNegotiatedContentResult<PolSourceSiteEffect>;
                    PolSourceSiteEffect polSourceSiteEffectRet = Ret.Content;
                    Assert.Equal(polSourceSiteEffectLast.PolSourceSiteEffectID, polSourceSiteEffectRet.PolSourceSiteEffectID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because PolSourceSiteEffectID exist
                    IHttpActionResult jsonRet2 = polSourceSiteEffectController.Post(polSourceSiteEffectRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<PolSourceSiteEffect> polSourceSiteEffectRet2 = jsonRet2 as OkNegotiatedContentResult<PolSourceSiteEffect>;
                    Assert.IsNull(polSourceSiteEffectRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added PolSourceSiteEffect
                    polSourceSiteEffectRet.PolSourceSiteEffectID = 0;
                    polSourceSiteEffectController.Request = new System.Net.Http.HttpRequestMessage();
                    polSourceSiteEffectController.Request.RequestUri = new System.Uri("http://localhost:5000/api/polSourceSiteEffect");
                    IHttpActionResult jsonRet3 = polSourceSiteEffectController.Post(polSourceSiteEffectRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<PolSourceSiteEffect> polSourceSiteEffectRet3 = jsonRet3 as CreatedNegotiatedContentResult<PolSourceSiteEffect>;
                    Assert.NotNull(polSourceSiteEffectRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = polSourceSiteEffectController.Delete(polSourceSiteEffectRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<PolSourceSiteEffect> polSourceSiteEffectRet4 = jsonRet4 as OkNegotiatedContentResult<PolSourceSiteEffect>;
                    Assert.NotNull(polSourceSiteEffectRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [Fact]
        public void PolSourceSiteEffect_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    PolSourceSiteEffectController polSourceSiteEffectController = new PolSourceSiteEffectController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(polSourceSiteEffectController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, polSourceSiteEffectController.DatabaseType);

                    PolSourceSiteEffect polSourceSiteEffectLast = new PolSourceSiteEffect();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        PolSourceSiteEffectService polSourceSiteEffectService = new PolSourceSiteEffectService(query, db, ContactID);
                        polSourceSiteEffectLast = (from c in db.PolSourceSiteEffects select c).FirstOrDefault();
                    }

                    // ok with PolSourceSiteEffect info
                    IHttpActionResult jsonRet = polSourceSiteEffectController.GetPolSourceSiteEffectWithID(polSourceSiteEffectLast.PolSourceSiteEffectID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<PolSourceSiteEffect> Ret = jsonRet as OkNegotiatedContentResult<PolSourceSiteEffect>;
                    PolSourceSiteEffect polSourceSiteEffectRet = Ret.Content;
                    Assert.Equal(polSourceSiteEffectLast.PolSourceSiteEffectID, polSourceSiteEffectRet.PolSourceSiteEffectID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = polSourceSiteEffectController.Put(polSourceSiteEffectRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<PolSourceSiteEffect> polSourceSiteEffectRet2 = jsonRet2 as OkNegotiatedContentResult<PolSourceSiteEffect>;
                    Assert.NotNull(polSourceSiteEffectRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because PolSourceSiteEffectID of 0 does not exist
                    polSourceSiteEffectRet.PolSourceSiteEffectID = 0;
                    IHttpActionResult jsonRet3 = polSourceSiteEffectController.Put(polSourceSiteEffectRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    OkNegotiatedContentResult<PolSourceSiteEffect> polSourceSiteEffectRet3 = jsonRet3 as OkNegotiatedContentResult<PolSourceSiteEffect>;
                    Assert.IsNull(polSourceSiteEffectRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void PolSourceSiteEffect_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    PolSourceSiteEffectController polSourceSiteEffectController = new PolSourceSiteEffectController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(polSourceSiteEffectController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, polSourceSiteEffectController.DatabaseType);

                    PolSourceSiteEffect polSourceSiteEffectLast = new PolSourceSiteEffect();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        PolSourceSiteEffectService polSourceSiteEffectService = new PolSourceSiteEffectService(query, db, ContactID);
                        polSourceSiteEffectLast = (from c in db.PolSourceSiteEffects select c).FirstOrDefault();
                    }

                    // ok with PolSourceSiteEffect info
                    IHttpActionResult jsonRet = polSourceSiteEffectController.GetPolSourceSiteEffectWithID(polSourceSiteEffectLast.PolSourceSiteEffectID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<PolSourceSiteEffect> Ret = jsonRet as OkNegotiatedContentResult<PolSourceSiteEffect>;
                    PolSourceSiteEffect polSourceSiteEffectRet = Ret.Content;
                    Assert.Equal(polSourceSiteEffectLast.PolSourceSiteEffectID, polSourceSiteEffectRet.PolSourceSiteEffectID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added PolSourceSiteEffect
                    polSourceSiteEffectRet.PolSourceSiteEffectID = 0;
                    polSourceSiteEffectController.Request = new System.Net.Http.HttpRequestMessage();
                    polSourceSiteEffectController.Request.RequestUri = new System.Uri("http://localhost:5000/api/polSourceSiteEffect");
                    IHttpActionResult jsonRet3 = polSourceSiteEffectController.Post(polSourceSiteEffectRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<PolSourceSiteEffect> polSourceSiteEffectRet3 = jsonRet3 as CreatedNegotiatedContentResult<PolSourceSiteEffect>;
                    Assert.NotNull(polSourceSiteEffectRet3);
                    PolSourceSiteEffect polSourceSiteEffect = polSourceSiteEffectRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = polSourceSiteEffectController.Delete(polSourceSiteEffectRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<PolSourceSiteEffect> polSourceSiteEffectRet2 = jsonRet2 as OkNegotiatedContentResult<PolSourceSiteEffect>;
                    Assert.NotNull(polSourceSiteEffectRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because PolSourceSiteEffectID of 0 does not exist
                    polSourceSiteEffectRet.PolSourceSiteEffectID = 0;
                    IHttpActionResult jsonRet4 = polSourceSiteEffectController.Delete(polSourceSiteEffectRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<PolSourceSiteEffect> polSourceSiteEffectRet4 = jsonRet4 as OkNegotiatedContentResult<PolSourceSiteEffect>;
                    Assert.IsNull(polSourceSiteEffectRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
