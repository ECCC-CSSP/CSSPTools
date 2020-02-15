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
    public partial class TideDataValueControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TideDataValueControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void TideDataValue_Controller_GetTideDataValueList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TideDataValueController tideDataValueController = new TideDataValueController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tideDataValueController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tideDataValueController.DatabaseType);

                    TideDataValue tideDataValueFirst = new TideDataValue();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        TideDataValueService tideDataValueService = new TideDataValueService(query, db, ContactID);
                        tideDataValueFirst = (from c in db.TideDataValues select c).FirstOrDefault();
                        count = (from c in db.TideDataValues select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with TideDataValue info
                    IActionResult jsonRet = tideDataValueController.GetTideDataValueList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(tideDataValueFirst.TideDataValueID, ((List<TideDataValue>)ret.Value)[0].TideDataValueID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<TideDataValue>)ret.Value).Count);

                    List<TideDataValue> tideDataValueList = new List<TideDataValue>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        TideDataValueService tideDataValueService = new TideDataValueService(query, db, ContactID);
                        tideDataValueList = (from c in db.TideDataValues select c).OrderBy(c => c.TideDataValueID).Skip(0).Take(2).ToList();
                        count = (from c in db.TideDataValues select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with TideDataValue info
                        jsonRet = tideDataValueController.GetTideDataValueList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(tideDataValueList[0].TideDataValueID, ((List<TideDataValue>)ret.Value)[0].TideDataValueID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<TideDataValue>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with TideDataValue info
                           IActionResult jsonRet2 = tideDataValueController.GetTideDataValueList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(tideDataValueList[1].TideDataValueID, ((List<TideDataValue>)ret2.Value)[0].TideDataValueID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<TideDataValue>)ret2.Value).Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void TideDataValue_Controller_GetTideDataValueWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TideDataValueController tideDataValueController = new TideDataValueController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tideDataValueController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tideDataValueController.DatabaseType);

                    TideDataValue tideDataValueFirst = new TideDataValue();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        TideDataValueService tideDataValueService = new TideDataValueService(new Query(), db, ContactID);
                        tideDataValueFirst = (from c in db.TideDataValues select c).FirstOrDefault();
                    }

                    // ok with TideDataValue info
                    IActionResult jsonRet = tideDataValueController.GetTideDataValueWithID(tideDataValueFirst.TideDataValueID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(tideDataValueFirst.TideDataValueID, ((TideDataValue)ret.Value).TideDataValueID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = tideDataValueController.GetTideDataValueWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult tideDataValueRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(tideDataValueRet2);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void TideDataValue_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TideDataValueController tideDataValueController = new TideDataValueController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tideDataValueController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tideDataValueController.DatabaseType);

                    TideDataValue tideDataValueFirst = new TideDataValue();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        TideDataValueService tideDataValueService = new TideDataValueService(query, db, ContactID);
                        tideDataValueFirst = (from c in db.TideDataValues select c).FirstOrDefault();
                    }

                    // ok with TideDataValue info
                    IActionResult jsonRet = tideDataValueController.GetTideDataValueWithID(tideDataValueFirst.TideDataValueID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    TideDataValue tideDataValueRet = (TideDataValue)ret.Value;
                    Assert.Equal(tideDataValueFirst.TideDataValueID, tideDataValueRet.TideDataValueID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because TideDataValueID exist
                    IActionResult jsonRet2 = tideDataValueController.Post(tideDataValueRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added TideDataValue
                    tideDataValueRet.TideDataValueID = 0;
                    IActionResult jsonRet3 = tideDataValueController.Post(tideDataValueRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = tideDataValueController.Delete(tideDataValueRet, LanguageRequest.ToString());
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
        public void TideDataValue_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TideDataValueController tideDataValueController = new TideDataValueController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tideDataValueController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tideDataValueController.DatabaseType);

                    TideDataValue tideDataValueFirst = new TideDataValue();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        TideDataValueService tideDataValueService = new TideDataValueService(query, db, ContactID);
                        tideDataValueFirst = (from c in db.TideDataValues select c).FirstOrDefault();
                    }

                    // ok with TideDataValue info
                    IActionResult jsonRet = tideDataValueController.GetTideDataValueWithID(tideDataValueFirst.TideDataValueID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    TideDataValue tideDataValueRet = (TideDataValue)Ret.Value;
                    Assert.Equal(tideDataValueFirst.TideDataValueID, tideDataValueRet.TideDataValueID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = tideDataValueController.Put(tideDataValueRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult tideDataValueRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(tideDataValueRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because TideDataValueID of 0 does not exist
                    tideDataValueRet.TideDataValueID = 0;
                    IActionResult jsonRet3 = tideDataValueController.Put(tideDataValueRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult tideDataValueRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(tideDataValueRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void TideDataValue_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TideDataValueController tideDataValueController = new TideDataValueController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tideDataValueController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tideDataValueController.DatabaseType);

                    TideDataValue tideDataValueFirst = new TideDataValue();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        TideDataValueService tideDataValueService = new TideDataValueService(query, db, ContactID);
                        tideDataValueFirst = (from c in db.TideDataValues select c).FirstOrDefault();
                    }

                    // ok with TideDataValue info
                    IActionResult jsonRet = tideDataValueController.GetTideDataValueWithID(tideDataValueFirst.TideDataValueID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    TideDataValue tideDataValueRet = (TideDataValue)Ret.Value;
                    Assert.Equal(tideDataValueFirst.TideDataValueID, tideDataValueRet.TideDataValueID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added TideDataValue
                    tideDataValueRet.TideDataValueID = 0;
                    IActionResult jsonRet3 = tideDataValueController.Post(tideDataValueRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    TideDataValue tideDataValue = (TideDataValue)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = tideDataValueController.Delete(tideDataValueRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because TideDataValueID of 0 does not exist
                    tideDataValueRet.TideDataValueID = 0;
                    IActionResult jsonRet4 = tideDataValueController.Delete(tideDataValueRet, LanguageRequest.ToString());
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
