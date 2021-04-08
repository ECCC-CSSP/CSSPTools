/*
 * Manually edited
 * 
 */
using CSSPDBModels;
using CSSPEnums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPWebModels
{
    [NotMapped]
    public partial class PostMapInfoModel
    {
        public TVItem TVItem { get; set; }
        public TVItem ParentTVItem { get; set; }
        public MapInfo MapInfo { get; set; }
        public List<MapInfoPoint> MapInfoPointList { get; set; }

        public PostMapInfoModel()
        {
            MapInfoPointList = new List<MapInfoPoint>();
        }
    }
}
