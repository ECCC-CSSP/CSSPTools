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
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<List<MWQMSiteStartEndDate>> ret = jsonRet as OkNegotiatedContentResult<List<MWQMSiteStartEndDate>>;
                    Assert.Equal(mwqmSiteStartEndDateFirst.MWQMSiteStartEndDateID, ret.Content[0].MWQMSiteStartEndDateID);
                    Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

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
                        Assert.NotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<MWQMSiteStartEndDate>>;
                        Assert.Equal(mwqmSiteStartEndDateList[0].MWQMSiteStartEndDateID, ret.Content[0].MWQMSiteStartEndDateID);
                        Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with MWQMSiteStartEndDate info
                           IActionResult jsonRet2 = mwqmSiteStartEndDateController.GetMWQMSiteStartEndDateList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkNegotiatedContentResult<List<MWQMSiteStartEndDate>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<MWQMSiteStartEndDate>>;
                           Assert.Equal(mwqmSiteStartEndDateList[1].MWQMSiteStartEndDateID, ret2.Content[0].MWQMSiteStartEndDateID);
                           Assert.Equal((count > query.Take ? query.Take : count), ret2.Content.Count);
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
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<MWQMSiteStartEndDate> Ret = jsonRet as OkNegotiatedContentResult<MWQMSiteStartEndDate>;
                    MWQMSiteStartEndDate mwqmSiteStartEndDateRet = Ret.Content;
                    Assert.Equal(mwqmSiteStartEndDateFirst.MWQMSiteStartEndDateID, mwqmSiteStartEndDateRet.MWQMSiteStartEndDateID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = mwqmSiteStartEndDateController.GetMWQMSiteStartEndDateWithID(0);
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<MWQMSiteStartEndDate> mwqmSiteStartEndDateRet2 = jsonRet2 as OkNegotiatedContentResult<MWQMSiteStartEndDate>;
                    Assert.Null(mwqmSiteStartEndDateRet2);

                    NotFoundObjectResult notFoundRequest = jsonRet2 as NotFoundObjectResult;
                    Assert.NotNull(notFoundRequest);
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

                    MWQMSiteStartEndDate mwqmSiteStartEndDateLast = new MWQMSiteStartEndDate();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MWQMSiteStartEndDateService mwqmSiteStartEndDateService = new MWQMSiteStartEndDateService(query, db, ContactID);
                        mwqmSiteStartEndDateLast = (from c in db.MWQMSiteStartEndDates select c).FirstOrDefault();
                    }

                    // ok with MWQMSiteStartEndDate info
                    IActionResult jsonRet = mwqmSiteStartEndDateController.GetMWQMSiteStartEndDateWithID(mwqmSiteStartEndDateLast.MWQMSiteStartEndDateID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<MWQMSiteStartEndDate> Ret = jsonRet as OkNegotiatedContentResult<MWQMSiteStartEndDate>;
                    MWQMSiteStartEndDate mwqmSiteStartEndDateRet = Ret.Content;
                    Assert.Equal(mwqmSiteStartEndDateLast.MWQMSiteStartEndDateID, mwqmSiteStartEndDateRet.MWQMSiteStartEndDateID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because MWQMSiteStartEndDateID exist
                    IActionResult jsonRet2 = mwqmSiteStartEndDateController.Post(mwqmSiteStartEndDateRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<MWQMSiteStartEndDate> mwqmSiteStartEndDateRet2 = jsonRet2 as OkNegotiatedContentResult<MWQMSiteStartEndDate>;
                    Assert.Null(mwqmSiteStartEndDateRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added MWQMSiteStartEndDate
                    mwqmSiteStartEndDateRet.MWQMSiteStartEndDateID = 0;
                    IActionResult jsonRet3 = mwqmSiteStartEndDateController.Post(mwqmSiteStartEndDateRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<MWQMSiteStartEndDate> mwqmSiteStartEndDateRet3 = jsonRet3 as CreatedNegotiatedContentResult<MWQMSiteStartEndDate>;
                    Assert.NotNull(mwqmSiteStartEndDateRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = mwqmSiteStartEndDateController.Delete(mwqmSiteStartEndDateRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<MWQMSiteStartEndDate> mwqmSiteStartEndDateRet4 = jsonRet4 as OkNegotiatedContentResult<MWQMSiteStartEndDate>;
                    Assert.NotNull(mwqmSiteStartEndDateRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
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

                    MWQMSiteStartEndDate mwqmSiteStartEndDateLast = new MWQMSiteStartEndDate();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        MWQMSiteStartEndDateService mwqmSiteStartEndDateService = new MWQMSiteStartEndDateService(query, db, ContactID);
                        mwqmSiteStartEndDateLast = (from c in db.MWQMSiteStartEndDates select c).FirstOrDefault();
                    }

                    // ok with MWQMSiteStartEndDate info
                    IActionResult jsonRet = mwqmSiteStartEndDateController.GetMWQMSiteStartEndDateWithID(mwqmSiteStartEndDateLast.MWQMSiteStartEndDateID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<MWQMSiteStartEndDate> Ret = jsonRet as OkNegotiatedContentResult<MWQMSiteStartEndDate>;
                    MWQMSiteStartEndDate mwqmSiteStartEndDateRet = Ret.Content;
                    Assert.Equal(mwqmSiteStartEndDateLast.MWQMSiteStartEndDateID, mwqmSiteStartEndDateRet.MWQMSiteStartEndDateID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = mwqmSiteStartEndDateController.Put(mwqmSiteStartEndDateRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<MWQMSiteStartEndDate> mwqmSiteStartEndDateRet2 = jsonRet2 as OkNegotiatedContentResult<MWQMSiteStartEndDate>;
                    Assert.NotNull(mwqmSiteStartEndDateRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because MWQMSiteStartEndDateID of 0 does not exist
                    mwqmSiteStartEndDateRet.MWQMSiteStartEndDateID = 0;
                    IActionResult jsonRet3 = mwqmSiteStartEndDateController.Put(mwqmSiteStartEndDateRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    OkNegotiatedContentResult<MWQMSiteStartEndDate> mwqmSiteStartEndDateRet3 = jsonRet3 as OkNegotiatedContentResult<MWQMSiteStartEndDate>;
                    Assert.Null(mwqmSiteStartEndDateRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
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

                    MWQMSiteStartEndDate mwqmSiteStartEndDateLast = new MWQMSiteStartEndDate();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MWQMSiteStartEndDateService mwqmSiteStartEndDateService = new MWQMSiteStartEndDateService(query, db, ContactID);
                        mwqmSiteStartEndDateLast = (from c in db.MWQMSiteStartEndDates select c).FirstOrDefault();
                    }

                    // ok with MWQMSiteStartEndDate info
                    IActionResult jsonRet = mwqmSiteStartEndDateController.GetMWQMSiteStartEndDateWithID(mwqmSiteStartEndDateLast.MWQMSiteStartEndDateID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<MWQMSiteStartEndDate> Ret = jsonRet as OkNegotiatedContentResult<MWQMSiteStartEndDate>;
                    MWQMSiteStartEndDate mwqmSiteStartEndDateRet = Ret.Content;
                    Assert.Equal(mwqmSiteStartEndDateLast.MWQMSiteStartEndDateID, mwqmSiteStartEndDateRet.MWQMSiteStartEndDateID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return newly added MWQMSiteStartEndDate
                    mwqmSiteStartEndDateRet.MWQMSiteStartEndDateID = 0;
                    IActionResult jsonRet3 = mwqmSiteStartEndDateController.Post(mwqmSiteStartEndDateRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<MWQMSiteStartEndDate> mwqmSiteStartEndDateRet3 = jsonRet3 as CreatedNegotiatedContentResult<MWQMSiteStartEndDate>;
                    Assert.NotNull(mwqmSiteStartEndDateRet3);
                    MWQMSiteStartEndDate mwqmSiteStartEndDate = mwqmSiteStartEndDateRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = mwqmSiteStartEndDateController.Delete(mwqmSiteStartEndDateRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<MWQMSiteStartEndDate> mwqmSiteStartEndDateRet2 = jsonRet2 as OkNegotiatedContentResult<MWQMSiteStartEndDate>;
                    Assert.NotNull(mwqmSiteStartEndDateRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because MWQMSiteStartEndDateID of 0 does not exist
                    mwqmSiteStartEndDateRet.MWQMSiteStartEndDateID = 0;
                    IActionResult jsonRet4 = mwqmSiteStartEndDateController.Delete(mwqmSiteStartEndDateRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<MWQMSiteStartEndDate> mwqmSiteStartEndDateRet4 = jsonRet4 as OkNegotiatedContentResult<MWQMSiteStartEndDate>;
                    Assert.Null(mwqmSiteStartEndDateRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
