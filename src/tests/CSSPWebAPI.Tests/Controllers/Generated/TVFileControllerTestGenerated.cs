using CSSPEnums;
using CSSPModels;
using CSSPServices;
using CSSPWebAPI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;

namespace CSSPWebAPI.Tests.Controllers
{
    [TestClass]
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
        [TestMethod]
        public void TVFile_Controller_GetTVFileList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVFileController tvFileController = new TVFileController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(tvFileController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, tvFileController.DatabaseType);

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
                    IHttpActionResult jsonRet = tvFileController.GetTVFileList();
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<List<TVFile>> ret = jsonRet as OkNegotiatedContentResult<List<TVFile>>;
                    Assert.AreEqual(tvFileFirst.TVFileID, ret.Content[0].TVFileID);
                    Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

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
                        Assert.IsNotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<TVFile>>;
                        Assert.AreEqual(tvFileList[0].TVFileID, ret.Content[0].TVFileID);
                        Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with TVFile info
                           IHttpActionResult jsonRet2 = tvFileController.GetTVFileList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.IsNotNull(jsonRet2);

                           OkNegotiatedContentResult<List<TVFile>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<TVFile>>;
                           Assert.AreEqual(tvFileList[1].TVFileID, ret2.Content[0].TVFileID);
                           Assert.AreEqual((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [TestMethod]
        public void TVFile_Controller_GetTVFileWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVFileController tvFileController = new TVFileController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(tvFileController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, tvFileController.DatabaseType);

                    TVFile tvFileFirst = new TVFile();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        TVFileService tvFileService = new TVFileService(new Query(), db, ContactID);
                        tvFileFirst = (from c in db.TVFiles select c).FirstOrDefault();
                    }

                    // ok with TVFile info
                    IHttpActionResult jsonRet = tvFileController.GetTVFileWithID(tvFileFirst.TVFileID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<TVFile> Ret = jsonRet as OkNegotiatedContentResult<TVFile>;
                    TVFile tvFileRet = Ret.Content;
                    Assert.AreEqual(tvFileFirst.TVFileID, tvFileRet.TVFileID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = tvFileController.GetTVFileWithID(0);
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<TVFile> tvFileRet2 = jsonRet2 as OkNegotiatedContentResult<TVFile>;
                    Assert.IsNull(tvFileRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.IsNotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [TestMethod]
        public void TVFile_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVFileController tvFileController = new TVFileController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(tvFileController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, tvFileController.DatabaseType);

                    TVFile tvFileLast = new TVFile();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        TVFileService tvFileService = new TVFileService(query, db, ContactID);
                        tvFileLast = (from c in db.TVFiles select c).FirstOrDefault();
                    }

                    // ok with TVFile info
                    IHttpActionResult jsonRet = tvFileController.GetTVFileWithID(tvFileLast.TVFileID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<TVFile> Ret = jsonRet as OkNegotiatedContentResult<TVFile>;
                    TVFile tvFileRet = Ret.Content;
                    Assert.AreEqual(tvFileLast.TVFileID, tvFileRet.TVFileID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because TVFileID exist
                    IHttpActionResult jsonRet2 = tvFileController.Post(tvFileRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<TVFile> tvFileRet2 = jsonRet2 as OkNegotiatedContentResult<TVFile>;
                    Assert.IsNull(tvFileRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest2);

                    // Post to return newly added TVFile
                    tvFileRet.TVFileID = 0;
                    tvFileController.Request = new System.Net.Http.HttpRequestMessage();
                    tvFileController.Request.RequestUri = new System.Uri("http://localhost:5000/api/tvFile");
                    IHttpActionResult jsonRet3 = tvFileController.Post(tvFileRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<TVFile> tvFileRet3 = jsonRet3 as CreatedNegotiatedContentResult<TVFile>;
                    Assert.IsNotNull(tvFileRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = tvFileController.Delete(tvFileRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<TVFile> tvFileRet4 = jsonRet4 as OkNegotiatedContentResult<TVFile>;
                    Assert.IsNotNull(tvFileRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [TestMethod]
        public void TVFile_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVFileController tvFileController = new TVFileController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(tvFileController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, tvFileController.DatabaseType);

                    TVFile tvFileLast = new TVFile();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        TVFileService tvFileService = new TVFileService(query, db, ContactID);
                        tvFileLast = (from c in db.TVFiles select c).FirstOrDefault();
                    }

                    // ok with TVFile info
                    IHttpActionResult jsonRet = tvFileController.GetTVFileWithID(tvFileLast.TVFileID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<TVFile> Ret = jsonRet as OkNegotiatedContentResult<TVFile>;
                    TVFile tvFileRet = Ret.Content;
                    Assert.AreEqual(tvFileLast.TVFileID, tvFileRet.TVFileID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = tvFileController.Put(tvFileRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<TVFile> tvFileRet2 = jsonRet2 as OkNegotiatedContentResult<TVFile>;
                    Assert.IsNotNull(tvFileRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because TVFileID of 0 does not exist
                    tvFileRet.TVFileID = 0;
                    IHttpActionResult jsonRet3 = tvFileController.Put(tvFileRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    OkNegotiatedContentResult<TVFile> tvFileRet3 = jsonRet3 as OkNegotiatedContentResult<TVFile>;
                    Assert.IsNull(tvFileRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [TestMethod]
        public void TVFile_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    TVFileController tvFileController = new TVFileController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.IsNotNull(tvFileController);
                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, tvFileController.DatabaseType);

                    TVFile tvFileLast = new TVFile();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        TVFileService tvFileService = new TVFileService(query, db, ContactID);
                        tvFileLast = (from c in db.TVFiles select c).FirstOrDefault();
                    }

                    // ok with TVFile info
                    IHttpActionResult jsonRet = tvFileController.GetTVFileWithID(tvFileLast.TVFileID);
                    Assert.IsNotNull(jsonRet);

                    OkNegotiatedContentResult<TVFile> Ret = jsonRet as OkNegotiatedContentResult<TVFile>;
                    TVFile tvFileRet = Ret.Content;
                    Assert.AreEqual(tvFileLast.TVFileID, tvFileRet.TVFileID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added TVFile
                    tvFileRet.TVFileID = 0;
                    tvFileController.Request = new System.Net.Http.HttpRequestMessage();
                    tvFileController.Request.RequestUri = new System.Uri("http://localhost:5000/api/tvFile");
                    IHttpActionResult jsonRet3 = tvFileController.Post(tvFileRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet3);

                    CreatedNegotiatedContentResult<TVFile> tvFileRet3 = jsonRet3 as CreatedNegotiatedContentResult<TVFile>;
                    Assert.IsNotNull(tvFileRet3);
                    TVFile tvFile = tvFileRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = tvFileController.Delete(tvFileRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet2);

                    OkNegotiatedContentResult<TVFile> tvFileRet2 = jsonRet2 as OkNegotiatedContentResult<TVFile>;
                    Assert.IsNotNull(tvFileRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because TVFileID of 0 does not exist
                    tvFileRet.TVFileID = 0;
                    IHttpActionResult jsonRet4 = tvFileController.Delete(tvFileRet, LanguageRequest.ToString());
                    Assert.IsNotNull(jsonRet4);

                    OkNegotiatedContentResult<TVFile> tvFileRet4 = jsonRet4 as OkNegotiatedContentResult<TVFile>;
                    Assert.IsNull(tvFileRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
