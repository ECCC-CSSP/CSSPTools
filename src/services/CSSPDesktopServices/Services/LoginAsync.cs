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
        public async Task<bool> LoginAsync(LoginModel loginModel)
        {
            AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.LoggingIn));

            if (!await LoginContactAsync(loginModel)) return await Task.FromResult(false);

            if (!await LoginTVItemUserAuthorizationAsync()) return await Task.FromResult(false);

            if (!await LoginTVTypeUserAuthorizationAsync()) return await Task.FromResult(false);

            if (!await LoginManageAsync(loginModel)) return await Task.FromResult(false);

            AppendStatus(new AppendEventArgs(""));

            if (!await CSSPLocalLoggedInService.SetLocalLoggedInContactInfo()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
    }
}
