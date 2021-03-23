//using CSSPCultureServices.Services;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using System;
//using System.Collections.Generic;
//using System.Globalization;
//using System.IO;
//using System.Threading.Tasks;
//using Xunit;
//using Microsoft.AspNetCore.Mvc;
//using System.Linq;
//using CSSPCultureServices.Resources;
//using CSSPDBPreferenceModels;
//using CSSPScrambleServices;
//using System.Transactions;
//using System.ComponentModel.DataAnnotations;

//namespace PreferenceServices.Tests
//{
//    [Collection("Sequential")]
//    public partial class PreferenceServicesTests
//    {
//        #region Variables
//        #endregion Variables

//        #region Properties
//        #endregion Properties

//        #region Constructors
//        #endregion Constructors

//        #region Tests
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task PreferenceService_Constructor_Good_Test(string culture)
//        {
//            Assert.True(await Setup(culture));
//            Assert.NotNull(CSSPCultureService);
//            Assert.NotNull(PreferenceService);
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task PreferenceService_All_Good_Test(string culture)
//        {
//            Assert.True(await Setup(culture));

//            List<Preference> preferenceToDeleteList = (from c in dbPreference.Preferences
//                                                       where c.VariableName == "TestingVariableName"
//                                                       select c).ToList();

//            try
//            {
//                dbPreference.Preferences.RemoveRange(preferenceToDeleteList);
//                dbPreference.SaveChanges();
//            }
//            catch (Exception ex)
//            {
//                Assert.True(false, ex.Message);
//            }

//            Preference preference = new Preference()
//            {
//                PreferenceID = 0,
//                VariableName = "TestingVariableName",
//                VariableValue = "TestingVariableValue",
//            };

//            // testing AddOrModify -- Add
//            var actionPreferencePost = await PreferenceService.AddOrModify(preference);
//            Assert.Equal(200, ((ObjectResult)actionPreferencePost.Result).StatusCode);
//            Assert.NotNull(((OkObjectResult)actionPreferencePost.Result).Value);
//            Preference preferenceNewPost = (Preference)((OkObjectResult)actionPreferencePost.Result).Value;
//            Assert.NotNull(preferenceNewPost);
//            Assert.Equal(preference.VariableName, preferenceNewPost.VariableName);

//            // testing AddOrModify -- Modify
//            preferenceNewPost.VariableValue = "NewVariableValue";
//            var actionPreferencePut = await PreferenceService.AddOrModify(preferenceNewPost);
//            Assert.Equal(200, ((ObjectResult)actionPreferencePut.Result).StatusCode);
//            Assert.NotNull(((OkObjectResult)actionPreferencePut.Result).Value);
//            Preference preferenceNewPut = (Preference)((OkObjectResult)actionPreferencePut.Result).Value;
//            Assert.NotNull(preferenceNewPut);
//            Assert.Equal(preferenceNewPost.VariableName, preferenceNewPut.VariableName);

//            // testing GetPreferenceList
//            var actionPreferenceList = await PreferenceService.GetPreferenceList();
//            Assert.Equal(200, ((ObjectResult)actionPreferenceList.Result).StatusCode);
//            Assert.NotNull(((OkObjectResult)actionPreferenceList.Result).Value);
//            List<Preference> preferenceList = (List<Preference>)((OkObjectResult)actionPreferenceList.Result).Value;
//            Assert.True(preferenceList.Where(c => c.VariableName == preferenceNewPut.VariableName).Any());
//            Assert.True(preferenceList.Where(c => c.VariableValue == preferenceNewPut.VariableValue).Any());
//            Assert.False(preferenceList.Where(c => c.VariableValue == preference.VariableValue).Any());

//            // testing Delete
//            var actionDelete = await PreferenceService.Delete(preferenceNewPost.PreferenceID);
//            Assert.Equal(200, ((ObjectResult)actionDelete.Result).StatusCode);
//            Assert.NotNull(((OkObjectResult)actionDelete.Result).Value);
//            bool DeleteRet = (bool)((OkObjectResult)actionDelete.Result).Value;
//            Assert.True(DeleteRet);

