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
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<List<RatingCurve>> ret = jsonRet as OkNegotiatedContentResult<List<RatingCurve>>;
                    Assert.Equal(ratingCurveFirst.RatingCurveID, ret.Content[0].RatingCurveID);
                    Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

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
                        Assert.NotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<RatingCurve>>;
                        Assert.Equal(ratingCurveList[0].RatingCurveID, ret.Content[0].RatingCurveID);
                        Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with RatingCurve info
                           IActionResult jsonRet2 = ratingCurveController.GetRatingCurveList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkNegotiatedContentResult<List<RatingCurve>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<RatingCurve>>;
                           Assert.Equal(ratingCurveList[1].RatingCurveID, ret2.Content[0].RatingCurveID);
                           Assert.Equal((count > query.Take ? query.Take : count), ret2.Content.Count);
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
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<RatingCurve> Ret = jsonRet as OkNegotiatedContentResult<RatingCurve>;
                    RatingCurve ratingCurveRet = Ret.Content;
                    Assert.Equal(ratingCurveFirst.RatingCurveID, ratingCurveRet.RatingCurveID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = ratingCurveController.GetRatingCurveWithID(0);
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<RatingCurve> ratingCurveRet2 = jsonRet2 as OkNegotiatedContentResult<RatingCurve>;
                    Assert.Null(ratingCurveRet2);

                    NotFoundObjectResult notFoundRequest = jsonRet2 as NotFoundObjectResult;
                    Assert.NotNull(notFoundRequest);
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
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<RatingCurve> Ret = jsonRet as OkNegotiatedContentResult<RatingCurve>;
                    RatingCurve ratingCurveRet = Ret.Content;
                    Assert.Equal(ratingCurveLast.RatingCurveID, ratingCurveRet.RatingCurveID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because RatingCurveID exist
                    IActionResult jsonRet2 = ratingCurveController.Post(ratingCurveRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<RatingCurve> ratingCurveRet2 = jsonRet2 as OkNegotiatedContentResult<RatingCurve>;
                    Assert.Null(ratingCurveRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added RatingCurve
                    ratingCurveRet.RatingCurveID = 0;
                    ratingCurveController.Request = new System.Net.Http.HttpRequestMessage();
                    ratingCurveController.Request.RequestUri = new System.Uri("http://localhost:5000/api/ratingCurve");
                    IActionResult jsonRet3 = ratingCurveController.Post(ratingCurveRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<RatingCurve> ratingCurveRet3 = jsonRet3 as CreatedNegotiatedContentResult<RatingCurve>;
                    Assert.NotNull(ratingCurveRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = ratingCurveController.Delete(ratingCurveRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<RatingCurve> ratingCurveRet4 = jsonRet4 as OkNegotiatedContentResult<RatingCurve>;
                    Assert.NotNull(ratingCurveRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
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
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<RatingCurve> Ret = jsonRet as OkNegotiatedContentResult<RatingCurve>;
                    RatingCurve ratingCurveRet = Ret.Content;
                    Assert.Equal(ratingCurveLast.RatingCurveID, ratingCurveRet.RatingCurveID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = ratingCurveController.Put(ratingCurveRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<RatingCurve> ratingCurveRet2 = jsonRet2 as OkNegotiatedContentResult<RatingCurve>;
                    Assert.NotNull(ratingCurveRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because RatingCurveID of 0 does not exist
                    ratingCurveRet.RatingCurveID = 0;
                    IActionResult jsonRet3 = ratingCurveController.Put(ratingCurveRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    OkNegotiatedContentResult<RatingCurve> ratingCurveRet3 = jsonRet3 as OkNegotiatedContentResult<RatingCurve>;
                    Assert.Null(ratingCurveRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
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
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<RatingCurve> Ret = jsonRet as OkNegotiatedContentResult<RatingCurve>;
                    RatingCurve ratingCurveRet = Ret.Content;
                    Assert.Equal(ratingCurveLast.RatingCurveID, ratingCurveRet.RatingCurveID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return newly added RatingCurve
                    ratingCurveRet.RatingCurveID = 0;
                    ratingCurveController.Request = new System.Net.Http.HttpRequestMessage();
                    ratingCurveController.Request.RequestUri = new System.Uri("http://localhost:5000/api/ratingCurve");
                    IActionResult jsonRet3 = ratingCurveController.Post(ratingCurveRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<RatingCurve> ratingCurveRet3 = jsonRet3 as CreatedNegotiatedContentResult<RatingCurve>;
                    Assert.NotNull(ratingCurveRet3);
                    RatingCurve ratingCurve = ratingCurveRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = ratingCurveController.Delete(ratingCurveRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<RatingCurve> ratingCurveRet2 = jsonRet2 as OkNegotiatedContentResult<RatingCurve>;
                    Assert.NotNull(ratingCurveRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because RatingCurveID of 0 does not exist
                    ratingCurveRet.RatingCurveID = 0;
                    IActionResult jsonRet4 = ratingCurveController.Delete(ratingCurveRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<RatingCurve> ratingCurveRet4 = jsonRet4 as OkNegotiatedContentResult<RatingCurve>;
                    Assert.Null(ratingCurveRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
