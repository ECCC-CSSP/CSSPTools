/* 
 *  Manually Edited
 *  
 */

using CSSPCultureServices.Resources;
using CSSPDBModels;
using CSSPEnums;
using CSSPHelperModels;
using CSSPReadGzFileServices;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using System.Text.Json;
using ManageServices;

namespace CSSPDBLocalServices.Tests
{
    public partial class ClassificationLocalServiceTest : CSSPDBLocalServiceTest
    {
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddClassificationLocal_Good_Test(string culture)
        {
            Assert.True(await ClassificationLocalServiceSetup(culture));

            int SubsectorTVItemID = 635;

            WebSubsector webSubsector = await CSSPReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, SubsectorTVItemID);

            List<TVItemModel> tvItemModelParentList = webSubsector.TVItemModelParentList;

            ClassificationTypeEnum classificationType = ClassificationTypeEnum.Approved;

            List<Coord> coordList = new List<Coord>()
            {
                new Coord() { Lat = 23.0D, Lng = -56.0D, Ordinal = 0 },
                new Coord() { Lat = 24.0D, Lng = -57.0D, Ordinal = 0 },
            };

            var actionClassificationRes = await ClassificationLocalService.AddClassificationLocalAsync(SubsectorTVItemID, classificationType, coordList);
            Assert.Equal(200, ((ObjectResult)actionClassificationRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionClassificationRes.Result).Value);
            ClassificationModel classificationModelRet = (ClassificationModel)((OkObjectResult)actionClassificationRes.Result).Value;
            Assert.NotNull(classificationModelRet);

            // check count of CSSPDBLocal items in tables
            Assert.Equal(1, (from c in dbLocal.Classifications select c).Count());
            Assert.Equal(tvItemModelParentList.Count + 1, (from c in dbLocal.TVItems select c).Count());
            Assert.Equal((tvItemModelParentList.Count * 2) + 2, (from c in dbLocal.TVItemLanguages select c).Count());
            Assert.Equal(1, (from c in dbLocal.MapInfos select c).Count());
            Assert.Equal(coordList.Count, (from c in dbLocal.MapInfoPoints select c).Count());

            // check Classifications table items
            Assert.Equal(DBCommandEnum.Created, classificationModelRet.Classification.DBCommand);
            Assert.Equal(-1, classificationModelRet.Classification.ClassificationTVItemID);
            Assert.Equal(classificationType, classificationModelRet.Classification.ClassificationType);
            Assert.Equal(0, classificationModelRet.Classification.Ordinal);
            Assert.Equal(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID, classificationModelRet.Classification.LastUpdateContactTVItemID);
            Assert.True(DateTime.UtcNow.AddMinutes(-1) < classificationModelRet.Classification.LastUpdateDate_UTC);
            Assert.True(DateTime.UtcNow.AddMinutes(1) > classificationModelRet.Classification.LastUpdateDate_UTC);

            Classification classificationDB = (from c in dbLocal.Classifications
                                               where c.ClassificationID == -1
                                               select c).FirstOrDefault();
            Assert.NotNull(classificationDB);

            Assert.Equal(JsonSerializer.Serialize(classificationDB), JsonSerializer.Serialize(classificationModelRet));

            webSubsector = await CSSPReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, SubsectorTVItemID);

            ClassificationModel classificationModelWeb = (from c in webSubsector.ClassificationModelList
                                                          where c.Classification.ClassificationID == -1
                                                          select c).FirstOrDefault();
            Assert.NotNull(classificationModelWeb);

            await CSSPLogService.Save();

            List<CommandLog> commandLogList = (from c in dbManage.CommandLogs
                                               select c).ToList();

            Assert.Single(commandLogList);
            Assert.Contains("ClassificationLocalService.AddClassificationLocal(Classification classification)", commandLogList[0].Log);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddClassificationLocal_SubsectorTVItemID_Error_Test(string culture)
        {
            Assert.True(await ClassificationLocalServiceSetup(culture));

            int SubsectorTVItemID = 0;

            ClassificationTypeEnum classificationType = ClassificationTypeEnum.Approved;

            List<Coord> coordList = new List<Coord>()
            {
                new Coord() { Lat = 23.0D, Lng = -56.0D, Ordinal = 0 },
                new Coord() { Lat = 24.0D, Lng = -57.0D, Ordinal = 0 },
            };

            var actionClassificationRes = await ClassificationLocalService.AddClassificationLocalAsync(SubsectorTVItemID, classificationType, coordList);
            Assert.Equal(400, ((ObjectResult)actionClassificationRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionClassificationRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "SubsectorTVItemID"), errRes.ErrList[0]);
        }
    }
}
