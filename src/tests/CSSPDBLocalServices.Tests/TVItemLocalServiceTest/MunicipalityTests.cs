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
        public async Task Municipality_AddTVItemLocal_Good_Test(string culture)
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
            Assert.Equal(3, toRecreateList.Count);
            Assert.Equal(0, toRecreateList[0].TVItemID);
            Assert.Equal(WebTypeEnum.WebAllMunicipalities, toRecreateList[0].WebType);
            Assert.Equal(-1, toRecreateList[1].TVItemID);
            Assert.Equal(WebTypeEnum.WebMunicipality, toRecreateList[1].WebType);
            Assert.Equal(7, toRecreateList[2].TVItemID);
            Assert.Equal(WebTypeEnum.WebProvince, toRecreateList[2].WebType);

            DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
            Assert.True(di.Exists);
            List<FileInfo> fiList = di.GetFiles().ToList();
            Assert.Equal(3, fiList.Count);

            FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebAllMunicipalities }.gz");
            Assert.True(fi.Exists);

            fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebMunicipality }_{ -1 }.gz");
            Assert.True(fi.Exists);

            fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebProvince }_{ 7 }.gz");
            Assert.True(fi.Exists);

            await LoadWebType(7, WebTypeEnum.WebAllMunicipalities);

            Assert.True(webAllMunicipalities.TVItemModelList.Where(c => c.TVItem.TVItemID == -1
            && c.TVItem.TVType == TVTypeEnum.Municipality).Any());

            await LoadWebType(-1, WebTypeEnum.WebMunicipality);

            Assert.True(webMunicipality.TVItemModel.TVItem.TVItemID == -1
            && webMunicipality.TVItemModel.TVItem.TVType == TVTypeEnum.Municipality);

            await LoadWebType(7, WebTypeEnum.WebProvince);

            Assert.True(webProvince.TVItemModelMunicipalityList.Where(c => c.TVItem.TVItemID == -1
            && c.TVItem.TVType == TVTypeEnum.Municipality).Any());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Municipality_DeleteTVItemLocal_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            Assert.True(false, "To Do");
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Municipality_ModifyTVItemLocal_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            Assert.True(false, "To Do");
        }
    }
}
