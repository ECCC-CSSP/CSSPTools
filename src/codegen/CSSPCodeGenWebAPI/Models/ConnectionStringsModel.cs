﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSSPCodeGenWebAPI.Models
{
    public class ConnectionStringsModel
    {
        public string CSSPDB { get; set; }
        public string CSSPDB2 { get; set; }
        public string TestDB { get; set; }
        public string GenerateCodeSatusDB { get; set; }
    }
}