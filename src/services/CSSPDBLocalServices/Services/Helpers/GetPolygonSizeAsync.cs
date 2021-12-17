namespace CSSPDBLocalServices;

public partial class HelperLocalService : ControllerBase, IHelperLocalService
{
    public async Task<double> GetPolygonSizeAsync(TVTypeEnum tvType)
    {
        switch (tvType)
        {
            case TVTypeEnum.Address:
                return await Task.FromResult(0.1D);
            case TVTypeEnum.Area:
                return await Task.FromResult(0.1D);
            case TVTypeEnum.Classification:
                return await Task.FromResult(0.1D);
            case TVTypeEnum.ClimateSite:
                return await Task.FromResult(0.1D);
            case TVTypeEnum.Country:
                return await Task.FromResult(10.0D);
            case TVTypeEnum.Email:
                return await Task.FromResult(0.1D);
            case TVTypeEnum.EmailDistributionList:
                return await Task.FromResult(0.1D);
            case TVTypeEnum.File:
                return await Task.FromResult(0.1D);
            case TVTypeEnum.Infrastructure:
                return await Task.FromResult(0.1D);
            case TVTypeEnum.HydrometricSite:
                return await Task.FromResult(0.1D);
            case TVTypeEnum.MikeBoundaryConditionMesh:
                return await Task.FromResult(0.1D);
            case TVTypeEnum.MikeBoundaryConditionWebTide:
                return await Task.FromResult(0.1D);
            case TVTypeEnum.MikeScenario:
                return await Task.FromResult(0.1D);
            case TVTypeEnum.MikeSource:
                return await Task.FromResult(0.1D);
            case TVTypeEnum.Municipality:
                return await Task.FromResult(0.1D);
            case TVTypeEnum.MWQMRun:
                return await Task.FromResult(0.1D);
            case TVTypeEnum.MWQMSite:
                return await Task.FromResult(0.1D);
            case TVTypeEnum.PolSourceSite:
                return await Task.FromResult(0.1D);
            case TVTypeEnum.Province:
                return await Task.FromResult(0.1D);
            case TVTypeEnum.RainExceedance:
                return await Task.FromResult(0.1D);
            case TVTypeEnum.SamplingPlan:
                return await Task.FromResult(0.1D);
            case TVTypeEnum.Sector:
                return await Task.FromResult(0.1D);
            case TVTypeEnum.Subsector:
                return await Task.FromResult(0.1D);
            case TVTypeEnum.Tel:
                return await Task.FromResult(0.1D);
            case TVTypeEnum.TideSite:
                return await Task.FromResult(0.1D);
            default:
                return await Task.FromResult(0.1D);
        }
    }
}

