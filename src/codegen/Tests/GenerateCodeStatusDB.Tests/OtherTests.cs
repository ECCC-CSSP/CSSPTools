using GenerateCodeStatusDB.Models;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GenerateCodeStatusDB.Tests
{
    public partial class Tests
    {
        #region Variables
        #endregion Variables

        #region Constructors
        #endregion Constructors

        #region Functions public
        [Fact]
        public void OtherTest_Good_Test()
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
