using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class DocTemplates
    {
        [Key]
        public int DocTemplateID { get; set; }
        public int Language { get; set; }
        public int TVType { get; set; }
        public int TVFileTVItemID { get; set; }
        [Required]
        [StringLength(150)]
        public string FileName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(TVFileTVItemID))]
        [InverseProperty(nameof(TVItems.DocTemplates))]
        public virtual TVItems TVFileTVItem { get; set; }
    }
}
