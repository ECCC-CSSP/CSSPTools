using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
    public class ContactShortcutModel : LastUpdateAndContactModel
    {
        public ContactShortcutModel()
        {
        }
        public int ContactShortcutID { get; set; }
        public int ContactID { get; set; }
        public string ShortCutText { get; set; }
        public string ShortCutAddress { get; set; }
    }
}
