using CSSPEnumsDLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
    public class TVItemStatModel : LastUpdateAndContactModel
    {
        public TVItemStatModel()
        {
        }
        public int TVItemStatID { get; set; }
        public int TVItemID { get; set; }
        public TVTypeEnum TVType { get; set; }
        public int ChildCount { get; set; }
    }
}
