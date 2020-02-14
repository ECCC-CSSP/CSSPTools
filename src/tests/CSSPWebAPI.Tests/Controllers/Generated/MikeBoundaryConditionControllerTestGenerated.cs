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
    public partial class MikeBoundaryConditionControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MikeBoundaryConditionControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void MikeBoundaryCondition_Controller_GetMikeBoundaryConditionList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MikeBoundaryConditionController mikeBoundaryConditionController = new MikeBoundaryConditionController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mikeBoundaryConditionController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mikeBoundaryConditionController.DatabaseType);

                    MikeBoundaryCondition mikeBoundaryConditionFirst = new MikeBoundaryCondition();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        MikeBoundaryConditionService mikeBoundaryConditionService = new MikeBoundaryConditionService(query, db, ContactID);
                        mikeBoundaryConditionFirst = (from c in db.MikeBoundaryConditions select c).FirstOrDefault();
                        count = (from c in db.MikeBoundaryConditions select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with MikeBoundaryCondition info
                    IActionResult jsonRet = mikeBoundaryConditionController.GetMikeBoundaryConditionList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(mikeBoundaryConditionFirst.MikeBoundaryConditionID, ((List<MikeBoundaryCondition>)ret.Value)[0].MikeBoundaryConditionID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<MikeBoundaryCondition>)ret.Value).Count);

                    List<MikeBoundaryCondition> mikeBoundaryConditionList = new List<MikeBoundaryCondition>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        MikeBoundaryConditionService mikeBoundaryConditionService = new MikeBoundaryConditionService(query, db, ContactID);
                        mikeBoundaryConditionList = (from c in db.MikeBoundaryConditions select c).OrderBy(c => c.MikeBoundaryConditionID).Skip(0).Take(2).ToList();
                        count = (from c in db.MikeBoundaryConditions select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with MikeBoundaryCondition info
                        jsonRet = mikeBoundaryConditionController.GetMikeBoundaryConditionList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(mikeBoundaryConditionList[0].MikeBoundaryConditionID, ((List<MikeBoundaryCondition>)ret.Value)[0].MikeBoundaryConditionID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<MikeBoundaryCondition>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with MikeBoundaryCondition info
                           IActionResult jsonRet2 = mikeBoundaryConditionController.GetMikeBoundaryConditionList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(mikeBoundaryConditionList[1].MikeBoundaryConditionID, ((List<MikeBoundaryCondition>)ret2.Value)[0].MikeBoundaryConditionID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<MikeBoundaryCondition>)ret2.Value).Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void MikeBoundaryCondition_Controller_GetMikeBoundaryConditionWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MikeBoundaryConditionController mikeBoundaryConditionController = new MikeBoundaryConditionController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mikeBoundaryConditionController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mikeBoundaryConditionController.DatabaseType);

                    MikeBoundaryCondition mikeBoundaryConditionFirst = new MikeBoundaryCondition();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        MikeBoundaryConditionService mikeBoundaryConditionService = new MikeBoundaryConditionService(new Query(), db, ContactID);
                        mikeBoundaryConditionFirst = (from c in db.MikeBoundaryConditions select c).FirstOrDefault();
                    }

                    // ok with MikeBoundaryCondition info
                    IActionResult jsonRet = mikeBoundaryConditionController.GetMikeBoundaryConditionWithID(mikeBoundaryConditionFirst.MikeBoundaryConditionID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(mikeBoundaryConditionFirst.MikeBoundaryConditionID, ((MikeBoundaryCondition)ret.Value).MikeBoundaryConditionID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = mikeBoundaryConditionController.GetMikeBoundaryConditionWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult mikeBoundaryConditionRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(mikeBoundaryConditionRet2);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void MikeBoundaryCondition_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MikeBoundaryConditionController mikeBoundaryConditionController = new MikeBoundaryConditionController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mikeBoundaryConditionController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mikeBoundaryConditionController.DatabaseType);

                    MikeBoundaryCondition mikeBoundaryConditionLast = new MikeBoundaryCondition();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MikeBoundaryConditionService mikeBoundaryConditionService = new MikeBoundaryConditionService(query, db, ContactID);
                        mikeBoundaryConditionLast = (from c in db.MikeBoundaryConditions select c).FirstOrDefault();
                    }

                    // ok with MikeBoundaryCondition info
                    IActionResult jsonRet = mikeBoundaryConditionController.GetMikeBoundaryConditionWithID(mikeBoundaryConditionLast.MikeBoundaryConditionID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    MikeBoundaryCondition mikeBoundaryConditionRet = (MikeBoundaryCondition)ret.Value;
                    Assert.Equal(mikeBoundaryConditionLast.MikeBoundaryConditionID, mikeBoundaryConditionRet.MikeBoundaryConditionID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because MikeBoundaryConditionID exist
                    IActionResult jsonRet2 = mikeBoundaryConditionController.Post(mikeBoundaryConditionRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added MikeBoundaryCondition
                    mikeBoundaryConditionRet.MikeBoundaryConditionID = 0;
                    IActionResult jsonRet3 = mikeBoundaryConditionController.Post(mikeBoundaryConditionRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = mikeBoundaryConditionController.Delete(mikeBoundaryConditionRet, LanguageRequest.ToString());
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
        public void MikeBoundaryCondition_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MikeBoundaryConditionController mikeBoundaryConditionController = new MikeBoundaryConditionController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mikeBoundaryConditionController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mikeBoundaryConditionController.DatabaseType);

                    MikeBoundaryCondition mikeBoundaryConditionLast = new MikeBoundaryCondition();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        MikeBoundaryConditionService mikeBoundaryConditionService = new MikeBoundaryConditionService(query, db, ContactID);
                        mikeBoundaryConditionLast = (from c in db.MikeBoundaryConditions select c).FirstOrDefault();
                    }

                    // ok with MikeBoundaryCondition info
                    IActionResult jsonRet = mikeBoundaryConditionController.GetMikeBoundaryConditionWithID(mikeBoundaryConditionLast.MikeBoundaryConditionID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    MikeBoundaryCondition mikeBoundaryConditionRet = (MikeBoundaryCondition)Ret.Value;
                    Assert.Equal(mikeBoundaryConditionLast.MikeBoundaryConditionID, mikeBoundaryConditionRet.MikeBoundaryConditionID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = mikeBoundaryConditionController.Put(mikeBoundaryConditionRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult mikeBoundaryConditionRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(mikeBoundaryConditionRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because MikeBoundaryConditionID of 0 does not exist
                    mikeBoundaryConditionRet.MikeBoundaryConditionID = 0;
                    IActionResult jsonRet3 = mikeBoundaryConditionController.Put(mikeBoundaryConditionRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult mikeBoundaryConditionRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(mikeBoundaryConditionRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void MikeBoundaryCondition_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MikeBoundaryConditionController mikeBoundaryConditionController = new MikeBoundaryConditionController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mikeBoundaryConditionController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mikeBoundaryConditionController.DatabaseType);

                    MikeBoundaryCondition mikeBoundaryConditionLast = new MikeBoundaryCondition();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MikeBoundaryConditionService mikeBoundaryConditionService = new MikeBoundaryConditionService(query, db, ContactID);
                        mikeBoundaryConditionLast = (from c in db.MikeBoundaryConditions select c).FirstOrDefault();
                    }

                    // ok with MikeBoundaryCondition info
                    IActionResult jsonRet = mikeBoundaryConditionController.GetMikeBoundaryConditionWithID(mikeBoundaryConditionLast.MikeBoundaryConditionID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    MikeBoundaryCondition mikeBoundaryConditionRet = (MikeBoundaryCondition)Ret.Value;
                    Assert.Equal(mikeBoundaryConditionLast.MikeBoundaryConditionID, mikeBoundaryConditionRet.MikeBoundaryConditionID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added MikeBoundaryCondition
                    mikeBoundaryConditionRet.MikeBoundaryConditionID = 0;
                    IActionResult jsonRet3 = mikeBoundaryConditionController.Post(mikeBoundaryConditionRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    MikeBoundaryCondition mikeBoundaryCondition = (MikeBoundaryCondition)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = mikeBoundaryConditionController.Delete(mikeBoundaryConditionRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because MikeBoundaryConditionID of 0 does not exist
                    mikeBoundaryConditionRet.MikeBoundaryConditionID = 0;
                    IActionResult jsonRet4 = mikeBoundaryConditionController.Delete(mikeBoundaryConditionRet, LanguageRequest.ToString());
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
