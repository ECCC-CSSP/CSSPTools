using CSSPEnumsDLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
    public class ReportSectionModel : LastUpdateAndContactModel
    {
        public ReportSectionModel()
        {
        }
        public int ReportSectionID { get; set; }
        public int ReportTypeID { get; set; }
        public int? TVItemID { get; set; }
        public int Ordinal { get; set; }
        public bool IsStatic { get; set; }
        public int? ParentReportSectionID { get; set; }
        public int? Year { get; set; }
        public bool Locked { get; set; }
        public int? TemplateReportSectionID { get; set; }
        public string ReportSectionName { get; set; }
        public string ReportSectionText { get; set; }
    }
}
