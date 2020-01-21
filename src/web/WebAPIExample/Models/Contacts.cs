using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class Contacts
    {
        public Contacts()
        {
            ContactPreferences = new HashSet<ContactPreferences>();
            ContactShortcuts = new HashSet<ContactShortcuts>();
        }

        [Key]
        public int ContactID { get; set; }
        [Required]
        [StringLength(128)]
        public string Id { get; set; }
        public int ContactTVItemID { get; set; }
        [Required]
        [StringLength(255)]
        public string LoginEmail { get; set; }
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100)]
        public string LastName { get; set; }
        [StringLength(50)]
        public string Initial { get; set; }
        [Required]
        [StringLength(100)]
        public string WebName { get; set; }
        public int? ContactTitle { get; set; }
        public bool IsAdmin { get; set; }
        public bool EmailValidated { get; set; }
        public bool Disabled { get; set; }
        public bool IsNew { get; set; }
        [StringLength(200)]
        public string SamplingPlanner_ProvincesTVItemID { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(ContactTVItemID))]
        [InverseProperty(nameof(TVItems.Contacts))]
        public virtual TVItems ContactTVItem { get; set; }
        [ForeignKey(nameof(Id))]
        [InverseProperty(nameof(AspNetUsers.Contacts))]
        public virtual AspNetUsers IdNavigation { get; set; }
        [InverseProperty("Contact")]
        public virtual ICollection<ContactPreferences> ContactPreferences { get; set; }
        [InverseProperty("Contact")]
        public virtual ICollection<ContactShortcuts> ContactShortcuts { get; set; }
    }
}
