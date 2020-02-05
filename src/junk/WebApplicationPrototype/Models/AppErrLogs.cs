using System;
using System.Collections.Generic;

namespace WebApplicationPrototype.Models
{
    public partial class AppErrLogs
    {
        public int AppErrLogID { get; set; }
        public string Tag { get; set; }
        public int LineNumber { get; set; }
        public string Source { get; set; }
        public string Message { get; set; }
        public DateTime DateTime_UTC { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }
    }
}
