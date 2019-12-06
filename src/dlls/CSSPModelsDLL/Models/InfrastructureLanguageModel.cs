using CSSPEnumsDLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
    public class InfrastructureLanguageModel : LastUpdateAndContactModel
    {
        public InfrastructureLanguageModel()
        {
        }
        public int InfrastructureLanguageID { get; set; }
        public int InfrastructureID { get; set; }
        public LanguageEnum Language { get; set; }
        public string Comment { get; set; }
        public TranslationStatusEnum TranslationStatus { get; set; }
    }
}
