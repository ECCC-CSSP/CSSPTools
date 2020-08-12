﻿using CSSPDesktopServices.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CSSPDesktopServices.Services
{
    public partial class CSSPDesktopService : ICSSPDesktopService
    {
        private async Task<bool> DoStart()
        {
            AppendStatus(new AppendEventArgs(appTextModel.ExecutingBackgroundApps));

            Directory.SetCurrentDirectory(LocalCSSPWebAPIsPath);

            if (!OpenCSSPWebAPIs()) return await Task.FromResult(false);
            if (!OpenBrowser()) return await Task.FromResult(false);

            AppendStatus(new AppendEventArgs(""));

            return await Task.FromResult(true);
        }
    }
}
