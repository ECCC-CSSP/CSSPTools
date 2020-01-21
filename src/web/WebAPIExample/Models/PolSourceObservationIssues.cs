using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class PolSourceObservationIssues
    {
        [Key]
        public int PolSourceObservationIssueID { get; set; }
        public int PolSourceObservationID { get; set; }
        [Required]
        [StringLength(250)]
        public string ObservationInfo { get; set; }
        public int Ordinal { get; set; }
        [Column(TypeName = "text")]
        public string ExtraComment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(PolSourceObservationID))]
        [InverseProperty(nameof(PolSourceObservations.PolSourceObservationIssues))]
        public virtual PolSourceObservations PolSourceObservation { get; set; }
    }
}
