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
    public partial class MWQMLookupMPNControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MWQMLookupMPNControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void MWQMLookupMPN_Controller_GetMWQMLookupMPNList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMLookupMPNController mwqmLookupMPNController = new MWQMLookupMPNController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mwqmLookupMPNController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mwqmLookupMPNController.DatabaseType);

                    MWQMLookupMPN mwqmLookupMPNFirst = new MWQMLookupMPN();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        MWQMLookupMPNService mwqmLookupMPNService = new MWQMLookupMPNService(query, db, ContactID);
                        mwqmLookupMPNFirst = (from c in db.MWQMLookupMPNs select c).FirstOrDefault();
                        count = (from c in db.MWQMLookupMPNs select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with MWQMLookupMPN info
                    IActionResult jsonRet = mwqmLookupMPNController.GetMWQMLookupMPNList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(mwqmLookupMPNFirst.MWQMLookupMPNID, ((List<MWQMLookupMPN>)ret.Value)[0].MWQMLookupMPNID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<MWQMLookupMPN>)ret.Value).Count);

                    List<MWQMLookupMPN> mwqmLookupMPNList = new List<MWQMLookupMPN>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        MWQMLookupMPNService mwqmLookupMPNService = new MWQMLookupMPNService(query, db, ContactID);
                        mwqmLookupMPNList = (from c in db.MWQMLookupMPNs select c).OrderBy(c => c.MWQMLookupMPNID).Skip(0).Take(2).ToList();
                        count = (from c in db.MWQMLookupMPNs select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with MWQMLookupMPN info
                        jsonRet = mwqmLookupMPNController.GetMWQMLookupMPNList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(mwqmLookupMPNList[0].MWQMLookupMPNID, ((List<MWQMLookupMPN>)ret.Value)[0].MWQMLookupMPNID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<MWQMLookupMPN>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with MWQMLookupMPN info
                           IActionResult jsonRet2 = mwqmLookupMPNController.GetMWQMLookupMPNList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(mwqmLookupMPNList[1].MWQMLookupMPNID, ((List<MWQMLookupMPN>)ret2.Value)[0].MWQMLookupMPNID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<MWQMLookupMPN>)ret2.Value).Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void MWQMLookupMPN_Controller_GetMWQMLookupMPNWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMLookupMPNController mwqmLookupMPNController = new MWQMLookupMPNController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mwqmLookupMPNController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mwqmLookupMPNController.DatabaseType);

                    MWQMLookupMPN mwqmLookupMPNFirst = new MWQMLookupMPN();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        MWQMLookupMPNService mwqmLookupMPNService = new MWQMLookupMPNService(new Query(), db, ContactID);
                        mwqmLookupMPNFirst = (from c in db.MWQMLookupMPNs select c).FirstOrDefault();
                    }

                    // ok with MWQMLookupMPN info
                    IActionResult jsonRet = mwqmLookupMPNController.GetMWQMLookupMPNWithID(mwqmLookupMPNFirst.MWQMLookupMPNID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(mwqmLookupMPNFirst.MWQMLookupMPNID, ((MWQMLookupMPN)ret.Value).MWQMLookupMPNID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = mwqmLookupMPNController.GetMWQMLookupMPNWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult mwqmLookupMPNRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(mwqmLookupMPNRet2);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void MWQMLookupMPN_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMLookupMPNController mwqmLookupMPNController = new MWQMLookupMPNController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mwqmLookupMPNController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mwqmLookupMPNController.DatabaseType);

                    MWQMLookupMPN mwqmLookupMPNFirst = new MWQMLookupMPN();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MWQMLookupMPNService mwqmLookupMPNService = new MWQMLookupMPNService(query, db, ContactID);
                        mwqmLookupMPNFirst = (from c in db.MWQMLookupMPNs select c).FirstOrDefault();
                    }

                    // ok with MWQMLookupMPN info
                    IActionResult jsonRet = mwqmLookupMPNController.GetMWQMLookupMPNWithID(mwqmLookupMPNFirst.MWQMLookupMPNID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    MWQMLookupMPN mwqmLookupMPNRet = (MWQMLookupMPN)ret.Value;
                    Assert.Equal(mwqmLookupMPNFirst.MWQMLookupMPNID, mwqmLookupMPNRet.MWQMLookupMPNID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because MWQMLookupMPNID exist
                    IActionResult jsonRet2 = mwqmLookupMPNController.Post(mwqmLookupMPNRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added MWQMLookupMPN
                    mwqmLookupMPNRet.MWQMLookupMPNID = 0;
                    mwqmLookupMPNRet.Tubes01 = 1;
                    mwqmLookupMPNRet.Tubes1 = 1;
                    mwqmLookupMPNRet.Tubes10 = 1;
                    mwqmLookupMPNRet.MPN_100ml = 6;
                    IActionResult jsonRet3 = mwqmLookupMPNController.Post(mwqmLookupMPNRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = mwqmLookupMPNController.Delete(mwqmLookupMPNRet, LanguageRequest.ToString());
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
        public void MWQMLookupMPN_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMLookupMPNController mwqmLookupMPNController = new MWQMLookupMPNController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mwqmLookupMPNController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mwqmLookupMPNController.DatabaseType);

                    MWQMLookupMPN mwqmLookupMPNFirst = new MWQMLookupMPN();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        MWQMLookupMPNService mwqmLookupMPNService = new MWQMLookupMPNService(query, db, ContactID);
                        mwqmLookupMPNFirst = (from c in db.MWQMLookupMPNs select c).FirstOrDefault();
                    }

                    // ok with MWQMLookupMPN info
                    IActionResult jsonRet = mwqmLookupMPNController.GetMWQMLookupMPNWithID(mwqmLookupMPNFirst.MWQMLookupMPNID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    MWQMLookupMPN mwqmLookupMPNRet = (MWQMLookupMPN)Ret.Value;
                    Assert.Equal(mwqmLookupMPNFirst.MWQMLookupMPNID, mwqmLookupMPNRet.MWQMLookupMPNID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = mwqmLookupMPNController.Put(mwqmLookupMPNRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult mwqmLookupMPNRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(mwqmLookupMPNRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because MWQMLookupMPNID of 0 does not exist
                    mwqmLookupMPNRet.MWQMLookupMPNID = 0;
                    IActionResult jsonRet3 = mwqmLookupMPNController.Put(mwqmLookupMPNRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult mwqmLookupMPNRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(mwqmLookupMPNRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void MWQMLookupMPN_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMLookupMPNController mwqmLookupMPNController = new MWQMLookupMPNController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mwqmLookupMPNController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mwqmLookupMPNController.DatabaseType);

                    MWQMLookupMPN mwqmLookupMPNFirst = new MWQMLookupMPN();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MWQMLookupMPNService mwqmLookupMPNService = new MWQMLookupMPNService(query, db, ContactID);
                        mwqmLookupMPNFirst = (from c in db.MWQMLookupMPNs select c).FirstOrDefault();
                    }

                    // ok with MWQMLookupMPN info
                    IActionResult jsonRet = mwqmLookupMPNController.GetMWQMLookupMPNWithID(mwqmLookupMPNFirst.MWQMLookupMPNID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    MWQMLookupMPN mwqmLookupMPNRet = (MWQMLookupMPN)Ret.Value;
                    Assert.Equal(mwqmLookupMPNFirst.MWQMLookupMPNID, mwqmLookupMPNRet.MWQMLookupMPNID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added MWQMLookupMPN
                    mwqmLookupMPNRet.MWQMLookupMPNID = 0;
                    mwqmLookupMPNRet.Tubes01 = 1;
                    mwqmLookupMPNRet.Tubes1 = 1;
                    mwqmLookupMPNRet.Tubes10 = 1;
                    mwqmLookupMPNRet.MPN_100ml = 6;
                    IActionResult jsonRet3 = mwqmLookupMPNController.Post(mwqmLookupMPNRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    MWQMLookupMPN mwqmLookupMPN = (MWQMLookupMPN)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = mwqmLookupMPNController.Delete(mwqmLookupMPNRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because MWQMLookupMPNID of 0 does not exist
                    mwqmLookupMPNRet.MWQMLookupMPNID = 0;
                    IActionResult jsonRet4 = mwqmLookupMPNController.Delete(mwqmLookupMPNRet, LanguageRequest.ToString());
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
