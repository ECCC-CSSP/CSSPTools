using CSSPEnumsDLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
    public class ClimateDataValueModel : LastUpdateAndContactModel
    {
        public ClimateDataValueModel()
        {
        }
        public int ClimateDataValueID { get; set; }
        public int ClimateSiteID { get; set; }
        public System.DateTime DateTime_Local { get; set; }
        public bool Keep { get; set; }
        public StorageDataTypeEnum StorageDataType { get; set; }
        public bool HasBeenRead { get; set; }
        public double? Snow_cm { get; set; }
        public Nullable<double> Rainfall_mm { get; set; }
        public Nullable<double> RainfallEntered_mm { get; set; }
        public Nullable<double> TotalPrecip_mm_cm { get; set; }
        public Nullable<double> MaxTemp_C { get; set; }
        public Nullable<double> MinTemp_C { get; set; }
        public Nullable<double> HeatDegDays_C { get; set; }
        public Nullable<double> CoolDegDays_C { get; set; }
        public Nullable<double> SnowOnGround_cm { get; set; }
        public Nullable<double> DirMaxGust_0North { get; set; }
        public Nullable<double> SpdMaxGust_kmh { get; set; }
        public string HourlyValues { get; set; }
    }
}
