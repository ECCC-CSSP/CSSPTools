using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
    public class MikeSourceModel : LastUpdateAndContactModel
    {
        public MikeSourceModel()
        {
            MikeSourceStartEndModelList = new List<MikeSourceStartEndModel>();
        }
        public int MikeSourceID { get; set; }
        public int MikeSourceTVItemID { get; set; }
        public string MikeSourceTVText { get; set; }
        public bool IsContinuous { get; set; }
        public bool Include { get; set; }
        public bool IsRiver { get; set; }
        public bool UseHydrometric { get; set; }
        public int? HydrometricTVItemID { get; set; }
        public double? DrainageArea_km2 { get; set; }
        public double? Factor { get; set; }
        public string SourceNumberString { get; set; }
        public float Lat { get; set; }
        public float Lng { get; set; }
        public List<MikeSourceStartEndModel> MikeSourceStartEndModelList { get; set; }
    }
}
