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
    public partial class MikeSourceStartEndControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MikeSourceStartEndControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [TestMethod]
        public void MikeSourceStartEnd_Controller_GetMikeSourceStartEndList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MikeSourceStartEndController mikeSourceStartEndController = new MikeSourceStartEndController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mikeSourceStartEndController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mikeSourceStartEndController.DatabaseType);

                    MikeSourceStartEnd mikeSourceStartEndFirst = new MikeSourceStartEnd();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        MikeSourceStartEndService mikeSourceStartEndService = new MikeSourceStartEndService(query, db, ContactID);
                        mikeSourceStartEndFirst = (from c in db.MikeSourceStartEnds select c).FirstOrDefault();
                        count = (from c in db.MikeSourceStartEnds select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with MikeSourceStartEnd info
                    IHttpActionResult jsonRet = mikeSourceStartEndController.GetMikeSourceStartEndList();
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<List<MikeSourceStartEnd>> ret = jsonRet as OkNegotiatedContentResult<List<MikeSourceStartEnd>>;
                    Assert.AreEqual(mikeSourceStartEndFirst.MikeSourceStartEndID, ret.Content[0].MikeSourceStartEndID);
                    Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<MikeSourceStartEnd> mikeSourceStartEndList = new List<MikeSourceStartEnd>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        MikeSourceStartEndService mikeSourceStartEndService = new MikeSourceStartEndService(query, db, ContactID);
                        mikeSourceStartEndList = (from c in db.MikeSourceStartEnds select c).OrderBy(c => c.MikeSourceStartEndID).Skip(0).Take(2).ToList();
                        count = (from c in db.MikeSourceStartEnds select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with MikeSourceStartEnd info
                        jsonRet = mikeSourceStartEndController.GetMikeSourceStartEndList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsNotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<MikeSourceStartEnd>>;
                        Assert.AreEqual(mikeSourceStartEndList[0].MikeSourceStartEndID, ret.Content[0].MikeSourceStartEndID);
                        Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with MikeSourceStartEnd info
                           IHttpActionResult jsonRet2 = mikeSourceStartEndController.GetMikeSourceStartEndList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.IsNotNull(jsonRet2);

                           OkNegotiatedContentResult<List<MikeSourceStartEnd>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<MikeSourceStartEnd>>;
                           Assert.AreEqual(mikeSourceStartEndList[1].MikeSourceStartEndID, ret2.Content[0].MikeSourceStartEndID);
                           Assert.AreEqual((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [TestMethod]
        public void MikeSourceStartEnd_Controller_GetMikeSourceStartEndWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MikeSourceStartEndController mikeSourceStartEndController = new MikeSourceStartEndController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mikeSourceStartEndController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mikeSourceStartEndController.DatabaseType);

                    MikeSourceStartEnd mikeSourceStartEndFirst = new MikeSourceStartEnd();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        MikeSourceStartEndService mikeSourceStartEndService = new MikeSourceStartEndService(new Query(), db, ContactID);
                        mikeSourceStartEndFirst = (from c in db.MikeSourceStartEnds select c).FirstOrDefault();
                    }

                    // ok with MikeSourceStartEnd info
                    IHttpActionResult jsonRet = mikeSourceStartEndController.GetMikeSourceStartEndWithID(mikeSourceStartEndFirst.MikeSourceStartEndID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<MikeSourceStartEnd> Ret = jsonRet as OkNegotiatedContentResult<MikeSourceStartEnd>;
                    MikeSourceStartEnd mikeSourceStartEndRet = Ret.Content;
                    Assert.AreEqual(mikeSourceStartEndFirst.MikeSourceStartEndID, mikeSourceStartEndRet.MikeSourceStartEndID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = mikeSourceStartEndController.GetMikeSourceStartEndWithID(0);
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<MikeSourceStartEnd> mikeSourceStartEndRet2 = jsonRet2 as OkNegotiatedContentResult<MikeSourceStartEnd>;
                    Assert.IsNull(mikeSourceStartEndRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.IsNotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [TestMethod]
        public void MikeSourceStartEnd_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MikeSourceStartEndController mikeSourceStartEndController = new MikeSourceStartEndController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mikeSourceStartEndController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mikeSourceStartEndController.DatabaseType);

                    MikeSourceStartEnd mikeSourceStartEndLast = new MikeSourceStartEnd();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MikeSourceStartEndService mikeSourceStartEndService = new MikeSourceStartEndService(query, db, ContactID);
                        mikeSourceStartEndLast = (from c in db.MikeSourceStartEnds select c).FirstOrDefault();
                    }

                    // ok with MikeSourceStartEnd info
                    IHttpActionResult jsonRet = mikeSourceStartEndController.GetMikeSourceStartEndWithID(mikeSourceStartEndLast.MikeSourceStartEndID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<MikeSourceStartEnd> Ret = jsonRet as OkNegotiatedContentResult<MikeSourceStartEnd>;
                    MikeSourceStartEnd mikeSourceStartEndRet = Ret.Content;
                    Assert.AreEqual(mikeSourceStartEndLast.MikeSourceStartEndID, mikeSourceStartEndRet.MikeSourceStartEndID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because MikeSourceStartEndID exist
                    IHttpActionResult jsonRet2 = mikeSourceStartEndController.Post(mikeSourceStartEndRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<MikeSourceStartEnd> mikeSourceStartEndRet2 = jsonRet2 as OkNegotiatedContentResult<MikeSourceStartEnd>;
                    Assert.IsNull(mikeSourceStartEndRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest2);

                    // Post to return newly added MikeSourceStartEnd
                    mikeSourceStartEndRet.MikeSourceStartEndID = 0;
                    mikeSourceStartEndController.Request = new System.Net.Http.HttpRequestMessage();
                    mikeSourceStartEndController.Request.RequestUri = new System.Uri("http://localhost:5000/api/mikeSourceStartEnd");
                    IHttpActionResult jsonRet3 = mikeSourceStartEndController.Post(mikeSourceStartEndRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<MikeSourceStartEnd> mikeSourceStartEndRet3 = jsonRet3 as CreatedNegotiatedContentResult<MikeSourceStartEnd>;
                    Assert.IsNotNull(mikeSourceStartEndRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = mikeSourceStartEndController.Delete(mikeSourceStartEndRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<MikeSourceStartEnd> mikeSourceStartEndRet4 = jsonRet4 as OkNegotiatedContentResult<MikeSourceStartEnd>;
                    Assert.IsNotNull(mikeSourceStartEndRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [TestMethod]
        public void MikeSourceStartEnd_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MikeSourceStartEndController mikeSourceStartEndController = new MikeSourceStartEndController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mikeSourceStartEndController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mikeSourceStartEndController.DatabaseType);

                    MikeSourceStartEnd mikeSourceStartEndLast = new MikeSourceStartEnd();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        MikeSourceStartEndService mikeSourceStartEndService = new MikeSourceStartEndService(query, db, ContactID);
                        mikeSourceStartEndLast = (from c in db.MikeSourceStartEnds select c).FirstOrDefault();
                    }

                    // ok with MikeSourceStartEnd info
                    IHttpActionResult jsonRet = mikeSourceStartEndController.GetMikeSourceStartEndWithID(mikeSourceStartEndLast.MikeSourceStartEndID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<MikeSourceStartEnd> Ret = jsonRet as OkNegotiatedContentResult<MikeSourceStartEnd>;
                    MikeSourceStartEnd mikeSourceStartEndRet = Ret.Content;
                    Assert.AreEqual(mikeSourceStartEndLast.MikeSourceStartEndID, mikeSourceStartEndRet.MikeSourceStartEndID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = mikeSourceStartEndController.Put(mikeSourceStartEndRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<MikeSourceStartEnd> mikeSourceStartEndRet2 = jsonRet2 as OkNegotiatedContentResult<MikeSourceStartEnd>;
                    Assert.IsNotNull(mikeSourceStartEndRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because MikeSourceStartEndID of 0 does not exist
                    mikeSourceStartEndRet.MikeSourceStartEndID = 0;
                    IHttpActionResult jsonRet3 = mikeSourceStartEndController.Put(mikeSourceStartEndRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    OkNegotiatedContentResult<MikeSourceStartEnd> mikeSourceStartEndRet3 = jsonRet3 as OkNegotiatedContentResult<MikeSourceStartEnd>;
                    Assert.IsNull(mikeSourceStartEndRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [TestMethod]
        public void MikeSourceStartEnd_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MikeSourceStartEndController mikeSourceStartEndController = new MikeSourceStartEndController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(mikeSourceStartEndController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, mikeSourceStartEndController.DatabaseType);

                    MikeSourceStartEnd mikeSourceStartEndLast = new MikeSourceStartEnd();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MikeSourceStartEndService mikeSourceStartEndService = new MikeSourceStartEndService(query, db, ContactID);
                        mikeSourceStartEndLast = (from c in db.MikeSourceStartEnds select c).FirstOrDefault();
                    }

                    // ok with MikeSourceStartEnd info
                    IHttpActionResult jsonRet = mikeSourceStartEndController.GetMikeSourceStartEndWithID(mikeSourceStartEndLast.MikeSourceStartEndID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<MikeSourceStartEnd> Ret = jsonRet as OkNegotiatedContentResult<MikeSourceStartEnd>;
                    MikeSourceStartEnd mikeSourceStartEndRet = Ret.Content;
                    Assert.AreEqual(mikeSourceStartEndLast.MikeSourceStartEndID, mikeSourceStartEndRet.MikeSourceStartEndID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added MikeSourceStartEnd
                    mikeSourceStartEndRet.MikeSourceStartEndID = 0;
                    mikeSourceStartEndController.Request = new System.Net.Http.HttpRequestMessage();
                    mikeSourceStartEndController.Request.RequestUri = new System.Uri("http://localhost:5000/api/mikeSourceStartEnd");
                    IHttpActionResult jsonRet3 = mikeSourceStartEndController.Post(mikeSourceStartEndRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<MikeSourceStartEnd> mikeSourceStartEndRet3 = jsonRet3 as CreatedNegotiatedContentResult<MikeSourceStartEnd>;
                    Assert.IsNotNull(mikeSourceStartEndRet3);
                    MikeSourceStartEnd mikeSourceStartEnd = mikeSourceStartEndRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = mikeSourceStartEndController.Delete(mikeSourceStartEndRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<MikeSourceStartEnd> mikeSourceStartEndRet2 = jsonRet2 as OkNegotiatedContentResult<MikeSourceStartEnd>;
                    Assert.IsNotNull(mikeSourceStartEndRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because MikeSourceStartEndID of 0 does not exist
                    mikeSourceStartEndRet.MikeSourceStartEndID = 0;
                    IHttpActionResult jsonRet4 = mikeSourceStartEndController.Delete(mikeSourceStartEndRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<MikeSourceStartEnd> mikeSourceStartEndRet4 = jsonRet4 as OkNegotiatedContentResult<MikeSourceStartEnd>;
                    Assert.IsNull(mikeSourceStartEndRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
