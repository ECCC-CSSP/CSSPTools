using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class MWQMSiteStartEndDates
    {
        [Key]
        public int MWQMSiteStartEndDateID { get; set; }
        public int MWQMSiteTVItemID { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EndDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(MWQMSiteTVItemID))]
        [InverseProperty(nameof(TVItems.MWQMSiteStartEndDates))]
        public virtual TVItems MWQMSiteTVItem { get; set; }
    }
}
