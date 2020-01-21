using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class LabSheetDetails
    {
        public LabSheetDetails()
        {
            LabSheetTubeMPNDetails = new HashSet<LabSheetTubeMPNDetails>();
        }

        [Key]
        public int LabSheetDetailID { get; set; }
        public int LabSheetID { get; set; }
        public int SamplingPlanID { get; set; }
        public int SubsectorTVItemID { get; set; }
        public int Version { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime RunDate { get; set; }
        [Required]
        [StringLength(7)]
        public string Tides { get; set; }
        [StringLength(20)]
        public string SampleCrewInitials { get; set; }
        public int? WaterBathCount { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? IncubationBath1StartTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? IncubationBath2StartTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? IncubationBath3StartTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? IncubationBath1EndTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? IncubationBath2EndTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? IncubationBath3EndTime { get; set; }
        public int? IncubationBath1TimeCalculated_minutes { get; set; }
        public int? IncubationBath2TimeCalculated_minutes { get; set; }
        public int? IncubationBath3TimeCalculated_minutes { get; set; }
        [StringLength(10)]
        public string WaterBath1 { get; set; }
        [StringLength(10)]
        public string WaterBath2 { get; set; }
        [StringLength(10)]
        public string WaterBath3 { get; set; }
        public double? TCField1 { get; set; }
        public double? TCLab1 { get; set; }
        public double? TCField2 { get; set; }
        public double? TCLab2 { get; set; }
        public double? TCFirst { get; set; }
        public double? TCAverage { get; set; }
        [StringLength(100)]
        public string ControlLot { get; set; }
        [StringLength(1)]
        public string Positive35 { get; set; }
        [StringLength(1)]
        public string NonTarget35 { get; set; }
        [StringLength(1)]
        public string Negative35 { get; set; }
        [StringLength(1)]
        public string Bath1Positive44_5 { get; set; }
        [StringLength(1)]
        public string Bath2Positive44_5 { get; set; }
        [StringLength(1)]
        public string Bath3Positive44_5 { get; set; }
        [StringLength(1)]
        public string Bath1NonTarget44_5 { get; set; }
        [StringLength(1)]
        public string Bath2NonTarget44_5 { get; set; }
        [StringLength(1)]
        public string Bath3NonTarget44_5 { get; set; }
        [StringLength(1)]
        public string Bath1Negative44_5 { get; set; }
        [StringLength(1)]
        public string Bath2Negative44_5 { get; set; }
        [StringLength(1)]
        public string Bath3Negative44_5 { get; set; }
        [StringLength(1)]
        public string Blank35 { get; set; }
        [StringLength(1)]
        public string Bath1Blank44_5 { get; set; }
        [StringLength(1)]
        public string Bath2Blank44_5 { get; set; }
        [StringLength(1)]
        public string Bath3Blank44_5 { get; set; }
        [StringLength(20)]
        public string Lot35 { get; set; }
        [StringLength(20)]
        public string Lot44_5 { get; set; }
        [StringLength(250)]
        public string Weather { get; set; }
        [StringLength(250)]
        public string RunComment { get; set; }
        [StringLength(250)]
        public string RunWeatherComment { get; set; }
        [StringLength(20)]
        public string SampleBottleLotNumber { get; set; }
        [StringLength(20)]
        public string SalinitiesReadBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? SalinitiesReadDate { get; set; }
        [StringLength(20)]
        public string ResultsReadBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ResultsReadDate { get; set; }
        [StringLength(20)]
        public string ResultsRecordedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ResultsRecordedDate { get; set; }
        public double? DailyDuplicateRLog { get; set; }
        public double? DailyDuplicatePrecisionCriteria { get; set; }
        public bool? DailyDuplicateAcceptable { get; set; }
        public double? IntertechDuplicateRLog { get; set; }
        public double? IntertechDuplicatePrecisionCriteria { get; set; }
        public bool? IntertechDuplicateAcceptable { get; set; }
        public bool? IntertechReadAcceptable { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(LabSheetID))]
        [InverseProperty(nameof(LabSheets.LabSheetDetails))]
        public virtual LabSheets LabSheet { get; set; }
        [ForeignKey(nameof(SamplingPlanID))]
        [InverseProperty(nameof(SamplingPlans.LabSheetDetails))]
        public virtual SamplingPlans SamplingPlan { get; set; }
        [ForeignKey(nameof(SubsectorTVItemID))]
        [InverseProperty(nameof(TVItems.LabSheetDetails))]
        public virtual TVItems SubsectorTVItem { get; set; }
        [InverseProperty("LabSheetDetail")]
        public virtual ICollection<LabSheetTubeMPNDetails> LabSheetTubeMPNDetails { get; set; }
    }
}
