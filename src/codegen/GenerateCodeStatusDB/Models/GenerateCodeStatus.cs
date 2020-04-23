using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GenerateCodeStatusDB.Models
{
    public partial class GenerateCodeStatus
    {
        public long StatusID { get; set; }
        public string Command { get; set; }
        public long PercentCompleted { get; set; }
        public string ErrorText { get; set; }
        public string StatusText { get; set; }
        public string LastUpdateDate { get; set; }
    }
}
