using CSSPEnumsDLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
    public class MikeScenarioResultModel : LastUpdateAndContactModel
    {
        public MikeScenarioResultModel()
        {
        }
        public int MikeScenarioResultID { get; set; }
        public int MikeScenarioTVItemID { get; set; }
        public string MikeScenarioTVText { get; set; }
        public string MikeResultsJSON { get; set; }
    }

    public class MIKEResult
    {
        public MIKEResult()
        {
            TimeStepDateTimeList = new List<DateTime>();
            MIKEMWQMSiteResultList = new List<MIKEMWQMSiteResult>();
            MIKESourceResultList = new List<MIKESourceResult>();
        }

        public int MikeScenarioTVItemID { get; set; }
        public string MikeScenarioTVText { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int ResultFrequency_Min { get; set; }
        public int NumberOfTimeSteps { get; set; }
        public List<DateTime> TimeStepDateTimeList { get; set; }
        public List<MIKEMWQMSiteResult> MIKEMWQMSiteResultList { get; set; }
        public List<MIKESourceResult> MIKESourceResultList { get; set; }
    }
    public class MIKEMWQMSiteResult
    {
        public MIKEMWQMSiteResult()
        {
            MWQMSiteTVItemID = -1;
            MWQMSiteTVText = "";
            Lat = -1.0f;
            Lng = -1.0f;
            ElementLat = -1.0f;
            ElementLng = -1.0f;
            NoSample = true;
            SampleDateTime = new DateTime();
            FC = -1.0f;
            Salinity = -1.0f;
            Temperature = -1.0f;
            TVLocation = new TVLocation();
            MIKEHydroResult = new MIKEHydroResult();
            MIKETransResult = new MIKETransResult();
        }
        public int MWQMSiteTVItemID { get; set; }
        public string MWQMSiteTVText { get; set; }
        public float Lat { get; set; }
        public float Lng { get; set; }
        public float ElementLat { get; set; }
        public float ElementLng { get; set; }
        public bool NoSample { get; set; }
        public DateTime SampleDateTime { get; set; }
        public float FC { get; set; }
        public float Salinity { get; set; }
        public float Temperature { get; set; }
        public TVLocation TVLocation { get; set; }
        public MIKEHydroResult MIKEHydroResult { get; set; }
        public MIKETransResult MIKETransResult { get; set; }
    }
    public class MIKEHydroResult
    {
        public MIKEHydroResult()
        {
            SurfaceElevationList = new List<float>();
            StillWaterDepthList = new List<float>();
            TotalWaterDepthList = new List<float>();
            UVelocityList = new List<float>();
            VVelocityList = new List<float>();
            DensityList = new List<float>();
            TemperatureList = new List<float>();
            SalinityList = new List<float>();
            CurrentSpeedList = new List<float>();
            CurrentDirectionList = new List<float>();
            WindUVelocityList = new List<float>();
            WindVVelocityList = new List<float>();
            PrecipitationList = new List<float>();
        }
        public List<float> SurfaceElevationList { get; set; }
        public List<float> StillWaterDepthList { get; set; }
        public List<float> TotalWaterDepthList { get; set; }
        public List<float> UVelocityList { get; set; }
        public List<float> VVelocityList { get; set; }
        public List<float> DensityList { get; set; }
        public List<float> TemperatureList { get; set; }
        public List<float> SalinityList { get; set; }
        public List<float> CurrentSpeedList { get; set; }
        public List<float> CurrentDirectionList { get; set; }
        public List<float> WindUVelocityList { get; set; }
        public List<float> WindVVelocityList { get; set; }
        public List<float> PrecipitationList { get; set; }
    }
    public class MIKETransResult
    {
        public MIKETransResult()
        {
            FCList = new List<float>();
            UVelocityList = new List<float>();
            VVelocityList = new List<float>();
        }

        public List<float> FCList { get; set; }
        public List<float> UVelocityList { get; set; }
        public List<float> VVelocityList { get; set; }

    }
    public class MIKESourceResult
    {
        public MIKESourceResult()
        {
            MWQMSourceTVItemID = -1;
            MWQMSourceTVText = "";
            Lat = -1.0f;
            Lng = -1.0f;
            DischargeList = new List<float>();
            FCList = new List<float>();
        }

        public int MWQMSourceTVItemID { get; set; }
        public string MWQMSourceTVText { get; set; }
        public float Lat { get; set; }
        public float Lng { get; set; }
        public List<float> DischargeList { get; set; }
        public List<float> FCList { get; set; }
    }


}
