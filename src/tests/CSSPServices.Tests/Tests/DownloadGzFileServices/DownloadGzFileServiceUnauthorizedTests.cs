using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Xunit;

namespace CSSPServices.Tests
{
    public partial class DownloadGzFileServiceTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        // see Helpers.cs
        #endregion Constructors

        #region Tests 
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task DownloadGzFiles_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

            Assert.False(await DownloadGzFileService.DownloadGzFile("WebRoot.Gz"));
        }
        #endregion Tests 

        #region Functions private
        #endregion Functions private
    }
}
