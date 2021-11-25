namespace CSSPSQLiteServices;

public partial class CSSPSQLiteService : ICSSPSQLiteService
{
    private async Task<bool> CheckAndCreateMissingDirectoriesAndFilesAsync(List<FileInfo> fiDBs)
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
                    fs.Flush();
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

