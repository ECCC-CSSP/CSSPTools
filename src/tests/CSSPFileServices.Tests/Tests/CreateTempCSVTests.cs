using CSSPEnums;
using CSSPDBModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using System.Collections.Generic;
using CSSPWebModels;

namespace FileServices.Tests
{
    //[Collection("Sequential")]
    public partial class FileServiceTests
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
        public async Task FileService_CreateTempCSV_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            FileInfo fi = new FileInfo($@"{CSSPTempFilesPath}\\TestingThisWillBeUnique.csv");
            if (fi.Exists)
            {
                try
                {
                    fi.Delete();
                }
                catch (Exception ex)
                {
                    Assert.True(false, ex.Message);
                }
            }

            TableConvertToCSVModel tableConvertToCSVModel = new TableConvertToCSVModel();
            tableConvertToCSVModel.CSVString = "a,b,c";
            tableConvertToCSVModel.TableFileName = fi.Name;

            var actionRes = await FileService.CreateTempCSV(tableConvertToCSVModel);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);

            fi = new FileInfo(fi.FullName);
            Assert.True(fi.Exists);

            if (fi.Exists)
            {
                try
                {
                    fi.Delete();
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
        public async Task FileService_CreateTempCSV_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            FileInfo fi = new FileInfo($@"{CSSPTempFilesPath}\\TestingThisWillBeUnique.csv");
            if (fi.Exists)
            {
                try
                {
                    fi.Delete();
                }
                catch (Exception ex)
                {
                    Assert.True(false, ex.Message);
                }
            }

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
