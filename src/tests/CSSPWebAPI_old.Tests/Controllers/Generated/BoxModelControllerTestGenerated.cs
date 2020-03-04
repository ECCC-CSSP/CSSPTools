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
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(boxModelFirst.BoxModelID, ((List<BoxModel>)ret.Value)[0].BoxModelID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<BoxModel>)ret.Value).Count);

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
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(boxModelList[0].BoxModelID, ((List<BoxModel>)ret.Value)[0].BoxModelID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<BoxModel>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with BoxModel info
                           IActionResult jsonRet2 = boxModelController.GetBoxModelList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(boxModelList[1].BoxModelID, ((List<BoxModel>)ret2.Value)[0].BoxModelID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<BoxModel>)ret2.Value).Count);
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
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(boxModelFirst.BoxModelID, ((BoxModel)ret.Value).BoxModelID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = boxModelController.GetBoxModelWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult boxModelRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(boxModelRet2);
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

                    BoxModel boxModelFirst = new BoxModel();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        BoxModelService boxModelService = new BoxModelService(query, db, ContactID);
                        boxModelFirst = (from c in db.BoxModels select c).FirstOrDefault();
                    }

                    // ok with BoxModel info
                    IActionResult jsonRet = boxModelController.GetBoxModelWithID(boxModelFirst.BoxModelID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    BoxModel boxModelRet = (BoxModel)ret.Value;
                    Assert.Equal(boxModelFirst.BoxModelID, boxModelRet.BoxModelID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because BoxModelID exist
                    IActionResult jsonRet2 = boxModelController.Post(boxModelRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added BoxModel
                    boxModelRet.BoxModelID = 0;
                    IActionResult jsonRet3 = boxModelController.Post(boxModelRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = boxModelController.Delete(boxModelRet, LanguageRequest.ToString());
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
        public void BoxModel_Controller_Put_Test()
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
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        BoxModelService boxModelService = new BoxModelService(query, db, ContactID);
                        boxModelFirst = (from c in db.BoxModels select c).FirstOrDefault();
                    }

                    // ok with BoxModel info
                    IActionResult jsonRet = boxModelController.GetBoxModelWithID(boxModelFirst.BoxModelID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    BoxModel boxModelRet = (BoxModel)Ret.Value;
                    Assert.Equal(boxModelFirst.BoxModelID, boxModelRet.BoxModelID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = boxModelController.Put(boxModelRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult boxModelRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(boxModelRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because BoxModelID of 0 does not exist
                    boxModelRet.BoxModelID = 0;
                    IActionResult jsonRet3 = boxModelController.Put(boxModelRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult boxModelRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(boxModelRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
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

                    BoxModel boxModelFirst = new BoxModel();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        BoxModelService boxModelService = new BoxModelService(query, db, ContactID);
                        boxModelFirst = (from c in db.BoxModels select c).FirstOrDefault();
                    }

                    // ok with BoxModel info
                    IActionResult jsonRet = boxModelController.GetBoxModelWithID(boxModelFirst.BoxModelID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    BoxModel boxModelRet = (BoxModel)Ret.Value;
                    Assert.Equal(boxModelFirst.BoxModelID, boxModelRet.BoxModelID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added BoxModel
                    boxModelRet.BoxModelID = 0;
                    IActionResult jsonRet3 = boxModelController.Post(boxModelRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    BoxModel boxModel = (BoxModel)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = boxModelController.Delete(boxModelRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because BoxModelID of 0 does not exist
                    boxModelRet.BoxModelID = 0;
                    IActionResult jsonRet4 = boxModelController.Delete(boxModelRet, LanguageRequest.ToString());
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
