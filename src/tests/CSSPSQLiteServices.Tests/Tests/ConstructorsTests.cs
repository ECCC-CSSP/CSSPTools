using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace CSSPSQLiteServices.Tests
{
    public partial class CSSPSQLiteServiceTests
    {
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Constructor_Good_Test(string culture)
        {
            Assert.True(await CSSPSQLiteServiceSetup(culture));
            Assert.NotNull(CSSPCultureService);
            Assert.NotNull(CSSPSQLiteService);
        }
    }
}
