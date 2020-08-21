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

            // doing preference
            preference = (from c in dbLogin.Preferences
                          select c).FirstOrDefault();

            if (preference == null)
            {
                AppendStatus(new AppendEventArgs(string.Format(appTextModel.CouldNotFind_InDBLogin, "Preference")));

                LoginRequired = true;
                return await Task.FromResult(true);
            }

            AppendStatus(new AppendEventArgs(string.Format(appTextModel.Found_InDBLogin, "Preference")));
            preference.AzureStore = await Descramble(preference.AzureStore);
            preference.LoginEmail = await Descramble(preference.LoginEmail);
            preference.Password = await Descramble(preference.Password);
            preference.HasInternetConnection = bool.Parse(await Descramble(preference.HasInternetConnection.ToString()));
            preference.LoggedIn = bool.Parse(await Descramble(preference.LoggedIn.ToString()));
            preference.Token = await Descramble(preference.Token);
            LoginRequired = false;

            AppendStatus(new AppendEventArgs(""));

            return await Task.FromResult(true);
        }
    }
}
