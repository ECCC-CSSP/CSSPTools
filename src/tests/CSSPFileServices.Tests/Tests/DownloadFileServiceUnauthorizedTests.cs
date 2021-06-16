using CSSPEnums;
using CSSPDBModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace FileServices.Tests
{
    public partial class FileServiceTests
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
        //[InlineData("fr-CA")]
        public async Task LocalizeAzureFile_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
           
            LoggedInService.LoggedInContactInfo = null;

            int ParentTVItemID = 1;
            string FileName = "BarTopBottom.png";

            // Download file
            var actionRes2 = await FileService.LocalizeAzureFile(ParentTVItemID, FileName);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionRes2.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DownloadFile_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            int ParentTVItemID = 1;
            string FileName = "BarTopBottom.png";

            // Download file
            var actionRes2 = await FileService.DownloadFile(ParentTVItemID, FileName);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionRes2).StatusCode);
        }
        #endregion Tests 

        #region Functions private
        #endregion Functions private
    }
}
