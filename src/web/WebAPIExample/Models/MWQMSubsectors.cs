using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class MWQMSubsectors
    {
        public MWQMSubsectors()
        {
            MWQMSubsectorLanguages = new HashSet<MWQMSubsectorLanguages>();
        }

        [Key]
        public int MWQMSubsectorID { get; set; }
        public int MWQMSubsectorTVItemID { get; set; }
        [Required]
        [StringLength(20)]
        public string SubsectorHistoricKey { get; set; }
        [StringLength(30)]
        public string TideLocationSIDText { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(MWQMSubsectorTVItemID))]
        [InverseProperty(nameof(TVItems.MWQMSubsectors))]
        public virtual TVItems MWQMSubsectorTVItem { get; set; }
        [InverseProperty("MWQMSubsector")]
        public virtual ICollection<MWQMSubsectorLanguages> MWQMSubsectorLanguages { get; set; }
    }
}
