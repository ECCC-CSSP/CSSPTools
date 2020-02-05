using System;
using System.Collections.Generic;

namespace WebAPIPrototype.Models
{
    public partial class DocTemplates
    {
        public int DocTemplateID { get; set; }
        public int Language { get; set; }
        public int TVType { get; set; }
        public int TVFileTVItemID { get; set; }
        public string FileName { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual TVItems TVFileTVItem { get; set; }
    }
}
