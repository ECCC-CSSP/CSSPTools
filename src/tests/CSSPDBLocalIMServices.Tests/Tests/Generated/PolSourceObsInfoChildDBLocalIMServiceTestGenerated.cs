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

namespace CSSPDBLocalIMServices.Tests
{
    public partial class PolSourceObsInfoChildDBLocalIMServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public PolSourceObsInfoChildDBLocalIMServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Functions private
        private void CheckPolSourceObsInfoChildFields(List<PolSourceObsInfoChild> polSourceObsInfoChildList)
        {
            if (!string.IsNullOrWhiteSpace(polSourceObsInfoChildList[0].PolSourceObsInfoText))
            {
                Assert.False(string.IsNullOrWhiteSpace(polSourceObsInfoChildList[0].PolSourceObsInfoText));
            }
            if (!string.IsNullOrWhiteSpace(polSourceObsInfoChildList[0].PolSourceObsInfoChildStartText))
            {
                Assert.False(string.IsNullOrWhiteSpace(polSourceObsInfoChildList[0].PolSourceObsInfoChildStartText));
            }
        }

        #endregion Functions private
    }
}
