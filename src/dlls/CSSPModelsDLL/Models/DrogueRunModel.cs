using CSSPEnumsDLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
    public class DrogueRunModel : LastUpdateAndContactModel
    {
        public DrogueRunModel()
        {
        }
        public int DrogueRunID { get; set; }
        public int SubsectorTVItemID { get; set; }
        public int DrogueNumber { get; set; }
        public DrogueTypeEnum DrogueType { get; set; }
        public DateTime RunStartDateTime { get; set; }
        public bool IsRisingTide { get; set; }
    }
}
