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
    public partial class MWQMAnalysisReportParameterControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MWQMAnalysisReportParameterControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void MWQMAnalysisReportParameter_Controller_GetMWQMAnalysisReportParameterList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMAnalysisReportParameterController mwqmAnalysisReportParameterController = new MWQMAnalysisReportParameterController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mwqmAnalysisReportParameterController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mwqmAnalysisReportParameterController.DatabaseType);

                    MWQMAnalysisReportParameter mwqmAnalysisReportParameterFirst = new MWQMAnalysisReportParameter();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        MWQMAnalysisReportParameterService mwqmAnalysisReportParameterService = new MWQMAnalysisReportParameterService(query, db, ContactID);
                        mwqmAnalysisReportParameterFirst = (from c in db.MWQMAnalysisReportParameters select c).FirstOrDefault();
                        count = (from c in db.MWQMAnalysisReportParameters select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with MWQMAnalysisReportParameter info
                    IActionResult jsonRet = mwqmAnalysisReportParameterController.GetMWQMAnalysisReportParameterList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(mwqmAnalysisReportParameterFirst.MWQMAnalysisReportParameterID, ((List<MWQMAnalysisReportParameter>)ret.Value)[0].MWQMAnalysisReportParameterID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<MWQMAnalysisReportParameter>)ret.Value).Count);

                    List<MWQMAnalysisReportParameter> mwqmAnalysisReportParameterList = new List<MWQMAnalysisReportParameter>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        MWQMAnalysisReportParameterService mwqmAnalysisReportParameterService = new MWQMAnalysisReportParameterService(query, db, ContactID);
                        mwqmAnalysisReportParameterList = (from c in db.MWQMAnalysisReportParameters select c).OrderBy(c => c.MWQMAnalysisReportParameterID).Skip(0).Take(2).ToList();
                        count = (from c in db.MWQMAnalysisReportParameters select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with MWQMAnalysisReportParameter info
                        jsonRet = mwqmAnalysisReportParameterController.GetMWQMAnalysisReportParameterList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(mwqmAnalysisReportParameterList[0].MWQMAnalysisReportParameterID, ((List<MWQMAnalysisReportParameter>)ret.Value)[0].MWQMAnalysisReportParameterID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<MWQMAnalysisReportParameter>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with MWQMAnalysisReportParameter info
                           IActionResult jsonRet2 = mwqmAnalysisReportParameterController.GetMWQMAnalysisReportParameterList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(mwqmAnalysisReportParameterList[1].MWQMAnalysisReportParameterID, ((List<MWQMAnalysisReportParameter>)ret2.Value)[0].MWQMAnalysisReportParameterID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<MWQMAnalysisReportParameter>)ret2.Value).Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void MWQMAnalysisReportParameter_Controller_GetMWQMAnalysisReportParameterWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMAnalysisReportParameterController mwqmAnalysisReportParameterController = new MWQMAnalysisReportParameterController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mwqmAnalysisReportParameterController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mwqmAnalysisReportParameterController.DatabaseType);

                    MWQMAnalysisReportParameter mwqmAnalysisReportParameterFirst = new MWQMAnalysisReportParameter();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        MWQMAnalysisReportParameterService mwqmAnalysisReportParameterService = new MWQMAnalysisReportParameterService(new Query(), db, ContactID);
                        mwqmAnalysisReportParameterFirst = (from c in db.MWQMAnalysisReportParameters select c).FirstOrDefault();
                    }

                    // ok with MWQMAnalysisReportParameter info
                    IActionResult jsonRet = mwqmAnalysisReportParameterController.GetMWQMAnalysisReportParameterWithID(mwqmAnalysisReportParameterFirst.MWQMAnalysisReportParameterID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(mwqmAnalysisReportParameterFirst.MWQMAnalysisReportParameterID, ((MWQMAnalysisReportParameter)ret.Value).MWQMAnalysisReportParameterID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = mwqmAnalysisReportParameterController.GetMWQMAnalysisReportParameterWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult mwqmAnalysisReportParameterRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(mwqmAnalysisReportParameterRet2);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void MWQMAnalysisReportParameter_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMAnalysisReportParameterController mwqmAnalysisReportParameterController = new MWQMAnalysisReportParameterController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mwqmAnalysisReportParameterController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mwqmAnalysisReportParameterController.DatabaseType);

                    MWQMAnalysisReportParameter mwqmAnalysisReportParameterFirst = new MWQMAnalysisReportParameter();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MWQMAnalysisReportParameterService mwqmAnalysisReportParameterService = new MWQMAnalysisReportParameterService(query, db, ContactID);
                        mwqmAnalysisReportParameterFirst = (from c in db.MWQMAnalysisReportParameters select c).FirstOrDefault();
                    }

                    // ok with MWQMAnalysisReportParameter info
                    IActionResult jsonRet = mwqmAnalysisReportParameterController.GetMWQMAnalysisReportParameterWithID(mwqmAnalysisReportParameterFirst.MWQMAnalysisReportParameterID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    MWQMAnalysisReportParameter mwqmAnalysisReportParameterRet = (MWQMAnalysisReportParameter)ret.Value;
                    Assert.Equal(mwqmAnalysisReportParameterFirst.MWQMAnalysisReportParameterID, mwqmAnalysisReportParameterRet.MWQMAnalysisReportParameterID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because MWQMAnalysisReportParameterID exist
                    IActionResult jsonRet2 = mwqmAnalysisReportParameterController.Post(mwqmAnalysisReportParameterRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added MWQMAnalysisReportParameter
                    mwqmAnalysisReportParameterRet.MWQMAnalysisReportParameterID = 0;
                    IActionResult jsonRet3 = mwqmAnalysisReportParameterController.Post(mwqmAnalysisReportParameterRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = mwqmAnalysisReportParameterController.Delete(mwqmAnalysisReportParameterRet, LanguageRequest.ToString());
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
        public void MWQMAnalysisReportParameter_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMAnalysisReportParameterController mwqmAnalysisReportParameterController = new MWQMAnalysisReportParameterController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mwqmAnalysisReportParameterController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mwqmAnalysisReportParameterController.DatabaseType);

                    MWQMAnalysisReportParameter mwqmAnalysisReportParameterFirst = new MWQMAnalysisReportParameter();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        MWQMAnalysisReportParameterService mwqmAnalysisReportParameterService = new MWQMAnalysisReportParameterService(query, db, ContactID);
                        mwqmAnalysisReportParameterFirst = (from c in db.MWQMAnalysisReportParameters select c).FirstOrDefault();
                    }

                    // ok with MWQMAnalysisReportParameter info
                    IActionResult jsonRet = mwqmAnalysisReportParameterController.GetMWQMAnalysisReportParameterWithID(mwqmAnalysisReportParameterFirst.MWQMAnalysisReportParameterID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    MWQMAnalysisReportParameter mwqmAnalysisReportParameterRet = (MWQMAnalysisReportParameter)Ret.Value;
                    Assert.Equal(mwqmAnalysisReportParameterFirst.MWQMAnalysisReportParameterID, mwqmAnalysisReportParameterRet.MWQMAnalysisReportParameterID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = mwqmAnalysisReportParameterController.Put(mwqmAnalysisReportParameterRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult mwqmAnalysisReportParameterRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(mwqmAnalysisReportParameterRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because MWQMAnalysisReportParameterID of 0 does not exist
                    mwqmAnalysisReportParameterRet.MWQMAnalysisReportParameterID = 0;
                    IActionResult jsonRet3 = mwqmAnalysisReportParameterController.Put(mwqmAnalysisReportParameterRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult mwqmAnalysisReportParameterRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(mwqmAnalysisReportParameterRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void MWQMAnalysisReportParameter_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMAnalysisReportParameterController mwqmAnalysisReportParameterController = new MWQMAnalysisReportParameterController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mwqmAnalysisReportParameterController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mwqmAnalysisReportParameterController.DatabaseType);

                    MWQMAnalysisReportParameter mwqmAnalysisReportParameterFirst = new MWQMAnalysisReportParameter();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MWQMAnalysisReportParameterService mwqmAnalysisReportParameterService = new MWQMAnalysisReportParameterService(query, db, ContactID);
                        mwqmAnalysisReportParameterFirst = (from c in db.MWQMAnalysisReportParameters select c).FirstOrDefault();
                    }

                    // ok with MWQMAnalysisReportParameter info
                    IActionResult jsonRet = mwqmAnalysisReportParameterController.GetMWQMAnalysisReportParameterWithID(mwqmAnalysisReportParameterFirst.MWQMAnalysisReportParameterID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    MWQMAnalysisReportParameter mwqmAnalysisReportParameterRet = (MWQMAnalysisReportParameter)Ret.Value;
                    Assert.Equal(mwqmAnalysisReportParameterFirst.MWQMAnalysisReportParameterID, mwqmAnalysisReportParameterRet.MWQMAnalysisReportParameterID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added MWQMAnalysisReportParameter
                    mwqmAnalysisReportParameterRet.MWQMAnalysisReportParameterID = 0;
                    IActionResult jsonRet3 = mwqmAnalysisReportParameterController.Post(mwqmAnalysisReportParameterRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    MWQMAnalysisReportParameter mwqmAnalysisReportParameter = (MWQMAnalysisReportParameter)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = mwqmAnalysisReportParameterController.Delete(mwqmAnalysisReportParameterRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because MWQMAnalysisReportParameterID of 0 does not exist
                    mwqmAnalysisReportParameterRet.MWQMAnalysisReportParameterID = 0;
                    IActionResult jsonRet4 = mwqmAnalysisReportParameterController.Delete(mwqmAnalysisReportParameterRet, LanguageRequest.ToString());
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
