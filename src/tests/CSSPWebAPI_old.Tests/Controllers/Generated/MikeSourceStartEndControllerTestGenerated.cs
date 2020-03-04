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
    public partial class MikeSourceStartEndControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MikeSourceStartEndControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void MikeSourceStartEnd_Controller_GetMikeSourceStartEndList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MikeSourceStartEndController mikeSourceStartEndController = new MikeSourceStartEndController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mikeSourceStartEndController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mikeSourceStartEndController.DatabaseType);

                    MikeSourceStartEnd mikeSourceStartEndFirst = new MikeSourceStartEnd();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        MikeSourceStartEndService mikeSourceStartEndService = new MikeSourceStartEndService(query, db, ContactID);
                        mikeSourceStartEndFirst = (from c in db.MikeSourceStartEnds select c).FirstOrDefault();
                        count = (from c in db.MikeSourceStartEnds select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with MikeSourceStartEnd info
                    IActionResult jsonRet = mikeSourceStartEndController.GetMikeSourceStartEndList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(mikeSourceStartEndFirst.MikeSourceStartEndID, ((List<MikeSourceStartEnd>)ret.Value)[0].MikeSourceStartEndID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<MikeSourceStartEnd>)ret.Value).Count);

                    List<MikeSourceStartEnd> mikeSourceStartEndList = new List<MikeSourceStartEnd>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        MikeSourceStartEndService mikeSourceStartEndService = new MikeSourceStartEndService(query, db, ContactID);
                        mikeSourceStartEndList = (from c in db.MikeSourceStartEnds select c).OrderBy(c => c.MikeSourceStartEndID).Skip(0).Take(2).ToList();
                        count = (from c in db.MikeSourceStartEnds select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with MikeSourceStartEnd info
                        jsonRet = mikeSourceStartEndController.GetMikeSourceStartEndList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(mikeSourceStartEndList[0].MikeSourceStartEndID, ((List<MikeSourceStartEnd>)ret.Value)[0].MikeSourceStartEndID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<MikeSourceStartEnd>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with MikeSourceStartEnd info
                           IActionResult jsonRet2 = mikeSourceStartEndController.GetMikeSourceStartEndList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(mikeSourceStartEndList[1].MikeSourceStartEndID, ((List<MikeSourceStartEnd>)ret2.Value)[0].MikeSourceStartEndID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<MikeSourceStartEnd>)ret2.Value).Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void MikeSourceStartEnd_Controller_GetMikeSourceStartEndWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MikeSourceStartEndController mikeSourceStartEndController = new MikeSourceStartEndController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mikeSourceStartEndController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mikeSourceStartEndController.DatabaseType);

                    MikeSourceStartEnd mikeSourceStartEndFirst = new MikeSourceStartEnd();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        MikeSourceStartEndService mikeSourceStartEndService = new MikeSourceStartEndService(new Query(), db, ContactID);
                        mikeSourceStartEndFirst = (from c in db.MikeSourceStartEnds select c).FirstOrDefault();
                    }

                    // ok with MikeSourceStartEnd info
                    IActionResult jsonRet = mikeSourceStartEndController.GetMikeSourceStartEndWithID(mikeSourceStartEndFirst.MikeSourceStartEndID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(mikeSourceStartEndFirst.MikeSourceStartEndID, ((MikeSourceStartEnd)ret.Value).MikeSourceStartEndID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = mikeSourceStartEndController.GetMikeSourceStartEndWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult mikeSourceStartEndRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(mikeSourceStartEndRet2);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void MikeSourceStartEnd_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MikeSourceStartEndController mikeSourceStartEndController = new MikeSourceStartEndController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mikeSourceStartEndController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mikeSourceStartEndController.DatabaseType);

                    MikeSourceStartEnd mikeSourceStartEndFirst = new MikeSourceStartEnd();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MikeSourceStartEndService mikeSourceStartEndService = new MikeSourceStartEndService(query, db, ContactID);
                        mikeSourceStartEndFirst = (from c in db.MikeSourceStartEnds select c).FirstOrDefault();
                    }

                    // ok with MikeSourceStartEnd info
                    IActionResult jsonRet = mikeSourceStartEndController.GetMikeSourceStartEndWithID(mikeSourceStartEndFirst.MikeSourceStartEndID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    MikeSourceStartEnd mikeSourceStartEndRet = (MikeSourceStartEnd)ret.Value;
                    Assert.Equal(mikeSourceStartEndFirst.MikeSourceStartEndID, mikeSourceStartEndRet.MikeSourceStartEndID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because MikeSourceStartEndID exist
                    IActionResult jsonRet2 = mikeSourceStartEndController.Post(mikeSourceStartEndRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added MikeSourceStartEnd
                    mikeSourceStartEndRet.MikeSourceStartEndID = 0;
                    IActionResult jsonRet3 = mikeSourceStartEndController.Post(mikeSourceStartEndRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = mikeSourceStartEndController.Delete(mikeSourceStartEndRet, LanguageRequest.ToString());
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
        public void MikeSourceStartEnd_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MikeSourceStartEndController mikeSourceStartEndController = new MikeSourceStartEndController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mikeSourceStartEndController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mikeSourceStartEndController.DatabaseType);

                    MikeSourceStartEnd mikeSourceStartEndFirst = new MikeSourceStartEnd();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        MikeSourceStartEndService mikeSourceStartEndService = new MikeSourceStartEndService(query, db, ContactID);
                        mikeSourceStartEndFirst = (from c in db.MikeSourceStartEnds select c).FirstOrDefault();
                    }

                    // ok with MikeSourceStartEnd info
                    IActionResult jsonRet = mikeSourceStartEndController.GetMikeSourceStartEndWithID(mikeSourceStartEndFirst.MikeSourceStartEndID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    MikeSourceStartEnd mikeSourceStartEndRet = (MikeSourceStartEnd)Ret.Value;
                    Assert.Equal(mikeSourceStartEndFirst.MikeSourceStartEndID, mikeSourceStartEndRet.MikeSourceStartEndID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = mikeSourceStartEndController.Put(mikeSourceStartEndRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult mikeSourceStartEndRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(mikeSourceStartEndRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because MikeSourceStartEndID of 0 does not exist
                    mikeSourceStartEndRet.MikeSourceStartEndID = 0;
                    IActionResult jsonRet3 = mikeSourceStartEndController.Put(mikeSourceStartEndRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult mikeSourceStartEndRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(mikeSourceStartEndRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void MikeSourceStartEnd_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    MikeSourceStartEndController mikeSourceStartEndController = new MikeSourceStartEndController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(mikeSourceStartEndController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, mikeSourceStartEndController.DatabaseType);

                    MikeSourceStartEnd mikeSourceStartEndFirst = new MikeSourceStartEnd();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MikeSourceStartEndService mikeSourceStartEndService = new MikeSourceStartEndService(query, db, ContactID);
                        mikeSourceStartEndFirst = (from c in db.MikeSourceStartEnds select c).FirstOrDefault();
                    }

                    // ok with MikeSourceStartEnd info
                    IActionResult jsonRet = mikeSourceStartEndController.GetMikeSourceStartEndWithID(mikeSourceStartEndFirst.MikeSourceStartEndID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    MikeSourceStartEnd mikeSourceStartEndRet = (MikeSourceStartEnd)Ret.Value;
                    Assert.Equal(mikeSourceStartEndFirst.MikeSourceStartEndID, mikeSourceStartEndRet.MikeSourceStartEndID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added MikeSourceStartEnd
                    mikeSourceStartEndRet.MikeSourceStartEndID = 0;
                    IActionResult jsonRet3 = mikeSourceStartEndController.Post(mikeSourceStartEndRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    MikeSourceStartEnd mikeSourceStartEnd = (MikeSourceStartEnd)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = mikeSourceStartEndController.Delete(mikeSourceStartEndRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because MikeSourceStartEndID of 0 does not exist
                    mikeSourceStartEndRet.MikeSourceStartEndID = 0;
                    IActionResult jsonRet4 = mikeSourceStartEndController.Delete(mikeSourceStartEndRet, LanguageRequest.ToString());
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
