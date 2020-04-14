using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSSPCodeGenWebAPI.Models
{
    public class GenerateCommand
    {
        public string Command { get; set; }
    }

    public class ActionReturn
    {
        public string OKText { get; set; }
        public string ErrorText { get; set; }
    }
}
