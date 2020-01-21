using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class TVFiles
    {
        public TVFiles()
        {
            TVFileLanguages = new HashSet<TVFileLanguages>();
        }

        [Key]
        public int TVFileID { get; set; }
        public int TVFileTVItemID { get; set; }
        public int? TemplateTVType { get; set; }
        public int? ReportTypeID { get; set; }
        [Column(TypeName = "text")]
        public string Parameters { get; set; }
        public int? Year { get; set; }
        public int Language { get; set; }
        public int FilePurpose { get; set; }
        public int FileType { get; set; }
        public int FileSize_kb { get; set; }
        [Column(TypeName = "text")]
        public string FileInfo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime FileCreatedDate_UTC { get; set; }
        public bool? FromWater { get; set; }
        [StringLength(250)]
        public string ClientFilePath { get; set; }
        [Required]
        [StringLength(250)]
        public string ServerFileName { get; set; }
        [Required]
        [StringLength(250)]
        public string ServerFilePath { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(TVFileTVItemID))]
        [InverseProperty(nameof(TVItems.TVFiles))]
        public virtual TVItems TVFileTVItem { get; set; }
        [InverseProperty("TVFile")]
        public virtual ICollection<TVFileLanguages> TVFileLanguages { get; set; }
    }
}
