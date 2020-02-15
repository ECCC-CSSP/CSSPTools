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
    public partial class BoxModelLanguageControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public BoxModelLanguageControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void BoxModelLanguage_Controller_GetBoxModelLanguageList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    BoxModelLanguageController boxModelLanguageController = new BoxModelLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(boxModelLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, boxModelLanguageController.DatabaseType);

                    BoxModelLanguage boxModelLanguageFirst = new BoxModelLanguage();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        BoxModelLanguageService boxModelLanguageService = new BoxModelLanguageService(query, db, ContactID);
                        boxModelLanguageFirst = (from c in db.BoxModelLanguages select c).FirstOrDefault();
                        count = (from c in db.BoxModelLanguages select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with BoxModelLanguage info
                    IActionResult jsonRet = boxModelLanguageController.GetBoxModelLanguageList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(boxModelLanguageFirst.BoxModelLanguageID, ((List<BoxModelLanguage>)ret.Value)[0].BoxModelLanguageID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<BoxModelLanguage>)ret.Value).Count);

                    List<BoxModelLanguage> boxModelLanguageList = new List<BoxModelLanguage>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        BoxModelLanguageService boxModelLanguageService = new BoxModelLanguageService(query, db, ContactID);
                        boxModelLanguageList = (from c in db.BoxModelLanguages select c).OrderBy(c => c.BoxModelLanguageID).Skip(0).Take(2).ToList();
                        count = (from c in db.BoxModelLanguages select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with BoxModelLanguage info
                        jsonRet = boxModelLanguageController.GetBoxModelLanguageList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(boxModelLanguageList[0].BoxModelLanguageID, ((List<BoxModelLanguage>)ret.Value)[0].BoxModelLanguageID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<BoxModelLanguage>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with BoxModelLanguage info
                           IActionResult jsonRet2 = boxModelLanguageController.GetBoxModelLanguageList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(boxModelLanguageList[1].BoxModelLanguageID, ((List<BoxModelLanguage>)ret2.Value)[0].BoxModelLanguageID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<BoxModelLanguage>)ret2.Value).Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void BoxModelLanguage_Controller_GetBoxModelLanguageWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    BoxModelLanguageController boxModelLanguageController = new BoxModelLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(boxModelLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, boxModelLanguageController.DatabaseType);

                    BoxModelLanguage boxModelLanguageFirst = new BoxModelLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        BoxModelLanguageService boxModelLanguageService = new BoxModelLanguageService(new Query(), db, ContactID);
                        boxModelLanguageFirst = (from c in db.BoxModelLanguages select c).FirstOrDefault();
                    }

                    // ok with BoxModelLanguage info
                    IActionResult jsonRet = boxModelLanguageController.GetBoxModelLanguageWithID(boxModelLanguageFirst.BoxModelLanguageID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(boxModelLanguageFirst.BoxModelLanguageID, ((BoxModelLanguage)ret.Value).BoxModelLanguageID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = boxModelLanguageController.GetBoxModelLanguageWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult boxModelLanguageRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(boxModelLanguageRet2);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void BoxModelLanguage_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    BoxModelLanguageController boxModelLanguageController = new BoxModelLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(boxModelLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, boxModelLanguageController.DatabaseType);

                    BoxModelLanguage boxModelLanguageFirst = new BoxModelLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        BoxModelLanguageService boxModelLanguageService = new BoxModelLanguageService(query, db, ContactID);
                        boxModelLanguageFirst = (from c in db.BoxModelLanguages select c).FirstOrDefault();
                    }

                    // ok with BoxModelLanguage info
                    IActionResult jsonRet = boxModelLanguageController.GetBoxModelLanguageWithID(boxModelLanguageFirst.BoxModelLanguageID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    BoxModelLanguage boxModelLanguageRet = (BoxModelLanguage)ret.Value;
                    Assert.Equal(boxModelLanguageFirst.BoxModelLanguageID, boxModelLanguageRet.BoxModelLanguageID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because BoxModelLanguageID exist
                    IActionResult jsonRet2 = boxModelLanguageController.Post(boxModelLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added BoxModelLanguage
                    boxModelLanguageRet.BoxModelLanguageID = 0;
                    IActionResult jsonRet3 = boxModelLanguageController.Post(boxModelLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = boxModelLanguageController.Delete(boxModelLanguageRet, LanguageRequest.ToString());
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
        public void BoxModelLanguage_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    BoxModelLanguageController boxModelLanguageController = new BoxModelLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(boxModelLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, boxModelLanguageController.DatabaseType);

                    BoxModelLanguage boxModelLanguageFirst = new BoxModelLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        BoxModelLanguageService boxModelLanguageService = new BoxModelLanguageService(query, db, ContactID);
                        boxModelLanguageFirst = (from c in db.BoxModelLanguages select c).FirstOrDefault();
                    }

                    // ok with BoxModelLanguage info
                    IActionResult jsonRet = boxModelLanguageController.GetBoxModelLanguageWithID(boxModelLanguageFirst.BoxModelLanguageID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    BoxModelLanguage boxModelLanguageRet = (BoxModelLanguage)Ret.Value;
                    Assert.Equal(boxModelLanguageFirst.BoxModelLanguageID, boxModelLanguageRet.BoxModelLanguageID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = boxModelLanguageController.Put(boxModelLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult boxModelLanguageRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(boxModelLanguageRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because BoxModelLanguageID of 0 does not exist
                    boxModelLanguageRet.BoxModelLanguageID = 0;
                    IActionResult jsonRet3 = boxModelLanguageController.Put(boxModelLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult boxModelLanguageRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(boxModelLanguageRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void BoxModelLanguage_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    BoxModelLanguageController boxModelLanguageController = new BoxModelLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(boxModelLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, boxModelLanguageController.DatabaseType);

                    BoxModelLanguage boxModelLanguageFirst = new BoxModelLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        BoxModelLanguageService boxModelLanguageService = new BoxModelLanguageService(query, db, ContactID);
                        boxModelLanguageFirst = (from c in db.BoxModelLanguages select c).FirstOrDefault();
                    }

                    // ok with BoxModelLanguage info
                    IActionResult jsonRet = boxModelLanguageController.GetBoxModelLanguageWithID(boxModelLanguageFirst.BoxModelLanguageID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    BoxModelLanguage boxModelLanguageRet = (BoxModelLanguage)Ret.Value;
                    Assert.Equal(boxModelLanguageFirst.BoxModelLanguageID, boxModelLanguageRet.BoxModelLanguageID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added BoxModelLanguage
                    boxModelLanguageRet.BoxModelLanguageID = 0;
                    IActionResult jsonRet3 = boxModelLanguageController.Post(boxModelLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    BoxModelLanguage boxModelLanguage = (BoxModelLanguage)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = boxModelLanguageController.Delete(boxModelLanguageRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because BoxModelLanguageID of 0 does not exist
                    boxModelLanguageRet.BoxModelLanguageID = 0;
                    IActionResult jsonRet4 = boxModelLanguageController.Delete(boxModelLanguageRet, LanguageRequest.ToString());
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
