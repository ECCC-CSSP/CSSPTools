import { Contact } from 'src/app/models/generated/db/Contact.model';
import { SearchResult } from 'src/app/models/generated/helper/SearchResult.model';
import { WebArea } from 'src/app/models/generated/web/WebArea.model';
import { WebClimateSites } from 'src/app/models/generated/web/WebClimateSites.model';
import { WebCountry } from 'src/app/models/generated/web/WebCountry.model';
import { WebDrogueRuns } from 'src/app/models/generated/web/WebDrogueRuns.model';
import { WebHydrometricSites } from 'src/app/models/generated/web/WebHydrometricSites.model';
import { WebMikeScenarios } from 'src/app/models/generated/web/WebMikeScenarios.model';
import { WebMunicipality } from 'src/app/models/generated/web/WebMunicipality.model';
import { WebMWQMRuns } from 'src/app/models/generated/web/WebMWQMRuns.model';
import { WebMWQMSites } from 'src/app/models/generated/web/WebMWQMSites.model';
import { WebPolSourceSites } from 'src/app/models/generated/web/WebPolSourceSites.model';
import { WebProvince } from 'src/app/models/generated/web/WebProvince.model';
import { WebRoot } from 'src/app/models/generated/web/WebRoot.model';
import { WebSector } from 'src/app/models/generated/web/WebSector.model';
import { WebSubsector } from 'src/app/models/generated/web/WebSubsector.model';
//import { Subscription } from 'rxjs';
import { WebAllCountries } from './generated/web/WebAllCountries.model';
import { WebAllMunicipalities } from './generated/web/WebAllMunicipalities.model';
import { WebAllProvinces } from './generated/web/WebAllProvinces.model';
import { WebAllReportTypes } from './generated/web/WebAllReportTypes.model';
import { WebAllContacts } from './generated/web/WebAllContacts.model';
import { WebAllHelpDocs } from './generated/web/WebAllHelpDocs.model';
import { WebAllMWQMLookupMPNs } from './generated/web/WebAllMWQMLookupMPNs.model';
import { WebAllPolSourceGroupings } from './generated/web/WebAllPolSourceGroupings.model';
import { WebAllPolSourceSiteEffectTerms } from './generated/web/WebAllPolSourceSiteEffectTerms.model';
import { WebAllTideLocations } from './generated/web/WebAllTideLocations.model';
import { TVItemStatModel } from './generated/web/TVItemStatModel.model';
import { WebAllAddresses } from './generated/web/WebAllAddresses.model';
import { WebAllEmails } from './generated/web/WebAllEmails.model';
import { WebAllTels } from './generated/web/WebAllTels.model';
import { WebAllTVItemLanguages } from './generated/web/WebAllTVItemLanguages.model';
import { WebAllTVItems } from './generated/web/WebAllTVItems.model';
import { WebLabSheets } from './generated/web/WebLabSheets.model';
import { WebMWQMSamples } from './generated/web/WebMWQMSamples.model';
import { WebTideSites } from './generated/web/WebTideSites.model';

export interface AppLoaded {
    LoggedInContact?: Contact;
    BreadCrumbWebBaseList?: TVItemStatModel[];

    // WebAllAddressesSubscription?: Subscription;
    // WebAllContactsSubscription?: Subscription;
    // WebAllCountriesSubscription?: Subscription;
    // WebAllEmailsSubscription?: Subscription;
    // WebAllHelpDocsSubscription?: Subscription;
    // WebAllMunicipalitiesSubscription?: Subscription;
    // WebAllMWQMLookupMPNsSubscription?: Subscription;
    // WebAllPolSourceGroupingsSubscription?: Subscription;
    // WebAllPolSourceSiteEffectTermsSubscription?: Subscription;
    // WebAllProvincesSubscription?: Subscription;
    // WebAllReportTypesSubscription?: Subscription;
    // WebAllTelsSubscription?: Subscription;
    // WebAllTideLocationsSubscription?: Subscription;
    // WebAllTVItemLanguagesSubscription?: Subscription;
    // WebAllTVItemsSubscription?: Subscription;
    // WebAreaSubscription?: Subscription;
    // WebClimateSitesSubscription?: Subscription;
    // WebCountrySubscription?: Subscription;
    // WebDrogueRunsSubscription?: Subscription;
    // WebHydrometricSitesSubscription?: Subscription;
    // WebLabSheetsSubscription?: Subscription;
    // WebMikeScenariosSubscription?: Subscription;
    // WebMunicipalitySubscription?: Subscription;
    // WebMWQMRunsSubscription?: Subscription;
    // WebMWQMSamples1980_2020Subscription?: Subscription;
    // WebMWQMSamples2021_2060Subscription?: Subscription;
    // WebMWQMSitesSubscription?: Subscription;
    // WebPolSourceSitesSubscription?: Subscription;
    // WebProvincesSubscription?: Subscription;
    // WebRootSubscription?: Subscription;
    // WebSectorSubscription?: Subscription;
    // WebSubsectorSubscription?: Subscription;
    // WebTideSitesSubscription?: Subscription;

