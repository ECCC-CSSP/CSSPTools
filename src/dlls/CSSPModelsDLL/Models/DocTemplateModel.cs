using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSSPEnumsDLL.Enums;

namespace CSSPModelsDLL.Models
{
    public class DocTemplateModel : LastUpdateAndContactModel
    {
        public DocTemplateModel()
        {
        }
        public LanguageEnum Language { get; set; }
        public int DocTemplateID { get; set; }
        public TVTypeEnum TVType { get; set; }
        public int TVFileTVItemID { get; set; }
        public string FileName { get; set; }
    }
}
