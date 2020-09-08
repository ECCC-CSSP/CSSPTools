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
using LoggedInServices;

namespace CSSPDBServices.Tests
{
    public partial class DBTableDBServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public DBTableDBServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Functions private
        private void CheckDBTableFields(List<DBTable> dBTableList)
        {
            Assert.False(string.IsNullOrWhiteSpace(dBTableList[0].TableName));
            Assert.False(string.IsNullOrWhiteSpace(dBTableList[0].Plurial));
        }

        #endregion Functions private
    }
}