    // Map related items
    Map?: google.maps.Map;
    Zoom?: number;
    Center?: google.maps.LatLngLiteral;
    Options?: google.maps.MapOptions;
    GoogleCrossPolylineListMVC?: google.maps.MVCArray<google.maps.Polyline>;
    GoogleMarkerListMVC?: google.maps.MVCArray<google.maps.Marker>;
    GooglePolygonListMVC?: google.maps.MVCArray<google.maps.Polygon>;
    GooglePolylineListMVC?: google.maps.MVCArray<google.maps.Polyline>;
    InfoContent?: string;

    MarkerOriginal?: google.maps.LatLngLiteral;
    MarkerChanged?: google.maps.LatLngLiteral;   

    // Complete list not related to a TVItemID
    WebAllAddresses?: WebAllAddresses;
    WebAllContacts?: WebAllContacts;
    WebAllCountries?: WebAllCountries;
    WebAllEmails?: WebAllEmails;
    WebAllHelpDocs?: WebAllHelpDocs;
    WebAllMunicipalities?: WebAllMunicipalities;
    WebAllMWQMLookupMPNs?: WebAllMWQMLookupMPNs;
    WebAllPolSourceGroupings?: WebAllPolSourceGroupings;
    WebAllPolSourceSiteEffectTerms?: WebAllPolSourceSiteEffectTerms;
    WebAllProvinces?: WebAllProvinces;
    WebAllReportTypes?: WebAllReportTypes;
    WebAllTels?: WebAllTels;
    WebAllTideLocations?: WebAllTideLocations;
    WebAllTVItemLanguages?: WebAllTVItemLanguages;
    WebAllTVItems?: WebAllTVItems;
    WebArea?: WebArea;
    WebClimateSites?: WebClimateSites;
    WebCountry?: WebCountry;
    WebDrogueRuns?: WebDrogueRuns;
    WebHydrometricSites?: WebHydrometricSites;
    WebLabSheets?: WebLabSheets;
    WebMikeScenarios?: WebMikeScenarios;
    WebMunicipality?: WebMunicipality;
    WebMWQMRuns?: WebMWQMRuns;
    WebMWQMSamples1980_2020?: WebMWQMSamples;
    WebMWQMSamples2021_2060?: WebMWQMSamples;
    WebMWQMSites?: WebMWQMSites;
    WebPolSourceSites?: WebPolSourceSites;
    WebProvince?: WebProvince;
    WebRoot?: WebRoot;
    WebSector?: WebSector;
    WebSubsector?: WebSubsector;
    WebTideSites?: WebTideSites;

    // MapInfoModelList?: MapInfoModel[];
    //AdminContactList?: Contact[];

    SearchResult?: SearchResult[];

    // // Root TVItemID related
    // WebRoot?: WebRoot;
    // BreadCrumbRootWebBaseList?: TVItemStatModel[];
    // RootCountryList?: TVItemStatMapModel[];
    // RootFileListList?: TVFileModel[][];

    // // Country TVItemID related
    // WebCountry?: WebCountry;
    // BreadCrumbCountryWebBaseList?: TVItemStatModel[];
    // CountryProvinceList?: TVItemStatMapModel[];
    // CountryFileListList?: TVFileModel[][];
    // EmailDistributionListContactLanguageList?: EmailDistributionListContactLanguage[];
    // EmailDistributionListContactList?: EmailDistributionListContact[];
    // EmailDistributionListLanguageList?: EmailDistributionListLanguage[];
    // EmailDistributionListList?: EmailDistributionList[];

