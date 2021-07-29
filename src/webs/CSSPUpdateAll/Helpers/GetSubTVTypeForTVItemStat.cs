using CSSPDBModels;
using CSSPDBServices;
using CSSPEnums;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace CSSPUpdateAll
{
    public partial class Startup
    {
        private List<TVTypeEnum> GetSubTVTypeForTVItemStat(TVTypeEnum TVType)
        {
            List<TVTypeEnum> SubTVTypeList = new List<TVTypeEnum>();
            switch (TVType)
            {
                case TVTypeEnum.Root:
                    {
                        SubTVTypeList = new List<TVTypeEnum>()
                        {
                            //TVTypeEnum.Address,
                            TVTypeEnum.Area,
                            //TVTypeEnum.ClimateSite,
                            //TVTypeEnum.Contact,
                            TVTypeEnum.Country,
                            //TVTypeEnum.Email,
                            TVTypeEnum.File,
                            TVTypeEnum.TotalFile,
                            //TVTypeEnum.HydrometricSite,
                            TVTypeEnum.Infrastructure,
                            TVTypeEnum.MikeScenario,
                            TVTypeEnum.Municipality,
                            //TVTypeEnum.MWQMSite,
                            //TVTypeEnum.MWQMRun,
                            TVTypeEnum.PolSourceSite,
                            TVTypeEnum.Province,
                            TVTypeEnum.Sector,
                            TVTypeEnum.Subsector,
                            //TVTypeEnum.Tel,
                            //TVTypeEnum.TideSite,
                            //TVTypeEnum.MWQMSiteSample,
                            TVTypeEnum.WasteWaterTreatmentPlant,
                            TVTypeEnum.LiftStation,
                            //TVTypeEnum.Spill,
                            TVTypeEnum.BoxModel,
                            TVTypeEnum.VisualPlumesScenario,
                        };
                    }
                    break;
                case TVTypeEnum.Area:
                    {
                        SubTVTypeList = new List<TVTypeEnum>()
                        {
                            //TVTypeEnum.Address,
                            //TVTypeEnum.ClimateSite,
                            TVTypeEnum.File,
                            TVTypeEnum.TotalFile,
                            //TVTypeEnum.HydrometricSite,
                            //TVTypeEnum.Infrastructure,
                            //TVTypeEnum.MikeScenario,
                            //TVTypeEnum.Municipality,
                            //TVTypeEnum.MWQMSite,
                            //TVTypeEnum.MWQMRun,
                            TVTypeEnum.PolSourceSite,
                            TVTypeEnum.Sector,
                            TVTypeEnum.Subsector,
                            //TVTypeEnum.TideSite,
                            //TVTypeEnum.MWQMSiteSample,
                            //TVTypeEnum.WasteWaterTreatmentPlant,
                            //TVTypeEnum.LiftStation,
                            //TVTypeEnum.Spill,
                            //TVTypeEnum.BoxModel,
                            //TVTypeEnum.VisualPlumesScenario,
                            //TVTypeEnum.Contact,
                        };
                    }
                    break;
                case TVTypeEnum.Country:
                    {
                        SubTVTypeList = new List<TVTypeEnum>()
                        {
                            TVTypeEnum.Area,
                            //TVTypeEnum.ClimateSite,
                            TVTypeEnum.File,
                            //TVTypeEnum.HydrometricSite,
                            TVTypeEnum.Infrastructure,
                            TVTypeEnum.MikeScenario,
                            TVTypeEnum.Municipality,
                            //TVTypeEnum.MWQMSite,
                            //TVTypeEnum.MWQMRun,
                            TVTypeEnum.PolSourceSite,
                            TVTypeEnum.Province,
                            TVTypeEnum.Sector,
                            TVTypeEnum.Subsector,
                            //TVTypeEnum.TideSite,
                            //TVTypeEnum.MWQMSiteSample,
                            TVTypeEnum.WasteWaterTreatmentPlant,
                            TVTypeEnum.LiftStation,
                            //TVTypeEnum.Spill,
                            TVTypeEnum.BoxModel,
                            TVTypeEnum.VisualPlumesScenario,
                            //TVTypeEnum.Address,
                            TVTypeEnum.TotalFile,
                            //TVTypeEnum.Contact,
                        };
                    }
                    break;
                case TVTypeEnum.Infrastructure:
                    {
                        SubTVTypeList = new List<TVTypeEnum>()
                        {
                            //TVTypeEnum.File,
                            //TVTypeEnum.Spill,
                            //TVTypeEnum.BoxModel,
                            //TVTypeEnum.VisualPlumesScenario,
                        };
                    }
                    break;
                case TVTypeEnum.MikeScenario:
                    {
                        SubTVTypeList = new List<TVTypeEnum>()
                        {
                            //TVTypeEnum.File,
                            //TVTypeEnum.TotalFile,
                            //TVTypeEnum.MikeSource,
                        };
                    }
                    break;
                case TVTypeEnum.Municipality:
                    {
                        SubTVTypeList = new List<TVTypeEnum>()
                        {
                            //TVTypeEnum.Address,
                            //TVTypeEnum.Contact,
                            TVTypeEnum.File,
                            TVTypeEnum.TotalFile,
                            TVTypeEnum.Infrastructure,
                            TVTypeEnum.MikeScenario,
                            TVTypeEnum.WasteWaterTreatmentPlant,
                            TVTypeEnum.LiftStation,
                            //TVTypeEnum.Spill,
                            TVTypeEnum.BoxModel,
                            TVTypeEnum.VisualPlumesScenario,
                        };
                    }
                    break;
                case TVTypeEnum.MWQMSite:
                    {
                        SubTVTypeList = new List<TVTypeEnum>()
                        {
                            //TVTypeEnum.File,
                            //TVTypeEnum.MWQMSiteSample,
                            //TVTypeEnum.MWQMRun,
                        };
                    }
                    break;
                case TVTypeEnum.PolSourceSite:
                    {
                        SubTVTypeList = new List<TVTypeEnum>()
                        {
                            //TVTypeEnum.Address,
                            //TVTypeEnum.File,
                        };
                    }
                    break;
                case TVTypeEnum.Province:
                    {
                        SubTVTypeList = new List<TVTypeEnum>()
                        {
                            //TVTypeEnum.Address,
                            TVTypeEnum.Area,
                            //TVTypeEnum.ClimateSite,
                            TVTypeEnum.File,
                            TVTypeEnum.TotalFile,
                            //TVTypeEnum.HydrometricSite,
                            TVTypeEnum.Infrastructure,
                            TVTypeEnum.MikeScenario,
                            TVTypeEnum.Municipality,
                            //TVTypeEnum.MWQMSite,
                            //TVTypeEnum.MWQMRun,
                            TVTypeEnum.PolSourceSite,
                            TVTypeEnum.Sector,
                            TVTypeEnum.Subsector,
                            //TVTypeEnum.TideSite,
                            //TVTypeEnum.MWQMSiteSample,
                            TVTypeEnum.WasteWaterTreatmentPlant,
                            TVTypeEnum.LiftStation,
                            //TVTypeEnum.Spill,
                            TVTypeEnum.BoxModel,
                            TVTypeEnum.VisualPlumesScenario,
                            //TVTypeEnum.Contact,
                        };
                    }
                    break;
                case TVTypeEnum.Sector:
                    {
                        SubTVTypeList = new List<TVTypeEnum>()
                        {
                            //TVTypeEnum.ClimateSite,
                            TVTypeEnum.File,
                            //TVTypeEnum.HydrometricSite,
                            //TVTypeEnum.Infrastructure,
                            //TVTypeEnum.MikeScenario,
                            //TVTypeEnum.Municipality,
                            //TVTypeEnum.MWQMSite,
                            //TVTypeEnum.MWQMRun,
                            TVTypeEnum.PolSourceSite,
                            TVTypeEnum.Subsector,
                            //TVTypeEnum.TideSite,
                            //TVTypeEnum.MWQMSiteSample,
                            //TVTypeEnum.WasteWaterTreatmentPlant,
                            //TVTypeEnum.LiftStation,
                            //TVTypeEnum.Spill,
                            //TVTypeEnum.BoxModel,
                            //TVTypeEnum.VisualPlumesScenario,
                            //TVTypeEnum.Address,
                            //TVTypeEnum.Contact,
                            TVTypeEnum.TotalFile,
                        };
                    }
                    break;
                case TVTypeEnum.Subsector:
                    {
                        SubTVTypeList = new List<TVTypeEnum>()
                        {
                            //TVTypeEnum.ClimateSite,
                            TVTypeEnum.File,
                            //TVTypeEnum.HydrometricSite,
                            //TVTypeEnum.Infrastructure,
                            //TVTypeEnum.MikeScenario,
                            //TVTypeEnum.Municipality,
                            //TVTypeEnum.MWQMSite,
                            //TVTypeEnum.MWQMRun,
                            TVTypeEnum.PolSourceSite,
                            //TVTypeEnum.TideSite,
                            //TVTypeEnum.MWQMSiteSample,
                            //TVTypeEnum.WasteWaterTreatmentPlant,
                            //TVTypeEnum.LiftStation,
                            //TVTypeEnum.Spill,
                            //TVTypeEnum.BoxModel,
                            //TVTypeEnum.VisualPlumesScenario,
                            //TVTypeEnum.Address,
                            //TVTypeEnum.Contact,
                            TVTypeEnum.TotalFile,
                        };
                    }
                    break;
                case TVTypeEnum.MWQMRun:
                    {
                        SubTVTypeList = new List<TVTypeEnum>()
                        {
                            //TVTypeEnum.File,
                            //TVTypeEnum.MWQMSite,
                            //TVTypeEnum.MWQMSiteSample,
                        };
                    }
                    break;
                default:
                    break;
            }

            return SubTVTypeList;
        }

    }
}
