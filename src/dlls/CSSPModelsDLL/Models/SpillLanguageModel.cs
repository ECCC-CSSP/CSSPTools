using CSSPEnumsDLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
    public class SpillLanguageModel : LastUpdateAndContactModel
    {
        public SpillLanguageModel()
        {
        }
        public int SpillLanguageID { get; set; }
        public int SpillID { get; set; }
        public LanguageEnum Language { get; set; }
        public string SpillComment { get; set; }
        public TranslationStatusEnum TranslationStatus { get; set; }
    }
}
