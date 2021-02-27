import { Contact } from 'src/app/models/generated/db/Contact.model';
import { ContactModel } from 'src/app/models/generated/web/ContactModel.model';
import { EmailDistributionList } from 'src/app/models/generated/db/EmailDistributionList.model';
import { EmailDistributionListContact } from 'src/app/models/generated/db/EmailDistributionListContact.model';
import { EmailDistributionListContactLanguage } from 'src/app/models/generated/db/EmailDistributionListContactLanguage.model';
import { EmailDistributionListLanguage } from 'src/app/models/generated/db/EmailDistributionListLanguage.model';
import { InfrastructureModel } from 'src/app/models/generated/web/InfrastructureModel.model';
import { LabSheetModel } from 'src/app/models/generated/web/LabSheetModel.model';
import { MapInfoModel } from 'src/app/models/generated/web/MapInfoModel.model';
import { MikeBoundaryConditionModel } from 'src/app/models/generated/web/MikeBoundaryConditionModel.model';
import { MikeScenario } from 'src/app/models/generated/db/MikeScenario.model';
import { MikeSourceModel } from 'src/app/models/generated/web/MikeSourceModel.model';
import { MWQMAnalysisReportParameter } from 'src/app/models/generated/db/MWQMAnalysisReportParameter.model';
import { MWQMSubsector } from 'src/app/models/generated/db/MWQMSubsector.model';
import { MWQMSubsectorLanguage } from 'src/app/models/generated/db/MWQMSubsectorLanguage.model';
import { Preference } from 'src/app/models/generated/helper/Preference.model';
import { SamplingPlan } from 'src/app/models/generated/db/SamplingPlan.model';
import { SearchResult } from 'src/app/models/generated/helper/SearchResult.model';
import { TVFileModel } from 'src/app/models/generated/web/TVFileModel.model';
import { TVItemLink } from 'src/app/models/generated/db/TVItemLink.model';
import { UseOfSite } from 'src/app/models/generated/db/UseOfSite.model';
import { WebArea } from 'src/app/models/generated/web/WebArea.model';
import { WebBase } from 'src/app/models/generated/web/WebBase.model';
import { WebClimateDataValue } from 'src/app/models/generated/web/WebClimateDataValue.model';
import { WebClimateSite } from 'src/app/models/generated/web/WebClimateSite.model';
import { WebCountry } from 'src/app/models/generated/web/WebCountry.model';
import { WebDrogueRun } from 'src/app/models/generated/web/WebDrogueRun.model';
import { WebHydrometricDataValue } from 'src/app/models/generated/web/WebHydrometricDataValue.model';
import { WebHydrometricSite } from 'src/app/models/generated/web/WebHydrometricSite.model';
import { WebMikeScenario } from 'src/app/models/generated/web/WebMikeScenario.model';
import { WebMunicipalities } from 'src/app/models/generated/web/WebMunicipalities.model';
import { WebMunicipality } from 'src/app/models/generated/web/WebMunicipality.model';
import { WebMWQMRun } from 'src/app/models/generated/web/WebMWQMRun.model';
import { WebMWQMSample } from 'src/app/models/generated/web/WebMWQMSample.model';
import { WebMWQMSite } from 'src/app/models/generated/web/WebMWQMSite.model';
import { WebPolSourceSite } from 'src/app/models/generated/web/WebPolSourceSite.model';
import { WebProvince } from 'src/app/models/generated/web/WebProvince.model';
import { WebRoot } from 'src/app/models/generated/web/WebRoot.model';
import { WebSamplingPlan } from 'src/app/models/generated/web/WebSamplingPlan.model';
import { WebSector } from 'src/app/models/generated/web/WebSector.model';
import { WebSubsector } from 'src/app/models/generated/web/WebSubsector.model';
import { MWQMRun } from './generated/db/MWQMRun.model';
import { MWQMSite } from './generated/db/MWQMSite.model';
import { PolSourceSite } from './generated/db/PolSourceSite.model';
import { Subscription } from 'rxjs';
import { StatMWQMRun } from './generated/web/StatMWQMRun.model';
import { StatMWQMSite } from './generated/web/StatMWQMSite.model';
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

