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
    public partial class TVItemMapModel : TVItemModel
    {
        public List<MapInfoModel> MapInfoModelList { get; set; }

        public TVItemMapModel()
        {
            MapInfoModelList = new List<MapInfoModel>();
        }
    }
}
