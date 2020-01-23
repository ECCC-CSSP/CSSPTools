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
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<List<MWQMSubsector>> ret = jsonRet as OkNegotiatedContentResult<List<MWQMSubsector>>;
                    Assert.Equal(mwqmSubsectorFirst.MWQMSubsectorID, ret.Content[0].MWQMSubsectorID);
                    Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

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
                        Assert.NotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<MWQMSubsector>>;
                        Assert.Equal(mwqmSubsectorList[0].MWQMSubsectorID, ret.Content[0].MWQMSubsectorID);
                        Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with MWQMSubsector info
                           IActionResult jsonRet2 = mwqmSubsectorController.GetMWQMSubsectorList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkNegotiatedContentResult<List<MWQMSubsector>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<MWQMSubsector>>;
                           Assert.Equal(mwqmSubsectorList[1].MWQMSubsectorID, ret2.Content[0].MWQMSubsectorID);
                           Assert.Equal((count > query.Take ? query.Take : count), ret2.Content.Count);
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
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<MWQMSubsector> Ret = jsonRet as OkNegotiatedContentResult<MWQMSubsector>;
                    MWQMSubsector mwqmSubsectorRet = Ret.Content;
                    Assert.Equal(mwqmSubsectorFirst.MWQMSubsectorID, mwqmSubsectorRet.MWQMSubsectorID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = mwqmSubsectorController.GetMWQMSubsectorWithID(0);
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<MWQMSubsector> mwqmSubsectorRet2 = jsonRet2 as OkNegotiatedContentResult<MWQMSubsector>;
                    Assert.Null(mwqmSubsectorRet2);

                    NotFoundObjectResult notFoundRequest = jsonRet2 as NotFoundObjectResult;
                    Assert.NotNull(notFoundRequest);
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

                    MWQMSubsector mwqmSubsectorLast = new MWQMSubsector();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MWQMSubsectorService mwqmSubsectorService = new MWQMSubsectorService(query, db, ContactID);
                        mwqmSubsectorLast = (from c in db.MWQMSubsectors select c).FirstOrDefault();
                    }

                    // ok with MWQMSubsector info
                    IActionResult jsonRet = mwqmSubsectorController.GetMWQMSubsectorWithID(mwqmSubsectorLast.MWQMSubsectorID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<MWQMSubsector> Ret = jsonRet as OkNegotiatedContentResult<MWQMSubsector>;
                    MWQMSubsector mwqmSubsectorRet = Ret.Content;
                    Assert.Equal(mwqmSubsectorLast.MWQMSubsectorID, mwqmSubsectorRet.MWQMSubsectorID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because MWQMSubsectorID exist
                    IActionResult jsonRet2 = mwqmSubsectorController.Post(mwqmSubsectorRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<MWQMSubsector> mwqmSubsectorRet2 = jsonRet2 as OkNegotiatedContentResult<MWQMSubsector>;
                    Assert.Null(mwqmSubsectorRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added MWQMSubsector
                    mwqmSubsectorRet.MWQMSubsectorID = 0;
                    IActionResult jsonRet3 = mwqmSubsectorController.Post(mwqmSubsectorRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<MWQMSubsector> mwqmSubsectorRet3 = jsonRet3 as CreatedNegotiatedContentResult<MWQMSubsector>;
                    Assert.NotNull(mwqmSubsectorRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = mwqmSubsectorController.Delete(mwqmSubsectorRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<MWQMSubsector> mwqmSubsectorRet4 = jsonRet4 as OkNegotiatedContentResult<MWQMSubsector>;
                    Assert.NotNull(mwqmSubsectorRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
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

                    MWQMSubsector mwqmSubsectorLast = new MWQMSubsector();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        MWQMSubsectorService mwqmSubsectorService = new MWQMSubsectorService(query, db, ContactID);
                        mwqmSubsectorLast = (from c in db.MWQMSubsectors select c).FirstOrDefault();
                    }

                    // ok with MWQMSubsector info
                    IActionResult jsonRet = mwqmSubsectorController.GetMWQMSubsectorWithID(mwqmSubsectorLast.MWQMSubsectorID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<MWQMSubsector> Ret = jsonRet as OkNegotiatedContentResult<MWQMSubsector>;
                    MWQMSubsector mwqmSubsectorRet = Ret.Content;
                    Assert.Equal(mwqmSubsectorLast.MWQMSubsectorID, mwqmSubsectorRet.MWQMSubsectorID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = mwqmSubsectorController.Put(mwqmSubsectorRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<MWQMSubsector> mwqmSubsectorRet2 = jsonRet2 as OkNegotiatedContentResult<MWQMSubsector>;
                    Assert.NotNull(mwqmSubsectorRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because MWQMSubsectorID of 0 does not exist
                    mwqmSubsectorRet.MWQMSubsectorID = 0;
                    IActionResult jsonRet3 = mwqmSubsectorController.Put(mwqmSubsectorRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    OkNegotiatedContentResult<MWQMSubsector> mwqmSubsectorRet3 = jsonRet3 as OkNegotiatedContentResult<MWQMSubsector>;
                    Assert.Null(mwqmSubsectorRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
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

                    MWQMSubsector mwqmSubsectorLast = new MWQMSubsector();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MWQMSubsectorService mwqmSubsectorService = new MWQMSubsectorService(query, db, ContactID);
                        mwqmSubsectorLast = (from c in db.MWQMSubsectors select c).FirstOrDefault();
                    }

                    // ok with MWQMSubsector info
                    IActionResult jsonRet = mwqmSubsectorController.GetMWQMSubsectorWithID(mwqmSubsectorLast.MWQMSubsectorID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<MWQMSubsector> Ret = jsonRet as OkNegotiatedContentResult<MWQMSubsector>;
                    MWQMSubsector mwqmSubsectorRet = Ret.Content;
                    Assert.Equal(mwqmSubsectorLast.MWQMSubsectorID, mwqmSubsectorRet.MWQMSubsectorID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return newly added MWQMSubsector
                    mwqmSubsectorRet.MWQMSubsectorID = 0;
                    IActionResult jsonRet3 = mwqmSubsectorController.Post(mwqmSubsectorRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<MWQMSubsector> mwqmSubsectorRet3 = jsonRet3 as CreatedNegotiatedContentResult<MWQMSubsector>;
                    Assert.NotNull(mwqmSubsectorRet3);
                    MWQMSubsector mwqmSubsector = mwqmSubsectorRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = mwqmSubsectorController.Delete(mwqmSubsectorRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<MWQMSubsector> mwqmSubsectorRet2 = jsonRet2 as OkNegotiatedContentResult<MWQMSubsector>;
                    Assert.NotNull(mwqmSubsectorRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because MWQMSubsectorID of 0 does not exist
                    mwqmSubsectorRet.MWQMSubsectorID = 0;
                    IActionResult jsonRet4 = mwqmSubsectorController.Delete(mwqmSubsectorRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<MWQMSubsector> mwqmSubsectorRet4 = jsonRet4 as OkNegotiatedContentResult<MWQMSubsector>;
                    Assert.Null(mwqmSubsectorRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
