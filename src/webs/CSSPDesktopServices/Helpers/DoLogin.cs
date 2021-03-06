﻿using CSSPCultureServices.Resources;
using CSSPDesktopServices.Models;
using CSSPDBModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.SignalR;
using CSSPHelperModels;

namespace CSSPDesktopServices.Services
{
    public partial class CSSPDesktopService : ICSSPDesktopService
    {
        #region Properties
        #endregion Properties

        #region Functions private
        private async Task<bool> DoLogin(LoginModel loginModel)
        {
            AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.LoggingIn));

            if (!await DoLoginContact(loginModel)) return await Task.FromResult(false);

            if (!await DoLoginTVItemUserAuthorization()) return await Task.FromResult(false);

            if (!await DoLoginTVTypeUserAuthorization()) return await Task.FromResult(false);

            if (!await DoLoginManage(loginModel)) return await Task.FromResult(false);

            AppendStatus(new AppendEventArgs(""));

            return await Task.FromResult(true);
        }

        #endregion Functions private
    }
}
