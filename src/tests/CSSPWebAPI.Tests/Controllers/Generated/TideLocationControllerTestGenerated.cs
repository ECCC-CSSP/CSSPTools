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
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(tideLocationFirst.TideLocationID, ((List<TideLocation>)ret.Value)[0].TideLocationID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<TideLocation>)ret.Value).Count);

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
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(tideLocationList[0].TideLocationID, ((List<TideLocation>)ret.Value)[0].TideLocationID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<TideLocation>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with TideLocation info
                           IActionResult jsonRet2 = tideLocationController.GetTideLocationList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(tideLocationList[1].TideLocationID, ((List<TideLocation>)ret2.Value)[0].TideLocationID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<TideLocation>)ret2.Value).Count);
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
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(tideLocationFirst.TideLocationID, ((TideLocation)ret.Value).TideLocationID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = tideLocationController.GetTideLocationWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult tideLocationRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(tideLocationRet2);
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

                    TideLocation tideLocationFirst = new TideLocation();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        TideLocationService tideLocationService = new TideLocationService(query, db, ContactID);
                        tideLocationFirst = (from c in db.TideLocations select c).FirstOrDefault();
                    }

                    // ok with TideLocation info
                    IActionResult jsonRet = tideLocationController.GetTideLocationWithID(tideLocationFirst.TideLocationID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    TideLocation tideLocationRet = (TideLocation)ret.Value;
                    Assert.Equal(tideLocationFirst.TideLocationID, tideLocationRet.TideLocationID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because TideLocationID exist
                    IActionResult jsonRet2 = tideLocationController.Post(tideLocationRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added TideLocation
                    tideLocationRet.TideLocationID = 0;
                    IActionResult jsonRet3 = tideLocationController.Post(tideLocationRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = tideLocationController.Delete(tideLocationRet, LanguageRequest.ToString());
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
        public void TideLocation_Controller_Put_Test()
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
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        TideLocationService tideLocationService = new TideLocationService(query, db, ContactID);
                        tideLocationFirst = (from c in db.TideLocations select c).FirstOrDefault();
                    }

                    // ok with TideLocation info
                    IActionResult jsonRet = tideLocationController.GetTideLocationWithID(tideLocationFirst.TideLocationID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    TideLocation tideLocationRet = (TideLocation)Ret.Value;
                    Assert.Equal(tideLocationFirst.TideLocationID, tideLocationRet.TideLocationID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = tideLocationController.Put(tideLocationRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult tideLocationRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(tideLocationRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because TideLocationID of 0 does not exist
                    tideLocationRet.TideLocationID = 0;
                    IActionResult jsonRet3 = tideLocationController.Put(tideLocationRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult tideLocationRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(tideLocationRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
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

                    TideLocation tideLocationFirst = new TideLocation();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        TideLocationService tideLocationService = new TideLocationService(query, db, ContactID);
                        tideLocationFirst = (from c in db.TideLocations select c).FirstOrDefault();
                    }

                    // ok with TideLocation info
                    IActionResult jsonRet = tideLocationController.GetTideLocationWithID(tideLocationFirst.TideLocationID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    TideLocation tideLocationRet = (TideLocation)Ret.Value;
                    Assert.Equal(tideLocationFirst.TideLocationID, tideLocationRet.TideLocationID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added TideLocation
                    tideLocationRet.TideLocationID = 0;
                    IActionResult jsonRet3 = tideLocationController.Post(tideLocationRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    TideLocation tideLocation = (TideLocation)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = tideLocationController.Delete(tideLocationRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because TideLocationID of 0 does not exist
                    tideLocationRet.TideLocationID = 0;
                    IActionResult jsonRet4 = tideLocationController.Delete(tideLocationRet, LanguageRequest.ToString());
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
