using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class SpillLanguages
    {
        [Key]
        public int SpillLanguageID { get; set; }
        public int SpillID { get; set; }
        public int Language { get; set; }
        [Required]
        [Column(TypeName = "text")]
        public string SpillComment { get; set; }
        public int TranslationStatus { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(SpillID))]
        [InverseProperty(nameof(Spills.SpillLanguages))]
        public virtual Spills Spill { get; set; }
    }
}
