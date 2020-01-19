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
    public partial class HydrometricDataValueControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public HydrometricDataValueControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void HydrometricDataValue_Controller_GetHydrometricDataValueList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    HydrometricDataValueController hydrometricDataValueController = new HydrometricDataValueController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(hydrometricDataValueController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, hydrometricDataValueController.DatabaseType);

                    HydrometricDataValue hydrometricDataValueFirst = new HydrometricDataValue();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        HydrometricDataValueService hydrometricDataValueService = new HydrometricDataValueService(query, db, ContactID);
                        hydrometricDataValueFirst = (from c in db.HydrometricDataValues select c).FirstOrDefault();
                        count = (from c in db.HydrometricDataValues select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with HydrometricDataValue info
                    IHttpActionResult jsonRet = hydrometricDataValueController.GetHydrometricDataValueList();
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<List<HydrometricDataValue>> ret = jsonRet as OkNegotiatedContentResult<List<HydrometricDataValue>>;
                    Assert.Equal(hydrometricDataValueFirst.HydrometricDataValueID, ret.Content[0].HydrometricDataValueID);
                    Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<HydrometricDataValue> hydrometricDataValueList = new List<HydrometricDataValue>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        HydrometricDataValueService hydrometricDataValueService = new HydrometricDataValueService(query, db, ContactID);
                        hydrometricDataValueList = (from c in db.HydrometricDataValues select c).OrderBy(c => c.HydrometricDataValueID).Skip(0).Take(2).ToList();
                        count = (from c in db.HydrometricDataValues select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with HydrometricDataValue info
                        jsonRet = hydrometricDataValueController.GetHydrometricDataValueList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.NotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<HydrometricDataValue>>;
                        Assert.Equal(hydrometricDataValueList[0].HydrometricDataValueID, ret.Content[0].HydrometricDataValueID);
                        Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with HydrometricDataValue info
                           IHttpActionResult jsonRet2 = hydrometricDataValueController.GetHydrometricDataValueList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkNegotiatedContentResult<List<HydrometricDataValue>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<HydrometricDataValue>>;
                           Assert.Equal(hydrometricDataValueList[1].HydrometricDataValueID, ret2.Content[0].HydrometricDataValueID);
                           Assert.Equal((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void HydrometricDataValue_Controller_GetHydrometricDataValueWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    HydrometricDataValueController hydrometricDataValueController = new HydrometricDataValueController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(hydrometricDataValueController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, hydrometricDataValueController.DatabaseType);

                    HydrometricDataValue hydrometricDataValueFirst = new HydrometricDataValue();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        HydrometricDataValueService hydrometricDataValueService = new HydrometricDataValueService(new Query(), db, ContactID);
                        hydrometricDataValueFirst = (from c in db.HydrometricDataValues select c).FirstOrDefault();
                    }

                    // ok with HydrometricDataValue info
                    IHttpActionResult jsonRet = hydrometricDataValueController.GetHydrometricDataValueWithID(hydrometricDataValueFirst.HydrometricDataValueID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<HydrometricDataValue> Ret = jsonRet as OkNegotiatedContentResult<HydrometricDataValue>;
                    HydrometricDataValue hydrometricDataValueRet = Ret.Content;
                    Assert.Equal(hydrometricDataValueFirst.HydrometricDataValueID, hydrometricDataValueRet.HydrometricDataValueID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = hydrometricDataValueController.GetHydrometricDataValueWithID(0);
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<HydrometricDataValue> hydrometricDataValueRet2 = jsonRet2 as OkNegotiatedContentResult<HydrometricDataValue>;
                    Assert.IsNull(hydrometricDataValueRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.NotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void HydrometricDataValue_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    HydrometricDataValueController hydrometricDataValueController = new HydrometricDataValueController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(hydrometricDataValueController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, hydrometricDataValueController.DatabaseType);

                    HydrometricDataValue hydrometricDataValueLast = new HydrometricDataValue();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        HydrometricDataValueService hydrometricDataValueService = new HydrometricDataValueService(query, db, ContactID);
                        hydrometricDataValueLast = (from c in db.HydrometricDataValues select c).FirstOrDefault();
                    }

                    // ok with HydrometricDataValue info
                    IHttpActionResult jsonRet = hydrometricDataValueController.GetHydrometricDataValueWithID(hydrometricDataValueLast.HydrometricDataValueID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<HydrometricDataValue> Ret = jsonRet as OkNegotiatedContentResult<HydrometricDataValue>;
                    HydrometricDataValue hydrometricDataValueRet = Ret.Content;
                    Assert.Equal(hydrometricDataValueLast.HydrometricDataValueID, hydrometricDataValueRet.HydrometricDataValueID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because HydrometricDataValueID exist
                    IHttpActionResult jsonRet2 = hydrometricDataValueController.Post(hydrometricDataValueRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<HydrometricDataValue> hydrometricDataValueRet2 = jsonRet2 as OkNegotiatedContentResult<HydrometricDataValue>;
                    Assert.IsNull(hydrometricDataValueRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added HydrometricDataValue
                    hydrometricDataValueRet.HydrometricDataValueID = 0;
                    hydrometricDataValueController.Request = new System.Net.Http.HttpRequestMessage();
                    hydrometricDataValueController.Request.RequestUri = new System.Uri("http://localhost:5000/api/hydrometricDataValue");
                    IHttpActionResult jsonRet3 = hydrometricDataValueController.Post(hydrometricDataValueRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<HydrometricDataValue> hydrometricDataValueRet3 = jsonRet3 as CreatedNegotiatedContentResult<HydrometricDataValue>;
                    Assert.NotNull(hydrometricDataValueRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = hydrometricDataValueController.Delete(hydrometricDataValueRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<HydrometricDataValue> hydrometricDataValueRet4 = jsonRet4 as OkNegotiatedContentResult<HydrometricDataValue>;
                    Assert.NotNull(hydrometricDataValueRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [Fact]
        public void HydrometricDataValue_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    HydrometricDataValueController hydrometricDataValueController = new HydrometricDataValueController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(hydrometricDataValueController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, hydrometricDataValueController.DatabaseType);

                    HydrometricDataValue hydrometricDataValueLast = new HydrometricDataValue();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        HydrometricDataValueService hydrometricDataValueService = new HydrometricDataValueService(query, db, ContactID);
                        hydrometricDataValueLast = (from c in db.HydrometricDataValues select c).FirstOrDefault();
                    }

                    // ok with HydrometricDataValue info
                    IHttpActionResult jsonRet = hydrometricDataValueController.GetHydrometricDataValueWithID(hydrometricDataValueLast.HydrometricDataValueID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<HydrometricDataValue> Ret = jsonRet as OkNegotiatedContentResult<HydrometricDataValue>;
                    HydrometricDataValue hydrometricDataValueRet = Ret.Content;
                    Assert.Equal(hydrometricDataValueLast.HydrometricDataValueID, hydrometricDataValueRet.HydrometricDataValueID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = hydrometricDataValueController.Put(hydrometricDataValueRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<HydrometricDataValue> hydrometricDataValueRet2 = jsonRet2 as OkNegotiatedContentResult<HydrometricDataValue>;
                    Assert.NotNull(hydrometricDataValueRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because HydrometricDataValueID of 0 does not exist
                    hydrometricDataValueRet.HydrometricDataValueID = 0;
                    IHttpActionResult jsonRet3 = hydrometricDataValueController.Put(hydrometricDataValueRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    OkNegotiatedContentResult<HydrometricDataValue> hydrometricDataValueRet3 = jsonRet3 as OkNegotiatedContentResult<HydrometricDataValue>;
                    Assert.IsNull(hydrometricDataValueRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void HydrometricDataValue_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    HydrometricDataValueController hydrometricDataValueController = new HydrometricDataValueController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(hydrometricDataValueController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, hydrometricDataValueController.DatabaseType);

                    HydrometricDataValue hydrometricDataValueLast = new HydrometricDataValue();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        HydrometricDataValueService hydrometricDataValueService = new HydrometricDataValueService(query, db, ContactID);
                        hydrometricDataValueLast = (from c in db.HydrometricDataValues select c).FirstOrDefault();
                    }

                    // ok with HydrometricDataValue info
                    IHttpActionResult jsonRet = hydrometricDataValueController.GetHydrometricDataValueWithID(hydrometricDataValueLast.HydrometricDataValueID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<HydrometricDataValue> Ret = jsonRet as OkNegotiatedContentResult<HydrometricDataValue>;
                    HydrometricDataValue hydrometricDataValueRet = Ret.Content;
                    Assert.Equal(hydrometricDataValueLast.HydrometricDataValueID, hydrometricDataValueRet.HydrometricDataValueID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added HydrometricDataValue
                    hydrometricDataValueRet.HydrometricDataValueID = 0;
                    hydrometricDataValueController.Request = new System.Net.Http.HttpRequestMessage();
                    hydrometricDataValueController.Request.RequestUri = new System.Uri("http://localhost:5000/api/hydrometricDataValue");
                    IHttpActionResult jsonRet3 = hydrometricDataValueController.Post(hydrometricDataValueRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<HydrometricDataValue> hydrometricDataValueRet3 = jsonRet3 as CreatedNegotiatedContentResult<HydrometricDataValue>;
                    Assert.NotNull(hydrometricDataValueRet3);
                    HydrometricDataValue hydrometricDataValue = hydrometricDataValueRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = hydrometricDataValueController.Delete(hydrometricDataValueRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<HydrometricDataValue> hydrometricDataValueRet2 = jsonRet2 as OkNegotiatedContentResult<HydrometricDataValue>;
                    Assert.NotNull(hydrometricDataValueRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because HydrometricDataValueID of 0 does not exist
                    hydrometricDataValueRet.HydrometricDataValueID = 0;
                    IHttpActionResult jsonRet4 = hydrometricDataValueController.Delete(hydrometricDataValueRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<HydrometricDataValue> hydrometricDataValueRet4 = jsonRet4 as OkNegotiatedContentResult<HydrometricDataValue>;
                    Assert.IsNull(hydrometricDataValueRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
