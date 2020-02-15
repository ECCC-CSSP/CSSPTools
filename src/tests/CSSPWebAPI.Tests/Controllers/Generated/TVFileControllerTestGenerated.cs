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
    public partial class TVFileControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TVFileControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void TVFile_Controller_GetTVFileList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVFileController tvFileController = new TVFileController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tvFileController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tvFileController.DatabaseType);

                    TVFile tvFileFirst = new TVFile();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        TVFileService tvFileService = new TVFileService(query, db, ContactID);
                        tvFileFirst = (from c in db.TVFiles select c).FirstOrDefault();
                        count = (from c in db.TVFiles select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with TVFile info
                    IActionResult jsonRet = tvFileController.GetTVFileList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(tvFileFirst.TVFileID, ((List<TVFile>)ret.Value)[0].TVFileID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<TVFile>)ret.Value).Count);

                    List<TVFile> tvFileList = new List<TVFile>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        TVFileService tvFileService = new TVFileService(query, db, ContactID);
                        tvFileList = (from c in db.TVFiles select c).OrderBy(c => c.TVFileID).Skip(0).Take(2).ToList();
                        count = (from c in db.TVFiles select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with TVFile info
                        jsonRet = tvFileController.GetTVFileList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(tvFileList[0].TVFileID, ((List<TVFile>)ret.Value)[0].TVFileID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<TVFile>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with TVFile info
                           IActionResult jsonRet2 = tvFileController.GetTVFileList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(tvFileList[1].TVFileID, ((List<TVFile>)ret2.Value)[0].TVFileID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<TVFile>)ret2.Value).Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void TVFile_Controller_GetTVFileWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVFileController tvFileController = new TVFileController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tvFileController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tvFileController.DatabaseType);

                    TVFile tvFileFirst = new TVFile();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        TVFileService tvFileService = new TVFileService(new Query(), db, ContactID);
                        tvFileFirst = (from c in db.TVFiles select c).FirstOrDefault();
                    }

                    // ok with TVFile info
                    IActionResult jsonRet = tvFileController.GetTVFileWithID(tvFileFirst.TVFileID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(tvFileFirst.TVFileID, ((TVFile)ret.Value).TVFileID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = tvFileController.GetTVFileWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult tvFileRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(tvFileRet2);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void TVFile_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVFileController tvFileController = new TVFileController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tvFileController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tvFileController.DatabaseType);

                    TVFile tvFileFirst = new TVFile();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        TVFileService tvFileService = new TVFileService(query, db, ContactID);
                        tvFileFirst = (from c in db.TVFiles select c).FirstOrDefault();
                    }

                    // ok with TVFile info
                    IActionResult jsonRet = tvFileController.GetTVFileWithID(tvFileFirst.TVFileID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    TVFile tvFileRet = (TVFile)ret.Value;
                    Assert.Equal(tvFileFirst.TVFileID, tvFileRet.TVFileID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because TVFileID exist
                    IActionResult jsonRet2 = tvFileController.Post(tvFileRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added TVFile
                    tvFileRet.TVFileID = 0;
                    IActionResult jsonRet3 = tvFileController.Post(tvFileRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = tvFileController.Delete(tvFileRet, LanguageRequest.ToString());
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
        public void TVFile_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVFileController tvFileController = new TVFileController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tvFileController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tvFileController.DatabaseType);

                    TVFile tvFileFirst = new TVFile();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        TVFileService tvFileService = new TVFileService(query, db, ContactID);
                        tvFileFirst = (from c in db.TVFiles select c).FirstOrDefault();
                    }

                    // ok with TVFile info
                    IActionResult jsonRet = tvFileController.GetTVFileWithID(tvFileFirst.TVFileID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    TVFile tvFileRet = (TVFile)Ret.Value;
                    Assert.Equal(tvFileFirst.TVFileID, tvFileRet.TVFileID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = tvFileController.Put(tvFileRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult tvFileRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(tvFileRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because TVFileID of 0 does not exist
                    tvFileRet.TVFileID = 0;
                    IActionResult jsonRet3 = tvFileController.Put(tvFileRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult tvFileRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(tvFileRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void TVFile_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVFileController tvFileController = new TVFileController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(tvFileController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, tvFileController.DatabaseType);

                    TVFile tvFileFirst = new TVFile();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        TVFileService tvFileService = new TVFileService(query, db, ContactID);
                        tvFileFirst = (from c in db.TVFiles select c).FirstOrDefault();
                    }

                    // ok with TVFile info
                    IActionResult jsonRet = tvFileController.GetTVFileWithID(tvFileFirst.TVFileID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    TVFile tvFileRet = (TVFile)Ret.Value;
                    Assert.Equal(tvFileFirst.TVFileID, tvFileRet.TVFileID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added TVFile
                    tvFileRet.TVFileID = 0;
                    IActionResult jsonRet3 = tvFileController.Post(tvFileRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    TVFile tvFile = (TVFile)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = tvFileController.Delete(tvFileRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because TVFileID of 0 does not exist
                    tvFileRet.TVFileID = 0;
                    IActionResult jsonRet4 = tvFileController.Delete(tvFileRet, LanguageRequest.ToString());
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
