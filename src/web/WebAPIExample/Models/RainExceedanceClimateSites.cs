using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class RainExceedanceClimateSites
    {
        [Key]
        public int RainExceedanceClimateSiteID { get; set; }
        public int RainExceedanceTVItemID { get; set; }
        public int ClimateSiteTVItemID { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(ClimateSiteTVItemID))]
        [InverseProperty(nameof(TVItems.RainExceedanceClimateSitesClimateSiteTVItem))]
        public virtual TVItems ClimateSiteTVItem { get; set; }
        [ForeignKey(nameof(RainExceedanceTVItemID))]
        [InverseProperty(nameof(TVItems.RainExceedanceClimateSitesRainExceedanceTVItem))]
        public virtual TVItems RainExceedanceTVItem { get; set; }
    }
}
