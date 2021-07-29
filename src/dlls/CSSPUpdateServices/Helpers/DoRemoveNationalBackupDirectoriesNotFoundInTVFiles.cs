using Azure;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
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
            DirectoryInfo diNat = new DirectoryInfo(NationalBackupAppDataPath);
            if (!diNat.Exists)
            {
                Console.WriteLine($"NationalBackupAppDataPath does not exist {diNat.FullName}");
                return await Task.FromResult(false);
            }

            FileInfo fi = new FileInfo(@"C:\CSSPTools\src\webs\CSSPUpdateAll\ListOfRemoveDirectoriesNotFoundInTVFiles.csv");

            StringBuilder sb = new StringBuilder();

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

            Console.WriteLine($@"Starting national directory cleanup");
            sb.AppendLine($@"Starting national directory cleanup");
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

                    Console.WriteLine($@"Deleting national directory --> {diSub.Name}");
                    sb.AppendLine($@"Deleting national directory --> {diSub.Name}");

                    try
                    {
                        diSub.Delete(true);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Could not delete national File [{diSub.FullName}]. Error: {ex.Message}");
                        return await Task.FromResult(false);
                    }
                }
            }
          
            Console.WriteLine($@"Ended national directory cleanup");
            sb.AppendLine($@"Ended national directory cleanup");

            StreamWriter sw = fi.CreateText();
            sw.Write(sb.ToString());
            sw.Close();

            return await Task.FromResult(true);
        }
    }
}
