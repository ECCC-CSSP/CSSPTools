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
    public partial class TideLocationControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TideLocationControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void TideLocation_Controller_GetTideLocationList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TideLocationController tideLocationController = new TideLocationController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tideLocationController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tideLocationController.DatabaseType);

                    TideLocation tideLocationFirst = new TideLocation();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        TideLocationService tideLocationService = new TideLocationService(query, db, ContactID);
                        tideLocationFirst = (from c in db.TideLocations select c).FirstOrDefault();
                        count = (from c in db.TideLocations select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with TideLocation info
                    IActionResult jsonRet = tideLocationController.GetTideLocationList();
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<List<TideLocation>> ret = jsonRet as OkNegotiatedContentResult<List<TideLocation>>;
                    Assert.Equal(tideLocationFirst.TideLocationID, ret.Content[0].TideLocationID);
                    Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<TideLocation> tideLocationList = new List<TideLocation>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        TideLocationService tideLocationService = new TideLocationService(query, db, ContactID);
                        tideLocationList = (from c in db.TideLocations select c).OrderBy(c => c.TideLocationID).Skip(0).Take(2).ToList();
                        count = (from c in db.TideLocations select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with TideLocation info
                        jsonRet = tideLocationController.GetTideLocationList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.NotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<TideLocation>>;
                        Assert.Equal(tideLocationList[0].TideLocationID, ret.Content[0].TideLocationID);
                        Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with TideLocation info
                           IActionResult jsonRet2 = tideLocationController.GetTideLocationList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkNegotiatedContentResult<List<TideLocation>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<TideLocation>>;
                           Assert.Equal(tideLocationList[1].TideLocationID, ret2.Content[0].TideLocationID);
                           Assert.Equal((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void TideLocation_Controller_GetTideLocationWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TideLocationController tideLocationController = new TideLocationController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tideLocationController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tideLocationController.DatabaseType);

                    TideLocation tideLocationFirst = new TideLocation();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        TideLocationService tideLocationService = new TideLocationService(new Query(), db, ContactID);
                        tideLocationFirst = (from c in db.TideLocations select c).FirstOrDefault();
                    }

                    // ok with TideLocation info
                    IActionResult jsonRet = tideLocationController.GetTideLocationWithID(tideLocationFirst.TideLocationID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<TideLocation> Ret = jsonRet as OkNegotiatedContentResult<TideLocation>;
                    TideLocation tideLocationRet = Ret.Content;
                    Assert.Equal(tideLocationFirst.TideLocationID, tideLocationRet.TideLocationID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = tideLocationController.GetTideLocationWithID(0);
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<TideLocation> tideLocationRet2 = jsonRet2 as OkNegotiatedContentResult<TideLocation>;
                    Assert.Null(tideLocationRet2);

                    NotFoundObjectResult notFoundRequest = jsonRet2 as NotFoundObjectResult;
                    Assert.NotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void TideLocation_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TideLocationController tideLocationController = new TideLocationController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tideLocationController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tideLocationController.DatabaseType);

                    TideLocation tideLocationLast = new TideLocation();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        TideLocationService tideLocationService = new TideLocationService(query, db, ContactID);
                        tideLocationLast = (from c in db.TideLocations select c).FirstOrDefault();
                    }

                    // ok with TideLocation info
                    IActionResult jsonRet = tideLocationController.GetTideLocationWithID(tideLocationLast.TideLocationID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<TideLocation> Ret = jsonRet as OkNegotiatedContentResult<TideLocation>;
                    TideLocation tideLocationRet = Ret.Content;
                    Assert.Equal(tideLocationLast.TideLocationID, tideLocationRet.TideLocationID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because TideLocationID exist
                    IActionResult jsonRet2 = tideLocationController.Post(tideLocationRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<TideLocation> tideLocationRet2 = jsonRet2 as OkNegotiatedContentResult<TideLocation>;
                    Assert.Null(tideLocationRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added TideLocation
                    tideLocationRet.TideLocationID = 0;
                    IActionResult jsonRet3 = tideLocationController.Post(tideLocationRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<TideLocation> tideLocationRet3 = jsonRet3 as CreatedNegotiatedContentResult<TideLocation>;
                    Assert.NotNull(tideLocationRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = tideLocationController.Delete(tideLocationRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<TideLocation> tideLocationRet4 = jsonRet4 as OkNegotiatedContentResult<TideLocation>;
                    Assert.NotNull(tideLocationRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [Fact]
        public void TideLocation_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TideLocationController tideLocationController = new TideLocationController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tideLocationController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tideLocationController.DatabaseType);

                    TideLocation tideLocationLast = new TideLocation();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        TideLocationService tideLocationService = new TideLocationService(query, db, ContactID);
                        tideLocationLast = (from c in db.TideLocations select c).FirstOrDefault();
                    }

                    // ok with TideLocation info
                    IActionResult jsonRet = tideLocationController.GetTideLocationWithID(tideLocationLast.TideLocationID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<TideLocation> Ret = jsonRet as OkNegotiatedContentResult<TideLocation>;
                    TideLocation tideLocationRet = Ret.Content;
                    Assert.Equal(tideLocationLast.TideLocationID, tideLocationRet.TideLocationID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = tideLocationController.Put(tideLocationRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<TideLocation> tideLocationRet2 = jsonRet2 as OkNegotiatedContentResult<TideLocation>;
                    Assert.NotNull(tideLocationRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because TideLocationID of 0 does not exist
                    tideLocationRet.TideLocationID = 0;
                    IActionResult jsonRet3 = tideLocationController.Put(tideLocationRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    OkNegotiatedContentResult<TideLocation> tideLocationRet3 = jsonRet3 as OkNegotiatedContentResult<TideLocation>;
                    Assert.Null(tideLocationRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void TideLocation_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TideLocationController tideLocationController = new TideLocationController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tideLocationController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tideLocationController.DatabaseType);

                    TideLocation tideLocationLast = new TideLocation();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        TideLocationService tideLocationService = new TideLocationService(query, db, ContactID);
                        tideLocationLast = (from c in db.TideLocations select c).FirstOrDefault();
                    }

                    // ok with TideLocation info
                    IActionResult jsonRet = tideLocationController.GetTideLocationWithID(tideLocationLast.TideLocationID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<TideLocation> Ret = jsonRet as OkNegotiatedContentResult<TideLocation>;
                    TideLocation tideLocationRet = Ret.Content;
                    Assert.Equal(tideLocationLast.TideLocationID, tideLocationRet.TideLocationID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return newly added TideLocation
                    tideLocationRet.TideLocationID = 0;
                    IActionResult jsonRet3 = tideLocationController.Post(tideLocationRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<TideLocation> tideLocationRet3 = jsonRet3 as CreatedNegotiatedContentResult<TideLocation>;
                    Assert.NotNull(tideLocationRet3);
                    TideLocation tideLocation = tideLocationRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = tideLocationController.Delete(tideLocationRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<TideLocation> tideLocationRet2 = jsonRet2 as OkNegotiatedContentResult<TideLocation>;
                    Assert.NotNull(tideLocationRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because TideLocationID of 0 does not exist
                    tideLocationRet.TideLocationID = 0;
                    IActionResult jsonRet4 = tideLocationController.Delete(tideLocationRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<TideLocation> tideLocationRet4 = jsonRet4 as OkNegotiatedContentResult<TideLocation>;
                    Assert.Null(tideLocationRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
