using CSSPEnumsDLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
    public class ReportTypeModel : LastUpdateAndContactModel
    {
        public ReportTypeModel()
        {
        }
        public int ReportTypeID { get; set; }
        public TVTypeEnum TVType { get; set; }
        public FileTypeEnum FileType { get; set; }
        public string UniqueCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string StartOfFileName { get; set; }
    }
}
