using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Xunit;
using CSSPWebAPI.Controllers;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System;
using CSSPWebAPI.Controllers.Resources;

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
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(tvItemFirst.TVItemID, ((List<TVItem>)ret.Value)[0].TVItemID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<TVItem>)ret.Value).Count);

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
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(tvItemList[0].TVItemID, ((List<TVItem>)ret.Value)[0].TVItemID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<TVItem>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with TVItem info
                           IActionResult jsonRet2 = tvItemController.GetTVItemList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(tvItemList[1].TVItemID, ((List<TVItem>)ret2.Value)[0].TVItemID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<TVItem>)ret2.Value).Count);
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
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(tvItemFirst.TVItemID, ((TVItem)ret.Value).TVItemID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = tvItemController.GetTVItemWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult tvItemRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(tvItemRet2);
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

                    TVItem tvItemFirst = new TVItem();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        TVItemService tvItemService = new TVItemService(query, db, ContactID);
                        tvItemFirst = (from c in db.TVItems select c).FirstOrDefault();
                    }

                    // ok with TVItem info
                    IActionResult jsonRet = tvItemController.GetTVItemWithID(tvItemFirst.TVItemID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    TVItem tvItemRet = (TVItem)ret.Value;
                    Assert.Equal(tvItemFirst.TVItemID, tvItemRet.TVItemID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because TVItemID exist
                    IActionResult jsonRet2 = tvItemController.Post(tvItemRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added TVItem
                    tvItemRet.TVItemID = 0;
                    tvItemRet.TVLevel = 1;
                    tvItemRet.TVType = TVTypeEnum.Contact;
                    IActionResult jsonRet3 = tvItemController.Post(tvItemRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = tvItemController.Delete(tvItemRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet4);

                    OkObjectResult ret4 = jsonRet4 as OkObjectResult;
                    Assert.NotNull(ret4);

                    BadRequestResult badRequest4 = jsonRet4 as BadRequestResult;
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

                    TVItem tvItemFirst = new TVItem();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        TVItemService tvItemService = new TVItemService(query, db, ContactID);
                        tvItemFirst = (from c in db.TVItems select c).Skip(2).FirstOrDefault();
                    }

                    // ok with TVItem info
                    IActionResult jsonRet = tvItemController.GetTVItemWithID(tvItemFirst.TVItemID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    TVItem tvItemRet = (TVItem)Ret.Value;
                    Assert.Equal(tvItemFirst.TVItemID, tvItemRet.TVItemID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = tvItemController.Put(tvItemRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult tvItemRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(tvItemRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because TVItemID of 0 does not exist
                    tvItemRet.TVItemID = 0;
                    IActionResult jsonRet3 = tvItemController.Put(tvItemRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult tvItemRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(tvItemRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
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

                    TVItem tvItemFirst = new TVItem();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        TVItemService tvItemService = new TVItemService(query, db, ContactID);
                        tvItemFirst = (from c in db.TVItems select c).FirstOrDefault();
                    }

                    // ok with TVItem info
                    IActionResult jsonRet = tvItemController.GetTVItemWithID(tvItemFirst.TVItemID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    TVItem tvItemRet = (TVItem)Ret.Value;
                    Assert.Equal(tvItemFirst.TVItemID, tvItemRet.TVItemID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added TVItem
                    tvItemRet.TVItemID = 0;
                    tvItemRet.TVLevel = 1;
                    tvItemRet.TVType = TVTypeEnum.Contact;
                    IActionResult jsonRet3 = tvItemController.Post(tvItemRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    TVItem tvItem = (TVItem)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = tvItemController.Delete(tvItemRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because TVItemID of 0 does not exist
                    tvItemRet.TVItemID = 0;
                    IActionResult jsonRet4 = tvItemController.Delete(tvItemRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet4);

                    OkObjectResult ret4 = jsonRet4 as OkObjectResult;
                    Assert.Null(ret4);

                    BadRequestObjectResult badRequest4 = jsonRet4 as BadRequestObjectResult;
                    Assert.NotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
