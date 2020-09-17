/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\ServicesClassNameServiceTestGenerated.exe
 *
 * Do not edit this file.
 *
 */

using CSSPEnums;
using CSSPModels;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Xunit;
using System.ComponentModel.DataAnnotations;
using CSSPCultureServices.Resources;
using LocalServices;
using System.Threading;

namespace CSSPDBLocalServices.Tests
{
    public partial class DataPathOfTideDBLocalServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public DataPathOfTideDBLocalServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Functions private
        private void CheckDataPathOfTideFields(List<DataPathOfTide> dataPathOfTideList)
        {
            Assert.False(string.IsNullOrWhiteSpace(dataPathOfTideList[0].Text));
            if (dataPathOfTideList[0].WebTideDataSet != null)
            {
                Assert.NotNull(dataPathOfTideList[0].WebTideDataSet);
            }
            if (!string.IsNullOrWhiteSpace(dataPathOfTideList[0].WebTideDataSetText))
            {
                Assert.False(string.IsNullOrWhiteSpace(dataPathOfTideList[0].WebTideDataSetText));
            }
        }

        #endregion Functions private
    }
}