using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class MWQMRuns
    {
        public MWQMRuns()
        {
            MWQMRunLanguages = new HashSet<MWQMRunLanguages>();
        }

        [Key]
        public int MWQMRunID { get; set; }
        public int SubsectorTVItemID { get; set; }
        public int MWQMRunTVItemID { get; set; }
        public int RunSampleType { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateTime_Local { get; set; }
        public int RunNumber { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? StartDateTime_Local { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EndDateTime_Local { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LabReceivedDateTime_Local { get; set; }
        public double? TemperatureControl1_C { get; set; }
        public double? TemperatureControl2_C { get; set; }
        public int? SeaStateAtStart_BeaufortScale { get; set; }
        public int? SeaStateAtEnd_BeaufortScale { get; set; }
        public double? WaterLevelAtBrook_m { get; set; }
        public double? WaveHightAtStart_m { get; set; }
        public double? WaveHightAtEnd_m { get; set; }
        [StringLength(20)]
        public string SampleCrewInitials { get; set; }
        public int? AnalyzeMethod { get; set; }
        public int? SampleMatrix { get; set; }
        public int? Laboratory { get; set; }
        public int? SampleStatus { get; set; }
        public int? LabSampleApprovalContactTVItemID { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LabAnalyzeBath1IncubationStartDateTime_Local { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LabAnalyzeBath2IncubationStartDateTime_Local { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LabAnalyzeBath3IncubationStartDateTime_Local { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LabRunSampleApprovalDateTime_Local { get; set; }
        public int? Tide_Start { get; set; }
        public int? Tide_End { get; set; }
        public double? RainDay0_mm { get; set; }
        public double? RainDay1_mm { get; set; }
        public double? RainDay2_mm { get; set; }
        public double? RainDay3_mm { get; set; }
        public double? RainDay4_mm { get; set; }
        public double? RainDay5_mm { get; set; }
        public double? RainDay6_mm { get; set; }
        public double? RainDay7_mm { get; set; }
        public double? RainDay8_mm { get; set; }
        public double? RainDay9_mm { get; set; }
        public double? RainDay10_mm { get; set; }
        public bool? RemoveFromStat { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(LabSampleApprovalContactTVItemID))]
        [InverseProperty(nameof(TVItems.MWQMRunsLabSampleApprovalContactTVItem))]
        public virtual TVItems LabSampleApprovalContactTVItem { get; set; }
        [ForeignKey(nameof(MWQMRunTVItemID))]
        [InverseProperty(nameof(TVItems.MWQMRunsMWQMRunTVItem))]
        public virtual TVItems MWQMRunTVItem { get; set; }
        [ForeignKey(nameof(SubsectorTVItemID))]
        [InverseProperty(nameof(TVItems.MWQMRunsSubsectorTVItem))]
        public virtual TVItems SubsectorTVItem { get; set; }
        [InverseProperty("MWQMRun")]
        public virtual ICollection<MWQMRunLanguages> MWQMRunLanguages { get; set; }
    }
}
