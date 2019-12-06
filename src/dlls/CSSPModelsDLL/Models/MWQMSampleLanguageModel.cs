using CSSPEnumsDLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
    public class MWQMSampleLanguageModel : LastUpdateAndContactModel
    {
        public MWQMSampleLanguageModel()
        {
        }
        public int MWQMSampleLanguageID { get; set; }
        public int MWQMSampleID { get; set; }
        public LanguageEnum Language { get; set; }
        public string MWQMSampleNote { get; set; }
        public TranslationStatusEnum TranslationStatus { get; set; }
    }
}
