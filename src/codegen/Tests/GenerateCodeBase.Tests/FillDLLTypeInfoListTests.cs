using GenerateCodeStatusDB.Models;
using GenerateCodeStatusDB.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GenerateCodeBase.Tests
{
    public partial class Tests
    {
        #region Variables
        #endregion Variables

        #region Constructors
        #endregion Constructors

        #region Functions public
        [Fact]
        public void FillDLLTypeInfoList_Good_Test()
        {
            foreach (string culture in new List<string>() { "en-CA", "fr-CA" })
            {
                Init(new CultureInfo(culture));

                Assert.True(true);

                // to do
            }
        }
        #endregion Functions public

    }
}
