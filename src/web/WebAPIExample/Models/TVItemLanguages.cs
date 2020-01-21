using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class TVItemLanguages
    {
        [Key]
        public int TVItemLanguageID { get; set; }
        public int TVItemID { get; set; }
        public int Language { get; set; }
        [Required]
        [StringLength(200)]
        public string TVText { get; set; }
        public int TranslationStatus { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(TVItemID))]
        [InverseProperty(nameof(TVItems.TVItemLanguages))]
        public virtual TVItems TVItem { get; set; }
    }
}
