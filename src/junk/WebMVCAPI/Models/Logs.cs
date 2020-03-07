using System;
using System.Collections.Generic;

namespace WebMVCAPI.Models
{
    public partial class Logs
    {
        public int LogID { get; set; }
        public string TableName { get; set; }
        public int ID { get; set; }
        public int LogCommand { get; set; }
        public string Information { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }
    }
}