    // // Province TVItemID related
    // WebProvince?: WebProvince;
    // BreadCrumbProvinceWebBaseList?: TVItemStatModel[];
    // ProvinceAreaList?: TVItemStatMapModel[];
    // ProvinceMunicipalityList?: TVItemStatMapModel[];
    // ProvinceFileListList?: TVFileModel[][];
    // ProvinceSamplingPlanList?: SamplingPlan[];
    // // separate load
    // WebClimateSites?: WebClimateSites;
    // WebHydrometricSites?: WebHydrometricSites;

    // // Area TVItemID related
    // WebArea?: WebArea;
    // BreadCrumbAreaWebBaseList?: TVItemStatModel[];
    // AreaSectorList?: TVItemStatMapModel[];
    // AreaFileListList?: TVFileModel[][];

    // // Sector TVItemID related
    // WebSector?: WebSector;
    // BreadCrumbSectorWebBaseList?: TVItemStatModel[];
    // SectorSubsectorList?: TVItemStatMapModel[];
    // SectorFileListList?: TVFileModel[][];
    // //SectorMIKEScenarioList?: WebBase[];

    // // Subsector TVItemID related
    // WebSubsector?: WebSubsector;
    // BreadCrumbSubsectorWebBaseList?: TVItemStatModel[];
    // SubsectorMWQMSiteList?: TVItemStatMapModel[];
    // SubsectorMWQMRunList?: TVItemStatMapModel[];
    // SubsectorPolSourceSiteList?: TVItemStatMapModel[];
    // SubsectorFileListList?: TVFileModel[][];
    // LabSheetModelList?: LabSheetModel[];
    // MWQMAnalysisReportParameterList?: MWQMAnalysisReportParameter[];
    // MWQMSubsector?: MWQMSubsector;
    // MWQMSubsectorLanguageList?: MWQMSubsectorLanguage[];
    // UseOfSiteList?: UseOfSite[];
    // // separate load
    // WebMWQMSites?: WebMWQMSites;
    // WebMWQMRuns?: WebMWQMRuns;
    // WebPolSourceSites?: WebPolSourceSites;
    // WebDrogueRuns?: WebDrogueRuns;

    // MWQMRunRoutingList?: MWQMRun[];
    // MWQMSiteList?: MWQMSite[];
    // StatMWQMRunList?: StatMWQMRun[];
    // StatMWQMSiteList?: StatMWQMSite[];

    // // Municipality TVItemID related -- this object is under province
    // WebMunicipality?: WebMunicipality;
    // BreadCrumbMunicipalityWebBaseList?: TVItemStatModel[];
    // InfrastructureModelList?: InfrastructureModel[];
    // MunicipalityFileListList?: TVFileModel[][];
    // MunicipalityContactModelList?: ContactModel[];
    // MunicipalityTVItemLinkList?: TVItemLink[];
    // TVItemMikeScenarioList?: TVItemStatMapModel[];

    // // Mike Scenario TVItemID related -- this object is under province
    // WebMikeScenarios?: WebMikeScenarios;
    // BreadCrumbMikeScenarioWebBaseList?: TVItemStatModel[];
    // MikeScenarioFileListList?: TVFileModel[][];
    // MikeBoundaryConditionModelMeshList: MikeBoundaryConditionModel[];
    // MikeBoundaryConditionModelWebTideList: MikeBoundaryConditionModel[];
    // MikeScenario: MikeScenario;
    // MikeSourceModelList: MikeSourceModel[];

    // // MWQM Run TVItemID related -- this object is under province
    // WebMWQMRunScenario?: WebMWQMRuns;
    // BreadCrumbMWQMRunWebBaseList?: TVItemStatModel[];
    // MWQMRunFileListList?: TVFileModel[][];
    // MWQMRun: MWQMRun;

    // // MWQM Site TVItemID related -- this object is under province
    // WebMWQMSiteScenario?: WebMWQMSites;
    // BreadCrumbMWQMSiteWebBaseList?: TVItemStatModel[];
    // MWQMSiteFileListList?: TVFileModel[][];
    // MWQMSite: MWQMSite;

    // // MWQM Site TVItemID related -- this object is under province
    // WebPolSourceSiteScenario?: WebPolSourceSites;
    // BreadCrumbPolSourceSiteWebBaseList?: TVItemStatModel[];
    // PolSourceSiteFileListList?: TVFileModel[][];
    // PolSourceSite: PolSourceSite;
}