export interface AppLoaded {
    LoggedInContact?: Contact;
    BreadCrumbWebBaseList?: WebBase[];
    PreferenceList?: Preference[];

    WebAreaSubscription: Subscription;
    WebClimateDataValueSubscription: Subscription;
    WebClimateSiteSubscription: Subscription;
    WebContactSubscription: Subscription;
    WebCountrySubscription: Subscription;
    WebDrogueRunSubscription: Subscription;
    WebHelpDocSubscription: Subscription;
    WebHydrometricDataValueSubscription: Subscription;
    WebHydrometricSiteSubscription: Subscription;
    WebMikeScenarioSubscription: Subscription;
    WebMunicipalitiesSubscription: Subscription;
    WebMunicipalitySubscription: Subscription;
    WebMWQMLookupMPNSubscription: Subscription;
    WebMWQMRunSubscription: Subscription;
    WebMWQMSampleSubscription: Subscription;
    WebMWQMSiteSubscription: Subscription;
    WebPolSourceGroupingSubscription: Subscription;
    WebPolSourceSiteEffectTermSubscription: Subscription;
    WebPolSourceSiteSubscription: Subscription;
    WebProvinceSubscription: Subscription;
    WebAllReportTypesSubscription: Subscription;
    WebRootSubscription: Subscription;
    WebSamplingPlanSubscription: Subscription;
    WebSectorSubscription: Subscription;
    WebSubsectorSubscription: Subscription;
    WebAllTideLocationsSubscription: Subscription;
    WebSubscription: Subscription;

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

    // Complete list not related to a TVItemID
    WebAllContacts?: WebAllContacts;
    AdminContactList?: Contact[];
    WebAllCountries?: WebAllCountries;
    WebAllMunicipalities?: WebAllMunicipalities;
    WebAllProvinces?: WebAllProvinces;
    WebAllHelpDocs?: WebAllHelpDocs;
    WebAllMWQMLookupMPNs?: WebAllMWQMLookupMPNs;
    WebAllPolSourceGroupings?: WebAllPolSourceGroupings;
    WebAllPolSourceSiteEffectTerms?: WebAllPolSourceSiteEffectTerms;
    WebAllReportTypes?: WebAllReportTypes;
    WebAllTideLocations?: WebAllTideLocations;
    MapInfoModelList?: MapInfoModel[];

    SearchResult?: SearchResult[];

    // Root TVItemID related
    WebRoot?: WebRoot;
    BreadCrumbRootWebBaseList?: WebBase[];
    RootCountryList?: WebBase[];
    RootFileListList?: TVFileModel[][];

    // Country TVItemID related
    WebCountry?: WebCountry;
    BreadCrumbCountryWebBaseList?: WebBase[];
    CountryProvinceList?: WebBase[];
    CountryFileListList?: TVFileModel[][];
    EmailDistributionListContactLanguageList?: EmailDistributionListContactLanguage[];
    EmailDistributionListContactList?: EmailDistributionListContact[];
    EmailDistributionListLanguageList?: EmailDistributionListLanguage[];
    EmailDistributionListList?: EmailDistributionList[];

    // Province TVItemID related
    WebProvince?: WebProvince;
    BreadCrumbProvinceWebBaseList?: WebBase[];
    ProvinceAreaList?: WebBase[];
    ProvinceMunicipalityList?: WebBase[];
    ProvinceFileListList?: TVFileModel[][];
    ProvinceSamplingPlanList?: SamplingPlan[];
    // separate load
    WebMunicipalities?: WebMunicipalities;
    WebClimateSite?: WebClimateSite;
    WebClimateDataValue?: WebClimateDataValue;
    WebHydrometricSite?: WebHydrometricSite;
    WebHydrometricDataValue?: WebHydrometricDataValue;

    // Area TVItemID related
    WebArea?: WebArea;
    BreadCrumbAreaWebBaseList?: WebBase[];
    AreaSectorList?: WebBase[];
    AreaFileListList?: TVFileModel[][];

