/*
 * manually edited
 *
 */

using CSSPEnums;
using CSSPDBModels;
using CSSPCultureServices.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using CSSPWebAPIsLocal.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using System.Collections.Generic;
using System.Text.Json;
using CSSPWebModels;
using System.Linq;
using CSSPHelperModels;

namespace CSSPWebAPIsLocal.LocalFileInfoController.Tests
{
    public partial class CSSPWebAPIsLocalLocalFileInfoControllerTests
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
        public async Task LocalFileInfoController_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
            Assert.NotEmpty(LocalUrl);
            Assert.NotEmpty(CSSPFilesPath);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalFileInfoController_GetLocalFileInfoList_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int ParentTVItemID = 1;

            string DirectoryPath = $"{CSSPFilesPath}{ParentTVItemID}\\";

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

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/LocalFileInfo/GetLocalFileInfoList/{ParentTVItemID}";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                List<LocalFileInfo> LocalFileInfoList = JsonSerializer.Deserialize<List<LocalFileInfo>>(responseContent);
                Assert.True(LocalFileInfoList.Count > 0);
                Assert.True(LocalFileInfoList.Where(c => c.FileName == FileName).Any());
            }

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
        public async Task LocalFileInfoController_GetLocalFileInfoList_For_Municipality_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int ParentTVItemID = 27764;

            string DirectoryPath = $"{CSSPFilesPath}{ParentTVItemID}\\";

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

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/LocalFileInfo/GetLocalFileInfoList/{ParentTVItemID}";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                List<LocalFileInfo> LocalFileInfoList = JsonSerializer.Deserialize<List<LocalFileInfo>>(responseContent);
                Assert.True(LocalFileInfoList.Count > 0);
                Assert.True(LocalFileInfoList.Where(c => c.FileName == FileName).Any());
            }

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
        public async Task LocalFileInfoController_GetLocalFileInfoList_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int TVItemID = 1000000;

            using (HttpClient httpClient = new HttpClient())
            {
                string url = $"{ LocalUrl }api/{ culture }/LocalFileInfo/GetLocalFileInfoList/{TVItemID}";
                var response = await httpClient.GetAsync(url);
                Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
                string responseContent = await response.Content.ReadAsStringAsync();
                ErrRes errRes = JsonSerializer.Deserialize<ErrRes>(responseContent);
                Assert.NotNull(errRes);
                Assert.True(errRes.ErrList.Count > 0);
            }
        }
        #endregion Tests

        #region FunctionPrivate
        #endregion Functions private
    }
}
