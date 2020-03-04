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
                    IActionResult jsonRet = polSourceSiteEffectController.GetPolSourceSiteEffectList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(polSourceSiteEffectFirst.PolSourceSiteEffectID, ((List<PolSourceSiteEffect>)ret.Value)[0].PolSourceSiteEffectID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<PolSourceSiteEffect>)ret.Value).Count);

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
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(polSourceSiteEffectList[0].PolSourceSiteEffectID, ((List<PolSourceSiteEffect>)ret.Value)[0].PolSourceSiteEffectID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<PolSourceSiteEffect>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with PolSourceSiteEffect info
                           IActionResult jsonRet2 = polSourceSiteEffectController.GetPolSourceSiteEffectList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(polSourceSiteEffectList[1].PolSourceSiteEffectID, ((List<PolSourceSiteEffect>)ret2.Value)[0].PolSourceSiteEffectID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<PolSourceSiteEffect>)ret2.Value).Count);
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
                    IActionResult jsonRet = polSourceSiteEffectController.GetPolSourceSiteEffectWithID(polSourceSiteEffectFirst.PolSourceSiteEffectID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(polSourceSiteEffectFirst.PolSourceSiteEffectID, ((PolSourceSiteEffect)ret.Value).PolSourceSiteEffectID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = polSourceSiteEffectController.GetPolSourceSiteEffectWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult polSourceSiteEffectRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(polSourceSiteEffectRet2);
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

                    PolSourceSiteEffect polSourceSiteEffectFirst = new PolSourceSiteEffect();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        PolSourceSiteEffectService polSourceSiteEffectService = new PolSourceSiteEffectService(query, db, ContactID);
                        polSourceSiteEffectFirst = (from c in db.PolSourceSiteEffects select c).FirstOrDefault();
                    }

                    // ok with PolSourceSiteEffect info
                    IActionResult jsonRet = polSourceSiteEffectController.GetPolSourceSiteEffectWithID(polSourceSiteEffectFirst.PolSourceSiteEffectID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    PolSourceSiteEffect polSourceSiteEffectRet = (PolSourceSiteEffect)ret.Value;
                    Assert.Equal(polSourceSiteEffectFirst.PolSourceSiteEffectID, polSourceSiteEffectRet.PolSourceSiteEffectID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because PolSourceSiteEffectID exist
                    IActionResult jsonRet2 = polSourceSiteEffectController.Post(polSourceSiteEffectRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added PolSourceSiteEffect
                    polSourceSiteEffectRet.PolSourceSiteEffectID = 0;
                    IActionResult jsonRet3 = polSourceSiteEffectController.Post(polSourceSiteEffectRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = polSourceSiteEffectController.Delete(polSourceSiteEffectRet, LanguageRequest.ToString());
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
        public void PolSourceSiteEffect_Controller_Put_Test()
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
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        PolSourceSiteEffectService polSourceSiteEffectService = new PolSourceSiteEffectService(query, db, ContactID);
                        polSourceSiteEffectFirst = (from c in db.PolSourceSiteEffects select c).FirstOrDefault();
                    }

                    // ok with PolSourceSiteEffect info
                    IActionResult jsonRet = polSourceSiteEffectController.GetPolSourceSiteEffectWithID(polSourceSiteEffectFirst.PolSourceSiteEffectID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    PolSourceSiteEffect polSourceSiteEffectRet = (PolSourceSiteEffect)Ret.Value;
                    Assert.Equal(polSourceSiteEffectFirst.PolSourceSiteEffectID, polSourceSiteEffectRet.PolSourceSiteEffectID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = polSourceSiteEffectController.Put(polSourceSiteEffectRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult polSourceSiteEffectRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(polSourceSiteEffectRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because PolSourceSiteEffectID of 0 does not exist
                    polSourceSiteEffectRet.PolSourceSiteEffectID = 0;
                    IActionResult jsonRet3 = polSourceSiteEffectController.Put(polSourceSiteEffectRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult polSourceSiteEffectRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(polSourceSiteEffectRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
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

                    PolSourceSiteEffect polSourceSiteEffectFirst = new PolSourceSiteEffect();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        PolSourceSiteEffectService polSourceSiteEffectService = new PolSourceSiteEffectService(query, db, ContactID);
                        polSourceSiteEffectFirst = (from c in db.PolSourceSiteEffects select c).FirstOrDefault();
                    }

                    // ok with PolSourceSiteEffect info
                    IActionResult jsonRet = polSourceSiteEffectController.GetPolSourceSiteEffectWithID(polSourceSiteEffectFirst.PolSourceSiteEffectID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    PolSourceSiteEffect polSourceSiteEffectRet = (PolSourceSiteEffect)Ret.Value;
                    Assert.Equal(polSourceSiteEffectFirst.PolSourceSiteEffectID, polSourceSiteEffectRet.PolSourceSiteEffectID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added PolSourceSiteEffect
                    polSourceSiteEffectRet.PolSourceSiteEffectID = 0;
                    IActionResult jsonRet3 = polSourceSiteEffectController.Post(polSourceSiteEffectRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    PolSourceSiteEffect polSourceSiteEffect = (PolSourceSiteEffect)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = polSourceSiteEffectController.Delete(polSourceSiteEffectRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because PolSourceSiteEffectID of 0 does not exist
                    polSourceSiteEffectRet.PolSourceSiteEffectID = 0;
                    IActionResult jsonRet4 = polSourceSiteEffectController.Delete(polSourceSiteEffectRet, LanguageRequest.ToString());
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
