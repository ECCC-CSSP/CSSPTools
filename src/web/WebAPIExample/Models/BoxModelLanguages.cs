using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class BoxModelLanguages
    {
        [Key]
        public int BoxModelLanguageID { get; set; }
        public int BoxModelID { get; set; }
        public int Language { get; set; }
        [Required]
        [StringLength(250)]
        public string ScenarioName { get; set; }
        public int TranslationStatus { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(BoxModelID))]
        [InverseProperty(nameof(BoxModels.BoxModelLanguages))]
        public virtual BoxModels BoxModel { get; set; }
    }
}
