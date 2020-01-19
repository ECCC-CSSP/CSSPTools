using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Xunit;
using CSSPWebAPI.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;

namespace CSSPWebAPI.Tests.Controllers
{
    public partial class BoxModelLanguageControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public BoxModelLanguageControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void BoxModelLanguage_Controller_GetBoxModelLanguageList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    BoxModelLanguageController boxModelLanguageController = new BoxModelLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(boxModelLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, boxModelLanguageController.DatabaseType);

                    BoxModelLanguage boxModelLanguageFirst = new BoxModelLanguage();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        BoxModelLanguageService boxModelLanguageService = new BoxModelLanguageService(query, db, ContactID);
                        boxModelLanguageFirst = (from c in db.BoxModelLanguages select c).FirstOrDefault();
                        count = (from c in db.BoxModelLanguages select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with BoxModelLanguage info
                    IHttpActionResult jsonRet = boxModelLanguageController.GetBoxModelLanguageList();
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<List<BoxModelLanguage>> ret = jsonRet as OkNegotiatedContentResult<List<BoxModelLanguage>>;
                    Assert.Equal(boxModelLanguageFirst.BoxModelLanguageID, ret.Content[0].BoxModelLanguageID);
                    Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<BoxModelLanguage> boxModelLanguageList = new List<BoxModelLanguage>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        BoxModelLanguageService boxModelLanguageService = new BoxModelLanguageService(query, db, ContactID);
                        boxModelLanguageList = (from c in db.BoxModelLanguages select c).OrderBy(c => c.BoxModelLanguageID).Skip(0).Take(2).ToList();
                        count = (from c in db.BoxModelLanguages select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with BoxModelLanguage info
                        jsonRet = boxModelLanguageController.GetBoxModelLanguageList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.NotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<BoxModelLanguage>>;
                        Assert.Equal(boxModelLanguageList[0].BoxModelLanguageID, ret.Content[0].BoxModelLanguageID);
                        Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with BoxModelLanguage info
                           IHttpActionResult jsonRet2 = boxModelLanguageController.GetBoxModelLanguageList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkNegotiatedContentResult<List<BoxModelLanguage>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<BoxModelLanguage>>;
                           Assert.Equal(boxModelLanguageList[1].BoxModelLanguageID, ret2.Content[0].BoxModelLanguageID);
                           Assert.Equal((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void BoxModelLanguage_Controller_GetBoxModelLanguageWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    BoxModelLanguageController boxModelLanguageController = new BoxModelLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(boxModelLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, boxModelLanguageController.DatabaseType);

                    BoxModelLanguage boxModelLanguageFirst = new BoxModelLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        BoxModelLanguageService boxModelLanguageService = new BoxModelLanguageService(new Query(), db, ContactID);
                        boxModelLanguageFirst = (from c in db.BoxModelLanguages select c).FirstOrDefault();
                    }

                    // ok with BoxModelLanguage info
                    IHttpActionResult jsonRet = boxModelLanguageController.GetBoxModelLanguageWithID(boxModelLanguageFirst.BoxModelLanguageID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<BoxModelLanguage> Ret = jsonRet as OkNegotiatedContentResult<BoxModelLanguage>;
                    BoxModelLanguage boxModelLanguageRet = Ret.Content;
                    Assert.Equal(boxModelLanguageFirst.BoxModelLanguageID, boxModelLanguageRet.BoxModelLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = boxModelLanguageController.GetBoxModelLanguageWithID(0);
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<BoxModelLanguage> boxModelLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<BoxModelLanguage>;
                    Assert.IsNull(boxModelLanguageRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.NotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void BoxModelLanguage_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    BoxModelLanguageController boxModelLanguageController = new BoxModelLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(boxModelLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, boxModelLanguageController.DatabaseType);

                    BoxModelLanguage boxModelLanguageLast = new BoxModelLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        BoxModelLanguageService boxModelLanguageService = new BoxModelLanguageService(query, db, ContactID);
                        boxModelLanguageLast = (from c in db.BoxModelLanguages select c).FirstOrDefault();
                    }

                    // ok with BoxModelLanguage info
                    IHttpActionResult jsonRet = boxModelLanguageController.GetBoxModelLanguageWithID(boxModelLanguageLast.BoxModelLanguageID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<BoxModelLanguage> Ret = jsonRet as OkNegotiatedContentResult<BoxModelLanguage>;
                    BoxModelLanguage boxModelLanguageRet = Ret.Content;
                    Assert.Equal(boxModelLanguageLast.BoxModelLanguageID, boxModelLanguageRet.BoxModelLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because BoxModelLanguageID exist
                    IHttpActionResult jsonRet2 = boxModelLanguageController.Post(boxModelLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<BoxModelLanguage> boxModelLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<BoxModelLanguage>;
                    Assert.IsNull(boxModelLanguageRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added BoxModelLanguage
                    boxModelLanguageRet.BoxModelLanguageID = 0;
                    boxModelLanguageController.Request = new System.Net.Http.HttpRequestMessage();
                    boxModelLanguageController.Request.RequestUri = new System.Uri("http://localhost:5000/api/boxModelLanguage");
                    IHttpActionResult jsonRet3 = boxModelLanguageController.Post(boxModelLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<BoxModelLanguage> boxModelLanguageRet3 = jsonRet3 as CreatedNegotiatedContentResult<BoxModelLanguage>;
                    Assert.NotNull(boxModelLanguageRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = boxModelLanguageController.Delete(boxModelLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<BoxModelLanguage> boxModelLanguageRet4 = jsonRet4 as OkNegotiatedContentResult<BoxModelLanguage>;
                    Assert.NotNull(boxModelLanguageRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [Fact]
        public void BoxModelLanguage_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    BoxModelLanguageController boxModelLanguageController = new BoxModelLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(boxModelLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, boxModelLanguageController.DatabaseType);

                    BoxModelLanguage boxModelLanguageLast = new BoxModelLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        BoxModelLanguageService boxModelLanguageService = new BoxModelLanguageService(query, db, ContactID);
                        boxModelLanguageLast = (from c in db.BoxModelLanguages select c).FirstOrDefault();
                    }

                    // ok with BoxModelLanguage info
                    IHttpActionResult jsonRet = boxModelLanguageController.GetBoxModelLanguageWithID(boxModelLanguageLast.BoxModelLanguageID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<BoxModelLanguage> Ret = jsonRet as OkNegotiatedContentResult<BoxModelLanguage>;
                    BoxModelLanguage boxModelLanguageRet = Ret.Content;
                    Assert.Equal(boxModelLanguageLast.BoxModelLanguageID, boxModelLanguageRet.BoxModelLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = boxModelLanguageController.Put(boxModelLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<BoxModelLanguage> boxModelLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<BoxModelLanguage>;
                    Assert.NotNull(boxModelLanguageRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because BoxModelLanguageID of 0 does not exist
                    boxModelLanguageRet.BoxModelLanguageID = 0;
                    IHttpActionResult jsonRet3 = boxModelLanguageController.Put(boxModelLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    OkNegotiatedContentResult<BoxModelLanguage> boxModelLanguageRet3 = jsonRet3 as OkNegotiatedContentResult<BoxModelLanguage>;
                    Assert.IsNull(boxModelLanguageRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void BoxModelLanguage_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    BoxModelLanguageController boxModelLanguageController = new BoxModelLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(boxModelLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, boxModelLanguageController.DatabaseType);

                    BoxModelLanguage boxModelLanguageLast = new BoxModelLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        BoxModelLanguageService boxModelLanguageService = new BoxModelLanguageService(query, db, ContactID);
                        boxModelLanguageLast = (from c in db.BoxModelLanguages select c).FirstOrDefault();
                    }

                    // ok with BoxModelLanguage info
                    IHttpActionResult jsonRet = boxModelLanguageController.GetBoxModelLanguageWithID(boxModelLanguageLast.BoxModelLanguageID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<BoxModelLanguage> Ret = jsonRet as OkNegotiatedContentResult<BoxModelLanguage>;
                    BoxModelLanguage boxModelLanguageRet = Ret.Content;
                    Assert.Equal(boxModelLanguageLast.BoxModelLanguageID, boxModelLanguageRet.BoxModelLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added BoxModelLanguage
                    boxModelLanguageRet.BoxModelLanguageID = 0;
                    boxModelLanguageController.Request = new System.Net.Http.HttpRequestMessage();
                    boxModelLanguageController.Request.RequestUri = new System.Uri("http://localhost:5000/api/boxModelLanguage");
                    IHttpActionResult jsonRet3 = boxModelLanguageController.Post(boxModelLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<BoxModelLanguage> boxModelLanguageRet3 = jsonRet3 as CreatedNegotiatedContentResult<BoxModelLanguage>;
                    Assert.NotNull(boxModelLanguageRet3);
                    BoxModelLanguage boxModelLanguage = boxModelLanguageRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = boxModelLanguageController.Delete(boxModelLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<BoxModelLanguage> boxModelLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<BoxModelLanguage>;
                    Assert.NotNull(boxModelLanguageRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because BoxModelLanguageID of 0 does not exist
                    boxModelLanguageRet.BoxModelLanguageID = 0;
                    IHttpActionResult jsonRet4 = boxModelLanguageController.Delete(boxModelLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<BoxModelLanguage> boxModelLanguageRet4 = jsonRet4 as OkNegotiatedContentResult<BoxModelLanguage>;
                    Assert.IsNull(boxModelLanguageRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
