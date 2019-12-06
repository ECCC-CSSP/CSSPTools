using CSSPEnumsDLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
    public class HelpDocModel : LastUpdateAndContactModel
    {
        public HelpDocModel()
        {
        }
        public int HelpDocID { get; set; }
        public string DocKey { get; set; }
        public LanguageEnum Language { get; set; }
        public string DocHTMLText { get; set; }
    }
}
