using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPModels;
using ManageServices;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSSPLocalLoggedInServices
{
    public partial class CSSPLocalLoggedInService : ICSSPLocalLoggedInService
    {
        public async Task<bool> SetLocalLoggedInContactInfoAsync()
        {
            LoggedInContactInfo = new LoggedInContactInfo();

            if (dbManage == null)
            {
                return await Task.FromResult(false);
            }

            LoggedInContactInfo.LoggedInContact = (from c in dbManage.Contacts
                                                   orderby c.LoginEmail
                                                   select c).FirstOrDefault();

            if (LoggedInContactInfo.LoggedInContact == null)
            {
                LoggedInContactInfo.TVTypeUserAuthorizationList = new List<TVTypeUserAuthorization>();
                LoggedInContactInfo.TVItemUserAuthorizationList = new List<TVItemUserAuthorization>();
            }
            else
            {
                LoggedInContactInfo.TVTypeUserAuthorizationList = (from c in dbManage.TVTypeUserAuthorizations
                                                                   where c.ContactTVItemID == LoggedInContactInfo.LoggedInContact.ContactTVItemID
                                                                   select c).ToList();

                LoggedInContactInfo.TVItemUserAuthorizationList = (from c in dbManage.TVItemUserAuthorizations
                                                                   where c.ContactTVItemID == LoggedInContactInfo.LoggedInContact.ContactTVItemID
                                                                   select c).ToList();
            }

            return await Task.FromResult(true);
        }
    }
}
