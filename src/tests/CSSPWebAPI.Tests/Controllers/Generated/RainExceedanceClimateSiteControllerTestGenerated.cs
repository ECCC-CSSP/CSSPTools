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
    public partial class RainExceedanceClimateSiteControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public RainExceedanceClimateSiteControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void RainExceedanceClimateSite_Controller_GetRainExceedanceClimateSiteList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    RainExceedanceClimateSiteController rainExceedanceClimateSiteController = new RainExceedanceClimateSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(rainExceedanceClimateSiteController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, rainExceedanceClimateSiteController.DatabaseType);

                    RainExceedanceClimateSite rainExceedanceClimateSiteFirst = new RainExceedanceClimateSite();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        RainExceedanceClimateSiteService rainExceedanceClimateSiteService = new RainExceedanceClimateSiteService(query, db, ContactID);
                        rainExceedanceClimateSiteFirst = (from c in db.RainExceedanceClimateSites select c).FirstOrDefault();
                        count = (from c in db.RainExceedanceClimateSites select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with RainExceedanceClimateSite info
                    IHttpActionResult jsonRet = rainExceedanceClimateSiteController.GetRainExceedanceClimateSiteList();
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<List<RainExceedanceClimateSite>> ret = jsonRet as OkNegotiatedContentResult<List<RainExceedanceClimateSite>>;
                    Assert.Equal(rainExceedanceClimateSiteFirst.RainExceedanceClimateSiteID, ret.Content[0].RainExceedanceClimateSiteID);
                    Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<RainExceedanceClimateSite> rainExceedanceClimateSiteList = new List<RainExceedanceClimateSite>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        RainExceedanceClimateSiteService rainExceedanceClimateSiteService = new RainExceedanceClimateSiteService(query, db, ContactID);
                        rainExceedanceClimateSiteList = (from c in db.RainExceedanceClimateSites select c).OrderBy(c => c.RainExceedanceClimateSiteID).Skip(0).Take(2).ToList();
                        count = (from c in db.RainExceedanceClimateSites select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with RainExceedanceClimateSite info
                        jsonRet = rainExceedanceClimateSiteController.GetRainExceedanceClimateSiteList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.NotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<RainExceedanceClimateSite>>;
                        Assert.Equal(rainExceedanceClimateSiteList[0].RainExceedanceClimateSiteID, ret.Content[0].RainExceedanceClimateSiteID);
                        Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with RainExceedanceClimateSite info
                           IHttpActionResult jsonRet2 = rainExceedanceClimateSiteController.GetRainExceedanceClimateSiteList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkNegotiatedContentResult<List<RainExceedanceClimateSite>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<RainExceedanceClimateSite>>;
                           Assert.Equal(rainExceedanceClimateSiteList[1].RainExceedanceClimateSiteID, ret2.Content[0].RainExceedanceClimateSiteID);
                           Assert.Equal((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void RainExceedanceClimateSite_Controller_GetRainExceedanceClimateSiteWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    RainExceedanceClimateSiteController rainExceedanceClimateSiteController = new RainExceedanceClimateSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(rainExceedanceClimateSiteController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, rainExceedanceClimateSiteController.DatabaseType);

                    RainExceedanceClimateSite rainExceedanceClimateSiteFirst = new RainExceedanceClimateSite();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        RainExceedanceClimateSiteService rainExceedanceClimateSiteService = new RainExceedanceClimateSiteService(new Query(), db, ContactID);
                        rainExceedanceClimateSiteFirst = (from c in db.RainExceedanceClimateSites select c).FirstOrDefault();
                    }

                    // ok with RainExceedanceClimateSite info
                    IHttpActionResult jsonRet = rainExceedanceClimateSiteController.GetRainExceedanceClimateSiteWithID(rainExceedanceClimateSiteFirst.RainExceedanceClimateSiteID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<RainExceedanceClimateSite> Ret = jsonRet as OkNegotiatedContentResult<RainExceedanceClimateSite>;
                    RainExceedanceClimateSite rainExceedanceClimateSiteRet = Ret.Content;
                    Assert.Equal(rainExceedanceClimateSiteFirst.RainExceedanceClimateSiteID, rainExceedanceClimateSiteRet.RainExceedanceClimateSiteID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = rainExceedanceClimateSiteController.GetRainExceedanceClimateSiteWithID(0);
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<RainExceedanceClimateSite> rainExceedanceClimateSiteRet2 = jsonRet2 as OkNegotiatedContentResult<RainExceedanceClimateSite>;
                    Assert.IsNull(rainExceedanceClimateSiteRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.NotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void RainExceedanceClimateSite_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    RainExceedanceClimateSiteController rainExceedanceClimateSiteController = new RainExceedanceClimateSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(rainExceedanceClimateSiteController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, rainExceedanceClimateSiteController.DatabaseType);

                    RainExceedanceClimateSite rainExceedanceClimateSiteLast = new RainExceedanceClimateSite();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        RainExceedanceClimateSiteService rainExceedanceClimateSiteService = new RainExceedanceClimateSiteService(query, db, ContactID);
                        rainExceedanceClimateSiteLast = (from c in db.RainExceedanceClimateSites select c).FirstOrDefault();
                    }

                    // ok with RainExceedanceClimateSite info
                    IHttpActionResult jsonRet = rainExceedanceClimateSiteController.GetRainExceedanceClimateSiteWithID(rainExceedanceClimateSiteLast.RainExceedanceClimateSiteID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<RainExceedanceClimateSite> Ret = jsonRet as OkNegotiatedContentResult<RainExceedanceClimateSite>;
                    RainExceedanceClimateSite rainExceedanceClimateSiteRet = Ret.Content;
                    Assert.Equal(rainExceedanceClimateSiteLast.RainExceedanceClimateSiteID, rainExceedanceClimateSiteRet.RainExceedanceClimateSiteID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because RainExceedanceClimateSiteID exist
                    IHttpActionResult jsonRet2 = rainExceedanceClimateSiteController.Post(rainExceedanceClimateSiteRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<RainExceedanceClimateSite> rainExceedanceClimateSiteRet2 = jsonRet2 as OkNegotiatedContentResult<RainExceedanceClimateSite>;
                    Assert.IsNull(rainExceedanceClimateSiteRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added RainExceedanceClimateSite
                    rainExceedanceClimateSiteRet.RainExceedanceClimateSiteID = 0;
                    rainExceedanceClimateSiteController.Request = new System.Net.Http.HttpRequestMessage();
                    rainExceedanceClimateSiteController.Request.RequestUri = new System.Uri("http://localhost:5000/api/rainExceedanceClimateSite");
                    IHttpActionResult jsonRet3 = rainExceedanceClimateSiteController.Post(rainExceedanceClimateSiteRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<RainExceedanceClimateSite> rainExceedanceClimateSiteRet3 = jsonRet3 as CreatedNegotiatedContentResult<RainExceedanceClimateSite>;
                    Assert.NotNull(rainExceedanceClimateSiteRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = rainExceedanceClimateSiteController.Delete(rainExceedanceClimateSiteRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<RainExceedanceClimateSite> rainExceedanceClimateSiteRet4 = jsonRet4 as OkNegotiatedContentResult<RainExceedanceClimateSite>;
                    Assert.NotNull(rainExceedanceClimateSiteRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [Fact]
        public void RainExceedanceClimateSite_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    RainExceedanceClimateSiteController rainExceedanceClimateSiteController = new RainExceedanceClimateSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(rainExceedanceClimateSiteController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, rainExceedanceClimateSiteController.DatabaseType);

                    RainExceedanceClimateSite rainExceedanceClimateSiteLast = new RainExceedanceClimateSite();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        RainExceedanceClimateSiteService rainExceedanceClimateSiteService = new RainExceedanceClimateSiteService(query, db, ContactID);
                        rainExceedanceClimateSiteLast = (from c in db.RainExceedanceClimateSites select c).FirstOrDefault();
                    }

                    // ok with RainExceedanceClimateSite info
                    IHttpActionResult jsonRet = rainExceedanceClimateSiteController.GetRainExceedanceClimateSiteWithID(rainExceedanceClimateSiteLast.RainExceedanceClimateSiteID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<RainExceedanceClimateSite> Ret = jsonRet as OkNegotiatedContentResult<RainExceedanceClimateSite>;
                    RainExceedanceClimateSite rainExceedanceClimateSiteRet = Ret.Content;
                    Assert.Equal(rainExceedanceClimateSiteLast.RainExceedanceClimateSiteID, rainExceedanceClimateSiteRet.RainExceedanceClimateSiteID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = rainExceedanceClimateSiteController.Put(rainExceedanceClimateSiteRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<RainExceedanceClimateSite> rainExceedanceClimateSiteRet2 = jsonRet2 as OkNegotiatedContentResult<RainExceedanceClimateSite>;
                    Assert.NotNull(rainExceedanceClimateSiteRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because RainExceedanceClimateSiteID of 0 does not exist
                    rainExceedanceClimateSiteRet.RainExceedanceClimateSiteID = 0;
                    IHttpActionResult jsonRet3 = rainExceedanceClimateSiteController.Put(rainExceedanceClimateSiteRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    OkNegotiatedContentResult<RainExceedanceClimateSite> rainExceedanceClimateSiteRet3 = jsonRet3 as OkNegotiatedContentResult<RainExceedanceClimateSite>;
                    Assert.IsNull(rainExceedanceClimateSiteRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void RainExceedanceClimateSite_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    RainExceedanceClimateSiteController rainExceedanceClimateSiteController = new RainExceedanceClimateSiteController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(rainExceedanceClimateSiteController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, rainExceedanceClimateSiteController.DatabaseType);

                    RainExceedanceClimateSite rainExceedanceClimateSiteLast = new RainExceedanceClimateSite();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        RainExceedanceClimateSiteService rainExceedanceClimateSiteService = new RainExceedanceClimateSiteService(query, db, ContactID);
                        rainExceedanceClimateSiteLast = (from c in db.RainExceedanceClimateSites select c).FirstOrDefault();
                    }

                    // ok with RainExceedanceClimateSite info
                    IHttpActionResult jsonRet = rainExceedanceClimateSiteController.GetRainExceedanceClimateSiteWithID(rainExceedanceClimateSiteLast.RainExceedanceClimateSiteID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<RainExceedanceClimateSite> Ret = jsonRet as OkNegotiatedContentResult<RainExceedanceClimateSite>;
                    RainExceedanceClimateSite rainExceedanceClimateSiteRet = Ret.Content;
                    Assert.Equal(rainExceedanceClimateSiteLast.RainExceedanceClimateSiteID, rainExceedanceClimateSiteRet.RainExceedanceClimateSiteID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added RainExceedanceClimateSite
                    rainExceedanceClimateSiteRet.RainExceedanceClimateSiteID = 0;
                    rainExceedanceClimateSiteController.Request = new System.Net.Http.HttpRequestMessage();
                    rainExceedanceClimateSiteController.Request.RequestUri = new System.Uri("http://localhost:5000/api/rainExceedanceClimateSite");
                    IHttpActionResult jsonRet3 = rainExceedanceClimateSiteController.Post(rainExceedanceClimateSiteRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<RainExceedanceClimateSite> rainExceedanceClimateSiteRet3 = jsonRet3 as CreatedNegotiatedContentResult<RainExceedanceClimateSite>;
                    Assert.NotNull(rainExceedanceClimateSiteRet3);
                    RainExceedanceClimateSite rainExceedanceClimateSite = rainExceedanceClimateSiteRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = rainExceedanceClimateSiteController.Delete(rainExceedanceClimateSiteRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<RainExceedanceClimateSite> rainExceedanceClimateSiteRet2 = jsonRet2 as OkNegotiatedContentResult<RainExceedanceClimateSite>;
                    Assert.NotNull(rainExceedanceClimateSiteRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because RainExceedanceClimateSiteID of 0 does not exist
                    rainExceedanceClimateSiteRet.RainExceedanceClimateSiteID = 0;
                    IHttpActionResult jsonRet4 = rainExceedanceClimateSiteController.Delete(rainExceedanceClimateSiteRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<RainExceedanceClimateSite> rainExceedanceClimateSiteRet4 = jsonRet4 as OkNegotiatedContentResult<RainExceedanceClimateSite>;
                    Assert.IsNull(rainExceedanceClimateSiteRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
