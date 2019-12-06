using CSSPEnumsDLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
    public class EmailModel : LastUpdateAndContactModel
    {
        public EmailModel()
        {
        }
        public int EmailID { get; set; }
        public int EmailTVItemID { get; set; }
        public string EmailAddress { get; set; }
        public EmailTypeEnum EmailType { get; set; }
        public string EmailTypeText { get; set; }
    }
}
