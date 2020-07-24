using CSSPDesktopUpdateServices.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSSPDesktopUpdateServices.Services
{
    public partial interface ICSSPDesktopUpdateService
    {
        AppTextModel appTextModel { get; set; }
        bool IsEnglish { get; set; }
        bool Start();
        event EventHandler<DownloadingEventArgs> StatusDownloading;
        event EventHandler<InstallingEventArgs> StatusInstalling;
        event EventHandler<ErrorMessageEventArgs> StatusErrorMessage;
    }

    public partial class CSSPDesktopUpdateService : ICSSPDesktopUpdateService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public AppTextModel appTextModel { get; set; }
        public bool IsEnglish { get; set; }

        #endregion Properties

        #region Constructors
        public CSSPDesktopUpdateService()
        {
        }
        #endregion Constructors

        #region Events
        #endregion Events

        #region Functions public
        public bool Start()
        {
            if (!DownloadUpdate()) return false;

            return true;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private

    }
}
