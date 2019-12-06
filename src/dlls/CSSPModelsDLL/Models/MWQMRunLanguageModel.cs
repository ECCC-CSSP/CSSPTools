using CSSPEnumsDLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
    public class MWQMRunLanguageModel : LastUpdateAndContactModel
    {
        public MWQMRunLanguageModel()
        {
        }
        public int MWQMRunLanguageID { get; set; }
        public int MWQMRunID { get; set; }
        public LanguageEnum Language { get; set; }
        public string RunComment { get; set; }
        public TranslationStatusEnum TranslationStatusRunComment { get; set; }
        public string RunWeatherComment { get; set; }
        public TranslationStatusEnum TranslationStatusRunWeatherComment { get; set; }
    }
}
