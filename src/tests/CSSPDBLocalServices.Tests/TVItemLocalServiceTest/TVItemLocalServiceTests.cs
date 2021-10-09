/* 
 *  Manually Edited
 *  
 */

using CSSPCultureServices.Resources;
using CSSPDBModels;
using CSSPEnums;
using CSSPHelperModels;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CSSPDBLocalServices.Tests
{
    public partial class TVItemLocalServiceTest
    {
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Constructor_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_Address_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(1, WebTypeEnum.WebRoot, TVTypeEnum.Address, TVTypeEnum.Root);

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            var boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            List<ToRecreate> toRecreateList = await TVItemLocalService.GetToRecreateList();
            Assert.NotNull(toRecreateList);
            Assert.NotEmpty(toRecreateList);
            Assert.Single(toRecreateList);
            Assert.Equal(0, toRecreateList[0].TVItemID);
            Assert.Equal(WebTypeEnum.WebAllAddresses, toRecreateList[0].WebType);

            DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
            Assert.True(di.Exists);
            List<FileInfo> fiList = di.GetFiles().ToList();
            Assert.Single(fiList);

            FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebAllAddresses }.gz");
            Assert.True(fi.Exists);

            await LoadWebType(0, WebTypeEnum.WebAllAddresses);

            Assert.True(webAllAddresses.AddressModelList.Where(c => c.TVItemModel.TVItem.TVItemID == -1).Any());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_Area_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(7, WebTypeEnum.WebProvince, TVTypeEnum.Area, TVTypeEnum.Province);

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            var boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            List<ToRecreate> toRecreateList = await TVItemLocalService.GetToRecreateList();
            Assert.NotNull(toRecreateList);
            Assert.NotEmpty(toRecreateList);
            Assert.Equal(2, toRecreateList.Count);
            Assert.Equal(-1, toRecreateList[0].TVItemID);
            Assert.Equal(WebTypeEnum.WebArea, toRecreateList[0].WebType);
            Assert.Equal(7, toRecreateList[1].TVItemID);
            Assert.Equal(WebTypeEnum.WebProvince, toRecreateList[1].WebType);

            DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
            Assert.True(di.Exists);
            List<FileInfo> fiList = di.GetFiles().ToList();
            Assert.Equal(2, fiList.Count);

            FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebArea }_{ -1 }.gz");
            Assert.True(fi.Exists);

            fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebProvince }_{ 7 }.gz");
            Assert.True(fi.Exists);

            await LoadWebType(-1, WebTypeEnum.WebArea);

            Assert.True(webArea.TVItemModel.TVItem.TVItemID == -1);

            await LoadWebType(7, WebTypeEnum.WebProvince);

            Assert.True(webProvince.TVItemModelAreaList.Where(c => c.TVItem.TVItemID == -1).Any());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_Classification_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(635, WebTypeEnum.WebSubsector, TVTypeEnum.Classification, TVTypeEnum.Subsector);

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            var boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            List<ToRecreate> toRecreateList = await TVItemLocalService.GetToRecreateList();
            Assert.NotNull(toRecreateList);
            Assert.NotEmpty(toRecreateList);
            Assert.Single(toRecreateList);
            Assert.Equal(635, toRecreateList[0].TVItemID);
            Assert.Equal(WebTypeEnum.WebSubsector, toRecreateList[0].WebType);

            DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
            Assert.True(di.Exists);
            List<FileInfo> fiList = di.GetFiles().ToList();
            Assert.Single(fiList);

            FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebSubsector }_{ 635 }.gz");
            Assert.True(fi.Exists);

            await LoadWebType(635, WebTypeEnum.WebSubsector);

            Assert.True(webSubsector.TVItemModelClassificationList.Where(c => c.TVItem.TVItemID == -1).Any());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_ClimateSite_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(7, WebTypeEnum.WebProvince, TVTypeEnum.ClimateSite, TVTypeEnum.Province);

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            var boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            List<ToRecreate> toRecreateList = await TVItemLocalService.GetToRecreateList();
            Assert.NotNull(toRecreateList);
            Assert.NotEmpty(toRecreateList);
            Assert.Single(toRecreateList);
            Assert.Equal(7, toRecreateList[0].TVItemID);
            Assert.Equal(WebTypeEnum.WebClimateSites, toRecreateList[0].WebType);

            DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
            Assert.True(di.Exists);
            List<FileInfo> fiList = di.GetFiles().ToList();
            Assert.Single(fiList);

            FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebClimateSites }_{ 7 }.gz");
            Assert.True(fi.Exists);

            await LoadWebType(7, WebTypeEnum.WebClimateSites);

            Assert.True(webClimateSites.ClimateSiteModelList.Where(c => c.TVItemModel.TVItem.TVItemID == -1).Any());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_Contact_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(1, WebTypeEnum.WebRoot, TVTypeEnum.Contact, TVTypeEnum.Root);

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            var boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            List<ToRecreate> toRecreateList = await TVItemLocalService.GetToRecreateList();
            Assert.NotNull(toRecreateList);
            Assert.NotEmpty(toRecreateList);
            Assert.Single(toRecreateList);
            Assert.Equal(0, toRecreateList[0].TVItemID);
            Assert.Equal(WebTypeEnum.WebAllContacts, toRecreateList[0].WebType);

            DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
            Assert.True(di.Exists);
            List<FileInfo> fiList = di.GetFiles().ToList();
            Assert.Single(fiList);

            FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebAllContacts }.gz");
            Assert.True(fi.Exists);

            await LoadWebType(0, WebTypeEnum.WebAllContacts);

            Assert.True(webAllContacts.ContactModelList.Where(c => c.TVItemModel.TVItem.TVItemID == -1).Any());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_Country_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(1, WebTypeEnum.WebRoot, TVTypeEnum.Country, TVTypeEnum.Root);

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            var boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            List<ToRecreate> toRecreateList = await TVItemLocalService.GetToRecreateList();
            Assert.NotNull(toRecreateList);
            Assert.NotEmpty(toRecreateList);
            Assert.Equal(3, toRecreateList.Count);
            Assert.Equal(0, toRecreateList[0].TVItemID);
            Assert.Equal(WebTypeEnum.WebAllCountries, toRecreateList[0].WebType);
            Assert.Equal(-1, toRecreateList[1].TVItemID);
            Assert.Equal(WebTypeEnum.WebCountry, toRecreateList[1].WebType);
            Assert.Equal(0, toRecreateList[2].TVItemID);
            Assert.Equal(WebTypeEnum.WebRoot, toRecreateList[2].WebType);

            DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
            Assert.True(di.Exists);
            List<FileInfo> fiList = di.GetFiles().ToList();
            Assert.Equal(3, fiList.Count);

            FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebAllCountries }.gz");
            Assert.True(fi.Exists);

            fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebCountry }_{ -1 }.gz");
            Assert.True(fi.Exists);

            fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebRoot }.gz");
            Assert.True(fi.Exists);

            await LoadWebType(0, WebTypeEnum.WebAllCountries);

            Assert.True(webAllCountries.TVItemModelList.Where(c => c.TVItem.TVItemID == -1).Any());

            await LoadWebType(-1, WebTypeEnum.WebCountry);

            Assert.True(webCountry.TVItemModel.TVItem.TVItemID == -1);

            await LoadWebType(0, WebTypeEnum.WebRoot);

            Assert.True(webRoot.TVItemModel.TVItem.TVItemID == -1);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_Email_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(1, WebTypeEnum.WebRoot, TVTypeEnum.Email, TVTypeEnum.Root);

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            var boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            List<ToRecreate> toRecreateList = await TVItemLocalService.GetToRecreateList();
            Assert.NotNull(toRecreateList);
            Assert.NotEmpty(toRecreateList);
            Assert.Single(toRecreateList);
            Assert.Equal(0, toRecreateList[0].TVItemID);
            Assert.Equal(WebTypeEnum.WebAllEmails, toRecreateList[0].WebType);

            DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
            Assert.True(di.Exists);
            List<FileInfo> fiList = di.GetFiles().ToList();
            Assert.Single(fiList);

            FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebAllEmails }.gz");
            Assert.True(fi.Exists);

            await LoadWebType(0, WebTypeEnum.WebAllEmails);

            Assert.True(webAllEmails.EmailModelList.Where(c => c.TVItemModel.TVItem.TVItemID == -1).Any());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_HydrometricSite_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(7, WebTypeEnum.WebProvince, TVTypeEnum.HydrometricSite, TVTypeEnum.Province);

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            var boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            List<ToRecreate> toRecreateList = await TVItemLocalService.GetToRecreateList();
            Assert.NotNull(toRecreateList);
            Assert.NotEmpty(toRecreateList);
            Assert.Single(toRecreateList);
            Assert.Equal(7, toRecreateList[0].TVItemID);
            Assert.Equal(WebTypeEnum.WebHydrometricSites, toRecreateList[0].WebType);

            DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
            Assert.True(di.Exists);
            List<FileInfo> fiList = di.GetFiles().ToList();
            Assert.Single(fiList);

            FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebHydrometricSites }_{ 7 }.gz");
            Assert.True(fi.Exists);

            await LoadWebType(7, WebTypeEnum.WebHydrometricSites);

            Assert.True(webHydrometricSites.HydrometricSiteModelList.Where(c => c.TVItemModel.TVItem.TVItemID == -1).Any());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_Infrastructure_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(27764, WebTypeEnum.WebMunicipality, TVTypeEnum.Infrastructure, TVTypeEnum.Municipality);

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            var boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            List<ToRecreate> toRecreateList = await TVItemLocalService.GetToRecreateList();
            Assert.NotNull(toRecreateList);
            Assert.NotEmpty(toRecreateList);
            Assert.Single(toRecreateList);
            Assert.Equal(27764, toRecreateList[0].TVItemID);
            Assert.Equal(WebTypeEnum.WebMunicipality, toRecreateList[0].WebType);

            DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
            Assert.True(di.Exists);
            List<FileInfo> fiList = di.GetFiles().ToList();
            Assert.Single(fiList);

            FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebMunicipality }_{ 27764 }.gz");
            Assert.True(fi.Exists);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_MikeBoundaryConditionMesh_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(27764, WebTypeEnum.WebMikeScenarios, TVTypeEnum.MikeBoundaryConditionMesh, TVTypeEnum.MikeScenario);

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            var boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            List<ToRecreate> toRecreateList = await TVItemLocalService.GetToRecreateList();
            Assert.NotNull(toRecreateList);
            Assert.NotEmpty(toRecreateList);
            Assert.Single(toRecreateList);
            Assert.Equal(27764, toRecreateList[0].TVItemID);
            Assert.Equal(WebTypeEnum.WebMikeScenarios, toRecreateList[0].WebType);

            DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
            Assert.True(di.Exists);
            List<FileInfo> fiList = di.GetFiles().ToList();
            Assert.Single(fiList);

            FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebMikeScenarios }_{ 27764 }.gz");
            Assert.True(fi.Exists);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_MikeBoundaryConditionWebTide_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(27764, WebTypeEnum.WebMikeScenarios, TVTypeEnum.MikeBoundaryConditionWebTide, TVTypeEnum.MikeScenario);

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            var boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            List<ToRecreate> toRecreateList = await TVItemLocalService.GetToRecreateList();
            Assert.NotNull(toRecreateList);
            Assert.NotEmpty(toRecreateList);
            Assert.Single(toRecreateList);
            Assert.Equal(27764, toRecreateList[0].TVItemID);
            Assert.Equal(WebTypeEnum.WebMikeScenarios, toRecreateList[0].WebType);

            DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
            Assert.True(di.Exists);
            List<FileInfo> fiList = di.GetFiles().ToList();
            Assert.Single(fiList);

            FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebMikeScenarios }_{ 27764 }.gz");
            Assert.True(fi.Exists);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_MikeScenario_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(27764, WebTypeEnum.WebMikeScenarios, TVTypeEnum.MikeScenario, TVTypeEnum.Municipality);

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            var boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            List<ToRecreate> toRecreateList = await TVItemLocalService.GetToRecreateList();
            Assert.NotNull(toRecreateList);
            Assert.NotEmpty(toRecreateList);
            Assert.Single(toRecreateList);
            Assert.Equal(27764, toRecreateList[0].TVItemID);
            Assert.Equal(WebTypeEnum.WebMikeScenarios, toRecreateList[0].WebType);

            DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
            Assert.True(di.Exists);
            List<FileInfo> fiList = di.GetFiles().ToList();
            Assert.Single(fiList);

            FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebMikeScenarios }_{ 27764 }.gz");
            Assert.True(fi.Exists);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_MikeSource_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(27764, WebTypeEnum.WebMikeScenarios, TVTypeEnum.MikeSource, TVTypeEnum.MikeScenario);

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            var boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            List<ToRecreate> toRecreateList = await TVItemLocalService.GetToRecreateList();
            Assert.NotNull(toRecreateList);
            Assert.NotEmpty(toRecreateList);
            Assert.Single(toRecreateList);
            Assert.Equal(27764, toRecreateList[0].TVItemID);
            Assert.Equal(WebTypeEnum.WebMikeScenarios, toRecreateList[0].WebType);

            DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
            Assert.True(di.Exists);
            List<FileInfo> fiList = di.GetFiles().ToList();
            Assert.Single(fiList);

            FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebMikeScenarios }_{ 27764 }.gz");
            Assert.True(fi.Exists);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_Municipality_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(7, WebTypeEnum.WebProvince, TVTypeEnum.Municipality, TVTypeEnum.Province);

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            var boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            List<ToRecreate> toRecreateList = await TVItemLocalService.GetToRecreateList();
            Assert.NotNull(toRecreateList);
            Assert.NotEmpty(toRecreateList);
            Assert.Equal(2, toRecreateList.Count);
            Assert.Equal(0, toRecreateList[0].TVItemID);
            Assert.Equal(WebTypeEnum.WebAllMunicipalities, toRecreateList[0].WebType);
            Assert.Equal(-1, toRecreateList[1].TVItemID);
            Assert.Equal(WebTypeEnum.WebMunicipality, toRecreateList[1].WebType);

            DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
            Assert.True(di.Exists);
            List<FileInfo> fiList = di.GetFiles().ToList();
            Assert.Equal(2, fiList.Count);

            FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebAllMunicipalities }.gz");
            Assert.True(fi.Exists);

            fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebMunicipality }_{ -1 }.gz");
            Assert.True(fi.Exists);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_MWQMRun_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(635, WebTypeEnum.WebSubsector, TVTypeEnum.MWQMRun, TVTypeEnum.Subsector);

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            var boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            List<ToRecreate> toRecreateList = await TVItemLocalService.GetToRecreateList();
            Assert.NotNull(toRecreateList);
            Assert.NotEmpty(toRecreateList);
            Assert.Single(toRecreateList);
            Assert.Equal(635, toRecreateList[0].TVItemID);
            Assert.Equal(WebTypeEnum.WebMWQMRuns, toRecreateList[0].WebType);

            DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
            Assert.True(di.Exists);
            List<FileInfo> fiList = di.GetFiles().ToList();
            Assert.Single(fiList);

            FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebMWQMRuns }_{ 635 }.gz");
            Assert.True(fi.Exists);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_MWQMSite_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(635, WebTypeEnum.WebSubsector, TVTypeEnum.MWQMSite, TVTypeEnum.Subsector);

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            var boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            List<ToRecreate> toRecreateList = await TVItemLocalService.GetToRecreateList();
            Assert.NotNull(toRecreateList);
            Assert.NotEmpty(toRecreateList);
            Assert.Single(toRecreateList);
            Assert.Equal(635, toRecreateList[0].TVItemID);
            Assert.Equal(WebTypeEnum.WebMWQMSites, toRecreateList[0].WebType);

            DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
            Assert.True(di.Exists);
            List<FileInfo> fiList = di.GetFiles().ToList();
            Assert.Single(fiList);

            FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebMWQMSites }_{ 635 }.gz");
            Assert.True(fi.Exists);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_PolSourceSite_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(635, WebTypeEnum.WebSubsector, TVTypeEnum.PolSourceSite, TVTypeEnum.Subsector);

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            var boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            List<ToRecreate> toRecreateList = await TVItemLocalService.GetToRecreateList();
            Assert.NotNull(toRecreateList);
            Assert.NotEmpty(toRecreateList);
            Assert.Single(toRecreateList);
            Assert.Equal(635, toRecreateList[0].TVItemID);
            Assert.Equal(WebTypeEnum.WebPolSourceSites, toRecreateList[0].WebType);

            DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
            Assert.True(di.Exists);
            List<FileInfo> fiList = di.GetFiles().ToList();
            Assert.Single(fiList);

            FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebPolSourceSites }_{ 635 }.gz");
            Assert.True(fi.Exists);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_Province_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(5, WebTypeEnum.WebCountry, TVTypeEnum.Province, TVTypeEnum.Country);

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            var boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            List<ToRecreate> toRecreateList = await TVItemLocalService.GetToRecreateList();
            Assert.NotNull(toRecreateList);
            Assert.NotEmpty(toRecreateList);
            Assert.Equal(4, toRecreateList.Count);
            Assert.Equal(0, toRecreateList[0].TVItemID);
            Assert.Equal(WebTypeEnum.WebAllProvinces, toRecreateList[0].WebType);
            Assert.Equal(5, toRecreateList[1].TVItemID);
            Assert.Equal(WebTypeEnum.WebCountry, toRecreateList[1].WebType);
            Assert.Equal(-1, toRecreateList[2].TVItemID);
            Assert.Equal(WebTypeEnum.WebProvince, toRecreateList[2].WebType);
            Assert.Equal(-1, toRecreateList[3].TVItemID);
            Assert.Equal(WebTypeEnum.WebDrogueRuns, toRecreateList[3].WebType);

            DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
            Assert.True(di.Exists);
            List<FileInfo> fiList = di.GetFiles().ToList();
            Assert.Equal(4, fiList.Count);

            FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebAllProvinces }.gz");
            Assert.True(fi.Exists);

            fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebCountry }_{ 5 }.gz");
            Assert.True(fi.Exists);

            fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebProvince }_{ -1 }.gz");
            Assert.True(fi.Exists);

            fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebDrogueRuns }_{ -1 }.gz");
            Assert.True(fi.Exists);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_RainExceedance_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(5, WebTypeEnum.WebCountry, TVTypeEnum.RainExceedance, TVTypeEnum.Country);

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            var boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            List<ToRecreate> toRecreateList = await TVItemLocalService.GetToRecreateList();
            Assert.NotNull(toRecreateList);
            Assert.NotEmpty(toRecreateList);
            Assert.Single(toRecreateList);
            Assert.Equal(5, toRecreateList[0].TVItemID);
            Assert.Equal(WebTypeEnum.WebCountry, toRecreateList[0].WebType);

            DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
            Assert.True(di.Exists);
            List<FileInfo> fiList = di.GetFiles().ToList();
            Assert.Single(fiList);

            FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebCountry }_{ 5 }.gz");
            Assert.True(fi.Exists);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_Sector_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(629, WebTypeEnum.WebArea, TVTypeEnum.Sector, TVTypeEnum.Area);

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            var boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            List<ToRecreate> toRecreateList = await TVItemLocalService.GetToRecreateList();
            Assert.NotNull(toRecreateList);
            Assert.NotEmpty(toRecreateList);
            Assert.Equal(2, toRecreateList.Count);
            Assert.Equal(629, toRecreateList[0].TVItemID);
            Assert.Equal(WebTypeEnum.WebArea, toRecreateList[0].WebType);
            Assert.Equal(-1, toRecreateList[1].TVItemID);
            Assert.Equal(WebTypeEnum.WebSector, toRecreateList[1].WebType);

            DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
            Assert.True(di.Exists);
            List<FileInfo> fiList = di.GetFiles().ToList();
            Assert.Equal(2, fiList.Count);

            FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebArea }_{ 629 }.gz");
            Assert.True(fi.Exists);

            fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebSector }_{ -1 }.gz");
            Assert.True(fi.Exists);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_Subsector_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(633, WebTypeEnum.WebSector, TVTypeEnum.Subsector, TVTypeEnum.Sector);

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            var boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            List<ToRecreate> toRecreateList = await TVItemLocalService.GetToRecreateList();
            Assert.NotNull(toRecreateList);
            Assert.NotEmpty(toRecreateList);
            Assert.Equal(7, toRecreateList.Count);
            Assert.Equal(633, toRecreateList[0].TVItemID);
            Assert.Equal(WebTypeEnum.WebSector, toRecreateList[0].WebType);
            Assert.Equal(-1, toRecreateList[1].TVItemID);
            Assert.Equal(WebTypeEnum.WebSubsector, toRecreateList[1].WebType);
            Assert.Equal(-1, toRecreateList[2].TVItemID);
            Assert.Equal(WebTypeEnum.WebMWQMRuns, toRecreateList[2].WebType);
            Assert.Equal(-1, toRecreateList[3].TVItemID);
            Assert.Equal(WebTypeEnum.WebMWQMSites, toRecreateList[3].WebType);
            Assert.Equal(-1, toRecreateList[4].TVItemID);
            Assert.Equal(WebTypeEnum.WebPolSourceSites, toRecreateList[4].WebType);
            Assert.Equal(-1, toRecreateList[5].TVItemID);
            Assert.Equal(WebTypeEnum.WebMWQMSamples1980_2020, toRecreateList[5].WebType);
            Assert.Equal(-1, toRecreateList[6].TVItemID);
            Assert.Equal(WebTypeEnum.WebMWQMSamples2021_2060, toRecreateList[6].WebType);

            DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
            Assert.True(di.Exists);
            List<FileInfo> fiList = di.GetFiles().ToList();
            Assert.Equal(7, fiList.Count);

            FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebSector }_{ 633 }.gz");
            Assert.True(fi.Exists);

            fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebSubsector }_{ -1 }.gz");
            Assert.True(fi.Exists);

            fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebMWQMRuns }_{ -1 }.gz");
            Assert.True(fi.Exists);

            fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebMWQMSites }_{ -1 }.gz");
            Assert.True(fi.Exists);

            fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebPolSourceSites }_{ -1 }.gz");
            Assert.True(fi.Exists);

            fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebMWQMSamples1980_2020 }_{ -1 }.gz");
            Assert.True(fi.Exists);

            fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebMWQMSamples2021_2060 }_{ -1 }.gz");
            Assert.True(fi.Exists);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_Tel_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(1, WebTypeEnum.WebRoot, TVTypeEnum.Tel, TVTypeEnum.Root);

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            var boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            List<ToRecreate> toRecreateList = await TVItemLocalService.GetToRecreateList();
            Assert.NotNull(toRecreateList);
            Assert.NotEmpty(toRecreateList);
            Assert.Single(toRecreateList);
            Assert.Equal(0, toRecreateList[0].TVItemID);
            Assert.Equal(WebTypeEnum.WebAllTels, toRecreateList[0].WebType);

            DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
            Assert.True(di.Exists);
            List<FileInfo> fiList = di.GetFiles().ToList();
            Assert.Single(fiList);

            FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebAllTels }.gz");
            Assert.True(fi.Exists);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_TideSite_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            // this test will not work as there is no Tide Site in the database

            //PostTVItemModel postTVItemModel = await FillPostTVItemModelForAdd(7, WebTypeEnum.WebProvince, TVTypeEnum.TideSite, TVTypeEnum.Province);

            //var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            //Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            //Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            //var boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            //Assert.True(boolRet);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_File_Area_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(629, WebTypeEnum.WebArea, TVTypeEnum.File, TVTypeEnum.Area);

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            var boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            List<ToRecreate> toRecreateList = await TVItemLocalService.GetToRecreateList();
            Assert.NotNull(toRecreateList);
            Assert.NotEmpty(toRecreateList);
            Assert.Single(toRecreateList);
            Assert.Equal(629, toRecreateList[0].TVItemID);
            Assert.Equal(WebTypeEnum.WebArea, toRecreateList[0].WebType);

            DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
            Assert.True(di.Exists);
            List<FileInfo> fiList = di.GetFiles().ToList();
            Assert.Single(fiList);

            FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebArea }_{ 629 }.gz");
            Assert.True(fi.Exists);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_File_Country_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(5, WebTypeEnum.WebCountry, TVTypeEnum.File, TVTypeEnum.Country);

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            var boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            List<ToRecreate> toRecreateList = await TVItemLocalService.GetToRecreateList();
            Assert.NotNull(toRecreateList);
            Assert.NotEmpty(toRecreateList);
            Assert.Single(toRecreateList);
            Assert.Equal(5, toRecreateList[0].TVItemID);
            Assert.Equal(WebTypeEnum.WebCountry, toRecreateList[0].WebType);

            DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
            Assert.True(di.Exists);
            List<FileInfo> fiList = di.GetFiles().ToList();
            Assert.Single(fiList);

            FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebCountry }_{ 5 }.gz");
            Assert.True(fi.Exists);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_File_Infrastructure_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(27764, WebTypeEnum.WebMunicipality, TVTypeEnum.File, TVTypeEnum.Infrastructure);

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            var boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            List<ToRecreate> toRecreateList = await TVItemLocalService.GetToRecreateList();
            Assert.NotNull(toRecreateList);
            Assert.NotEmpty(toRecreateList);
            Assert.Single(toRecreateList);
            Assert.Equal(27764, toRecreateList[0].TVItemID);
            Assert.Equal(WebTypeEnum.WebMunicipality, toRecreateList[0].WebType);

            DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
            Assert.True(di.Exists);
            List<FileInfo> fiList = di.GetFiles().ToList();
            Assert.Single(fiList);

            FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebMunicipality }_{ 27764 }.gz");
            Assert.True(fi.Exists);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_File_MikeScenario_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(27764, WebTypeEnum.WebMunicipality, TVTypeEnum.File, TVTypeEnum.MikeScenario);

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            var boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            List<ToRecreate> toRecreateList = await TVItemLocalService.GetToRecreateList();
            Assert.NotNull(toRecreateList);
            Assert.NotEmpty(toRecreateList);
            Assert.Single(toRecreateList);
            Assert.Equal(27764, toRecreateList[0].TVItemID);
            Assert.Equal(WebTypeEnum.WebMikeScenarios, toRecreateList[0].WebType);

            DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
            Assert.True(di.Exists);
            List<FileInfo> fiList = di.GetFiles().ToList();
            Assert.Single(fiList);

            FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebMikeScenarios }_{ 27764 }.gz");
            Assert.True(fi.Exists);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_File_Municipality_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(27764, WebTypeEnum.WebMunicipality, TVTypeEnum.File, TVTypeEnum.Municipality);

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            var boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            List<ToRecreate> toRecreateList = await TVItemLocalService.GetToRecreateList();
            Assert.NotNull(toRecreateList);
            Assert.NotEmpty(toRecreateList);
            Assert.Single(toRecreateList);
            Assert.Equal(27764, toRecreateList[0].TVItemID);
            Assert.Equal(WebTypeEnum.WebMunicipality, toRecreateList[0].WebType);

            DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
            Assert.True(di.Exists);
            List<FileInfo> fiList = di.GetFiles().ToList();
            Assert.Single(fiList);

            FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebMunicipality }_{ 27764 }.gz");
            Assert.True(fi.Exists);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_File_MWQMSite_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(635, WebTypeEnum.WebSubsector, TVTypeEnum.File, TVTypeEnum.MWQMSite);

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            var boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            List<ToRecreate> toRecreateList = await TVItemLocalService.GetToRecreateList();
            Assert.NotNull(toRecreateList);
            Assert.NotEmpty(toRecreateList);
            Assert.Single(toRecreateList);
            Assert.Equal(635, toRecreateList[0].TVItemID);
            Assert.Equal(WebTypeEnum.WebMWQMSites, toRecreateList[0].WebType);

            DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
            Assert.True(di.Exists);
            List<FileInfo> fiList = di.GetFiles().ToList();
            Assert.Single(fiList);

            FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebMWQMSites }_{ 635 }.gz");
            Assert.True(fi.Exists);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_File_PolSourceSite_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(635, WebTypeEnum.WebSubsector, TVTypeEnum.File, TVTypeEnum.PolSourceSite);

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            var boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            List<ToRecreate> toRecreateList = await TVItemLocalService.GetToRecreateList();
            Assert.NotNull(toRecreateList);
            Assert.NotEmpty(toRecreateList);
            Assert.Single(toRecreateList);
            Assert.Equal(635, toRecreateList[0].TVItemID);
            Assert.Equal(WebTypeEnum.WebPolSourceSites, toRecreateList[0].WebType);

            DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
            Assert.True(di.Exists);
            List<FileInfo> fiList = di.GetFiles().ToList();
            Assert.Single(fiList);

            FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebPolSourceSites }_{ 635 }.gz");
            Assert.True(fi.Exists);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_File_Province_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(7, WebTypeEnum.WebProvince, TVTypeEnum.File, TVTypeEnum.Province);

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            var boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            List<ToRecreate> toRecreateList = await TVItemLocalService.GetToRecreateList();
            Assert.NotNull(toRecreateList);
            Assert.NotEmpty(toRecreateList);
            Assert.Single(toRecreateList);
            Assert.Equal(7, toRecreateList[0].TVItemID);
            Assert.Equal(WebTypeEnum.WebProvince, toRecreateList[0].WebType);

            DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
            Assert.True(di.Exists);
            List<FileInfo> fiList = di.GetFiles().ToList();
            Assert.Single(fiList);

            FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebProvince }_{ 7 }.gz");
            Assert.True(fi.Exists);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_File_Root_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(1, WebTypeEnum.WebRoot, TVTypeEnum.File, TVTypeEnum.Root);

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            var boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            List<ToRecreate> toRecreateList = await TVItemLocalService.GetToRecreateList();
            Assert.NotNull(toRecreateList);
            Assert.NotEmpty(toRecreateList);
            Assert.Single(toRecreateList);
            Assert.Equal(1, toRecreateList[0].TVItemID);
            Assert.Equal(WebTypeEnum.WebRoot, toRecreateList[0].WebType);

            DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
            Assert.True(di.Exists);
            List<FileInfo> fiList = di.GetFiles().ToList();
            Assert.Single(fiList);

            FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebRoot }.gz");
            Assert.True(fi.Exists);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_File_Sector_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(633, WebTypeEnum.WebSector, TVTypeEnum.File, TVTypeEnum.Sector);

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            var boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            List<ToRecreate> toRecreateList = await TVItemLocalService.GetToRecreateList();
            Assert.NotNull(toRecreateList);
            Assert.NotEmpty(toRecreateList);
            Assert.Single(toRecreateList);
            Assert.Equal(633, toRecreateList[0].TVItemID);
            Assert.Equal(WebTypeEnum.WebSector, toRecreateList[0].WebType);

            DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
            Assert.True(di.Exists);
            List<FileInfo> fiList = di.GetFiles().ToList();
            Assert.Single(fiList);

            FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebSector }_{ 633 }.gz");
            Assert.True(fi.Exists);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_File_Subsector_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(635, WebTypeEnum.WebSubsector, TVTypeEnum.File, TVTypeEnum.Subsector);

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            var boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            List<ToRecreate> toRecreateList = await TVItemLocalService.GetToRecreateList();
            Assert.NotNull(toRecreateList);
            Assert.NotEmpty(toRecreateList);
            Assert.Single(toRecreateList);
            Assert.Equal(635, toRecreateList[0].TVItemID);
            Assert.Equal(WebTypeEnum.WebSubsector, toRecreateList[0].WebType);

            DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
            Assert.True(di.Exists);
            List<FileInfo> fiList = di.GetFiles().ToList();
            Assert.Single(fiList);

            FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebSubsector }_{ 635 }.gz");
            Assert.True(fi.Exists);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_TVItem_DBCommand_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(7, WebTypeEnum.WebProvince, TVTypeEnum.Area, TVTypeEnum.Province);

            postTVItemModel.TVItem.DBCommand = (DBCommandEnum)10000;

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"), errRes.ErrList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_TVItem_TVType_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(7, WebTypeEnum.WebProvince, TVTypeEnum.Area, TVTypeEnum.Province);

            postTVItemModel.TVItem.TVType = (TVTypeEnum)10000;

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "TVType"), errRes.ErrList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_TVItem_TVLevel_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(7, WebTypeEnum.WebProvince, TVTypeEnum.Area, TVTypeEnum.Province);

            postTVItemModel.TVItem.TVLevel = 0;

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "TVLevel"), errRes.ErrList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_TVItem_TVPath_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(7, WebTypeEnum.WebProvince, TVTypeEnum.Area, TVTypeEnum.Province);

            postTVItemModel.TVItem.TVPath = "";

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "TVPath"), errRes.ErrList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_TVItem_ParentID_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(7, WebTypeEnum.WebProvince, TVTypeEnum.Area, TVTypeEnum.Province);

            postTVItemModel.TVItem.ParentID = 0;

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "ParentID"), errRes.ErrList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_TVItemParent_DBCommand_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(7, WebTypeEnum.WebProvince, TVTypeEnum.Area, TVTypeEnum.Province);

            postTVItemModel.TVItem.DBCommand = (DBCommandEnum)10000;

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"), errRes.ErrList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_TVItemParent_TVType_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(7, WebTypeEnum.WebProvince, TVTypeEnum.Area, TVTypeEnum.Province);

            postTVItemModel.TVItem.TVType = (TVTypeEnum)10000;

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "TVType"), errRes.ErrList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_TVItemParent_TVLevel_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(7, WebTypeEnum.WebProvince, TVTypeEnum.Area, TVTypeEnum.Province);

            postTVItemModel.TVItem.TVLevel = 0;

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "TVLevel"), errRes.ErrList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_TVItemParent_TVPath_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(7, WebTypeEnum.WebProvince, TVTypeEnum.Area, TVTypeEnum.Province);

            postTVItemModel.TVItem.TVPath = "";

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "TVPath"), errRes.ErrList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_TVItemParent_ParentID_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(7, WebTypeEnum.WebProvince, TVTypeEnum.Area, TVTypeEnum.Province);

            postTVItemModel.TVItem.ParentID = 0;

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "ParentID"), errRes.ErrList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_TVItemLanguage_EN_DBCommand_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(7, WebTypeEnum.WebProvince, TVTypeEnum.Area, TVTypeEnum.Province);

            postTVItemModel.TVItemLanguageList[(int)LanguageEnum.en - 1].DBCommand = (DBCommandEnum)10000;

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"), errRes.ErrList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_TVItemLanguage_EN_TVItemLanguageID_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(7, WebTypeEnum.WebProvince, TVTypeEnum.Area, TVTypeEnum.Province);

            postTVItemModel.TVItemLanguageList[(int)LanguageEnum.en - 1].TVItemLanguageID = 1;

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Contains(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "TVItemLanguageID", "0"), errRes.ErrList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_TVItemLanguage_EN_TVItemID_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(7, WebTypeEnum.WebProvince, TVTypeEnum.Area, TVTypeEnum.Province);

            postTVItemModel.TVItemLanguageList[(int)LanguageEnum.en - 1].TVItemID = 1;

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Contains(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "TVItemID", "0"), errRes.ErrList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_Language_EN_TVItemID_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(7, WebTypeEnum.WebProvince, TVTypeEnum.Area, TVTypeEnum.Province);

            postTVItemModel.TVItemLanguageList[(int)LanguageEnum.en - 1].Language = (LanguageEnum)10000;

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "Language"), errRes.ErrList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_TVText_EN_TVItemID_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(7, WebTypeEnum.WebProvince, TVTypeEnum.Area, TVTypeEnum.Province);

            postTVItemModel.TVItemLanguageList[(int)LanguageEnum.en - 1].TVText = "";

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "TVText"), errRes.ErrList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_TranslationStatus_EN_TVItemID_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(7, WebTypeEnum.WebProvince, TVTypeEnum.Area, TVTypeEnum.Province);

            postTVItemModel.TVItemLanguageList[(int)LanguageEnum.en - 1].TranslationStatus = (TranslationStatusEnum)10000;

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "TranslationStatus"), errRes.ErrList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_TVItemLanguage_FR_DBCommand_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(7, WebTypeEnum.WebProvince, TVTypeEnum.Area, TVTypeEnum.Province);

            postTVItemModel.TVItemLanguageList[(int)LanguageEnum.fr - 1].DBCommand = (DBCommandEnum)10000;

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"), errRes.ErrList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_TVItemLanguage_FR_TVItemLanguageID_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(7, WebTypeEnum.WebProvince, TVTypeEnum.Area, TVTypeEnum.Province);

            postTVItemModel.TVItemLanguageList[(int)LanguageEnum.fr - 1].TVItemLanguageID = 1;

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Contains(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "TVItemLanguageID", "0"), errRes.ErrList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_TVItemLanguage_FR_TVItemID_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(7, WebTypeEnum.WebProvince, TVTypeEnum.Area, TVTypeEnum.Province);

            postTVItemModel.TVItemLanguageList[(int)LanguageEnum.fr - 1].TVItemID = 1;

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Contains(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "TVItemID", "0"), errRes.ErrList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_Language_FR_TVItemID_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(7, WebTypeEnum.WebProvince, TVTypeEnum.Area, TVTypeEnum.Province);

            postTVItemModel.TVItemLanguageList[(int)LanguageEnum.fr - 1].Language = (LanguageEnum)10000;

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "Language"), errRes.ErrList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_TVText_FR_TVItemID_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(7, WebTypeEnum.WebProvince, TVTypeEnum.Area, TVTypeEnum.Province);

            postTVItemModel.TVItemLanguageList[(int)LanguageEnum.fr - 1].TVText = "";

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "TVText"), errRes.ErrList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddTVItemLocal_TranslationStatus_FR_TVItemID_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(7, WebTypeEnum.WebProvince, TVTypeEnum.Area, TVTypeEnum.Province);

            postTVItemModel.TVItemLanguageList[(int)LanguageEnum.fr - 1].TranslationStatus = (TranslationStatusEnum)10000;

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "TranslationStatus"), errRes.ErrList);
        }
    }
}