//            // testing if Deleted item is removed
//            var actionPreferenceList2 = await PreferenceService.GetPreferenceList();
//            Assert.Equal(200, ((ObjectResult)actionPreferenceList2.Result).StatusCode);
//            Assert.NotNull(((OkObjectResult)actionPreferenceList2.Result).Value);
//            List<Preference> preferenceList2 = (List<Preference>)((OkObjectResult)actionPreferenceList2.Result).Value;
//            Assert.False(preferenceList2.Where(c => c.VariableName == preferenceNewPut.VariableName).Any());

//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task PreferenceService_AddOrModify_Cant_Find_PreferenceID_Error_Test(string culture)
//        {
//            Assert.True(await Setup(culture));

//            List<Preference> preferenceToDeleteList = (from c in dbPreference.Preferences
//                                                       where c.VariableName == "TestingVariableName"
//                                                       select c).ToList();

//            try
//            {
//                dbPreference.Preferences.RemoveRange(preferenceToDeleteList);
//                dbPreference.SaveChanges();
//            }
//            catch (Exception ex)
//            {
//                Assert.True(false, ex.Message);
//            }

//            Preference preference = new Preference()
//            {
//                PreferenceID = 0,
//                VariableName = "TestingVariableName",
//                VariableValue = "TestingVariableValue",
//            };

//            // testing AddOrModify -- Add
//            var actionPreferencePost = await PreferenceService.AddOrModify(preference);
//            Assert.Equal(200, ((ObjectResult)actionPreferencePost.Result).StatusCode);
//            Assert.NotNull(((OkObjectResult)actionPreferencePost.Result).Value);
//            Preference preferenceNewPost = (Preference)((OkObjectResult)actionPreferencePost.Result).Value;
//            Assert.NotNull(preferenceNewPost);
//            Assert.Equal(preference.VariableName, preferenceNewPost.VariableName);


//            preference.PreferenceID = 11110;
//            string error = string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "Preference", "PreferenceID", preference.PreferenceID.ToString());

//            var actionPreferencePost2 = await PreferenceService.AddOrModify(preference);
//            Assert.Equal(400, ((ObjectResult)actionPreferencePost2.Result).StatusCode);
//            Assert.NotNull(((BadRequestObjectResult)actionPreferencePost2.Result).Value);
//            var ErrorMessage = ((BadRequestObjectResult)actionPreferencePost2.Result).Value;
//            Assert.Equal(error, ErrorMessage);

//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task PreferenceService_AddOrModify_Unauthorized_Test(string culture)
//        {
//            Assert.True(await Setup(culture));

//            LoggedInService.LoggedInContactInfo.LoggedInContact = null;

//            Preference preference = new Preference()
//            {
//                PreferenceID = 0,
//                VariableName = "VariableName",
//                VariableValue = "VariableValue"
//            };

//            var actionPreference = await PreferenceService.AddOrModify(preference);
//            Assert.Equal(401, ((UnauthorizedObjectResult)actionPreference.Result).StatusCode);
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task PreferenceService_AddOrModify_ValidateAndAddOrModify_VariableName_Empty_Error_Test(string culture)
//        {
//            Assert.True(await Setup(culture));

//            Preference preference = new Preference()
//            {
//                PreferenceID = 0,
//                VariableName = "",
//                VariableValue = "VariableValue"
//            };

//            string error = string.Format(CSSPCultureServicesRes._IsRequired, "VariableName");

//            var actionPreference = await PreferenceService.AddOrModify(preference);
//            Assert.Equal(400, ((ObjectResult)actionPreference.Result).StatusCode);
//            Assert.NotNull(((BadRequestObjectResult)actionPreference.Result).Value);
//            var validationResultList = ((BadRequestObjectResult)actionPreference.Result).Value;
//            List<ValidationResult> vrList = ((IEnumerable<ValidationResult>)validationResultList).ToList();
//            Assert.True(vrList.Where(c => c.ErrorMessage.Contains(error)).Any());
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task PreferenceService_AddOrModify_ValidateAndAddOrModify_VariableName_Length_Over_300_Error_Test(string culture)
//        {
//            Assert.True(await Setup(culture));

