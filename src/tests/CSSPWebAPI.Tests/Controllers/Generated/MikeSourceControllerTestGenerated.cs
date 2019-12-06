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
    public partial class MikeSourceControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MikeSourceControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [TestMethod]
        public void MikeSource_Controller_GetMikeSourceList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MikeSourceController mikeSourceController = new MikeSourceController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mikeSourceController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mikeSourceController.DatabaseType);

                    MikeSource mikeSourceFirst = new MikeSource();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        MikeSourceService mikeSourceService = new MikeSourceService(query, db, ContactID);
                        mikeSourceFirst = (from c in db.MikeSources select c).FirstOrDefault();
                        count = (from c in db.MikeSources select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with MikeSource info
                    IHttpActionResult jsonRet = mikeSourceController.GetMikeSourceList();
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<List<MikeSource>> ret = jsonRet as OkNegotiatedContentResult<List<MikeSource>>;
                    Assert.AreEqual(mikeSourceFirst.MikeSourceID, ret.Content[0].MikeSourceID);
                    Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<MikeSource> mikeSourceList = new List<MikeSource>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        MikeSourceService mikeSourceService = new MikeSourceService(query, db, ContactID);
                        mikeSourceList = (from c in db.MikeSources select c).OrderBy(c => c.MikeSourceID).Skip(0).Take(2).ToList();
                        count = (from c in db.MikeSources select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with MikeSource info
                        jsonRet = mikeSourceController.GetMikeSourceList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsNotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<MikeSource>>;
                        Assert.AreEqual(mikeSourceList[0].MikeSourceID, ret.Content[0].MikeSourceID);
                        Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with MikeSource info
                           IHttpActionResult jsonRet2 = mikeSourceController.GetMikeSourceList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.IsNotNull(jsonRet2);

                           OkNegotiatedContentResult<List<MikeSource>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<MikeSource>>;
                           Assert.AreEqual(mikeSourceList[1].MikeSourceID, ret2.Content[0].MikeSourceID);
                           Assert.AreEqual((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [TestMethod]
        public void MikeSource_Controller_GetMikeSourceWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MikeSourceController mikeSourceController = new MikeSourceController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mikeSourceController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mikeSourceController.DatabaseType);

                    MikeSource mikeSourceFirst = new MikeSource();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        MikeSourceService mikeSourceService = new MikeSourceService(new Query(), db, ContactID);
                        mikeSourceFirst = (from c in db.MikeSources select c).FirstOrDefault();
                    }

                    // ok with MikeSource info
                    IHttpActionResult jsonRet = mikeSourceController.GetMikeSourceWithID(mikeSourceFirst.MikeSourceID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<MikeSource> Ret = jsonRet as OkNegotiatedContentResult<MikeSource>;
                    MikeSource mikeSourceRet = Ret.Content;
                    Assert.AreEqual(mikeSourceFirst.MikeSourceID, mikeSourceRet.MikeSourceID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = mikeSourceController.GetMikeSourceWithID(0);
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<MikeSource> mikeSourceRet2 = jsonRet2 as OkNegotiatedContentResult<MikeSource>;
                    Assert.IsNull(mikeSourceRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.IsNotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [TestMethod]
        public void MikeSource_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MikeSourceController mikeSourceController = new MikeSourceController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mikeSourceController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mikeSourceController.DatabaseType);

                    MikeSource mikeSourceLast = new MikeSource();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MikeSourceService mikeSourceService = new MikeSourceService(query, db, ContactID);
                        mikeSourceLast = (from c in db.MikeSources select c).FirstOrDefault();
                    }

                    // ok with MikeSource info
                    IHttpActionResult jsonRet = mikeSourceController.GetMikeSourceWithID(mikeSourceLast.MikeSourceID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<MikeSource> Ret = jsonRet as OkNegotiatedContentResult<MikeSource>;
                    MikeSource mikeSourceRet = Ret.Content;
                    Assert.AreEqual(mikeSourceLast.MikeSourceID, mikeSourceRet.MikeSourceID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because MikeSourceID exist
                    IHttpActionResult jsonRet2 = mikeSourceController.Post(mikeSourceRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<MikeSource> mikeSourceRet2 = jsonRet2 as OkNegotiatedContentResult<MikeSource>;
                    Assert.IsNull(mikeSourceRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest2);

                    // Post to return newly added MikeSource
                    mikeSourceRet.MikeSourceID = 0;
                    mikeSourceController.Request = new System.Net.Http.HttpRequestMessage();
                    mikeSourceController.Request.RequestUri = new System.Uri("http://localhost:5000/api/mikeSource");
                    IHttpActionResult jsonRet3 = mikeSourceController.Post(mikeSourceRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<MikeSource> mikeSourceRet3 = jsonRet3 as CreatedNegotiatedContentResult<MikeSource>;
                    Assert.IsNotNull(mikeSourceRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = mikeSourceController.Delete(mikeSourceRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<MikeSource> mikeSourceRet4 = jsonRet4 as OkNegotiatedContentResult<MikeSource>;
                    Assert.IsNotNull(mikeSourceRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [TestMethod]
        public void MikeSource_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MikeSourceController mikeSourceController = new MikeSourceController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mikeSourceController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mikeSourceController.DatabaseType);

                    MikeSource mikeSourceLast = new MikeSource();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        MikeSourceService mikeSourceService = new MikeSourceService(query, db, ContactID);
                        mikeSourceLast = (from c in db.MikeSources select c).FirstOrDefault();
                    }

                    // ok with MikeSource info
                    IHttpActionResult jsonRet = mikeSourceController.GetMikeSourceWithID(mikeSourceLast.MikeSourceID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<MikeSource> Ret = jsonRet as OkNegotiatedContentResult<MikeSource>;
                    MikeSource mikeSourceRet = Ret.Content;
                    Assert.AreEqual(mikeSourceLast.MikeSourceID, mikeSourceRet.MikeSourceID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = mikeSourceController.Put(mikeSourceRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<MikeSource> mikeSourceRet2 = jsonRet2 as OkNegotiatedContentResult<MikeSource>;
                    Assert.IsNotNull(mikeSourceRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because MikeSourceID of 0 does not exist
                    mikeSourceRet.MikeSourceID = 0;
                    IHttpActionResult jsonRet3 = mikeSourceController.Put(mikeSourceRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    OkNegotiatedContentResult<MikeSource> mikeSourceRet3 = jsonRet3 as OkNegotiatedContentResult<MikeSource>;
                    Assert.IsNull(mikeSourceRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [TestMethod]
        public void MikeSource_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MikeSourceController mikeSourceController = new MikeSourceController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mikeSourceController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mikeSourceController.DatabaseType);

                    MikeSource mikeSourceLast = new MikeSource();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MikeSourceService mikeSourceService = new MikeSourceService(query, db, ContactID);
                        mikeSourceLast = (from c in db.MikeSources select c).FirstOrDefault();
                    }

                    // ok with MikeSource info
                    IHttpActionResult jsonRet = mikeSourceController.GetMikeSourceWithID(mikeSourceLast.MikeSourceID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<MikeSource> Ret = jsonRet as OkNegotiatedContentResult<MikeSource>;
                    MikeSource mikeSourceRet = Ret.Content;
                    Assert.AreEqual(mikeSourceLast.MikeSourceID, mikeSourceRet.MikeSourceID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added MikeSource
                    mikeSourceRet.MikeSourceID = 0;
                    mikeSourceController.Request = new System.Net.Http.HttpRequestMessage();
                    mikeSourceController.Request.RequestUri = new System.Uri("http://localhost:5000/api/mikeSource");
                    IHttpActionResult jsonRet3 = mikeSourceController.Post(mikeSourceRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<MikeSource> mikeSourceRet3 = jsonRet3 as CreatedNegotiatedContentResult<MikeSource>;
                    Assert.IsNotNull(mikeSourceRet3);
                    MikeSource mikeSource = mikeSourceRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = mikeSourceController.Delete(mikeSourceRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<MikeSource> mikeSourceRet2 = jsonRet2 as OkNegotiatedContentResult<MikeSource>;
                    Assert.IsNotNull(mikeSourceRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because MikeSourceID of 0 does not exist
                    mikeSourceRet.MikeSourceID = 0;
                    IHttpActionResult jsonRet4 = mikeSourceController.Delete(mikeSourceRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<MikeSource> mikeSourceRet4 = jsonRet4 as OkNegotiatedContentResult<MikeSource>;
                    Assert.IsNull(mikeSourceRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
