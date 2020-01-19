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
                    IHttpActionResult jsonRet = mikeSourceStartEndController.GetMikeSourceStartEndList();
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<List<MikeSourceStartEnd>> ret = jsonRet as OkNegotiatedContentResult<List<MikeSourceStartEnd>>;
                    Assert.Equal(mikeSourceStartEndFirst.MikeSourceStartEndID, ret.Content[0].MikeSourceStartEndID);
                    Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

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
                        Assert.NotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<MikeSourceStartEnd>>;
                        Assert.Equal(mikeSourceStartEndList[0].MikeSourceStartEndID, ret.Content[0].MikeSourceStartEndID);
                        Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with MikeSourceStartEnd info
                           IHttpActionResult jsonRet2 = mikeSourceStartEndController.GetMikeSourceStartEndList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkNegotiatedContentResult<List<MikeSourceStartEnd>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<MikeSourceStartEnd>>;
                           Assert.Equal(mikeSourceStartEndList[1].MikeSourceStartEndID, ret2.Content[0].MikeSourceStartEndID);
                           Assert.Equal((count > query.Take ? query.Take : count), ret2.Content.Count);
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
                    IHttpActionResult jsonRet = mikeSourceStartEndController.GetMikeSourceStartEndWithID(mikeSourceStartEndFirst.MikeSourceStartEndID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<MikeSourceStartEnd> Ret = jsonRet as OkNegotiatedContentResult<MikeSourceStartEnd>;
                    MikeSourceStartEnd mikeSourceStartEndRet = Ret.Content;
                    Assert.Equal(mikeSourceStartEndFirst.MikeSourceStartEndID, mikeSourceStartEndRet.MikeSourceStartEndID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = mikeSourceStartEndController.GetMikeSourceStartEndWithID(0);
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<MikeSourceStartEnd> mikeSourceStartEndRet2 = jsonRet2 as OkNegotiatedContentResult<MikeSourceStartEnd>;
                    Assert.IsNull(mikeSourceStartEndRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.NotNull(notFoundRequest);
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

                    MikeSourceStartEnd mikeSourceStartEndLast = new MikeSourceStartEnd();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MikeSourceStartEndService mikeSourceStartEndService = new MikeSourceStartEndService(query, db, ContactID);
                        mikeSourceStartEndLast = (from c in db.MikeSourceStartEnds select c).FirstOrDefault();
                    }

                    // ok with MikeSourceStartEnd info
                    IHttpActionResult jsonRet = mikeSourceStartEndController.GetMikeSourceStartEndWithID(mikeSourceStartEndLast.MikeSourceStartEndID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<MikeSourceStartEnd> Ret = jsonRet as OkNegotiatedContentResult<MikeSourceStartEnd>;
                    MikeSourceStartEnd mikeSourceStartEndRet = Ret.Content;
                    Assert.Equal(mikeSourceStartEndLast.MikeSourceStartEndID, mikeSourceStartEndRet.MikeSourceStartEndID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because MikeSourceStartEndID exist
                    IHttpActionResult jsonRet2 = mikeSourceStartEndController.Post(mikeSourceStartEndRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<MikeSourceStartEnd> mikeSourceStartEndRet2 = jsonRet2 as OkNegotiatedContentResult<MikeSourceStartEnd>;
                    Assert.IsNull(mikeSourceStartEndRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added MikeSourceStartEnd
                    mikeSourceStartEndRet.MikeSourceStartEndID = 0;
                    mikeSourceStartEndController.Request = new System.Net.Http.HttpRequestMessage();
                    mikeSourceStartEndController.Request.RequestUri = new System.Uri("http://localhost:5000/api/mikeSourceStartEnd");
                    IHttpActionResult jsonRet3 = mikeSourceStartEndController.Post(mikeSourceStartEndRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<MikeSourceStartEnd> mikeSourceStartEndRet3 = jsonRet3 as CreatedNegotiatedContentResult<MikeSourceStartEnd>;
                    Assert.NotNull(mikeSourceStartEndRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = mikeSourceStartEndController.Delete(mikeSourceStartEndRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<MikeSourceStartEnd> mikeSourceStartEndRet4 = jsonRet4 as OkNegotiatedContentResult<MikeSourceStartEnd>;
                    Assert.NotNull(mikeSourceStartEndRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
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

                    MikeSourceStartEnd mikeSourceStartEndLast = new MikeSourceStartEnd();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        MikeSourceStartEndService mikeSourceStartEndService = new MikeSourceStartEndService(query, db, ContactID);
                        mikeSourceStartEndLast = (from c in db.MikeSourceStartEnds select c).FirstOrDefault();
                    }

                    // ok with MikeSourceStartEnd info
                    IHttpActionResult jsonRet = mikeSourceStartEndController.GetMikeSourceStartEndWithID(mikeSourceStartEndLast.MikeSourceStartEndID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<MikeSourceStartEnd> Ret = jsonRet as OkNegotiatedContentResult<MikeSourceStartEnd>;
                    MikeSourceStartEnd mikeSourceStartEndRet = Ret.Content;
                    Assert.Equal(mikeSourceStartEndLast.MikeSourceStartEndID, mikeSourceStartEndRet.MikeSourceStartEndID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = mikeSourceStartEndController.Put(mikeSourceStartEndRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<MikeSourceStartEnd> mikeSourceStartEndRet2 = jsonRet2 as OkNegotiatedContentResult<MikeSourceStartEnd>;
                    Assert.NotNull(mikeSourceStartEndRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because MikeSourceStartEndID of 0 does not exist
                    mikeSourceStartEndRet.MikeSourceStartEndID = 0;
                    IHttpActionResult jsonRet3 = mikeSourceStartEndController.Put(mikeSourceStartEndRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    OkNegotiatedContentResult<MikeSourceStartEnd> mikeSourceStartEndRet3 = jsonRet3 as OkNegotiatedContentResult<MikeSourceStartEnd>;
                    Assert.IsNull(mikeSourceStartEndRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
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

                    MikeSourceStartEnd mikeSourceStartEndLast = new MikeSourceStartEnd();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        MikeSourceStartEndService mikeSourceStartEndService = new MikeSourceStartEndService(query, db, ContactID);
                        mikeSourceStartEndLast = (from c in db.MikeSourceStartEnds select c).FirstOrDefault();
                    }

                    // ok with MikeSourceStartEnd info
                    IHttpActionResult jsonRet = mikeSourceStartEndController.GetMikeSourceStartEndWithID(mikeSourceStartEndLast.MikeSourceStartEndID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<MikeSourceStartEnd> Ret = jsonRet as OkNegotiatedContentResult<MikeSourceStartEnd>;
                    MikeSourceStartEnd mikeSourceStartEndRet = Ret.Content;
                    Assert.Equal(mikeSourceStartEndLast.MikeSourceStartEndID, mikeSourceStartEndRet.MikeSourceStartEndID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added MikeSourceStartEnd
                    mikeSourceStartEndRet.MikeSourceStartEndID = 0;
                    mikeSourceStartEndController.Request = new System.Net.Http.HttpRequestMessage();
                    mikeSourceStartEndController.Request.RequestUri = new System.Uri("http://localhost:5000/api/mikeSourceStartEnd");
                    IHttpActionResult jsonRet3 = mikeSourceStartEndController.Post(mikeSourceStartEndRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<MikeSourceStartEnd> mikeSourceStartEndRet3 = jsonRet3 as CreatedNegotiatedContentResult<MikeSourceStartEnd>;
                    Assert.NotNull(mikeSourceStartEndRet3);
                    MikeSourceStartEnd mikeSourceStartEnd = mikeSourceStartEndRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = mikeSourceStartEndController.Delete(mikeSourceStartEndRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<MikeSourceStartEnd> mikeSourceStartEndRet2 = jsonRet2 as OkNegotiatedContentResult<MikeSourceStartEnd>;
                    Assert.NotNull(mikeSourceStartEndRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because MikeSourceStartEndID of 0 does not exist
                    mikeSourceStartEndRet.MikeSourceStartEndID = 0;
                    IHttpActionResult jsonRet4 = mikeSourceStartEndController.Delete(mikeSourceStartEndRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<MikeSourceStartEnd> mikeSourceStartEndRet4 = jsonRet4 as OkNegotiatedContentResult<MikeSourceStartEnd>;
                    Assert.IsNull(mikeSourceStartEndRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
