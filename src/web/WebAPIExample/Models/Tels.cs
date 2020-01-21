using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class Tels
    {
        [Key]
        public int TelID { get; set; }
        public int TelTVItemID { get; set; }
        [Required]
        [StringLength(50)]
        public string TelNumber { get; set; }
        public int TelType { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(TelTVItemID))]
        [InverseProperty(nameof(TVItems.Tels))]
        public virtual TVItems TelTVItem { get; set; }
    }
}
