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
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(climateDataValueFirst.ClimateDataValueID, ((List<ClimateDataValue>)ret.Value)[0].ClimateDataValueID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<ClimateDataValue>)ret.Value).Count);

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
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(climateDataValueList[0].ClimateDataValueID, ((List<ClimateDataValue>)ret.Value)[0].ClimateDataValueID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<ClimateDataValue>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with ClimateDataValue info
                           IActionResult jsonRet2 = climateDataValueController.GetClimateDataValueList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(climateDataValueList[1].ClimateDataValueID, ((List<ClimateDataValue>)ret2.Value)[0].ClimateDataValueID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<ClimateDataValue>)ret2.Value).Count);
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
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(climateDataValueFirst.ClimateDataValueID, ((ClimateDataValue)ret.Value).ClimateDataValueID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = climateDataValueController.GetClimateDataValueWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult climateDataValueRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(climateDataValueRet2);
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
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    ClimateDataValue climateDataValueRet = (ClimateDataValue)ret.Value;
                    Assert.Equal(climateDataValueLast.ClimateDataValueID, climateDataValueRet.ClimateDataValueID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because ClimateDataValueID exist
                    IActionResult jsonRet2 = climateDataValueController.Post(climateDataValueRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added ClimateDataValue
                    climateDataValueRet.ClimateDataValueID = 0;
                    IActionResult jsonRet3 = climateDataValueController.Post(climateDataValueRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = climateDataValueController.Delete(climateDataValueRet, LanguageRequest.ToString());
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
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    ClimateDataValue climateDataValueRet = (ClimateDataValue)Ret.Value;
                    Assert.Equal(climateDataValueLast.ClimateDataValueID, climateDataValueRet.ClimateDataValueID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = climateDataValueController.Put(climateDataValueRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult climateDataValueRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(climateDataValueRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because ClimateDataValueID of 0 does not exist
                    climateDataValueRet.ClimateDataValueID = 0;
                    IActionResult jsonRet3 = climateDataValueController.Put(climateDataValueRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult climateDataValueRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(climateDataValueRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
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
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    ClimateDataValue climateDataValueRet = (ClimateDataValue)Ret.Value;
                    Assert.Equal(climateDataValueLast.ClimateDataValueID, climateDataValueRet.ClimateDataValueID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added ClimateDataValue
                    climateDataValueRet.ClimateDataValueID = 0;
                    IActionResult jsonRet3 = climateDataValueController.Post(climateDataValueRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    ClimateDataValue climateDataValue = (ClimateDataValue)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = climateDataValueController.Delete(climateDataValueRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because ClimateDataValueID of 0 does not exist
                    climateDataValueRet.ClimateDataValueID = 0;
                    IActionResult jsonRet4 = climateDataValueController.Delete(climateDataValueRet, LanguageRequest.ToString());
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
