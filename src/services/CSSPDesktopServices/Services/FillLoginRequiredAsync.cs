using CSSPCultureServices.Services;
using CSSPDesktopServices.Models;
using CSSPEnums;
using CSSPDBModels;
using Microsoft.Extensions.Configuration;
using CSSPReadGzFileServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Threading.Tasks;
using CSSPHelperModels;
using ManageServices;
using CSSPLocalLoggedInServices;
using CSSPCultureServices.Resources;
using CSSPScrambleServices;
using CSSPLogServices;
using System.Linq;

namespace CSSPDesktopServices.Services
{
    public partial class CSSPDesktopService : ICSSPDesktopService
    {
        public async Task<bool> FillLoginRequiredAsync()
        {
            AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.CheckIfLoginIsRequired));

            contact = (from c in dbManage.Contacts
                       select c).FirstOrDefault();

            if (contact == null || contact.IsLoggedIn == null || !(bool)contact.IsLoggedIn)
            {
                AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.LoginRequired));

                LoginRequired = true;
                return await Task.FromResult(true);
            }

            AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.AlreadyLoggedIn));

            LoginRequired = false;

            AppendStatus(new AppendEventArgs(""));

            return await Task.FromResult(true);
        }
    }
}
