using CSSPEnumsDLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
    public class VPScenarioLanguageModel : LastUpdateAndContactModel
    {
        public VPScenarioLanguageModel()
        {
        }
        public int VPScenarioLanguageID { get; set; }
        public int VPScenarioID { get; set; }
        public LanguageEnum Language { get; set; }
        public string VPScenarioName { get; set; }
        public TranslationStatusEnum TranslationStatus { get; set; }
    }
}
