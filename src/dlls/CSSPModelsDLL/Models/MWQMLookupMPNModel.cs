using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
    public class MWQMLookupMPNModel : LastUpdateAndContactModel
    {
        public MWQMLookupMPNModel()
        {
        }
        public int MWQMLookupMPNID { get; set; }
        public int Tubes10 { get; set; }
        public int Tubes1 { get; set; }
        public int Tubes01 { get; set; }
        public int MPN_100ml { get; set; }
    }
}
