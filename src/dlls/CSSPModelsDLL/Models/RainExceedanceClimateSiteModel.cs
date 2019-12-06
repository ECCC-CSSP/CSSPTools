using CSSPEnumsDLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
    public class RainExceedanceClimateSiteModel : LastUpdateAndContactModel
    {
        public RainExceedanceClimateSiteModel()
        {
        }
        public int RainExceedanceClimateSiteID { get; set; }
        public int RainExceedanceTVItemID { get; set; }
        public int ClimateSiteTVItemID { get; set; }
    }

    public class RainExceedanceFullClimateSites
    {
        public RainExceedanceFullClimateSites()
        {
            ClimateSiteModelUsedAndWithinDistanceModelList = new List<ClimateSiteWithLatLngAndOrdinalModel>();
            CurrentlyUsedClimateSiteTVItemIDList = new List<int>();
        }

        public string Error { get; set; }
        public List<ClimateSiteWithLatLngAndOrdinalModel> ClimateSiteModelUsedAndWithinDistanceModelList { get; set; }
        public List<int> CurrentlyUsedClimateSiteTVItemIDList { get; set; }
        public RainExceedanceModel RainExceedanceModel { get; set; }
    }
}
