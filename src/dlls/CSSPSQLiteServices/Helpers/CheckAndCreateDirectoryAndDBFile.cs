using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CSSPSQLiteServices.Services
{
    public partial class CSSPSQLiteService : ICSSPSQLiteService
    {
        private async Task<bool> CheckAndCreateMissingDirectoriesAndFiles(List<FileInfo> fiDBs)
        {
            foreach (FileInfo fiDB in fiDBs)
            {
                DirectoryInfo directoryInfo = new DirectoryInfo($@"{fiDB.Directory}");
                if (!directoryInfo.Exists)
                {
                    try
                    {
                        directoryInfo.Create();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"{ex.Message}");
                        return await Task.FromResult(false);
                    }
                }

                if (!fiDB.Exists)
                {
                    try
                    {
                        FileStream fs = fiDB.Create();
                        fs.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"{ex.Message}");
                        return await Task.FromResult(false);
                    }
                }
            }

            return await Task.FromResult(true);
        }
    }
}
