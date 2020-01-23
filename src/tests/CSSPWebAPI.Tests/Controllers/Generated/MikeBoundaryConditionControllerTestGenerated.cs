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
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<List<MikeBoundaryCondition>> ret = jsonRet as OkNegotiatedContentResult<List<MikeBoundaryCondition>>;
                    Assert.Equal(mikeBoundaryConditionFirst.MikeBoundaryConditionID, ret.Content[0].MikeBoundaryConditionID);
                    Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

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
                        Assert.NotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<MikeBoundaryCondition>>;
                        Assert.Equal(mikeBoundaryConditionList[0].MikeBoundaryConditionID, ret.Content[0].MikeBoundaryConditionID);
                        Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with MikeBoundaryCondition info
                           IActionResult jsonRet2 = mikeBoundaryConditionController.GetMikeBoundaryConditionList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkNegotiatedContentResult<List<MikeBoundaryCondition>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<MikeBoundaryCondition>>;
                           Assert.Equal(mikeBoundaryConditionList[1].MikeBoundaryConditionID, ret2.Content[0].MikeBoundaryConditionID);
                           Assert.Equal((count > query.Take ? query.Take : count), ret2.Content.Count);
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
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<MikeBoundaryCondition> Ret = jsonRet as OkNegotiatedContentResult<MikeBoundaryCondition>;
                    MikeBoundaryCondition mikeBoundaryConditionRet = Ret.Content;
                    Assert.Equal(mikeBoundaryConditionFirst.MikeBoundaryConditionID, mikeBoundaryConditionRet.MikeBoundaryConditionID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = mikeBoundaryConditionController.GetMikeBoundaryConditionWithID(0);
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<MikeBoundaryCondition> mikeBoundaryConditionRet2 = jsonRet2 as OkNegotiatedContentResult<MikeBoundaryCondition>;
                    Assert.Null(mikeBoundaryConditionRet2);

                    NotFoundObjectResult notFoundRequest = jsonRet2 as NotFoundObjectResult;
                    Assert.NotNull(notFoundRequest);
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
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<MikeBoundaryCondition> Ret = jsonRet as OkNegotiatedContentResult<MikeBoundaryCondition>;
                    MikeBoundaryCondition mikeBoundaryConditionRet = Ret.Content;
                    Assert.Equal(mikeBoundaryConditionLast.MikeBoundaryConditionID, mikeBoundaryConditionRet.MikeBoundaryConditionID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because MikeBoundaryConditionID exist
                    IActionResult jsonRet2 = mikeBoundaryConditionController.Post(mikeBoundaryConditionRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<MikeBoundaryCondition> mikeBoundaryConditionRet2 = jsonRet2 as OkNegotiatedContentResult<MikeBoundaryCondition>;
                    Assert.Null(mikeBoundaryConditionRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added MikeBoundaryCondition
                    mikeBoundaryConditionRet.MikeBoundaryConditionID = 0;
                    IActionResult jsonRet3 = mikeBoundaryConditionController.Post(mikeBoundaryConditionRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<MikeBoundaryCondition> mikeBoundaryConditionRet3 = jsonRet3 as CreatedNegotiatedContentResult<MikeBoundaryCondition>;
                    Assert.NotNull(mikeBoundaryConditionRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = mikeBoundaryConditionController.Delete(mikeBoundaryConditionRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<MikeBoundaryCondition> mikeBoundaryConditionRet4 = jsonRet4 as OkNegotiatedContentResult<MikeBoundaryCondition>;
                    Assert.NotNull(mikeBoundaryConditionRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
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
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<MikeBoundaryCondition> Ret = jsonRet as OkNegotiatedContentResult<MikeBoundaryCondition>;
                    MikeBoundaryCondition mikeBoundaryConditionRet = Ret.Content;
                    Assert.Equal(mikeBoundaryConditionLast.MikeBoundaryConditionID, mikeBoundaryConditionRet.MikeBoundaryConditionID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = mikeBoundaryConditionController.Put(mikeBoundaryConditionRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<MikeBoundaryCondition> mikeBoundaryConditionRet2 = jsonRet2 as OkNegotiatedContentResult<MikeBoundaryCondition>;
                    Assert.NotNull(mikeBoundaryConditionRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because MikeBoundaryConditionID of 0 does not exist
                    mikeBoundaryConditionRet.MikeBoundaryConditionID = 0;
                    IActionResult jsonRet3 = mikeBoundaryConditionController.Put(mikeBoundaryConditionRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    OkNegotiatedContentResult<MikeBoundaryCondition> mikeBoundaryConditionRet3 = jsonRet3 as OkNegotiatedContentResult<MikeBoundaryCondition>;
                    Assert.Null(mikeBoundaryConditionRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
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
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<MikeBoundaryCondition> Ret = jsonRet as OkNegotiatedContentResult<MikeBoundaryCondition>;
                    MikeBoundaryCondition mikeBoundaryConditionRet = Ret.Content;
                    Assert.Equal(mikeBoundaryConditionLast.MikeBoundaryConditionID, mikeBoundaryConditionRet.MikeBoundaryConditionID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return newly added MikeBoundaryCondition
                    mikeBoundaryConditionRet.MikeBoundaryConditionID = 0;
                    IActionResult jsonRet3 = mikeBoundaryConditionController.Post(mikeBoundaryConditionRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<MikeBoundaryCondition> mikeBoundaryConditionRet3 = jsonRet3 as CreatedNegotiatedContentResult<MikeBoundaryCondition>;
                    Assert.NotNull(mikeBoundaryConditionRet3);
                    MikeBoundaryCondition mikeBoundaryCondition = mikeBoundaryConditionRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = mikeBoundaryConditionController.Delete(mikeBoundaryConditionRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<MikeBoundaryCondition> mikeBoundaryConditionRet2 = jsonRet2 as OkNegotiatedContentResult<MikeBoundaryCondition>;
                    Assert.NotNull(mikeBoundaryConditionRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because MikeBoundaryConditionID of 0 does not exist
                    mikeBoundaryConditionRet.MikeBoundaryConditionID = 0;
                    IActionResult jsonRet4 = mikeBoundaryConditionController.Delete(mikeBoundaryConditionRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<MikeBoundaryCondition> mikeBoundaryConditionRet4 = jsonRet4 as OkNegotiatedContentResult<MikeBoundaryCondition>;
                    Assert.Null(mikeBoundaryConditionRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
