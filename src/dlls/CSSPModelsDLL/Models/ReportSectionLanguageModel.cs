using CSSPEnumsDLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
    public class ReportSectionLanguageModel : LastUpdateAndContactModel
    {
        public ReportSectionLanguageModel()
        {
        }
        public int ReportSectionLanguageID { get; set; }
        public int ReportSectionID { get; set; }
        public LanguageEnum Language { get; set; }
        public string ReportSectionName { get; set; }
        public TranslationStatusEnum TranslationStatusReportSectionName { get; set; }
        public string ReportSectionText { get; set; }
        public TranslationStatusEnum TranslationStatusReportSectionText { get; set; }
    }
}
