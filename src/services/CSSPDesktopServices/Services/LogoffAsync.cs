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
        public async Task<bool> LogoffAsync()
        {
            AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.Logoff));

            Contact contactToModify = (from c in dbManage.Contacts
                                       where c.ContactTVItemID == contact.ContactTVItemID
                                       select c).FirstOrDefault();

            if (contactToModify != null)
            {
                contactToModify.IsLoggedIn = false;
                LoginRequired = true;

                try
                {
                    dbManage.SaveChanges();
                }
                catch (Exception ex)
                {
                    AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.UnmanagedServerError_, ex.Message)));
                    return await Task.FromResult(true);
                }
            }

            AppendStatus(new AppendEventArgs(""));

            return await Task.FromResult(true);
        }
    }
}
