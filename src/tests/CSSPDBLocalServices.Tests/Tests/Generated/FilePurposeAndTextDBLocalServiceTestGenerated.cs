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

namespace CSSPDBLocalServices.Tests
{
    public partial class FilePurposeAndTextDBLocalServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public FilePurposeAndTextDBLocalServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Functions private
        private void CheckFilePurposeAndTextFields(List<FilePurposeAndText> filePurposeAndTextList)
        {
            if (!string.IsNullOrWhiteSpace(filePurposeAndTextList[0].FilePurposeText))
            {
                Assert.False(string.IsNullOrWhiteSpace(filePurposeAndTextList[0].FilePurposeText));
            }
        }

        #endregion Functions private
    }
}
