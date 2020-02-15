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
    public partial class BoxModelResultControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public BoxModelResultControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void BoxModelResult_Controller_GetBoxModelResultList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    BoxModelResultController boxModelResultController = new BoxModelResultController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(boxModelResultController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, boxModelResultController.DatabaseType);

                    BoxModelResult boxModelResultFirst = new BoxModelResult();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        BoxModelResultService boxModelResultService = new BoxModelResultService(query, db, ContactID);
                        boxModelResultFirst = (from c in db.BoxModelResults select c).FirstOrDefault();
                        count = (from c in db.BoxModelResults select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with BoxModelResult info
                    IActionResult jsonRet = boxModelResultController.GetBoxModelResultList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(boxModelResultFirst.BoxModelResultID, ((List<BoxModelResult>)ret.Value)[0].BoxModelResultID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<BoxModelResult>)ret.Value).Count);

                    List<BoxModelResult> boxModelResultList = new List<BoxModelResult>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        BoxModelResultService boxModelResultService = new BoxModelResultService(query, db, ContactID);
                        boxModelResultList = (from c in db.BoxModelResults select c).OrderBy(c => c.BoxModelResultID).Skip(0).Take(2).ToList();
                        count = (from c in db.BoxModelResults select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with BoxModelResult info
                        jsonRet = boxModelResultController.GetBoxModelResultList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(boxModelResultList[0].BoxModelResultID, ((List<BoxModelResult>)ret.Value)[0].BoxModelResultID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<BoxModelResult>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with BoxModelResult info
                           IActionResult jsonRet2 = boxModelResultController.GetBoxModelResultList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(boxModelResultList[1].BoxModelResultID, ((List<BoxModelResult>)ret2.Value)[0].BoxModelResultID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<BoxModelResult>)ret2.Value).Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void BoxModelResult_Controller_GetBoxModelResultWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    BoxModelResultController boxModelResultController = new BoxModelResultController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(boxModelResultController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, boxModelResultController.DatabaseType);

                    BoxModelResult boxModelResultFirst = new BoxModelResult();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        BoxModelResultService boxModelResultService = new BoxModelResultService(new Query(), db, ContactID);
                        boxModelResultFirst = (from c in db.BoxModelResults select c).FirstOrDefault();
                    }

                    // ok with BoxModelResult info
                    IActionResult jsonRet = boxModelResultController.GetBoxModelResultWithID(boxModelResultFirst.BoxModelResultID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(boxModelResultFirst.BoxModelResultID, ((BoxModelResult)ret.Value).BoxModelResultID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = boxModelResultController.GetBoxModelResultWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult boxModelResultRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(boxModelResultRet2);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void BoxModelResult_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    BoxModelResultController boxModelResultController = new BoxModelResultController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(boxModelResultController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, boxModelResultController.DatabaseType);

                    BoxModelResult boxModelResultFirst = new BoxModelResult();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        BoxModelResultService boxModelResultService = new BoxModelResultService(query, db, ContactID);
                        boxModelResultFirst = (from c in db.BoxModelResults select c).FirstOrDefault();
                    }

                    // ok with BoxModelResult info
                    IActionResult jsonRet = boxModelResultController.GetBoxModelResultWithID(boxModelResultFirst.BoxModelResultID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    BoxModelResult boxModelResultRet = (BoxModelResult)ret.Value;
                    Assert.Equal(boxModelResultFirst.BoxModelResultID, boxModelResultRet.BoxModelResultID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because BoxModelResultID exist
                    IActionResult jsonRet2 = boxModelResultController.Post(boxModelResultRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added BoxModelResult
                    boxModelResultRet.BoxModelResultID = 0;
                    IActionResult jsonRet3 = boxModelResultController.Post(boxModelResultRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = boxModelResultController.Delete(boxModelResultRet, LanguageRequest.ToString());
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
        public void BoxModelResult_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    BoxModelResultController boxModelResultController = new BoxModelResultController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(boxModelResultController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, boxModelResultController.DatabaseType);

                    BoxModelResult boxModelResultFirst = new BoxModelResult();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        BoxModelResultService boxModelResultService = new BoxModelResultService(query, db, ContactID);
                        boxModelResultFirst = (from c in db.BoxModelResults select c).FirstOrDefault();
                    }

                    // ok with BoxModelResult info
                    IActionResult jsonRet = boxModelResultController.GetBoxModelResultWithID(boxModelResultFirst.BoxModelResultID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    BoxModelResult boxModelResultRet = (BoxModelResult)Ret.Value;
                    Assert.Equal(boxModelResultFirst.BoxModelResultID, boxModelResultRet.BoxModelResultID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = boxModelResultController.Put(boxModelResultRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult boxModelResultRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(boxModelResultRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because BoxModelResultID of 0 does not exist
                    boxModelResultRet.BoxModelResultID = 0;
                    IActionResult jsonRet3 = boxModelResultController.Put(boxModelResultRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult boxModelResultRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(boxModelResultRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void BoxModelResult_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    BoxModelResultController boxModelResultController = new BoxModelResultController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(boxModelResultController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, boxModelResultController.DatabaseType);

                    BoxModelResult boxModelResultFirst = new BoxModelResult();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        BoxModelResultService boxModelResultService = new BoxModelResultService(query, db, ContactID);
                        boxModelResultFirst = (from c in db.BoxModelResults select c).FirstOrDefault();
                    }

                    // ok with BoxModelResult info
                    IActionResult jsonRet = boxModelResultController.GetBoxModelResultWithID(boxModelResultFirst.BoxModelResultID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    BoxModelResult boxModelResultRet = (BoxModelResult)Ret.Value;
                    Assert.Equal(boxModelResultFirst.BoxModelResultID, boxModelResultRet.BoxModelResultID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added BoxModelResult
                    boxModelResultRet.BoxModelResultID = 0;
                    IActionResult jsonRet3 = boxModelResultController.Post(boxModelResultRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    BoxModelResult boxModelResult = (BoxModelResult)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = boxModelResultController.Delete(boxModelResultRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because BoxModelResultID of 0 does not exist
                    boxModelResultRet.BoxModelResultID = 0;
                    IActionResult jsonRet4 = boxModelResultController.Delete(boxModelResultRet, LanguageRequest.ToString());
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
