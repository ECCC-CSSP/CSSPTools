using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSSPDesktopServices.Services
{
    public partial class CSSPDesktopService : ICSSPDesktopService
    {
        private async Task<bool> DoCheckingAvailableUpdate()
        {
            // will need to check a tag on the Azure Storage
            return await Task.FromResult(true);
        }
    }
}
