using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class TVFileLanguages
    {
        [Key]
        public int TVFileLanguageID { get; set; }
        public int TVFileID { get; set; }
        public int Language { get; set; }
        [Column(TypeName = "text")]
        public string FileDescription { get; set; }
        public int TranslationStatus { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(TVFileID))]
        [InverseProperty(nameof(TVFiles.TVFileLanguages))]
        public virtual TVFiles TVFile { get; set; }
    }
}
