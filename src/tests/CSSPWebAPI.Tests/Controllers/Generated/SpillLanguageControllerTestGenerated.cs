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
    public partial class SpillLanguageControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public SpillLanguageControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void SpillLanguage_Controller_GetSpillLanguageList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    SpillLanguageController spillLanguageController = new SpillLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(spillLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, spillLanguageController.DatabaseType);

                    SpillLanguage spillLanguageFirst = new SpillLanguage();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        SpillLanguageService spillLanguageService = new SpillLanguageService(query, db, ContactID);
                        spillLanguageFirst = (from c in db.SpillLanguages select c).FirstOrDefault();
                        count = (from c in db.SpillLanguages select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with SpillLanguage info
                    IActionResult jsonRet = spillLanguageController.GetSpillLanguageList();
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<List<SpillLanguage>> ret = jsonRet as OkNegotiatedContentResult<List<SpillLanguage>>;
                    Assert.Equal(spillLanguageFirst.SpillLanguageID, ret.Content[0].SpillLanguageID);
                    Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<SpillLanguage> spillLanguageList = new List<SpillLanguage>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        SpillLanguageService spillLanguageService = new SpillLanguageService(query, db, ContactID);
                        spillLanguageList = (from c in db.SpillLanguages select c).OrderBy(c => c.SpillLanguageID).Skip(0).Take(2).ToList();
                        count = (from c in db.SpillLanguages select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with SpillLanguage info
                        jsonRet = spillLanguageController.GetSpillLanguageList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.NotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<SpillLanguage>>;
                        Assert.Equal(spillLanguageList[0].SpillLanguageID, ret.Content[0].SpillLanguageID);
                        Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with SpillLanguage info
                           IActionResult jsonRet2 = spillLanguageController.GetSpillLanguageList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkNegotiatedContentResult<List<SpillLanguage>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<SpillLanguage>>;
                           Assert.Equal(spillLanguageList[1].SpillLanguageID, ret2.Content[0].SpillLanguageID);
                           Assert.Equal((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void SpillLanguage_Controller_GetSpillLanguageWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    SpillLanguageController spillLanguageController = new SpillLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(spillLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, spillLanguageController.DatabaseType);

                    SpillLanguage spillLanguageFirst = new SpillLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        SpillLanguageService spillLanguageService = new SpillLanguageService(new Query(), db, ContactID);
                        spillLanguageFirst = (from c in db.SpillLanguages select c).FirstOrDefault();
                    }

                    // ok with SpillLanguage info
                    IActionResult jsonRet = spillLanguageController.GetSpillLanguageWithID(spillLanguageFirst.SpillLanguageID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<SpillLanguage> Ret = jsonRet as OkNegotiatedContentResult<SpillLanguage>;
                    SpillLanguage spillLanguageRet = Ret.Content;
                    Assert.Equal(spillLanguageFirst.SpillLanguageID, spillLanguageRet.SpillLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = spillLanguageController.GetSpillLanguageWithID(0);
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<SpillLanguage> spillLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<SpillLanguage>;
                    Assert.Null(spillLanguageRet2);

                    NotFoundObjectResult notFoundRequest = jsonRet2 as NotFoundObjectResult;
                    Assert.NotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void SpillLanguage_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    SpillLanguageController spillLanguageController = new SpillLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(spillLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, spillLanguageController.DatabaseType);

                    SpillLanguage spillLanguageLast = new SpillLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        SpillLanguageService spillLanguageService = new SpillLanguageService(query, db, ContactID);
                        spillLanguageLast = (from c in db.SpillLanguages select c).FirstOrDefault();
                    }

                    // ok with SpillLanguage info
                    IActionResult jsonRet = spillLanguageController.GetSpillLanguageWithID(spillLanguageLast.SpillLanguageID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<SpillLanguage> Ret = jsonRet as OkNegotiatedContentResult<SpillLanguage>;
                    SpillLanguage spillLanguageRet = Ret.Content;
                    Assert.Equal(spillLanguageLast.SpillLanguageID, spillLanguageRet.SpillLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because SpillLanguageID exist
                    IActionResult jsonRet2 = spillLanguageController.Post(spillLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<SpillLanguage> spillLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<SpillLanguage>;
                    Assert.Null(spillLanguageRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added SpillLanguage
                    spillLanguageRet.SpillLanguageID = 0;
                    IActionResult jsonRet3 = spillLanguageController.Post(spillLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<SpillLanguage> spillLanguageRet3 = jsonRet3 as CreatedNegotiatedContentResult<SpillLanguage>;
                    Assert.NotNull(spillLanguageRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = spillLanguageController.Delete(spillLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<SpillLanguage> spillLanguageRet4 = jsonRet4 as OkNegotiatedContentResult<SpillLanguage>;
                    Assert.NotNull(spillLanguageRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [Fact]
        public void SpillLanguage_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    SpillLanguageController spillLanguageController = new SpillLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(spillLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, spillLanguageController.DatabaseType);

                    SpillLanguage spillLanguageLast = new SpillLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        SpillLanguageService spillLanguageService = new SpillLanguageService(query, db, ContactID);
                        spillLanguageLast = (from c in db.SpillLanguages select c).FirstOrDefault();
                    }

                    // ok with SpillLanguage info
                    IActionResult jsonRet = spillLanguageController.GetSpillLanguageWithID(spillLanguageLast.SpillLanguageID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<SpillLanguage> Ret = jsonRet as OkNegotiatedContentResult<SpillLanguage>;
                    SpillLanguage spillLanguageRet = Ret.Content;
                    Assert.Equal(spillLanguageLast.SpillLanguageID, spillLanguageRet.SpillLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = spillLanguageController.Put(spillLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<SpillLanguage> spillLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<SpillLanguage>;
                    Assert.NotNull(spillLanguageRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because SpillLanguageID of 0 does not exist
                    spillLanguageRet.SpillLanguageID = 0;
                    IActionResult jsonRet3 = spillLanguageController.Put(spillLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    OkNegotiatedContentResult<SpillLanguage> spillLanguageRet3 = jsonRet3 as OkNegotiatedContentResult<SpillLanguage>;
                    Assert.Null(spillLanguageRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void SpillLanguage_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    SpillLanguageController spillLanguageController = new SpillLanguageController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(spillLanguageController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, spillLanguageController.DatabaseType);

                    SpillLanguage spillLanguageLast = new SpillLanguage();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        SpillLanguageService spillLanguageService = new SpillLanguageService(query, db, ContactID);
                        spillLanguageLast = (from c in db.SpillLanguages select c).FirstOrDefault();
                    }

                    // ok with SpillLanguage info
                    IActionResult jsonRet = spillLanguageController.GetSpillLanguageWithID(spillLanguageLast.SpillLanguageID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<SpillLanguage> Ret = jsonRet as OkNegotiatedContentResult<SpillLanguage>;
                    SpillLanguage spillLanguageRet = Ret.Content;
                    Assert.Equal(spillLanguageLast.SpillLanguageID, spillLanguageRet.SpillLanguageID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return newly added SpillLanguage
                    spillLanguageRet.SpillLanguageID = 0;
                    IActionResult jsonRet3 = spillLanguageController.Post(spillLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<SpillLanguage> spillLanguageRet3 = jsonRet3 as CreatedNegotiatedContentResult<SpillLanguage>;
                    Assert.NotNull(spillLanguageRet3);
                    SpillLanguage spillLanguage = spillLanguageRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = spillLanguageController.Delete(spillLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<SpillLanguage> spillLanguageRet2 = jsonRet2 as OkNegotiatedContentResult<SpillLanguage>;
                    Assert.NotNull(spillLanguageRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because SpillLanguageID of 0 does not exist
                    spillLanguageRet.SpillLanguageID = 0;
                    IActionResult jsonRet4 = spillLanguageController.Delete(spillLanguageRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<SpillLanguage> spillLanguageRet4 = jsonRet4 as OkNegotiatedContentResult<SpillLanguage>;
                    Assert.Null(spillLanguageRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
