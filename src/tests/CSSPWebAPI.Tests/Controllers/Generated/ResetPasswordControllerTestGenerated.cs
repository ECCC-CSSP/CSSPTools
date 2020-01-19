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
    public partial class ResetPasswordControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ResetPasswordControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void ResetPassword_Controller_GetResetPasswordList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ResetPasswordController resetPasswordController = new ResetPasswordController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(resetPasswordController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, resetPasswordController.DatabaseType);

                    ResetPassword resetPasswordFirst = new ResetPassword();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        ResetPasswordService resetPasswordService = new ResetPasswordService(query, db, ContactID);
                        resetPasswordFirst = (from c in db.ResetPasswords select c).FirstOrDefault();
                        count = (from c in db.ResetPasswords select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with ResetPassword info
                    IHttpActionResult jsonRet = resetPasswordController.GetResetPasswordList();
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<List<ResetPassword>> ret = jsonRet as OkNegotiatedContentResult<List<ResetPassword>>;
                    Assert.Equal(resetPasswordFirst.ResetPasswordID, ret.Content[0].ResetPasswordID);
                    Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                    List<ResetPassword> resetPasswordList = new List<ResetPassword>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        ResetPasswordService resetPasswordService = new ResetPasswordService(query, db, ContactID);
                        resetPasswordList = (from c in db.ResetPasswords select c).OrderBy(c => c.ResetPasswordID).Skip(0).Take(2).ToList();
                        count = (from c in db.ResetPasswords select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with ResetPassword info
                        jsonRet = resetPasswordController.GetResetPasswordList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.NotNull(jsonRet);

                        ret = jsonRet as OkNegotiatedContentResult<List<ResetPassword>>;
                        Assert.Equal(resetPasswordList[0].ResetPasswordID, ret.Content[0].ResetPasswordID);
                        Assert.Equal((count > query.Take ? query.Take : count), ret.Content.Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with ResetPassword info
                           IHttpActionResult jsonRet2 = resetPasswordController.GetResetPasswordList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkNegotiatedContentResult<List<ResetPassword>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<ResetPassword>>;
                           Assert.Equal(resetPasswordList[1].ResetPasswordID, ret2.Content[0].ResetPasswordID);
                           Assert.Equal((count > query.Take ? query.Take : count), ret2.Content.Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void ResetPassword_Controller_GetResetPasswordWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ResetPasswordController resetPasswordController = new ResetPasswordController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(resetPasswordController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, resetPasswordController.DatabaseType);

                    ResetPassword resetPasswordFirst = new ResetPassword();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        ResetPasswordService resetPasswordService = new ResetPasswordService(new Query(), db, ContactID);
                        resetPasswordFirst = (from c in db.ResetPasswords select c).FirstOrDefault();
                    }

                    // ok with ResetPassword info
                    IHttpActionResult jsonRet = resetPasswordController.GetResetPasswordWithID(resetPasswordFirst.ResetPasswordID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<ResetPassword> Ret = jsonRet as OkNegotiatedContentResult<ResetPassword>;
                    ResetPassword resetPasswordRet = Ret.Content;
                    Assert.Equal(resetPasswordFirst.ResetPasswordID, resetPasswordRet.ResetPasswordID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Not Found
                    IHttpActionResult jsonRet2 = resetPasswordController.GetResetPasswordWithID(0);
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<ResetPassword> resetPasswordRet2 = jsonRet2 as OkNegotiatedContentResult<ResetPassword>;
                    Assert.IsNull(resetPasswordRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.NotNull(notFoundRequest);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void ResetPassword_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ResetPasswordController resetPasswordController = new ResetPasswordController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(resetPasswordController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, resetPasswordController.DatabaseType);

                    ResetPassword resetPasswordLast = new ResetPassword();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        ResetPasswordService resetPasswordService = new ResetPasswordService(query, db, ContactID);
                        resetPasswordLast = (from c in db.ResetPasswords select c).FirstOrDefault();
                    }

                    // ok with ResetPassword info
                    IHttpActionResult jsonRet = resetPasswordController.GetResetPasswordWithID(resetPasswordLast.ResetPasswordID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<ResetPassword> Ret = jsonRet as OkNegotiatedContentResult<ResetPassword>;
                    ResetPassword resetPasswordRet = Ret.Content;
                    Assert.Equal(resetPasswordLast.ResetPasswordID, resetPasswordRet.ResetPasswordID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return CSSPError because ResetPasswordID exist
                    IHttpActionResult jsonRet2 = resetPasswordController.Post(resetPasswordRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<ResetPassword> resetPasswordRet2 = jsonRet2 as OkNegotiatedContentResult<ResetPassword>;
                    Assert.IsNull(resetPasswordRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added ResetPassword
                    resetPasswordRet.ResetPasswordID = 0;
                    resetPasswordController.Request = new System.Net.Http.HttpRequestMessage();
                    resetPasswordController.Request.RequestUri = new System.Uri("http://localhost:5000/api/resetPassword");
                    IHttpActionResult jsonRet3 = resetPasswordController.Post(resetPasswordRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<ResetPassword> resetPasswordRet3 = jsonRet3 as CreatedNegotiatedContentResult<ResetPassword>;
                    Assert.NotNull(resetPasswordRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    IHttpActionResult jsonRet4 = resetPasswordController.Delete(resetPasswordRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<ResetPassword> resetPasswordRet4 = jsonRet4 as OkNegotiatedContentResult<ResetPassword>;
                    Assert.NotNull(resetPasswordRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Post Command

        #region Tests Generated for Class Controller Put Command
        [Fact]
        public void ResetPassword_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ResetPasswordController resetPasswordController = new ResetPasswordController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(resetPasswordController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, resetPasswordController.DatabaseType);

                    ResetPassword resetPasswordLast = new ResetPassword();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        ResetPasswordService resetPasswordService = new ResetPasswordService(query, db, ContactID);
                        resetPasswordLast = (from c in db.ResetPasswords select c).FirstOrDefault();
                    }

                    // ok with ResetPassword info
                    IHttpActionResult jsonRet = resetPasswordController.GetResetPasswordWithID(resetPasswordLast.ResetPasswordID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<ResetPassword> Ret = jsonRet as OkNegotiatedContentResult<ResetPassword>;
                    ResetPassword resetPasswordRet = Ret.Content;
                    Assert.Equal(resetPasswordLast.ResetPasswordID, resetPasswordRet.ResetPasswordID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Put to return success
                    IHttpActionResult jsonRet2 = resetPasswordController.Put(resetPasswordRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<ResetPassword> resetPasswordRet2 = jsonRet2 as OkNegotiatedContentResult<ResetPassword>;
                    Assert.NotNull(resetPasswordRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Put to return CSSPError because ResetPasswordID of 0 does not exist
                    resetPasswordRet.ResetPasswordID = 0;
                    IHttpActionResult jsonRet3 = resetPasswordController.Put(resetPasswordRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    OkNegotiatedContentResult<ResetPassword> resetPasswordRet3 = jsonRet3 as OkNegotiatedContentResult<ResetPassword>;
                    Assert.IsNull(resetPasswordRet3);

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void ResetPassword_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ResetPasswordController resetPasswordController = new ResetPasswordController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(resetPasswordController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, resetPasswordController.DatabaseType);

                    ResetPassword resetPasswordLast = new ResetPassword();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        ResetPasswordService resetPasswordService = new ResetPasswordService(query, db, ContactID);
                        resetPasswordLast = (from c in db.ResetPasswords select c).FirstOrDefault();
                    }

                    // ok with ResetPassword info
                    IHttpActionResult jsonRet = resetPasswordController.GetResetPasswordWithID(resetPasswordLast.ResetPasswordID);
                    Assert.NotNull(jsonRet);

                    OkNegotiatedContentResult<ResetPassword> Ret = jsonRet as OkNegotiatedContentResult<ResetPassword>;
                    ResetPassword resetPasswordRet = Ret.Content;
                    Assert.Equal(resetPasswordLast.ResetPasswordID, resetPasswordRet.ResetPasswordID);

                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest);

                    // Post to return newly added ResetPassword
                    resetPasswordRet.ResetPasswordID = 0;
                    resetPasswordController.Request = new System.Net.Http.HttpRequestMessage();
                    resetPasswordController.Request.RequestUri = new System.Uri("http://localhost:5000/api/resetPassword");
                    IHttpActionResult jsonRet3 = resetPasswordController.Post(resetPasswordRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet3);

                    CreatedNegotiatedContentResult<ResetPassword> resetPasswordRet3 = jsonRet3 as CreatedNegotiatedContentResult<ResetPassword>;
                    Assert.NotNull(resetPasswordRet3);
                    ResetPassword resetPassword = resetPasswordRet3.Content;

                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest3);

                    // Delete to return success
                    IHttpActionResult jsonRet2 = resetPasswordController.Delete(resetPasswordRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet2);

                    OkNegotiatedContentResult<ResetPassword> resetPasswordRet2 = jsonRet2 as OkNegotiatedContentResult<ResetPassword>;
                    Assert.NotNull(resetPasswordRet2);

                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;
                    Assert.IsNull(badRequest2);

                    // Delete to return CSSPError because ResetPasswordID of 0 does not exist
                    resetPasswordRet.ResetPasswordID = 0;
                    IHttpActionResult jsonRet4 = resetPasswordController.Delete(resetPasswordRet, LanguageRequest.ToString());
                    Assert.NotNull(jsonRet4);

                    OkNegotiatedContentResult<ResetPassword> resetPasswordRet4 = jsonRet4 as OkNegotiatedContentResult<ResetPassword>;
                    Assert.IsNull(resetPasswordRet4);

                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;
                    Assert.NotNull(badRequest4);
                }
            }
        }
        #endregion Tests Generated for Class Controller Delete Command

    }
}
