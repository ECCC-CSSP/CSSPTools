using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class PolSourceObservations
    {
        public PolSourceObservations()
        {
            PolSourceObservationIssues = new HashSet<PolSourceObservationIssues>();
        }

        [Key]
        public int PolSourceObservationID { get; set; }
        public int PolSourceSiteID { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ObservationDate_Local { get; set; }
        public int ContactTVItemID { get; set; }
        public bool DesktopReviewed { get; set; }
        [Required]
        [Column(TypeName = "text")]
        public string Observation_ToBeDeleted { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(ContactTVItemID))]
        [InverseProperty(nameof(TVItems.PolSourceObservations))]
        public virtual TVItems ContactTVItem { get; set; }
        [ForeignKey(nameof(PolSourceSiteID))]
        [InverseProperty(nameof(PolSourceSites.PolSourceObservations))]
        public virtual PolSourceSites PolSourceSite { get; set; }
        [InverseProperty("PolSourceObservation")]
        public virtual ICollection<PolSourceObservationIssues> PolSourceObservationIssues { get; set; }
    }
}
