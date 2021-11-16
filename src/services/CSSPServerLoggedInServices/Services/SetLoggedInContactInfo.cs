using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPHelperModels;
using ManageServices;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSSPServerLoggedInServices
{
    public partial class CSSPServerLoggedInService : ICSSPServerLoggedInService
    {
        public async Task<bool> SetLoggedInContactInfo(string LoginEmail)
        {
            LoggedInContactInfo.LoggedInContact = (from c in db.Contacts
                                                   where c.LoginEmail == LoginEmail
                                                   select c).FirstOrDefault();

            if (LoggedInContactInfo.LoggedInContact == null)
            {
                LoggedInContactInfo.TVTypeUserAuthorizationList = new List<TVTypeUserAuthorization>();
                LoggedInContactInfo.TVItemUserAuthorizationList = new List<TVItemUserAuthorization>();
            }
            else
            {
                LoggedInContactInfo.TVTypeUserAuthorizationList = (from c in db.TVTypeUserAuthorizations
                                                                   where c.ContactTVItemID == LoggedInContactInfo.LoggedInContact.ContactTVItemID
                                                                   select c).ToList();

                LoggedInContactInfo.TVItemUserAuthorizationList = (from c in db.TVItemUserAuthorizations
                                                                   where c.ContactTVItemID == LoggedInContactInfo.LoggedInContact.ContactTVItemID
                                                                   select c).ToList();
            }

            return await Task.FromResult(true);
        }
    }
}
