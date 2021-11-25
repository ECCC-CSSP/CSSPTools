namespace CSSPUpdateServices;

public partial class CSSPUpdateService : ControllerBase, ICSSPUpdateService
{
    public List<TVTypeEnum> GetSubTVTypeForTVItemStatAsync(TVTypeEnum TVType)
    {
        List<TVTypeEnum> SubTVTypeList = new List<TVTypeEnum>();
        switch (TVType)
        {
            case TVTypeEnum.Root:
                {
                    SubTVTypeList = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.Area,
                        TVTypeEnum.Country,
                        TVTypeEnum.File,
                        TVTypeEnum.TotalFile,
                        TVTypeEnum.Infrastructure,
                        TVTypeEnum.MikeScenario,
                        TVTypeEnum.Municipality,
                        TVTypeEnum.PolSourceSite,
                        TVTypeEnum.Province,
                        TVTypeEnum.Sector,
                        TVTypeEnum.Subsector,
                        TVTypeEnum.WasteWaterTreatmentPlant,
                        TVTypeEnum.LiftStation,
                        TVTypeEnum.BoxModel,
                        TVTypeEnum.VisualPlumesScenario,
                    };
                }
                break;
            case TVTypeEnum.Area:
                {
                    SubTVTypeList = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.File,
                        TVTypeEnum.TotalFile,
                        TVTypeEnum.PolSourceSite,
                        TVTypeEnum.Sector,
                        TVTypeEnum.Subsector,
                    };
                }
                break;
            case TVTypeEnum.Country:
                {
                    SubTVTypeList = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.Area,
                        TVTypeEnum.File,
                        TVTypeEnum.Infrastructure,
                        TVTypeEnum.MikeScenario,
                        TVTypeEnum.Municipality,
                        TVTypeEnum.PolSourceSite,
                        TVTypeEnum.Province,
                        TVTypeEnum.Sector,
                        TVTypeEnum.Subsector,
                        TVTypeEnum.WasteWaterTreatmentPlant,
                        TVTypeEnum.LiftStation,
                        TVTypeEnum.BoxModel,
                        TVTypeEnum.VisualPlumesScenario,
                        TVTypeEnum.TotalFile,
                    };
                }
                break;
            case TVTypeEnum.Municipality:
                {
                    SubTVTypeList = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.File,
                        TVTypeEnum.TotalFile,
                        TVTypeEnum.Infrastructure,
                        TVTypeEnum.MikeScenario,
                        TVTypeEnum.WasteWaterTreatmentPlant,
                        TVTypeEnum.LiftStation,
                        TVTypeEnum.BoxModel,
                        TVTypeEnum.VisualPlumesScenario,
                    };
                }
                break;
            case TVTypeEnum.Province:
                {
                    SubTVTypeList = new List<TVTypeEnum>()
                        {
                            TVTypeEnum.Area,
                            TVTypeEnum.File,
                            TVTypeEnum.TotalFile,
                            TVTypeEnum.Infrastructure,
                            TVTypeEnum.MikeScenario,
                            TVTypeEnum.Municipality,
                            TVTypeEnum.PolSourceSite,
                            TVTypeEnum.Sector,
                            TVTypeEnum.Subsector,
                            TVTypeEnum.WasteWaterTreatmentPlant,
                            TVTypeEnum.LiftStation,
                            TVTypeEnum.BoxModel,
                            TVTypeEnum.VisualPlumesScenario,
                        };
                }
                break;
            case TVTypeEnum.Sector:
                {
                    SubTVTypeList = new List<TVTypeEnum>()
                        {
                            TVTypeEnum.File,
                            TVTypeEnum.PolSourceSite,
                            TVTypeEnum.Subsector,
                            TVTypeEnum.TotalFile,
                        };
                }
                break;
            case TVTypeEnum.Subsector:
                {
                    SubTVTypeList = new List<TVTypeEnum>()
                        {
                            TVTypeEnum.File,
                            TVTypeEnum.PolSourceSite,
                            TVTypeEnum.TotalFile,
                        };
                }
                break;
            default:
                break;
        }

        return SubTVTypeList;
    }

}

