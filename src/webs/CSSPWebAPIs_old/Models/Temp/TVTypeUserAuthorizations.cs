using System;
using System.Collections.Generic;

namespace CSSPWebAPIs.Models.Temp
{
    public partial class TVTypeUserAuthorizations
    {
        public int TVTypeUserAuthorizationID { get; set; }
        public int ContactTVItemID { get; set; }
        public int TVType { get; set; }
        public int TVAuth { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual TVItems ContactTVItem { get; set; }
    }
}
