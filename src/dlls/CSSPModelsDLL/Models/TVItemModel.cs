using CSSPEnumsDLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
    public class TVItemModel : LastUpdateAndContactModel
    {
        public TVItemModel()
        {
        }
        public int TVItemID { get; set; }
        public int TVLevel { get; set; }
        public string TVPath { get; set; }
        public string TVText { get; set; }
        public TVTypeEnum TVType { get; set; }
        public TVAuthEnum TVAuth { get; set; }
        public int ParentID { get; set; }
        public bool IsActive { get; set; }
    }
    public class TVItemModelAndChildCount : TVItemModel
    {
        public int ChildCount { get; set; }
    }
    public class TVItemMoreInfoAreaModel
    {
        public TVItemMoreInfoAreaModel()
        {
        }

        public string Error { get; set; }
        public int MunicipalityCount { get; set; }
        public int WWTPCount { get; set; }
        public int LSCount { get; set; }
        public int SpillCount { get; set; }
        public int SectorCount { get; set; }
        public int SubSectorCount { get; set; }
        public int MWQMSampleCount { get; set; }
        public int MWQMSiteCount { get; set; }
        public int PolSourceSiteCount { get; set; }
    }
    public class TVItemMoreInfoFileModel
    {
        public TVItemMoreInfoFileModel()
        {
        }

        public string Error { get; set; }
        public string FullDesc { get; set; }
        public string Parameters { get; set; }
        public LanguageEnum Language { get; set; }
    }
    public class TVItemMoreInfoInfrastructureModel
    {
        public TVItemMoreInfoInfrastructureModel()
        {
        }

        public string Error { get; set; }
        public Nullable<float> PercOfTotalFlow { get; set; }
        public Nullable<float> AverageFlow_m3_day { get; set; }
        public Nullable<float> PeakFlow_m3_day { get; set; }
        public int BoxModelCount { get; set; }
        public int VPScenarioCount { get; set; }
    }
    public class TVItemMoreInfoMikeScenarioModel
    {
        public TVItemMoreInfoMikeScenarioModel()
        {
            TVItemMikeSourceModelList = new List<TVItemMikeSourceModel>();
        }

        public string Error { get; set; }
        public ScenarioStatusEnum ScenarioStatus { get; set; }
        public DateTime MikeScenarioStartDateTime_Local { get; set; }
        public DateTime MikeScenarioEndDateTime_Local { get; set; }
        public float WindSpeed_km_h { get; set; }
        public float WindDirection_deg { get; set; }
        public float DecayFactor_per_day { get; set; }
        public bool DecayIsConstant { get; set; }
        public float DecayFactorAmplitude { get; set; }
        public int ResultFrequency_min { get; set; }
        public float AmbientTemperature_C { get; set; }
        public float AmbientSalinity_PSU { get; set; }
        public float ManningNumber { get; set; }
        public int HydroFileSize { get; set; }
        public int TransFileSize { get; set; }
        public List<TVItemMikeSourceModel> TVItemMikeSourceModelList { get; set; }
    }
    public class TVItemMikeSourceModel : MikeSourceModel
    {
        public TVItemMikeSourceModel()
        {
            TVItemMikeSourceStartEndModelList = new List<MikeSourceStartEndModel>();
        }

        public List<MikeSourceStartEndModel> TVItemMikeSourceStartEndModelList { get; set; }
    }
    public class TVItemMoreInfoMunicipalityModel
    {
        public TVItemMoreInfoMunicipalityModel()
        {
        }

        public string Error { get; set; }
        public int WWTPCount { get; set; }
        public int LSCount { get; set; }
        public int SpillCount { get; set; }
        public int MikeScenarioCount { get; set; }
        public int BoxModelCount { get; set; }
        public int VPScenarioCount { get; set; }
    }
    public class TVItemMoreInfoPolSourceSiteModel
    {
        public TVItemMoreInfoPolSourceSiteModel()
        {
            IssuesTVTextList = new List<string>();
        }

        public string Error { get; set; }
        public string FullDesc { get; set; }
        public List<string> IssuesTVTextList { get; set; }
        public DateTime ObsDateTime_Local { get; set; }
        public bool DesktopReviewed { get; set; }
    }
    public class TVItemMoreInfoProvinceModel
    {
        public TVItemMoreInfoProvinceModel()
        {
        }

        public string Error { get; set; }
        public int MunicipalityCount { get; set; }
        public int WWTPCount { get; set; }
        public int LSCount { get; set; }
        public int SpillCount { get; set; }
        public int AreaCount { get; set; }
        public int SectorCount { get; set; }
        public int SubSectorCount { get; set; }
        public int MWQMSampleCount { get; set; }
        public int MWQMSiteCount { get; set; }
        public int PolSourceSiteCount { get; set; }
        public int MikeScenarioCount { get; set; }
        public int BoxModelCount { get; set; }
        public int VPScenarioCount { get; set; }
    }
    public class TVItemMoreInfoSectorModel
    {
        public TVItemMoreInfoSectorModel()
        {
        }

        public string Error { get; set; }
        public int MunicipalityCount { get; set; }
        public int WWTPCount { get; set; }
        public int LSCount { get; set; }
        public int SpillCount { get; set; }
        public int SubSectorCount { get; set; }
        public int MWQMSampleCount { get; set; }
        public int MWQMSiteCount { get; set; }
        public int PolSourceSiteCount { get; set; }
        public int MikeScenarioCount { get; set; }
        public int BoxModelCount { get; set; }
        public int VPScenarioCount { get; set; }
    }
    public class TVItemMoreInfoSubsectorModel
    {
        public TVItemMoreInfoSubsectorModel()
        {
        }

        public string Error { get; set; }
        public int MunicipalityCount { get; set; }
        public int WWTPCount { get; set; }
        public int LSCount { get; set; }
        public int SpillCount { get; set; }
        public int MWQMSampleCount { get; set; }
        public int MWQMSiteCount { get; set; }
        public int PolSourceSiteCount { get; set; }
        public int MikeScenarioCount { get; set; }
        public int BoxModelCount { get; set; }
        public int VPScenarioCount { get; set; }
    }
    public class TVItemMoreInfoMWQMRunModel
    {
        public TVItemMoreInfoMWQMRunModel()
        {
            MWQMSampleModelList = new List<MWQMSampleModel>();
        }

        public string Error { get; set; }
        public MWQMRunModel MWQMRunModel { get; set; }
        public List<MWQMSampleModel> MWQMSampleModelList { get; set; }
    }
    public class TVItemMoreInfoMWQMSiteModel
    {
        public TVItemMoreInfoMWQMSiteModel()
        {
        }

        public string Error { get; set; }
        public int MWQMSampleCount { get; set; }
        public float? SampCount { get; set; }
        public int SampMinYear { get; set; }
        public int SampMaxYear { get; set; }
        public float? MinFC { get; set; }
        public float? MaxFC { get; set; }
        public float? GeoMean { get; set; }
        public float? Median { get; set; }
        public float? P90 { get; set; }
        public float? PercOver43 { get; set; }
        public float? PercOver260 { get; set; }
        public int StatMinYear { get; set; }
        public int StatMaxYear { get; set; }
        public string Coloring { get; set; }
        public string Letter { get; set; }
        public DateTime? LastSampleDate { get; set; }
        public MWQMSiteLatestClassificationEnum MWQMSiteLatestClassification { get; set; }
    }
}
