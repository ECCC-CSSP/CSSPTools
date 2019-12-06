using CSSPEnumsDLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
    public class TVItemLanguageModel : LastUpdateAndContactModel
    {
        public TVItemLanguageModel()
        {
        }
        public int TVItemLanguageID { get; set; }
        public int TVItemID { get; set; }
        public LanguageEnum Language { get; set; }
        public string TVText { get; set; }
        public TranslationStatusEnum TranslationStatus { get; set; }
    }
}
