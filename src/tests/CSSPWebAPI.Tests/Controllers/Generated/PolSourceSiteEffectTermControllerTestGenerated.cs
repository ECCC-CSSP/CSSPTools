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
    public partial class PolSourceSiteEffectTermControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public PolSourceSiteEffectTermControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void PolSourceSiteEffectTerm_Controller_GetPolSourceSiteEffectTermList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    PolSourceSiteEffectTermController polSourceSiteEffectTermController = new PolSourceSiteEffectTermController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(polSourceSiteEffectTermController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, polSourceSiteEffectTermController.DatabaseType);

                    PolSourceSiteEffectTerm polSourceSiteEffectTermFirst = new PolSourceSiteEffectTerm();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        PolSourceSiteEffectTermService polSourceSiteEffectTermService = new PolSourceSiteEffectTermService(query, db, ContactID);
                        polSourceSiteEffectTermFirst = (from c in db.PolSourceSiteEffectTerms select c).FirstOrDefault();
                        count = (from c in db.PolSourceSiteEffectTerms select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with PolSourceSiteEffectTerm info
                    IActionResult jsonRet = polSourceSiteEffectTermController.GetPolSourceSiteEffectTermList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(polSourceSiteEffectTermFirst.PolSourceSiteEffectTermID, ((List<PolSourceSiteEffectTerm>)ret.Value)[0].PolSourceSiteEffectTermID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<PolSourceSiteEffectTerm>)ret.Value).Count);

                    List<PolSourceSiteEffectTerm> polSourceSiteEffectTermList = new List<PolSourceSiteEffectTerm>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        PolSourceSiteEffectTermService polSourceSiteEffectTermService = new PolSourceSiteEffectTermService(query, db, ContactID);
                        polSourceSiteEffectTermList = (from c in db.PolSourceSiteEffectTerms select c).OrderBy(c => c.PolSourceSiteEffectTermID).Skip(0).Take(2).ToList();
                        count = (from c in db.PolSourceSiteEffectTerms select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with PolSourceSiteEffectTerm info
                        jsonRet = polSourceSiteEffectTermController.GetPolSourceSiteEffectTermList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(polSourceSiteEffectTermList[0].PolSourceSiteEffectTermID, ((List<PolSourceSiteEffectTerm>)ret.Value)[0].PolSourceSiteEffectTermID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<PolSourceSiteEffectTerm>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with PolSourceSiteEffectTerm info
                           IActionResult jsonRet2 = polSourceSiteEffectTermController.GetPolSourceSiteEffectTermList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(polSourceSiteEffectTermList[1].PolSourceSiteEffectTermID, ((List<PolSourceSiteEffectTerm>)ret2.Value)[0].PolSourceSiteEffectTermID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<PolSourceSiteEffectTerm>)ret2.Value).Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void PolSourceSiteEffectTerm_Controller_GetPolSourceSiteEffectTermWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    PolSourceSiteEffectTermController polSourceSiteEffectTermController = new PolSourceSiteEffectTermController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(polSourceSiteEffectTermController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, polSourceSiteEffectTermController.DatabaseType);

                    PolSourceSiteEffectTerm polSourceSiteEffectTermFirst = new PolSourceSiteEffectTerm();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        PolSourceSiteEffectTermService polSourceSiteEffectTermService = new PolSourceSiteEffectTermService(new Query(), db, ContactID);
                        polSourceSiteEffectTermFirst = (from c in db.PolSourceSiteEffectTerms select c).FirstOrDefault();
                    }

                    // ok with PolSourceSiteEffectTerm info
                    IActionResult jsonRet = polSourceSiteEffectTermController.GetPolSourceSiteEffectTermWithID(polSourceSiteEffectTermFirst.PolSourceSiteEffectTermID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(polSourceSiteEffectTermFirst.PolSourceSiteEffectTermID, ((PolSourceSiteEffectTerm)ret.Value).PolSourceSiteEffectTermID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = polSourceSiteEffectTermController.GetPolSourceSiteEffectTermWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult polSourceSiteEffectTermRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(polSourceSiteEffectTermRet2);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void PolSourceSiteEffectTerm_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    PolSourceSiteEffectTermController polSourceSiteEffectTermController = new PolSourceSiteEffectTermController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(polSourceSiteEffectTermController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, polSourceSiteEffectTermController.DatabaseType);

                    PolSourceSiteEffectTerm polSourceSiteEffectTermLast = new PolSourceSiteEffectTerm();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        PolSourceSiteEffectTermService polSourceSiteEffectTermService = new PolSourceSiteEffectTermService(query, db, ContactID);
                        polSourceSiteEffectTermLast = (from c in db.PolSourceSiteEffectTerms select c).FirstOrDefault();
                    }

                    // ok with PolSourceSiteEffectTerm info
                    IActionResult jsonRet = polSourceSiteEffectTermController.GetPolSourceSiteEffectTermWithID(polSourceSiteEffectTermLast.PolSourceSiteEffectTermID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    PolSourceSiteEffectTerm polSourceSiteEffectTermRet = (PolSourceSiteEffectTerm)ret.Value;
                    Assert.Equal(polSourceSiteEffectTermLast.PolSourceSiteEffectTermID, polSourceSiteEffectTermRet.PolSourceSiteEffectTermID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because PolSourceSiteEffectTermID exist
                    IActionResult jsonRet2 = polSourceSiteEffectTermController.Post(polSourceSiteEffectTermRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added PolSourceSiteEffectTerm
                    polSourceSiteEffectTermRet.PolSourceSiteEffectTermID = 0;
                    IActionResult jsonRet3 = polSourceSiteEffectTermController.Post(polSourceSiteEffectTermRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = polSourceSiteEffectTermController.Delete(polSourceSiteEffectTermRet, LanguageRequest.ToString());
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
        public void PolSourceSiteEffectTerm_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    PolSourceSiteEffectTermController polSourceSiteEffectTermController = new PolSourceSiteEffectTermController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(polSourceSiteEffectTermController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, polSourceSiteEffectTermController.DatabaseType);

                    PolSourceSiteEffectTerm polSourceSiteEffectTermLast = new PolSourceSiteEffectTerm();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        PolSourceSiteEffectTermService polSourceSiteEffectTermService = new PolSourceSiteEffectTermService(query, db, ContactID);
                        polSourceSiteEffectTermLast = (from c in db.PolSourceSiteEffectTerms select c).FirstOrDefault();
                    }

                    // ok with PolSourceSiteEffectTerm info
                    IActionResult jsonRet = polSourceSiteEffectTermController.GetPolSourceSiteEffectTermWithID(polSourceSiteEffectTermLast.PolSourceSiteEffectTermID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    PolSourceSiteEffectTerm polSourceSiteEffectTermRet = (PolSourceSiteEffectTerm)Ret.Value;
                    Assert.Equal(polSourceSiteEffectTermLast.PolSourceSiteEffectTermID, polSourceSiteEffectTermRet.PolSourceSiteEffectTermID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = polSourceSiteEffectTermController.Put(polSourceSiteEffectTermRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult polSourceSiteEffectTermRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(polSourceSiteEffectTermRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because PolSourceSiteEffectTermID of 0 does not exist
                    polSourceSiteEffectTermRet.PolSourceSiteEffectTermID = 0;
                    IActionResult jsonRet3 = polSourceSiteEffectTermController.Put(polSourceSiteEffectTermRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult polSourceSiteEffectTermRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(polSourceSiteEffectTermRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void PolSourceSiteEffectTerm_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    PolSourceSiteEffectTermController polSourceSiteEffectTermController = new PolSourceSiteEffectTermController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(polSourceSiteEffectTermController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, polSourceSiteEffectTermController.DatabaseType);

                    PolSourceSiteEffectTerm polSourceSiteEffectTermLast = new PolSourceSiteEffectTerm();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        PolSourceSiteEffectTermService polSourceSiteEffectTermService = new PolSourceSiteEffectTermService(query, db, ContactID);
                        polSourceSiteEffectTermLast = (from c in db.PolSourceSiteEffectTerms select c).FirstOrDefault();
                    }

                    // ok with PolSourceSiteEffectTerm info
                    IActionResult jsonRet = polSourceSiteEffectTermController.GetPolSourceSiteEffectTermWithID(polSourceSiteEffectTermLast.PolSourceSiteEffectTermID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    PolSourceSiteEffectTerm polSourceSiteEffectTermRet = (PolSourceSiteEffectTerm)Ret.Value;
                    Assert.Equal(polSourceSiteEffectTermLast.PolSourceSiteEffectTermID, polSourceSiteEffectTermRet.PolSourceSiteEffectTermID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added PolSourceSiteEffectTerm
                    polSourceSiteEffectTermRet.PolSourceSiteEffectTermID = 0;
                    IActionResult jsonRet3 = polSourceSiteEffectTermController.Post(polSourceSiteEffectTermRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    PolSourceSiteEffectTerm polSourceSiteEffectTerm = (PolSourceSiteEffectTerm)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = polSourceSiteEffectTermController.Delete(polSourceSiteEffectTermRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because PolSourceSiteEffectTermID of 0 does not exist
                    polSourceSiteEffectTermRet.PolSourceSiteEffectTermID = 0;
                    IActionResult jsonRet4 = polSourceSiteEffectTermController.Delete(polSourceSiteEffectTermRet, LanguageRequest.ToString());
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
