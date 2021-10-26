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
    public partial class EmailLocalServiceTest : CSSPDBLocalServiceTest
    {
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddEmailLocal_Good_Test(string culture)
        {
            Assert.True(await EmailLocalServiceSetup(culture));

            EmailLocalModel emailLocalModel = FillEmailLocalModel();

            var actionPostTVItemModelRes = await EmailLocalService.AddEmailLocal(emailLocalModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            EmailLocalModel emailLocalModelRet = (EmailLocalModel)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(emailLocalModelRet);

            Assert.Equal(1, (from c in dbLocal.Emails select c).Count());
            Assert.Equal(2, (from c in dbLocal.TVItems select c).Count());
            Assert.Equal(4, (from c in dbLocal.TVItemLanguages select c).Count());

            Assert.Equal(-1, emailLocalModelRet.Email.EmailID);
            Assert.Equal(DBCommandEnum.Created, emailLocalModelRet.Email.DBCommand);
            Assert.Equal(-1, emailLocalModelRet.Email.EmailTVItemID);
            Assert.Equal(emailLocalModel.Email.EmailAddress, emailLocalModelRet.Email.EmailAddress);
            Assert.Equal(emailLocalModel.Email.EmailType, emailLocalModelRet.Email.EmailType);
            Assert.Equal(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID, emailLocalModelRet.Email.LastUpdateContactTVItemID);
            Assert.True(DateTime.UtcNow.AddSeconds(-1) < emailLocalModelRet.Email.LastUpdateDate_UTC);
            Assert.True(DateTime.UtcNow.AddSeconds(1) > emailLocalModelRet.Email.LastUpdateDate_UTC);

            Email emailDB = (from c in dbLocal.Emails
                                 where c.EmailID == -1
                                 select c).FirstOrDefault();
            Assert.NotNull(emailDB);

            EmailLocalModel emailLocalModelDB = new EmailLocalModel()
            {
                Email = emailDB,
            };

            Assert.Equal(JsonSerializer.Serialize(emailLocalModelDB), JsonSerializer.Serialize(emailLocalModelRet));

            WebAllEmails webAllEmails = await CSSPReadGzFileService.GetUncompressJSON<WebAllEmails>(WebTypeEnum.WebAllEmails, 0);

            Email emailWeb = (from c in webAllEmails.EmailList
                                  where c.EmailID == -1
                                  select c).FirstOrDefault();
            Assert.NotNull(emailWeb);

            await CSSPLogService.Save();

            List<CommandLog> commandLogList = (from c in dbManage.CommandLogs
                                               select c).ToList();

            Assert.Single(commandLogList);
            Assert.Contains("EmailLocalService.AddEmailLocal(EmailLocalModel emailLocalModel)", commandLogList[0].Log);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddEmailLocal_EmailID_Error_Test(string culture)
        {
            Assert.True(await EmailLocalServiceSetup(culture));

            EmailLocalModel emailLocalModel = FillEmailLocalModel();

            emailLocalModel.Email.EmailID = 10;

            var actionPostTVItemModelRes = await EmailLocalService.AddEmailLocal(emailLocalModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Equal(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "EmailID", "0"), errRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddEmailLocal_EmailAddress_Error_Test(string culture)
        {
            Assert.True(await EmailLocalServiceSetup(culture));

            EmailLocalModel emailLocalModel = FillEmailLocalModel();

            emailLocalModel.Email.EmailAddress = "";

            var actionPostTVItemModelRes = await EmailLocalService.AddEmailLocal(emailLocalModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "EmailAddress"), errRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddEmailLocal_EmailType_Error_Test(string culture)
        {
            Assert.True(await EmailLocalServiceSetup(culture));

            EmailLocalModel emailLocalModel = FillEmailLocalModel();

            emailLocalModel.Email.EmailType = (EmailTypeEnum)10000;

            var actionPostTVItemModelRes = await EmailLocalService.AddEmailLocal(emailLocalModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "EmailType"), errRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddEmailLocal_Return_Existing_Email_As_It_Already_Exist_Test(string culture)
        {
            Assert.True(await EmailLocalServiceSetup(culture));

            WebAllEmails webAllEmails = await CSSPReadGzFileService.GetUncompressJSON<WebAllEmails>(WebTypeEnum.WebAllEmails, 0);

            Assert.True(webAllEmails.EmailList.Count > 10);

            EmailLocalModel emailLocalModel = FillEmailLocalModel();

            emailLocalModel.Email = webAllEmails.EmailList[7];

            int EmailID = emailLocalModel.Email.EmailID;

            emailLocalModel.Email.EmailID = 0;

            var actionPostTVItemModelRes = await EmailLocalService.AddEmailLocal(emailLocalModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            EmailLocalModel emailLocalModelRet = (EmailLocalModel)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            emailLocalModel.Email.EmailID = EmailID;
            Assert.Equal(JsonSerializer.Serialize(emailLocalModel), JsonSerializer.Serialize(emailLocalModelRet));
        }
    }
}
