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
                    IActionResult jsonRet = tvItemStatController.GetTVItemStatList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(tvItemStatFirst.TVItemStatID, ((List<TVItemStat>)ret.Value)[0].TVItemStatID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<TVItemStat>)ret.Value).Count);

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
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(tvItemStatList[0].TVItemStatID, ((List<TVItemStat>)ret.Value)[0].TVItemStatID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<TVItemStat>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with TVItemStat info
                           IActionResult jsonRet2 = tvItemStatController.GetTVItemStatList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(tvItemStatList[1].TVItemStatID, ((List<TVItemStat>)ret2.Value)[0].TVItemStatID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<TVItemStat>)ret2.Value).Count);
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
                    IActionResult jsonRet = tvItemStatController.GetTVItemStatWithID(tvItemStatFirst.TVItemStatID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(tvItemStatFirst.TVItemStatID, ((TVItemStat)ret.Value).TVItemStatID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = tvItemStatController.GetTVItemStatWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult tvItemStatRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(tvItemStatRet2);
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

                    TVItemStat tvItemStatFirst = new TVItemStat();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        TVItemStatService tvItemStatService = new TVItemStatService(query, db, ContactID);
                        tvItemStatFirst = (from c in db.TVItemStats select c).FirstOrDefault();
                    }

                    // ok with TVItemStat info
                    IActionResult jsonRet = tvItemStatController.GetTVItemStatWithID(tvItemStatFirst.TVItemStatID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    TVItemStat tvItemStatRet = (TVItemStat)ret.Value;
                    Assert.Equal(tvItemStatFirst.TVItemStatID, tvItemStatRet.TVItemStatID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because TVItemStatID exist
                    IActionResult jsonRet2 = tvItemStatController.Post(tvItemStatRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added TVItemStat
                    tvItemStatRet.TVItemStatID = 0;
                    IActionResult jsonRet3 = tvItemStatController.Post(tvItemStatRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = tvItemStatController.Delete(tvItemStatRet, LanguageRequest.ToString());
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
        public void TVItemStat_Controller_Put_Test()
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
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        TVItemStatService tvItemStatService = new TVItemStatService(query, db, ContactID);
                        tvItemStatFirst = (from c in db.TVItemStats select c).FirstOrDefault();
                    }

                    // ok with TVItemStat info
                    IActionResult jsonRet = tvItemStatController.GetTVItemStatWithID(tvItemStatFirst.TVItemStatID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    TVItemStat tvItemStatRet = (TVItemStat)Ret.Value;
                    Assert.Equal(tvItemStatFirst.TVItemStatID, tvItemStatRet.TVItemStatID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = tvItemStatController.Put(tvItemStatRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult tvItemStatRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(tvItemStatRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because TVItemStatID of 0 does not exist
                    tvItemStatRet.TVItemStatID = 0;
                    IActionResult jsonRet3 = tvItemStatController.Put(tvItemStatRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult tvItemStatRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(tvItemStatRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
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

                    TVItemStat tvItemStatFirst = new TVItemStat();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        TVItemStatService tvItemStatService = new TVItemStatService(query, db, ContactID);
                        tvItemStatFirst = (from c in db.TVItemStats select c).FirstOrDefault();
                    }

                    // ok with TVItemStat info
                    IActionResult jsonRet = tvItemStatController.GetTVItemStatWithID(tvItemStatFirst.TVItemStatID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    TVItemStat tvItemStatRet = (TVItemStat)Ret.Value;
                    Assert.Equal(tvItemStatFirst.TVItemStatID, tvItemStatRet.TVItemStatID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added TVItemStat
                    tvItemStatRet.TVItemStatID = 0;
                    IActionResult jsonRet3 = tvItemStatController.Post(tvItemStatRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    TVItemStat tvItemStat = (TVItemStat)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = tvItemStatController.Delete(tvItemStatRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because TVItemStatID of 0 does not exist
                    tvItemStatRet.TVItemStatID = 0;
                    IActionResult jsonRet4 = tvItemStatController.Delete(tvItemStatRet, LanguageRequest.ToString());
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
