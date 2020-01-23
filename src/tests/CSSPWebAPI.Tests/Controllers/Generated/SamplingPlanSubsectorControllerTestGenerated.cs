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
    public partial class SamplingPlanSubsectorControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public SamplingPlanSubsectorControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void SamplingPlanSubsector_Controller_GetSamplingPlanSubsectorList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    SamplingPlanSubsectorController samplingPlanSubsectorController = new SamplingPlanSubsectorController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(samplingPlanSubsectorController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, samplingPlanSubsectorController.DatabaseType);

                    SamplingPlanSubsector samplingPlanSubsectorFirst = new SamplingPlanSubsector();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        SamplingPlanSubsectorService samplingPlanSubsectorService = new SamplingPlanSubsectorService(query, db, ContactID);
                        samplingPlanSubsectorFirst = (from c in db.SamplingPlanSubsectors select c).FirstOrDefault();
                        count = (from c in db.SamplingPlanSubsectors select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with SamplingPlanSubsector info
                    IActionResult jsonRet = samplingPlanSubsectorController.GetSamplingPlanSubsectorList();
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<List<SamplingPlanSubsector>> ret = jsonRet as OkNegotiatedContentResult<List<SamplingPlanSubsector>>;
                    Assert.Equal(samplingPlanSubsectorFirst.SamplingPlanSubsectorID, ret.Content[0].SamplingPlanSubsectorID);
                    Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<SamplingPlanSubsector> samplingPlanSubsectorList = new List<SamplingPlanSubsector>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        SamplingPlanSubsectorService samplingPlanSubsectorService = new SamplingPlanSubsectorService(query, db, ContactID);
                        samplingPlanSubsectorList = (from c in db.SamplingPlanSubsectors select c).OrderBy(c => c.SamplingPlanSubsectorID).Skip(0).Take(2).ToList();
                        count = (from c in db.SamplingPlanSubsectors select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with SamplingPlanSubsector info
                        jsonRet = samplingPlanSubsectorController.GetSamplingPlanSubsectorList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.NotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<SamplingPlanSubsector>>;
                        Assert.Equal(samplingPlanSubsectorList[0].SamplingPlanSubsectorID, ret.Content[0].SamplingPlanSubsectorID);
                        Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with SamplingPlanSubsector info
                           IActionResult jsonRet2 = samplingPlanSubsectorController.GetSamplingPlanSubsectorList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkNegotiatedContentResult<List<SamplingPlanSubsector>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<SamplingPlanSubsector>>;
                           Assert.Equal(samplingPlanSubsectorList[1].SamplingPlanSubsectorID, ret2.Content[0].SamplingPlanSubsectorID);
                           Assert.Equal((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void SamplingPlanSubsector_Controller_GetSamplingPlanSubsectorWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    SamplingPlanSubsectorController samplingPlanSubsectorController = new SamplingPlanSubsectorController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(samplingPlanSubsectorController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, samplingPlanSubsectorController.DatabaseType);

                    SamplingPlanSubsector samplingPlanSubsectorFirst = new SamplingPlanSubsector();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        SamplingPlanSubsectorService samplingPlanSubsectorService = new SamplingPlanSubsectorService(new Query(), db, ContactID);
                        samplingPlanSubsectorFirst = (from c in db.SamplingPlanSubsectors select c).FirstOrDefault();
                    }

                    // ok with SamplingPlanSubsector info
                    IActionResult jsonRet = samplingPlanSubsectorController.GetSamplingPlanSubsectorWithID(samplingPlanSubsectorFirst.SamplingPlanSubsectorID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<SamplingPlanSubsector> Ret = jsonRet as OkNegotiatedContentResult<SamplingPlanSubsector>;
                    SamplingPlanSubsector samplingPlanSubsectorRet = Ret.Content;
                    Assert.Equal(samplingPlanSubsectorFirst.SamplingPlanSubsectorID, samplingPlanSubsectorRet.SamplingPlanSubsectorID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = samplingPlanSubsectorController.GetSamplingPlanSubsectorWithID(0);
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<SamplingPlanSubsector> samplingPlanSubsectorRet2 = jsonRet2 as OkNegotiatedContentResult<SamplingPlanSubsector>;
                    Assert.Null(samplingPlanSubsectorRet2);

                    NotFoundObjectResult notFoundRequest = jsonRet2 as NotFoundObjectResult;
                    Assert.NotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void SamplingPlanSubsector_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    SamplingPlanSubsectorController samplingPlanSubsectorController = new SamplingPlanSubsectorController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(samplingPlanSubsectorController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, samplingPlanSubsectorController.DatabaseType);

                    SamplingPlanSubsector samplingPlanSubsectorLast = new SamplingPlanSubsector();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        SamplingPlanSubsectorService samplingPlanSubsectorService = new SamplingPlanSubsectorService(query, db, ContactID);
                        samplingPlanSubsectorLast = (from c in db.SamplingPlanSubsectors select c).FirstOrDefault();
                    }

                    // ok with SamplingPlanSubsector info
                    IActionResult jsonRet = samplingPlanSubsectorController.GetSamplingPlanSubsectorWithID(samplingPlanSubsectorLast.SamplingPlanSubsectorID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<SamplingPlanSubsector> Ret = jsonRet as OkNegotiatedContentResult<SamplingPlanSubsector>;
                    SamplingPlanSubsector samplingPlanSubsectorRet = Ret.Content;
                    Assert.Equal(samplingPlanSubsectorLast.SamplingPlanSubsectorID, samplingPlanSubsectorRet.SamplingPlanSubsectorID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because SamplingPlanSubsectorID exist
                    IActionResult jsonRet2 = samplingPlanSubsectorController.Post(samplingPlanSubsectorRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<SamplingPlanSubsector> samplingPlanSubsectorRet2 = jsonRet2 as OkNegotiatedContentResult<SamplingPlanSubsector>;
                    Assert.Null(samplingPlanSubsectorRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added SamplingPlanSubsector
                    samplingPlanSubsectorRet.SamplingPlanSubsectorID = 0;
                    IActionResult jsonRet3 = samplingPlanSubsectorController.Post(samplingPlanSubsectorRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<SamplingPlanSubsector> samplingPlanSubsectorRet3 = jsonRet3 as CreatedNegotiatedContentResult<SamplingPlanSubsector>;
                    Assert.NotNull(samplingPlanSubsectorRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = samplingPlanSubsectorController.Delete(samplingPlanSubsectorRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<SamplingPlanSubsector> samplingPlanSubsectorRet4 = jsonRet4 as OkNegotiatedContentResult<SamplingPlanSubsector>;
                    Assert.NotNull(samplingPlanSubsectorRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [Fact]
        public void SamplingPlanSubsector_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    SamplingPlanSubsectorController samplingPlanSubsectorController = new SamplingPlanSubsectorController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(samplingPlanSubsectorController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, samplingPlanSubsectorController.DatabaseType);

                    SamplingPlanSubsector samplingPlanSubsectorLast = new SamplingPlanSubsector();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        SamplingPlanSubsectorService samplingPlanSubsectorService = new SamplingPlanSubsectorService(query, db, ContactID);
                        samplingPlanSubsectorLast = (from c in db.SamplingPlanSubsectors select c).FirstOrDefault();
                    }

                    // ok with SamplingPlanSubsector info
                    IActionResult jsonRet = samplingPlanSubsectorController.GetSamplingPlanSubsectorWithID(samplingPlanSubsectorLast.SamplingPlanSubsectorID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<SamplingPlanSubsector> Ret = jsonRet as OkNegotiatedContentResult<SamplingPlanSubsector>;
                    SamplingPlanSubsector samplingPlanSubsectorRet = Ret.Content;
                    Assert.Equal(samplingPlanSubsectorLast.SamplingPlanSubsectorID, samplingPlanSubsectorRet.SamplingPlanSubsectorID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = samplingPlanSubsectorController.Put(samplingPlanSubsectorRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<SamplingPlanSubsector> samplingPlanSubsectorRet2 = jsonRet2 as OkNegotiatedContentResult<SamplingPlanSubsector>;
                    Assert.NotNull(samplingPlanSubsectorRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because SamplingPlanSubsectorID of 0 does not exist
                    samplingPlanSubsectorRet.SamplingPlanSubsectorID = 0;
                    IActionResult jsonRet3 = samplingPlanSubsectorController.Put(samplingPlanSubsectorRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    OkNegotiatedContentResult<SamplingPlanSubsector> samplingPlanSubsectorRet3 = jsonRet3 as OkNegotiatedContentResult<SamplingPlanSubsector>;
                    Assert.Null(samplingPlanSubsectorRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void SamplingPlanSubsector_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    SamplingPlanSubsectorController samplingPlanSubsectorController = new SamplingPlanSubsectorController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(samplingPlanSubsectorController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, samplingPlanSubsectorController.DatabaseType);

                    SamplingPlanSubsector samplingPlanSubsectorLast = new SamplingPlanSubsector();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        SamplingPlanSubsectorService samplingPlanSubsectorService = new SamplingPlanSubsectorService(query, db, ContactID);
                        samplingPlanSubsectorLast = (from c in db.SamplingPlanSubsectors select c).FirstOrDefault();
                    }

                    // ok with SamplingPlanSubsector info
                    IActionResult jsonRet = samplingPlanSubsectorController.GetSamplingPlanSubsectorWithID(samplingPlanSubsectorLast.SamplingPlanSubsectorID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<SamplingPlanSubsector> Ret = jsonRet as OkNegotiatedContentResult<SamplingPlanSubsector>;
                    SamplingPlanSubsector samplingPlanSubsectorRet = Ret.Content;
                    Assert.Equal(samplingPlanSubsectorLast.SamplingPlanSubsectorID, samplingPlanSubsectorRet.SamplingPlanSubsectorID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return newly added SamplingPlanSubsector
                    samplingPlanSubsectorRet.SamplingPlanSubsectorID = 0;
                    IActionResult jsonRet3 = samplingPlanSubsectorController.Post(samplingPlanSubsectorRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<SamplingPlanSubsector> samplingPlanSubsectorRet3 = jsonRet3 as CreatedNegotiatedContentResult<SamplingPlanSubsector>;
                    Assert.NotNull(samplingPlanSubsectorRet3);
                    SamplingPlanSubsector samplingPlanSubsector = samplingPlanSubsectorRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = samplingPlanSubsectorController.Delete(samplingPlanSubsectorRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<SamplingPlanSubsector> samplingPlanSubsectorRet2 = jsonRet2 as OkNegotiatedContentResult<SamplingPlanSubsector>;
                    Assert.NotNull(samplingPlanSubsectorRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because SamplingPlanSubsectorID of 0 does not exist
                    samplingPlanSubsectorRet.SamplingPlanSubsectorID = 0;
                    IActionResult jsonRet4 = samplingPlanSubsectorController.Delete(samplingPlanSubsectorRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<SamplingPlanSubsector> samplingPlanSubsectorRet4 = jsonRet4 as OkNegotiatedContentResult<SamplingPlanSubsector>;
                    Assert.Null(samplingPlanSubsectorRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
