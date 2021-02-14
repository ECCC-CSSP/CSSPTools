using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CSSPDesktopServices.Models;
using CSSPDBModels;
using CSSPCultureServices.Resources;
using System.Runtime.CompilerServices;
using CSSPDBPreferenceModels;

namespace CSSPDesktopServices.Services
{
    public partial class CSSPDesktopService : ICSSPDesktopService
    {
        private async Task<bool> DoCheckIfLoginIsRequired()
        {
            AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.CheckIfLoginIsRequired));

            // doing Contact
            contact = (from c in dbPreference.Contacts
                       select c).FirstOrDefault();

            if (contact == null)
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.CouldNotFind_InDBLogin, "Contact")));

                LoginRequired = true;
                return await Task.FromResult(true);
            }

            AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.Found_InDBLogin, "Contact")));

            Preference preferenceLoggedIn = await GetPreferenceWithVariableName("LoggedIn");

            if (preferenceLoggedIn == null)
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.CouldNotFind_InDBLogin_, "LoggedIn", "Preferences")));
                return await Task.FromResult(false);
            }

            bool LoggedIn = bool.Parse(preferenceLoggedIn.VariableValue);

            if (!LoggedIn)
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.CouldNotFind_InDBLogin_, "LoggedIn", "Preferences")));

                LoginRequired = true;
                return await Task.FromResult(true);
            }

            AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.Found_InDBLogin_, "LoggedIn", "Preference")));

            LoginRequired = false;

            AppendStatus(new AppendEventArgs(""));

            return await Task.FromResult(true);
        }
    }
}
