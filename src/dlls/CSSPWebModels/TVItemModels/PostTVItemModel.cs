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
    public partial class PostTVItemModel
    {
        public TVItem TVItem { get; set; }
        public List<TVItemLanguage> TVItemLanguageList { get; set; }
        public TVItem TVItemParent { get; set; }

        public PostTVItemModel()
        {
        }
    }
}
