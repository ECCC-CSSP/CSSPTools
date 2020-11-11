using CSSPEnums;
using CSSPDBModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace UploadFileServices.Tests
{
    public partial class UploadFileServiceTests
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
        public async Task UploadFile_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LocalService.LoggedInContactInfo = null;

            int ParentTVItemID = 1;
            string FileName = "BarTopBottom.png";

            // Download file
            var actionRes2 = await UploadFileService.UploadFile(ParentTVItemID, FileName);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionRes2).StatusCode);
        }
        #endregion Tests 

        #region Functions private
        #endregion Functions private
    }
}
