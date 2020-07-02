using System;
using System.IO;
using System.Threading.Tasks;

namespace CSSPSQLiteServices
{
    public partial class SQLiteCreateCSSPDBLocal
    {
        private async Task<bool> CheckAndCreateMissingDirectoryAndFile(FileInfo fiAppDataPath)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo($@"{fiAppDataPath.Directory}");
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

            if (!fiAppDataPath.Exists)
            {
                try
                {
                    FileStream fs = fiAppDataPath.Create();
                    fs.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                    return await Task.FromResult(false);
                }
            }

            return await Task.FromResult(true);
        }
    }
}
