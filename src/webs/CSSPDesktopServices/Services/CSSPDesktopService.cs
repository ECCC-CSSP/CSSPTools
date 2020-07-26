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
        bool IsEnglish { get; set; }
        Process processCSSPWebAPIs { get; set; }
        Process processBrowser { get; set; }
        AppTextModel appTextModel { get; set; }
        bool HasInternetConnection { get; set; }

        // Functions
        Task<bool> CreateAllRequiredDirectories();
        Task<bool> CheckingAvailableUpdate();
        void CheckingInternetConnection();
        Task<bool> GetUpdates();
        Task<bool> Start();
        Task<bool> Stop();
        
        // Events
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
        public bool IsEnglish { get; set; }
        public Process processCSSPWebAPIs { get; set; }
        public Process processBrowser { get; set; }
        public AppTextModel appTextModel { get; set; }
        public bool HasInternetConnection { get; set; }
        #endregion Properties

        #region Constructors
        #endregion Constructors

        #region Functions public
        public async Task<bool> CheckingAvailableUpdate()
        {
            if (!await DoCheckingAvailableUpdate()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        public void CheckingInternetConnection()
        {
            DoCheckingInternetConnection();
        }
        public async Task<bool> CreateAllRequiredDirectories()
        {
            if (!await DoCreateAllRequiredDirectories()) return await Task.FromResult(false);

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
        public async Task<bool> GetUpdates()
        {
            if (!await DoGetUpdates()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        #endregion Function public
    }
}
