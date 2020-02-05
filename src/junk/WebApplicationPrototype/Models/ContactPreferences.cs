using System;
using System.Collections.Generic;

namespace WebApplicationPrototype.Models
{
    public partial class ContactPreferences
    {
        public int ContactPreferenceID { get; set; }
        public int ContactID { get; set; }
        public int TVType { get; set; }
        public int MarkerSize { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual Contacts Contact { get; set; }
    }
}
