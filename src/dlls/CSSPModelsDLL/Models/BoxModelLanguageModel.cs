using CSSPEnumsDLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
    public class BoxModelLanguageModel : LastUpdateAndContactModel
    {
        public BoxModelLanguageModel()
        {
        }
        public int BoxModelLanguageID { get; set; }
        public int BoxModelID { get; set; }
        public LanguageEnum Language { get; set; }
        public string ScenarioName { get; set; }
        public TranslationStatusEnum TranslationStatus { get; set; }
    }
}
