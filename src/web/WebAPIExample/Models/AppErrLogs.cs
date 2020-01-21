using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class AppErrLogs
    {
        [Key]
        public int AppErrLogID { get; set; }
        [Required]
        [StringLength(100)]
        public string Tag { get; set; }
        public int LineNumber { get; set; }
        [Required]
        [Column(TypeName = "text")]
        public string Source { get; set; }
        [Required]
        [Column(TypeName = "text")]
        public string Message { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateTime_UTC { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }
    }
}
