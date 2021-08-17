using Azure;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
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
        public async Task<bool> DoRemoveNationalBackupDirectoriesNotFoundInTVFiles()
        {
            LogAppend(sbLog, $"{ CSSPCultureUpdateRes.Starting } DoRemoveNationalBackupDirectoriesNotFoundInTVFiles ...");

            if (!await CheckComputerName()) return await Task.FromResult(false);

            LogAppend(sbLog, $"{ CSSPCultureUpdateRes.RunningOn } { Environment.MachineName.ToString().ToLower() }");

            DirectoryInfo diNat = new DirectoryInfo(NationalBackupAppDataPath);
            if (!diNat.Exists)
            {
                ErrorAppend(sbError, $"{ String.Format(CSSPCultureUpdateRes.LocalAppDataPathDoesNotExist_, diNat.FullName) }");

                await StoreInCommandLog(sbLog, sbError, "DoRemoveNationalBackupDirectoriesNotFoundInTVFiles");

                return await Task.FromResult(false);
            }

            List<TVItem> TVItemList = (from c in db.TVItems
                                       where c.TVType == TVTypeEnum.File
                                       orderby c.TVLevel
                                       select c).AsNoTracking().ToList();


            List<int> ParentIDList = (from c in TVItemList
                                      orderby c.ParentID
                                      select (int)c.ParentID).Distinct().ToList();

            // ---------------------------------------------
            // Cleaning National drive
            //----------------------------------------------

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

                    LogAppend(sbLog, $"{ String.Format(CSSPCultureUpdateRes.DeletingNationalDirectory_, diSub.Name) }");

                    try
                    {
                        diSub.Delete(true);
                    }
                    catch (Exception ex)
                    {
                        ErrorAppend(sbError, $"{ String.Format(CSSPCultureUpdateRes.ErrorDeletingNationalDirectory_, diSub.Name) }");
                    }
                }
            }

            LogAppend(sbLog, $"{ CSSPCultureUpdateRes.End } DoRemoveNationalBackupDirectoriesNotFoundInTVFiles ...");

            await StoreInCommandLog(sbLog, sbError, "DoRemoveNationalBackupDirectoriesNotFoundInTVFiles");

            return await Task.FromResult(true);
        }
    }
}
