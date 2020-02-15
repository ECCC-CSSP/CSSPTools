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
    public partial class HydrometricDataValueControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public HydrometricDataValueControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void HydrometricDataValue_Controller_GetHydrometricDataValueList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    HydrometricDataValueController hydrometricDataValueController = new HydrometricDataValueController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(hydrometricDataValueController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, hydrometricDataValueController.DatabaseType);

                    HydrometricDataValue hydrometricDataValueFirst = new HydrometricDataValue();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        HydrometricDataValueService hydrometricDataValueService = new HydrometricDataValueService(query, db, ContactID);
                        hydrometricDataValueFirst = (from c in db.HydrometricDataValues select c).FirstOrDefault();
                        count = (from c in db.HydrometricDataValues select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with HydrometricDataValue info
                    IActionResult jsonRet = hydrometricDataValueController.GetHydrometricDataValueList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(hydrometricDataValueFirst.HydrometricDataValueID, ((List<HydrometricDataValue>)ret.Value)[0].HydrometricDataValueID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<HydrometricDataValue>)ret.Value).Count);

                    List<HydrometricDataValue> hydrometricDataValueList = new List<HydrometricDataValue>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        HydrometricDataValueService hydrometricDataValueService = new HydrometricDataValueService(query, db, ContactID);
                        hydrometricDataValueList = (from c in db.HydrometricDataValues select c).OrderBy(c => c.HydrometricDataValueID).Skip(0).Take(2).ToList();
                        count = (from c in db.HydrometricDataValues select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with HydrometricDataValue info
                        jsonRet = hydrometricDataValueController.GetHydrometricDataValueList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(hydrometricDataValueList[0].HydrometricDataValueID, ((List<HydrometricDataValue>)ret.Value)[0].HydrometricDataValueID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<HydrometricDataValue>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with HydrometricDataValue info
                           IActionResult jsonRet2 = hydrometricDataValueController.GetHydrometricDataValueList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(hydrometricDataValueList[1].HydrometricDataValueID, ((List<HydrometricDataValue>)ret2.Value)[0].HydrometricDataValueID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<HydrometricDataValue>)ret2.Value).Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void HydrometricDataValue_Controller_GetHydrometricDataValueWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    HydrometricDataValueController hydrometricDataValueController = new HydrometricDataValueController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(hydrometricDataValueController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, hydrometricDataValueController.DatabaseType);

                    HydrometricDataValue hydrometricDataValueFirst = new HydrometricDataValue();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        HydrometricDataValueService hydrometricDataValueService = new HydrometricDataValueService(new Query(), db, ContactID);
                        hydrometricDataValueFirst = (from c in db.HydrometricDataValues select c).FirstOrDefault();
                    }

                    // ok with HydrometricDataValue info
                    IActionResult jsonRet = hydrometricDataValueController.GetHydrometricDataValueWithID(hydrometricDataValueFirst.HydrometricDataValueID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(hydrometricDataValueFirst.HydrometricDataValueID, ((HydrometricDataValue)ret.Value).HydrometricDataValueID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = hydrometricDataValueController.GetHydrometricDataValueWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult hydrometricDataValueRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(hydrometricDataValueRet2);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void HydrometricDataValue_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    HydrometricDataValueController hydrometricDataValueController = new HydrometricDataValueController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(hydrometricDataValueController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, hydrometricDataValueController.DatabaseType);

                    HydrometricDataValue hydrometricDataValueFirst = new HydrometricDataValue();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        HydrometricDataValueService hydrometricDataValueService = new HydrometricDataValueService(query, db, ContactID);
                        hydrometricDataValueFirst = (from c in db.HydrometricDataValues select c).FirstOrDefault();
                    }

                    // ok with HydrometricDataValue info
                    IActionResult jsonRet = hydrometricDataValueController.GetHydrometricDataValueWithID(hydrometricDataValueFirst.HydrometricDataValueID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    HydrometricDataValue hydrometricDataValueRet = (HydrometricDataValue)ret.Value;
                    Assert.Equal(hydrometricDataValueFirst.HydrometricDataValueID, hydrometricDataValueRet.HydrometricDataValueID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because HydrometricDataValueID exist
                    IActionResult jsonRet2 = hydrometricDataValueController.Post(hydrometricDataValueRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added HydrometricDataValue
                    hydrometricDataValueRet.HydrometricDataValueID = 0;
                    IActionResult jsonRet3 = hydrometricDataValueController.Post(hydrometricDataValueRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = hydrometricDataValueController.Delete(hydrometricDataValueRet, LanguageRequest.ToString());
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
        public void HydrometricDataValue_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    HydrometricDataValueController hydrometricDataValueController = new HydrometricDataValueController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(hydrometricDataValueController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, hydrometricDataValueController.DatabaseType);

                    HydrometricDataValue hydrometricDataValueFirst = new HydrometricDataValue();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        HydrometricDataValueService hydrometricDataValueService = new HydrometricDataValueService(query, db, ContactID);
                        hydrometricDataValueFirst = (from c in db.HydrometricDataValues select c).FirstOrDefault();
                    }

                    // ok with HydrometricDataValue info
                    IActionResult jsonRet = hydrometricDataValueController.GetHydrometricDataValueWithID(hydrometricDataValueFirst.HydrometricDataValueID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    HydrometricDataValue hydrometricDataValueRet = (HydrometricDataValue)Ret.Value;
                    Assert.Equal(hydrometricDataValueFirst.HydrometricDataValueID, hydrometricDataValueRet.HydrometricDataValueID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = hydrometricDataValueController.Put(hydrometricDataValueRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult hydrometricDataValueRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(hydrometricDataValueRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because HydrometricDataValueID of 0 does not exist
                    hydrometricDataValueRet.HydrometricDataValueID = 0;
                    IActionResult jsonRet3 = hydrometricDataValueController.Put(hydrometricDataValueRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult hydrometricDataValueRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(hydrometricDataValueRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void HydrometricDataValue_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    HydrometricDataValueController hydrometricDataValueController = new HydrometricDataValueController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(hydrometricDataValueController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, hydrometricDataValueController.DatabaseType);

                    HydrometricDataValue hydrometricDataValueFirst = new HydrometricDataValue();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        HydrometricDataValueService hydrometricDataValueService = new HydrometricDataValueService(query, db, ContactID);
                        hydrometricDataValueFirst = (from c in db.HydrometricDataValues select c).FirstOrDefault();
                    }

                    // ok with HydrometricDataValue info
                    IActionResult jsonRet = hydrometricDataValueController.GetHydrometricDataValueWithID(hydrometricDataValueFirst.HydrometricDataValueID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    HydrometricDataValue hydrometricDataValueRet = (HydrometricDataValue)Ret.Value;
                    Assert.Equal(hydrometricDataValueFirst.HydrometricDataValueID, hydrometricDataValueRet.HydrometricDataValueID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added HydrometricDataValue
                    hydrometricDataValueRet.HydrometricDataValueID = 0;
                    IActionResult jsonRet3 = hydrometricDataValueController.Post(hydrometricDataValueRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    HydrometricDataValue hydrometricDataValue = (HydrometricDataValue)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = hydrometricDataValueController.Delete(hydrometricDataValueRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because HydrometricDataValueID of 0 does not exist
                    hydrometricDataValueRet.HydrometricDataValueID = 0;
                    IActionResult jsonRet4 = hydrometricDataValueController.Delete(hydrometricDataValueRet, LanguageRequest.ToString());
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
