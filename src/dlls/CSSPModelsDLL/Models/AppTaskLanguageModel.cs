using CSSPEnumsDLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
    public class AppTaskLanguageModel : LastUpdateAndContactModel
    {
        public AppTaskLanguageModel()
        {
        }
        public int AppTaskLanguageID { get; set; }
        public int AppTaskID { get; set; }
        public LanguageEnum Language { get; set; }
        public string StatusText { get; set; }
        public string ErrorText { get; set; }
        public TranslationStatusEnum TranslationStatus { get; set; }
    }
}
