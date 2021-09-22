using CSSPCultureServices.Resources;
using CSSPDesktopServices.Models;
using ManageServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace CSSPDesktopServices.Services
{
    public partial class CSSPDesktopService : ICSSPDesktopService
    {
        private async Task<bool> DoStart()
        {
            AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.ExecutingBackgroundApps));

            Directory.SetCurrentDirectory(Configuration["CSSPWebAPIsLocalPath"]);

            List <ManageFile> manageFilesList = (from c in dbManage.ManageFiles
                                                select c).ToList();

            foreach(ManageFile manageFile in manageFilesList)
            {
                manageFile.LoadedOnce = false;
            }

            try
            {
                dbManage.SaveChanges();
            }
            catch (Exception ex)
            {
                AppendStatus(new AppendEventArgs($"{CSSPCultureDesktopRes.CouldNotSetAllManageFilesLoadedOnceToFalse} Ex: { ex.Message }"));
            }

            AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.SetAllManageFilesLoadedOnceToFalse));
            AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.ExecutingBackgroundApps));

            if (!OpenCSSPWebAPIsLocal()) return await Task.FromResult(false);
            if (!OpenBrowser()) return await Task.FromResult(false);

            AppendStatus(new AppendEventArgs(""));

            return await Task.FromResult(true);
        }
    }
}
