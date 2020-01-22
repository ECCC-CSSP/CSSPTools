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
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<List<MWQMAnalysisReportParameter>> ret = jsonRet as OkNegotiatedContentResult<List<MWQMAnalysisReportParameter>>;
                    Assert.Equal(mwqmAnalysisReportParameterFirst.MWQMAnalysisReportParameterID, ret.Content[0].MWQMAnalysisReportParameterID);
                    Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

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
                        Assert.NotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<MWQMAnalysisReportParameter>>;
                        Assert.Equal(mwqmAnalysisReportParameterList[0].MWQMAnalysisReportParameterID, ret.Content[0].MWQMAnalysisReportParameterID);
                        Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with MWQMAnalysisReportParameter info
                           IActionResult jsonRet2 = mwqmAnalysisReportParameterController.GetMWQMAnalysisReportParameterList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkNegotiatedContentResult<List<MWQMAnalysisReportParameter>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<MWQMAnalysisReportParameter>>;
                           Assert.Equal(mwqmAnalysisReportParameterList[1].MWQMAnalysisReportParameterID, ret2.Content[0].MWQMAnalysisReportParameterID);
                           Assert.Equal((count > query.Take ? query.Take : count), ret2.Content.Count);
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
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<MWQMAnalysisReportParameter> Ret = jsonRet as OkNegotiatedContentResult<MWQMAnalysisReportParameter>;
                    MWQMAnalysisReportParameter mwqmAnalysisReportParameterRet = Ret.Content;
                    Assert.Equal(mwqmAnalysisReportParameterFirst.MWQMAnalysisReportParameterID, mwqmAnalysisReportParameterRet.MWQMAnalysisReportParameterID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = mwqmAnalysisReportParameterController.GetMWQMAnalysisReportParameterWithID(0);
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<MWQMAnalysisReportParameter> mwqmAnalysisReportParameterRet2 = jsonRet2 as OkNegotiatedContentResult<MWQMAnalysisReportParameter>;
                    Assert.Null(mwqmAnalysisReportParameterRet2);

                    NotFoundObjectResult notFoundRequest = jsonRet2 as NotFoundObjectResult;
                    Assert.NotNull(notFoundRequest);
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

                    MWQMAnalysisReportParameter mwqmAnalysisReportParameterLast = new MWQMAnalysisReportParameter();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MWQMAnalysisReportParameterService mwqmAnalysisReportParameterService = new MWQMAnalysisReportParameterService(query, db, ContactID);
                        mwqmAnalysisReportParameterLast = (from c in db.MWQMAnalysisReportParameters select c).FirstOrDefault();
                    }

                    // ok with MWQMAnalysisReportParameter info
                    IActionResult jsonRet = mwqmAnalysisReportParameterController.GetMWQMAnalysisReportParameterWithID(mwqmAnalysisReportParameterLast.MWQMAnalysisReportParameterID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<MWQMAnalysisReportParameter> Ret = jsonRet as OkNegotiatedContentResult<MWQMAnalysisReportParameter>;
                    MWQMAnalysisReportParameter mwqmAnalysisReportParameterRet = Ret.Content;
                    Assert.Equal(mwqmAnalysisReportParameterLast.MWQMAnalysisReportParameterID, mwqmAnalysisReportParameterRet.MWQMAnalysisReportParameterID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because MWQMAnalysisReportParameterID exist
                    IActionResult jsonRet2 = mwqmAnalysisReportParameterController.Post(mwqmAnalysisReportParameterRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<MWQMAnalysisReportParameter> mwqmAnalysisReportParameterRet2 = jsonRet2 as OkNegotiatedContentResult<MWQMAnalysisReportParameter>;
                    Assert.Null(mwqmAnalysisReportParameterRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added MWQMAnalysisReportParameter
                    mwqmAnalysisReportParameterRet.MWQMAnalysisReportParameterID = 0;
                    mwqmAnalysisReportParameterController.Request = new System.Net.Http.HttpRequestMessage();
                    mwqmAnalysisReportParameterController.Request.RequestUri = new System.Uri("http://localhost:5000/api/mwqmAnalysisReportParameter");
                    IActionResult jsonRet3 = mwqmAnalysisReportParameterController.Post(mwqmAnalysisReportParameterRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<MWQMAnalysisReportParameter> mwqmAnalysisReportParameterRet3 = jsonRet3 as CreatedNegotiatedContentResult<MWQMAnalysisReportParameter>;
                    Assert.NotNull(mwqmAnalysisReportParameterRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = mwqmAnalysisReportParameterController.Delete(mwqmAnalysisReportParameterRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<MWQMAnalysisReportParameter> mwqmAnalysisReportParameterRet4 = jsonRet4 as OkNegotiatedContentResult<MWQMAnalysisReportParameter>;
                    Assert.NotNull(mwqmAnalysisReportParameterRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
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

                    MWQMAnalysisReportParameter mwqmAnalysisReportParameterLast = new MWQMAnalysisReportParameter();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        MWQMAnalysisReportParameterService mwqmAnalysisReportParameterService = new MWQMAnalysisReportParameterService(query, db, ContactID);
                        mwqmAnalysisReportParameterLast = (from c in db.MWQMAnalysisReportParameters select c).FirstOrDefault();
                    }

                    // ok with MWQMAnalysisReportParameter info
                    IActionResult jsonRet = mwqmAnalysisReportParameterController.GetMWQMAnalysisReportParameterWithID(mwqmAnalysisReportParameterLast.MWQMAnalysisReportParameterID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<MWQMAnalysisReportParameter> Ret = jsonRet as OkNegotiatedContentResult<MWQMAnalysisReportParameter>;
                    MWQMAnalysisReportParameter mwqmAnalysisReportParameterRet = Ret.Content;
                    Assert.Equal(mwqmAnalysisReportParameterLast.MWQMAnalysisReportParameterID, mwqmAnalysisReportParameterRet.MWQMAnalysisReportParameterID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = mwqmAnalysisReportParameterController.Put(mwqmAnalysisReportParameterRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<MWQMAnalysisReportParameter> mwqmAnalysisReportParameterRet2 = jsonRet2 as OkNegotiatedContentResult<MWQMAnalysisReportParameter>;
                    Assert.NotNull(mwqmAnalysisReportParameterRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because MWQMAnalysisReportParameterID of 0 does not exist
                    mwqmAnalysisReportParameterRet.MWQMAnalysisReportParameterID = 0;
                    IActionResult jsonRet3 = mwqmAnalysisReportParameterController.Put(mwqmAnalysisReportParameterRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    OkNegotiatedContentResult<MWQMAnalysisReportParameter> mwqmAnalysisReportParameterRet3 = jsonRet3 as OkNegotiatedContentResult<MWQMAnalysisReportParameter>;
                    Assert.Null(mwqmAnalysisReportParameterRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
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

                    MWQMAnalysisReportParameter mwqmAnalysisReportParameterLast = new MWQMAnalysisReportParameter();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MWQMAnalysisReportParameterService mwqmAnalysisReportParameterService = new MWQMAnalysisReportParameterService(query, db, ContactID);
                        mwqmAnalysisReportParameterLast = (from c in db.MWQMAnalysisReportParameters select c).FirstOrDefault();
                    }

                    // ok with MWQMAnalysisReportParameter info
                    IActionResult jsonRet = mwqmAnalysisReportParameterController.GetMWQMAnalysisReportParameterWithID(mwqmAnalysisReportParameterLast.MWQMAnalysisReportParameterID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<MWQMAnalysisReportParameter> Ret = jsonRet as OkNegotiatedContentResult<MWQMAnalysisReportParameter>;
                    MWQMAnalysisReportParameter mwqmAnalysisReportParameterRet = Ret.Content;
                    Assert.Equal(mwqmAnalysisReportParameterLast.MWQMAnalysisReportParameterID, mwqmAnalysisReportParameterRet.MWQMAnalysisReportParameterID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return newly added MWQMAnalysisReportParameter
                    mwqmAnalysisReportParameterRet.MWQMAnalysisReportParameterID = 0;
                    mwqmAnalysisReportParameterController.Request = new System.Net.Http.HttpRequestMessage();
                    mwqmAnalysisReportParameterController.Request.RequestUri = new System.Uri("http://localhost:5000/api/mwqmAnalysisReportParameter");
                    IActionResult jsonRet3 = mwqmAnalysisReportParameterController.Post(mwqmAnalysisReportParameterRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<MWQMAnalysisReportParameter> mwqmAnalysisReportParameterRet3 = jsonRet3 as CreatedNegotiatedContentResult<MWQMAnalysisReportParameter>;
                    Assert.NotNull(mwqmAnalysisReportParameterRet3);
                    MWQMAnalysisReportParameter mwqmAnalysisReportParameter = mwqmAnalysisReportParameterRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = mwqmAnalysisReportParameterController.Delete(mwqmAnalysisReportParameterRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<MWQMAnalysisReportParameter> mwqmAnalysisReportParameterRet2 = jsonRet2 as OkNegotiatedContentResult<MWQMAnalysisReportParameter>;
                    Assert.NotNull(mwqmAnalysisReportParameterRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because MWQMAnalysisReportParameterID of 0 does not exist
                    mwqmAnalysisReportParameterRet.MWQMAnalysisReportParameterID = 0;
                    IActionResult jsonRet4 = mwqmAnalysisReportParameterController.Delete(mwqmAnalysisReportParameterRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<MWQMAnalysisReportParameter> mwqmAnalysisReportParameterRet4 = jsonRet4 as OkNegotiatedContentResult<MWQMAnalysisReportParameter>;
                    Assert.Null(mwqmAnalysisReportParameterRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
