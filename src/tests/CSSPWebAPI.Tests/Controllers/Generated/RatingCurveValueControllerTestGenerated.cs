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
    public partial class RatingCurveValueControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public RatingCurveValueControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void RatingCurveValue_Controller_GetRatingCurveValueList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    RatingCurveValueController ratingCurveValueController = new RatingCurveValueController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(ratingCurveValueController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, ratingCurveValueController.DatabaseType);

                    RatingCurveValue ratingCurveValueFirst = new RatingCurveValue();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        RatingCurveValueService ratingCurveValueService = new RatingCurveValueService(query, db, ContactID);
                        ratingCurveValueFirst = (from c in db.RatingCurveValues select c).FirstOrDefault();
                        count = (from c in db.RatingCurveValues select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with RatingCurveValue info
                    IActionResult jsonRet = ratingCurveValueController.GetRatingCurveValueList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(ratingCurveValueFirst.RatingCurveValueID, ((List<RatingCurveValue>)ret.Value)[0].RatingCurveValueID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<RatingCurveValue>)ret.Value).Count);

                    List<RatingCurveValue> ratingCurveValueList = new List<RatingCurveValue>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        RatingCurveValueService ratingCurveValueService = new RatingCurveValueService(query, db, ContactID);
                        ratingCurveValueList = (from c in db.RatingCurveValues select c).OrderBy(c => c.RatingCurveValueID).Skip(0).Take(2).ToList();
                        count = (from c in db.RatingCurveValues select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with RatingCurveValue info
                        jsonRet = ratingCurveValueController.GetRatingCurveValueList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(ratingCurveValueList[0].RatingCurveValueID, ((List<RatingCurveValue>)ret.Value)[0].RatingCurveValueID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<RatingCurveValue>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with RatingCurveValue info
                           IActionResult jsonRet2 = ratingCurveValueController.GetRatingCurveValueList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(ratingCurveValueList[1].RatingCurveValueID, ((List<RatingCurveValue>)ret2.Value)[0].RatingCurveValueID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<RatingCurveValue>)ret2.Value).Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void RatingCurveValue_Controller_GetRatingCurveValueWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    RatingCurveValueController ratingCurveValueController = new RatingCurveValueController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(ratingCurveValueController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, ratingCurveValueController.DatabaseType);

                    RatingCurveValue ratingCurveValueFirst = new RatingCurveValue();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        RatingCurveValueService ratingCurveValueService = new RatingCurveValueService(new Query(), db, ContactID);
                        ratingCurveValueFirst = (from c in db.RatingCurveValues select c).FirstOrDefault();
                    }

                    // ok with RatingCurveValue info
                    IActionResult jsonRet = ratingCurveValueController.GetRatingCurveValueWithID(ratingCurveValueFirst.RatingCurveValueID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(ratingCurveValueFirst.RatingCurveValueID, ((RatingCurveValue)ret.Value).RatingCurveValueID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = ratingCurveValueController.GetRatingCurveValueWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult ratingCurveValueRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ratingCurveValueRet2);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void RatingCurveValue_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    RatingCurveValueController ratingCurveValueController = new RatingCurveValueController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(ratingCurveValueController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, ratingCurveValueController.DatabaseType);

                    RatingCurveValue ratingCurveValueLast = new RatingCurveValue();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        RatingCurveValueService ratingCurveValueService = new RatingCurveValueService(query, db, ContactID);
                        ratingCurveValueLast = (from c in db.RatingCurveValues select c).FirstOrDefault();
                    }

                    // ok with RatingCurveValue info
                    IActionResult jsonRet = ratingCurveValueController.GetRatingCurveValueWithID(ratingCurveValueLast.RatingCurveValueID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    RatingCurveValue ratingCurveValueRet = (RatingCurveValue)ret.Value;
                    Assert.Equal(ratingCurveValueLast.RatingCurveValueID, ratingCurveValueRet.RatingCurveValueID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because RatingCurveValueID exist
                    IActionResult jsonRet2 = ratingCurveValueController.Post(ratingCurveValueRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added RatingCurveValue
                    ratingCurveValueRet.RatingCurveValueID = 0;
                    IActionResult jsonRet3 = ratingCurveValueController.Post(ratingCurveValueRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = ratingCurveValueController.Delete(ratingCurveValueRet, LanguageRequest.ToString());
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
        public void RatingCurveValue_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    RatingCurveValueController ratingCurveValueController = new RatingCurveValueController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(ratingCurveValueController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, ratingCurveValueController.DatabaseType);

                    RatingCurveValue ratingCurveValueLast = new RatingCurveValue();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        RatingCurveValueService ratingCurveValueService = new RatingCurveValueService(query, db, ContactID);
                        ratingCurveValueLast = (from c in db.RatingCurveValues select c).FirstOrDefault();
                    }

                    // ok with RatingCurveValue info
                    IActionResult jsonRet = ratingCurveValueController.GetRatingCurveValueWithID(ratingCurveValueLast.RatingCurveValueID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    RatingCurveValue ratingCurveValueRet = (RatingCurveValue)Ret.Value;
                    Assert.Equal(ratingCurveValueLast.RatingCurveValueID, ratingCurveValueRet.RatingCurveValueID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = ratingCurveValueController.Put(ratingCurveValueRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ratingCurveValueRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ratingCurveValueRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because RatingCurveValueID of 0 does not exist
                    ratingCurveValueRet.RatingCurveValueID = 0;
                    IActionResult jsonRet3 = ratingCurveValueController.Put(ratingCurveValueRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult ratingCurveValueRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(ratingCurveValueRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void RatingCurveValue_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    RatingCurveValueController ratingCurveValueController = new RatingCurveValueController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(ratingCurveValueController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, ratingCurveValueController.DatabaseType);

                    RatingCurveValue ratingCurveValueLast = new RatingCurveValue();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        RatingCurveValueService ratingCurveValueService = new RatingCurveValueService(query, db, ContactID);
                        ratingCurveValueLast = (from c in db.RatingCurveValues select c).FirstOrDefault();
                    }

                    // ok with RatingCurveValue info
                    IActionResult jsonRet = ratingCurveValueController.GetRatingCurveValueWithID(ratingCurveValueLast.RatingCurveValueID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    RatingCurveValue ratingCurveValueRet = (RatingCurveValue)Ret.Value;
                    Assert.Equal(ratingCurveValueLast.RatingCurveValueID, ratingCurveValueRet.RatingCurveValueID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added RatingCurveValue
                    ratingCurveValueRet.RatingCurveValueID = 0;
                    IActionResult jsonRet3 = ratingCurveValueController.Post(ratingCurveValueRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    RatingCurveValue ratingCurveValue = (RatingCurveValue)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = ratingCurveValueController.Delete(ratingCurveValueRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because RatingCurveValueID of 0 does not exist
                    ratingCurveValueRet.RatingCurveValueID = 0;
                    IActionResult jsonRet4 = ratingCurveValueController.Delete(ratingCurveValueRet, LanguageRequest.ToString());
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
