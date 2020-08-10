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
        private bool DoCheckIfLoginIsRequired()
        {
            // doing Contact
            Contact contact = (from c in dbLogin.Contacts
                               select c).FirstOrDefault();

            if (contact == null)
            {
                LoginRequired = true;
                return true;
            }

            ContactLoggedIn = contact;

            // doing LoginEmail
            LoginEmail = (from c in dbLogin.Preferences
                          where c.PreferenceName == "LoginEmail"
                          select c.PreferenceText).FirstOrDefault();

            if (string.IsNullOrWhiteSpace(LoginEmail))
            {
                LoginRequired = true;
                return true;
            }

            LoginEmail = Descramble(LoginEmail);

            // doing Password
            Password = (from c in dbLogin.Preferences
                        where c.PreferenceName == "Password"
                        select c.PreferenceText).FirstOrDefault();

            if (string.IsNullOrWhiteSpace(Password))
            {
                LoginRequired = true;
                return true;
            }

            Password = Descramble(Password);

            // doing LoggedIn
            string LoggedInTxt = (from c in dbLogin.Preferences
                                  where c.PreferenceName == "LoggedIn"
                                  select c.PreferenceText).FirstOrDefault();

            if (string.IsNullOrWhiteSpace(LoggedInTxt))
            {
                LoginRequired = true;
                return true;
            }

            LoggedInTxt = Descramble(LoggedInTxt);

            IsLoggedIn = bool.Parse(LoggedInTxt);

            if (!IsLoggedIn)
            {
                LoginRequired = true;
                return true;
            }

            // doing AzureStore
            AzureStore = (from c in dbLogin.Preferences
                          where c.PreferenceName == "AzureStore"
                          select c.PreferenceText).FirstOrDefault();

            if (string.IsNullOrWhiteSpace(AzureStore))
            {
                LoginRequired = true;
                return true;
            }

            AzureStore = Descramble(AzureStore);

            LoginRequired = false;

            return true;
        }
    }
}
