using CSSPDesktopServices.Models;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CSSPDesktopServices.Services
{
    public partial class CSSPDesktopService
    {
        private async Task<bool> DoStart()
        {
            ClearStatus(new ClearEventArgs());
            if (!await OpenCSSPWebAPIs()) return await Task.FromResult(false);
            if (!await OpenBrowser()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
    }
}
