using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
   public class MWQMSiteStartEndDateModel : LastUpdateAndContactModel
    {
       public MWQMSiteStartEndDateModel()
       {
       }
       public int MWQMSiteStartEndDateID { get; set; }
       public int MWQMSiteTVItemID { get; set; }
       public DateTime StartDate { get; set; }
       public DateTime? EndDate { get; set; }
    }
}
