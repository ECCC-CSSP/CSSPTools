using CSSPEnumsDLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
    public class MapInfoModel : LastUpdateAndContactModel
    {
        public MapInfoModel()
        {
        }
        public int MapInfoID { get; set; }
        public int TVItemID { get; set; }
        public TVTypeEnum TVType { get; set; }
        public double LatMin { get; set; }
        public double LatMax { get; set; }
        public double LngMin { get; set; }
        public double LngMax { get; set; }
        public MapInfoDrawTypeEnum MapInfoDrawType { get; set; }
    }
}
