using CSSPEnumsDLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
    public class ClassificationModel : LastUpdateAndContactModel
    {
        public ClassificationModel()
        {
        }
        public int ClassificationID { get; set; }
        public int ClassificationTVItemID { get; set; }
        public string ClassificationTVText { get; set; }
        public ClassificationTypeEnum ClassificationType { get; set; }
        public int Ordinal { get; set; }
    }
}
