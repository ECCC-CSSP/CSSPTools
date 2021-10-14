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
        public async Task Province_AddTVItemLocal_Good_Test(string culture)
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

            await LoadWebType(0, WebTypeEnum.WebAllProvinces);

            Assert.True(webAllProvinces.TVItemModelList.Where(c => c.TVItem.TVItemID == -1
            && c.TVItem.TVType == TVTypeEnum.Province).Any());

            await LoadWebType(5, WebTypeEnum.WebCountry);

            Assert.True(webCountry.TVItemModelProvinceList.Where(c => c.TVItem.TVItemID == -1
            && c.TVItem.TVType == TVTypeEnum.Province).Any());

            await LoadWebType(-1, WebTypeEnum.WebProvince);

            Assert.True(webProvince.TVItemModel.TVItem.TVItemID == -1
            && webProvince.TVItemModel.TVItem.TVType == TVTypeEnum.Province);

            await LoadWebType(-1, WebTypeEnum.WebDrogueRuns);

            Assert.True(webDrogueRuns.TVItemModel.TVItem.TVItemID == -1
            && webDrogueRuns.TVItemModel.TVItem.TVType == TVTypeEnum.Province);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Province_DeleteTVItemLocal_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            Assert.True(false, "To Do");
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Province_ModifyTVItemLocal_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            Assert.True(false, "To Do");
        }
    }
}
