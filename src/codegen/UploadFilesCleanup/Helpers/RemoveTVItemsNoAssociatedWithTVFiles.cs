using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPEnums;
using CSSPLocalLoggedInServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace UploadAllFilesToAzure
{
    public partial class Startup
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        #endregion Constructors

        #region Functions private
        public bool RemoveTVItemsNoAssociatedWithTVFiles()
        {
            FileInfo fi = new FileInfo(@"C:\CSSPTools\src\codegen\UploadFilesCleanup\ListOfTVItemsRemoved.csv");

            StringBuilder sb = new StringBuilder();

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
                    sb.Append($"{tvItem.TVItemID},{tvItem.ParentID}\r\n");
                    Console.WriteLine($"{count}/{total} --- {tvItem.TVItemID} --- {tvItem.ParentID}");

                    db.TVItems.Remove(tvItem);
                }

            }


            StreamWriter sw = fi.CreateText();
            sw.Write(sb.ToString());
            sw.Close();

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not save all removed TVItems. {ex.Message}");
            }

            return true;
        }
        #endregion Functions private
    }
}
