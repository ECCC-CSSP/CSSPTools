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
        public async Task CSSPDBLocalIsEmpty_Good_Test(string culture)
        {
            Assert.True(await CSSPSQLiteServiceSetup(culture));

            bool retBool = await CSSPSQLiteService.CreateSQLiteCSSPDBLocal();
            Assert.True(retBool);

            retBool = await CSSPSQLiteService.CSSPDBLocalIsEmpty();
            Assert.True(retBool);

        }
    }
}
