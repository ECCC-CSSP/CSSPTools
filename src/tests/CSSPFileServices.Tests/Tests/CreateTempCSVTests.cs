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
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using ManageServices;
using CSSPLogServices.Models;
using CSSPHelperModels;

namespace CSSPFileServices.Tests
{
    //[Collection("Sequential")]
    public partial class FileServiceTests
    {
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateTempCSV_Good_Test(string culture)
        {
            Assert.True(await CSSPFileServiceSetup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            CSSPLogService.CSSPAppName = "FileServiceTests";
            CSSPLogService.CSSPCommandName = "Testing_CreateTempCSV";

            FileInfo fi = new FileInfo($@"{ config.CSSPTempFilesPath }\\TestingThisWillBeUnique.csv");
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

            var actionRes = await CSSPFileService.CreateTempCSV(tableConvertToCSVModel);
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

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateTempCSV_Unauthorized_Error_Test(string culture)
        {
            Assert.True(await CSSPFileServiceSetup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            CSSPLogService.CSSPAppName = "FileServiceTests";
            CSSPLogService.CSSPCommandName = "Testing_CreateTempCSV_Unauthorized";

            LoggedInService.LoggedInContactInfo = null;

            FileInfo fi = new FileInfo($@"{ config.CSSPTempFilesPath }\\TestingThisWillBeUnique.csv");
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

            var actionRes = await CSSPFileService.CreateTempCSV(tableConvertToCSVModel);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionRes.Result).Value;
            Assert.NotEmpty(errRes.ErrList);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateTempCSV_PathDoesNotExist_Error_Test(string culture)
        {
            Assert.True(await CSSPFileServiceSetup(culture));

            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

            CSSPLogService.CSSPAppName = "FileServiceTests";
            CSSPLogService.CSSPCommandName = "Testing_CreateTempCSV_PathDoesNotExist_Error";

            FileInfo fi = new FileInfo($@"{ config.CSSPTempFilesPath }\\TestingThisWillBeUnique.csv");
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

            config.CSSPTempFilesPath = config.CSSPTempFilesPath.Replace("cssptempfiles", "notexist");

            var actionRes = await CSSPFileService.CreateTempCSV(tableConvertToCSVModel);
            Assert.Equal(400, ((BadRequestObjectResult)actionRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
            Assert.NotEmpty(errRes.ErrList);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
    }
}
