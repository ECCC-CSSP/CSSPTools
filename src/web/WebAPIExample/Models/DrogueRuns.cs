using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class DrogueRuns
    {
        public DrogueRuns()
        {
            DrogueRunPositions = new HashSet<DrogueRunPositions>();
        }

        [Key]
        public int DrogueRunID { get; set; }
        public int SubsectorTVItemID { get; set; }
        public int DrogueNumber { get; set; }
        public int DrogueType { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime RunStartDateTime { get; set; }
        public bool IsRisingTide { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(SubsectorTVItemID))]
        [InverseProperty(nameof(TVItems.DrogueRuns))]
        public virtual TVItems SubsectorTVItem { get; set; }
        [InverseProperty("DrogueRun")]
        public virtual ICollection<DrogueRunPositions> DrogueRunPositions { get; set; }
    }
}
