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
using Microsoft.AspNetCore.Mvc;

namespace CSSPDesktopServices.Services
{
    public partial class CSSPDesktopService : ICSSPDesktopService
    {
        public async Task<bool> LoginAsync(LoginModel loginModel)
        {
            AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.LoggingIn));

            await CSSPAzureLoginService.AzureLoginAsync(loginModel);  

            if (CSSPLogService.ErrRes.ErrList.Count == 0)
            {
                AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.LoggedIn));
                LoginRequired = false;

                contact = (from c in dbManage.Contacts
                           select c).FirstOrDefault();
            }
            else
            {
                AppendStatus(new AppendEventArgs(string.Join(",", CSSPLogService.ErrRes.ErrList)));
                LoginRequired = true;
            }

            return await Task.FromResult(true);
        }
    }
}
