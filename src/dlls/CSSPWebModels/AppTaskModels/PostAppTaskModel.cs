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
    public partial class PostAppTaskModel
    {
        public AppTask AppTask { get; set; }
        public List<AppTaskLanguage> AppTaskLanguageList { get; set; }

        public PostAppTaskModel()
        {
            AppTaskLanguageList = new List<AppTaskLanguage>();
        }
    }
}
