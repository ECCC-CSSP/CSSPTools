using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class HelpDocs
    {
        [Key]
        public int HelpDocID { get; set; }
        [Required]
        [StringLength(100)]
        public string DocKey { get; set; }
        public int Language { get; set; }
        [Required]
        [Column(TypeName = "text")]
        public string DocHTMLText { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }
    }
}
