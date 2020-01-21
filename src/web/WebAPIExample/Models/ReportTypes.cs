using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class ReportTypes
    {
        public ReportTypes()
        {
            ReportSections = new HashSet<ReportSections>();
            ReportTypeLanguages = new HashSet<ReportTypeLanguages>();
        }

        [Key]
        public int ReportTypeID { get; set; }
        public int TVType { get; set; }
        public int FileType { get; set; }
        [Required]
        [StringLength(100)]
        public string UniqueCode { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [InverseProperty("ReportType")]
        public virtual ICollection<ReportSections> ReportSections { get; set; }
        [InverseProperty("ReportType")]
        public virtual ICollection<ReportTypeLanguages> ReportTypeLanguages { get; set; }
    }
}
