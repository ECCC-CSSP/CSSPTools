using CSSPEnumsDLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
    public class ContactPreferenceModel : LastUpdateAndContactModel
    {
        public ContactPreferenceModel()
        {
        }
        public int ContactPreferenceID { get; set; }
        public int ContactID { get; set; }
        public TVTypeEnum TVType { get; set; }
        public int MarkerSize { get; set; }
    }
}
