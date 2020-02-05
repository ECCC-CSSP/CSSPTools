using System;
using System.Collections.Generic;

namespace WebAPIPrototype.Models
{
    public partial class TVItemUserAuthorizations
    {
        public int TVItemUserAuthorizationID { get; set; }
        public int ContactTVItemID { get; set; }
        public int TVItemID1 { get; set; }
        public int? TVItemID2 { get; set; }
        public int? TVItemID3 { get; set; }
        public int? TVItemID4 { get; set; }
        public int TVAuth { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual TVItems ContactTVItem { get; set; }
        public virtual TVItems TVItemID1Navigation { get; set; }
    }
}
