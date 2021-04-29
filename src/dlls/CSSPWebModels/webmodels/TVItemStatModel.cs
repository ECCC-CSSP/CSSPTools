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
    public partial class TVItemStatModel : TVItemModel
    {
        public List<TVItemStat> TVItemStatList { get; set; }

        public TVItemStatModel()
        {
            TVItemStatList = new List<TVItemStat>();
        }
    }
}
