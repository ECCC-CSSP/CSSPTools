using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSSPEnumsDLL.Enums;

namespace CSSPModelsDLL.Models
{
   public class MWQMSiteModel : LastUpdateAndContactModel
    {
       public MWQMSiteModel()
       {
       }
       public int MWQMSiteID { get; set; }
       public int MWQMSiteTVItemID { get; set; }
       public string MWQMSiteTVText { get; set; }
       public string MWQMSiteNumber { get; set; }
       public string MWQMSiteDescription { get; set; }
       public MWQMSiteLatestClassificationEnum MWQMSiteLatestClassification { get; set; }
       public int Ordinal { get; set; }
    }

}
