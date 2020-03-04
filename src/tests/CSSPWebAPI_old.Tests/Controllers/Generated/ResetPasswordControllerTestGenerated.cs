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
                    IActionResult jsonRet = resetPasswordController.GetResetPasswordList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(resetPasswordFirst.ResetPasswordID, ((List<ResetPassword>)ret.Value)[0].ResetPasswordID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<ResetPassword>)ret.Value).Count);

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
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(resetPasswordList[0].ResetPasswordID, ((List<ResetPassword>)ret.Value)[0].ResetPasswordID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<ResetPassword>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with ResetPassword info
                           IActionResult jsonRet2 = resetPasswordController.GetResetPasswordList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(resetPasswordList[1].ResetPasswordID, ((List<ResetPassword>)ret2.Value)[0].ResetPasswordID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<ResetPassword>)ret2.Value).Count);
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
                    IActionResult jsonRet = resetPasswordController.GetResetPasswordWithID(resetPasswordFirst.ResetPasswordID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(resetPasswordFirst.ResetPasswordID, ((ResetPassword)ret.Value).ResetPasswordID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = resetPasswordController.GetResetPasswordWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult resetPasswordRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(resetPasswordRet2);
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

                    ResetPassword resetPasswordFirst = new ResetPassword();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        ResetPasswordService resetPasswordService = new ResetPasswordService(query, db, ContactID);
                        resetPasswordFirst = (from c in db.ResetPasswords select c).FirstOrDefault();
                    }

                    // ok with ResetPassword info
                    IActionResult jsonRet = resetPasswordController.GetResetPasswordWithID(resetPasswordFirst.ResetPasswordID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    ResetPassword resetPasswordRet = (ResetPassword)ret.Value;
                    Assert.Equal(resetPasswordFirst.ResetPasswordID, resetPasswordRet.ResetPasswordID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because ResetPasswordID exist
                    IActionResult jsonRet2 = resetPasswordController.Post(resetPasswordRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added ResetPassword
                    resetPasswordRet.ResetPasswordID = 0;
                    IActionResult jsonRet3 = resetPasswordController.Post(resetPasswordRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = resetPasswordController.Delete(resetPasswordRet, LanguageRequest.ToString());
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
        public void ResetPassword_Controller_Put_Test()
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
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        ResetPasswordService resetPasswordService = new ResetPasswordService(query, db, ContactID);
                        resetPasswordFirst = (from c in db.ResetPasswords select c).FirstOrDefault();
                    }

                    // ok with ResetPassword info
                    IActionResult jsonRet = resetPasswordController.GetResetPasswordWithID(resetPasswordFirst.ResetPasswordID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    ResetPassword resetPasswordRet = (ResetPassword)Ret.Value;
                    Assert.Equal(resetPasswordFirst.ResetPasswordID, resetPasswordRet.ResetPasswordID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = resetPasswordController.Put(resetPasswordRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult resetPasswordRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(resetPasswordRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because ResetPasswordID of 0 does not exist
                    resetPasswordRet.ResetPasswordID = 0;
                    IActionResult jsonRet3 = resetPasswordController.Put(resetPasswordRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult resetPasswordRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(resetPasswordRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
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

                    ResetPassword resetPasswordFirst = new ResetPassword();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        ResetPasswordService resetPasswordService = new ResetPasswordService(query, db, ContactID);
                        resetPasswordFirst = (from c in db.ResetPasswords select c).FirstOrDefault();
                    }

                    // ok with ResetPassword info
                    IActionResult jsonRet = resetPasswordController.GetResetPasswordWithID(resetPasswordFirst.ResetPasswordID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    ResetPassword resetPasswordRet = (ResetPassword)Ret.Value;
                    Assert.Equal(resetPasswordFirst.ResetPasswordID, resetPasswordRet.ResetPasswordID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added ResetPassword
                    resetPasswordRet.ResetPasswordID = 0;
                    IActionResult jsonRet3 = resetPasswordController.Post(resetPasswordRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    ResetPassword resetPassword = (ResetPassword)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = resetPasswordController.Delete(resetPasswordRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because ResetPasswordID of 0 does not exist
                    resetPasswordRet.ResetPasswordID = 0;
                    IActionResult jsonRet4 = resetPasswordController.Delete(resetPasswordRet, LanguageRequest.ToString());
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
