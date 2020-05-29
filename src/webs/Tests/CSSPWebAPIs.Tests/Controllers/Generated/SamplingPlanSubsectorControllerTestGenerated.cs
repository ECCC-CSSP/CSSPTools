using CSSPEnums;
using CSSPModels;
using CSSPServices;
using CSSPWebAPI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;

namespace CSSPWebAPI.Tests.Controllers
{
    [TestClass]
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
        [TestMethod]
        public void SamplingPlanSubsector_Controller_GetSamplingPlanSubsectorList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    SamplingPlanSubsectorController samplingPlanSubsectorController = new SamplingPlanSubsectorController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(samplingPlanSubsectorController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, samplingPlanSubsectorController.DatabaseType);

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
                    IHttpActionResult jsonRet = samplingPlanSubsectorController.GetSamplingPlanSubsectorList();
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<List<SamplingPlanSubsector>> ret = jsonRet as OkNegotiatedContentResult<List<SamplingPlanSubsector>>;
                    Assert.AreEqual(samplingPlanSubsectorFirst.SamplingPlanSubsectorID, ret.Content[0].SamplingPlanSubsectorID);
                    Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

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
                        Assert.IsNotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<SamplingPlanSubsector>>;
                        Assert.AreEqual(samplingPlanSubsectorList[0].SamplingPlanSubsectorID, ret.Content[0].SamplingPlanSubsectorID);
                        Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with SamplingPlanSubsector info
                           IHttpActionResult jsonRet2 = samplingPlanSubsectorController.GetSamplingPlanSubsectorList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.IsNotNull(jsonRet2);

