using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class TVItemStats
    {
        [Key]
        public int TVItemStatID { get; set; }
        public int TVItemID { get; set; }
        public int TVType { get; set; }
        public int ChildCount { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(TVItemID))]
        [InverseProperty(nameof(TVItems.TVItemStats))]
        public virtual TVItems TVItem { get; set; }
    }
}
