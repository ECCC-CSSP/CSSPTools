using CSSPEnums;
using CSSPDBModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using System.IO;
using CSSPWebModels;

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
        public async Task CreateTempFile_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
           
            LoggedInService.LoggedInContactInfo = null;

            FileInfo fi = new FileInfo($@"{CSSPTempFilesPath}\\TestingThisWillBeUnique.txt");

            TableConvertToCSVModel tableConvertToCSVModel = new TableConvertToCSVModel();
            tableConvertToCSVModel.CSVString = "a,b,c";
            tableConvertToCSVModel.TableFileName = fi.Name;

            var actionRes = await FileService.CreateTempCSV(tableConvertToCSVModel);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionRes.Result).StatusCode);
        }
        #endregion Tests 

        #region Functions private
        #endregion Functions private
    }
}
