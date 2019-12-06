using CSSPEnumsDLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
    public class TVFileModel : LastUpdateAndContactModel
    {
        public TVFileModel()
        {
        }
        public int TVFileID { get; set; }
        public int TVFileTVItemID { get; set; }
        public TVTypeEnum? TemplateTVType { get; set; }
        public int? ReportTypeID { get; set; }
        public string Parameters { get; set; }
        public int? Year { get; set; }
        public string TVFileTVText { get; set; }
        public LanguageEnum Language { get; set; }
        public FilePurposeEnum FilePurpose { get; set; }
        public FileTypeEnum FileType { get; set; }
        public string FileDescription { get; set; }
        public int FileSize_kb { get; set; }
        public string FileInfo { get; set; }
        public bool? FromWater { get; set; }
        public System.DateTime FileCreatedDate_UTC { get; set; }
        public string ClientFilePath { get; set; }
        public string ServerFileName { get; set; }
        public string ServerFilePath { get; set; }
    }

}
