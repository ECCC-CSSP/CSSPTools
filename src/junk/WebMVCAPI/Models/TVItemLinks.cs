using System;
using System.Collections.Generic;

namespace WebMVCAPI.Models
{
    public partial class TVItemLinks
    {
        public TVItemLinks()
        {
            InverseParentTVItemLink = new HashSet<TVItemLinks>();
        }

        public int TVItemLinkID { get; set; }
        public int FromTVItemID { get; set; }
        public int ToTVItemID { get; set; }
        public int FromTVType { get; set; }
        public int ToTVType { get; set; }
        public DateTime? StartDateTime_Local { get; set; }
        public DateTime? EndDateTime_Local { get; set; }
        public int Ordinal { get; set; }
        public int TVLevel { get; set; }
        public string TVPath { get; set; }
        public int? ParentTVItemLinkID { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual TVItems FromTVItem { get; set; }
        public virtual TVItemLinks ParentTVItemLink { get; set; }
        public virtual TVItems ToTVItem { get; set; }
        public virtual ICollection<TVItemLinks> InverseParentTVItemLink { get; set; }
    }
}
