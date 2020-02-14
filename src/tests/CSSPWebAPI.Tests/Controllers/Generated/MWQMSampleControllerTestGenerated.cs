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
    public partial class MWQMSampleControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MWQMSampleControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void MWQMSample_Controller_GetMWQMSampleList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMSampleController mwqmSampleController = new MWQMSampleController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mwqmSampleController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mwqmSampleController.DatabaseType);

                    MWQMSample mwqmSampleFirst = new MWQMSample();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        MWQMSampleService mwqmSampleService = new MWQMSampleService(query, db, ContactID);
                        mwqmSampleFirst = (from c in db.MWQMSamples select c).FirstOrDefault();
                        count = (from c in db.MWQMSamples select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with MWQMSample info
                    IActionResult jsonRet = mwqmSampleController.GetMWQMSampleList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(mwqmSampleFirst.MWQMSampleID, ((List<MWQMSample>)ret.Value)[0].MWQMSampleID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<MWQMSample>)ret.Value).Count);

                    List<MWQMSample> mwqmSampleList = new List<MWQMSample>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        MWQMSampleService mwqmSampleService = new MWQMSampleService(query, db, ContactID);
                        mwqmSampleList = (from c in db.MWQMSamples select c).OrderBy(c => c.MWQMSampleID).Skip(0).Take(2).ToList();
                        count = (from c in db.MWQMSamples select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with MWQMSample info
                        jsonRet = mwqmSampleController.GetMWQMSampleList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(mwqmSampleList[0].MWQMSampleID, ((List<MWQMSample>)ret.Value)[0].MWQMSampleID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<MWQMSample>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with MWQMSample info
                           IActionResult jsonRet2 = mwqmSampleController.GetMWQMSampleList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(mwqmSampleList[1].MWQMSampleID, ((List<MWQMSample>)ret2.Value)[0].MWQMSampleID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<MWQMSample>)ret2.Value).Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void MWQMSample_Controller_GetMWQMSampleWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMSampleController mwqmSampleController = new MWQMSampleController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mwqmSampleController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mwqmSampleController.DatabaseType);

                    MWQMSample mwqmSampleFirst = new MWQMSample();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        MWQMSampleService mwqmSampleService = new MWQMSampleService(new Query(), db, ContactID);
                        mwqmSampleFirst = (from c in db.MWQMSamples select c).FirstOrDefault();
                    }

                    // ok with MWQMSample info
                    IActionResult jsonRet = mwqmSampleController.GetMWQMSampleWithID(mwqmSampleFirst.MWQMSampleID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(mwqmSampleFirst.MWQMSampleID, ((MWQMSample)ret.Value).MWQMSampleID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = mwqmSampleController.GetMWQMSampleWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult mwqmSampleRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(mwqmSampleRet2);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void MWQMSample_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMSampleController mwqmSampleController = new MWQMSampleController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mwqmSampleController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mwqmSampleController.DatabaseType);

                    MWQMSample mwqmSampleLast = new MWQMSample();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MWQMSampleService mwqmSampleService = new MWQMSampleService(query, db, ContactID);
                        mwqmSampleLast = (from c in db.MWQMSamples select c).FirstOrDefault();
                    }

                    // ok with MWQMSample info
                    IActionResult jsonRet = mwqmSampleController.GetMWQMSampleWithID(mwqmSampleLast.MWQMSampleID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    MWQMSample mwqmSampleRet = (MWQMSample)ret.Value;
                    Assert.Equal(mwqmSampleLast.MWQMSampleID, mwqmSampleRet.MWQMSampleID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because MWQMSampleID exist
                    IActionResult jsonRet2 = mwqmSampleController.Post(mwqmSampleRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added MWQMSample
                    mwqmSampleRet.MWQMSampleID = 0;
                    IActionResult jsonRet3 = mwqmSampleController.Post(mwqmSampleRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = mwqmSampleController.Delete(mwqmSampleRet, LanguageRequest.ToString());
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
        public void MWQMSample_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMSampleController mwqmSampleController = new MWQMSampleController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mwqmSampleController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mwqmSampleController.DatabaseType);

                    MWQMSample mwqmSampleLast = new MWQMSample();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        MWQMSampleService mwqmSampleService = new MWQMSampleService(query, db, ContactID);
                        mwqmSampleLast = (from c in db.MWQMSamples select c).FirstOrDefault();
                    }

                    // ok with MWQMSample info
                    IActionResult jsonRet = mwqmSampleController.GetMWQMSampleWithID(mwqmSampleLast.MWQMSampleID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    MWQMSample mwqmSampleRet = (MWQMSample)Ret.Value;
                    Assert.Equal(mwqmSampleLast.MWQMSampleID, mwqmSampleRet.MWQMSampleID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = mwqmSampleController.Put(mwqmSampleRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult mwqmSampleRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(mwqmSampleRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because MWQMSampleID of 0 does not exist
                    mwqmSampleRet.MWQMSampleID = 0;
                    IActionResult jsonRet3 = mwqmSampleController.Put(mwqmSampleRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult mwqmSampleRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(mwqmSampleRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void MWQMSample_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MWQMSampleController mwqmSampleController = new MWQMSampleController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mwqmSampleController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mwqmSampleController.DatabaseType);

                    MWQMSample mwqmSampleLast = new MWQMSample();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MWQMSampleService mwqmSampleService = new MWQMSampleService(query, db, ContactID);
                        mwqmSampleLast = (from c in db.MWQMSamples select c).FirstOrDefault();
                    }

                    // ok with MWQMSample info
                    IActionResult jsonRet = mwqmSampleController.GetMWQMSampleWithID(mwqmSampleLast.MWQMSampleID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    MWQMSample mwqmSampleRet = (MWQMSample)Ret.Value;
                    Assert.Equal(mwqmSampleLast.MWQMSampleID, mwqmSampleRet.MWQMSampleID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added MWQMSample
                    mwqmSampleRet.MWQMSampleID = 0;
                    IActionResult jsonRet3 = mwqmSampleController.Post(mwqmSampleRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    MWQMSample mwqmSample = (MWQMSample)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = mwqmSampleController.Delete(mwqmSampleRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because MWQMSampleID of 0 does not exist
                    mwqmSampleRet.MWQMSampleID = 0;
                    IActionResult jsonRet4 = mwqmSampleController.Delete(mwqmSampleRet, LanguageRequest.ToString());
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
