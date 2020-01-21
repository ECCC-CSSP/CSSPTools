using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class Classifications
    {
        [Key]
        public int ClassificationID { get; set; }
        public int ClassificationTVItemID { get; set; }
        public int ClassificationType { get; set; }
        public int Ordinal { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(ClassificationTVItemID))]
        [InverseProperty(nameof(TVItems.Classifications))]
        public virtual TVItems ClassificationTVItem { get; set; }
    }
}
