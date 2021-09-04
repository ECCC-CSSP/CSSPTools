using Azure;
using Azure.Storage.Files.Shares;
using CSSPCultureServices.Resources;
using CSSPDBModels;
using CSSPEnums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSSPUpdateServices
{
    public partial class CSSPUpdateService : ControllerBase, ICSSPUpdateService
    {
        public async Task<ActionResult<bool>> DoRemoveNationalBackupFilesNotFoundInTVFiles()
        {
            await CSSPLogService.FunctionLog(MethodBase.GetCurrentMethod().DeclaringType.Name);

            DirectoryInfo diNat = new DirectoryInfo(NationalBackupAppDataPath);
            if (!diNat.Exists)
            {
                await CSSPLogService.AppendError(new ValidationResult($"{ String.Format(CSSPCultureUpdateRes.LocalAppDataPathDoesNotExist_, diNat.FullName) }", new[] { "" }));

                await CSSPLogService.EndFunctionLog(MethodBase.GetCurrentMethod().DeclaringType.Name);

                await CSSPLogService.Save();

                return await Task.FromResult(BadRequest(CSSPLogService.ValidationResultList));
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
                    await CSSPLogService.AppendError(new ValidationResult($"{ String.Format(CSSPCultureUpdateRes.CouldNotFindTVItemForTVFile_TVFileTVItemIDEqual_, tvFile.TVFileTVItemID) }", new[] { "" }));

                    await CSSPLogService.EndFunctionLog(MethodBase.GetCurrentMethod().DeclaringType.Name);

                    await CSSPLogService.Save();

                    return await Task.FromResult(BadRequest(CSSPLogService.ValidationResultList));
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

                        await CSSPLogService.AppendLog($"{ String.Format(CSSPCultureUpdateRes.DeletingNationalFile_, DirNat) }");

                        try
                        {
                            fileInfoNat.Delete();
                        }
                        catch (Exception ex)
                        {
                            await CSSPLogService.AppendError(new ValidationResult($"{ String.Format(CSSPCultureUpdateRes.ErrorDeletingNationalFile_Error_, DirNat, ex.Message) }", new[] { "" }));

                            await CSSPLogService.EndFunctionLog(MethodBase.GetCurrentMethod().DeclaringType.Name);

                            await CSSPLogService.Save();

                            return await Task.FromResult(BadRequest(CSSPLogService.ValidationResultList));
                        }
                    }
                }
            }

            await CSSPLogService.EndFunctionLog(MethodBase.GetCurrentMethod().DeclaringType.Name);

            return await Task.FromResult(Ok(true));
        }
    }
}
