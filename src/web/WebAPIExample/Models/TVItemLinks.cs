using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class TVItemLinks
    {
        public TVItemLinks()
        {
            InverseParentTVItemLink = new HashSet<TVItemLinks>();
        }

        [Key]
        public int TVItemLinkID { get; set; }
        public int FromTVItemID { get; set; }
        public int ToTVItemID { get; set; }
        public int FromTVType { get; set; }
        public int ToTVType { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? StartDateTime_Local { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EndDateTime_Local { get; set; }
        public int Ordinal { get; set; }
        public int TVLevel { get; set; }
        [Required]
        [StringLength(250)]
        public string TVPath { get; set; }
        public int? ParentTVItemLinkID { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(FromTVItemID))]
        [InverseProperty(nameof(TVItems.TVItemLinksFromTVItem))]
        public virtual TVItems FromTVItem { get; set; }
        [ForeignKey(nameof(ParentTVItemLinkID))]
        [InverseProperty(nameof(TVItemLinks.InverseParentTVItemLink))]
        public virtual TVItemLinks ParentTVItemLink { get; set; }
        [ForeignKey(nameof(ToTVItemID))]
        [InverseProperty(nameof(TVItems.TVItemLinksToTVItem))]
        public virtual TVItems ToTVItem { get; set; }
        [InverseProperty(nameof(TVItemLinks.ParentTVItemLink))]
        public virtual ICollection<TVItemLinks> InverseParentTVItemLink { get; set; }
    }
}
