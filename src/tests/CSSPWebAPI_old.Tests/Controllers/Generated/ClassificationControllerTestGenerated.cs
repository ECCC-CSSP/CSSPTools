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
    public partial class ClassificationControllerTest : BaseControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ClassificationControllerTest() : base()
        {
        }
        #endregion Constructors

        #region Tests Generated for Class Controller GetList Command
        [Fact]
        public void Classification_Controller_GetClassificationList_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ClassificationController classificationController = new ClassificationController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(classificationController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, classificationController.DatabaseType);

                    Classification classificationFirst = new Classification();
                    int count = -1;
                    Query query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        ClassificationService classificationService = new ClassificationService(query, db, ContactID);
                        classificationFirst = (from c in db.Classifications select c).FirstOrDefault();
                        count = (from c in db.Classifications select c).Count();
                        count = (query.Take > count ? count : query.Take);
                    }

                    // ok with Classification info
                    IActionResult jsonRet = classificationController.GetClassificationList();
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(classificationFirst.ClassificationID, ((List<Classification>)ret.Value)[0].ClassificationID);
                    Assert.Equal((count > query.Take ? query.Take : count), ((List<Classification>)ret.Value).Count);

                    List<Classification> classificationList = new List<Classification>();
                    count = -1;
                    query = new Query();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                    {
                        ClassificationService classificationService = new ClassificationService(query, db, ContactID);
                        classificationList = (from c in db.Classifications select c).OrderBy(c => c.ClassificationID).Skip(0).Take(2).ToList();
                        count = (from c in db.Classifications select c).Count();
                    }

                    if (count > 0)
                    {
                        query.Skip = 0;
                        query.Take = 5;
                        count = (query.Take > count ? query.Take : count);

                        // ok with Classification info
                        jsonRet = classificationController.GetClassificationList(query.Language.ToString(), query.Skip, query.Take);
                        Assert.IsType<OkObjectResult>(jsonRet);

                        ret = jsonRet as OkObjectResult;
                        Assert.Equal(classificationList[0].ClassificationID, ((List<Classification>)ret.Value)[0].ClassificationID);
                        Assert.Equal((count > query.Take ? query.Take : count), ((List<Classification>)ret.Value).Count);

                       if (count > 1)
                       {
                           query.Skip = 1;
                           query.Take = 5;
                           count = (query.Take > count ? query.Take : count);

                           // ok with Classification info
                           IActionResult jsonRet2 = classificationController.GetClassificationList(query.Language.ToString(), query.Skip, query.Take);
                           Assert.NotNull(jsonRet2);

                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                           Assert.Equal(classificationList[1].ClassificationID, ((List<Classification>)ret2.Value)[0].ClassificationID);
                           Assert.Equal((count > query.Take ? query.Take : count), ((List<Classification>)ret2.Value).Count);
                       }
                    }
                }
            }
        }
        #endregion Tests Generated for Class Controller GetList Command

        #region Tests Generated for Class Controller GetWithID Command
        [Fact]
        public void Classification_Controller_GetClassificationWithID_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ClassificationController classificationController = new ClassificationController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(classificationController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, classificationController.DatabaseType);

                    Classification classificationFirst = new Classification();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        ClassificationService classificationService = new ClassificationService(new Query(), db, ContactID);
                        classificationFirst = (from c in db.Classifications select c).FirstOrDefault();
                    }

                    // ok with Classification info
                    IActionResult jsonRet = classificationController.GetClassificationWithID(classificationFirst.ClassificationID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Assert.Equal(200, ret.StatusCode);
                    Assert.Equal(classificationFirst.ClassificationID, ((Classification)ret.Value).ClassificationID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Not Found
                    IActionResult jsonRet2 = classificationController.GetClassificationWithID(0);
                    Assert.IsType<NotFoundResult>(jsonRet2);

                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;
                    Assert.Equal(404, notFoundRequest.StatusCode);

                    OkObjectResult classificationRet2 = jsonRet2 as OkObjectResult;
                    Assert.Null(classificationRet2);
                }
            }
        }
        #endregion Tests Generated for Class Controller GetWithID Command

        #region Tests Generated for Class Controller Post Command
        [Fact]
        public void Classification_Controller_Post_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ClassificationController classificationController = new ClassificationController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(classificationController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, classificationController.DatabaseType);

                    Classification classificationFirst = new Classification();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        ClassificationService classificationService = new ClassificationService(query, db, ContactID);
                        classificationFirst = (from c in db.Classifications select c).FirstOrDefault();
                    }

                    // ok with Classification info
                    IActionResult jsonRet = classificationController.GetClassificationWithID(classificationFirst.ClassificationID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult ret = jsonRet as OkObjectResult;
                    Classification classificationRet = (Classification)ret.Value;
                    Assert.Equal(classificationFirst.ClassificationID, classificationRet.ClassificationID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return CSSPError because ClassificationID exist
                    IActionResult jsonRet2 = classificationController.Post(classificationRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.Null(ret2);

                    BadRequestObjectResult badRequest2 = jsonRet2 as BadRequestObjectResult;
                    Assert.NotNull(badRequest2);

                    // Post to return newly added Classification
                    classificationRet.ClassificationID = 0;
                    IActionResult jsonRet3 = classificationController.Post(classificationRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.NotNull(ret3);

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    IActionResult jsonRet4 = classificationController.Delete(classificationRet, LanguageRequest.ToString());
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
        public void Classification_Controller_Put_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ClassificationController classificationController = new ClassificationController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(classificationController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, classificationController.DatabaseType);

                    Classification classificationFirst = new Classification();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;

                        ClassificationService classificationService = new ClassificationService(query, db, ContactID);
                        classificationFirst = (from c in db.Classifications select c).FirstOrDefault();
                    }

                    // ok with Classification info
                    IActionResult jsonRet = classificationController.GetClassificationWithID(classificationFirst.ClassificationID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    Classification classificationRet = (Classification)Ret.Value;
                    Assert.Equal(classificationFirst.ClassificationID, classificationRet.ClassificationID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Put to return success
                    IActionResult jsonRet2 = classificationController.Put(classificationRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult classificationRet2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(classificationRet2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Put to return CSSPError because ClassificationID of 0 does not exist
                    classificationRet.ClassificationID = 0;
                    IActionResult jsonRet3 = classificationController.Put(classificationRet, LanguageRequest.ToString());
                    Assert.IsType<BadRequestObjectResult>(jsonRet3);

                    OkObjectResult classificationRet3 = jsonRet3 as OkObjectResult;
                    Assert.Null(classificationRet3);

                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;
                    Assert.NotNull(badRequest3);
                }
            }
        }
        #endregion Tests Generated for Class Controller Put Command

        #region Tests Generated for Class Controller Delete Command
        [Fact]
        public void Classification_Controller_Delete_Test()
        {
            foreach (LanguageEnum LanguageRequest in AllowableLanguages)
            {
                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })
                {
                    ClassificationController classificationController = new ClassificationController(DatabaseTypeEnum.SqlServerTestDB);
                    Assert.NotNull(classificationController);
                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, classificationController.DatabaseType);

                    Classification classificationFirst = new Classification();
                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
                    {
                        Query query = new Query();
                        query.Language = LanguageRequest;
                        query.Asc = "";
                        query.Desc = "";

                        ClassificationService classificationService = new ClassificationService(query, db, ContactID);
                        classificationFirst = (from c in db.Classifications select c).FirstOrDefault();
                    }

                    // ok with Classification info
                    IActionResult jsonRet = classificationController.GetClassificationWithID(classificationFirst.ClassificationID);
                    Assert.IsType<OkObjectResult>(jsonRet);

                    OkObjectResult Ret = jsonRet as OkObjectResult;
                    Classification classificationRet = (Classification)Ret.Value;
                    Assert.Equal(classificationFirst.ClassificationID, classificationRet.ClassificationID);

                    BadRequestResult badRequest = jsonRet as BadRequestResult;
                    Assert.Null(badRequest);

                    // Post to return newly added Classification
                    classificationRet.ClassificationID = 0;
                    IActionResult jsonRet3 = classificationController.Post(classificationRet, LanguageRequest.ToString());
                    Assert.IsType<CreatedResult>(jsonRet3);

                    CreatedResult ret3 = jsonRet3 as CreatedResult;
                    Assert.IsType<CreatedResult>(ret3);
                    Classification classification = (Classification)ret3.Value;

                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;
                    Assert.Null(badRequest3);

                    // Delete to return success
                    IActionResult jsonRet2 = classificationController.Delete(classificationRet, LanguageRequest.ToString());
                    Assert.IsType<OkObjectResult>(jsonRet2);

                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;
                    Assert.NotNull(ret2);

                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;
                    Assert.Null(badRequest2);

                    // Delete to return CSSPError because ClassificationID of 0 does not exist
                    classificationRet.ClassificationID = 0;
                    IActionResult jsonRet4 = classificationController.Delete(classificationRet, LanguageRequest.ToString());
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
