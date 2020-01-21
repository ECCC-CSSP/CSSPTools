using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class TVTypeUserAuthorizations
    {
        [Key]
        public int TVTypeUserAuthorizationID { get; set; }
        public int ContactTVItemID { get; set; }
        public int TVType { get; set; }
        public int TVAuth { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(ContactTVItemID))]
        [InverseProperty(nameof(TVItems.TVTypeUserAuthorizations))]
        public virtual TVItems ContactTVItem { get; set; }
    }
}
