using Azure;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using CSSPCultureServices.Resources;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CSSPUpdateServices
{
    public partial class CSSPUpdateService : ICSSPUpdateService
    {
        public async Task<bool> DoUploadAllFilesToAzure()
        {
            LogAppend(sbLog, $"{ CSSPCultureUpdateRes.Starting } DoUploadAllFilesToAzure ...");

            if (!await CheckComputerName()) return await Task.FromResult(false);

            LogAppend(sbLog, $"{ CSSPCultureUpdateRes.RunningOn } { Environment.MachineName.ToString().ToLower() }");

            int CountFileTotal = 0;
            int CountFileUploaded = 0;

            DirectoryInfo di = new DirectoryInfo(LocalAppDataPath);

            List<DirectoryInfo> diList = di.GetDirectories().ToList().Skip(0).Take(10000).ToList();

            int count = 0;
            foreach (DirectoryInfo d in diList)
            {
                count += 1;
                Console.WriteLine($"{ count } --- { d.FullName }");

                ShareClient shareClient = new ShareClient(AzureStore, AzureStoreCSSPFilesPath);
                ShareDirectoryClient directory = shareClient.GetDirectoryClient(d.Name);

                if (!directory.Exists())
                {
                    try
                    {
                        directory.Create();
                    }
                    catch (Exception ex)
                    {
                        ErrorAppend(sbError, $"{ String.Format(CSSPCultureUpdateRes.CouldNotCreateDirectory_Error_, d.FullName, ex.Message) }");

                        await StoreInCommandLog(sbLog, sbError, "DoUploadAllFilesToAzure");

                        return await Task.FromResult(false);
                    }
                }

                Pageable<ShareFileItem> shareFileItemList = directory.GetFilesAndDirectories();

                List<FileInfo> fileInfoList = d.GetFiles().ToList();
                foreach (FileInfo fi in fileInfoList)
                {
                    CountFileTotal += 1;
                    Console.WriteLine($"\t\t File Count: {CountFileTotal} -- { fi.FullName }");


                    bool ShouldUpload = true;
                    foreach (ShareFileItem shareFileItem in shareFileItemList)
                    {
                        if (fi.Name == shareFileItem.Name)
                        {
                            if (fi.Length == shareFileItem.FileSize)
                            {
                                ShouldUpload = false;
                                break;
                            }
                        }
                    }

                    if (ShouldUpload)
                    {
                        try
                        {
                            ShareFileClient file = directory.GetFileClient(fi.Name);
                            using (FileStream stream = File.OpenRead(fi.FullName))
                            {
                                if (fi.Length != 0)
                                {

                                    file.Create(stream.Length);
                                    file.Upload(stream);

                                    CountFileUploaded += 1;
                                    LogAppend(sbLog, $"{ String.Format(CSSPCultureUpdateRes.UploadedCount_AndFile_, CountFileUploaded, fi.FullName) }");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            ErrorAppend(sbError, $"{ String.Format(CSSPCultureUpdateRes.CouldNotUploadFile_Error_, d.FullName, ex.Message) }");

                            await StoreInCommandLog(sbLog, sbError, "DoUploadAllFilesToAzure");

                            return await Task.FromResult(false);
                        }
                    }
                }
            }

            LogAppend(sbLog, $"{ CSSPCultureUpdateRes.End } DoUploadAllFilesToAzure ...");

            await StoreInCommandLog(sbLog, sbError, "DoUploadAllFilesToAzure");

            return await Task.FromResult(true);
        }
    }
}
