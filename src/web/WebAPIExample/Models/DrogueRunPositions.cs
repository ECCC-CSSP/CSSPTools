using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class DrogueRunPositions
    {
        [Key]
        public int DrogueRunPositionID { get; set; }
        public int DrogueRunID { get; set; }
        public int Ordinal { get; set; }
        public double StepLat { get; set; }
        public double StepLng { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime StepDateTime_Local { get; set; }
        public double CalculatedSpeed_m_s { get; set; }
        public double CalculatedDirection_deg { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(DrogueRunID))]
        [InverseProperty(nameof(DrogueRuns.DrogueRunPositions))]
        public virtual DrogueRuns DrogueRun { get; set; }
    }
}
