using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CompareEnumsAndOldEnums.Models
{
    public partial class StatusAndResults
    {
        [Key]
        public long StatusAndResultID { get; set; }
        public string Command { get; set; }
        public long PercentCompleted { get; set; }
        public string StatusText { get; set; }
        public string LastUpdateDate { get; set; }
    }
}
