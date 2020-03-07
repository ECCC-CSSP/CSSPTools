using System;
using System.Collections.Generic;

namespace CSSPWebAPIs.Models.Temp
{
    public partial class AppTaskLanguages
    {
        public int AppTaskLanguageID { get; set; }
        public int AppTaskID { get; set; }
        public int Language { get; set; }
        public string StatusText { get; set; }
        public string ErrorText { get; set; }
        public int TranslationStatus { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual AppTasks AppTask { get; set; }
    }
}
