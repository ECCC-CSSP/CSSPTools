using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class MikeSources
    {
        public MikeSources()
        {
            MikeSourceStartEnds = new HashSet<MikeSourceStartEnds>();
        }

        [Key]
        public int MikeSourceID { get; set; }
        public int MikeSourceTVItemID { get; set; }
        public bool IsContinuous { get; set; }
        public bool Include { get; set; }
        public bool IsRiver { get; set; }
        public bool UseHydrometric { get; set; }
        public int? HydrometricTVItemID { get; set; }
        public double? DrainageArea_km2 { get; set; }
        public double? Factor { get; set; }
        [Required]
        [StringLength(50)]
        public string SourceNumberString { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(HydrometricTVItemID))]
        [InverseProperty(nameof(TVItems.MikeSourcesHydrometricTVItem))]
        public virtual TVItems HydrometricTVItem { get; set; }
        [ForeignKey(nameof(MikeSourceTVItemID))]
        [InverseProperty(nameof(TVItems.MikeSourcesMikeSourceTVItem))]
        public virtual TVItems MikeSourceTVItem { get; set; }
        [InverseProperty("MikeSource")]
        public virtual ICollection<MikeSourceStartEnds> MikeSourceStartEnds { get; set; }
    }
}
