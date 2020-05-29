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
    public partial class PolSourceGroupingControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public PolSourceGroupingControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [TestMethod]
        public void PolSourceGrouping_Controller_GetPolSourceGroupingList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    PolSourceGroupingController polSourceGroupingController = new PolSourceGroupingController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(polSourceGroupingController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, polSourceGroupingController.DatabaseType);

                    PolSourceGrouping polSourceGroupingFirst = new PolSourceGrouping();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        PolSourceGroupingService polSourceGroupingService = new PolSourceGroupingService(query, db, ContactID);
                        polSourceGroupingFirst = (from c in db.PolSourceGroupings select c).FirstOrDefault();
                        count = (from c in db.PolSourceGroupings select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with PolSourceGrouping info
                    IHttpActionResult jsonRet = polSourceGroupingController.GetPolSourceGroupingList();
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<List<PolSourceGrouping>> ret = jsonRet as OkNegotiatedContentResult<List<PolSourceGrouping>>;
                    Assert.AreEqual(polSourceGroupingFirst.PolSourceGroupingID, ret.Content[0].PolSourceGroupingID);
                    Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<PolSourceGrouping> polSourceGroupingList = new List<PolSourceGrouping>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        PolSourceGroupingService polSourceGroupingService = new PolSourceGroupingService(query, db, ContactID);
                        polSourceGroupingList = (from c in db.PolSourceGroupings select c).OrderBy(c => c.PolSourceGroupingID).Skip(0).Take(2).ToList();
                        count = (from c in db.PolSourceGroupings select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with PolSourceGrouping info
                        jsonRet = polSourceGroupingController.GetPolSourceGroupingList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsNotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<PolSourceGrouping>>;
                        Assert.AreEqual(polSourceGroupingList[0].PolSourceGroupingID, ret.Content[0].PolSourceGroupingID);
                        Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with PolSourceGrouping info
                           IHttpActionResult jsonRet2 = polSourceGroupingController.GetPolSourceGroupingList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.IsNotNull(jsonRet2);

                           OkNegotiatedContentResult<List<PolSourceGrouping>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<PolSourceGrouping>>;
                           Assert.AreEqual(polSourceGroupingList[1].PolSourceGroupingID, ret2.Content[0].PolSourceGroupingID);
                           Assert.AreEqual((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [TestMethod]
        public void PolSourceGrouping_Controller_GetPolSourceGroupingWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    PolSourceGroupingController polSourceGroupingController = new PolSourceGroupingController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(polSourceGroupingController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, polSourceGroupingController.DatabaseType);

                    PolSourceGrouping polSourceGroupingFirst = new PolSourceGrouping();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        PolSourceGroupingService polSourceGroupingService = new PolSourceGroupingService(new Query(), db, ContactID);
                        polSourceGroupingFirst = (from c in db.PolSourceGroupings select c).FirstOrDefault();
                    }

                    // ok with PolSourceGrouping info
                    IHttpActionResult jsonRet = polSourceGroupingController.GetPolSourceGroupingWithID(polSourceGroupingFirst.PolSourceGroupingID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<PolSourceGrouping> Ret = jsonRet as OkNegotiatedContentResult<PolSourceGrouping>;
                    PolSourceGrouping polSourceGroupingRet = Ret.Content;
                    Assert.AreEqual(polSourceGroupingFirst.PolSourceGroupingID, polSourceGroupingRet.PolSourceGroupingID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = polSourceGroupingController.GetPolSourceGroupingWithID(0);
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<PolSourceGrouping> polSourceGroupingRet2 = jsonRet2 as OkNegotiatedContentResult<PolSourceGrouping>;
                    Assert.IsNull(polSourceGroupingRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.IsNotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [TestMethod]
        public void PolSourceGrouping_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    PolSourceGroupingController polSourceGroupingController = new PolSourceGroupingController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(polSourceGroupingController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, polSourceGroupingController.DatabaseType);

                    PolSourceGrouping polSourceGroupingLast = new PolSourceGrouping();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        PolSourceGroupingService polSourceGroupingService = new PolSourceGroupingService(query, db, ContactID);
                        polSourceGroupingLast = (from c in db.PolSourceGroupings select c).FirstOrDefault();
                    }

                    // ok with PolSourceGrouping info
                    IHttpActionResult jsonRet = polSourceGroupingController.GetPolSourceGroupingWithID(polSourceGroupingLast.PolSourceGroupingID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<PolSourceGrouping> Ret = jsonRet as OkNegotiatedContentResult<PolSourceGrouping>;
                    PolSourceGrouping polSourceGroupingRet = Ret.Content;
                    Assert.AreEqual(polSourceGroupingLast.PolSourceGroupingID, polSourceGroupingRet.PolSourceGroupingID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because PolSourceGroupingID exist
                    IHttpActionResult jsonRet2 = polSourceGroupingController.Post(polSourceGroupingRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<PolSourceGrouping> polSourceGroupingRet2 = jsonRet2 as OkNegotiatedContentResult<PolSourceGrouping>;
                    Assert.IsNull(polSourceGroupingRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest2);

                    // Post to return newly added PolSourceGrouping
                    polSourceGroupingRet.PolSourceGroupingID = 0;
                    polSourceGroupingController.Request = new System.Net.Http.HttpRequestMessage();
                    polSourceGroupingController.Request.RequestUri = new System.Uri("http://localhost:5000/api/polSourceGrouping");
                    IHttpActionResult jsonRet3 = polSourceGroupingController.Post(polSourceGroupingRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<PolSourceGrouping> polSourceGroupingRet3 = jsonRet3 as CreatedNegotiatedContentResult<PolSourceGrouping>;
                    Assert.IsNotNull(polSourceGroupingRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = polSourceGroupingController.Delete(polSourceGroupingRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<PolSourceGrouping> polSourceGroupingRet4 = jsonRet4 as OkNegotiatedContentResult<PolSourceGrouping>;
                    Assert.IsNotNull(polSourceGroupingRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [TestMethod]
        public void PolSourceGrouping_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    PolSourceGroupingController polSourceGroupingController = new PolSourceGroupingController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(polSourceGroupingController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, polSourceGroupingController.DatabaseType);

                    PolSourceGrouping polSourceGroupingLast = new PolSourceGrouping();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        PolSourceGroupingService polSourceGroupingService = new PolSourceGroupingService(query, db, ContactID);
                        polSourceGroupingLast = (from c in db.PolSourceGroupings select c).FirstOrDefault();
                    }

                    // ok with PolSourceGrouping info
                    IHttpActionResult jsonRet = polSourceGroupingController.GetPolSourceGroupingWithID(polSourceGroupingLast.PolSourceGroupingID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<PolSourceGrouping> Ret = jsonRet as OkNegotiatedContentResult<PolSourceGrouping>;
                    PolSourceGrouping polSourceGroupingRet = Ret.Content;
                    Assert.AreEqual(polSourceGroupingLast.PolSourceGroupingID, polSourceGroupingRet.PolSourceGroupingID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = polSourceGroupingController.Put(polSourceGroupingRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<PolSourceGrouping> polSourceGroupingRet2 = jsonRet2 as OkNegotiatedContentResult<PolSourceGrouping>;
                    Assert.IsNotNull(polSourceGroupingRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because PolSourceGroupingID of 0 does not exist
                    polSourceGroupingRet.PolSourceGroupingID = 0;
                    IHttpActionResult jsonRet3 = polSourceGroupingController.Put(polSourceGroupingRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    OkNegotiatedContentResult<PolSourceGrouping> polSourceGroupingRet3 = jsonRet3 as OkNegotiatedContentResult<PolSourceGrouping>;
                    Assert.IsNull(polSourceGroupingRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [TestMethod]
        public void PolSourceGrouping_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    PolSourceGroupingController polSourceGroupingController = new PolSourceGroupingController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(polSourceGroupingController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, polSourceGroupingController.DatabaseType);

                    PolSourceGrouping polSourceGroupingLast = new PolSourceGrouping();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        PolSourceGroupingService polSourceGroupingService = new PolSourceGroupingService(query, db, ContactID);
                        polSourceGroupingLast = (from c in db.PolSourceGroupings select c).FirstOrDefault();
                    }

                    // ok with PolSourceGrouping info
                    IHttpActionResult jsonRet = polSourceGroupingController.GetPolSourceGroupingWithID(polSourceGroupingLast.PolSourceGroupingID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<PolSourceGrouping> Ret = jsonRet as OkNegotiatedContentResult<PolSourceGrouping>;
                    PolSourceGrouping polSourceGroupingRet = Ret.Content;
                    Assert.AreEqual(polSourceGroupingLast.PolSourceGroupingID, polSourceGroupingRet.PolSourceGroupingID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added PolSourceGrouping
                    polSourceGroupingRet.PolSourceGroupingID = 0;
                    polSourceGroupingController.Request = new System.Net.Http.HttpRequestMessage();
                    polSourceGroupingController.Request.RequestUri = new System.Uri("http://localhost:5000/api/polSourceGrouping");
                    IHttpActionResult jsonRet3 = polSourceGroupingController.Post(polSourceGroupingRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<PolSourceGrouping> polSourceGroupingRet3 = jsonRet3 as CreatedNegotiatedContentResult<PolSourceGrouping>;
                    Assert.IsNotNull(polSourceGroupingRet3);
                    PolSourceGrouping polSourceGrouping = polSourceGroupingRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = polSourceGroupingController.Delete(polSourceGroupingRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<PolSourceGrouping> polSourceGroupingRet2 = jsonRet2 as OkNegotiatedContentResult<PolSourceGrouping>;
                    Assert.IsNotNull(polSourceGroupingRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because PolSourceGroupingID of 0 does not exist
                    polSourceGroupingRet.PolSourceGroupingID = 0;
                    IHttpActionResult jsonRet4 = polSourceGroupingController.Delete(polSourceGroupingRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<PolSourceGrouping> polSourceGroupingRet4 = jsonRet4 as OkNegotiatedContentResult<PolSourceGrouping>;
                    Assert.IsNull(polSourceGroupingRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
