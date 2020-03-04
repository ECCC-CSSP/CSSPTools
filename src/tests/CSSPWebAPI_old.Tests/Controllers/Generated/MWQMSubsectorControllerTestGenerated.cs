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
    public partial class MWQMSubsectorControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MWQMSubsectorControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void MWQMSubsector_Controller_GetMWQMSubsectorList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMSubsectorController mwqmSubsectorController = new MWQMSubsectorController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mwqmSubsectorController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mwqmSubsectorController.DatabaseType);

                    MWQMSubsector mwqmSubsectorFirst = new MWQMSubsector();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        MWQMSubsectorService mwqmSubsectorService = new MWQMSubsectorService(query, db, ContactID);
                        mwqmSubsectorFirst = (from c in db.MWQMSubsectors select c).FirstOrDefault();
                        count = (from c in db.MWQMSubsectors select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with MWQMSubsector info
                    IActionResult jsonRet = mwqmSubsectorController.GetMWQMSubsectorList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(mwqmSubsectorFirst.MWQMSubsectorID, ((List<MWQMSubsector>)ret.Value)[0].MWQMSubsectorID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<MWQMSubsector>)ret.Value).Count);

                    List<MWQMSubsector> mwqmSubsectorList = new List<MWQMSubsector>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        MWQMSubsectorService mwqmSubsectorService = new MWQMSubsectorService(query, db, ContactID);
                        mwqmSubsectorList = (from c in db.MWQMSubsectors select c).OrderBy(c => c.MWQMSubsectorID).Skip(0).Take(2).ToList();
                        count = (from c in db.MWQMSubsectors select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with MWQMSubsector info
                        jsonRet = mwqmSubsectorController.GetMWQMSubsectorList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(mwqmSubsectorList[0].MWQMSubsectorID, ((List<MWQMSubsector>)ret.Value)[0].MWQMSubsectorID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<MWQMSubsector>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with MWQMSubsector info
                           IActionResult jsonRet2 = mwqmSubsectorController.GetMWQMSubsectorList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(mwqmSubsectorList[1].MWQMSubsectorID, ((List<MWQMSubsector>)ret2.Value)[0].MWQMSubsectorID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<MWQMSubsector>)ret2.Value).Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void MWQMSubsector_Controller_GetMWQMSubsectorWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMSubsectorController mwqmSubsectorController = new MWQMSubsectorController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mwqmSubsectorController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mwqmSubsectorController.DatabaseType);

                    MWQMSubsector mwqmSubsectorFirst = new MWQMSubsector();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        MWQMSubsectorService mwqmSubsectorService = new MWQMSubsectorService(new Query(), db, ContactID);
                        mwqmSubsectorFirst = (from c in db.MWQMSubsectors select c).FirstOrDefault();
                    }

                    // ok with MWQMSubsector info
                    IActionResult jsonRet = mwqmSubsectorController.GetMWQMSubsectorWithID(mwqmSubsectorFirst.MWQMSubsectorID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(mwqmSubsectorFirst.MWQMSubsectorID, ((MWQMSubsector)ret.Value).MWQMSubsectorID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = mwqmSubsectorController.GetMWQMSubsectorWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult mwqmSubsectorRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(mwqmSubsectorRet2);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void MWQMSubsector_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMSubsectorController mwqmSubsectorController = new MWQMSubsectorController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mwqmSubsectorController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mwqmSubsectorController.DatabaseType);

                    MWQMSubsector mwqmSubsectorFirst = new MWQMSubsector();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MWQMSubsectorService mwqmSubsectorService = new MWQMSubsectorService(query, db, ContactID);
                        mwqmSubsectorFirst = (from c in db.MWQMSubsectors select c).FirstOrDefault();
                    }

                    // ok with MWQMSubsector info
                    IActionResult jsonRet = mwqmSubsectorController.GetMWQMSubsectorWithID(mwqmSubsectorFirst.MWQMSubsectorID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    MWQMSubsector mwqmSubsectorRet = (MWQMSubsector)ret.Value;
                    Assert.Equal(mwqmSubsectorFirst.MWQMSubsectorID, mwqmSubsectorRet.MWQMSubsectorID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because MWQMSubsectorID exist
                    IActionResult jsonRet2 = mwqmSubsectorController.Post(mwqmSubsectorRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added MWQMSubsector
                    mwqmSubsectorRet.MWQMSubsectorID = 0;
                    IActionResult jsonRet3 = mwqmSubsectorController.Post(mwqmSubsectorRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = mwqmSubsectorController.Delete(mwqmSubsectorRet, LanguageRequest.ToString());
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
        public void MWQMSubsector_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMSubsectorController mwqmSubsectorController = new MWQMSubsectorController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mwqmSubsectorController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mwqmSubsectorController.DatabaseType);

                    MWQMSubsector mwqmSubsectorFirst = new MWQMSubsector();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        MWQMSubsectorService mwqmSubsectorService = new MWQMSubsectorService(query, db, ContactID);
                        mwqmSubsectorFirst = (from c in db.MWQMSubsectors select c).FirstOrDefault();
                    }

                    // ok with MWQMSubsector info
                    IActionResult jsonRet = mwqmSubsectorController.GetMWQMSubsectorWithID(mwqmSubsectorFirst.MWQMSubsectorID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    MWQMSubsector mwqmSubsectorRet = (MWQMSubsector)Ret.Value;
                    Assert.Equal(mwqmSubsectorFirst.MWQMSubsectorID, mwqmSubsectorRet.MWQMSubsectorID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = mwqmSubsectorController.Put(mwqmSubsectorRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult mwqmSubsectorRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(mwqmSubsectorRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because MWQMSubsectorID of 0 does not exist
                    mwqmSubsectorRet.MWQMSubsectorID = 0;
                    IActionResult jsonRet3 = mwqmSubsectorController.Put(mwqmSubsectorRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult mwqmSubsectorRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(mwqmSubsectorRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void MWQMSubsector_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMSubsectorController mwqmSubsectorController = new MWQMSubsectorController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mwqmSubsectorController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mwqmSubsectorController.DatabaseType);

                    MWQMSubsector mwqmSubsectorFirst = new MWQMSubsector();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MWQMSubsectorService mwqmSubsectorService = new MWQMSubsectorService(query, db, ContactID);
                        mwqmSubsectorFirst = (from c in db.MWQMSubsectors select c).FirstOrDefault();
                    }

                    // ok with MWQMSubsector info
                    IActionResult jsonRet = mwqmSubsectorController.GetMWQMSubsectorWithID(mwqmSubsectorFirst.MWQMSubsectorID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    MWQMSubsector mwqmSubsectorRet = (MWQMSubsector)Ret.Value;
                    Assert.Equal(mwqmSubsectorFirst.MWQMSubsectorID, mwqmSubsectorRet.MWQMSubsectorID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added MWQMSubsector
                    mwqmSubsectorRet.MWQMSubsectorID = 0;
                    IActionResult jsonRet3 = mwqmSubsectorController.Post(mwqmSubsectorRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    MWQMSubsector mwqmSubsector = (MWQMSubsector)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = mwqmSubsectorController.Delete(mwqmSubsectorRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because MWQMSubsectorID of 0 does not exist
                    mwqmSubsectorRet.MWQMSubsectorID = 0;
                    IActionResult jsonRet4 = mwqmSubsectorController.Delete(mwqmSubsectorRet, LanguageRequest.ToString());
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
