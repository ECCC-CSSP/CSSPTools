using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
    public class MapInfoPointModel : LastUpdateAndContactModel
    {
        public MapInfoPointModel()
        {
        }
        public int MapInfoPointID { get; set; }
        public int MapInfoID { get; set; }
        public int Ordinal { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public int TVItemID { get; set; }
    }
}
