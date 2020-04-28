using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EnumsCompareWithOldEnumsServices.Tests
{
    public class StartTests : TestBase
    {
        #region Variables
        #endregion Variables

        #region Constructors
        public StartTests() : base()
        {
        }
        #endregion Constructors

        #region Functions public
        [Fact]
        public async Task Start_Good_Test()
        {
            generateCodeStatusDBService.Error = new System.Text.StringBuilder();

            string[] args = new List<string>() { "a", "b" }.ToArray();

            await enumsCompareWithOldEnumsService.Run(args);

            Assert.Equal("", generateCodeStatusDBService.Error.ToString());
        }
        #endregion Functions public
    }
}
