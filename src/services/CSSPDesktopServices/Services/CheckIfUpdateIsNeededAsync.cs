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
using System.IO;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using Azure;

namespace CSSPDesktopServices.Services
{
    public partial class CSSPDesktopService : ICSSPDesktopService
    {
        public async Task<bool> CheckIfUpdateIsNeededAsync()
        {
            if (!await CSSPLocalLoggedInService.SetLocalLoggedInContactInfo()) return await Task.FromResult(false);

            AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.CheckIfUpdateIsNeeded));

            UpdateIsNeeded = false;

            if (contact.HasInternetConnection == null || !(bool)contact.HasInternetConnection)
            {
                return await Task.FromResult(true);
            }

            if (!await CheckIfZipFileAreUpToDateAsync()) return await Task.FromResult(true);

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(false);

            if (!await CheckIfJsonFileAreUpToDateAsync()) return await Task.FromResult(true);

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(false);

            AppendStatus(new AppendEventArgs(""));

            return await Task.FromResult(true);
        }
    }
}
