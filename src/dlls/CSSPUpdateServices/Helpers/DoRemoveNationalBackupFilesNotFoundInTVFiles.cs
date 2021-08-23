using Azure;
using Azure.Storage.Files.Shares;
using CSSPCultureServices.Resources;
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
            CSSPLogService.AppendLog($"{ CSSPCultureUpdateRes.Starting } DoRemoveNationalBackupFilesNotFoundInTVFiles ...");

            if (!await CheckComputerName()) return await Task.FromResult(false);

            CSSPLogService.AppendLog($"{ CSSPCultureUpdateRes.RunningOn } { Environment.MachineName.ToString().ToLower() }");

            DirectoryInfo diNat = new DirectoryInfo(NationalBackupAppDataPath);
            if (!diNat.Exists)
            {
                CSSPLogService.AppendError($"{ String.Format(CSSPCultureUpdateRes.LocalAppDataPathDoesNotExist_, diNat.FullName) }");

                await CSSPLogService.StoreInCommandLog(CSSPAppNameEnum.CSSPUpdate, CSSPCommandNameEnum.RemoveNationalBackupFilesNotFoundInTVFiles);

                return await Task.FromResult(false);
            }

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
                    CSSPLogService.AppendError($"{ String.Format(CSSPCultureUpdateRes.CouldNotFindTVItemForTVFile_TVFileTVItemIDEqual_, tvFile.TVFileTVItemID) }");

                    await CSSPLogService.StoreInCommandLog(CSSPAppNameEnum.CSSPUpdate, CSSPCommandNameEnum.RemoveNationalBackupFilesNotFoundInTVFiles);

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
                        string DirNat = $@"{ParentID}\{fileInfoNat.Name}";

                        CSSPLogService.AppendLog($"{ String.Format(CSSPCultureUpdateRes.DeletingNationalFile_, DirNat) }");

                        try
                        {
                            fileInfoNat.Delete();
                        }
                        catch (Exception ex)
                        {
                            CSSPLogService.AppendError($"{ String.Format(CSSPCultureUpdateRes.ErrorDeletingNationalFile_Error_, DirNat, ex.Message) }");
                        }
                    }
                }
            }

            CSSPLogService.AppendLog($"{ CSSPCultureUpdateRes.End } DoRemoveNationalBackupFilesNotFoundInTVFiles ...");

            await CSSPLogService.StoreInCommandLog(CSSPAppNameEnum.CSSPUpdate, CSSPCommandNameEnum.RemoveNationalBackupFilesNotFoundInTVFiles);

            return await Task.FromResult(true);
        }
    }
}
