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
    public partial class RatingCurveControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public RatingCurveControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void RatingCurve_Controller_GetRatingCurveList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    RatingCurveController ratingCurveController = new RatingCurveController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(ratingCurveController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, ratingCurveController.DatabaseType);

                    RatingCurve ratingCurveFirst = new RatingCurve();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        RatingCurveService ratingCurveService = new RatingCurveService(query, db, ContactID);
                        ratingCurveFirst = (from c in db.RatingCurves select c).FirstOrDefault();
                        count = (from c in db.RatingCurves select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with RatingCurve info
                    IActionResult jsonRet = ratingCurveController.GetRatingCurveList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(ratingCurveFirst.RatingCurveID, ((List<RatingCurve>)ret.Value)[0].RatingCurveID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<RatingCurve>)ret.Value).Count);

                    List<RatingCurve> ratingCurveList = new List<RatingCurve>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        RatingCurveService ratingCurveService = new RatingCurveService(query, db, ContactID);
                        ratingCurveList = (from c in db.RatingCurves select c).OrderBy(c => c.RatingCurveID).Skip(0).Take(2).ToList();
                        count = (from c in db.RatingCurves select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with RatingCurve info
                        jsonRet = ratingCurveController.GetRatingCurveList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(ratingCurveList[0].RatingCurveID, ((List<RatingCurve>)ret.Value)[0].RatingCurveID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<RatingCurve>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with RatingCurve info
                           IActionResult jsonRet2 = ratingCurveController.GetRatingCurveList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(ratingCurveList[1].RatingCurveID, ((List<RatingCurve>)ret2.Value)[0].RatingCurveID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<RatingCurve>)ret2.Value).Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void RatingCurve_Controller_GetRatingCurveWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    RatingCurveController ratingCurveController = new RatingCurveController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(ratingCurveController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, ratingCurveController.DatabaseType);

                    RatingCurve ratingCurveFirst = new RatingCurve();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        RatingCurveService ratingCurveService = new RatingCurveService(new Query(), db, ContactID);
                        ratingCurveFirst = (from c in db.RatingCurves select c).FirstOrDefault();
                    }

                    // ok with RatingCurve info
                    IActionResult jsonRet = ratingCurveController.GetRatingCurveWithID(ratingCurveFirst.RatingCurveID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(ratingCurveFirst.RatingCurveID, ((RatingCurve)ret.Value).RatingCurveID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = ratingCurveController.GetRatingCurveWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult ratingCurveRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ratingCurveRet2);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void RatingCurve_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    RatingCurveController ratingCurveController = new RatingCurveController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(ratingCurveController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, ratingCurveController.DatabaseType);

                    RatingCurve ratingCurveLast = new RatingCurve();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        RatingCurveService ratingCurveService = new RatingCurveService(query, db, ContactID);
                        ratingCurveLast = (from c in db.RatingCurves select c).FirstOrDefault();
                    }

                    // ok with RatingCurve info
                    IActionResult jsonRet = ratingCurveController.GetRatingCurveWithID(ratingCurveLast.RatingCurveID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    RatingCurve ratingCurveRet = (RatingCurve)ret.Value;
                    Assert.Equal(ratingCurveLast.RatingCurveID, ratingCurveRet.RatingCurveID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because RatingCurveID exist
                    IActionResult jsonRet2 = ratingCurveController.Post(ratingCurveRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added RatingCurve
                    ratingCurveRet.RatingCurveID = 0;
                    IActionResult jsonRet3 = ratingCurveController.Post(ratingCurveRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = ratingCurveController.Delete(ratingCurveRet, LanguageRequest.ToString());
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
        public void RatingCurve_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    RatingCurveController ratingCurveController = new RatingCurveController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(ratingCurveController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, ratingCurveController.DatabaseType);

                    RatingCurve ratingCurveLast = new RatingCurve();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        RatingCurveService ratingCurveService = new RatingCurveService(query, db, ContactID);
                        ratingCurveLast = (from c in db.RatingCurves select c).FirstOrDefault();
                    }

                    // ok with RatingCurve info
                    IActionResult jsonRet = ratingCurveController.GetRatingCurveWithID(ratingCurveLast.RatingCurveID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    RatingCurve ratingCurveRet = (RatingCurve)Ret.Value;
                    Assert.Equal(ratingCurveLast.RatingCurveID, ratingCurveRet.RatingCurveID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = ratingCurveController.Put(ratingCurveRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ratingCurveRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ratingCurveRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because RatingCurveID of 0 does not exist
                    ratingCurveRet.RatingCurveID = 0;
                    IActionResult jsonRet3 = ratingCurveController.Put(ratingCurveRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult ratingCurveRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(ratingCurveRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void RatingCurve_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    RatingCurveController ratingCurveController = new RatingCurveController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(ratingCurveController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, ratingCurveController.DatabaseType);

                    RatingCurve ratingCurveLast = new RatingCurve();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        RatingCurveService ratingCurveService = new RatingCurveService(query, db, ContactID);
                        ratingCurveLast = (from c in db.RatingCurves select c).FirstOrDefault();
                    }

                    // ok with RatingCurve info
                    IActionResult jsonRet = ratingCurveController.GetRatingCurveWithID(ratingCurveLast.RatingCurveID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    RatingCurve ratingCurveRet = (RatingCurve)Ret.Value;
                    Assert.Equal(ratingCurveLast.RatingCurveID, ratingCurveRet.RatingCurveID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added RatingCurve
                    ratingCurveRet.RatingCurveID = 0;
                    IActionResult jsonRet3 = ratingCurveController.Post(ratingCurveRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    RatingCurve ratingCurve = (RatingCurve)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = ratingCurveController.Delete(ratingCurveRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because RatingCurveID of 0 does not exist
                    ratingCurveRet.RatingCurveID = 0;
                    IActionResult jsonRet4 = ratingCurveController.Delete(ratingCurveRet, LanguageRequest.ToString());
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
