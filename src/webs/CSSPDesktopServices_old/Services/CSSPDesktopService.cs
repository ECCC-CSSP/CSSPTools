using CSSPDesktopServices.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace CSSPDesktopServices.Services
{
    public interface ICSSPDesktopService
    {
        // Properties
        string StartUrl { get; set; }
        string AppDataPath { get; set; }
        string CSSPWebAPIsExeFullPath { get; set; }
        string HelpPath { get; set; }
        bool IsEnglish { get; set; }
        Process processCSSPWebAPIs { get; set; }
        Process processBrowser { get; set; }
        Process processHelp { get; set; }
        AppTextModel appTextModel { get; set; }
        // Functions
        Task<bool> CheckingAvailableUpdate();
        Task<bool> CheckingInternetConnection();
        Task<bool> Update();
        Task<bool> Start();
        Task<bool> Stop();
        Task<bool> OpenHelp();
        event EventHandler<ClearEventArgs> StatusClear;
        event EventHandler<AppendEventArgs> StatusAppend;
    }
    public partial class CSSPDesktopService : ICSSPDesktopService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public string AppDataPath { get; set; }
        public string StartUrl { get; set; }
        public string CSSPWebAPIsExeFullPath { get; set; }
        public string HelpPath { get; set; }
        public bool IsEnglish { get; set; }
        public Process processCSSPWebAPIs { get; set; }
        public Process processBrowser { get; set; }
        public Process processHelp { get; set; }
        public AppTextModel appTextModel { get; set; }
        #endregion Properties

        #region Constructors
        #endregion Constructors

        #region Functions public
        public async Task<bool> CheckingAvailableUpdate()
        {
            if (!await DoCheckingAvailableUpdate()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        public async Task<bool> CheckingInternetConnection()
        {
            if (!await DoCheckingInternetConnection()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        public async Task<bool> OpenHelp()
        {
            if (!await DoOpenHelp()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        public async Task<bool> Start()
        {
            if (!await DoStart()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        public async Task<bool> Stop()
        {
            if (!await DoStop()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        public async Task<bool> Update()
        {
            if (!await DoUpdate()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        #endregion Function public
    }
}
