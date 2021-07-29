﻿using Azure;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using CSSPDBModels;
using CSSPEnums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPUpdateAll
{
    public partial class Startup
    {
        public async Task<bool> RemoveDirectoriesNotFoundInTVFiles(string StartPathLocal, string StartPathMQEM_NATIONAL)
        {
            DirectoryInfo di = new DirectoryInfo(StartPathLocal);
            if (!di.Exists)
            {
                Console.WriteLine($"StartPathLocal does not exist {di.FullName}");
                return await Task.FromResult(false);
            }

            DirectoryInfo diNat = new DirectoryInfo(StartPathMQEM_NATIONAL);
            if (!diNat.Exists)
            {
                Console.WriteLine($"StartPathMQEM_NATIONAL does not exist {diNat.FullName}");
                return await Task.FromResult(false);
            }

            FileInfo fi = new FileInfo(@"C:\CSSPTools\src\webs\CSSPUpdateAll\ListOfRemoveDirectoriesNotFoundInTVFiles.csv");

            StringBuilder sb = new StringBuilder();

            List<TVItem> TVItemList = (from c in db.TVItems
                                       where c.TVType == TVTypeEnum.File
                                       orderby c.TVLevel
                                       select c).AsNoTracking().ToList();


            List<int> ParentIDList = (from c in TVItemList
                                      orderby c.ParentID
                                      select (int)c.ParentID).Distinct().ToList();

            // ---------------------------------------------
            // Cleaning Local drive
            //----------------------------------------------
            
            Console.WriteLine($@"Starting local directory cleanup");
            sb.AppendLine($@"Starting local directory cleanup");

            List<DirectoryInfo> diSubList = di.GetDirectories().OrderBy(c => c.Name).ToList();

            foreach (DirectoryInfo diSub in diSubList)
            {
                int? ParentIDExist = (from c in ParentIDList
                                      where c.ToString() == diSub.Name
                                      select c).FirstOrDefault();

                if (ParentIDExist == 0)
                {
                    if (diSub.Name == "WebTide")
                    {
                        continue;
                    }

                    Console.WriteLine($@"Deleting local directory --> {diSub.Name}");
                    sb.AppendLine($@"Deleting local directory --> {diSub.Name}");

                    List<FileInfo> fiList = diSub.GetFiles().ToList();

                    foreach(FileInfo fiDel in fiList)
                    {
                        try
                        {
                            Console.WriteLine($@"     Deleting local file --> {fiDel.FullName}");
                            sb.AppendLine($@"     Deleting local file --> {fiDel.FullName}");

                            fiDel.Delete();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Could not delete local File [{fiDel.FullName}]. Error: {ex.Message}");
                            return await Task.FromResult(false);
                        }
                    }

                    try
                    {
                        diSub.Delete();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Could not delete local Directory [{diSub.FullName}]. Error: {ex.Message}");
                        return await Task.FromResult(false);
                    }

                }
            }
            Console.WriteLine($@"Ended local directory cleanup");
            sb.AppendLine($@"Ended local directory cleanup");

            // ---------------------------------------------
            // Cleaning National drive
            //----------------------------------------------

            Console.WriteLine($@"Starting national directory cleanup");
            sb.AppendLine($@"Starting national directory cleanup");
            List<DirectoryInfo> diNatSubList = diNat.GetDirectories().OrderBy(c => c.Name).ToList();

            foreach (DirectoryInfo diSub in diNatSubList)
            {
                int? ParentIDExist = (from c in ParentIDList
                                      where c.ToString() == diSub.Name
                                      select c).FirstOrDefault();

                if (ParentIDExist == 0)
                {
                    if (diSub.Name == "WebTide")
                    {
                        continue;
                    }

                    Console.WriteLine($@"Deleting national directory --> {diSub.Name}");
                    sb.AppendLine($@"Deleting national directory --> {diSub.Name}");

                    try
                    {
                        diSub.Delete(true);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Could not delete national File [{diSub.FullName}]. Error: {ex.Message}");
                        return await Task.FromResult(false);
                    }
                }
            }
            Console.WriteLine($@"Ended national directory cleanup");
            sb.AppendLine($@"Ended national directory cleanup");


            // ---------------------------------------------
            // Cleaning Azure drive
            //----------------------------------------------

            Console.WriteLine($@"Starting Azure directory cleanup");
            sb.AppendLine($@"Starting Azure directory cleanup");

            ShareClient shareClient = new ShareClient(AzureStore, AzureStoreCSSPFilesPath);
            ShareDirectoryClient directory = shareClient.GetRootDirectoryClient();

            Pageable<ShareFileItem> shareFileItemList = directory.GetFilesAndDirectories();

            foreach (ShareFileItem shareFileItem in shareFileItemList)
            {
                int? ParentIDExist = (from c in ParentIDList
                                      where c.ToString() == shareFileItem.Name
                                      select c).FirstOrDefault();

                if (ParentIDExist == 0)
                {
                    if (shareFileItem.Name == "WebTide")
                    {
                        continue;
                    }

                    Console.WriteLine($@"Deleting azure directory --> {shareFileItem.Name}");
                    sb.AppendLine($@"Deleting azure directory --> {shareFileItem.Name}");

                    if (shareFileItem.IsDirectory)
                    {
                        ShareClient shareClientSub = new ShareClient(AzureStore, AzureStoreCSSPFilesPath);
                        ShareDirectoryClient directorySub = shareClientSub.GetDirectoryClient(shareFileItem.Name);

                        if (directorySub.Exists())
                        {
                            foreach (ShareFileItem shareFileItemSub in directorySub.GetFilesAndDirectories())
                            {
                                ShareFileClient file = directorySub.GetFileClient(shareFileItemSub.Name);

                                Console.WriteLine($@"                Deleting azure file --> {shareFileItem.Name}\{shareFileItemSub.Name}");
                                sb.AppendLine($@"                Deleting azure file --> {shareFileItem.Name}\{shareFileItemSub.Name}");

                                Response<bool> responseFile = file.DeleteIfExists();

                                if (responseFile.Value)
                                {
                                    Console.WriteLine($@"                Deleted file from Azure --> {shareFileItem.Name}\{ shareFileItemSub.Name }");
                                }
                                else
                                {
                                    Console.WriteLine($@"              Error deleting from Azure --> {shareFileItem.Name}\{ shareFileItemSub.Name }");
                                }
                            }
                        }

                        Response<bool> responseDir = directorySub.DeleteIfExists();

                        if (responseDir.Value)
                        {
                            Console.WriteLine($@"              Deleted directory from Azure --> {shareFileItem.Name}");
                        }
                        else
                        {
                            Console.WriteLine($@"            Error deleting directory from Azure --> {shareFileItem.Name}");
                        }
                    }
                }
            }
            Console.WriteLine($@"Ended Azure directory cleanup");
            sb.AppendLine($@"Ended Azure directory cleanup");

            StreamWriter sw = fi.CreateText();
            sw.Write(sb.ToString());
            sw.Close();

            return await Task.FromResult(true);
        }
    }
}
