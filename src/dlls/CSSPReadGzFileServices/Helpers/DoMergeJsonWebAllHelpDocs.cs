/*
 * Manually edited
 * 
 */
using CSSPDBModels;
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ReadGzFileServices
{
    public partial class ReadGzFileService : ControllerBase, IReadGzFileService
    {
        private void DoMergeJsonWebAllHelpDocs(WebAllHelpDocs WebAllHelpDocs, WebAllHelpDocs WebAllHelpDocsLocal)
        {
            List<HelpDoc> helpDocLocalList = (from c in WebAllHelpDocsLocal.HelpDocList
                                                    where c.DBCommand != DBCommandEnum.Original
                                                    select c).ToList();

            foreach (HelpDoc helpDocLocal in helpDocLocalList)
            {
                HelpDoc helpDocOriginal = WebAllHelpDocs.HelpDocList.Where(c => c.HelpDocID == helpDocLocal.HelpDocID).FirstOrDefault();
                if (helpDocOriginal == null)
                {
                    WebAllHelpDocs.HelpDocList.Add(helpDocLocal);
                }
                else
                {
                    helpDocOriginal = helpDocLocal;
                }
            }
        }
    }
}
