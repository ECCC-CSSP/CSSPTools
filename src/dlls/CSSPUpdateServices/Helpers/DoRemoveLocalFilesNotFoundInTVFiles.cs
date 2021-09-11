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
        public async Task<ActionResult<bool>> DoRemoveLocalFilesNotFoundInTVFiles()
        {
            CSSPLogService.FunctionLog(MethodBase.GetCurrentMethod().DeclaringType.Name);

            DirectoryInfo di = new DirectoryInfo(LocalAppDataPath);
            if (!di.Exists)
            {
                CSSPLogService.AppendError(new ValidationResult($"{ String.Format(CSSPCultureUpdateRes.LocalAppDataPathDoesNotExist_, di.FullName) }", new[] { "" }));

                CSSPLogService.EndFunctionLog(MethodBase.GetCurrentMethod().DeclaringType.Name);

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
                    CSSPLogService.AppendError(new ValidationResult($"{ String.Format(CSSPCultureUpdateRes.CouldNotFindTVItemForTVFile_TVFileTVItemIDEqual_, tvFile.TVFileTVItemID) }", new[] { "" }));

                    CSSPLogService.EndFunctionLog(MethodBase.GetCurrentMethod().DeclaringType.Name);

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
                        string ParentIDFileName = $@"{parentAndFileName.ParentID}\{parentAndFileName.ServerFileName}";

                        CSSPLogService.AppendLog($"{ String.Format(CSSPCultureUpdateRes.DeletingTVFileAndTVItem_, ParentIDFileName) }");

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
                                CSSPLogService.AppendError(new ValidationResult($"{ String.Format(CSSPCultureUpdateRes.CouldNotDeleteTVFileWithTVFileID_Error_, parentAndFileName.TVFileID, ex.Message) }", new[] { "" }));

                                CSSPLogService.EndFunctionLog(MethodBase.GetCurrentMethod().DeclaringType.Name);

                                await CSSPLogService.Save();

                                return await Task.FromResult(BadRequest(CSSPLogService.ValidationResultList));
                            }

                            try
                            {
                                db.TVItems.Remove(tvItem);
                                db.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                CSSPLogService.AppendError(new ValidationResult($"{ String.Format(CSSPCultureUpdateRes.CouldNotDeleteTVItemWithTVItemID_Error_, parentAndFileName.TVItemID, ex.Message) }", new[] { "" }));

                                CSSPLogService.EndFunctionLog(MethodBase.GetCurrentMethod().DeclaringType.Name);

                                await CSSPLogService.Save();

                                return await Task.FromResult(BadRequest(CSSPLogService.ValidationResultList));
                            }
                        }
                    }
                }

                foreach (FileInfo fileInfo in FileInfoList)
                {
                    if (!parentAndFileNameList.Where(c => c.ServerFileName == fileInfo.Name).Any())
                    {
                        CSSPLogService.AppendLog($"{ String.Format(CSSPCultureUpdateRes.DeletingLocalFile_, fileInfo.FullName) }");

                        try
                        {
                            fileInfo.Delete();
                        }
                        catch (Exception ex)
                        {
                            CSSPLogService.AppendError(new ValidationResult($"{ String.Format(CSSPCultureUpdateRes.ErrorDeletingLocalFile_Error_, fileInfo.FullName, ex.Message) }", new[] { "" }));

                            CSSPLogService.EndFunctionLog(MethodBase.GetCurrentMethod().DeclaringType.Name);

                            await CSSPLogService.Save();

                            return await Task.FromResult(BadRequest(CSSPLogService.ValidationResultList));
                        }
                    }
                }
            }

            CSSPLogService.EndFunctionLog(MethodBase.GetCurrentMethod().DeclaringType.Name);

            return await Task.FromResult(Ok(true));

        }
    }
}
