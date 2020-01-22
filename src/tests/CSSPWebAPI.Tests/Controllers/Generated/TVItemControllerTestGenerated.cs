using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Xunit;
using CSSPWebAPI.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.AspNetCore.Mvc;

namespace CSSPWebAPI.Tests.Controllers
{
    public partial class TVItemControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TVItemControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void TVItem_Controller_GetTVItemList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVItemController tvItemController = new TVItemController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tvItemController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tvItemController.DatabaseType);

                    TVItem tvItemFirst = new TVItem();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        TVItemService tvItemService = new TVItemService(query, db, ContactID);
                        tvItemFirst = (from c in db.TVItems select c).FirstOrDefault();
                        count = (from c in db.TVItems select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with TVItem info
                    IActionResult jsonRet = tvItemController.GetTVItemList();
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<List<TVItem>> ret = jsonRet as OkNegotiatedContentResult<List<TVItem>>;
                    Assert.Equal(tvItemFirst.TVItemID, ret.Content[0].TVItemID);
                    Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<TVItem> tvItemList = new List<TVItem>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        TVItemService tvItemService = new TVItemService(query, db, ContactID);
                        tvItemList = (from c in db.TVItems select c).OrderBy(c => c.TVItemID).Skip(0).Take(2).ToList();
                        count = (from c in db.TVItems select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with TVItem info
                        jsonRet = tvItemController.GetTVItemList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.NotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<TVItem>>;
                        Assert.Equal(tvItemList[0].TVItemID, ret.Content[0].TVItemID);
                        Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with TVItem info
                           IActionResult jsonRet2 = tvItemController.GetTVItemList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkNegotiatedContentResult<List<TVItem>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<TVItem>>;
                           Assert.Equal(tvItemList[1].TVItemID, ret2.Content[0].TVItemID);
                           Assert.Equal((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void TVItem_Controller_GetTVItemWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVItemController tvItemController = new TVItemController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tvItemController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tvItemController.DatabaseType);

                    TVItem tvItemFirst = new TVItem();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        TVItemService tvItemService = new TVItemService(new Query(), db, ContactID);
                        tvItemFirst = (from c in db.TVItems select c).FirstOrDefault();
                    }

                    // ok with TVItem info
                    IActionResult jsonRet = tvItemController.GetTVItemWithID(tvItemFirst.TVItemID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<TVItem> Ret = jsonRet as OkNegotiatedContentResult<TVItem>;
                    TVItem tvItemRet = Ret.Content;
                    Assert.Equal(tvItemFirst.TVItemID, tvItemRet.TVItemID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = tvItemController.GetTVItemWithID(0);
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<TVItem> tvItemRet2 = jsonRet2 as OkNegotiatedContentResult<TVItem>;
                    Assert.Null(tvItemRet2);

                    NotFoundObjectResult notFoundRequest = jsonRet2 as NotFoundObjectResult;
                    Assert.NotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void TVItem_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVItemController tvItemController = new TVItemController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tvItemController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tvItemController.DatabaseType);

                    TVItem tvItemLast = new TVItem();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        TVItemService tvItemService = new TVItemService(query, db, ContactID);
                        tvItemLast = (from c in db.TVItems select c).FirstOrDefault();
                    }

                    // ok with TVItem info
                    IActionResult jsonRet = tvItemController.GetTVItemWithID(tvItemLast.TVItemID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<TVItem> Ret = jsonRet as OkNegotiatedContentResult<TVItem>;
                    TVItem tvItemRet = Ret.Content;
                    Assert.Equal(tvItemLast.TVItemID, tvItemRet.TVItemID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because TVItemID exist
                    IActionResult jsonRet2 = tvItemController.Post(tvItemRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<TVItem> tvItemRet2 = jsonRet2 as OkNegotiatedContentResult<TVItem>;
                    Assert.Null(tvItemRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added TVItem
                    tvItemRet.TVItemID = 0;
                    tvItemRet.TVLevel = 1;
                    tvItemRet.TVType = TVTypeEnum.Contact;
                    tvItemController.Request = new System.Net.Http.HttpRequestMessage();
                    tvItemController.Request.RequestUri = new System.Uri("http://localhost:5000/api/tvItem");
                    IActionResult jsonRet3 = tvItemController.Post(tvItemRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<TVItem> tvItemRet3 = jsonRet3 as CreatedNegotiatedContentResult<TVItem>;
                    Assert.NotNull(tvItemRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = tvItemController.Delete(tvItemRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<TVItem> tvItemRet4 = jsonRet4 as OkNegotiatedContentResult<TVItem>;
                    Assert.NotNull(tvItemRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [Fact]
        public void TVItem_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVItemController tvItemController = new TVItemController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tvItemController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tvItemController.DatabaseType);

                    TVItem tvItemLast = new TVItem();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        TVItemService tvItemService = new TVItemService(query, db, ContactID);
                        tvItemLast = (from c in db.TVItems select c).LastOrDefault();
                    }

                    // ok with TVItem info
                    IActionResult jsonRet = tvItemController.GetTVItemWithID(tvItemLast.TVItemID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<TVItem> Ret = jsonRet as OkNegotiatedContentResult<TVItem>;
                    TVItem tvItemRet = Ret.Content;
                    Assert.Equal(tvItemLast.TVItemID, tvItemRet.TVItemID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = tvItemController.Put(tvItemRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<TVItem> tvItemRet2 = jsonRet2 as OkNegotiatedContentResult<TVItem>;
                    Assert.NotNull(tvItemRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because TVItemID of 0 does not exist
                    tvItemRet.TVItemID = 0;
                    IActionResult jsonRet3 = tvItemController.Put(tvItemRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    OkNegotiatedContentResult<TVItem> tvItemRet3 = jsonRet3 as OkNegotiatedContentResult<TVItem>;
                    Assert.Null(tvItemRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void TVItem_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVItemController tvItemController = new TVItemController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tvItemController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tvItemController.DatabaseType);

                    TVItem tvItemLast = new TVItem();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        TVItemService tvItemService = new TVItemService(query, db, ContactID);
                        tvItemLast = (from c in db.TVItems select c).FirstOrDefault();
                    }

                    // ok with TVItem info
                    IActionResult jsonRet = tvItemController.GetTVItemWithID(tvItemLast.TVItemID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<TVItem> Ret = jsonRet as OkNegotiatedContentResult<TVItem>;
                    TVItem tvItemRet = Ret.Content;
                    Assert.Equal(tvItemLast.TVItemID, tvItemRet.TVItemID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return newly added TVItem
                    tvItemRet.TVItemID = 0;
                    tvItemRet.TVLevel = 1;
                    tvItemRet.TVType = TVTypeEnum.Contact;
                    tvItemController.Request = new System.Net.Http.HttpRequestMessage();
                    tvItemController.Request.RequestUri = new System.Uri("http://localhost:5000/api/tvItem");
                    IActionResult jsonRet3 = tvItemController.Post(tvItemRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<TVItem> tvItemRet3 = jsonRet3 as CreatedNegotiatedContentResult<TVItem>;
                    Assert.NotNull(tvItemRet3);
                    TVItem tvItem = tvItemRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = tvItemController.Delete(tvItemRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<TVItem> tvItemRet2 = jsonRet2 as OkNegotiatedContentResult<TVItem>;
                    Assert.NotNull(tvItemRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because TVItemID of 0 does not exist
                    tvItemRet.TVItemID = 0;
                    IActionResult jsonRet4 = tvItemController.Delete(tvItemRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<TVItem> tvItemRet4 = jsonRet4 as OkNegotiatedContentResult<TVItem>;
                    Assert.Null(tvItemRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
