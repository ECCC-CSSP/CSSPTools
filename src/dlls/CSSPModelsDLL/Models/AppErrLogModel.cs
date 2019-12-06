using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
    public class AppErrLogModel : LastUpdateAndContactModel
    {
        public AppErrLogModel()
        {
        }

        public int AppErrLogID { get; set; }
        public string Tag { get; set; }
        public int LineNumber { get; set; }
        public string Source { get; set; }
        public string Message { get; set; }
        public System.DateTime DateTime_UTC { get; set; }
    }
}
