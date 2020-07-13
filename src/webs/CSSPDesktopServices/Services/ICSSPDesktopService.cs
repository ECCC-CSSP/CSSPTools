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
        List<string> InternetConnectionTestingURLs { get; set; }
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
}
