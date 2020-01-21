using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class AppTaskLanguages
    {
        [Key]
        public int AppTaskLanguageID { get; set; }
        public int AppTaskID { get; set; }
        public int Language { get; set; }
        [StringLength(250)]
        public string StatusText { get; set; }
        [StringLength(250)]
        public string ErrorText { get; set; }
        public int TranslationStatus { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(AppTaskID))]
        [InverseProperty(nameof(AppTasks.AppTaskLanguages))]
        public virtual AppTasks AppTask { get; set; }
    }
}
