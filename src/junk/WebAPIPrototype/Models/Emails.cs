using System;
using System.Collections.Generic;

namespace WebAPIPrototype.Models
{
    public partial class Emails
    {
        public int EmailID { get; set; }
        public int EmailTVItemID { get; set; }
        public string EmailAddress { get; set; }
        public int EmailType { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual TVItems EmailTVItem { get; set; }
    }
}
