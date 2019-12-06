using CSSPEnumsDLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
    public class TideDataValueModel : LastUpdateAndContactModel
    {
        public TideDataValueModel()
        {
        }
        public int TideDataValueID { get; set; }
        public int TideSiteTVItemID { get; set; }
        public System.DateTime DateTime_Local { get; set; }
        public bool Keep { get; set; }
        public TideDataTypeEnum TideDataType { get; set; }
        public StorageDataTypeEnum StorageDataType { get; set; }
        public double Depth_m { get; set; }
        public double UVelocity_m_s { get; set; }
        public double VVelocity_m_s { get; set; }
        public Nullable<TideTextEnum> TideStart { get; set; }
        public Nullable<TideTextEnum> TideEnd { get; set; }
    }
}
