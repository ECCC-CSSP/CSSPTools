﻿//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Threading.Tasks;
//using CSSPCultureServices.Services;
//using CSSPDesktopServices.Models;
//using CSSPDesktopServices.Services;
//using CSSPEnums;
//using CSSPDBModels;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Xunit;
//using CSSPHelperModels;

//namespace CSSPDesktopServices.Tests
//{
//    public partial class CSSPDesktopServiceTests
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
//        public async Task CSSPDesktopService_Register_Good_Test(string culture)
//        {
//            Assert.True(await Setup(culture));

//            RegisterModel registerModel = new RegisterModel()
//            {
//                LoginEmail = "AlAlAl.BlBlBl@somthing.ca",
//                FirstName = "AlAlAl",
//                LastName = "BlBlBl",
//                Initial = "T",
//                Password = Configuration.GetValue<string>("Password"),
//                ConfirmPassword = Configuration.GetValue<string>("Password"),
//            };

//            bool retBool = await CSSPDesktopService.Register(registerModel);
//            Assert.True(retBool);
//        }
//        #endregion Tests

//        #region Functions private
//        #endregion Functions private
//    }
//}
