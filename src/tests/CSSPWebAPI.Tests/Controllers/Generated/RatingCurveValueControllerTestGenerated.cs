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
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<List<RatingCurveValue>> ret = jsonRet as OkNegotiatedContentResult<List<RatingCurveValue>>;
                    Assert.Equal(ratingCurveValueFirst.RatingCurveValueID, ret.Content[0].RatingCurveValueID);
                    Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

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
                        Assert.NotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<RatingCurveValue>>;
                        Assert.Equal(ratingCurveValueList[0].RatingCurveValueID, ret.Content[0].RatingCurveValueID);
                        Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with RatingCurveValue info
                           IActionResult jsonRet2 = ratingCurveValueController.GetRatingCurveValueList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkNegotiatedContentResult<List<RatingCurveValue>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<RatingCurveValue>>;
                           Assert.Equal(ratingCurveValueList[1].RatingCurveValueID, ret2.Content[0].RatingCurveValueID);
                           Assert.Equal((count > query.Take ? query.Take : count), ret2.Content.Count);
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
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<RatingCurveValue> Ret = jsonRet as OkNegotiatedContentResult<RatingCurveValue>;
                    RatingCurveValue ratingCurveValueRet = Ret.Content;
                    Assert.Equal(ratingCurveValueFirst.RatingCurveValueID, ratingCurveValueRet.RatingCurveValueID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = ratingCurveValueController.GetRatingCurveValueWithID(0);
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<RatingCurveValue> ratingCurveValueRet2 = jsonRet2 as OkNegotiatedContentResult<RatingCurveValue>;
                    Assert.Null(ratingCurveValueRet2);

                    NotFoundObjectResult notFoundRequest = jsonRet2 as NotFoundObjectResult;
                    Assert.NotNull(notFoundRequest);
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
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<RatingCurveValue> Ret = jsonRet as OkNegotiatedContentResult<RatingCurveValue>;
                    RatingCurveValue ratingCurveValueRet = Ret.Content;
                    Assert.Equal(ratingCurveValueLast.RatingCurveValueID, ratingCurveValueRet.RatingCurveValueID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because RatingCurveValueID exist
                    IActionResult jsonRet2 = ratingCurveValueController.Post(ratingCurveValueRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<RatingCurveValue> ratingCurveValueRet2 = jsonRet2 as OkNegotiatedContentResult<RatingCurveValue>;
                    Assert.Null(ratingCurveValueRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added RatingCurveValue
                    ratingCurveValueRet.RatingCurveValueID = 0;
                    IActionResult jsonRet3 = ratingCurveValueController.Post(ratingCurveValueRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<RatingCurveValue> ratingCurveValueRet3 = jsonRet3 as CreatedNegotiatedContentResult<RatingCurveValue>;
                    Assert.NotNull(ratingCurveValueRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = ratingCurveValueController.Delete(ratingCurveValueRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<RatingCurveValue> ratingCurveValueRet4 = jsonRet4 as OkNegotiatedContentResult<RatingCurveValue>;
                    Assert.NotNull(ratingCurveValueRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
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
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<RatingCurveValue> Ret = jsonRet as OkNegotiatedContentResult<RatingCurveValue>;
                    RatingCurveValue ratingCurveValueRet = Ret.Content;
                    Assert.Equal(ratingCurveValueLast.RatingCurveValueID, ratingCurveValueRet.RatingCurveValueID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = ratingCurveValueController.Put(ratingCurveValueRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<RatingCurveValue> ratingCurveValueRet2 = jsonRet2 as OkNegotiatedContentResult<RatingCurveValue>;
                    Assert.NotNull(ratingCurveValueRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because RatingCurveValueID of 0 does not exist
                    ratingCurveValueRet.RatingCurveValueID = 0;
                    IActionResult jsonRet3 = ratingCurveValueController.Put(ratingCurveValueRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    OkNegotiatedContentResult<RatingCurveValue> ratingCurveValueRet3 = jsonRet3 as OkNegotiatedContentResult<RatingCurveValue>;
                    Assert.Null(ratingCurveValueRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
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
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<RatingCurveValue> Ret = jsonRet as OkNegotiatedContentResult<RatingCurveValue>;
                    RatingCurveValue ratingCurveValueRet = Ret.Content;
                    Assert.Equal(ratingCurveValueLast.RatingCurveValueID, ratingCurveValueRet.RatingCurveValueID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return newly added RatingCurveValue
                    ratingCurveValueRet.RatingCurveValueID = 0;
                    IActionResult jsonRet3 = ratingCurveValueController.Post(ratingCurveValueRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<RatingCurveValue> ratingCurveValueRet3 = jsonRet3 as CreatedNegotiatedContentResult<RatingCurveValue>;
                    Assert.NotNull(ratingCurveValueRet3);
                    RatingCurveValue ratingCurveValue = ratingCurveValueRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = ratingCurveValueController.Delete(ratingCurveValueRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<RatingCurveValue> ratingCurveValueRet2 = jsonRet2 as OkNegotiatedContentResult<RatingCurveValue>;
                    Assert.NotNull(ratingCurveValueRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because RatingCurveValueID of 0 does not exist
                    ratingCurveValueRet.RatingCurveValueID = 0;
                    IActionResult jsonRet4 = ratingCurveValueController.Delete(ratingCurveValueRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<RatingCurveValue> ratingCurveValueRet4 = jsonRet4 as OkNegotiatedContentResult<RatingCurveValue>;
                    Assert.Null(ratingCurveValueRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
