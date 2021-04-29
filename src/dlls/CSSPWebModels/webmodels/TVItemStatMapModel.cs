/*
 * Manually edited
 * 
 */
using CSSPDBModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPWebModels
{
    [NotMapped]
    public partial class TVItemStatMapModel : TVItemStatModel
    {
        public List<MapInfoModel> MapInfoModelList { get; set; }

        public TVItemStatMapModel()
        {
            MapInfoModelList = new List<MapInfoModel>();
        }
    }
}
