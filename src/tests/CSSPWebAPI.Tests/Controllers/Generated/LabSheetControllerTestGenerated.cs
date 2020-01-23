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
    public partial class LabSheetControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public LabSheetControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void LabSheet_Controller_GetLabSheetList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    LabSheetController labSheetController = new LabSheetController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(labSheetController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, labSheetController.DatabaseType);

                    LabSheet labSheetFirst = new LabSheet();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        LabSheetService labSheetService = new LabSheetService(query, db, ContactID);
                        labSheetFirst = (from c in db.LabSheets select c).FirstOrDefault();
                        count = (from c in db.LabSheets select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with LabSheet info
                    IActionResult jsonRet = labSheetController.GetLabSheetList();
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<List<LabSheet>> ret = jsonRet as OkNegotiatedContentResult<List<LabSheet>>;
                    Assert.Equal(labSheetFirst.LabSheetID, ret.Content[0].LabSheetID);
                    Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<LabSheet> labSheetList = new List<LabSheet>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        LabSheetService labSheetService = new LabSheetService(query, db, ContactID);
                        labSheetList = (from c in db.LabSheets select c).OrderBy(c => c.LabSheetID).Skip(0).Take(2).ToList();
                        count = (from c in db.LabSheets select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with LabSheet info
                        jsonRet = labSheetController.GetLabSheetList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.NotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<LabSheet>>;
                        Assert.Equal(labSheetList[0].LabSheetID, ret.Content[0].LabSheetID);
                        Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with LabSheet info
                           IActionResult jsonRet2 = labSheetController.GetLabSheetList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkNegotiatedContentResult<List<LabSheet>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<LabSheet>>;
                           Assert.Equal(labSheetList[1].LabSheetID, ret2.Content[0].LabSheetID);
                           Assert.Equal((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void LabSheet_Controller_GetLabSheetWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    LabSheetController labSheetController = new LabSheetController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(labSheetController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, labSheetController.DatabaseType);

                    LabSheet labSheetFirst = new LabSheet();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        LabSheetService labSheetService = new LabSheetService(new Query(), db, ContactID);
                        labSheetFirst = (from c in db.LabSheets select c).FirstOrDefault();
                    }

                    // ok with LabSheet info
                    IActionResult jsonRet = labSheetController.GetLabSheetWithID(labSheetFirst.LabSheetID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<LabSheet> Ret = jsonRet as OkNegotiatedContentResult<LabSheet>;
                    LabSheet labSheetRet = Ret.Content;
                    Assert.Equal(labSheetFirst.LabSheetID, labSheetRet.LabSheetID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = labSheetController.GetLabSheetWithID(0);
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<LabSheet> labSheetRet2 = jsonRet2 as OkNegotiatedContentResult<LabSheet>;
                    Assert.Null(labSheetRet2);

                    NotFoundObjectResult notFoundRequest = jsonRet2 as NotFoundObjectResult;
                    Assert.NotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void LabSheet_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    LabSheetController labSheetController = new LabSheetController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(labSheetController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, labSheetController.DatabaseType);

                    LabSheet labSheetLast = new LabSheet();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        LabSheetService labSheetService = new LabSheetService(query, db, ContactID);
                        labSheetLast = (from c in db.LabSheets select c).FirstOrDefault();
                    }

                    // ok with LabSheet info
                    IActionResult jsonRet = labSheetController.GetLabSheetWithID(labSheetLast.LabSheetID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<LabSheet> Ret = jsonRet as OkNegotiatedContentResult<LabSheet>;
                    LabSheet labSheetRet = Ret.Content;
                    Assert.Equal(labSheetLast.LabSheetID, labSheetRet.LabSheetID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because LabSheetID exist
                    IActionResult jsonRet2 = labSheetController.Post(labSheetRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<LabSheet> labSheetRet2 = jsonRet2 as OkNegotiatedContentResult<LabSheet>;
                    Assert.Null(labSheetRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added LabSheet
                    labSheetRet.LabSheetID = 0;
                    IActionResult jsonRet3 = labSheetController.Post(labSheetRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<LabSheet> labSheetRet3 = jsonRet3 as CreatedNegotiatedContentResult<LabSheet>;
                    Assert.NotNull(labSheetRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = labSheetController.Delete(labSheetRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<LabSheet> labSheetRet4 = jsonRet4 as OkNegotiatedContentResult<LabSheet>;
                    Assert.NotNull(labSheetRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [Fact]
        public void LabSheet_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    LabSheetController labSheetController = new LabSheetController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(labSheetController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, labSheetController.DatabaseType);

                    LabSheet labSheetLast = new LabSheet();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        LabSheetService labSheetService = new LabSheetService(query, db, ContactID);
                        labSheetLast = (from c in db.LabSheets select c).FirstOrDefault();
                    }

                    // ok with LabSheet info
                    IActionResult jsonRet = labSheetController.GetLabSheetWithID(labSheetLast.LabSheetID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<LabSheet> Ret = jsonRet as OkNegotiatedContentResult<LabSheet>;
                    LabSheet labSheetRet = Ret.Content;
                    Assert.Equal(labSheetLast.LabSheetID, labSheetRet.LabSheetID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = labSheetController.Put(labSheetRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<LabSheet> labSheetRet2 = jsonRet2 as OkNegotiatedContentResult<LabSheet>;
                    Assert.NotNull(labSheetRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because LabSheetID of 0 does not exist
                    labSheetRet.LabSheetID = 0;
                    IActionResult jsonRet3 = labSheetController.Put(labSheetRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    OkNegotiatedContentResult<LabSheet> labSheetRet3 = jsonRet3 as OkNegotiatedContentResult<LabSheet>;
                    Assert.Null(labSheetRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void LabSheet_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    LabSheetController labSheetController = new LabSheetController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(labSheetController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, labSheetController.DatabaseType);

                    LabSheet labSheetLast = new LabSheet();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        LabSheetService labSheetService = new LabSheetService(query, db, ContactID);
                        labSheetLast = (from c in db.LabSheets select c).FirstOrDefault();
                    }

                    // ok with LabSheet info
                    IActionResult jsonRet = labSheetController.GetLabSheetWithID(labSheetLast.LabSheetID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<LabSheet> Ret = jsonRet as OkNegotiatedContentResult<LabSheet>;
                    LabSheet labSheetRet = Ret.Content;
                    Assert.Equal(labSheetLast.LabSheetID, labSheetRet.LabSheetID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.Null(badRequest);

                    // Post to return newly added LabSheet
                    labSheetRet.LabSheetID = 0;
                    IActionResult jsonRet3 = labSheetController.Post(labSheetRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<LabSheet> labSheetRet3 = jsonRet3 as CreatedNegotiatedContentResult<LabSheet>;
                    Assert.NotNull(labSheetRet3);
                    LabSheet labSheet = labSheetRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = labSheetController.Delete(labSheetRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<LabSheet> labSheetRet2 = jsonRet2 as OkNegotiatedContentResult<LabSheet>;
                    Assert.NotNull(labSheetRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because LabSheetID of 0 does not exist
                    labSheetRet.LabSheetID = 0;
                    IActionResult jsonRet4 = labSheetController.Delete(labSheetRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<LabSheet> labSheetRet4 = jsonRet4 as OkNegotiatedContentResult<LabSheet>;
                    Assert.Null(labSheetRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
