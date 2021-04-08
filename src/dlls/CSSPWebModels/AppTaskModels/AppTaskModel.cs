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
    public partial class AppTaskModel
    {
        public AppTask AppTask { get; set; }
        public List<AppTaskLanguage> AppTaskLanguageList { get; set; }

        public AppTaskModel()
        {
            AppTaskLanguageList = new List<AppTaskLanguage>();
        }
    }
}
