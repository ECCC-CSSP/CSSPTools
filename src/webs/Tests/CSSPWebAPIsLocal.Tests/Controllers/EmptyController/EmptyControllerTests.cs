/*
 * manually edited
 *
 */

using CSSPEnums;
using CSSPModels;
using CSSPCultureServices.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using CSSPWebAPIsLocal.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using System.Collections.Generic;
using System.Text.Json;

namespace EmptyControllers.Tests
{
    public partial class EmptyControllerTests
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
        public async Task SearchController_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.NotNull(CSSPCultureService);
        }
        #endregion Tests

        #region FunctionPrivate
        #endregion Functions private
    }
}
