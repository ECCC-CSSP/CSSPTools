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
        public async Task<bool> DoRemoveTVItemsNoAssociatedWithTVFiles()
        {
            CSSPLogService.AppendLog($"{ CSSPCultureUpdateRes.Starting } DoRemoveTVItemsNoAssociatedWithTVFiles ...");

            if (!await CheckComputerName()) return await Task.FromResult(false);

            CSSPLogService.AppendLog($"{ CSSPCultureUpdateRes.RunningOn } { Environment.MachineName.ToString().ToLower() }");

            List<TVItem> TVItemList = (from c in db.TVItems
                                       where c.TVType == TVTypeEnum.File
                                       orderby c.TVLevel
                                       select c).ToList();

            List<TVFile> TVFileList = (from c in db.TVFiles
                                       select c).ToList();

            int count = 0;
            int total = TVItemList.Count;
            foreach (TVItem tvItem in TVItemList)
            {
                count += 1;

                if (count % 1000 == 0)
                {
                    Console.WriteLine($"Count -> {count}/{total}");
                }

                if (!(TVFileList.Where(c => c.TVFileTVItemID == tvItem.TVItemID).Any()))
                {
                    string dupText = $@"{tvItem.TVItemID} --- {tvItem.ParentID}";

                    CSSPLogService.AppendLog($"{ dupText }");

                    db.TVItems.Remove(tvItem);
                }

            }

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                CSSPLogService.AppendError($"{ String.Format(CSSPCultureUpdateRes.CouldNotSaveAllRemovedTVItemsError_, ex.Message) }");
            }

            CSSPLogService.AppendLog($"{ CSSPCultureUpdateRes.End } DoRemoveTVItemsNoAssociatedWithTVFiles ...");

            await CSSPLogService.StoreInCommandLog(CSSPAppNameEnum.CSSPUpdate, CSSPCommandNameEnum.RemoveTVItemsNoAssociatedWithTVFiles);

            return await Task.FromResult(true);
        }
    }
}
