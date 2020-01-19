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
    public partial class TVItemStatControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TVItemStatControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void TVItemStat_Controller_GetTVItemStatList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVItemStatController tvItemStatController = new TVItemStatController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tvItemStatController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tvItemStatController.DatabaseType);

                    TVItemStat tvItemStatFirst = new TVItemStat();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        TVItemStatService tvItemStatService = new TVItemStatService(query, db, ContactID);
                        tvItemStatFirst = (from c in db.TVItemStats select c).FirstOrDefault();
                        count = (from c in db.TVItemStats select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with TVItemStat info
                    IHttpActionResult jsonRet = tvItemStatController.GetTVItemStatList();
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<List<TVItemStat>> ret = jsonRet as OkNegotiatedContentResult<List<TVItemStat>>;
                    Assert.Equal(tvItemStatFirst.TVItemStatID, ret.Content[0].TVItemStatID);
                    Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<TVItemStat> tvItemStatList = new List<TVItemStat>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        TVItemStatService tvItemStatService = new TVItemStatService(query, db, ContactID);
                        tvItemStatList = (from c in db.TVItemStats select c).OrderBy(c => c.TVItemStatID).Skip(0).Take(2).ToList();
                        count = (from c in db.TVItemStats select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with TVItemStat info
                        jsonRet = tvItemStatController.GetTVItemStatList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.NotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<TVItemStat>>;
                        Assert.Equal(tvItemStatList[0].TVItemStatID, ret.Content[0].TVItemStatID);
                        Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with TVItemStat info
                           IHttpActionResult jsonRet2 = tvItemStatController.GetTVItemStatList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkNegotiatedContentResult<List<TVItemStat>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<TVItemStat>>;
                           Assert.Equal(tvItemStatList[1].TVItemStatID, ret2.Content[0].TVItemStatID);
                           Assert.Equal((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void TVItemStat_Controller_GetTVItemStatWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVItemStatController tvItemStatController = new TVItemStatController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tvItemStatController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tvItemStatController.DatabaseType);

                    TVItemStat tvItemStatFirst = new TVItemStat();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        TVItemStatService tvItemStatService = new TVItemStatService(new Query(), db, ContactID);
                        tvItemStatFirst = (from c in db.TVItemStats select c).FirstOrDefault();
                    }

                    // ok with TVItemStat info
                    IHttpActionResult jsonRet = tvItemStatController.GetTVItemStatWithID(tvItemStatFirst.TVItemStatID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<TVItemStat> Ret = jsonRet as OkNegotiatedContentResult<TVItemStat>;
                    TVItemStat tvItemStatRet = Ret.Content;
                    Assert.Equal(tvItemStatFirst.TVItemStatID, tvItemStatRet.TVItemStatID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = tvItemStatController.GetTVItemStatWithID(0);
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<TVItemStat> tvItemStatRet2 = jsonRet2 as OkNegotiatedContentResult<TVItemStat>;
                    Assert.IsNull(tvItemStatRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.NotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void TVItemStat_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVItemStatController tvItemStatController = new TVItemStatController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tvItemStatController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tvItemStatController.DatabaseType);

                    TVItemStat tvItemStatLast = new TVItemStat();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        TVItemStatService tvItemStatService = new TVItemStatService(query, db, ContactID);
                        tvItemStatLast = (from c in db.TVItemStats select c).FirstOrDefault();
                    }

                    // ok with TVItemStat info
                    IHttpActionResult jsonRet = tvItemStatController.GetTVItemStatWithID(tvItemStatLast.TVItemStatID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<TVItemStat> Ret = jsonRet as OkNegotiatedContentResult<TVItemStat>;
                    TVItemStat tvItemStatRet = Ret.Content;
                    Assert.Equal(tvItemStatLast.TVItemStatID, tvItemStatRet.TVItemStatID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because TVItemStatID exist
                    IHttpActionResult jsonRet2 = tvItemStatController.Post(tvItemStatRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<TVItemStat> tvItemStatRet2 = jsonRet2 as OkNegotiatedContentResult<TVItemStat>;
                    Assert.IsNull(tvItemStatRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added TVItemStat
                    tvItemStatRet.TVItemStatID = 0;
                    tvItemStatController.Request = new System.Net.Http.HttpRequestMessage();
                    tvItemStatController.Request.RequestUri = new System.Uri("http://localhost:5000/api/tvItemStat");
                    IHttpActionResult jsonRet3 = tvItemStatController.Post(tvItemStatRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<TVItemStat> tvItemStatRet3 = jsonRet3 as CreatedNegotiatedContentResult<TVItemStat>;
                    Assert.NotNull(tvItemStatRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = tvItemStatController.Delete(tvItemStatRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<TVItemStat> tvItemStatRet4 = jsonRet4 as OkNegotiatedContentResult<TVItemStat>;
                    Assert.NotNull(tvItemStatRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [Fact]
        public void TVItemStat_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVItemStatController tvItemStatController = new TVItemStatController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tvItemStatController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tvItemStatController.DatabaseType);

                    TVItemStat tvItemStatLast = new TVItemStat();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        TVItemStatService tvItemStatService = new TVItemStatService(query, db, ContactID);
                        tvItemStatLast = (from c in db.TVItemStats select c).FirstOrDefault();
                    }

                    // ok with TVItemStat info
                    IHttpActionResult jsonRet = tvItemStatController.GetTVItemStatWithID(tvItemStatLast.TVItemStatID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<TVItemStat> Ret = jsonRet as OkNegotiatedContentResult<TVItemStat>;
                    TVItemStat tvItemStatRet = Ret.Content;
                    Assert.Equal(tvItemStatLast.TVItemStatID, tvItemStatRet.TVItemStatID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = tvItemStatController.Put(tvItemStatRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<TVItemStat> tvItemStatRet2 = jsonRet2 as OkNegotiatedContentResult<TVItemStat>;
                    Assert.NotNull(tvItemStatRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because TVItemStatID of 0 does not exist
                    tvItemStatRet.TVItemStatID = 0;
                    IHttpActionResult jsonRet3 = tvItemStatController.Put(tvItemStatRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    OkNegotiatedContentResult<TVItemStat> tvItemStatRet3 = jsonRet3 as OkNegotiatedContentResult<TVItemStat>;
                    Assert.IsNull(tvItemStatRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void TVItemStat_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVItemStatController tvItemStatController = new TVItemStatController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tvItemStatController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tvItemStatController.DatabaseType);

                    TVItemStat tvItemStatLast = new TVItemStat();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        TVItemStatService tvItemStatService = new TVItemStatService(query, db, ContactID);
                        tvItemStatLast = (from c in db.TVItemStats select c).FirstOrDefault();
                    }

                    // ok with TVItemStat info
                    IHttpActionResult jsonRet = tvItemStatController.GetTVItemStatWithID(tvItemStatLast.TVItemStatID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<TVItemStat> Ret = jsonRet as OkNegotiatedContentResult<TVItemStat>;
                    TVItemStat tvItemStatRet = Ret.Content;
                    Assert.Equal(tvItemStatLast.TVItemStatID, tvItemStatRet.TVItemStatID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added TVItemStat
                    tvItemStatRet.TVItemStatID = 0;
                    tvItemStatController.Request = new System.Net.Http.HttpRequestMessage();
                    tvItemStatController.Request.RequestUri = new System.Uri("http://localhost:5000/api/tvItemStat");
                    IHttpActionResult jsonRet3 = tvItemStatController.Post(tvItemStatRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<TVItemStat> tvItemStatRet3 = jsonRet3 as CreatedNegotiatedContentResult<TVItemStat>;
                    Assert.NotNull(tvItemStatRet3);
                    TVItemStat tvItemStat = tvItemStatRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = tvItemStatController.Delete(tvItemStatRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<TVItemStat> tvItemStatRet2 = jsonRet2 as OkNegotiatedContentResult<TVItemStat>;
                    Assert.NotNull(tvItemStatRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because TVItemStatID of 0 does not exist
                    tvItemStatRet.TVItemStatID = 0;
                    IHttpActionResult jsonRet4 = tvItemStatController.Delete(tvItemStatRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<TVItemStat> tvItemStatRet4 = jsonRet4 as OkNegotiatedContentResult<TVItemStat>;
                    Assert.IsNull(tvItemStatRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
