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
        public bool RemoveTVFilesDoubleAssociatedWithTVItemsTypeFile()
        {
            FileInfo fi = new FileInfo(@"C:\CSSPTools\src\codegen\UploadFilesCleanup\ListOfDuplicateTVFilesRemoved.csv");

            StringBuilder sb = new StringBuilder();

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
                    Console.WriteLine($"duplicate TVFileTVItemID ---> {TVFileList[i].TVFileTVItemID} -- {TVFileList[i].ServerFileName} -- {TVFileList[i + 1].ServerFileName}");
                    sb.AppendLine($"duplicate TVFileTVItemID ---> {TVFileList[i].TVFileTVItemID} -- {TVFileList[i].ServerFileName} -- {TVFileList[i + 1].ServerFileName}");
                    db.TVFiles.Remove(TVFileList[i + 1]);
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