                           OkNegotiatedContentResult<List<SamplingPlanSubsector>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<SamplingPlanSubsector>>;
                           Assert.AreEqual(samplingPlanSubsectorList[1].SamplingPlanSubsectorID, ret2.Content[0].SamplingPlanSubsectorID);
                           Assert.AreEqual((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [TestMethod]
        public void SamplingPlanSubsector_Controller_GetSamplingPlanSubsectorWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    SamplingPlanSubsectorController samplingPlanSubsectorController = new SamplingPlanSubsectorController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(samplingPlanSubsectorController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, samplingPlanSubsectorController.DatabaseType);

                    SamplingPlanSubsector samplingPlanSubsectorFirst = new SamplingPlanSubsector();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        SamplingPlanSubsectorService samplingPlanSubsectorService = new SamplingPlanSubsectorService(new Query(), db, ContactID);
                        samplingPlanSubsectorFirst = (from c in db.SamplingPlanSubsectors select c).FirstOrDefault();
                    }

                    // ok with SamplingPlanSubsector info
                    IHttpActionResult jsonRet = samplingPlanSubsectorController.GetSamplingPlanSubsectorWithID(samplingPlanSubsectorFirst.SamplingPlanSubsectorID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<SamplingPlanSubsector> Ret = jsonRet as OkNegotiatedContentResult<SamplingPlanSubsector>;
                    SamplingPlanSubsector samplingPlanSubsectorRet = Ret.Content;
                    Assert.AreEqual(samplingPlanSubsectorFirst.SamplingPlanSubsectorID, samplingPlanSubsectorRet.SamplingPlanSubsectorID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = samplingPlanSubsectorController.GetSamplingPlanSubsectorWithID(0);
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<SamplingPlanSubsector> samplingPlanSubsectorRet2 = jsonRet2 as OkNegotiatedContentResult<SamplingPlanSubsector>;
                    Assert.IsNull(samplingPlanSubsectorRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.IsNotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [TestMethod]
        public void SamplingPlanSubsector_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    SamplingPlanSubsectorController samplingPlanSubsectorController = new SamplingPlanSubsectorController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(samplingPlanSubsectorController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, samplingPlanSubsectorController.DatabaseType);

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
                    IHttpActionResult jsonRet = samplingPlanSubsectorController.GetSamplingPlanSubsectorWithID(samplingPlanSubsectorLast.SamplingPlanSubsectorID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<SamplingPlanSubsector> Ret = jsonRet as OkNegotiatedContentResult<SamplingPlanSubsector>;
                    SamplingPlanSubsector samplingPlanSubsectorRet = Ret.Content;
                    Assert.AreEqual(samplingPlanSubsectorLast.SamplingPlanSubsectorID, samplingPlanSubsectorRet.SamplingPlanSubsectorID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because SamplingPlanSubsectorID exist
                    IHttpActionResult jsonRet2 = samplingPlanSubsectorController.Post(samplingPlanSubsectorRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<SamplingPlanSubsector> samplingPlanSubsectorRet2 = jsonRet2 as OkNegotiatedContentResult<SamplingPlanSubsector>;
                    Assert.IsNull(samplingPlanSubsectorRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest2);

                    // Post to return newly added SamplingPlanSubsector
                    samplingPlanSubsectorRet.SamplingPlanSubsectorID = 0;
                    samplingPlanSubsectorController.Request = new System.Net.Http.HttpRequestMessage();
                    samplingPlanSubsectorController.Request.RequestUri = new System.Uri("http://localhost:5000/api/samplingPlanSubsector");
                    IHttpActionResult jsonRet3 = samplingPlanSubsectorController.Post(samplingPlanSubsectorRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<SamplingPlanSubsector> samplingPlanSubsectorRet3 = jsonRet3 as CreatedNegotiatedContentResult<SamplingPlanSubsector>;
                    Assert.IsNotNull(samplingPlanSubsectorRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = samplingPlanSubsectorController.Delete(samplingPlanSubsectorRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<SamplingPlanSubsector> samplingPlanSubsectorRet4 = jsonRet4 as OkNegotiatedContentResult<SamplingPlanSubsector>;
                    Assert.IsNotNull(samplingPlanSubsectorRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [TestMethod]
        public void SamplingPlanSubsector_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    SamplingPlanSubsectorController samplingPlanSubsectorController = new SamplingPlanSubsectorController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(samplingPlanSubsectorController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, samplingPlanSubsectorController.DatabaseType);

                    SamplingPlanSubsector samplingPlanSubsectorLast = new SamplingPlanSubsector();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        SamplingPlanSubsectorService samplingPlanSubsectorService = new SamplingPlanSubsectorService(query, db, ContactID);
                        samplingPlanSubsectorLast = (from c in db.SamplingPlanSubsectors select c).FirstOrDefault();
                    }

                    // ok with SamplingPlanSubsector info
                    IHttpActionResult jsonRet = samplingPlanSubsectorController.GetSamplingPlanSubsectorWithID(samplingPlanSubsectorLast.SamplingPlanSubsectorID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<SamplingPlanSubsector> Ret = jsonRet as OkNegotiatedContentResult<SamplingPlanSubsector>;
                    SamplingPlanSubsector samplingPlanSubsectorRet = Ret.Content;
                    Assert.AreEqual(samplingPlanSubsectorLast.SamplingPlanSubsectorID, samplingPlanSubsectorRet.SamplingPlanSubsectorID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = samplingPlanSubsectorController.Put(samplingPlanSubsectorRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<SamplingPlanSubsector> samplingPlanSubsectorRet2 = jsonRet2 as OkNegotiatedContentResult<SamplingPlanSubsector>;
                    Assert.IsNotNull(samplingPlanSubsectorRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because SamplingPlanSubsectorID of 0 does not exist
                    samplingPlanSubsectorRet.SamplingPlanSubsectorID = 0;
                    IHttpActionResult jsonRet3 = samplingPlanSubsectorController.Put(samplingPlanSubsectorRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    OkNegotiatedContentResult<SamplingPlanSubsector> samplingPlanSubsectorRet3 = jsonRet3 as OkNegotiatedContentResult<SamplingPlanSubsector>;
                    Assert.IsNull(samplingPlanSubsectorRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [TestMethod]
        public void SamplingPlanSubsector_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    SamplingPlanSubsectorController samplingPlanSubsectorController = new SamplingPlanSubsectorController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(samplingPlanSubsectorController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, samplingPlanSubsectorController.DatabaseType);

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
                    IHttpActionResult jsonRet = samplingPlanSubsectorController.GetSamplingPlanSubsectorWithID(samplingPlanSubsectorLast.SamplingPlanSubsectorID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<SamplingPlanSubsector> Ret = jsonRet as OkNegotiatedContentResult<SamplingPlanSubsector>;
                    SamplingPlanSubsector samplingPlanSubsectorRet = Ret.Content;
                    Assert.AreEqual(samplingPlanSubsectorLast.SamplingPlanSubsectorID, samplingPlanSubsectorRet.SamplingPlanSubsectorID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added SamplingPlanSubsector
                    samplingPlanSubsectorRet.SamplingPlanSubsectorID = 0;
                    samplingPlanSubsectorController.Request = new System.Net.Http.HttpRequestMessage();
                    samplingPlanSubsectorController.Request.RequestUri = new System.Uri("http://localhost:5000/api/samplingPlanSubsector");
                    IHttpActionResult jsonRet3 = samplingPlanSubsectorController.Post(samplingPlanSubsectorRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<SamplingPlanSubsector> samplingPlanSubsectorRet3 = jsonRet3 as CreatedNegotiatedContentResult<SamplingPlanSubsector>;
                    Assert.IsNotNull(samplingPlanSubsectorRet3);
                    SamplingPlanSubsector samplingPlanSubsector = samplingPlanSubsectorRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = samplingPlanSubsectorController.Delete(samplingPlanSubsectorRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<SamplingPlanSubsector> samplingPlanSubsectorRet2 = jsonRet2 as OkNegotiatedContentResult<SamplingPlanSubsector>;
                    Assert.IsNotNull(samplingPlanSubsectorRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because SamplingPlanSubsectorID of 0 does not exist
                    samplingPlanSubsectorRet.SamplingPlanSubsectorID = 0;
                    IHttpActionResult jsonRet4 = samplingPlanSubsectorController.Delete(samplingPlanSubsectorRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<SamplingPlanSubsector> samplingPlanSubsectorRet4 = jsonRet4 as OkNegotiatedContentResult<SamplingPlanSubsector>;
                    Assert.IsNull(samplingPlanSubsectorRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