//            Preference preference = new Preference()
//            {
//                PreferenceID = 0,
//                VariableName = "Variablename Variablename Variablename Variablename " +
//                "Variablename Variablename Variablename Variablename Variablename " +
//                "Variablename Variablename Variablename Variablename Variablename " +
//                "Variablename Variablename Variablename Variablename Variablename " +
//                "Variablename Variablename Variablename Variablename Variablename " +
//                "Variablename Variablename Variablename Variablename Variablename",
//                VariableValue = "VariableValue"
//            };

//            string error = string.Format(CSSPCultureServicesRes._MaxLengthIs_, "VariableName", "300");

//            var actionPreference = await PreferenceService.AddOrModify(preference);
//            Assert.Equal(400, ((ObjectResult)actionPreference.Result).StatusCode);
//            Assert.NotNull(((BadRequestObjectResult)actionPreference.Result).Value);
//            var validationResultList = ((BadRequestObjectResult)actionPreference.Result).Value;
//            List<ValidationResult> vrList = ((IEnumerable<ValidationResult>)validationResultList).ToList();
//            Assert.True(vrList.Where(c => c.ErrorMessage.Contains(error)).Any());
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task PreferenceService_Delete_Unauthorized_Empty_Error_Test(string culture)
//        {
//            Assert.True(await Setup(culture));

//            List<Preference> preferenceToDeleteList = (from c in dbPreference.Preferences
//                                                       where c.VariableName == "TestingVariableName"
//                                                       select c).ToList();

//            try
//            {
//                dbPreference.Preferences.RemoveRange(preferenceToDeleteList);
//                dbPreference.SaveChanges();
//            }
//            catch (Exception ex)
//            {
//                Assert.True(false, ex.Message);
//            }

//            Preference preference = new Preference()
//            {
//                PreferenceID = 0,
//                VariableName = "TestingVariableName",
//                VariableValue = ""
//            };

//            string error = string.Format(CSSPCultureServicesRes._IsRequired, "VariableValue");

//            var actionPreference = await PreferenceService.AddOrModify(preference);
//            Assert.Equal(400, ((ObjectResult)actionPreference.Result).StatusCode);
//            Assert.NotNull(((BadRequestObjectResult)actionPreference.Result).Value);
//            var validationResultList = ((BadRequestObjectResult)actionPreference.Result).Value;
//            List<ValidationResult> vrList = ((IEnumerable<ValidationResult>)validationResultList).ToList();
//            Assert.True(vrList.Where(c => c.ErrorMessage.Contains(error)).Any());
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task PreferenceService_AddOrModify_ValidateAndAddOrModify_VariableValue_Length_Over_300_Error_Test(string culture)
//        {
//            Assert.True(await Setup(culture));

//            List<Preference> preferenceToDeleteList = (from c in dbPreference.Preferences
//                                                       where c.VariableName == "TestingVariableName"
//                                                       select c).ToList();

//            try
//            {
//                dbPreference.Preferences.RemoveRange(preferenceToDeleteList);
//                dbPreference.SaveChanges();
//            }
//            catch (Exception ex)
//            {
//                Assert.True(false, ex.Message);
//            }

//            Preference preference = new Preference()
//            {
//                PreferenceID = 0,
//                VariableName = "TestingVariableName",
//                VariableValue = "VariableValue VariableValue VariableValue VariableValue" +
//                " VariableValue VariableValue VariableValue VariableValue VariableValue " +
//                "VariableValue VariableValue VariableValue VariableValue VariableValue " +
//                "VariableValue VariableValue VariableValue VariableValue VariableValue " +
//                "VariableValue VariableValue VariableValue VariableValue VariableValue " +
//                "VariableValue VariableValue VariableValue VariableValue VariableValue",
//            };

//            string error = string.Format(CSSPCultureServicesRes._MaxLengthIs_, "VariableValue", "300");

//            var actionPreference = await PreferenceService.AddOrModify(preference);
//            Assert.Equal(400, ((ObjectResult)actionPreference.Result).StatusCode);
//            Assert.NotNull(((BadRequestObjectResult)actionPreference.Result).Value);
//            var validationResultList = ((BadRequestObjectResult)actionPreference.Result).Value;
//            List<ValidationResult> vrList = ((IEnumerable<ValidationResult>)validationResultList).ToList();
//            Assert.True(vrList.Where(c => c.ErrorMessage.Contains(error)).Any());
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task PreferenceService_AddOrModify_ValidateAndAddOrModify_VariableName_Should_Not_Already_Exist_When_Adding_Error_Test(string culture)
//        {
//            Assert.True(await Setup(culture));

