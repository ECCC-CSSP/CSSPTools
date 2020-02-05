using System;
using System.Collections.Generic;

namespace WebAPIPrototype.Models
{
    public partial class Contacts
    {
        public Contacts()
        {
            ContactPreferences = new HashSet<ContactPreferences>();
            ContactShortcuts = new HashSet<ContactShortcuts>();
        }

        public int ContactID { get; set; }
        public string Id { get; set; }
        public int ContactTVItemID { get; set; }
        public string LoginEmail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Initial { get; set; }
        public string WebName { get; set; }
        public int? ContactTitle { get; set; }
        public bool IsAdmin { get; set; }
        public bool EmailValidated { get; set; }
        public bool Disabled { get; set; }
        public bool IsNew { get; set; }
        public string SamplingPlanner_ProvincesTVItemID { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual TVItems ContactTVItem { get; set; }
        public virtual AspNetUsers IdNavigation { get; set; }
        public virtual ICollection<ContactPreferences> ContactPreferences { get; set; }
        public virtual ICollection<ContactShortcuts> ContactShortcuts { get; set; }
    }
}
