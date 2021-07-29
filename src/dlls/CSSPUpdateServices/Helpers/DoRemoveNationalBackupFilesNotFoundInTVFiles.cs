using Azure;
using Azure.Storage.Files.Shares;
using CSSPDBModels;
using CSSPEnums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPUpdateServices
{
    public partial class CSSPUpdateService : ICSSPUpdateService
    {
        public async Task<bool> DoRemoveNationalBackupFilesNotFoundInTVFiles()
        {
            DirectoryInfo diNat = new DirectoryInfo(NationalBackupAppDataPath);
            if (!diNat.Exists)
            {
                Console.WriteLine($"NationalBackupAppDataPath does not exist {diNat.FullName}");
                return await Task.FromResult(false);
            }

            FileInfo fi = new FileInfo(@"C:\CSSPTools\src\webs\CSSPUpdateAll\ListOfRemoveFilesNotFoundInTVFiles.csv");

            StringBuilder sb = new StringBuilder();

            List<TVItem> TVItemList = (from c in db.TVItems
                                       where c.TVType == TVTypeEnum.File
                                       orderby c.TVLevel
                                       select c).AsNoTracking().ToList();

            List<TVFile> TVFileList = (from c in db.TVFiles
                                       select c).AsNoTracking().ToList();

            List<ParentAndFileName> ParentAndFileNameList = new List<ParentAndFileName>();

            int count = 0;
            int total = TVFileList.Count;
            foreach (TVFile tvFile in TVFileList)
            {
                count += 1;
                if (count % 1000 == 0)
                {
                    Console.WriteLine($"Count -> {count}/{total}");
                }

                TVItem tvItem = TVItemList.Where(c => c.TVItemID == tvFile.TVFileTVItemID).FirstOrDefault();
                if (tvItem == null)
                {
                    Console.WriteLine($"Could not find tvItem for tvFile.TVFileTVItemID -> {tvFile.TVFileTVItemID}");
                    return await Task.FromResult(false);
                }


                ParentAndFileNameList.Add(new ParentAndFileName() { ParentID = (int)tvItem.ParentID, ServerFileName = tvFile.ServerFileName, TVFileID = tvFile.TVFileID, TVItemID = tvFile.TVFileTVItemID });
            }

            List<int> ParentIDList = (from c in ParentAndFileNameList
                                      //where c.ParentID == 1
                                      orderby c.ParentID
                                      select c.ParentID).Distinct().ToList();


            count = 0;
            total = ParentIDList.Count;
            foreach (int ParentID in ParentIDList)
            {
                count += 1;
                if (count % 1 == 0)
                {
                    Console.WriteLine($"Count -> {count}/{total} doing ParentID {ParentID}");
                }

                DirectoryInfo diParentNat = new DirectoryInfo($@"{diNat.FullName}{ParentID}\");
                List<FileInfo> FileInfoNatList = new List<FileInfo>();
                if (diParentNat.Exists)
                {
                    FileInfoNatList = diParentNat.GetFiles().ToList();
                }

                List<ParentAndFileName> parentAndFileNameList = (from c in ParentAndFileNameList
                                                                 where c.ParentID == ParentID
                                                                 orderby c.ServerFileName
                                                                 select c).ToList();

                foreach (FileInfo fileInfoNat in FileInfoNatList)
                {
                    if (!parentAndFileNameList.Where(c => c.ServerFileName == fileInfoNat.Name).Any())
                    {
                        Console.WriteLine($@"Deleting on National --> {ParentID}\{fileInfoNat.Name}");
                        sb.AppendLine($@"Deleting on National --> {ParentID}\{fileInfoNat.Name}");

                        try
                        {
                            fileInfoNat.Delete();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Could not delete File [{fileInfoNat.FullName}]. Error: {ex.Message}");
                            return await Task.FromResult(false);
                        }
                    }
                }
            }

            StreamWriter sw = fi.CreateText();
            sw.Write(sb.ToString());
            sw.Close();

            return await Task.FromResult(true);
        }
    }
}
