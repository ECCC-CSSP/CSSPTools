using CSSPEnumsDLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
    public class TVFileLanguageModel : LastUpdateAndContactModel
    {
        public TVFileLanguageModel()
        {
        }
        public int TVFileLanguageID { get; set; }
        public int TVFileID { get; set; }
        public LanguageEnum Language { get; set; }
        public string FileDescription { get; set; }
        public TranslationStatusEnum TranslationStatus { get; set; }
    }
}
