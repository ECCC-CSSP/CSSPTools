using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class MWQMLookupMPNs
    {
        [Key]
        public int MWQMLookupMPNID { get; set; }
        public int Tubes10 { get; set; }
        public int Tubes1 { get; set; }
        public int Tubes01 { get; set; }
        public int MPN_100ml { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }
    }
}
