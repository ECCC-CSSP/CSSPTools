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
        public async Task<bool> DoRemoveLocalFilesNotFoundInTVFiles()
        {
            DirectoryInfo di = new DirectoryInfo(LocalAppDataPath);
            if (!di.Exists)
            {
                Console.WriteLine($"LocalAppDataPath does not exist {di.FullName}");
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

                DirectoryInfo diParent = new DirectoryInfo($@"{di.FullName}{ParentID}\");
                List<FileInfo> FileInfoList = new List<FileInfo>();
                if (diParent.Exists)
                {
                    FileInfoList = diParent.GetFiles().ToList();
                }

                List<ParentAndFileName> parentAndFileNameList = (from c in ParentAndFileNameList
                                                                 where c.ParentID == ParentID
                                                                 orderby c.ServerFileName
                                                                 select c).ToList();

                foreach (ParentAndFileName parentAndFileName in parentAndFileNameList)
                {
                    if (!FileInfoList.Where(c => c.Name == parentAndFileName.ServerFileName).Any())
                    {
                        Console.WriteLine($@"Deleting TVFile and TVItem --> {parentAndFileName.ParentID}\{parentAndFileName.ServerFileName}");
                        sb.AppendLine($@"Deleting TVFile and TVItem --> {parentAndFileName.ParentID}\{parentAndFileName.ServerFileName}");

                        TVItem tvItem = (from c in db.TVItems
                                         where c.TVType == TVTypeEnum.File
                                         && c.TVItemID == parentAndFileName.TVItemID
                                         orderby c.TVLevel
                                         select c).FirstOrDefault();

                        TVFile tvFile = (from c in db.TVFiles
                                         where c.TVFileID == parentAndFileName.TVFileID
                                         select c).FirstOrDefault();

                        if (tvItem != null && tvFile != null)
                        {
                            try
                            {
                                db.TVFiles.Remove(tvFile);
                                db.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Could not delete TVFile with TVFileID == {parentAndFileName.TVFileID}. Error: {ex.Message}");
                                return await Task.FromResult(false);
                            }

                            try
                            {
                                db.TVItems.Remove(tvItem);
                                db.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Could not delete TVItem with TVItemID == {parentAndFileName.TVItemID}. Error: {ex.Message}");
                                return await Task.FromResult(false);
                            }
                        }
                    }
                }

                foreach (FileInfo fileInfo in FileInfoList)
                {
                    if (!parentAndFileNameList.Where(c => c.ServerFileName == fileInfo.Name).Any())
                    {
                        Console.WriteLine($@"Deleting file on local --> {ParentID}\{fileInfo.Name}");
                        sb.AppendLine($@"Deleting file on local --> {ParentID}\{fileInfo.Name}");

                        try
                        {
                            fileInfo.Delete();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Could not delete File [{fileInfo.FullName}]. Error: {ex.Message}");
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
