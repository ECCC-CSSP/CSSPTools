using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class TideSites
    {
        [Key]
        public int TideSiteID { get; set; }
        public int TideSiteTVItemID { get; set; }
        [Required]
        [StringLength(100)]
        public string TideSiteName { get; set; }
        [Required]
        [StringLength(2)]
        public string Province { get; set; }
        public int sid { get; set; }
        public int Zone { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(TideSiteTVItemID))]
        [InverseProperty(nameof(TVItems.TideSites))]
        public virtual TVItems TideSiteTVItem { get; set; }
    }
}
