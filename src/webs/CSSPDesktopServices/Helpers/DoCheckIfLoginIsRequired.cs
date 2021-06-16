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

namespace CSSPDesktopServices.Services
{
    public partial class CSSPDesktopService : ICSSPDesktopService
    {
        private async Task<bool> DoCheckIfLoginIsRequired()
        {
            AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.CheckIfLoginIsRequired));

            // doing Contact
            contact = (from c in dbManage.Contacts
                       select c).FirstOrDefault();

            if (contact == null)
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.CouldNotFind_InPreferenceDB, "Contact")));

                LoginRequired = true;
                return await Task.FromResult(true);
            }

            AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.Found_InDBLogin, "Contact")));

            if (contact.IsLoggedIn == null || !(bool)contact.IsLoggedIn)
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.User_IsNotLoggedIn, contact.FirstName + " " + contact.LastName)));

                LoginRequired = true;
                return await Task.FromResult(true);
            }

            AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.User_IsAlreadyLoggedIn, contact.FirstName + " " + contact.LastName)));

            LoginRequired = false;

            AppendStatus(new AppendEventArgs(""));

            return await Task.FromResult(true);
        }
    }
}
