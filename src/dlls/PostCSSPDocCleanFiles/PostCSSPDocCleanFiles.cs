using CSSPGenerateCodeBase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostCSSPDoc
{
    public partial class PostCSSPDocCleanFiles : GenerateCodeBase
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public PostCSSPDocCleanFiles()
        {
        }
        #endregion Constructors

        #region Events
        #endregion Events

        #region Functions public
        public void CleanFiles()
        {
            if (!RemoveUnneededSectionFromToc_html())
            {
                StatusPermanentEvent(new StatusEventArgs("\r\nCSSPError..."));
                return;
            }

            if (!DeleteUnneededFilesFromSiteApi())
            {
                StatusPermanentEvent(new StatusEventArgs("\r\nCSSPError..."));
                return;
            }

            if (!ReplaceLogoSVG())
            {
                StatusPermanentEvent(new StatusEventArgs("\r\nCSSPError..."));
                return;
            }

            if (!ReplaceFavIcon())
            {
                StatusPermanentEvent(new StatusEventArgs("\r\nCSSPError..."));
                return;
            }

            StatusPermanentEvent(new StatusEventArgs("\r\nDone..."));
        }
        #endregion Functions public

        #region Functions private
        private bool DeleteUnneededFilesFromSiteApi()
        {
            string baseDiretory = @"C:\CSSPTools\src\web\CSSPCodeDocs\_site\api\";
            List<string> DeleteFileList = new List<string>()
            {
                "CSSPWebAPI.ApplicationUserManager", "CSSPWebAPI.BundleConfig", "CSSPWebAPI.FilterConfig", "CSSPWebAPI",
                "CSSPWebAPI.RouteConfig", "CSSPWebAPI.Startup", "CSSPWebAPI.WebApiApplication", "CSSPWebAPI.WebApiConfig"
            };
            List<string> DeleteStartWithFileList = new List<string>()
            {
                "CSSPEnums.Resources", "CSSPModels.Resources", "CSSPServices.Resources", "CSSPWebAPI.Models",
                "CSSPWebAPI.Providers", "CSSPWebAPI.Results",
            };

            foreach (string fileName in DeleteFileList)
            {
                FileInfo fi = new FileInfo($"{baseDiretory}{fileName}.html");

                if (fi.Exists)
                {
                    try
                    {
                        StatusPermanentEvent(new StatusEventArgs($"Deleting [{ fi.FullName }]"));
                        fi.Delete();
                        StatusPermanentEvent(new StatusEventArgs($"Deleted [{ fi.FullName }]"));
                    }
                    catch (Exception)
                    {
                        StatusPermanentEvent(new StatusEventArgs($"Could not delete [{ fi.FullName }]"));
                        return false;
                    }
                }
            }

            foreach (string PartialDirectoryName in DeleteStartWithFileList)
            {
                DirectoryInfo di = new DirectoryInfo($@"{ baseDiretory }");

                List<FileInfo> fiList = di.GetFiles().ToList();
                foreach (FileInfo fi in fiList)
                {
                    if (fi.Name.StartsWith($"{ PartialDirectoryName }"))
                    {
                        try
                        {
                            StatusPermanentEvent(new StatusEventArgs($"Deleting [{ fi.FullName }]"));
                            fi.Delete();
                            StatusPermanentEvent(new StatusEventArgs($"Deleted [{ fi.FullName }]"));
                        }
                        catch (Exception)
                        {
                            StatusPermanentEvent(new StatusEventArgs($"Could not delete [{ fi.FullName }]"));
                            return false; ;
                        }
                    }
                }
            }

            return true;
        }
        private bool RemoveUnneededSectionFromToc_html()
        {
            string File = @"C:\CSSPTools\src\web\CSSPCodeDocs\_site\api\toc.html";
            List<string> File1LineList = new List<string>();

            List<string> SectionToDeleteList = new List<string>()
            {
                "CSSPEnums.Resources", "CSSPModels.Resources", "CSSPServices.Resources", "CSSPWebAPI",
                "CSSPWebAPI.Models", "CSSPWebAPI.Providers", "CSSPWebAPI.Results"
            };
            List<int> LineIndexToRemoveList = new List<int>();

            FileInfo fi = new FileInfo(File);

            if (!fi.Exists)
            {
                StatusPermanentEvent(new StatusEventArgs($"Could not find [{ File }]"));
                return false;
            }

            StatusPermanentEvent(new StatusEventArgs($"Reading [{ File }]..."));
            StreamReader sr = fi.OpenText();
            while (!sr.EndOfStream)
            {
                File1LineList.Add(sr.ReadLine());
            }
            sr.Close();
            StatusPermanentEvent(new StatusEventArgs($"Read [{ File }]"));

            for (int i = 0, countA = File1LineList.Count - 1; i < countA; i++)
            {
                if (File1LineList[i] == "                <li>")
                {
                    bool ShouldDelete = false;
                    foreach (string section in SectionToDeleteList)
                    {
                        if (File1LineList[i + 2].Contains($@"title=""{ section }"">{ section }</a>"))
                        {
                            ShouldDelete = true;
                            break;
                        }
                    }

                    if (ShouldDelete)
                    {
                        for (int j = i, countB = File1LineList.Count - 1; j < countB; j++)
                        {
                            if (File1LineList[j] == "                </li>")
                            {
                                for (int k = i; k < j + 1; k++)
                                {
                                    LineIndexToRemoveList.Add(k);
                                }
                                i = j;
                                break;
                            }
                        }
                    }
                }
            }

            try
            {
                StatusPermanentEvent(new StatusEventArgs($"Copying [{ File }] to[{ File.Replace(".html", "_original.html") }]"));
                fi.CopyTo(File.Replace(".html", "_original.html"), true);
                StatusPermanentEvent(new StatusEventArgs($"Copied [{ File }] to[{ File.Replace(".html", "_original.html") }]"));
            }
            catch (Exception)
            {
                StatusPermanentEvent(new StatusEventArgs($"Could not copy [{ File }] to [{ File.Replace(".html", "_original.html") }]"));
                return false;
            }
       
            try
            {
                StatusPermanentEvent(new StatusEventArgs($"Deleting  [{ File }]"));
                fi.Delete();
                StatusPermanentEvent(new StatusEventArgs($"Deleted  [{ File }]"));
            }
            catch (Exception)
            {
                StatusPermanentEvent(new StatusEventArgs($"Could not delete [{ File }]"));
                return false;
            }
            
            StatusPermanentEvent(new StatusEventArgs($"Creating [{ File }]"));
            StreamWriter sw = fi.CreateText();
            for (int i = 0, countA = File1LineList.Count - 1; i < countA; i++)
            {
                if (!LineIndexToRemoveList.Contains(i))
                {
                    sw.WriteLine(File1LineList[i]);
                }
            }
            sw.Close();
            StatusPermanentEvent(new StatusEventArgs($"Created [{ File }]"));

            try
            {
                StatusPermanentEvent(new StatusEventArgs($"Deleting  [{ File.Replace(".html", "_original.html") }]"));
                FileInfo fiToDelete = new FileInfo(File.Replace(".html", "_original.html"));
                fiToDelete.Delete();
                StatusPermanentEvent(new StatusEventArgs($"Deleted  [{ File.Replace(".html", "_original.html") }]"));
            }
            catch (Exception)
            {
                StatusPermanentEvent(new StatusEventArgs($"Could not delete [{ File.Replace(".html", "_original.html") }]"));
                return false;
            }

            return true;
        }
        private bool ReplaceLogoSVG()
        {
            string FileNameNew = @"C:\CSSPTools\src\web\CSSPCodeDocs\logo.svg";
            string FileNameOriginal = @"C:\CSSPTools\src\web\CSSPCodeDocs\_site\logo.svg";

            FileInfo fiLogoNew = new FileInfo(FileNameNew);

            if (!fiLogoNew.Exists)
            {
                StatusPermanentEvent(new StatusEventArgs($"Could not find [{ fiLogoNew.FullName }]"));
                return false;
            }

            try
            {
                StatusPermanentEvent(new StatusEventArgs($"Copying [{ FileNameNew }] to  [{ FileNameOriginal }]"));
                fiLogoNew.CopyTo(FileNameOriginal, true);
                StatusPermanentEvent(new StatusEventArgs($"Copied [{ FileNameNew }] to  [{ FileNameOriginal }]"));
            }
            catch (Exception)
            {
                StatusPermanentEvent(new StatusEventArgs($"Could not copy [{ FileNameNew }] to  [{ FileNameOriginal }]"));
                return false;
            }

            return true;
        }
        private bool ReplaceFavIcon()
        {
            string FileNameNew = @"C:\CSSPTools\src\web\CSSPCodeDocs\favicon.ico";
            string FileNameOriginal = @"C:\CSSPTools\src\web\CSSPCodeDocs\_site\favicon.ico";

            FileInfo fiLogoNew = new FileInfo(FileNameNew);

            if (!fiLogoNew.Exists)
            {
                StatusPermanentEvent(new StatusEventArgs($"Could not find [{ fiLogoNew.FullName }]"));
                return false;
            }

            try
            {
                StatusPermanentEvent(new StatusEventArgs($"Copying [{ FileNameNew }] to  [{ FileNameOriginal }]"));
                fiLogoNew.CopyTo(FileNameOriginal, true);
                StatusPermanentEvent(new StatusEventArgs($"Copied [{ FileNameNew }] to  [{ FileNameOriginal }]"));
            }
            catch (Exception)
            {
                StatusPermanentEvent(new StatusEventArgs($"Could not copy [{ FileNameNew }] to  [{ FileNameOriginal }]"));
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
