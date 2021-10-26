/* 
 *  Manually Edited
 *  
 */

using CSSPDBModels;
using CSSPEnums;
using CSSPWebModels;
using System;
using System.Collections.Generic;

namespace CSSPDBLocalServices.Tests
{
    public partial class EmailLocalServiceTest
    {
        private EmailLocalModel FillEmailLocalModel()
        {
            EmailLocalModel emailModel = new EmailLocalModel();

            Email address = new Email()
            {
                EmailID = 0,
                DBCommand = DBCommandEnum.Created,
                EmailTVItemID = 0,
                EmailType = EmailTypeEnum.Personal,
                EmailAddress = "SomeEmail@ec.gc.ca",
                LastUpdateDate_UTC = DateTime.UtcNow,
                LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID,
            };

            emailModel.Email = address;

            return emailModel;
        }
    }
}
