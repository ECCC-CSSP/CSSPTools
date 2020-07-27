using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSSPDesktopServices.Services
{
    public partial class CSSPDesktopService
    {
        private async Task<bool> DoGetUpdates()
        {
            Thread.Sleep(3000);

            return await Task.FromResult(true);
        }
    }
}
