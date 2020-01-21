using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class TVItemUserAuthorizations
    {
        [Key]
        public int TVItemUserAuthorizationID { get; set; }
        public int ContactTVItemID { get; set; }
        public int TVItemID1 { get; set; }
        public int? TVItemID2 { get; set; }
        public int? TVItemID3 { get; set; }
        public int? TVItemID4 { get; set; }
        public int TVAuth { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(ContactTVItemID))]
        [InverseProperty(nameof(TVItems.TVItemUserAuthorizationsContactTVItem))]
        public virtual TVItems ContactTVItem { get; set; }
        [ForeignKey(nameof(TVItemID1))]
        [InverseProperty(nameof(TVItems.TVItemUserAuthorizationsTVItemID1Navigation))]
        public virtual TVItems TVItemID1Navigation { get; set; }
    }
}
