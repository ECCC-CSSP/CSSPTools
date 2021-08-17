using CSSPCultureServices.Resources;
using CSSPDBModels;
using CSSPEnums;
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
        public async Task<bool> DoRemoveTVFilesDoubleAssociatedWithTVItemsTypeFile()
        {
            LogAppend(sbLog, $"{ CSSPCultureUpdateRes.Starting } DoRemoveTVFilesDoubleAssociatedWithTVItemsTypeFile ...");

            if (!await CheckComputerName()) return await Task.FromResult(false);

            LogAppend(sbLog, $"{ CSSPCultureUpdateRes.RunningOn } { Environment.MachineName.ToString().ToLower() }");

            List<TVItem> TVItemList = (from c in db.TVItems
                                       where c.TVType == TVTypeEnum.File
                                       orderby c.TVLevel
                                       select c).ToList();

            List<TVFile> TVFileList = (from c in db.TVFiles
                                       orderby c.TVFileTVItemID
                                       select c).ToList();

            for (int i = 0, count = TVFileList.Count - 1; i < count; i++)
            {
                if (TVFileList[i].TVFileTVItemID == TVFileList[i + 1].TVFileTVItemID)
                {
                    string dupText = $@"{TVFileList[i].TVFileTVItemID} -- {TVFileList[i].ServerFileName} -- {TVFileList[i + 1].ServerFileName}";

                    LogAppend(sbLog, $"{ String.Format(CSSPCultureUpdateRes.DuplicateTVFileTVItemID, dupText) }");

                    db.TVFiles.Remove(TVFileList[i + 1]);
                }
            }

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                ErrorAppend(sbError, $"{ String.Format(CSSPCultureUpdateRes.CouldNotSaveAllRemovedTVItemsError_, ex.Message) }");
            }

            LogAppend(sbLog, $"{ CSSPCultureUpdateRes.End } DoRemoveTVFilesDoubleAssociatedWithTVItemsTypeFile ...");

            await StoreInCommandLog(sbLog, sbError, "DoRemoveTVFilesDoubleAssociatedWithTVItemsTypeFile");

            return await Task.FromResult(true);
        }
    }
}
