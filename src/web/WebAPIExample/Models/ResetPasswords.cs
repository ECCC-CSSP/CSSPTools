using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class ResetPasswords
    {
        [Key]
        public int ResetPasswordID { get; set; }
        [Required]
        [StringLength(256)]
        public string Email { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ExpireDate_Local { get; set; }
        [Required]
        [StringLength(8)]
        public string Code { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }
    }
}
