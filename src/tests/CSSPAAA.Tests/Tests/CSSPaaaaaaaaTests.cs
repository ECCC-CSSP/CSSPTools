using System.Threading.Tasks;
using Xunit;

namespace CSSPAAA.Tests
{
    public partial class CreateGzFileServiceTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        // see under GzFileServices Setup.cs
        #endregion Constructors

        #region Tests
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CSSPAAA_Good_Test(string culture)
        {
            string cult = culture;
            Assert.True(await Task.FromResult(true));
        }
        #endregion Tests 

        #region Functions private
        #endregion Functions private
    }
}
