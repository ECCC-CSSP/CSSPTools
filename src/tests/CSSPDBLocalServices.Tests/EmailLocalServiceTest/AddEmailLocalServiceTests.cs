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

            Email email = FillEmail();

            var actionEmailRes = await EmailLocalService.AddEmailLocal(email);
            Assert.Equal(200, ((ObjectResult)actionEmailRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionEmailRes.Result).Value);
            Email emailRet = (Email)((OkObjectResult)actionEmailRes.Result).Value;
            Assert.NotNull(emailRet);

            Assert.Equal(1, (from c in dbLocal.Emails select c).Count());
            Assert.Equal(2, (from c in dbLocal.TVItems select c).Count());
            Assert.Equal(4, (from c in dbLocal.TVItemLanguages select c).Count());

            Assert.Equal(-1, emailRet.EmailID);
            Assert.Equal(DBCommandEnum.Created, emailRet.DBCommand);
            Assert.Equal(-1, emailRet.EmailTVItemID);
            Assert.Equal(email.EmailAddress, emailRet.EmailAddress);
            Assert.Equal(email.EmailType, emailRet.EmailType);
            Assert.Equal(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID, emailRet.LastUpdateContactTVItemID);
            Assert.True(DateTime.UtcNow.AddSeconds(-1) < emailRet.LastUpdateDate_UTC);
            Assert.True(DateTime.UtcNow.AddSeconds(1) > emailRet.LastUpdateDate_UTC);

            Email emailDB = (from c in dbLocal.Emails
                                 where c.EmailID == -1
                                 select c).FirstOrDefault();
            Assert.NotNull(emailDB);

            Assert.Equal(JsonSerializer.Serialize(emailDB), JsonSerializer.Serialize(emailRet));

            WebAllEmails webAllEmails = await CSSPReadGzFileService.GetUncompressJSON<WebAllEmails>(WebTypeEnum.WebAllEmails, 0);

            Email emailWeb = (from c in webAllEmails.EmailList
                                  where c.EmailID == -1
                                  select c).FirstOrDefault();
            Assert.NotNull(emailWeb);

            await CSSPLogService.Save();

            List<CommandLog> commandLogList = (from c in dbManage.CommandLogs
                                               select c).ToList();

            Assert.Single(commandLogList);
            Assert.Contains("EmailLocalService.AddEmailLocal(Email email)", commandLogList[0].Log);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddEmailLocal_EmailID_Error_Test(string culture)
        {
            Assert.True(await EmailLocalServiceSetup(culture));

            Email email = FillEmail();

            email.EmailID = 10;

            var actionEmailRes = await EmailLocalService.AddEmailLocal(email);
            Assert.Equal(400, ((ObjectResult)actionEmailRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionEmailRes.Result).Value;
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

            Email email = FillEmail();

            email.EmailAddress = "";

            var actionEmailRes = await EmailLocalService.AddEmailLocal(email);
            Assert.Equal(400, ((ObjectResult)actionEmailRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionEmailRes.Result).Value;
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

            Email email = FillEmail();

            email.EmailType = (EmailTypeEnum)10000;

            var actionEmailRes = await EmailLocalService.AddEmailLocal(email);
            Assert.Equal(400, ((ObjectResult)actionEmailRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionEmailRes.Result).Value;
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

            Email email = FillEmail();

            email = webAllEmails.EmailList[7];

            int EmailID = email.EmailID;

            email.EmailID = 0;

            var actionEmailRes = await EmailLocalService.AddEmailLocal(email);
            Assert.Equal(200, ((ObjectResult)actionEmailRes.Result).StatusCode);
            Email emailRet = (Email)((OkObjectResult)actionEmailRes.Result).Value;
            email.EmailID = EmailID;
            Assert.Equal(JsonSerializer.Serialize(email), JsonSerializer.Serialize(emailRet));
        }
    }
}
