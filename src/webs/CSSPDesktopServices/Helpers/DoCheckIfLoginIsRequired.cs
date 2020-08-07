using CSSPEnums;
using CSSPModels;
using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSSPDesktopServices.Services
{
    public partial class CSSPDesktopService : ICSSPDesktopService
    {
        private async Task<bool> DoCheckIfLoginIsRequired()
        {
            Contact contact = (from c in dbLogin.Contacts
                               select c).FirstOrDefault();

            if (contact == null)
            {
                LoginRequired = true;
            }

            ContactLoggedIn = contact;

            LoginEmail = (from c in dbLogin.Preferences
                          where c.PreferenceName == "LoginEmail"
                          select c.PreferenceText).FirstOrDefault();

            if (string.IsNullOrWhiteSpace(LoginEmail))
            {
                LoginRequired = true;
            }

            LoginEmail = Descramble(LoginEmail);

            Password = (from c in dbLogin.Preferences
                        where c.PreferenceName == "Password"
                        select c.PreferenceText).FirstOrDefault();

            if (string.IsNullOrWhiteSpace(Password))
            {
                LoginRequired = true;
            }

            Password = Descramble(Password);

            AzureStore = (from c in dbLogin.Preferences
                        where c.PreferenceName == "AzureStore"
                        select c.PreferenceText).FirstOrDefault();

            if (string.IsNullOrWhiteSpace(AzureStore))
            {
                LoginRequired = true;
            }

            AzureStore = Descramble(AzureStore);

            LoginRequired = false;

            return await Task.FromResult(true);
        }
    }
}
