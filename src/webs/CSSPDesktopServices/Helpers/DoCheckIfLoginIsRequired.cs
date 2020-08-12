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
using CSSPDesktopServices.Models;

namespace CSSPDesktopServices.Services
{
    public partial class CSSPDesktopService : ICSSPDesktopService
    {
        private async Task<bool> DoCheckIfLoginIsRequired()
        {
            AppendStatus(new AppendEventArgs(appTextModel.CheckIfLoginIsRequired));

            // doing Contact
            Contact contact = (from c in dbLogin.Contacts
                               select c).FirstOrDefault();

            if (contact == null)
            {
                AppendStatus(new AppendEventArgs(string.Format(appTextModel.CouldNotFind_InDBLogin, "Contact")));

                LoginRequired = true;
                return await Task.FromResult(true);
            }

            AppendStatus(new AppendEventArgs(string.Format(appTextModel.Found_InDBLogin, "Contact")));
            ContactLoggedIn = contact;

            // doing LoginEmail
            LoginEmail = (from c in dbLogin.Preferences
                          where c.PreferenceName == "LoginEmail"
                          select c.PreferenceText).FirstOrDefault();

            if (string.IsNullOrWhiteSpace(LoginEmail))
            {
                AppendStatus(new AppendEventArgs(string.Format(appTextModel.CouldNotFind_InDBLogin, "LoginEmail")));

                LoginRequired = true;
                return await Task.FromResult(true);
            }

            AppendStatus(new AppendEventArgs(string.Format(appTextModel.Found_InDBLogin, "LoginEmail")));
            LoginEmail = await Descramble(LoginEmail);

            // doing Password
            Password = (from c in dbLogin.Preferences
                        where c.PreferenceName == "Password"
                        select c.PreferenceText).FirstOrDefault();

            if (string.IsNullOrWhiteSpace(Password))
            {
                AppendStatus(new AppendEventArgs(string.Format(appTextModel.CouldNotFind_InDBLogin, "Password")));

                LoginRequired = true;
                return await Task.FromResult(true);
            }

            AppendStatus(new AppendEventArgs(string.Format(appTextModel.Found_InDBLogin, "Password")));
            Password = await Descramble(Password);

            // doing LoggedIn
            string LoggedInTxt = (from c in dbLogin.Preferences
                                  where c.PreferenceName == "LoggedIn"
                                  select c.PreferenceText).FirstOrDefault();

            if (string.IsNullOrWhiteSpace(LoggedInTxt))
            {
                AppendStatus(new AppendEventArgs(string.Format(appTextModel.CouldNotFind_InDBLogin, "LoggedIn")));

                LoginRequired = true;
                return await Task.FromResult(true);
            }

            AppendStatus(new AppendEventArgs(string.Format(appTextModel.Found_InDBLogin, "LoggedIn")));
            LoggedInTxt = await Descramble(LoggedInTxt);

            IsLoggedIn = bool.Parse(LoggedInTxt);

            if (!IsLoggedIn)
            {
                LoginRequired = true;
                return await Task.FromResult(true);
            }

            // doing AzureStore
            AzureStore = (from c in dbLogin.Preferences
                          where c.PreferenceName == "AzureStore"
                          select c.PreferenceText).FirstOrDefault();

            if (string.IsNullOrWhiteSpace(AzureStore))
            {
                AppendStatus(new AppendEventArgs(string.Format(appTextModel.CouldNotFind_InDBLogin, "AzureStore")));

                LoginRequired = true;
                return await Task.FromResult(true);
            }

            AppendStatus(new AppendEventArgs(string.Format(appTextModel.Found_InDBLogin, "AzureStore")));
            AzureStore = await Descramble(AzureStore);

            LoginRequired = false;

            AppendStatus(new AppendEventArgs(""));

            return await Task.FromResult(true);
        }
    }
}
