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
    public partial class BoxModelControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public BoxModelControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [TestMethod]
        public void BoxModel_Controller_GetBoxModelList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    BoxModelController boxModelController = new BoxModelController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(boxModelController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, boxModelController.DatabaseType);

                    BoxModel boxModelFirst = new BoxModel();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        BoxModelService boxModelService = new BoxModelService(query, db, ContactID);
                        boxModelFirst = (from c in db.BoxModels select c).FirstOrDefault();
                        count = (from c in db.BoxModels select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with BoxModel info
                    IHttpActionResult jsonRet = boxModelController.GetBoxModelList();
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<List<BoxModel>> ret = jsonRet as OkNegotiatedContentResult<List<BoxModel>>;
                    Assert.AreEqual(boxModelFirst.BoxModelID, ret.Content[0].BoxModelID);
                    Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<BoxModel> boxModelList = new List<BoxModel>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        BoxModelService boxModelService = new BoxModelService(query, db, ContactID);
                        boxModelList = (from c in db.BoxModels select c).OrderBy(c => c.BoxModelID).Skip(0).Take(2).ToList();
                        count = (from c in db.BoxModels select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with BoxModel info
                        jsonRet = boxModelController.GetBoxModelList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsNotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<BoxModel>>;
                        Assert.AreEqual(boxModelList[0].BoxModelID, ret.Content[0].BoxModelID);
                        Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with BoxModel info
                           IHttpActionResult jsonRet2 = boxModelController.GetBoxModelList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.IsNotNull(jsonRet2);

                           OkNegotiatedContentResult<List<BoxModel>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<BoxModel>>;
                           Assert.AreEqual(boxModelList[1].BoxModelID, ret2.Content[0].BoxModelID);
                           Assert.AreEqual((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [TestMethod]
        public void BoxModel_Controller_GetBoxModelWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    BoxModelController boxModelController = new BoxModelController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(boxModelController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, boxModelController.DatabaseType);

                    BoxModel boxModelFirst = new BoxModel();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        BoxModelService boxModelService = new BoxModelService(new Query(), db, ContactID);
                        boxModelFirst = (from c in db.BoxModels select c).FirstOrDefault();
                    }

                    // ok with BoxModel info
                    IHttpActionResult jsonRet = boxModelController.GetBoxModelWithID(boxModelFirst.BoxModelID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<BoxModel> Ret = jsonRet as OkNegotiatedContentResult<BoxModel>;
                    BoxModel boxModelRet = Ret.Content;
                    Assert.AreEqual(boxModelFirst.BoxModelID, boxModelRet.BoxModelID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = boxModelController.GetBoxModelWithID(0);
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<BoxModel> boxModelRet2 = jsonRet2 as OkNegotiatedContentResult<BoxModel>;
                    Assert.IsNull(boxModelRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.IsNotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [TestMethod]
        public void BoxModel_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    BoxModelController boxModelController = new BoxModelController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(boxModelController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, boxModelController.DatabaseType);

                    BoxModel boxModelLast = new BoxModel();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        BoxModelService boxModelService = new BoxModelService(query, db, ContactID);
                        boxModelLast = (from c in db.BoxModels select c).FirstOrDefault();
                    }

                    // ok with BoxModel info
                    IHttpActionResult jsonRet = boxModelController.GetBoxModelWithID(boxModelLast.BoxModelID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<BoxModel> Ret = jsonRet as OkNegotiatedContentResult<BoxModel>;
                    BoxModel boxModelRet = Ret.Content;
                    Assert.AreEqual(boxModelLast.BoxModelID, boxModelRet.BoxModelID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because BoxModelID exist
                    IHttpActionResult jsonRet2 = boxModelController.Post(boxModelRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<BoxModel> boxModelRet2 = jsonRet2 as OkNegotiatedContentResult<BoxModel>;
                    Assert.IsNull(boxModelRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest2);

                    // Post to return newly added BoxModel
                    boxModelRet.BoxModelID = 0;
                    boxModelController.Request = new System.Net.Http.HttpRequestMessage();
                    boxModelController.Request.RequestUri = new System.Uri("http://localhost:5000/api/boxModel");
                    IHttpActionResult jsonRet3 = boxModelController.Post(boxModelRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<BoxModel> boxModelRet3 = jsonRet3 as CreatedNegotiatedContentResult<BoxModel>;
                    Assert.IsNotNull(boxModelRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = boxModelController.Delete(boxModelRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<BoxModel> boxModelRet4 = jsonRet4 as OkNegotiatedContentResult<BoxModel>;
                    Assert.IsNotNull(boxModelRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [TestMethod]
        public void BoxModel_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    BoxModelController boxModelController = new BoxModelController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(boxModelController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, boxModelController.DatabaseType);

                    BoxModel boxModelLast = new BoxModel();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        BoxModelService boxModelService = new BoxModelService(query, db, ContactID);
                        boxModelLast = (from c in db.BoxModels select c).FirstOrDefault();
                    }

                    // ok with BoxModel info
                    IHttpActionResult jsonRet = boxModelController.GetBoxModelWithID(boxModelLast.BoxModelID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<BoxModel> Ret = jsonRet as OkNegotiatedContentResult<BoxModel>;
                    BoxModel boxModelRet = Ret.Content;
                    Assert.AreEqual(boxModelLast.BoxModelID, boxModelRet.BoxModelID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = boxModelController.Put(boxModelRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<BoxModel> boxModelRet2 = jsonRet2 as OkNegotiatedContentResult<BoxModel>;
                    Assert.IsNotNull(boxModelRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because BoxModelID of 0 does not exist
                    boxModelRet.BoxModelID = 0;
                    IHttpActionResult jsonRet3 = boxModelController.Put(boxModelRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    OkNegotiatedContentResult<BoxModel> boxModelRet3 = jsonRet3 as OkNegotiatedContentResult<BoxModel>;
                    Assert.IsNull(boxModelRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [TestMethod]
        public void BoxModel_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    BoxModelController boxModelController = new BoxModelController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(boxModelController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, boxModelController.DatabaseType);

                    BoxModel boxModelLast = new BoxModel();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        BoxModelService boxModelService = new BoxModelService(query, db, ContactID);
                        boxModelLast = (from c in db.BoxModels select c).FirstOrDefault();
                    }

                    // ok with BoxModel info
                    IHttpActionResult jsonRet = boxModelController.GetBoxModelWithID(boxModelLast.BoxModelID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<BoxModel> Ret = jsonRet as OkNegotiatedContentResult<BoxModel>;
                    BoxModel boxModelRet = Ret.Content;
                    Assert.AreEqual(boxModelLast.BoxModelID, boxModelRet.BoxModelID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added BoxModel
                    boxModelRet.BoxModelID = 0;
                    boxModelController.Request = new System.Net.Http.HttpRequestMessage();
                    boxModelController.Request.RequestUri = new System.Uri("http://localhost:5000/api/boxModel");
                    IHttpActionResult jsonRet3 = boxModelController.Post(boxModelRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<BoxModel> boxModelRet3 = jsonRet3 as CreatedNegotiatedContentResult<BoxModel>;
                    Assert.IsNotNull(boxModelRet3);
                    BoxModel boxModel = boxModelRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = boxModelController.Delete(boxModelRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<BoxModel> boxModelRet2 = jsonRet2 as OkNegotiatedContentResult<BoxModel>;
                    Assert.IsNotNull(boxModelRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because BoxModelID of 0 does not exist
                    boxModelRet.BoxModelID = 0;
                    IHttpActionResult jsonRet4 = boxModelController.Delete(boxModelRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<BoxModel> boxModelRet4 = jsonRet4 as OkNegotiatedContentResult<BoxModel>;
                    Assert.IsNull(boxModelRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
