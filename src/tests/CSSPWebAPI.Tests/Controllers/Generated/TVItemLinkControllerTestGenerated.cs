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
                    IActionResult jsonRet = tvItemLinkController.GetTVItemLinkList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(tvItemLinkFirst.TVItemLinkID, ((List<TVItemLink>)ret.Value)[0].TVItemLinkID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<TVItemLink>)ret.Value).Count);

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
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(tvItemLinkList[0].TVItemLinkID, ((List<TVItemLink>)ret.Value)[0].TVItemLinkID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<TVItemLink>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with TVItemLink info
                           IActionResult jsonRet2 = tvItemLinkController.GetTVItemLinkList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(tvItemLinkList[1].TVItemLinkID, ((List<TVItemLink>)ret2.Value)[0].TVItemLinkID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<TVItemLink>)ret2.Value).Count);
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
                    IActionResult jsonRet = tvItemLinkController.GetTVItemLinkWithID(tvItemLinkFirst.TVItemLinkID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(tvItemLinkFirst.TVItemLinkID, ((TVItemLink)ret.Value).TVItemLinkID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = tvItemLinkController.GetTVItemLinkWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult tvItemLinkRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(tvItemLinkRet2);
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

                    TVItemLink tvItemLinkFirst = new TVItemLink();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        TVItemLinkService tvItemLinkService = new TVItemLinkService(query, db, ContactID);
                        tvItemLinkFirst = (from c in db.TVItemLinks select c).FirstOrDefault();
                    }

                    // ok with TVItemLink info
                    IActionResult jsonRet = tvItemLinkController.GetTVItemLinkWithID(tvItemLinkFirst.TVItemLinkID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    TVItemLink tvItemLinkRet = (TVItemLink)ret.Value;
                    Assert.Equal(tvItemLinkFirst.TVItemLinkID, tvItemLinkRet.TVItemLinkID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because TVItemLinkID exist
                    IActionResult jsonRet2 = tvItemLinkController.Post(tvItemLinkRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added TVItemLink
                    tvItemLinkRet.TVItemLinkID = 0;
                    IActionResult jsonRet3 = tvItemLinkController.Post(tvItemLinkRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = tvItemLinkController.Delete(tvItemLinkRet, LanguageRequest.ToString());
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
        public void TVItemLink_Controller_Put_Test()
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
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        TVItemLinkService tvItemLinkService = new TVItemLinkService(query, db, ContactID);
                        tvItemLinkFirst = (from c in db.TVItemLinks select c).FirstOrDefault();
                    }

                    // ok with TVItemLink info
                    IActionResult jsonRet = tvItemLinkController.GetTVItemLinkWithID(tvItemLinkFirst.TVItemLinkID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    TVItemLink tvItemLinkRet = (TVItemLink)Ret.Value;
                    Assert.Equal(tvItemLinkFirst.TVItemLinkID, tvItemLinkRet.TVItemLinkID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = tvItemLinkController.Put(tvItemLinkRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult tvItemLinkRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(tvItemLinkRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because TVItemLinkID of 0 does not exist
                    tvItemLinkRet.TVItemLinkID = 0;
                    IActionResult jsonRet3 = tvItemLinkController.Put(tvItemLinkRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult tvItemLinkRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(tvItemLinkRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
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

                    TVItemLink tvItemLinkFirst = new TVItemLink();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        TVItemLinkService tvItemLinkService = new TVItemLinkService(query, db, ContactID);
                        tvItemLinkFirst = (from c in db.TVItemLinks select c).FirstOrDefault();
                    }

                    // ok with TVItemLink info
                    IActionResult jsonRet = tvItemLinkController.GetTVItemLinkWithID(tvItemLinkFirst.TVItemLinkID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    TVItemLink tvItemLinkRet = (TVItemLink)Ret.Value;
                    Assert.Equal(tvItemLinkFirst.TVItemLinkID, tvItemLinkRet.TVItemLinkID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added TVItemLink
                    tvItemLinkRet.TVItemLinkID = 0;
                    IActionResult jsonRet3 = tvItemLinkController.Post(tvItemLinkRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    TVItemLink tvItemLink = (TVItemLink)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = tvItemLinkController.Delete(tvItemLinkRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because TVItemLinkID of 0 does not exist
                    tvItemLinkRet.TVItemLinkID = 0;
                    IActionResult jsonRet4 = tvItemLinkController.Delete(tvItemLinkRet, LanguageRequest.ToString());
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
