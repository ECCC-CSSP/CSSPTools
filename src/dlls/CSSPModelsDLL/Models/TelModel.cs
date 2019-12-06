using CSSPEnumsDLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
    public class TelModel : LastUpdateAndContactModel
    {
        public TelModel()
        {
        }
        public int TelID { get; set; }
        public int TelTVItemID { get; set; }
        public string TelNumber { get; set; }
        public TelTypeEnum TelType { get; set; }
        public string TelTypeText { get; set; }
    }
}
