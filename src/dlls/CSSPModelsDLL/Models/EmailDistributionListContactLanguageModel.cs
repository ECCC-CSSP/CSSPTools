using CSSPEnumsDLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
    public class EmailDistributionListContactLanguageModel : LastUpdateAndContactModel
    {
        public EmailDistributionListContactLanguageModel()
        {
        }
        public int EmailDistributionListContactLanguageID { get; set; }
        public int EmailDistributionListContactID { get; set; }
        public LanguageEnum Language { get; set; }
        public string Agency { get; set; }
        public TranslationStatusEnum TranslationStatus { get; set; }
    }
}
