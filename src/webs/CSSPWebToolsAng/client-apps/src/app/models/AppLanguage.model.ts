import { HttpStatus } from './HttpStatus.model';

export interface AppLanguage extends HttpStatus {
    CountryShowProvince: string[];
    CountryProvinces: string[];
    CountryShowFiles: string[];
    CountryFiles: string[];
    CountryShowOpenDataNationalTools: string[];
    CountryOpenDataNational: string[];
    CountryShowEmailDistributionList: string[];
    CountryEmailDistributionList: string[];
    CountryShowRainExceedance: string[];
    CountryRainExceedance: string[];

    HomeCSSPWebTools: string[];
    HomeTheWebToolWillLetYou: string[];
    HomeViewAndUpdateWWTPInfo: string[];
    HomeMakeCalculationUsingBoxModelAndVisualPlumes: string[];
    HomeSetupAndRunMIKEScenariosAndStoreInputsAndResults: string[];
    HomeManageMWQMInformation: string[];
    HomeToHaveAccessWebToolsInformationAndApplication: string[];
    HomePleaseContactASiteAdministratorListedBelow: string[];
    HomeStartUsingCSSPWebTools: string[];
    HomeAzureVersion: string[];

    ProvinceShowAreas: string[];
    ProvinceAreas: string[];
    ProvinceShowMunicipalities: string[];
    ProvinceMunicipalities: string[];
    ProvinceShowFiles: string[];
    ProvinceFiles: string[];
    ProvinceShowOpenData: string[];
    ProvinceOpenData: string[];
    ProvinceShowSamplingPlan: string[];
    ProvinceSamplingPlan: string[];
    ProvinceShowProvinceTools: string[];
    ProvinceProvinceTools: string[];

    RootShowCountries: string[];
    RootCountries: string[];
    RootShowFiles: string[];
    RootFiles: string[];
    RootShowExportArcGISTools: string[];
    RootExportArcGIS: string[];

    SearchSearch: string[];

    ShellApplicationName: string[];
    ShellOpenContextMenu: string[];
    ShellReturnHome: string[];
    ShellShowMap: string[];
    ShellResizeMap: string[];

    SideNavMenuContextMenu: string[];
    SideNavMenuShowInactiveItems: string[];
    SideNavMenuInactive: string[];
    SideNavMenuShowDetails: string[];
    SideNavMenuDetails: string[];
    SideNavMenuShowEdit: string[];
    SideNavMenuEdit: string[];

    TVItemListDetailCountryProvince: string[];
    TVItemListDetailCountryMunicipality: string[];
    TVItemListDetailCountrySubsector: string[];
    TVItemListDetailCountryMWQMSite: string[];
    TVItemListDetailCountryMWQMRun: string[];
    TVItemListDetailCountryMWQMSample: string[];
    TVItemListDetailCountryMikeScenario: string[];

    TVItemListDetailProvinceMunicipality: string[];
    TVItemListDetailProvinceSubsector: string[];
    TVItemListDetailProvinceMWQMSite: string[];
    TVItemListDetailProvinceMWQMRun: string[];
    TVItemListDetailProvinceMWQMSample: string[];
    TVItemListDetailProvinceMikeScenario: string[];

    TVItemListDetailRootCountry: string[];
    TVItemListDetailRootProvince: string[];
    TVItemListDetailRootMunicipality: string[];
    TVItemListDetailRootSubsector: string[];
    TVItemListDetailRootMWQMSite: string[];
    TVItemListDetailRootMWQMRun: string[];
    TVItemListDetailRootMWQMSample: string[];
    TVItemListDetailRootMikeScenario: string[];

}
