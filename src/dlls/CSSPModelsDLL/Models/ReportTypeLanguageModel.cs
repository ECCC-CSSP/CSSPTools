using CSSPEnumsDLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
    public class ReportTypeLanguageModel : LastUpdateAndContactModel
    {
        public ReportTypeLanguageModel()
        {
        }
        public int ReportTypeLanguageID { get; set; }
        public int ReportTypeID { get; set; }
        public LanguageEnum Language { get; set; }
        public string Name { get; set; }
        public TranslationStatusEnum TranslationStatusName { get; set; }
        public string Description { get; set; }
        public TranslationStatusEnum TranslationStatusDescription { get; set; }
        public string StartOfFileName { get; set; }
        public TranslationStatusEnum TranslationStatusStartOfFileName { get; set; }
    }
}
