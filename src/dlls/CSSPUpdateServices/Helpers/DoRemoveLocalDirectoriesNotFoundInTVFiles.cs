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
        public async Task<bool> DoRemoveLocalDirectoriesNotFoundInTVFiles()
        {
            DirectoryInfo di = new DirectoryInfo(LocalAppDataPath);
            if (!di.Exists)
            {
                Console.WriteLine($"LocalAppDataPath does not exist {di.FullName}");
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
            // Cleaning Local drive
            //----------------------------------------------
            
            Console.WriteLine($@"Starting local directory cleanup");
            sb.AppendLine($@"Starting local directory cleanup");

            List<DirectoryInfo> diSubList = di.GetDirectories().OrderBy(c => c.Name).ToList();

            foreach (DirectoryInfo diSub in diSubList)
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

                    Console.WriteLine($@"Deleting local directory --> {diSub.Name}");
                    sb.AppendLine($@"Deleting local directory --> {diSub.Name}");

                    List<FileInfo> fiList = diSub.GetFiles().ToList();

                    foreach(FileInfo fiDel in fiList)
                    {
                        try
                        {
                            Console.WriteLine($@"     Deleting local file --> {fiDel.FullName}");
                            sb.AppendLine($@"     Deleting local file --> {fiDel.FullName}");

                            fiDel.Delete();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Could not delete local File [{fiDel.FullName}]. Error: {ex.Message}");
                            return await Task.FromResult(false);
                        }
                    }

                    try
                    {
                        diSub.Delete();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Could not delete local Directory [{diSub.FullName}]. Error: {ex.Message}");
                        return await Task.FromResult(false);
                    }

                }
            }
            
            Console.WriteLine($@"Ended local directory cleanup");
            sb.AppendLine($@"Ended local directory cleanup");

            StreamWriter sw = fi.CreateText();
            sw.Write(sb.ToString());
            sw.Close();

            return await Task.FromResult(true);
        }
    }
}
