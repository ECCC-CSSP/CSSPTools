using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class MikeScenarioResults
    {
        [Key]
        public int MikeScenarioResultID { get; set; }
        public int MikeScenarioTVItemID { get; set; }
        [Column(TypeName = "text")]
        public string MikeResultsJSON { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(MikeScenarioTVItemID))]
        [InverseProperty(nameof(TVItems.MikeScenarioResults))]
        public virtual TVItems MikeScenarioTVItem { get; set; }
    }
}
