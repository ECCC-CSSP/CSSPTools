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
    public partial class CountryLocalModel
    {
        public TVItem TVItemParent { get; set; }
        public TVItem TVItem { get; set; }
        public List<TVItemLanguage> TVItemLanguageList { get; set; }
        public List<MapInfoLocalModel> MapInfoLocalModelList { get; set; }

        public CountryLocalModel()
        {
            TVItemLanguageList = new List<TVItemLanguage>();
            MapInfoLocalModelList = new List<MapInfoLocalModel>();
        }
    }
}
