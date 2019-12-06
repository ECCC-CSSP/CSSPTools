using CSSPEnumsDLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
    public class TVItemLinkModel : LastUpdateAndContactModel
    {
        public TVItemLinkModel()
        {
        }
        public int TVItemLinkID { get; set; }
        public int FromTVItemID { get; set; }
        public string FromTVText { get; set; }
        public int ToTVItemID { get; set; }
        public string ToTVText { get; set; }
        public TVTypeEnum FromTVType { get; set; }
        public TVTypeEnum ToTVType { get; set; }
        public Nullable<System.DateTime> StartDateTime_Local { get; set; }
        public Nullable<System.DateTime> EndDateTime_Local { get; set; }
        public int Ordinal { get; set; }
        public int TVLevel { get; set; }
        public string TVPath { get; set; }
        public Nullable<int> ParentTVItemLinkID { get; set; }
    }
}
