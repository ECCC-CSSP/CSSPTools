using CSSPModels;
using CSSPCultureServices.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using CSSPCultureServices.Resources;

namespace PreferenceServices.Tests
{
    [Collection("Sequential")]
    public partial class PreferenceServicesTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        #endregion Constructors

        #region Tests
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task PreferenceService_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
            Assert.NotNull(CSSPCultureService);
            Assert.NotNull(PreferenceService);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task PreferenceService_All_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Preference preference = new Preference()
            {
                VariableName = "TestingVariableName",
                VariableValue = "TestingVariableValue",
            };

            // testing Post
            var actionPreferencePost = await PreferenceService.Post(preference);
            Assert.Equal(200, ((ObjectResult)actionPreferencePost.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPreferencePost.Result).Value);
            Preference preferenceNewPost = (Preference)((OkObjectResult)actionPreferencePost.Result).Value;
            Assert.NotNull(preferenceNewPost);
            Assert.Equal(preference.VariableName, preferenceNewPost.VariableName);
            Assert.Equal(preference.VariableValue, preferenceNewPost.VariableValue);

            // testing Put
            preferenceNewPost.VariableValue = "NewVariableValue";
            var actionPreferencePut = await PreferenceService.Put(preferenceNewPost);
            Assert.Equal(200, ((ObjectResult)actionPreferencePut.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPreferencePut.Result).Value);
            Preference preferenceNewPut = (Preference)((OkObjectResult)actionPreferencePut.Result).Value;
            Assert.NotNull(preferenceNewPut);
            Assert.Equal(preferenceNewPost.VariableName, preferenceNewPut.VariableName);
            Assert.Equal(preferenceNewPost.VariableValue, preferenceNewPut.VariableValue);

            // testing GetPreferenceWithPreferenceID
            var actionPreferenceGetWithID = await PreferenceService.GetPreferenceWithPreferenceID(preferenceNewPut.PreferenceID);
            Assert.Equal(200, ((ObjectResult)actionPreferenceGetWithID.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPreferenceGetWithID.Result).Value);
            Preference preferenceNewGetWithID = (Preference)((OkObjectResult)actionPreferenceGetWithID.Result).Value;
            Assert.Equal(preferenceNewPut.VariableName, preferenceNewGetWithID.VariableName);
            Assert.Equal(preferenceNewPut.VariableValue, preferenceNewGetWithID.VariableValue);

            // testing GetPreferenceWithWithVariableName
            var actionPreferenceWithVariableName = await PreferenceService.GetPreferenceWithVariableName(preferenceNewGetWithID.VariableName);
            Assert.Equal(200, ((ObjectResult)actionPreferenceWithVariableName.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPreferenceWithVariableName.Result).Value);
            Preference preferenceNewGetPreferenceWithVariableName = (Preference)((OkObjectResult)actionPreferenceWithVariableName.Result).Value;
            Assert.Equal(preferenceNewGetWithID.VariableName, preferenceNewGetPreferenceWithVariableName.VariableName);
            Assert.Equal(preferenceNewGetWithID.VariableValue, preferenceNewGetPreferenceWithVariableName.VariableValue);

            // testing AddOrChange
            var actionAddOrChange = await PreferenceService.AddOrChange(preferenceNewGetPreferenceWithVariableName.VariableName, preferenceNewGetPreferenceWithVariableName.VariableValue + "a");
            Assert.Equal(200, ((ObjectResult)actionAddOrChange.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionAddOrChange.Result).Value);
            Preference preferenceAddOrChange = (Preference)((OkObjectResult)actionAddOrChange.Result).Value;
            Assert.Equal(preferenceNewGetPreferenceWithVariableName.VariableName, preferenceAddOrChange.VariableName);
            Assert.Equal(preferenceNewGetPreferenceWithVariableName.VariableValue + "a", preferenceAddOrChange.VariableValue);

            // testing GetCSSPFileList
            var actionPreferenceGetPreferenceList = await PreferenceService.GetPreferenceList();
            Assert.Equal(200, ((ObjectResult)actionPreferenceGetPreferenceList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPreferenceGetPreferenceList.Result).Value);
            List<Preference> PreferenceGetPreferenceList = (List<Preference>)((OkObjectResult)actionPreferenceGetPreferenceList.Result).Value;
            Assert.True(PreferenceGetPreferenceList.Count > 0);

            // testing Delete
            var actionDelete = await PreferenceService.Delete(preferenceNewPost.PreferenceID);
            Assert.Equal(200, ((ObjectResult)actionDelete.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionDelete.Result).Value);
            bool DeleteRet = (bool)((OkObjectResult)actionDelete.Result).Value;
            Assert.True(DeleteRet);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task PreferenceService_GetPreferenceWithPreferenceID_BadRequest_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int PreferenceID = 0;

            var actionPreference = await PreferenceService.GetPreferenceWithPreferenceID(PreferenceID);
            Assert.Equal(400, ((BadRequestObjectResult)actionPreference.Result).StatusCode);
            Assert.Equal(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "Preference", "PreferenceID", PreferenceID.ToString()),
                ((BadRequestObjectResult)actionPreference.Result).Value);

        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task PreferenceService_GetPreferenceWithVariableName_BadRequest_Test(string culture)
        {
            Assert.True(await Setup(culture));

            string VariableName = "WillNotFind";

            var actionPreference = await PreferenceService.GetPreferenceWithVariableName(VariableName);
            Assert.Equal(400, ((BadRequestObjectResult)actionPreference.Result).StatusCode);
            Assert.Equal(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "Preference", "VariableName", $"{ VariableName }"),
                ((BadRequestObjectResult)actionPreference.Result).Value);
        }
        #endregion Tests

        #region Functions private
        #endregion Functions private
    }
}
