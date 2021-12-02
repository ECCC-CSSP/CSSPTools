namespace CSSPDBLocalServices;

public partial class HelperLocalService : ControllerBase, IHelperLocalService
{
    public List<TVTypeParentTVTypeRelation> GetTVTypeParentTVTypeRelationListAsync()
    {
        return new List<TVTypeParentTVTypeRelation>()
        {
            new TVTypeParentTVTypeRelation() {            // Root
                TVTypeParent = TVTypeEnum.Root,
                TVTypeChildList = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Root,
                    TVTypeEnum.Country,
                    TVTypeEnum.Address,
                    TVTypeEnum.Email,
                    TVTypeEnum.Tel,
                    TVTypeEnum.File,
                },
            },
            new TVTypeParentTVTypeRelation() {            // Country
                TVTypeParent = TVTypeEnum.Country,
                TVTypeChildList = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Province,
                    TVTypeEnum.RainExceedance,
                    TVTypeEnum.EmailDistributionList,
                    TVTypeEnum.File,
                },
            },
            new TVTypeParentTVTypeRelation() {            // Province
                TVTypeParent = TVTypeEnum.Province,
                TVTypeChildList = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Area,
                    TVTypeEnum.SamplingPlan,
                    TVTypeEnum.Municipality,
                    TVTypeEnum.ClimateSite,
                    TVTypeEnum.HydrometricSite,
                    TVTypeEnum.TideSite,
                    TVTypeEnum.File,
                },
            },
            new TVTypeParentTVTypeRelation() {            // Municipality
                TVTypeParent = TVTypeEnum.Municipality,
                TVTypeChildList = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Infrastructure,
                    TVTypeEnum.MikeScenario,
                    TVTypeEnum.File,
                },
            },
            new TVTypeParentTVTypeRelation() {            // Infrastructure
                TVTypeParent = TVTypeEnum.Infrastructure,
                TVTypeChildList = new List<TVTypeEnum>()
                {
                    TVTypeEnum.File,
                },
            },
            new TVTypeParentTVTypeRelation() {            // MikeScenario
                TVTypeParent = TVTypeEnum.MikeScenario,
                TVTypeChildList = new List<TVTypeEnum>()
                {
                    TVTypeEnum.MikeSource,
                    TVTypeEnum.MikeBoundaryConditionMesh,
                    TVTypeEnum.MikeBoundaryConditionWebTide,
                    TVTypeEnum.File,
                },
            },
            new TVTypeParentTVTypeRelation() {            // Area
                TVTypeParent = TVTypeEnum.Area,
                TVTypeChildList = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Sector,
                    TVTypeEnum.File,
                },
            },
            new TVTypeParentTVTypeRelation() {            // Sector
                TVTypeParent = TVTypeEnum.Sector,
                TVTypeChildList = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Subsector,
                    TVTypeEnum.File,
                },
            },
            new TVTypeParentTVTypeRelation() {            // Subsector
                TVTypeParent = TVTypeEnum.Subsector,
                TVTypeChildList = new List<TVTypeEnum>()
                {
                    TVTypeEnum.MWQMRun,
                    TVTypeEnum.MWQMSite,
                    TVTypeEnum.PolSourceSite,
                    TVTypeEnum.Classification,
                    TVTypeEnum.File,
                    TVTypeEnum.Approved,
                    TVTypeEnum.ConditionallyApproved,
                    TVTypeEnum.ConditionallyRestricted,
                    TVTypeEnum.Restricted,
                    TVTypeEnum.Prohibited,
                    TVTypeEnum.Unclassified,
                },
            },
            new TVTypeParentTVTypeRelation() {            // MWQMSite
                TVTypeParent = TVTypeEnum.MWQMSite,
                TVTypeChildList = new List<TVTypeEnum>()
                {
                    TVTypeEnum.File,
                },
            },
            new TVTypeParentTVTypeRelation() {            // PolSourceSite
                TVTypeParent = TVTypeEnum.PolSourceSite,
                TVTypeChildList = new List<TVTypeEnum>()
                {
                    TVTypeEnum.File,
                },
            },
        };
    }
}
