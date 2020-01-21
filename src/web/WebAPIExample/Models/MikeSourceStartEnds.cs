using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class MikeSourceStartEnds
    {
        [Key]
        public int MikeSourceStartEndID { get; set; }
        public int MikeSourceID { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime StartDateAndTime_Local { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime EndDateAndTime_Local { get; set; }
        public double SourceFlowStart_m3_day { get; set; }
        public double SourceFlowEnd_m3_day { get; set; }
        public int SourcePollutionStart_MPN_100ml { get; set; }
        public int SourcePollutionEnd_MPN_100ml { get; set; }
        public double SourceTemperatureStart_C { get; set; }
        public double SourceTemperatureEnd_C { get; set; }
        public double SourceSalinityStart_PSU { get; set; }
        public double SourceSalinityEnd_PSU { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(MikeSourceID))]
        [InverseProperty(nameof(MikeSources.MikeSourceStartEnds))]
        public virtual MikeSources MikeSource { get; set; }
    }
}
