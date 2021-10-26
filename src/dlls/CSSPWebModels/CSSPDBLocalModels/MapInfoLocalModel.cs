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
    public partial class MapInfoLocalModel
    {
        public MapInfo MapInfo { get; set; }
        public List<MapInfoPoint> MapInfoPointList { get; set; }

        public MapInfoLocalModel()
        {
            MapInfoPointList = new List<MapInfoPoint>();
        }
    }
}
