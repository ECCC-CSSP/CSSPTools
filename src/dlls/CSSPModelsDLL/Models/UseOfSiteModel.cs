using CSSPEnumsDLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
    public class UseOfSiteModel : LastUpdateAndContactModel
    {
        public UseOfSiteModel()
        {
        }
        public int UseOfSiteID { get; set; }
        public int SiteTVItemID { get; set; }
        public string SiteTVText { get; set; }
        public int SubsectorTVItemID { get; set; }
        public string SubsectorTVText { get; set; }
        public TVTypeEnum TVType { get; set; }
        public int Ordinal { get; set; }
        public int StartYear { get; set; }
        public Nullable<int> EndYear { get; set; }
        public Nullable<bool> UseWeight { get; set; }
        public Nullable<double> Weight_perc { get; set; }
        public Nullable<bool> UseEquation { get; set; }
        public Nullable<double> Param1 { get; set; }
        public Nullable<double> Param2 { get; set; }
        public Nullable<double> Param3 { get; set; }
        public Nullable<double> Param4 { get; set; }

    }
}
