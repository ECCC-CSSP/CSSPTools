﻿using System;
using System.Collections.Generic;

namespace CSSPWebAPIs.Models.Temp
{
    public partial class ResetPasswords
    {
        public int ResetPasswordID { get; set; }
        public string Email { get; set; }
        public DateTime ExpireDate_Local { get; set; }
        public string Code { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }
    }
}