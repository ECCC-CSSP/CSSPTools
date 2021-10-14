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
        public async Task Subsector_AddTVItemLocal_Good_Test(string culture)
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

            await LoadWebType(633, WebTypeEnum.WebSector);

            Assert.True(webSector.TVItemModelSubsectorList.Where(c => c.TVItem.TVItemID == -1
            && c.TVItem.TVType == TVTypeEnum.Subsector).Any());

            await LoadWebType(-1, WebTypeEnum.WebSubsector);

            Assert.True(webSubsector.TVItemModel.TVItem.TVItemID == -1
            && webSubsector.TVItemModel.TVItem.TVType == TVTypeEnum.Subsector);

            await LoadWebType(-1, WebTypeEnum.WebMWQMRuns);

            Assert.True(webMWQMRuns.TVItemModel.TVItem.TVItemID == -1
                && webMWQMRuns.TVItemModel.TVItem.TVType == TVTypeEnum.Subsector);

            await LoadWebType(-1, WebTypeEnum.WebMWQMSites);

            Assert.True(webMWQMSites.TVItemModel.TVItem.TVItemID == -1
                && webMWQMSites.TVItemModel.TVItem.TVType == TVTypeEnum.Subsector);

            await LoadWebType(-1, WebTypeEnum.WebPolSourceSites);

            Assert.True(webPolSourceSites.TVItemModel.TVItem.TVItemID == -1
                && webPolSourceSites.TVItemModel.TVItem.TVType == TVTypeEnum.Subsector);

            await LoadWebType(-1, WebTypeEnum.WebMWQMSamples1980_2020);

            Assert.True(webMWQMSamples1980_2020.TVItemModel.TVItem.TVItemID == -1
                && webMWQMSamples1980_2020.TVItemModel.TVItem.TVType == TVTypeEnum.Subsector);

            await LoadWebType(-1, WebTypeEnum.WebMWQMSamples2021_2060);

            Assert.True(webMWQMSamples2021_2060.TVItemModel.TVItem.TVItemID == -1
                && webMWQMSamples2021_2060.TVItemModel.TVItem.TVType == TVTypeEnum.Subsector);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Subsector_DeleteTVItemLocal_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            Assert.True(false, "To Do");
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Subsector_ModifyTVItemLocal_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            Assert.True(false, "To Do");
        }
    }
}
