using System;
using System.Collections.Generic;

namespace WebAPIPrototype.Models
{
    public partial class TVFiles
    {
        public TVFiles()
        {
            TVFileLanguages = new HashSet<TVFileLanguages>();
        }

        public int TVFileID { get; set; }
        public int TVFileTVItemID { get; set; }
        public int? TemplateTVType { get; set; }
        public int? ReportTypeID { get; set; }
        public string Parameters { get; set; }
        public int? Year { get; set; }
        public int Language { get; set; }
        public int FilePurpose { get; set; }
        public int FileType { get; set; }
        public int FileSize_kb { get; set; }
        public string FileInfo { get; set; }
        public DateTime FileCreatedDate_UTC { get; set; }
        public bool? FromWater { get; set; }
        public string ClientFilePath { get; set; }
        public string ServerFileName { get; set; }
        public string ServerFilePath { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual TVItems TVFileTVItem { get; set; }
        public virtual ICollection<TVFileLanguages> TVFileLanguages { get; set; }
    }
}
