using CSSPCultureServices.Resources;
using CSSPDBModels;
using CSSPEnums;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<bool>> DoRemoveTVItemsNoAssociatedWithTVFiles()
        {
            CSSPLogService.FunctionLog(MethodBase.GetCurrentMethod().DeclaringType.Name);

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
                CSSPLogService.AppendError(new ValidationResult($"{ String.Format(CSSPCultureUpdateRes.CouldNotSaveAllRemovedTVItemsError_, ex.Message) }", new[] { "" }));

                CSSPLogService.EndFunctionLog(MethodBase.GetCurrentMethod().DeclaringType.Name);

                await CSSPLogService.Save();

                return await Task.FromResult(BadRequest(CSSPLogService.ValidationResultList));
            }

            CSSPLogService.EndFunctionLog(MethodBase.GetCurrentMethod().DeclaringType.Name);

            return await Task.FromResult(Ok(true));
        }
    }
}
