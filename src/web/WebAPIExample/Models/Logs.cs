using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class Logs
    {
        [Key]
        public int LogID { get; set; }
        [Required]
        [StringLength(50)]
        public string TableName { get; set; }
        public int ID { get; set; }
        public int LogCommand { get; set; }
        [Required]
        [Column(TypeName = "text")]
        public string Information { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }
    }
}
