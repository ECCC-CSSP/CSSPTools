using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class ContactPreferences
    {
        [Key]
        public int ContactPreferenceID { get; set; }
        public int ContactID { get; set; }
        public int TVType { get; set; }
        public int MarkerSize { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(ContactID))]
        [InverseProperty(nameof(Contacts.ContactPreferences))]
        public virtual Contacts Contact { get; set; }
    }
}
