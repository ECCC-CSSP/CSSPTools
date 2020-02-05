using System;
using System.Collections.Generic;

namespace WebApplicationPrototype.Models
{
    public partial class ContactShortcuts
    {
        public int ContactShortcutID { get; set; }
        public int ContactID { get; set; }
        public string ShortCutText { get; set; }
        public string ShortCutAddress { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual Contacts Contact { get; set; }
    }
}
