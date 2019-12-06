using CSSPEnumsDLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
    public class LogModel : LastUpdateAndContactModel
    {
        public LogModel()
        {
        }

        public int LogID { get; set; }
        public string TableName { get; set; }
        public int ID { get; set; }
        public LogCommandEnum LogCommand { get; set; }
        public string Information { get; set; }
    }
}
