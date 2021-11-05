/*
 * Manually edited
 * 
 */
using CSSPCustomAttributes;
using CSSPDBModels;
using CSSPEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPWebModels
{
    [NotMapped]
    public partial class ClassificationLocalModel
    {
        public TVItem TVItemParent { get; set; }
        public TVItemModel TVItemModel { get; set; }
        public Classification Classification { get; set; }
        public ClassificationLocalModel()
        {

        }
    }
}
