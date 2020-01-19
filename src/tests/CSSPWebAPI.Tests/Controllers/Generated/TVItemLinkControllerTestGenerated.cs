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
    public partial class TVItemLinkControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TVItemLinkControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void TVItemLink_Controller_GetTVItemLinkList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVItemLinkController tvItemLinkController = new TVItemLinkController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tvItemLinkController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tvItemLinkController.DatabaseType);

                    TVItemLink tvItemLinkFirst = new TVItemLink();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        TVItemLinkService tvItemLinkService = new TVItemLinkService(query, db, ContactID);
                        tvItemLinkFirst = (from c in db.TVItemLinks select c).FirstOrDefault();
                        count = (from c in db.TVItemLinks select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with TVItemLink info
                    IHttpActionResult jsonRet = tvItemLinkController.GetTVItemLinkList();
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<List<TVItemLink>> ret = jsonRet as OkNegotiatedContentResult<List<TVItemLink>>;
                    Assert.Equal(tvItemLinkFirst.TVItemLinkID, ret.Content[0].TVItemLinkID);
                    Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<TVItemLink> tvItemLinkList = new List<TVItemLink>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        TVItemLinkService tvItemLinkService = new TVItemLinkService(query, db, ContactID);
                        tvItemLinkList = (from c in db.TVItemLinks select c).OrderBy(c => c.TVItemLinkID).Skip(0).Take(2).ToList();
                        count = (from c in db.TVItemLinks select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with TVItemLink info
                        jsonRet = tvItemLinkController.GetTVItemLinkList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.NotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<TVItemLink>>;
                        Assert.Equal(tvItemLinkList[0].TVItemLinkID, ret.Content[0].TVItemLinkID);
                        Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with TVItemLink info
                           IHttpActionResult jsonRet2 = tvItemLinkController.GetTVItemLinkList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkNegotiatedContentResult<List<TVItemLink>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<TVItemLink>>;
                           Assert.Equal(tvItemLinkList[1].TVItemLinkID, ret2.Content[0].TVItemLinkID);
                           Assert.Equal((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void TVItemLink_Controller_GetTVItemLinkWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVItemLinkController tvItemLinkController = new TVItemLinkController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tvItemLinkController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tvItemLinkController.DatabaseType);

                    TVItemLink tvItemLinkFirst = new TVItemLink();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        TVItemLinkService tvItemLinkService = new TVItemLinkService(new Query(), db, ContactID);
                        tvItemLinkFirst = (from c in db.TVItemLinks select c).FirstOrDefault();
                    }

                    // ok with TVItemLink info
                    IHttpActionResult jsonRet = tvItemLinkController.GetTVItemLinkWithID(tvItemLinkFirst.TVItemLinkID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<TVItemLink> Ret = jsonRet as OkNegotiatedContentResult<TVItemLink>;
                    TVItemLink tvItemLinkRet = Ret.Content;
                    Assert.Equal(tvItemLinkFirst.TVItemLinkID, tvItemLinkRet.TVItemLinkID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = tvItemLinkController.GetTVItemLinkWithID(0);
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<TVItemLink> tvItemLinkRet2 = jsonRet2 as OkNegotiatedContentResult<TVItemLink>;
                    Assert.IsNull(tvItemLinkRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.NotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void TVItemLink_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVItemLinkController tvItemLinkController = new TVItemLinkController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tvItemLinkController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tvItemLinkController.DatabaseType);

                    TVItemLink tvItemLinkLast = new TVItemLink();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        TVItemLinkService tvItemLinkService = new TVItemLinkService(query, db, ContactID);
                        tvItemLinkLast = (from c in db.TVItemLinks select c).FirstOrDefault();
                    }

                    // ok with TVItemLink info
                    IHttpActionResult jsonRet = tvItemLinkController.GetTVItemLinkWithID(tvItemLinkLast.TVItemLinkID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<TVItemLink> Ret = jsonRet as OkNegotiatedContentResult<TVItemLink>;
                    TVItemLink tvItemLinkRet = Ret.Content;
                    Assert.Equal(tvItemLinkLast.TVItemLinkID, tvItemLinkRet.TVItemLinkID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because TVItemLinkID exist
                    IHttpActionResult jsonRet2 = tvItemLinkController.Post(tvItemLinkRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<TVItemLink> tvItemLinkRet2 = jsonRet2 as OkNegotiatedContentResult<TVItemLink>;
                    Assert.IsNull(tvItemLinkRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added TVItemLink
                    tvItemLinkRet.TVItemLinkID = 0;
                    tvItemLinkController.Request = new System.Net.Http.HttpRequestMessage();
                    tvItemLinkController.Request.RequestUri = new System.Uri("http://localhost:5000/api/tvItemLink");
                    IHttpActionResult jsonRet3 = tvItemLinkController.Post(tvItemLinkRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<TVItemLink> tvItemLinkRet3 = jsonRet3 as CreatedNegotiatedContentResult<TVItemLink>;
                    Assert.NotNull(tvItemLinkRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = tvItemLinkController.Delete(tvItemLinkRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<TVItemLink> tvItemLinkRet4 = jsonRet4 as OkNegotiatedContentResult<TVItemLink>;
                    Assert.NotNull(tvItemLinkRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [Fact]
        public void TVItemLink_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVItemLinkController tvItemLinkController = new TVItemLinkController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tvItemLinkController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tvItemLinkController.DatabaseType);

                    TVItemLink tvItemLinkLast = new TVItemLink();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        TVItemLinkService tvItemLinkService = new TVItemLinkService(query, db, ContactID);
                        tvItemLinkLast = (from c in db.TVItemLinks select c).FirstOrDefault();
                    }

                    // ok with TVItemLink info
                    IHttpActionResult jsonRet = tvItemLinkController.GetTVItemLinkWithID(tvItemLinkLast.TVItemLinkID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<TVItemLink> Ret = jsonRet as OkNegotiatedContentResult<TVItemLink>;
                    TVItemLink tvItemLinkRet = Ret.Content;
                    Assert.Equal(tvItemLinkLast.TVItemLinkID, tvItemLinkRet.TVItemLinkID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = tvItemLinkController.Put(tvItemLinkRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<TVItemLink> tvItemLinkRet2 = jsonRet2 as OkNegotiatedContentResult<TVItemLink>;
                    Assert.NotNull(tvItemLinkRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because TVItemLinkID of 0 does not exist
                    tvItemLinkRet.TVItemLinkID = 0;
                    IHttpActionResult jsonRet3 = tvItemLinkController.Put(tvItemLinkRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    OkNegotiatedContentResult<TVItemLink> tvItemLinkRet3 = jsonRet3 as OkNegotiatedContentResult<TVItemLink>;
                    Assert.IsNull(tvItemLinkRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void TVItemLink_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVItemLinkController tvItemLinkController = new TVItemLinkController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tvItemLinkController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tvItemLinkController.DatabaseType);

                    TVItemLink tvItemLinkLast = new TVItemLink();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        TVItemLinkService tvItemLinkService = new TVItemLinkService(query, db, ContactID);
                        tvItemLinkLast = (from c in db.TVItemLinks select c).FirstOrDefault();
                    }

                    // ok with TVItemLink info
                    IHttpActionResult jsonRet = tvItemLinkController.GetTVItemLinkWithID(tvItemLinkLast.TVItemLinkID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<TVItemLink> Ret = jsonRet as OkNegotiatedContentResult<TVItemLink>;
                    TVItemLink tvItemLinkRet = Ret.Content;
                    Assert.Equal(tvItemLinkLast.TVItemLinkID, tvItemLinkRet.TVItemLinkID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added TVItemLink
                    tvItemLinkRet.TVItemLinkID = 0;
                    tvItemLinkController.Request = new System.Net.Http.HttpRequestMessage();
                    tvItemLinkController.Request.RequestUri = new System.Uri("http://localhost:5000/api/tvItemLink");
                    IHttpActionResult jsonRet3 = tvItemLinkController.Post(tvItemLinkRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<TVItemLink> tvItemLinkRet3 = jsonRet3 as CreatedNegotiatedContentResult<TVItemLink>;
                    Assert.NotNull(tvItemLinkRet3);
                    TVItemLink tvItemLink = tvItemLinkRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = tvItemLinkController.Delete(tvItemLinkRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<TVItemLink> tvItemLinkRet2 = jsonRet2 as OkNegotiatedContentResult<TVItemLink>;
                    Assert.NotNull(tvItemLinkRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because TVItemLinkID of 0 does not exist
                    tvItemLinkRet.TVItemLinkID = 0;
                    IHttpActionResult jsonRet4 = tvItemLinkController.Delete(tvItemLinkRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<TVItemLink> tvItemLinkRet4 = jsonRet4 as OkNegotiatedContentResult<TVItemLink>;
                    Assert.IsNull(tvItemLinkRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
