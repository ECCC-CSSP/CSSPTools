using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Xunit;
using CSSPWebAPI.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;

namespace CSSPWebAPI.Tests.Controllers
{
    public partial class DrogueRunPositionControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public DrogueRunPositionControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void DrogueRunPosition_Controller_GetDrogueRunPositionList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    DrogueRunPositionController drogueRunPositionController = new DrogueRunPositionController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(drogueRunPositionController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, drogueRunPositionController.DatabaseType);

                    DrogueRunPosition drogueRunPositionFirst = new DrogueRunPosition();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        DrogueRunPositionService drogueRunPositionService = new DrogueRunPositionService(query, db, ContactID);
                        drogueRunPositionFirst = (from c in db.DrogueRunPositions select c).FirstOrDefault();
                        count = (from c in db.DrogueRunPositions select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with DrogueRunPosition info
                    IHttpActionResult jsonRet = drogueRunPositionController.GetDrogueRunPositionList();
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<List<DrogueRunPosition>> ret = jsonRet as OkNegotiatedContentResult<List<DrogueRunPosition>>;
                    Assert.Equal(drogueRunPositionFirst.DrogueRunPositionID, ret.Content[0].DrogueRunPositionID);
                    Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<DrogueRunPosition> drogueRunPositionList = new List<DrogueRunPosition>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        DrogueRunPositionService drogueRunPositionService = new DrogueRunPositionService(query, db, ContactID);
                        drogueRunPositionList = (from c in db.DrogueRunPositions select c).OrderBy(c => c.DrogueRunPositionID).Skip(0).Take(2).ToList();
                        count = (from c in db.DrogueRunPositions select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with DrogueRunPosition info
                        jsonRet = drogueRunPositionController.GetDrogueRunPositionList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.NotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<DrogueRunPosition>>;
                        Assert.Equal(drogueRunPositionList[0].DrogueRunPositionID, ret.Content[0].DrogueRunPositionID);
                        Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with DrogueRunPosition info
                           IHttpActionResult jsonRet2 = drogueRunPositionController.GetDrogueRunPositionList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkNegotiatedContentResult<List<DrogueRunPosition>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<DrogueRunPosition>>;
                           Assert.Equal(drogueRunPositionList[1].DrogueRunPositionID, ret2.Content[0].DrogueRunPositionID);
                           Assert.Equal((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void DrogueRunPosition_Controller_GetDrogueRunPositionWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    DrogueRunPositionController drogueRunPositionController = new DrogueRunPositionController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(drogueRunPositionController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, drogueRunPositionController.DatabaseType);

                    DrogueRunPosition drogueRunPositionFirst = new DrogueRunPosition();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        DrogueRunPositionService drogueRunPositionService = new DrogueRunPositionService(new Query(), db, ContactID);
                        drogueRunPositionFirst = (from c in db.DrogueRunPositions select c).FirstOrDefault();
                    }

                    // ok with DrogueRunPosition info
                    IHttpActionResult jsonRet = drogueRunPositionController.GetDrogueRunPositionWithID(drogueRunPositionFirst.DrogueRunPositionID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<DrogueRunPosition> Ret = jsonRet as OkNegotiatedContentResult<DrogueRunPosition>;
                    DrogueRunPosition drogueRunPositionRet = Ret.Content;
                    Assert.Equal(drogueRunPositionFirst.DrogueRunPositionID, drogueRunPositionRet.DrogueRunPositionID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = drogueRunPositionController.GetDrogueRunPositionWithID(0);
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<DrogueRunPosition> drogueRunPositionRet2 = jsonRet2 as OkNegotiatedContentResult<DrogueRunPosition>;
                    Assert.IsNull(drogueRunPositionRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.NotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void DrogueRunPosition_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    DrogueRunPositionController drogueRunPositionController = new DrogueRunPositionController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(drogueRunPositionController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, drogueRunPositionController.DatabaseType);

                    DrogueRunPosition drogueRunPositionLast = new DrogueRunPosition();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        DrogueRunPositionService drogueRunPositionService = new DrogueRunPositionService(query, db, ContactID);
                        drogueRunPositionLast = (from c in db.DrogueRunPositions select c).FirstOrDefault();
                    }

                    // ok with DrogueRunPosition info
                    IHttpActionResult jsonRet = drogueRunPositionController.GetDrogueRunPositionWithID(drogueRunPositionLast.DrogueRunPositionID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<DrogueRunPosition> Ret = jsonRet as OkNegotiatedContentResult<DrogueRunPosition>;
                    DrogueRunPosition drogueRunPositionRet = Ret.Content;
                    Assert.Equal(drogueRunPositionLast.DrogueRunPositionID, drogueRunPositionRet.DrogueRunPositionID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because DrogueRunPositionID exist
                    IHttpActionResult jsonRet2 = drogueRunPositionController.Post(drogueRunPositionRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<DrogueRunPosition> drogueRunPositionRet2 = jsonRet2 as OkNegotiatedContentResult<DrogueRunPosition>;
                    Assert.IsNull(drogueRunPositionRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added DrogueRunPosition
                    drogueRunPositionRet.DrogueRunPositionID = 0;
                    drogueRunPositionController.Request = new System.Net.Http.HttpRequestMessage();
                    drogueRunPositionController.Request.RequestUri = new System.Uri("http://localhost:5000/api/drogueRunPosition");
                    IHttpActionResult jsonRet3 = drogueRunPositionController.Post(drogueRunPositionRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<DrogueRunPosition> drogueRunPositionRet3 = jsonRet3 as CreatedNegotiatedContentResult<DrogueRunPosition>;
                    Assert.NotNull(drogueRunPositionRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = drogueRunPositionController.Delete(drogueRunPositionRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<DrogueRunPosition> drogueRunPositionRet4 = jsonRet4 as OkNegotiatedContentResult<DrogueRunPosition>;
                    Assert.NotNull(drogueRunPositionRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [Fact]
        public void DrogueRunPosition_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    DrogueRunPositionController drogueRunPositionController = new DrogueRunPositionController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(drogueRunPositionController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, drogueRunPositionController.DatabaseType);

                    DrogueRunPosition drogueRunPositionLast = new DrogueRunPosition();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        DrogueRunPositionService drogueRunPositionService = new DrogueRunPositionService(query, db, ContactID);
                        drogueRunPositionLast = (from c in db.DrogueRunPositions select c).FirstOrDefault();
                    }

                    // ok with DrogueRunPosition info
                    IHttpActionResult jsonRet = drogueRunPositionController.GetDrogueRunPositionWithID(drogueRunPositionLast.DrogueRunPositionID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<DrogueRunPosition> Ret = jsonRet as OkNegotiatedContentResult<DrogueRunPosition>;
                    DrogueRunPosition drogueRunPositionRet = Ret.Content;
                    Assert.Equal(drogueRunPositionLast.DrogueRunPositionID, drogueRunPositionRet.DrogueRunPositionID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = drogueRunPositionController.Put(drogueRunPositionRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<DrogueRunPosition> drogueRunPositionRet2 = jsonRet2 as OkNegotiatedContentResult<DrogueRunPosition>;
                    Assert.NotNull(drogueRunPositionRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because DrogueRunPositionID of 0 does not exist
                    drogueRunPositionRet.DrogueRunPositionID = 0;
                    IHttpActionResult jsonRet3 = drogueRunPositionController.Put(drogueRunPositionRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    OkNegotiatedContentResult<DrogueRunPosition> drogueRunPositionRet3 = jsonRet3 as OkNegotiatedContentResult<DrogueRunPosition>;
                    Assert.IsNull(drogueRunPositionRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void DrogueRunPosition_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    DrogueRunPositionController drogueRunPositionController = new DrogueRunPositionController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(drogueRunPositionController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, drogueRunPositionController.DatabaseType);

                    DrogueRunPosition drogueRunPositionLast = new DrogueRunPosition();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        DrogueRunPositionService drogueRunPositionService = new DrogueRunPositionService(query, db, ContactID);
                        drogueRunPositionLast = (from c in db.DrogueRunPositions select c).FirstOrDefault();
                    }

                    // ok with DrogueRunPosition info
                    IHttpActionResult jsonRet = drogueRunPositionController.GetDrogueRunPositionWithID(drogueRunPositionLast.DrogueRunPositionID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<DrogueRunPosition> Ret = jsonRet as OkNegotiatedContentResult<DrogueRunPosition>;
                    DrogueRunPosition drogueRunPositionRet = Ret.Content;
                    Assert.Equal(drogueRunPositionLast.DrogueRunPositionID, drogueRunPositionRet.DrogueRunPositionID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added DrogueRunPosition
                    drogueRunPositionRet.DrogueRunPositionID = 0;
                    drogueRunPositionController.Request = new System.Net.Http.HttpRequestMessage();
                    drogueRunPositionController.Request.RequestUri = new System.Uri("http://localhost:5000/api/drogueRunPosition");
                    IHttpActionResult jsonRet3 = drogueRunPositionController.Post(drogueRunPositionRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<DrogueRunPosition> drogueRunPositionRet3 = jsonRet3 as CreatedNegotiatedContentResult<DrogueRunPosition>;
                    Assert.NotNull(drogueRunPositionRet3);
                    DrogueRunPosition drogueRunPosition = drogueRunPositionRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = drogueRunPositionController.Delete(drogueRunPositionRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<DrogueRunPosition> drogueRunPositionRet2 = jsonRet2 as OkNegotiatedContentResult<DrogueRunPosition>;
                    Assert.NotNull(drogueRunPositionRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because DrogueRunPositionID of 0 does not exist
                    drogueRunPositionRet.DrogueRunPositionID = 0;
                    IHttpActionResult jsonRet4 = drogueRunPositionController.Delete(drogueRunPositionRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<DrogueRunPosition> drogueRunPositionRet4 = jsonRet4 as OkNegotiatedContentResult<DrogueRunPosition>;
                    Assert.IsNull(drogueRunPositionRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
