using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CSSPSQLiteServices.Services
{
    public interface ICSSPSQLiteService
    {
        string Error { get; set; }
        Task<bool> CreateSQLiteCSSPLocalDatabase();
        Task<bool> CreateSQLiteCSSPFileManagementDatabase();
        Task<bool> CreateSQLiteCSSPLoginDatabase();
        Task<bool> DBContainsInfo(FileInfo fi);
    }
}

