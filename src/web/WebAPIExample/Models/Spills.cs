using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class Spills
    {
        public Spills()
        {
            SpillLanguages = new HashSet<SpillLanguages>();
        }

        [Key]
        public int SpillID { get; set; }
        public int MunicipalityTVItemID { get; set; }
        public int? InfrastructureTVItemID { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime StartDateTime_Local { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EndDateTime_Local { get; set; }
        public double AverageFlow_m3_day { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(InfrastructureTVItemID))]
        [InverseProperty(nameof(TVItems.SpillsInfrastructureTVItem))]
        public virtual TVItems InfrastructureTVItem { get; set; }
        [ForeignKey(nameof(MunicipalityTVItemID))]
        [InverseProperty(nameof(TVItems.SpillsMunicipalityTVItem))]
        public virtual TVItems MunicipalityTVItem { get; set; }
        [InverseProperty("Spill")]
        public virtual ICollection<SpillLanguages> SpillLanguages { get; set; }
    }
}
