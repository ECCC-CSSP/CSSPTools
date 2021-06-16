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
using System.Text;
using CSSPCultureServices.Resources;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace CSSPWebAPIsLocal.CreateFileController.Tests
{
    public partial class CreateFileControllerTests
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
        public async Task CreateFileController_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
            Assert.NotNull(contact);
            Assert.NotNull(FileService);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateFileController_CreateTempCSV_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            FileInfo fi = new FileInfo($@"{CSSPTempFilesPath}\\TestingThisWillBeUnique.txt");
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
            tableConvertToCSVModel.TableFileName = "TestingThisWillBeUnique.txt";

            using (HttpClient httpClient = new HttpClient())
            {
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                httpClient.DefaultRequestHeaders.Accept.Add(contentType);

                string stringData = JsonSerializer.Serialize(tableConvertToCSVModel);
                var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = httpClient.PostAsync($"{ LocalUrl }api/{ culture }/CreateFile/CreateTempCSV/", contentData).Result;
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }

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
        public async Task CreateFileController_CreateTempPNG_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.True(true);
        }
        #endregion Tests

        #region FunctionPrivate
        #endregion Functions private
    }
}
