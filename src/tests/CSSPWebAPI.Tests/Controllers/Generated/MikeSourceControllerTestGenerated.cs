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
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(mikeSourceFirst.MikeSourceID, ((List<MikeSource>)ret.Value)[0].MikeSourceID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<MikeSource>)ret.Value).Count);

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
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(mikeSourceList[0].MikeSourceID, ((List<MikeSource>)ret.Value)[0].MikeSourceID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<MikeSource>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with MikeSource info
                           IActionResult jsonRet2 = mikeSourceController.GetMikeSourceList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(mikeSourceList[1].MikeSourceID, ((List<MikeSource>)ret2.Value)[0].MikeSourceID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<MikeSource>)ret2.Value).Count);
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
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(mikeSourceFirst.MikeSourceID, ((MikeSource)ret.Value).MikeSourceID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = mikeSourceController.GetMikeSourceWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult mikeSourceRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(mikeSourceRet2);
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
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    MikeSource mikeSourceRet = (MikeSource)ret.Value;
                    Assert.Equal(mikeSourceLast.MikeSourceID, mikeSourceRet.MikeSourceID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because MikeSourceID exist
                    IActionResult jsonRet2 = mikeSourceController.Post(mikeSourceRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added MikeSource
                    mikeSourceRet.MikeSourceID = 0;
                    IActionResult jsonRet3 = mikeSourceController.Post(mikeSourceRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = mikeSourceController.Delete(mikeSourceRet, LanguageRequest.ToString());
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
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    MikeSource mikeSourceRet = (MikeSource)Ret.Value;
                    Assert.Equal(mikeSourceLast.MikeSourceID, mikeSourceRet.MikeSourceID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = mikeSourceController.Put(mikeSourceRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult mikeSourceRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(mikeSourceRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because MikeSourceID of 0 does not exist
                    mikeSourceRet.MikeSourceID = 0;
                    IActionResult jsonRet3 = mikeSourceController.Put(mikeSourceRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult mikeSourceRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(mikeSourceRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
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
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    MikeSource mikeSourceRet = (MikeSource)Ret.Value;
                    Assert.Equal(mikeSourceLast.MikeSourceID, mikeSourceRet.MikeSourceID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added MikeSource
                    mikeSourceRet.MikeSourceID = 0;
                    IActionResult jsonRet3 = mikeSourceController.Post(mikeSourceRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    MikeSource mikeSource = (MikeSource)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = mikeSourceController.Delete(mikeSourceRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because MikeSourceID of 0 does not exist
                    mikeSourceRet.MikeSourceID = 0;
                    IActionResult jsonRet4 = mikeSourceController.Delete(mikeSourceRet, LanguageRequest.ToString());
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
