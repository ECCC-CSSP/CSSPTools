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
    public partial class TVItemModelInfrastructureModel
    {
        public List<TVItemModel> TVItemModeWithInfrastructurelList { get; set; }
        public List<TVItemModel> TVItemModelWithoutInfrastructureList { get; set; }

        public TVItemModelInfrastructureModel()
        {
            TVItemModeWithInfrastructurelList = new List<TVItemModel>();
            TVItemModelWithoutInfrastructureList = new List<TVItemModel>();
        }
    }
}
