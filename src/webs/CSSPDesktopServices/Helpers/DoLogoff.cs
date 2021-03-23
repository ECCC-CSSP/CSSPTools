using CSSPCultureServices.Resources;
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
using Microsoft.AspNetCore.Mvc;

namespace CSSPDesktopServices.Services
{
    public partial class CSSPDesktopService : ICSSPDesktopService
    {
        #region Properties
        #endregion Properties

        #region Functions private
        private async Task<bool> DoLogoff()
        {
            AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.Logoff));

            contact.IsLoggedIn = false;

            try
            {
                dbPreference.SaveChanges();
            }
            catch (Exception ex)
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.UnmanagedServerError_, ex.Message)));
                return await Task.FromResult(true);
            }

            AppendStatus(new AppendEventArgs(""));

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
