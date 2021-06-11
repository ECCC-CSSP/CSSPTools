using CSSPLocalFileInfoServices;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace LocalFileInfoServices.Tests
{
    [Collection("Sequential")]
    public partial class LocalFileInfoServicesTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        #endregion Constructors

        #region Tests
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalFileInfoService_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
            Assert.NotNull(CSSPFilesPath);
            Assert.NotNull(LocalFileInfoService);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalFileInfoService_GetLocalFileInfoList_Good_Test(string culture)
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

            var actionRes = await LocalFileInfoService.GetLocalFileInfoList(DirectoryPath);
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
        public async Task LocalFileInfoService_GetLocalFileInfoList_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int TVItemID = 10000000; // should not exist

            string DirectoryPath = $"{CSSPFilesPath}{TVItemID}\\";

            var actionRes = await LocalFileInfoService.GetLocalFileInfoList(DirectoryPath);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            List<LocalFileInfo> LocalFileInfoList = (List<LocalFileInfo>)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(LocalFileInfoList);
            Assert.True(LocalFileInfoList.Count == 0);
        }
        #endregion Tests

        #region Functions private
        #endregion Functions private
    }
}
