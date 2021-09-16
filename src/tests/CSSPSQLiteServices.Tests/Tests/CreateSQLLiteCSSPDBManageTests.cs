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
        public async Task CreateSQLiteCSSPDBManage_Good_Test(string culture)
        {
            Assert.True(await CSSPSQLiteServiceSetup(culture));

            bool retBool = await CSSPSQLiteService.CreateSQLiteCSSPDBManage();
            Assert.True(retBool);

            FileInfo fi = new FileInfo(config.CSSPDBManage);
            Assert.True(fi.Exists);
        }
    }
}
