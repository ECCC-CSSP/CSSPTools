using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPEnums;
using LoggedInServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Security.Cryptography;
using Azure.Storage.Files.Shares;
using Azure;
using Azure.Storage.Files.Shares.Models;
using Microsoft.AspNetCore.Http;

namespace UploadAllFilesToAzure
{
    public partial class Startup
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        #endregion Constructors

        #region Functions private
        public bool RemoveDirectoriesNotFoundInTVFiles(string StartPathLocal, string StartPathMQEM_NATIONAL)
        {
            DirectoryInfo di = new DirectoryInfo(StartPathLocal);
            if (!di.Exists)
            {
                Console.WriteLine($"StartPathLocal does not exist {di.FullName}");
                return false;
            }

            DirectoryInfo diNat = new DirectoryInfo(StartPathMQEM_NATIONAL);
            if (!diNat.Exists)
            {
                Console.WriteLine($"StartPathMQEM_NATIONAL does not exist {diNat.FullName}");
                return false;
            }

            FileInfo fi = new FileInfo(@"C:\CSSPTools\src\codegen\UploadFilesCleanup\ListOfRemoveDirectoriesNotFoundInTVFiles.csv");

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
            sb.AppendLine($@"Starting local directory cleanup");

            List<DirectoryInfo> diSubList = di.GetDirectories().OrderBy(c => c.Name).ToList();

            foreach (DirectoryInfo diSub in diSubList)
            {
                int? ParentIDExist = (from c in ParentIDList
                                      where c.ToString() == diSub.Name
                                      select c).FirstOrDefault();

                if (ParentIDExist == null)
                {
                    sb.AppendLine($@"Deleting local directory --> {diSub.Name}");
                }
            }
            sb.AppendLine($@"Ended local directory cleanup");

            // ---------------------------------------------
            // Cleaning National drive
            //----------------------------------------------

            sb.AppendLine($@"Starting national directory cleanup");
            List<DirectoryInfo> diNatSubList = diNat.GetDirectories().OrderBy(c => c.Name).ToList();

            foreach (DirectoryInfo diSub in diNatSubList)
            {
                int? ParentIDExist = (from c in ParentIDList
                                      where c.ToString() == diSub.Name
                                      select c).FirstOrDefault();

                if (ParentIDExist == null)
                {
                    sb.AppendLine($@"Deleting national directory --> {diSub.Name}");
                }
            }
            sb.AppendLine($@"Ended national directory cleanup");

            //int count = 0;
            //total = ParentIDList.Count;
            //foreach (int ParentID in ParentIDList)
            //{
            //    ShareClient shareClient = new ShareClient(AzureStore, AzureStoreCSSPFilesPath);
            //    ShareDirectoryClient directory = shareClient.GetDirectoryClient(ParentID.ToString());

            //    count += 1;
            //    if (count % 1 == 0)
            //    {
            //        Console.WriteLine($"Count -> {count}/{total} doing ParentID {ParentID}");
            //    }

            //    DirectoryInfo diParent = new DirectoryInfo($@"{di.FullName}{ParentID}\");
            //    List<FileInfo> FileInfoList = new List<FileInfo>();
            //    if (diParent.Exists)
            //    {
            //        FileInfoList = diParent.GetFiles().ToList();
            //    }

            //    DirectoryInfo diParentNat = new DirectoryInfo($@"{diNat.FullName}{ParentID}\");
            //    List<FileInfo> FileInfoNatList = new List<FileInfo>();
            //    if (diParentNat.Exists)
            //    {
            //        FileInfoNatList = diParentNat.GetFiles().ToList();
            //    }

            //    List<ParentAndFileName> parentAndFileNameList = (from c in ParentAndFileNameList
            //                                                     where c.ParentID == ParentID
            //                                                     orderby c.ServerFileName
            //                                                     select c).ToList();

            //    foreach (ParentAndFileName parentAndFileName in parentAndFileNameList)
            //    {
            //        if (!FileInfoList.Where(c => c.Name == parentAndFileName.ServerFileName).Any())
            //        {
            //            Console.WriteLine($@"Deleting TVFile and TVItem --> {parentAndFileName.ParentID}\{parentAndFileName.ServerFileName}");
            //            sb.AppendLine($@"Deleting TVFile and TVItem --> {parentAndFileName.ParentID}\{parentAndFileName.ServerFileName}");

            //            TVItem tvItem = (from c in db.TVItems
            //                             where c.TVType == TVTypeEnum.File
            //                             && c.TVItemID == parentAndFileName.TVItemID
            //                             orderby c.TVLevel
            //                             select c).FirstOrDefault();

            //            TVFile tvFile = (from c in db.TVFiles
            //                             where c.TVFileID == parentAndFileName.TVFileID
            //                             select c).FirstOrDefault();

            //            if (tvItem != null && tvFile != null)
            //            {
            //                try
            //                {
            //                    db.TVFiles.Remove(tvFile);
            //                    db.SaveChanges();
            //                }
            //                catch (Exception ex)
            //                {
            //                    Console.WriteLine($"Could not delete TVFile with TVFileID == {parentAndFileName.TVFileID}. Error: {ex.Message}");
            //                    return false;
            //                }

            //                try
            //                {
            //                    db.TVItems.Remove(tvItem);
            //                    db.SaveChanges();
            //                }
            //                catch (Exception ex)
            //                {
            //                    Console.WriteLine($"Could not delete TVItem with TVItemID == {parentAndFileName.TVItemID}. Error: {ex.Message}");
            //                    return false;
            //                }
            //            }
            //        }
            //    }

            //    foreach (FileInfo fileInfo in FileInfoList)
            //    {
            //        if (!parentAndFileNameList.Where(c => c.ServerFileName == fileInfo.Name).Any())
            //        {
            //            Console.WriteLine($@"Deleting file on local --> {ParentID}\{fileInfo.Name}");
            //            sb.AppendLine($@"Deleting file on local --> {ParentID}\{fileInfo.Name}");

            //            try
            //            {
            //                fileInfo.Delete();
            //            }
            //            catch (Exception ex)
            //            {
            //                Console.WriteLine($"Could not delete File [{fileInfo.FullName}]. Error: {ex.Message}");
            //                return false;
            //            }

            //            // deleting the file from Azure

            //            if (directory.Exists())
            //            {
            //                ShareFileClient file = directory.GetFileClient(fileInfo.Name);

            //                Response<bool> response = file.DeleteIfExists();
            //                //Response response = directory.DeleteFile(fileInfo.Name);

            //                if (response.Value)
            //                {
            //                    Console.WriteLine($@"Deleted from Azure --> {ParentID}\{ fileInfo.Name }");
            //                }
            //                else
            //                {
            //                    Console.WriteLine($@"Error deleting from Azure --> {ParentID}\{ fileInfo.Name }");
            //                }
            //            }
            //        }
            //    }

            //    foreach (FileInfo fileInfoNat in FileInfoNatList)
            //    {
            //        if (!parentAndFileNameList.Where(c => c.ServerFileName == fileInfoNat.Name).Any())
            //        {
            //            Console.WriteLine($@"Deleting on National --> {ParentID}\{fileInfoNat.Name}");
            //            sb.AppendLine($@"Deleting on National --> {ParentID}\{fileInfoNat.Name}");

            //            try
            //            {
            //                fileInfoNat.Delete();
            //            }
            //            catch (Exception ex)
            //            {
            //                Console.WriteLine($"Could not delete File [{fileInfoNat.FullName}]. Error: {ex.Message}");
            //                return false;
            //            }
            //        }
            //    }
            //}

            StreamWriter sw = fi.CreateText();
            sw.Write(sb.ToString());
            sw.Close();

            return true;
        }
        #endregion Functions private
    }
}
