using CSSPEnums;
using CSSPDBModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using System.Diagnostics;
using System.Reflection;
using ManageServices;
using System.Collections.Generic;
using System.Linq;

namespace CreateGzFileServices.Tests
{
    public partial class CreateGzFileServiceTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        // see under GzFileServices Setup.cs
        #endregion Constructors

        #region Tests
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DeleteGzFileService_WebAllAddresses_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            SetVar(WebTypeEnum.WebAllAddresses);
            var actionRes = await CreateGzFileService.DeleteGzFile(WebTypeEnum.WebAllAddresses);
            CheckVar(actionRes, WebTypeEnum.WebAllAddresses);
        }
        #endregion Functions private
    }
}