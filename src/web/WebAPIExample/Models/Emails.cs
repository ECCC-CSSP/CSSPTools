using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class Emails
    {
        [Key]
        public int EmailID { get; set; }
        public int EmailTVItemID { get; set; }
        [Required]
        [StringLength(255)]
        public string EmailAddress { get; set; }
        public int EmailType { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(EmailTVItemID))]
        [InverseProperty(nameof(TVItems.Emails))]
        public virtual TVItems EmailTVItem { get; set; }
    }
}
