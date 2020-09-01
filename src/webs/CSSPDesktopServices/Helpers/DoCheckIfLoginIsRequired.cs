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
            contact = (from c in dbLogin.Contacts
                       select c).FirstOrDefault();

            if (contact == null)
            {
                AppendStatus(new AppendEventArgs(string.Format(appTextModel.CouldNotFind_InDBLogin, "Contact")));

                LoginRequired = true;
                return await Task.FromResult(true);
            }

            AppendStatus(new AppendEventArgs(string.Format(appTextModel.Found_InDBLogin, "Contact")));

            // doing preference
            Preference preferenceInDB = (from c in dbLogin.Preferences
                                         select c).FirstOrDefault();

            if (preferenceInDB == null)
            {
                preference = null;
                AppendStatus(new AppendEventArgs(string.Format(appTextModel.CouldNotFind_InDBLogin, "Preference")));

                LoginRequired = true;
                return await Task.FromResult(true);
            }

            AppendStatus(new AppendEventArgs(string.Format(appTextModel.Found_InDBLogin, "Preference")));
            preference.PreferenceID = preferenceInDB.PreferenceID;
            preference.AzureStore = await Descramble(preferenceInDB.AzureStore);
            preference.LoginEmail = await Descramble(preferenceInDB.LoginEmail);
            preference.Password = await Descramble(preferenceInDB.Password);
            preference.HasInternetConnection = preferenceInDB.HasInternetConnection;
            preference.LoggedIn = preferenceInDB.LoggedIn;
            preference.Token = await Descramble(preferenceInDB.Token);

            LoginRequired = false;

            AppendStatus(new AppendEventArgs(""));

            return await Task.FromResult(true);
        }
    }
}
