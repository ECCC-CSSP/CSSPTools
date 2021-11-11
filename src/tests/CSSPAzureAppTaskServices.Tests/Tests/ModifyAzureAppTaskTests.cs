/* 
 *  Manually Edited
 *  
 */

using CSSPCultureServices.Resources;
using CSSPEnums;
using CSSPWebModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace CSSPAzureAppTaskServices.Tests
{
    public partial class AzureAppTaskServiceTest
    {
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Modify_Good_Test(string culture)
        {
            Assert.True(await CSSPAzureAppTaskServiceSetup(culture));

            AppTaskLocalModel appTaskModel = FillAppTaskModel();

            List<AppTaskLocalModel> postAppTaskModelListRet = await TestGetAllAsync();
            Assert.Empty(postAppTaskModelListRet);

            AppTaskLocalModel postAppTaskModelRet = await TestAddAsync(appTaskModel);
            Assert.NotNull(postAppTaskModelRet);
            Assert.NotNull(postAppTaskModelRet.AppTask);
            Assert.NotEmpty(postAppTaskModelRet.AppTaskLanguageList);

            string StatusText = "New Status Text";
            string ErrorText = "New Error Text";

            postAppTaskModelRet.AppTask.DBCommand = DBCommandEnum.Modified;
            postAppTaskModelRet.AppTaskLanguageList[0].DBCommand = DBCommandEnum.Modified;
            postAppTaskModelRet.AppTaskLanguageList[0].StatusText = StatusText;
            postAppTaskModelRet.AppTaskLanguageList[0].ErrorText = ErrorText;
            postAppTaskModelRet.AppTaskLanguageList[1].DBCommand = DBCommandEnum.Modified;
            postAppTaskModelRet.AppTaskLanguageList[1].StatusText = StatusText;
            postAppTaskModelRet.AppTaskLanguageList[1].ErrorText = ErrorText;

            AppTaskLocalModel appTaskModelRet5 = await TestModifyAsync(postAppTaskModelRet);
            Assert.NotNull(postAppTaskModelRet);
            Assert.NotNull(postAppTaskModelRet.AppTask);
            Assert.NotEmpty(postAppTaskModelRet.AppTaskLanguageList);

            Assert.Equal(DBCommandEnum.Modified, appTaskModelRet5.AppTask.DBCommand);
            Assert.Equal(DBCommandEnum.Modified, appTaskModelRet5.AppTaskLanguageList[0].DBCommand);
            Assert.Equal(StatusText, appTaskModelRet5.AppTaskLanguageList[0].StatusText);
            Assert.Equal(ErrorText, appTaskModelRet5.AppTaskLanguageList[0].ErrorText);
            Assert.Equal(DBCommandEnum.Modified, appTaskModelRet5.AppTaskLanguageList[1].DBCommand);
            Assert.Equal(StatusText, appTaskModelRet5.AppTaskLanguageList[1].StatusText);
            Assert.Equal(ErrorText, appTaskModelRet5.AppTaskLanguageList[1].ErrorText);

            List<AppTaskLocalModel> appTaskModelListRet = await TestGetAllAsync();
            Assert.NotEmpty(appTaskModelListRet);

            await TestDeleteAsync(postAppTaskModelRet.AppTask.AppTaskID);

            appTaskModelListRet = await TestGetAllAsync();
            Assert.Empty(appTaskModelListRet);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Modify_CouldNotFind_Error_Test(string culture)
        {
            Assert.True(await CSSPAzureAppTaskServiceSetup(culture));

            AppTaskLocalModel appTaskModel = FillAppTaskModel();

            AppTaskLocalModel appTaskModelRet = await TestAddAsync(appTaskModel);

            int AppTaskIDToDelete = appTaskModelRet.AppTask.AppTaskID;

            AppTaskLocalModel appTaskModel2 = FillAppTaskModel();
            appTaskModel2.AppTask.AppTaskID = -1;
            appTaskModel2.AppTaskLanguageList[0].AppTaskLanguageID = -1;
            appTaskModel2.AppTaskLanguageList[1].AppTaskLanguageID = -1;
            appTaskModel2.AppTaskLanguageList[0].AppTaskID = -1;
            appTaskModel2.AppTaskLanguageList[1].AppTaskID = -1;
            await TestModifyErrorAsync(appTaskModel2, string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTask", "AppTaskID", appTaskModel2.AppTask.AppTaskID.ToString()));
        }
    }
}
