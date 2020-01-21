using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class MWQMSamples
    {
        public MWQMSamples()
        {
            MWQMSampleLanguages = new HashSet<MWQMSampleLanguages>();
        }

        [Key]
        public int MWQMSampleID { get; set; }
        public int MWQMSiteTVItemID { get; set; }
        public int MWQMRunTVItemID { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime SampleDateTime_Local { get; set; }
        [StringLength(6)]
        public string TimeText { get; set; }
        public double? Depth_m { get; set; }
        public int FecCol_MPN_100ml { get; set; }
        public double? Salinity_PPT { get; set; }
        public double? WaterTemp_C { get; set; }
        public double? PH { get; set; }
        [Required]
        [StringLength(50)]
        public string SampleTypesText { get; set; }
        public int? SampleType_old { get; set; }
        public int? Tube_10 { get; set; }
        public int? Tube_1_0 { get; set; }
        public int? Tube_0_1 { get; set; }
        [StringLength(10)]
        public string ProcessedBy { get; set; }
        public bool UseForOpenData { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(MWQMRunTVItemID))]
        [InverseProperty(nameof(TVItems.MWQMSamplesMWQMRunTVItem))]
        public virtual TVItems MWQMRunTVItem { get; set; }
        [ForeignKey(nameof(MWQMSiteTVItemID))]
        [InverseProperty(nameof(TVItems.MWQMSamplesMWQMSiteTVItem))]
        public virtual TVItems MWQMSiteTVItem { get; set; }
        [InverseProperty("MWQMSample")]
        public virtual ICollection<MWQMSampleLanguages> MWQMSampleLanguages { get; set; }
    }
}
