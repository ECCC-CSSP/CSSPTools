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
    public partial class MikeSourceControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MikeSourceControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void MikeSource_Controller_GetMikeSourceList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MikeSourceController mikeSourceController = new MikeSourceController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mikeSourceController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mikeSourceController.DatabaseType);

                    MikeSource mikeSourceFirst = new MikeSource();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        MikeSourceService mikeSourceService = new MikeSourceService(query, db, ContactID);
                        mikeSourceFirst = (from c in db.MikeSources select c).FirstOrDefault();
                        count = (from c in db.MikeSources select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with MikeSource info
                    IActionResult jsonRet = mikeSourceController.GetMikeSourceList();
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<List<MikeSource>> ret = jsonRet as OkNegotiatedContentResult<List<MikeSource>>;
                    Assert.Equal(mikeSourceFirst.MikeSourceID, ret.Content[0].MikeSourceID);
                    Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<MikeSource> mikeSourceList = new List<MikeSource>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        MikeSourceService mikeSourceService = new MikeSourceService(query, db, ContactID);
                        mikeSourceList = (from c in db.MikeSources select c).OrderBy(c => c.MikeSourceID).Skip(0).Take(2).ToList();
                        count = (from c in db.MikeSources select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with MikeSource info
                        jsonRet = mikeSourceController.GetMikeSourceList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.NotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<MikeSource>>;
                        Assert.Equal(mikeSourceList[0].MikeSourceID, ret.Content[0].MikeSourceID);
                        Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with MikeSource info
                           IActionResult jsonRet2 = mikeSourceController.GetMikeSourceList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkNegotiatedContentResult<List<MikeSource>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<MikeSource>>;
                           Assert.Equal(mikeSourceList[1].MikeSourceID, ret2.Content[0].MikeSourceID);
                           Assert.Equal((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void MikeSource_Controller_GetMikeSourceWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MikeSourceController mikeSourceController = new MikeSourceController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mikeSourceController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mikeSourceController.DatabaseType);

                    MikeSource mikeSourceFirst = new MikeSource();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        MikeSourceService mikeSourceService = new MikeSourceService(new Query(), db, ContactID);
                        mikeSourceFirst = (from c in db.MikeSources select c).FirstOrDefault();
                    }

                    // ok with MikeSource info
                    IActionResult jsonRet = mikeSourceController.GetMikeSourceWithID(mikeSourceFirst.MikeSourceID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<MikeSource> Ret = jsonRet as OkNegotiatedContentResult<MikeSource>;
                    MikeSource mikeSourceRet = Ret.Content;
                    Assert.Equal(mikeSourceFirst.MikeSourceID, mikeSourceRet.MikeSourceID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = mikeSourceController.GetMikeSourceWithID(0);
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<MikeSource> mikeSourceRet2 = jsonRet2 as OkNegotiatedContentResult<MikeSource>;
                    Assert.Null(mikeSourceRet2);

                    NotFoundObjectResult notFoundRequest = jsonRet2 as NotFoundObjectResult;
                    Assert.NotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void MikeSource_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MikeSourceController mikeSourceController = new MikeSourceController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mikeSourceController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mikeSourceController.DatabaseType);

                    MikeSource mikeSourceLast = new MikeSource();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MikeSourceService mikeSourceService = new MikeSourceService(query, db, ContactID);
                        mikeSourceLast = (from c in db.MikeSources select c).FirstOrDefault();
                    }

                    // ok with MikeSource info
                    IActionResult jsonRet = mikeSourceController.GetMikeSourceWithID(mikeSourceLast.MikeSourceID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<MikeSource> Ret = jsonRet as OkNegotiatedContentResult<MikeSource>;
                    MikeSource mikeSourceRet = Ret.Content;
                    Assert.Equal(mikeSourceLast.MikeSourceID, mikeSourceRet.MikeSourceID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because MikeSourceID exist
                    IActionResult jsonRet2 = mikeSourceController.Post(mikeSourceRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<MikeSource> mikeSourceRet2 = jsonRet2 as OkNegotiatedContentResult<MikeSource>;
                    Assert.Null(mikeSourceRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added MikeSource
                    mikeSourceRet.MikeSourceID = 0;
                    IActionResult jsonRet3 = mikeSourceController.Post(mikeSourceRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<MikeSource> mikeSourceRet3 = jsonRet3 as CreatedNegotiatedContentResult<MikeSource>;
                    Assert.NotNull(mikeSourceRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = mikeSourceController.Delete(mikeSourceRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<MikeSource> mikeSourceRet4 = jsonRet4 as OkNegotiatedContentResult<MikeSource>;
                    Assert.NotNull(mikeSourceRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [Fact]
        public void MikeSource_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MikeSourceController mikeSourceController = new MikeSourceController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mikeSourceController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mikeSourceController.DatabaseType);

                    MikeSource mikeSourceLast = new MikeSource();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        MikeSourceService mikeSourceService = new MikeSourceService(query, db, ContactID);
                        mikeSourceLast = (from c in db.MikeSources select c).FirstOrDefault();
                    }

                    // ok with MikeSource info
                    IActionResult jsonRet = mikeSourceController.GetMikeSourceWithID(mikeSourceLast.MikeSourceID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<MikeSource> Ret = jsonRet as OkNegotiatedContentResult<MikeSource>;
                    MikeSource mikeSourceRet = Ret.Content;
                    Assert.Equal(mikeSourceLast.MikeSourceID, mikeSourceRet.MikeSourceID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = mikeSourceController.Put(mikeSourceRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<MikeSource> mikeSourceRet2 = jsonRet2 as OkNegotiatedContentResult<MikeSource>;
                    Assert.NotNull(mikeSourceRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because MikeSourceID of 0 does not exist
                    mikeSourceRet.MikeSourceID = 0;
                    IActionResult jsonRet3 = mikeSourceController.Put(mikeSourceRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    OkNegotiatedContentResult<MikeSource> mikeSourceRet3 = jsonRet3 as OkNegotiatedContentResult<MikeSource>;
                    Assert.Null(mikeSourceRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void MikeSource_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MikeSourceController mikeSourceController = new MikeSourceController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mikeSourceController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mikeSourceController.DatabaseType);

                    MikeSource mikeSourceLast = new MikeSource();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MikeSourceService mikeSourceService = new MikeSourceService(query, db, ContactID);
                        mikeSourceLast = (from c in db.MikeSources select c).FirstOrDefault();
                    }

                    // ok with MikeSource info
                    IActionResult jsonRet = mikeSourceController.GetMikeSourceWithID(mikeSourceLast.MikeSourceID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<MikeSource> Ret = jsonRet as OkNegotiatedContentResult<MikeSource>;
                    MikeSource mikeSourceRet = Ret.Content;
                    Assert.Equal(mikeSourceLast.MikeSourceID, mikeSourceRet.MikeSourceID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return newly added MikeSource
                    mikeSourceRet.MikeSourceID = 0;
                    IActionResult jsonRet3 = mikeSourceController.Post(mikeSourceRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<MikeSource> mikeSourceRet3 = jsonRet3 as CreatedNegotiatedContentResult<MikeSource>;
                    Assert.NotNull(mikeSourceRet3);
                    MikeSource mikeSource = mikeSourceRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = mikeSourceController.Delete(mikeSourceRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<MikeSource> mikeSourceRet2 = jsonRet2 as OkNegotiatedContentResult<MikeSource>;
                    Assert.NotNull(mikeSourceRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because MikeSourceID of 0 does not exist
                    mikeSourceRet.MikeSourceID = 0;
                    IActionResult jsonRet4 = mikeSourceController.Delete(mikeSourceRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<MikeSource> mikeSourceRet4 = jsonRet4 as OkNegotiatedContentResult<MikeSource>;
                    Assert.Null(mikeSourceRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
