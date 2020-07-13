using CSSPDesktopServices.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace CSSPDesktopServices.Services
{
    public partial class CSSPDesktopService : ICSSPDesktopService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public string StartUrl { get; set; }
        public string AppDataPath { get; set; }
        public string CSSPWebAPIsExeFullPath { get; set; }
        public string HelpPath { get; set; }
        public List<string> InternetConnectionTestingURLs { get; set; }
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
