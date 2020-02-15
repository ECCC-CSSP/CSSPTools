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
    public partial class MWQMSiteStartEndDateControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MWQMSiteStartEndDateControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void MWQMSiteStartEndDate_Controller_GetMWQMSiteStartEndDateList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMSiteStartEndDateController mwqmSiteStartEndDateController = new MWQMSiteStartEndDateController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mwqmSiteStartEndDateController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mwqmSiteStartEndDateController.DatabaseType);

                    MWQMSiteStartEndDate mwqmSiteStartEndDateFirst = new MWQMSiteStartEndDate();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        MWQMSiteStartEndDateService mwqmSiteStartEndDateService = new MWQMSiteStartEndDateService(query, db, ContactID);
                        mwqmSiteStartEndDateFirst = (from c in db.MWQMSiteStartEndDates select c).FirstOrDefault();
                        count = (from c in db.MWQMSiteStartEndDates select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with MWQMSiteStartEndDate info
                    IActionResult jsonRet = mwqmSiteStartEndDateController.GetMWQMSiteStartEndDateList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(mwqmSiteStartEndDateFirst.MWQMSiteStartEndDateID, ((List<MWQMSiteStartEndDate>)ret.Value)[0].MWQMSiteStartEndDateID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<MWQMSiteStartEndDate>)ret.Value).Count);

                    List<MWQMSiteStartEndDate> mwqmSiteStartEndDateList = new List<MWQMSiteStartEndDate>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        MWQMSiteStartEndDateService mwqmSiteStartEndDateService = new MWQMSiteStartEndDateService(query, db, ContactID);
                        mwqmSiteStartEndDateList = (from c in db.MWQMSiteStartEndDates select c).OrderBy(c => c.MWQMSiteStartEndDateID).Skip(0).Take(2).ToList();
                        count = (from c in db.MWQMSiteStartEndDates select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with MWQMSiteStartEndDate info
                        jsonRet = mwqmSiteStartEndDateController.GetMWQMSiteStartEndDateList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(mwqmSiteStartEndDateList[0].MWQMSiteStartEndDateID, ((List<MWQMSiteStartEndDate>)ret.Value)[0].MWQMSiteStartEndDateID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<MWQMSiteStartEndDate>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with MWQMSiteStartEndDate info
                           IActionResult jsonRet2 = mwqmSiteStartEndDateController.GetMWQMSiteStartEndDateList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(mwqmSiteStartEndDateList[1].MWQMSiteStartEndDateID, ((List<MWQMSiteStartEndDate>)ret2.Value)[0].MWQMSiteStartEndDateID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<MWQMSiteStartEndDate>)ret2.Value).Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void MWQMSiteStartEndDate_Controller_GetMWQMSiteStartEndDateWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMSiteStartEndDateController mwqmSiteStartEndDateController = new MWQMSiteStartEndDateController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mwqmSiteStartEndDateController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mwqmSiteStartEndDateController.DatabaseType);

                    MWQMSiteStartEndDate mwqmSiteStartEndDateFirst = new MWQMSiteStartEndDate();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        MWQMSiteStartEndDateService mwqmSiteStartEndDateService = new MWQMSiteStartEndDateService(new Query(), db, ContactID);
                        mwqmSiteStartEndDateFirst = (from c in db.MWQMSiteStartEndDates select c).FirstOrDefault();
                    }

                    // ok with MWQMSiteStartEndDate info
                    IActionResult jsonRet = mwqmSiteStartEndDateController.GetMWQMSiteStartEndDateWithID(mwqmSiteStartEndDateFirst.MWQMSiteStartEndDateID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(mwqmSiteStartEndDateFirst.MWQMSiteStartEndDateID, ((MWQMSiteStartEndDate)ret.Value).MWQMSiteStartEndDateID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = mwqmSiteStartEndDateController.GetMWQMSiteStartEndDateWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult mwqmSiteStartEndDateRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(mwqmSiteStartEndDateRet2);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void MWQMSiteStartEndDate_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMSiteStartEndDateController mwqmSiteStartEndDateController = new MWQMSiteStartEndDateController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mwqmSiteStartEndDateController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mwqmSiteStartEndDateController.DatabaseType);

                    MWQMSiteStartEndDate mwqmSiteStartEndDateFirst = new MWQMSiteStartEndDate();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MWQMSiteStartEndDateService mwqmSiteStartEndDateService = new MWQMSiteStartEndDateService(query, db, ContactID);
                        mwqmSiteStartEndDateFirst = (from c in db.MWQMSiteStartEndDates select c).FirstOrDefault();
                    }

                    // ok with MWQMSiteStartEndDate info
                    IActionResult jsonRet = mwqmSiteStartEndDateController.GetMWQMSiteStartEndDateWithID(mwqmSiteStartEndDateFirst.MWQMSiteStartEndDateID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    MWQMSiteStartEndDate mwqmSiteStartEndDateRet = (MWQMSiteStartEndDate)ret.Value;
                    Assert.Equal(mwqmSiteStartEndDateFirst.MWQMSiteStartEndDateID, mwqmSiteStartEndDateRet.MWQMSiteStartEndDateID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because MWQMSiteStartEndDateID exist
                    IActionResult jsonRet2 = mwqmSiteStartEndDateController.Post(mwqmSiteStartEndDateRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added MWQMSiteStartEndDate
                    mwqmSiteStartEndDateRet.MWQMSiteStartEndDateID = 0;
                    IActionResult jsonRet3 = mwqmSiteStartEndDateController.Post(mwqmSiteStartEndDateRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = mwqmSiteStartEndDateController.Delete(mwqmSiteStartEndDateRet, LanguageRequest.ToString());
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
        public void MWQMSiteStartEndDate_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMSiteStartEndDateController mwqmSiteStartEndDateController = new MWQMSiteStartEndDateController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mwqmSiteStartEndDateController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mwqmSiteStartEndDateController.DatabaseType);

                    MWQMSiteStartEndDate mwqmSiteStartEndDateFirst = new MWQMSiteStartEndDate();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        MWQMSiteStartEndDateService mwqmSiteStartEndDateService = new MWQMSiteStartEndDateService(query, db, ContactID);
                        mwqmSiteStartEndDateFirst = (from c in db.MWQMSiteStartEndDates select c).FirstOrDefault();
                    }

                    // ok with MWQMSiteStartEndDate info
                    IActionResult jsonRet = mwqmSiteStartEndDateController.GetMWQMSiteStartEndDateWithID(mwqmSiteStartEndDateFirst.MWQMSiteStartEndDateID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    MWQMSiteStartEndDate mwqmSiteStartEndDateRet = (MWQMSiteStartEndDate)Ret.Value;
                    Assert.Equal(mwqmSiteStartEndDateFirst.MWQMSiteStartEndDateID, mwqmSiteStartEndDateRet.MWQMSiteStartEndDateID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = mwqmSiteStartEndDateController.Put(mwqmSiteStartEndDateRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult mwqmSiteStartEndDateRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(mwqmSiteStartEndDateRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because MWQMSiteStartEndDateID of 0 does not exist
                    mwqmSiteStartEndDateRet.MWQMSiteStartEndDateID = 0;
                    IActionResult jsonRet3 = mwqmSiteStartEndDateController.Put(mwqmSiteStartEndDateRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult mwqmSiteStartEndDateRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(mwqmSiteStartEndDateRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void MWQMSiteStartEndDate_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMSiteStartEndDateController mwqmSiteStartEndDateController = new MWQMSiteStartEndDateController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mwqmSiteStartEndDateController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mwqmSiteStartEndDateController.DatabaseType);

                    MWQMSiteStartEndDate mwqmSiteStartEndDateFirst = new MWQMSiteStartEndDate();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MWQMSiteStartEndDateService mwqmSiteStartEndDateService = new MWQMSiteStartEndDateService(query, db, ContactID);
                        mwqmSiteStartEndDateFirst = (from c in db.MWQMSiteStartEndDates select c).FirstOrDefault();
                    }

                    // ok with MWQMSiteStartEndDate info
                    IActionResult jsonRet = mwqmSiteStartEndDateController.GetMWQMSiteStartEndDateWithID(mwqmSiteStartEndDateFirst.MWQMSiteStartEndDateID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    MWQMSiteStartEndDate mwqmSiteStartEndDateRet = (MWQMSiteStartEndDate)Ret.Value;
                    Assert.Equal(mwqmSiteStartEndDateFirst.MWQMSiteStartEndDateID, mwqmSiteStartEndDateRet.MWQMSiteStartEndDateID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added MWQMSiteStartEndDate
                    mwqmSiteStartEndDateRet.MWQMSiteStartEndDateID = 0;
                    IActionResult jsonRet3 = mwqmSiteStartEndDateController.Post(mwqmSiteStartEndDateRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    MWQMSiteStartEndDate mwqmSiteStartEndDate = (MWQMSiteStartEndDate)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = mwqmSiteStartEndDateController.Delete(mwqmSiteStartEndDateRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because MWQMSiteStartEndDateID of 0 does not exist
                    mwqmSiteStartEndDateRet.MWQMSiteStartEndDateID = 0;
                    IActionResult jsonRet4 = mwqmSiteStartEndDateController.Delete(mwqmSiteStartEndDateRet, LanguageRequest.ToString());
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
