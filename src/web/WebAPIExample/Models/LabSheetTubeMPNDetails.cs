using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class LabSheetTubeMPNDetails
    {
        [Key]
        public int LabSheetTubeMPNDetailID { get; set; }
        public int LabSheetDetailID { get; set; }
        public int Ordinal { get; set; }
        public int MWQMSiteTVItemID { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? SampleDateTime { get; set; }
        public int? MPN { get; set; }
        public int? Tube10 { get; set; }
        public int? Tube1_0 { get; set; }
        public int? Tube0_1 { get; set; }
        public double? Salinity { get; set; }
        public double? Temperature { get; set; }
        [StringLength(10)]
        public string ProcessedBy { get; set; }
        public int SampleType { get; set; }
        [StringLength(250)]
        public string SiteComment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(LabSheetDetailID))]
        [InverseProperty(nameof(LabSheetDetails.LabSheetTubeMPNDetails))]
        public virtual LabSheetDetails LabSheetDetail { get; set; }
        [ForeignKey(nameof(MWQMSiteTVItemID))]
        [InverseProperty(nameof(TVItems.LabSheetTubeMPNDetails))]
        public virtual TVItems MWQMSiteTVItem { get; set; }
    }
}
