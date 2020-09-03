/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\WebAPIClassNameControllerGenerated.exe
 *
 * Do not edit this file.
 *
 */

using CSSPServices;
using Microsoft.Extensions.DependencyInjection;

namespace CSSPWebAPIsLocalLocal
{
    public partial class Startup
    {
        private void LoadAllDBServices(IServiceCollection services)
        {
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IAppErrLogService, AppErrLogService>();
            services.AddScoped<IAppTaskService, AppTaskService>();
            services.AddScoped<IAppTaskLanguageService, AppTaskLanguageService>();
            services.AddScoped<IAspNetUserService, AspNetUserService>();
            services.AddScoped<IBoxModelService, BoxModelService>();
            services.AddScoped<IBoxModelLanguageService, BoxModelLanguageService>();
            services.AddScoped<IBoxModelResultService, BoxModelResultService>();
            services.AddScoped<IClassificationService, ClassificationService>();
            services.AddScoped<IClimateDataValueService, ClimateDataValueService>();
            services.AddScoped<IClimateSiteService, ClimateSiteService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IContactPreferenceService, ContactPreferenceService>();
            services.AddScoped<IContactShortcutService, ContactShortcutService>();
            services.AddScoped<IDocTemplateService, DocTemplateService>();
            services.AddScoped<IDrogueRunService, DrogueRunService>();
            services.AddScoped<IDrogueRunPositionService, DrogueRunPositionService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IEmailDistributionListService, EmailDistributionListService>();
            services.AddScoped<IEmailDistributionListContactService, EmailDistributionListContactService>();
            services.AddScoped<IEmailDistributionListContactLanguageService, EmailDistributionListContactLanguageService>();
            services.AddScoped<IEmailDistributionListLanguageService, EmailDistributionListLanguageService>();
            services.AddScoped<IHelpDocService, HelpDocService>();
            services.AddScoped<IHydrometricDataValueService, HydrometricDataValueService>();
            services.AddScoped<IHydrometricSiteService, HydrometricSiteService>();
            services.AddScoped<IInfrastructureService, InfrastructureService>();
            services.AddScoped<IInfrastructureLanguageService, InfrastructureLanguageService>();
            services.AddScoped<ILabSheetService, LabSheetService>();
            services.AddScoped<ILabSheetDetailService, LabSheetDetailService>();
            services.AddScoped<ILabSheetTubeMPNDetailService, LabSheetTubeMPNDetailService>();
            services.AddScoped<ILogService, LogService>();
            services.AddScoped<IMapInfoService, MapInfoService>();
            services.AddScoped<IMapInfoPointService, MapInfoPointService>();
            services.AddScoped<IMikeBoundaryConditionService, MikeBoundaryConditionService>();
            services.AddScoped<IMikeScenarioService, MikeScenarioService>();
            services.AddScoped<IMikeScenarioResultService, MikeScenarioResultService>();
            services.AddScoped<IMikeSourceService, MikeSourceService>();
            services.AddScoped<IMikeSourceStartEndService, MikeSourceStartEndService>();
            services.AddScoped<IMWQMAnalysisReportParameterService, MWQMAnalysisReportParameterService>();
            services.AddScoped<IMWQMLookupMPNService, MWQMLookupMPNService>();
            services.AddScoped<IMWQMRunService, MWQMRunService>();
            services.AddScoped<IMWQMRunLanguageService, MWQMRunLanguageService>();
            services.AddScoped<IMWQMSampleService, MWQMSampleService>();
            services.AddScoped<IMWQMSampleLanguageService, MWQMSampleLanguageService>();
            services.AddScoped<IMWQMSiteService, MWQMSiteService>();
            services.AddScoped<IMWQMSiteStartEndDateService, MWQMSiteStartEndDateService>();
            services.AddScoped<IMWQMSubsectorService, MWQMSubsectorService>();
            services.AddScoped<IMWQMSubsectorLanguageService, MWQMSubsectorLanguageService>();
            services.AddScoped<IPolSourceGroupingService, PolSourceGroupingService>();
            services.AddScoped<IPolSourceGroupingLanguageService, PolSourceGroupingLanguageService>();
            services.AddScoped<IPolSourceObservationService, PolSourceObservationService>();
            services.AddScoped<IPolSourceObservationIssueService, PolSourceObservationIssueService>();
            services.AddScoped<IPolSourceSiteService, PolSourceSiteService>();
            services.AddScoped<IPolSourceSiteEffectService, PolSourceSiteEffectService>();
            services.AddScoped<IPolSourceSiteEffectTermService, PolSourceSiteEffectTermService>();
            services.AddScoped<IRainExceedanceService, RainExceedanceService>();
            services.AddScoped<IRainExceedanceClimateSiteService, RainExceedanceClimateSiteService>();
            services.AddScoped<IRatingCurveService, RatingCurveService>();
            services.AddScoped<IRatingCurveValueService, RatingCurveValueService>();
            services.AddScoped<IReportSectionService, ReportSectionService>();
            services.AddScoped<IReportTypeService, ReportTypeService>();
            services.AddScoped<IResetPasswordService, ResetPasswordService>();
            services.AddScoped<ISamplingPlanService, SamplingPlanService>();
            services.AddScoped<ISamplingPlanEmailService, SamplingPlanEmailService>();
            services.AddScoped<ISamplingPlanSubsectorService, SamplingPlanSubsectorService>();
            services.AddScoped<ISamplingPlanSubsectorSiteService, SamplingPlanSubsectorSiteService>();
            services.AddScoped<ISpillService, SpillService>();
            services.AddScoped<ISpillLanguageService, SpillLanguageService>();
            services.AddScoped<ITelService, TelService>();
            services.AddScoped<ITideDataValueService, TideDataValueService>();
            services.AddScoped<ITideLocationService, TideLocationService>();
            services.AddScoped<ITideSiteService, TideSiteService>();
            services.AddScoped<ITVFileService, TVFileService>();
            services.AddScoped<ITVFileLanguageService, TVFileLanguageService>();
            services.AddScoped<ITVItemService, TVItemService>();
            services.AddScoped<ITVItemLanguageService, TVItemLanguageService>();
            services.AddScoped<ITVItemLinkService, TVItemLinkService>();
            services.AddScoped<ITVItemStatService, TVItemStatService>();
            services.AddScoped<ITVItemUserAuthorizationService, TVItemUserAuthorizationService>();
            services.AddScoped<ITVTypeUserAuthorizationService, TVTypeUserAuthorizationService>();
            services.AddScoped<IUseOfSiteService, UseOfSiteService>();
            services.AddScoped<IVPAmbientService, VPAmbientService>();
            services.AddScoped<IVPResultService, VPResultService>();
            services.AddScoped<IVPScenarioService, VPScenarioService>();
            services.AddScoped<IVPScenarioLanguageService, VPScenarioLanguageService>();

        }
    }
}
