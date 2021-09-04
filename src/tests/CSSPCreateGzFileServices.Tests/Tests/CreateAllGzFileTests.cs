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
        [Theory(Skip = "Skip as it takes a long time. Still wants a marker however")]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateAllGzFile_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            // commented out because it takes a long time to excecute
            // remove comment if you want to manually test it

            //SetVar(WebTypeEnum.WebAllAddresses);
            //var actionRes = await CreateGzFileService.CreateAllGzFiles();
            //CheckVar(actionRes, WebTypeEnum.WebAllAddresses);
        }
        #endregion Tests 

        #region Functions private

        #endregion Functions private
    }
}