    // Sector TVItemID related
    WebSector?: WebSector;
    BreadCrumbSectorWebBaseList?: WebBase[];
    SectorSubsectorList?: WebBase[];
    SectorFileListList?: TVFileModel[][];
    SectorMIKEScenarioList?: WebBase[];

    // Subsector TVItemID related
    WebSubsector?: WebSubsector;
    BreadCrumbSubsectorWebBaseList?: WebBase[];
    SubsectorMWQMSiteList?: WebBase[];
    SubsectorMWQMRunList?: WebBase[];
    SubsectorPolSourceSiteList?: WebBase[];
    SubsectorFileListList?: TVFileModel[][];
    LabSheetModelList?: LabSheetModel[];
    MWQMAnalysisReportParameterList?: MWQMAnalysisReportParameter[];
    MWQMSubsector?: MWQMSubsector;
    MWQMSubsectorLanguageList?: MWQMSubsectorLanguage[];
    UseOfSiteList?: UseOfSite[];
    // separate load
    WebMWQMSite?: WebMWQMSite;
    WebMWQMRun?: WebMWQMRun;
    WebPolSourceSite?: WebPolSourceSite;
    WebMWQMSample1980?: WebMWQMSample;
    WebMWQMSample1990?: WebMWQMSample;
    WebMWQMSample2000?: WebMWQMSample;
    WebMWQMSample2010?: WebMWQMSample;
    WebMWQMSample2020?: WebMWQMSample;
    WebMWQMSample2030?: WebMWQMSample;
    WebMWQMSample2040?: WebMWQMSample;
    WebMWQMSample2050?: WebMWQMSample;
    WebMWQMSampleAll?: WebMWQMSample;
    WebDrogueRun?: WebDrogueRun;

    MWQMRunRoutingList?: MWQMRun[];
    MWQMSiteList?: MWQMSite[];
    StatMWQMRunList?: StatMWQMRun[];
    StatMWQMSiteList?: StatMWQMSite[];

    // Municipality TVItemID related -- this object is under province
    WebMunicipality?: WebMunicipality;
    BreadCrumbMunicipalityWebBaseList?: WebBase[];
    InfrastructureModelList?: InfrastructureModel[];
    MunicipalityFileListList?: TVFileModel[][];
    MunicipalityContactModelList?: ContactModel[];
    MunicipalityTVItemLinkList?: TVItemLink[];
    TVItemMikeScenarioList?: WebBase[];

    // Mike Scenario TVItemID related -- this object is under province
    WebMikeScenario?: WebMikeScenario;
    BreadCrumbMikeScenarioWebBaseList?: WebBase[];
    MikeScenarioFileListList?: TVFileModel[][];
    MikeBoundaryConditionModelMeshList: MikeBoundaryConditionModel[];
    MikeBoundaryConditionModelWebTideList: MikeBoundaryConditionModel[];
    MikeScenario: MikeScenario;
    MikeSourceModelList: MikeSourceModel[];

    // MWQM Run TVItemID related -- this object is under province
    WebMWQMRunScenario?: WebMWQMRun;
    BreadCrumbMWQMRunWebBaseList?: WebBase[];
    MWQMRunFileListList?: TVFileModel[][];
    MWQMRun: MWQMRun;

    // MWQM Site TVItemID related -- this object is under province
    WebMWQMSiteScenario?: WebMWQMSite;
    BreadCrumbMWQMSiteWebBaseList?: WebBase[];
    MWQMSiteFileListList?: TVFileModel[][];
    MWQMSite: MWQMSite;

    // MWQM Site TVItemID related -- this object is under province
    WebPolSourceSiteScenario?: WebPolSourceSite;
    BreadCrumbPolSourceSiteWebBaseList?: WebBase[];
    PolSourceSiteFileListList?: TVFileModel[][];
    PolSourceSite: PolSourceSite;

    // SamplingPlan SamplingPlanID related -- this object is under province
    WebSamplingPlan?: WebSamplingPlan;
}
