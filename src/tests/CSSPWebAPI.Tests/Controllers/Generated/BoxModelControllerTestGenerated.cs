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
        [Fact]
        public void BoxModel_Controller_GetBoxModelList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    BoxModelController boxModelController = new BoxModelController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(boxModelController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, boxModelController.DatabaseType);

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
                    IActionResult jsonRet = boxModelController.GetBoxModelList();
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<List<BoxModel>> ret = jsonRet as OkNegotiatedContentResult<List<BoxModel>>;
                    Assert.Equal(boxModelFirst.BoxModelID, ret.Content[0].BoxModelID);
                    Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

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
                        Assert.NotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<BoxModel>>;
                        Assert.Equal(boxModelList[0].BoxModelID, ret.Content[0].BoxModelID);
                        Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with BoxModel info
                           IActionResult jsonRet2 = boxModelController.GetBoxModelList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkNegotiatedContentResult<List<BoxModel>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<BoxModel>>;
                           Assert.Equal(boxModelList[1].BoxModelID, ret2.Content[0].BoxModelID);
                           Assert.Equal((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void BoxModel_Controller_GetBoxModelWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    BoxModelController boxModelController = new BoxModelController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(boxModelController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, boxModelController.DatabaseType);

                    BoxModel boxModelFirst = new BoxModel();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        BoxModelService boxModelService = new BoxModelService(new Query(), db, ContactID);
                        boxModelFirst = (from c in db.BoxModels select c).FirstOrDefault();
                    }

                    // ok with BoxModel info
                    IActionResult jsonRet = boxModelController.GetBoxModelWithID(boxModelFirst.BoxModelID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<BoxModel> Ret = jsonRet as OkNegotiatedContentResult<BoxModel>;
                    BoxModel boxModelRet = Ret.Content;
                    Assert.Equal(boxModelFirst.BoxModelID, boxModelRet.BoxModelID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = boxModelController.GetBoxModelWithID(0);
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<BoxModel> boxModelRet2 = jsonRet2 as OkNegotiatedContentResult<BoxModel>;
                    Assert.Null(boxModelRet2);

                    NotFoundObjectResult notFoundRequest = jsonRet2 as NotFoundObjectResult;
                    Assert.NotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void BoxModel_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    BoxModelController boxModelController = new BoxModelController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(boxModelController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, boxModelController.DatabaseType);

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
                    IActionResult jsonRet = boxModelController.GetBoxModelWithID(boxModelLast.BoxModelID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<BoxModel> Ret = jsonRet as OkNegotiatedContentResult<BoxModel>;
                    BoxModel boxModelRet = Ret.Content;
                    Assert.Equal(boxModelLast.BoxModelID, boxModelRet.BoxModelID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because BoxModelID exist
                    IActionResult jsonRet2 = boxModelController.Post(boxModelRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<BoxModel> boxModelRet2 = jsonRet2 as OkNegotiatedContentResult<BoxModel>;
                    Assert.Null(boxModelRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added BoxModel
                    boxModelRet.BoxModelID = 0;
                    IActionResult jsonRet3 = boxModelController.Post(boxModelRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<BoxModel> boxModelRet3 = jsonRet3 as CreatedNegotiatedContentResult<BoxModel>;
                    Assert.NotNull(boxModelRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = boxModelController.Delete(boxModelRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<BoxModel> boxModelRet4 = jsonRet4 as OkNegotiatedContentResult<BoxModel>;
                    Assert.NotNull(boxModelRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [Fact]
        public void BoxModel_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    BoxModelController boxModelController = new BoxModelController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(boxModelController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, boxModelController.DatabaseType);

                    BoxModel boxModelLast = new BoxModel();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        BoxModelService boxModelService = new BoxModelService(query, db, ContactID);
                        boxModelLast = (from c in db.BoxModels select c).FirstOrDefault();
                    }

                    // ok with BoxModel info
                    IActionResult jsonRet = boxModelController.GetBoxModelWithID(boxModelLast.BoxModelID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<BoxModel> Ret = jsonRet as OkNegotiatedContentResult<BoxModel>;
                    BoxModel boxModelRet = Ret.Content;
                    Assert.Equal(boxModelLast.BoxModelID, boxModelRet.BoxModelID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = boxModelController.Put(boxModelRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<BoxModel> boxModelRet2 = jsonRet2 as OkNegotiatedContentResult<BoxModel>;
                    Assert.NotNull(boxModelRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because BoxModelID of 0 does not exist
                    boxModelRet.BoxModelID = 0;
                    IActionResult jsonRet3 = boxModelController.Put(boxModelRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    OkNegotiatedContentResult<BoxModel> boxModelRet3 = jsonRet3 as OkNegotiatedContentResult<BoxModel>;
                    Assert.Null(boxModelRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void BoxModel_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    BoxModelController boxModelController = new BoxModelController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(boxModelController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, boxModelController.DatabaseType);

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
                    IActionResult jsonRet = boxModelController.GetBoxModelWithID(boxModelLast.BoxModelID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<BoxModel> Ret = jsonRet as OkNegotiatedContentResult<BoxModel>;
                    BoxModel boxModelRet = Ret.Content;
                    Assert.Equal(boxModelLast.BoxModelID, boxModelRet.BoxModelID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return newly added BoxModel
                    boxModelRet.BoxModelID = 0;
                    IActionResult jsonRet3 = boxModelController.Post(boxModelRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<BoxModel> boxModelRet3 = jsonRet3 as CreatedNegotiatedContentResult<BoxModel>;
                    Assert.NotNull(boxModelRet3);
                    BoxModel boxModel = boxModelRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = boxModelController.Delete(boxModelRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<BoxModel> boxModelRet2 = jsonRet2 as OkNegotiatedContentResult<BoxModel>;
                    Assert.NotNull(boxModelRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because BoxModelID of 0 does not exist
                    boxModelRet.BoxModelID = 0;
                    IActionResult jsonRet4 = boxModelController.Delete(boxModelRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<BoxModel> boxModelRet4 = jsonRet4 as OkNegotiatedContentResult<BoxModel>;
                    Assert.Null(boxModelRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