//            List<Preference> preferenceToDeleteList = (from c in dbPreference.Preferences
//                                                       where c.VariableName == "TestingVariableName"
//                                                       select c).ToList();

//            try
//            {
//                dbPreference.Preferences.RemoveRange(preferenceToDeleteList);
//                dbPreference.SaveChanges();
//            }
//            catch (Exception ex)
//            {
//                Assert.True(false, ex.Message);
//            }

//            Preference preference = new Preference()
//            {
//                PreferenceID = 0,
//                VariableName = "TestingVariableName",
//                VariableValue = "TestingVariableValue",
//            };

//            // testing AddOrModify -- Add
//            var actionPreferencePost = await PreferenceService.AddOrModify(preference);
//            Assert.Equal(200, ((ObjectResult)actionPreferencePost.Result).StatusCode);
//            Assert.NotNull(((OkObjectResult)actionPreferencePost.Result).Value);
//            Preference preferenceNewPost = (Preference)((OkObjectResult)actionPreferencePost.Result).Value;
//            Assert.NotNull(preferenceNewPost);
//            Assert.Equal(preference.VariableName, preferenceNewPost.VariableName);
//            Assert.Equal(ScrambleService.Descramble(preference.VariableValue), preferenceNewPost.VariableValue);

//            string error = string.Format(CSSPCultureServicesRes._AlreadyExists, "Preference");

//            preference.PreferenceID = 0;
//            var actionPreference = await PreferenceService.AddOrModify(preference);
//            Assert.Equal(400, ((ObjectResult)actionPreference.Result).StatusCode);
//            Assert.NotNull(((BadRequestObjectResult)actionPreference.Result).Value);
//            var validationResultList = ((BadRequestObjectResult)actionPreference.Result).Value;
//            List<ValidationResult> vrList = ((IEnumerable<ValidationResult>)validationResultList).ToList();
//            Assert.True(vrList.Where(c => c.ErrorMessage.Contains(error)).Any());
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task PreferenceService_AddOrModify_ValidateAndAddOrModify_VariableName_Could_Not_Find_VariableName_Error_Test(string culture)
//        {
//            Assert.True(await Setup(culture));

//            List<Preference> preferenceToDeleteList = (from c in dbPreference.Preferences
//                                                       where c.VariableName == "TestingVariableName"
//                                                       select c).ToList();

//            try
//            {
//                dbPreference.Preferences.RemoveRange(preferenceToDeleteList);
//                dbPreference.SaveChanges();
//            }
//            catch (Exception ex)
//            {
//                Assert.True(false, ex.Message);
//            }

//            Preference preference = new Preference()
//            {
//                PreferenceID = 0,
//                VariableName = "TestingVariableName",
//                VariableValue = "TestingVariableValue",
//            };

//            // testing AddOrModify -- Add
//            var actionPreferencePost = await PreferenceService.AddOrModify(preference);
//            Assert.Equal(200, ((ObjectResult)actionPreferencePost.Result).StatusCode);
//            Assert.NotNull(((OkObjectResult)actionPreferencePost.Result).Value);
//            Preference preferenceNewPost = (Preference)((OkObjectResult)actionPreferencePost.Result).Value;
//            Assert.NotNull(preferenceNewPost);
//            Assert.Equal(preference.VariableName, preferenceNewPost.VariableName);
//            Assert.Equal(ScrambleService.Descramble(preference.VariableValue), preferenceNewPost.VariableValue);


//            preferenceNewPost.VariableName = "TestingVariableName_notExist";
//            string error = string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "Preference", "VariableName", preferenceNewPost.VariableName);

