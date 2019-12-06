using CSSPEnumsDLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
    public class MWQMSiteLanguageModel : LastUpdateAndContactModel
    {
        public MWQMSiteLanguageModel()
        {
        }
        public int MWQMSiteLanguageID { get; set; }
        public int MWQMSiteID { get; set; }
        public LanguageEnum Language { get; set; }
        public string MWQMSiteName { get; set; }
        public TranslationStatusEnum TranslationStatus { get; set; }
    }
}
