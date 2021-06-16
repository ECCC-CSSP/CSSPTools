using CSSPEnums;
using CSSPDBModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using CSSPWebModels;
using System.Collections.Generic;

namespace FileServices.Tests
{
    [Collection("Sequential")]
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
        public async Task FileService_LocalizeAzureFile_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int ParentTVItemID = 1;
            string FileName = "BarTopBottom.png";

            // Download file
            var actionRes2 = await FileService.LocalizeAzureFile(ParentTVItemID, FileName);
            Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes2.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FileService_DownloadFile_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int ParentTVItemID = 1;
            string FileName = "BarTopBottom.png";

            FileInfo fi = new FileInfo($"{ CSSPFilesPath }{ParentTVItemID}\\{FileName}");

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

            var actionRes2 = await FileService.DownloadFile(ParentTVItemID, FileName);
            Assert.NotNull(((FileStreamResult)actionRes2).FileStream);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalFileService_GetLocalFileInfoList_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int TVItemID = 1; // this is under root

            string DirectoryPath = $"{CSSPFilesPath}{TVItemID}\\";

            DirectoryInfo di = new DirectoryInfo(DirectoryPath);

            if (!di.Exists)
            {
                try
                {
                    di.Create();
                }
                catch (Exception ex)
                {
                    Assert.True(false, ex.Message);
                }
            }

            string FileName = "ThisFileShouldNotExis.txt";
            FileInfo fi = new FileInfo($"{DirectoryPath}{FileName}");

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

            StreamWriter sw = fi.CreateText();
            sw.WriteLine("bonjour");
            sw.Close();

            var actionRes = await FileService.GetLocalFileInfoList(DirectoryPath);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            List<LocalFileInfo> LocalFileInfoList = (List<LocalFileInfo>)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(LocalFileInfoList);
            Assert.True(LocalFileInfoList.Where(c => c.FileName == FileName).Any());

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
        public async Task LocalFileService_GetLocalFileInfoList_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int TVItemID = 10000000; // should not exist

            string DirectoryPath = $"{CSSPFilesPath}{TVItemID}\\";

            var actionRes = await FileService.GetLocalFileInfoList(DirectoryPath);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            List<LocalFileInfo> LocalFileInfoList = (List<LocalFileInfo>)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(LocalFileInfoList);
            Assert.True(LocalFileInfoList.Count == 0);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalFileService_GetLocalFileInfo_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int TVItemID = 1; // this is under root

            string DirectoryPath = $"{CSSPFilesPath}{TVItemID}\\";

            DirectoryInfo di = new DirectoryInfo(DirectoryPath);

            if (!di.Exists)
            {
                try
                {
                    di.Create();
                }
                catch (Exception ex)
                {
                    Assert.True(false, ex.Message);
                }
            }

            string FileName = "ThisFileShouldNotExis.txt";
            FileInfo fi = new FileInfo($"{DirectoryPath}{FileName}");

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

            StreamWriter sw = fi.CreateText();
            sw.WriteLine("bonjour");
            sw.Close();

            var actionRes = await FileService.GetLocalFileInfo(DirectoryPath, fi.Name);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            LocalFileInfo localFileInfo = (LocalFileInfo)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(localFileInfo);
            Assert.Equal(fi.Name, localFileInfo.FileName);
            Assert.True(localFileInfo.Length > 0);

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
        public async Task LocalFileService_GetLocalFileInfo_DirectoryPath_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int TVItemID = 10000000; // should not exist

            string DirectoryPath = $"{CSSPFilesPath}{TVItemID}\\";

            var actionRes = await FileService.GetLocalFileInfo(DirectoryPath, "ShouldNotExist.txt");
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            LocalFileInfo localFileInfo = (LocalFileInfo)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(localFileInfo);
            Assert.Equal("", localFileInfo.FileName);
            Assert.Equal(0, localFileInfo.Length);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalFileService_GetLocalFileInfo_FileName_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int TVItemID = 1; // this is under root

            string DirectoryPath = $"{CSSPFilesPath}{TVItemID}\\";

            DirectoryInfo di = new DirectoryInfo(DirectoryPath);

            if (!di.Exists)
            {
                try
                {
                    di.Create();
                }
                catch (Exception ex)
                {
                    Assert.True(false, ex.Message);
                }
            }

            string FileName = "ThisFileShouldNotExis.txt";
            FileInfo fi = new FileInfo($"{DirectoryPath}{FileName}");

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

            StreamWriter sw = fi.CreateText();
            sw.WriteLine("bonjour");
            sw.Close();

            var actionRes = await FileService.GetLocalFileInfo(DirectoryPath, $"NotExist{ fi.Name }");
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            LocalFileInfo localFileInfo = (LocalFileInfo)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(localFileInfo);
            Assert.Equal("", localFileInfo.FileName);
            Assert.Equal(0, localFileInfo.Length);

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
        #endregion Tests 

        #region Functions private
        #endregion Functions private
    }
}
