using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class ContactShortcuts
    {
        [Key]
        public int ContactShortcutID { get; set; }
        public int ContactID { get; set; }
        [Required]
        [StringLength(100)]
        public string ShortCutText { get; set; }
        [Required]
        [StringLength(200)]
        public string ShortCutAddress { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(ContactID))]
        [InverseProperty(nameof(Contacts.ContactShortcuts))]
        public virtual Contacts Contact { get; set; }
    }
}
