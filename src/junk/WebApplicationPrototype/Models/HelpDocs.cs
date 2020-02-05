using System;
using System.Collections.Generic;

namespace WebApplicationPrototype.Models
{
    public partial class HelpDocs
    {
        public int HelpDocID { get; set; }
        public string DocKey { get; set; }
        public int Language { get; set; }
        public string DocHTMLText { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }
    }
}
