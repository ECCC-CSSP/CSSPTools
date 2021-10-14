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
        public async Task HydrometricSite_AddTVItemLocal_Good_Test(string culture)
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

            Assert.True(webHydrometricSites.HydrometricSiteModelList.Where(c => c.TVItemModel.TVItem.TVItemID == -1
            && c.TVItemModel.TVItem.TVType == TVTypeEnum.HydrometricSite).Any());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task HydrometricSite_DeleteTVItemLocal_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            Assert.True(false, "To Do");
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task HydrometricSite_ModifyTVItemLocal_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            Assert.True(false, "To Do");
        }
    }
}
