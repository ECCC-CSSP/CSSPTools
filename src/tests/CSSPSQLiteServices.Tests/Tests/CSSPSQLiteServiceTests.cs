using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace CSSPSQLiteServices.Tests
{
    [Collection("Sequential")]
    public partial class CSSPSQLiteServiceTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public CSSPSQLiteServiceTests()
        {

        }
        #endregion Constructors

        #region Tests
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CSSPSQLiteService_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
            Assert.NotNull(CSSPCultureService);
            Assert.NotNull(CSSPSQLiteService);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CSSPSQLiteService_CreateSQLiteCSSPDBLocal_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            if (fiCSSPDBLocal.Exists)
            {
                try
                {
                    fiCSSPDBLocal.Delete();
                }
                catch (Exception ex)
                {
                    Assert.True(false, ex.Message);
                }
            }

            bool retBool = await CSSPSQLiteService.CreateSQLiteCSSPDBLocal();
            Assert.True(retBool);

            fiCSSPDBLocal = new FileInfo(CSSPDBLocal);

            Assert.True(fiCSSPDBLocal.Exists);

            if (fiCSSPDBLocal.Exists)
            {
                try
                {
                    fiCSSPDBLocal.Delete();
                }
                catch (Exception ex)
                {
                    Assert.True(false, ex.Message);
                }
            }

        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CSSPSQLiteService_CreateSQLiteCSSPDBManage_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            if (fiCSSPDBManage.Exists)
            {
                try
                {
                    fiCSSPDBManage.Delete();
                }
                catch (Exception ex)
                {
                    Assert.True(false, ex.Message);
                }
            }

            bool retBool = await CSSPSQLiteService.CreateSQLiteCSSPDBManage();
            Assert.True(retBool);

            fiCSSPDBManage = new FileInfo(CSSPDBManage);

            Assert.True(fiCSSPDBManage.Exists);

            if (fiCSSPDBManage.Exists)
            {
                try
                {
                    fiCSSPDBManage.Delete();
                }
                catch (Exception ex)
                {
                    Assert.True(false, ex.Message);
                }
            }

        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CSSPSQLiteService_CSSPDBLocalIsEmpty_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            try
            {
                fiCSSPDBLocal.Delete();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }

            bool retBool = await CSSPSQLiteService.CreateSQLiteCSSPDBLocal();
            Assert.True(retBool);

            retBool = await CSSPSQLiteService.CSSPDBLocalIsEmpty();
            Assert.True(retBool);

        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CSSPSQLiteService_CSSPDBManageIsEmpty_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            try
            {
                fiCSSPDBManage.Delete();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }

            bool retBool = await CSSPSQLiteService.CreateSQLiteCSSPDBManage();
            Assert.True(retBool);

            retBool = await CSSPSQLiteService.CSSPDBManageIsEmpty();
            Assert.True(retBool);
        }
        #endregion Tests

        #region Functions private
        #endregion Functions private

    }
}
