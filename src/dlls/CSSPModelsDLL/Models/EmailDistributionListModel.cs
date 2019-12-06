using CSSPEnumsDLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
    public class EmailDistributionListModel : LastUpdateAndContactModel
    {
        public EmailDistributionListModel()
        {
        }
        public int EmailDistributionListID { get; set; }
        public int ParentTVItemID { get; set; }
        public string EmailListName { get; set; }
        public int Ordinal { get; set; }
        public string LastModifiedBy { get; set; }
    }
}
