using System;
using System.Collections.Generic;
using System.Text;

namespace CSSPGenerateCodeBase.Models
{
    public class EnumsFiles
    {
        public EnumsFiles()
        {
            CSSPEnumsDLL = "";
            BaseDir = "";
            EnumsGenerated = "";
            EnumsTestGenerated = "";
        }

        public string CSSPEnumsDLL { get; set; }
        public string BaseDir { get; set; }
        public string EnumsGenerated { get; set; }
        public string EnumsTestGenerated { get; set; }
    }
}
