﻿using System;
using System.Collections.Generic;

namespace CSSPWebAPIs.Models.Temp
{
    public partial class Classifications
    {
        public int ClassificationID { get; set; }
        public int ClassificationTVItemID { get; set; }
        public int ClassificationType { get; set; }
        public int Ordinal { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual TVItems ClassificationTVItem { get; set; }
    }
}