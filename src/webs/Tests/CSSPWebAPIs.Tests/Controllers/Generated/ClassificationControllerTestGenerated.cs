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
    public partial class ClassificationControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ClassificationControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [TestMethod]
        public void Classification_Controller_GetClassificationList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ClassificationController classificationController = new ClassificationController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(classificationController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, classificationController.DatabaseType);

                    Classification classificationFirst = new Classification();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        ClassificationService classificationService = new ClassificationService(query, db, ContactID);
                        classificationFirst = (from c in db.Classifications select c).FirstOrDefault();
                        count = (from c in db.Classifications select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with Classification info
                    IHttpActionResult jsonRet = classificationController.GetClassificationList();
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<List<Classification>> ret = jsonRet as OkNegotiatedContentResult<List<Classification>>;
                    Assert.AreEqual(classificationFirst.ClassificationID, ret.Content[0].ClassificationID);
                    Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<Classification> classificationList = new List<Classification>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        ClassificationService classificationService = new ClassificationService(query, db, ContactID);
                        classificationList = (from c in db.Classifications select c).OrderBy(c => c.ClassificationID).Skip(0).Take(2).ToList();
                        count = (from c in db.Classifications select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with Classification info
                        jsonRet = classificationController.GetClassificationList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsNotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<Classification>>;
                        Assert.AreEqual(classificationList[0].ClassificationID, ret.Content[0].ClassificationID);
                        Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with Classification info
                           IHttpActionResult jsonRet2 = classificationController.GetClassificationList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.IsNotNull(jsonRet2);

                           OkNegotiatedContentResult<List<Classification>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<Classification>>;
                           Assert.AreEqual(classificationList[1].ClassificationID, ret2.Content[0].ClassificationID);
                           Assert.AreEqual((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [TestMethod]
        public void Classification_Controller_GetClassificationWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ClassificationController classificationController = new ClassificationController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(classificationController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, classificationController.DatabaseType);

                    Classification classificationFirst = new Classification();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        ClassificationService classificationService = new ClassificationService(new Query(), db, ContactID);
                        classificationFirst = (from c in db.Classifications select c).FirstOrDefault();
                    }

                    // ok with Classification info
                    IHttpActionResult jsonRet = classificationController.GetClassificationWithID(classificationFirst.ClassificationID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<Classification> Ret = jsonRet as OkNegotiatedContentResult<Classification>;
                    Classification classificationRet = Ret.Content;
                    Assert.AreEqual(classificationFirst.ClassificationID, classificationRet.ClassificationID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = classificationController.GetClassificationWithID(0);
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<Classification> classificationRet2 = jsonRet2 as OkNegotiatedContentResult<Classification>;
                    Assert.IsNull(classificationRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.IsNotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [TestMethod]
        public void Classification_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ClassificationController classificationController = new ClassificationController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(classificationController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, classificationController.DatabaseType);

                    Classification classificationLast = new Classification();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        ClassificationService classificationService = new ClassificationService(query, db, ContactID);
                        classificationLast = (from c in db.Classifications select c).FirstOrDefault();
                    }

                    // ok with Classification info
                    IHttpActionResult jsonRet = classificationController.GetClassificationWithID(classificationLast.ClassificationID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<Classification> Ret = jsonRet as OkNegotiatedContentResult<Classification>;
                    Classification classificationRet = Ret.Content;
                    Assert.AreEqual(classificationLast.ClassificationID, classificationRet.ClassificationID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because ClassificationID exist
                    IHttpActionResult jsonRet2 = classificationController.Post(classificationRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<Classification> classificationRet2 = jsonRet2 as OkNegotiatedContentResult<Classification>;
                    Assert.IsNull(classificationRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest2);

                    // Post to return newly added Classification
                    classificationRet.ClassificationID = 0;
                    classificationController.Request = new System.Net.Http.HttpRequestMessage();
                    classificationController.Request.RequestUri = new System.Uri("http://localhost:5000/api/classification");
                    IHttpActionResult jsonRet3 = classificationController.Post(classificationRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<Classification> classificationRet3 = jsonRet3 as CreatedNegotiatedContentResult<Classification>;
                    Assert.IsNotNull(classificationRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = classificationController.Delete(classificationRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<Classification> classificationRet4 = jsonRet4 as OkNegotiatedContentResult<Classification>;
                    Assert.IsNotNull(classificationRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [TestMethod]
        public void Classification_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ClassificationController classificationController = new ClassificationController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(classificationController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, classificationController.DatabaseType);

                    Classification classificationLast = new Classification();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        ClassificationService classificationService = new ClassificationService(query, db, ContactID);
                        classificationLast = (from c in db.Classifications select c).FirstOrDefault();
                    }

                    // ok with Classification info
                    IHttpActionResult jsonRet = classificationController.GetClassificationWithID(classificationLast.ClassificationID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<Classification> Ret = jsonRet as OkNegotiatedContentResult<Classification>;
                    Classification classificationRet = Ret.Content;
                    Assert.AreEqual(classificationLast.ClassificationID, classificationRet.ClassificationID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = classificationController.Put(classificationRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<Classification> classificationRet2 = jsonRet2 as OkNegotiatedContentResult<Classification>;
                    Assert.IsNotNull(classificationRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because ClassificationID of 0 does not exist
                    classificationRet.ClassificationID = 0;
                    IHttpActionResult jsonRet3 = classificationController.Put(classificationRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    OkNegotiatedContentResult<Classification> classificationRet3 = jsonRet3 as OkNegotiatedContentResult<Classification>;
                    Assert.IsNull(classificationRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [TestMethod]
        public void Classification_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ClassificationController classificationController = new ClassificationController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(classificationController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, classificationController.DatabaseType);

                    Classification classificationLast = new Classification();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        ClassificationService classificationService = new ClassificationService(query, db, ContactID);
                        classificationLast = (from c in db.Classifications select c).FirstOrDefault();
                    }

                    // ok with Classification info
                    IHttpActionResult jsonRet = classificationController.GetClassificationWithID(classificationLast.ClassificationID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<Classification> Ret = jsonRet as OkNegotiatedContentResult<Classification>;
                    Classification classificationRet = Ret.Content;
                    Assert.AreEqual(classificationLast.ClassificationID, classificationRet.ClassificationID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added Classification
                    classificationRet.ClassificationID = 0;
                    classificationController.Request = new System.Net.Http.HttpRequestMessage();
                    classificationController.Request.RequestUri = new System.Uri("http://localhost:5000/api/classification");
                    IHttpActionResult jsonRet3 = classificationController.Post(classificationRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<Classification> classificationRet3 = jsonRet3 as CreatedNegotiatedContentResult<Classification>;
                    Assert.IsNotNull(classificationRet3);
                    Classification classification = classificationRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = classificationController.Delete(classificationRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<Classification> classificationRet2 = jsonRet2 as OkNegotiatedContentResult<Classification>;
                    Assert.IsNotNull(classificationRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because ClassificationID of 0 does not exist
                    classificationRet.ClassificationID = 0;
                    IHttpActionResult jsonRet4 = classificationController.Delete(classificationRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<Classification> classificationRet4 = jsonRet4 as OkNegotiatedContentResult<Classification>;
                    Assert.IsNull(classificationRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
