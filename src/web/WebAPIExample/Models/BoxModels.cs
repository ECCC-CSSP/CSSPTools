using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class BoxModels
    {
        public BoxModels()
        {
            BoxModelLanguages = new HashSet<BoxModelLanguages>();
            BoxModelResults = new HashSet<BoxModelResults>();
        }

        [Key]
        public int BoxModelID { get; set; }
        public int InfrastructureTVItemID { get; set; }
        public double Discharge_m3_day { get; set; }
        public double Depth_m { get; set; }
        public double Temperature_C { get; set; }
        public int Dilution { get; set; }
        public double DecayRate_per_day { get; set; }
        public int FCUntreated_MPN_100ml { get; set; }
        public int FCPreDisinfection_MPN_100ml { get; set; }
        public int Concentration_MPN_100ml { get; set; }
        public double T90_hour { get; set; }
        public double DischargeDuration_hour { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(InfrastructureTVItemID))]
        [InverseProperty(nameof(TVItems.BoxModels))]
        public virtual TVItems InfrastructureTVItem { get; set; }
        [InverseProperty("BoxModel")]
        public virtual ICollection<BoxModelLanguages> BoxModelLanguages { get; set; }
        [InverseProperty("BoxModel")]
        public virtual ICollection<BoxModelResults> BoxModelResults { get; set; }
    }
}
