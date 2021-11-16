//using CSSPDBModels;
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

//namespace WebAppLoadedServices.Tests
//{
//    [Collection("Sequential")]
//    public partial class WebAppLoadedServicesTests
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
//        public async Task WebAppLoadedService_Constructor_Good_Test(string culture)
//        {
//            Assert.True(await Setup(culture));
//            Assert.NotEmpty(FirstName);
//            Assert.NotEmpty(Initial);
//            Assert.NotEmpty(LastName);
//            Assert.NotEmpty(LoginEmail);
//            Assert.NotEmpty(Password);
//            Assert.NotEmpty(CSSPDBPreferenceFileName);
//        }
//        #endregion Tests

//        #region Functions private
//        #endregion Functions private
//    }
//}
