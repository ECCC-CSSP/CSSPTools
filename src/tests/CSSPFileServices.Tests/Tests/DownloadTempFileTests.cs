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
using System.ComponentModel.DataAnnotations;

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
        public async Task FileService_DownloadTempFile_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            FileInfo fi = new FileInfo($@"{ config.CSSPTempFilesPath }\\ThisFileShoulBeUnique743Testing.txt");

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

            File.WriteAllText(fi.FullName, "bonjour");
            
            var actionRes = await FileService.DownloadTempFile(fi.Name);
            Assert.NotNull(((FileStreamResult)actionRes).FileStream);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FileService_DownloadTempFile_Unauthorized_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            FileInfo fi = new FileInfo($@"{ config.CSSPTempFilesPath }\\ThisFileShoulBeUnique743Testing.txt");

            File.WriteAllText(fi.FullName, "bonjour");

            LoggedInService.LoggedInContactInfo = null;

            var actionRes = await FileService.DownloadTempFile(fi.Name);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionRes).StatusCode);
            var ValidationResultList = (List<ValidationResult>)((UnauthorizedObjectResult)actionRes).Value;
            Assert.NotNull(ValidationResultList);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FileService_DownloadTempFile_FileDoesNotExist_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            string FileName = "doesnotexist.css";

            var actionRes = await FileService.DownloadTempFile(FileName);
            Assert.Equal(400, ((BadRequestObjectResult)actionRes).StatusCode);
            var ValidationResultList = (List<ValidationResult>)((BadRequestObjectResult)actionRes).Value;
            Assert.NotNull(ValidationResultList);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        #endregion Tests 

        #region Functions private
        #endregion Functions private
    }
}
