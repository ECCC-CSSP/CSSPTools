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
    public partial class ClimateDataValueControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ClimateDataValueControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void ClimateDataValue_Controller_GetClimateDataValueList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ClimateDataValueController climateDataValueController = new ClimateDataValueController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(climateDataValueController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, climateDataValueController.DatabaseType);

                    ClimateDataValue climateDataValueFirst = new ClimateDataValue();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        ClimateDataValueService climateDataValueService = new ClimateDataValueService(query, db, ContactID);
                        climateDataValueFirst = (from c in db.ClimateDataValues select c).FirstOrDefault();
                        count = (from c in db.ClimateDataValues select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with ClimateDataValue info
                    IActionResult jsonRet = climateDataValueController.GetClimateDataValueList();
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<List<ClimateDataValue>> ret = jsonRet as OkNegotiatedContentResult<List<ClimateDataValue>>;
                    Assert.Equal(climateDataValueFirst.ClimateDataValueID, ret.Content[0].ClimateDataValueID);
                    Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<ClimateDataValue> climateDataValueList = new List<ClimateDataValue>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        ClimateDataValueService climateDataValueService = new ClimateDataValueService(query, db, ContactID);
                        climateDataValueList = (from c in db.ClimateDataValues select c).OrderBy(c => c.ClimateDataValueID).Skip(0).Take(2).ToList();
                        count = (from c in db.ClimateDataValues select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with ClimateDataValue info
                        jsonRet = climateDataValueController.GetClimateDataValueList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.NotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<ClimateDataValue>>;
                        Assert.Equal(climateDataValueList[0].ClimateDataValueID, ret.Content[0].ClimateDataValueID);
                        Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with ClimateDataValue info
                           IActionResult jsonRet2 = climateDataValueController.GetClimateDataValueList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkNegotiatedContentResult<List<ClimateDataValue>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<ClimateDataValue>>;
                           Assert.Equal(climateDataValueList[1].ClimateDataValueID, ret2.Content[0].ClimateDataValueID);
                           Assert.Equal((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void ClimateDataValue_Controller_GetClimateDataValueWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ClimateDataValueController climateDataValueController = new ClimateDataValueController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(climateDataValueController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, climateDataValueController.DatabaseType);

                    ClimateDataValue climateDataValueFirst = new ClimateDataValue();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        ClimateDataValueService climateDataValueService = new ClimateDataValueService(new Query(), db, ContactID);
                        climateDataValueFirst = (from c in db.ClimateDataValues select c).FirstOrDefault();
                    }

                    // ok with ClimateDataValue info
                    IActionResult jsonRet = climateDataValueController.GetClimateDataValueWithID(climateDataValueFirst.ClimateDataValueID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<ClimateDataValue> Ret = jsonRet as OkNegotiatedContentResult<ClimateDataValue>;
                    ClimateDataValue climateDataValueRet = Ret.Content;
                    Assert.Equal(climateDataValueFirst.ClimateDataValueID, climateDataValueRet.ClimateDataValueID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = climateDataValueController.GetClimateDataValueWithID(0);
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<ClimateDataValue> climateDataValueRet2 = jsonRet2 as OkNegotiatedContentResult<ClimateDataValue>;
                    Assert.Null(climateDataValueRet2);

                    NotFoundObjectResult notFoundRequest = jsonRet2 as NotFoundObjectResult;
                    Assert.NotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void ClimateDataValue_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ClimateDataValueController climateDataValueController = new ClimateDataValueController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(climateDataValueController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, climateDataValueController.DatabaseType);

                    ClimateDataValue climateDataValueLast = new ClimateDataValue();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        ClimateDataValueService climateDataValueService = new ClimateDataValueService(query, db, ContactID);
                        climateDataValueLast = (from c in db.ClimateDataValues select c).FirstOrDefault();
                    }

                    // ok with ClimateDataValue info
                    IActionResult jsonRet = climateDataValueController.GetClimateDataValueWithID(climateDataValueLast.ClimateDataValueID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<ClimateDataValue> Ret = jsonRet as OkNegotiatedContentResult<ClimateDataValue>;
                    ClimateDataValue climateDataValueRet = Ret.Content;
                    Assert.Equal(climateDataValueLast.ClimateDataValueID, climateDataValueRet.ClimateDataValueID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because ClimateDataValueID exist
                    IActionResult jsonRet2 = climateDataValueController.Post(climateDataValueRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<ClimateDataValue> climateDataValueRet2 = jsonRet2 as OkNegotiatedContentResult<ClimateDataValue>;
                    Assert.Null(climateDataValueRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added ClimateDataValue
                    climateDataValueRet.ClimateDataValueID = 0;
                    climateDataValueController.Request = new System.Net.Http.HttpRequestMessage();
                    climateDataValueController.Request.RequestUri = new System.Uri("http://localhost:5000/api/climateDataValue");
                    IActionResult jsonRet3 = climateDataValueController.Post(climateDataValueRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<ClimateDataValue> climateDataValueRet3 = jsonRet3 as CreatedNegotiatedContentResult<ClimateDataValue>;
                    Assert.NotNull(climateDataValueRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = climateDataValueController.Delete(climateDataValueRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<ClimateDataValue> climateDataValueRet4 = jsonRet4 as OkNegotiatedContentResult<ClimateDataValue>;
                    Assert.NotNull(climateDataValueRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [Fact]
        public void ClimateDataValue_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ClimateDataValueController climateDataValueController = new ClimateDataValueController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(climateDataValueController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, climateDataValueController.DatabaseType);

                    ClimateDataValue climateDataValueLast = new ClimateDataValue();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        ClimateDataValueService climateDataValueService = new ClimateDataValueService(query, db, ContactID);
                        climateDataValueLast = (from c in db.ClimateDataValues select c).FirstOrDefault();
                    }

                    // ok with ClimateDataValue info
                    IActionResult jsonRet = climateDataValueController.GetClimateDataValueWithID(climateDataValueLast.ClimateDataValueID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<ClimateDataValue> Ret = jsonRet as OkNegotiatedContentResult<ClimateDataValue>;
                    ClimateDataValue climateDataValueRet = Ret.Content;
                    Assert.Equal(climateDataValueLast.ClimateDataValueID, climateDataValueRet.ClimateDataValueID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = climateDataValueController.Put(climateDataValueRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<ClimateDataValue> climateDataValueRet2 = jsonRet2 as OkNegotiatedContentResult<ClimateDataValue>;
                    Assert.NotNull(climateDataValueRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because ClimateDataValueID of 0 does not exist
                    climateDataValueRet.ClimateDataValueID = 0;
                    IActionResult jsonRet3 = climateDataValueController.Put(climateDataValueRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    OkNegotiatedContentResult<ClimateDataValue> climateDataValueRet3 = jsonRet3 as OkNegotiatedContentResult<ClimateDataValue>;
                    Assert.Null(climateDataValueRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void ClimateDataValue_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ClimateDataValueController climateDataValueController = new ClimateDataValueController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(climateDataValueController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, climateDataValueController.DatabaseType);

                    ClimateDataValue climateDataValueLast = new ClimateDataValue();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        ClimateDataValueService climateDataValueService = new ClimateDataValueService(query, db, ContactID);
                        climateDataValueLast = (from c in db.ClimateDataValues select c).FirstOrDefault();
                    }

                    // ok with ClimateDataValue info
                    IActionResult jsonRet = climateDataValueController.GetClimateDataValueWithID(climateDataValueLast.ClimateDataValueID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<ClimateDataValue> Ret = jsonRet as OkNegotiatedContentResult<ClimateDataValue>;
                    ClimateDataValue climateDataValueRet = Ret.Content;
                    Assert.Equal(climateDataValueLast.ClimateDataValueID, climateDataValueRet.ClimateDataValueID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return newly added ClimateDataValue
                    climateDataValueRet.ClimateDataValueID = 0;
                    climateDataValueController.Request = new System.Net.Http.HttpRequestMessage();
                    climateDataValueController.Request.RequestUri = new System.Uri("http://localhost:5000/api/climateDataValue");
                    IActionResult jsonRet3 = climateDataValueController.Post(climateDataValueRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<ClimateDataValue> climateDataValueRet3 = jsonRet3 as CreatedNegotiatedContentResult<ClimateDataValue>;
                    Assert.NotNull(climateDataValueRet3);
                    ClimateDataValue climateDataValue = climateDataValueRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = climateDataValueController.Delete(climateDataValueRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<ClimateDataValue> climateDataValueRet2 = jsonRet2 as OkNegotiatedContentResult<ClimateDataValue>;
                    Assert.NotNull(climateDataValueRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because ClimateDataValueID of 0 does not exist
                    climateDataValueRet.ClimateDataValueID = 0;
                    IActionResult jsonRet4 = climateDataValueController.Delete(climateDataValueRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<ClimateDataValue> climateDataValueRet4 = jsonRet4 as OkNegotiatedContentResult<ClimateDataValue>;
                    Assert.Null(climateDataValueRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
