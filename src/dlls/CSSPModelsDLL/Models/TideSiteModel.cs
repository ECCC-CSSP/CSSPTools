using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
    public class TideSiteModel : LastUpdateAndContactModel
    {
        public TideSiteModel()
        {
        }
        public int TideSiteID { get; set; }
        public int TideSiteTVItemID { get; set; }
        public string TideSiteName { get; set; }
        public string Province { get; set; }
        public int sid { get; set; }
        public int Zone { get; set; }
    }
}
