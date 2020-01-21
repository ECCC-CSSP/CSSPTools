using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class MikeBoundaryConditions
    {
        [Key]
        public int MikeBoundaryConditionID { get; set; }
        public int MikeBoundaryConditionTVItemID { get; set; }
        [Required]
        [StringLength(100)]
        public string MikeBoundaryConditionCode { get; set; }
        [Required]
        [StringLength(100)]
        public string MikeBoundaryConditionName { get; set; }
        public double MikeBoundaryConditionLength_m { get; set; }
        [Required]
        [StringLength(100)]
        public string MikeBoundaryConditionFormat { get; set; }
        public int MikeBoundaryConditionLevelOrVelocity { get; set; }
        public int WebTideDataSet { get; set; }
        public int NumberOfWebTideNodes { get; set; }
        [Required]
        [Column(TypeName = "text")]
        public string WebTideDataFromStartToEndDate { get; set; }
        public int TVType { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(MikeBoundaryConditionTVItemID))]
        [InverseProperty(nameof(TVItems.MikeBoundaryConditions))]
        public virtual TVItems MikeBoundaryConditionTVItem { get; set; }
    }
}