//            var actionPreference = await PreferenceService.AddOrModify(preferenceNewPost);
//            Assert.Equal(400, ((ObjectResult)actionPreference.Result).StatusCode);
//            Assert.NotNull(((BadRequestObjectResult)actionPreference.Result).Value);
//            var validationResultList = ((BadRequestObjectResult)actionPreference.Result).Value;
//            List<ValidationResult> vrList = ((IEnumerable<ValidationResult>)validationResultList).ToList();
//            Assert.True(vrList.Where(c => c.ErrorMessage.Contains(error)).Any());
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task PreferenceService_Delete_Unauthorization_Error_Test(string culture)
//        {
//            Assert.True(await Setup(culture));

//            List<Preference> preferenceToDeleteList = (from c in dbPreference.Preferences
//                                                       where c.VariableName == "TestingVariableName"
//                                                       select c).ToList();

//            try
//            {
//                dbPreference.Preferences.RemoveRange(preferenceToDeleteList);
//                dbPreference.SaveChanges();
//            }
//            catch (Exception ex)
//            {
//                Assert.True(false, ex.Message);
//            }

//            Preference preference = new Preference()
//            {
//                PreferenceID = 0,
//                VariableName = "TestingVariableName",
//                VariableValue = "TestingVariableValue",
//            };

//            // testing AddOrModify -- Add
//            var actionPreferencePost = await PreferenceService.AddOrModify(preference);
//            Assert.Equal(200, ((ObjectResult)actionPreferencePost.Result).StatusCode);
//            Assert.NotNull(((OkObjectResult)actionPreferencePost.Result).Value);
//            Preference preferenceNewPost = (Preference)((OkObjectResult)actionPreferencePost.Result).Value;
//            Assert.NotNull(preferenceNewPost);
//            Assert.Equal(preference.VariableName, preferenceNewPost.VariableName);
//            Assert.Equal(ScrambleService.Descramble(preference.VariableValue), preferenceNewPost.VariableValue);

//            LoggedInService.LoggedInContactInfo.LoggedInContact = null;

//            var actionPreference = await PreferenceService.Delete(preferenceNewPost.PreferenceID);
//            Assert.Equal(401, ((UnauthorizedObjectResult)actionPreference.Result).StatusCode);

//            await LoggedInService.SetLoggedInLocalContactInfo();

//            actionPreference = await PreferenceService.Delete(preferenceNewPost.PreferenceID);
//            Assert.Equal(200, ((ObjectResult)actionPreferencePost.Result).StatusCode);
//            Assert.NotNull(((OkObjectResult)actionPreferencePost.Result).Value);
//        }

//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task PreferenceService_Delete_Could_Not_Find_Error_Test(string culture)
//        {
//            Assert.True(await Setup(culture));

//            List<Preference> preferenceToDeleteList = (from c in dbPreference.Preferences
//                                                       where c.VariableName == "TestingVariableName"
//                                                       select c).ToList();

//            try
//            {
//                dbPreference.Preferences.RemoveRange(preferenceToDeleteList);
//                dbPreference.SaveChanges();
//            }
//            catch (Exception ex)
//            {
//                Assert.True(false, ex.Message);
//            }

//            int PreferenceIDNotExist = 0;
//            string error = string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "Preference", "PreferenceID", PreferenceIDNotExist.ToString());

//            var actionPreference = await PreferenceService.Delete(PreferenceIDNotExist);
//            Assert.Equal(400, ((BadRequestObjectResult)actionPreference.Result).StatusCode);
//            var BadRequestText = ((BadRequestObjectResult)actionPreference.Result).Value;
//            Assert.Equal(error, BadRequestText);
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task PreferenceService_Delete_DbUpdateException_Error_Test(string culture)
//        {
//            Assert.True(await Setup(culture));

//            List<Preference> preferenceToDeleteList = (from c in dbPreference.Preferences
//                                                       where c.VariableName == "TestingVariableName"
//                                                       select c).ToList();

//            try
//            {
//                dbPreference.Preferences.RemoveRange(preferenceToDeleteList);
//                dbPreference.SaveChanges();
//            }
//            catch (Exception ex)
//            {
//                Assert.True(false, ex.Message);
//            }

//            Preference preference = new Preference()
//            {
//                PreferenceID = 0,
//                VariableName = "TestingVariableName",
//                VariableValue = "TestingVariableValue",
//            };

