using CSSPEnumsDLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
    public class EmailDistributionListContactModel : LastUpdateAndContactModel
    {
        public EmailDistributionListContactModel()
        {
        }
        public int EmailDistributionListContactID { get; set; }
        public int EmailDistributionListID { get; set; }
        public bool IsCC { get; set; }
        public string Agency { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool CMPRainfallSeasonal { get; set; }
        public bool CMPWastewater { get; set; }
        public bool EmergencyWeather { get; set; }
        public bool EmergencyWastewater { get; set; }
        public bool ReopeningAllTypes { get; set; }
    }
}
