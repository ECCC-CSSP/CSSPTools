using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class ClimateSites
    {
        public ClimateSites()
        {
            ClimateDataValues = new HashSet<ClimateDataValues>();
        }

        [Key]
        public int ClimateSiteID { get; set; }
        public int ClimateSiteTVItemID { get; set; }
        public int? ECDBID { get; set; }
        [Required]
        [StringLength(100)]
        public string ClimateSiteName { get; set; }
        [Required]
        [StringLength(4)]
        public string Province { get; set; }
        public double? Elevation_m { get; set; }
        [StringLength(10)]
        public string ClimateID { get; set; }
        public int? WMOID { get; set; }
        [StringLength(3)]
        public string TCID { get; set; }
        public bool? IsQuebecSite { get; set; }
        public bool? IsCoCoRaHS { get; set; }
        public double? TimeOffset_hour { get; set; }
        [StringLength(50)]
        public string File_desc { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? HourlyStartDate_Local { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? HourlyEndDate_Local { get; set; }
        public bool? HourlyNow { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DailyStartDate_Local { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DailyEndDate_Local { get; set; }
        public bool? DailyNow { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? MonthlyStartDate_Local { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? MonthlyEndDate_Local { get; set; }
        public bool? MonthlyNow { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(ClimateSiteTVItemID))]
        [InverseProperty(nameof(TVItems.ClimateSites))]
        public virtual TVItems ClimateSiteTVItem { get; set; }
        [InverseProperty("ClimateSite")]
        public virtual ICollection<ClimateDataValues> ClimateDataValues { get; set; }
    }
}
