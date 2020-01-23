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
    public partial class TelControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TelControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void Tel_Controller_GetTelList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TelController telController = new TelController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(telController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, telController.DatabaseType);

                    Tel telFirst = new Tel();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        TelService telService = new TelService(query, db, ContactID);
                        telFirst = (from c in db.Tels select c).FirstOrDefault();
                        count = (from c in db.Tels select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with Tel info
                    IActionResult jsonRet = telController.GetTelList();
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<List<Tel>> ret = jsonRet as OkNegotiatedContentResult<List<Tel>>;
                    Assert.Equal(telFirst.TelID, ret.Content[0].TelID);
                    Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<Tel> telList = new List<Tel>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        TelService telService = new TelService(query, db, ContactID);
                        telList = (from c in db.Tels select c).OrderBy(c => c.TelID).Skip(0).Take(2).ToList();
                        count = (from c in db.Tels select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with Tel info
                        jsonRet = telController.GetTelList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.NotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<Tel>>;
                        Assert.Equal(telList[0].TelID, ret.Content[0].TelID);
                        Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with Tel info
                           IActionResult jsonRet2 = telController.GetTelList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkNegotiatedContentResult<List<Tel>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<Tel>>;
                           Assert.Equal(telList[1].TelID, ret2.Content[0].TelID);
                           Assert.Equal((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void Tel_Controller_GetTelWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TelController telController = new TelController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(telController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, telController.DatabaseType);

                    Tel telFirst = new Tel();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        TelService telService = new TelService(new Query(), db, ContactID);
                        telFirst = (from c in db.Tels select c).FirstOrDefault();
                    }

                    // ok with Tel info
                    IActionResult jsonRet = telController.GetTelWithID(telFirst.TelID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<Tel> Ret = jsonRet as OkNegotiatedContentResult<Tel>;
                    Tel telRet = Ret.Content;
                    Assert.Equal(telFirst.TelID, telRet.TelID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = telController.GetTelWithID(0);
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<Tel> telRet2 = jsonRet2 as OkNegotiatedContentResult<Tel>;
                    Assert.Null(telRet2);

                    NotFoundObjectResult notFoundRequest = jsonRet2 as NotFoundObjectResult;
                    Assert.NotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void Tel_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TelController telController = new TelController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(telController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, telController.DatabaseType);

                    Tel telLast = new Tel();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        TelService telService = new TelService(query, db, ContactID);
                        telLast = (from c in db.Tels select c).FirstOrDefault();
                    }

                    // ok with Tel info
                    IActionResult jsonRet = telController.GetTelWithID(telLast.TelID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<Tel> Ret = jsonRet as OkNegotiatedContentResult<Tel>;
                    Tel telRet = Ret.Content;
                    Assert.Equal(telLast.TelID, telRet.TelID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because TelID exist
                    IActionResult jsonRet2 = telController.Post(telRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<Tel> telRet2 = jsonRet2 as OkNegotiatedContentResult<Tel>;
                    Assert.Null(telRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added Tel
                    telRet.TelID = 0;
                    IActionResult jsonRet3 = telController.Post(telRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<Tel> telRet3 = jsonRet3 as CreatedNegotiatedContentResult<Tel>;
                    Assert.NotNull(telRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = telController.Delete(telRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<Tel> telRet4 = jsonRet4 as OkNegotiatedContentResult<Tel>;
                    Assert.NotNull(telRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [Fact]
        public void Tel_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TelController telController = new TelController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(telController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, telController.DatabaseType);

                    Tel telLast = new Tel();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        TelService telService = new TelService(query, db, ContactID);
                        telLast = (from c in db.Tels select c).FirstOrDefault();
                    }

                    // ok with Tel info
                    IActionResult jsonRet = telController.GetTelWithID(telLast.TelID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<Tel> Ret = jsonRet as OkNegotiatedContentResult<Tel>;
                    Tel telRet = Ret.Content;
                    Assert.Equal(telLast.TelID, telRet.TelID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = telController.Put(telRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<Tel> telRet2 = jsonRet2 as OkNegotiatedContentResult<Tel>;
                    Assert.NotNull(telRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because TelID of 0 does not exist
                    telRet.TelID = 0;
                    IActionResult jsonRet3 = telController.Put(telRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    OkNegotiatedContentResult<Tel> telRet3 = jsonRet3 as OkNegotiatedContentResult<Tel>;
                    Assert.Null(telRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void Tel_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TelController telController = new TelController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(telController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, telController.DatabaseType);

                    Tel telLast = new Tel();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        TelService telService = new TelService(query, db, ContactID);
                        telLast = (from c in db.Tels select c).FirstOrDefault();
                    }

                    // ok with Tel info
                    IActionResult jsonRet = telController.GetTelWithID(telLast.TelID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<Tel> Ret = jsonRet as OkNegotiatedContentResult<Tel>;
                    Tel telRet = Ret.Content;
                    Assert.Equal(telLast.TelID, telRet.TelID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return newly added Tel
                    telRet.TelID = 0;
                    IActionResult jsonRet3 = telController.Post(telRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<Tel> telRet3 = jsonRet3 as CreatedNegotiatedContentResult<Tel>;
                    Assert.NotNull(telRet3);
                    Tel tel = telRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = telController.Delete(telRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<Tel> telRet2 = jsonRet2 as OkNegotiatedContentResult<Tel>;
                    Assert.NotNull(telRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because TelID of 0 does not exist
                    telRet.TelID = 0;
                    IActionResult jsonRet4 = telController.Delete(telRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<Tel> telRet4 = jsonRet4 as OkNegotiatedContentResult<Tel>;
                    Assert.Null(telRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
