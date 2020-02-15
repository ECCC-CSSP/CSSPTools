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
    public partial class PolSourceObservationControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public PolSourceObservationControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void PolSourceObservation_Controller_GetPolSourceObservationList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    PolSourceObservationController polSourceObservationController = new PolSourceObservationController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(polSourceObservationController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, polSourceObservationController.DatabaseType);

                    PolSourceObservation polSourceObservationFirst = new PolSourceObservation();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        PolSourceObservationService polSourceObservationService = new PolSourceObservationService(query, db, ContactID);
                        polSourceObservationFirst = (from c in db.PolSourceObservations select c).FirstOrDefault();
                        count = (from c in db.PolSourceObservations select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with PolSourceObservation info
                    IActionResult jsonRet = polSourceObservationController.GetPolSourceObservationList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(polSourceObservationFirst.PolSourceObservationID, ((List<PolSourceObservation>)ret.Value)[0].PolSourceObservationID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<PolSourceObservation>)ret.Value).Count);

                    List<PolSourceObservation> polSourceObservationList = new List<PolSourceObservation>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        PolSourceObservationService polSourceObservationService = new PolSourceObservationService(query, db, ContactID);
                        polSourceObservationList = (from c in db.PolSourceObservations select c).OrderBy(c => c.PolSourceObservationID).Skip(0).Take(2).ToList();
                        count = (from c in db.PolSourceObservations select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with PolSourceObservation info
                        jsonRet = polSourceObservationController.GetPolSourceObservationList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(polSourceObservationList[0].PolSourceObservationID, ((List<PolSourceObservation>)ret.Value)[0].PolSourceObservationID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<PolSourceObservation>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with PolSourceObservation info
                           IActionResult jsonRet2 = polSourceObservationController.GetPolSourceObservationList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(polSourceObservationList[1].PolSourceObservationID, ((List<PolSourceObservation>)ret2.Value)[0].PolSourceObservationID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<PolSourceObservation>)ret2.Value).Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void PolSourceObservation_Controller_GetPolSourceObservationWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    PolSourceObservationController polSourceObservationController = new PolSourceObservationController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(polSourceObservationController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, polSourceObservationController.DatabaseType);

                    PolSourceObservation polSourceObservationFirst = new PolSourceObservation();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        PolSourceObservationService polSourceObservationService = new PolSourceObservationService(new Query(), db, ContactID);
                        polSourceObservationFirst = (from c in db.PolSourceObservations select c).FirstOrDefault();
                    }

                    // ok with PolSourceObservation info
                    IActionResult jsonRet = polSourceObservationController.GetPolSourceObservationWithID(polSourceObservationFirst.PolSourceObservationID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(polSourceObservationFirst.PolSourceObservationID, ((PolSourceObservation)ret.Value).PolSourceObservationID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = polSourceObservationController.GetPolSourceObservationWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult polSourceObservationRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(polSourceObservationRet2);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void PolSourceObservation_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    PolSourceObservationController polSourceObservationController = new PolSourceObservationController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(polSourceObservationController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, polSourceObservationController.DatabaseType);

                    PolSourceObservation polSourceObservationFirst = new PolSourceObservation();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        PolSourceObservationService polSourceObservationService = new PolSourceObservationService(query, db, ContactID);
                        polSourceObservationFirst = (from c in db.PolSourceObservations select c).FirstOrDefault();
                    }

                    // ok with PolSourceObservation info
                    IActionResult jsonRet = polSourceObservationController.GetPolSourceObservationWithID(polSourceObservationFirst.PolSourceObservationID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    PolSourceObservation polSourceObservationRet = (PolSourceObservation)ret.Value;
                    Assert.Equal(polSourceObservationFirst.PolSourceObservationID, polSourceObservationRet.PolSourceObservationID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because PolSourceObservationID exist
                    IActionResult jsonRet2 = polSourceObservationController.Post(polSourceObservationRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added PolSourceObservation
                    polSourceObservationRet.PolSourceObservationID = 0;
                    IActionResult jsonRet3 = polSourceObservationController.Post(polSourceObservationRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = polSourceObservationController.Delete(polSourceObservationRet, LanguageRequest.ToString());
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
        public void PolSourceObservation_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    PolSourceObservationController polSourceObservationController = new PolSourceObservationController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(polSourceObservationController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, polSourceObservationController.DatabaseType);

                    PolSourceObservation polSourceObservationFirst = new PolSourceObservation();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        PolSourceObservationService polSourceObservationService = new PolSourceObservationService(query, db, ContactID);
                        polSourceObservationFirst = (from c in db.PolSourceObservations select c).FirstOrDefault();
                    }

                    // ok with PolSourceObservation info
                    IActionResult jsonRet = polSourceObservationController.GetPolSourceObservationWithID(polSourceObservationFirst.PolSourceObservationID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    PolSourceObservation polSourceObservationRet = (PolSourceObservation)Ret.Value;
                    Assert.Equal(polSourceObservationFirst.PolSourceObservationID, polSourceObservationRet.PolSourceObservationID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = polSourceObservationController.Put(polSourceObservationRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult polSourceObservationRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(polSourceObservationRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because PolSourceObservationID of 0 does not exist
                    polSourceObservationRet.PolSourceObservationID = 0;
                    IActionResult jsonRet3 = polSourceObservationController.Put(polSourceObservationRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult polSourceObservationRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(polSourceObservationRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void PolSourceObservation_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    PolSourceObservationController polSourceObservationController = new PolSourceObservationController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(polSourceObservationController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, polSourceObservationController.DatabaseType);

                    PolSourceObservation polSourceObservationFirst = new PolSourceObservation();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        PolSourceObservationService polSourceObservationService = new PolSourceObservationService(query, db, ContactID);
                        polSourceObservationFirst = (from c in db.PolSourceObservations select c).FirstOrDefault();
                    }

                    // ok with PolSourceObservation info
                    IActionResult jsonRet = polSourceObservationController.GetPolSourceObservationWithID(polSourceObservationFirst.PolSourceObservationID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    PolSourceObservation polSourceObservationRet = (PolSourceObservation)Ret.Value;
                    Assert.Equal(polSourceObservationFirst.PolSourceObservationID, polSourceObservationRet.PolSourceObservationID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added PolSourceObservation
                    polSourceObservationRet.PolSourceObservationID = 0;
                    IActionResult jsonRet3 = polSourceObservationController.Post(polSourceObservationRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    PolSourceObservation polSourceObservation = (PolSourceObservation)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = polSourceObservationController.Delete(polSourceObservationRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because PolSourceObservationID of 0 does not exist
                    polSourceObservationRet.PolSourceObservationID = 0;
                    IActionResult jsonRet4 = polSourceObservationController.Delete(polSourceObservationRet, LanguageRequest.ToString());
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
