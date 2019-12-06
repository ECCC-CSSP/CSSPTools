using CSSPEnumsDLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
    public class EmailDistributionListLanguageModel : LastUpdateAndContactModel
    {
        public EmailDistributionListLanguageModel()
        {
        }
        public int EmailDistributionListLanguageID { get; set; }
        public int EmailDistributionListID { get; set; }
        public LanguageEnum Language { get; set; }
        public string EmailListName { get; set; }
        public TranslationStatusEnum TranslationStatus { get; set; }
    }
}
