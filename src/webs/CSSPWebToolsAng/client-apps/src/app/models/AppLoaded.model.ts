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
import { WebContact } from 'src/app/models/generated/web/WebContact.model';
import { WebCountry } from 'src/app/models/generated/web/WebCountry.model';
import { WebDrogueRun } from 'src/app/models/generated/web/WebDrogueRun.model';
import { WebHelpDoc } from 'src/app/models/generated/web/WebHelpDoc.model';
import { WebHydrometricDataValue } from 'src/app/models/generated/web/WebHydrometricDataValue.model';
import { WebHydrometricSite } from 'src/app/models/generated/web/WebHydrometricSite.model';
import { WebMikeScenario } from 'src/app/models/generated/web/WebMikeScenario.model';
import { WebMunicipalities } from 'src/app/models/generated/web/WebMunicipalities.model';
import { WebMunicipality } from 'src/app/models/generated/web/WebMunicipality.model';
import { WebMWQMLookupMPN } from 'src/app/models/generated/web/WebMWQMLookupMPN.model';
import { WebMWQMRun } from 'src/app/models/generated/web/WebMWQMRun.model';
import { WebMWQMSample } from 'src/app/models/generated/web/WebMWQMSample.model';
import { WebMWQMSite } from 'src/app/models/generated/web/WebMWQMSite.model';
import { WebPolSourceGrouping } from 'src/app/models/generated/web/WebPolSourceGrouping.model';
import { WebPolSourceSite } from 'src/app/models/generated/web/WebPolSourceSite.model';
import { WebPolSourceSiteEffectTerm } from 'src/app/models/generated/web/WebPolSourceSiteEffectTerm.model';
import { WebProvince } from 'src/app/models/generated/web/WebProvince.model';
import { WebReportType } from 'src/app/models/generated/web/WebReportType.model';
import { WebRoot } from 'src/app/models/generated/web/WebRoot.model';
import { WebSamplingPlan } from 'src/app/models/generated/web/WebSamplingPlan.model';
import { WebSector } from 'src/app/models/generated/web/WebSector.model';
import { WebSubsector } from 'src/app/models/generated/web/WebSubsector.model';
import { WebTideLocation } from 'src/app/models/generated/web/WebTideLocation.model';

export interface AppLoaded {
    LoggedInContact?: Contact;
    BreadCrumbWebBaseList?: WebBase[];
    PreferenceList?: Preference[];
   
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
    WebContact?: WebContact;
    AdminContactList?: Contact[];
    WebHelpDoc?: WebHelpDoc;
    WebMWQMLookupMPN?: WebMWQMLookupMPN;
    WebPolSourceGrouping?: WebPolSourceGrouping;
    WebPolSourceSiteEffectTerm?: WebPolSourceSiteEffectTerm;   
    WebReportType?: WebReportType;   
    WebTideLocation?: WebTideLocation;
    MapInfoModelList?: MapInfoModel[];
   
    SearchResult?: SearchResult[];
    
    // Root TVItemID related
    WebRoot?: WebRoot;
    RootCountryList?: WebBase[];
    RootFileListList?: TVFileModel[][];
    
    // Country TVItemID related
    WebCountry?: WebCountry;
    CountryProvinceList?: WebBase[];
    CountryFileListList?: TVFileModel[][];
    EmailDistributionListContactLanguageList?: EmailDistributionListContactLanguage[];
    EmailDistributionListContactList?: EmailDistributionListContact[];
    EmailDistributionListLanguageList?: EmailDistributionListLanguage[];
    EmailDistributionListList?: EmailDistributionList[];
    
    // Province TVItemID related
    WebProvince?: WebProvince;
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
    AreaSectorList?: WebBase[];
    AreaFileListList?: TVFileModel[][];

    // Sector TVItemID related
    WebSector?: WebSector;
    SectorSubsectorList?: WebBase[];
    SectorFileListList?: TVFileModel[][];
    SectorMIKEScenarioList?: WebBase[];
    
    // Subsector TVItemID related
    WebSubsector?: WebSubsector;
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

    // Municipality TVItemID related -- this object is under province
    WebMunicipality?: WebMunicipality;
    InfrastructureModelList?: InfrastructureModel[];
    MunicipalityFileListList?: TVFileModel[][];
    MunicipalityContactModelList?: ContactModel[];
    MunicipalityTVItemLinkList?: TVItemLink[];
    TVItemMikeScenarioList?: WebBase[];
    // separate load --- not this object is also used for MIKE Scenario under Sector
    WebMikeScenario?: WebMikeScenario;
    MikeScenarioFileListList?: TVFileModel[][];
    MikeBoundaryConditionModelMeshList: MikeBoundaryConditionModel[];
    MikeBoundaryConditionModelWebTideList: MikeBoundaryConditionModel[];
    MikeScenario: MikeScenario;
    MikeSourceModelList: MikeSourceModel[];

    // SamplingPlan SamplingPlanID related -- this object is under province
    WebSamplingPlan?: WebSamplingPlan;
}