//            // testing AddOrModify -- Add
//            var actionPreferencePost = await PreferenceService.AddOrModify(preference);
//            Assert.Equal(200, ((ObjectResult)actionPreferencePost.Result).StatusCode);
//            Assert.NotNull(((OkObjectResult)actionPreferencePost.Result).Value);
//            Preference preferenceNewPost = (Preference)((OkObjectResult)actionPreferencePost.Result).Value;
//            Assert.NotNull(preferenceNewPost);
//            Assert.Equal(preference.VariableName, preferenceNewPost.VariableName);

//            // -----------
//            // don't know how to test the catch (DbUpdateException ex)
//            // -----------
//            //await Assert.ThrowsAsync<DbUpdateException>(async () => await PreferenceService.Delete(preferenceNewPost.PreferenceID));


//            var actionPreference = await PreferenceService.Delete(preferenceNewPost.PreferenceID);
//            Assert.Equal(200, ((ObjectResult)actionPreferencePost.Result).StatusCode);
//            Assert.NotNull(((OkObjectResult)actionPreferencePost.Result).Value);
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task PreferenceService_GetPreferenceList_Good_Test(string culture)
//        {
//            Assert.True(await Setup(culture));


//            // testing AddOrModify -- Add
//            var actionPreferenceGet = await PreferenceService.GetPreferenceList();
//            Assert.Equal(200, ((ObjectResult)actionPreferenceGet.Result).StatusCode);
//            Assert.NotNull(((OkObjectResult)actionPreferenceGet.Result).Value);
//            List<Preference> preferenceGetList = (List<Preference>)((OkObjectResult)actionPreferenceGet.Result).Value;
//            Assert.True(preferenceGetList.Count > 0);
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task PreferenceService_GetPreferenceList_Unauthorized_Error_Test(string culture)
//        {
//            Assert.True(await Setup(culture));

//            LoggedInService.LoggedInContactInfo.LoggedInContact = null;

//            // testing AddOrModify -- Add
//            var actionPreferenceGet = await PreferenceService.GetPreferenceList();
//            Assert.Equal(401, ((UnauthorizedObjectResult)actionPreferenceGet.Result).StatusCode);
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task PreferenceService_GetPreferenceList_Descramble_Good_Test(string culture)
//        {
//            Assert.True(await Setup(culture));

//            List<Preference> preferenceToDeleteList = (from c in dbPreference.Preferences
//                                                       where c.VariableName == "TestingVariableName"
//                                                       select c).ToList();

//            try
//            {
//                dbPreference.Preferences.RemoveRange(preferenceToDeleteList);
//                dbPreference.SaveChanges();
//            }
//            catch (Exception ex)
//            {
//                Assert.True(false, ex.Message);
//            }

//            string val = "TestingVariableValue";
//            Preference preference = new Preference()
//            {
//                PreferenceID = 0,
//                VariableName = "TestingVariableName",
//                VariableValue = val,
//            };

//            // testing AddOrModify -- Add
//            var actionPreferencePost = await PreferenceService.AddOrModify(preference);
//            Assert.Equal(200, ((ObjectResult)actionPreferencePost.Result).StatusCode);
//            Assert.NotNull(((OkObjectResult)actionPreferencePost.Result).Value);
//            Preference preferenceNewPost = (Preference)((OkObjectResult)actionPreferencePost.Result).Value;
//            Assert.NotNull(preferenceNewPost);
//            Assert.Equal(preference.VariableName, preferenceNewPost.VariableName);

//            var actionPreferenceGet = await PreferenceService.GetPreferenceList();
//            Assert.Equal(200, ((ObjectResult)actionPreferenceGet.Result).StatusCode);
//            Assert.NotNull(((OkObjectResult)actionPreferenceGet.Result).Value);
//            List<Preference> preferenceGetList = (List<Preference>)((OkObjectResult)actionPreferenceGet.Result).Value;
//            Assert.True(preferenceGetList.Count > 0);
//            Preference preferenceRet = preferenceGetList.Where(c => c.VariableName == preference.VariableName).FirstOrDefault();
//            Assert.NotNull(preferenceRet);
//            Assert.Equal(val, preferenceRet.VariableValue);
//        }
//        #endregion Tests

//        #region Functions private
//        #endregion Functions private
//    }
//}
