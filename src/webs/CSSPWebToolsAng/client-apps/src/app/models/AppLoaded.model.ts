import { Contact } from './generated/Contact.model';
import { ContactModel } from './generated/ContactModel.model';
import { EmailDistributionList } from './generated/EmailDistributionList.model';
import { EmailDistributionListContact } from './generated/EmailDistributionListContact.model';
import { EmailDistributionListContactLanguage } from './generated/EmailDistributionListContactLanguage.model';
import { EmailDistributionListLanguage } from './generated/EmailDistributionListLanguage.model';
import { InfrastructureModel } from './generated/InfrastructureModel.model';
import { LabSheetModel } from './generated/LabSheetModel.model';
import { MikeBoundaryConditionModel } from './generated/MikeBoundaryConditionModel.model';
import { MikeScenario } from './generated/MikeScenario.model';
import { MikeSourceModel } from './generated/MikeSourceModel.model';
import { MWQMAnalysisReportParameter } from './generated/MWQMAnalysisReportParameter.model';
import { MWQMSubsector } from './generated/MWQMSubsector.model';
import { MWQMSubsectorLanguage } from './generated/MWQMSubsectorLanguage.model';
import { Preference } from './generated/Preference.model';
import { SamplingPlan } from './generated/SamplingPlan.model';
import { SearchResult } from './generated/SearchResult.model';
import { TVFileModel } from './generated/TVFileModel.model';
import { TVItemLink } from './generated/TVItemLink.model';
import { UseOfSite } from './generated/UseOfSite.model';
import { WebArea } from './generated/WebArea.model';
import { WebBase } from './generated/WebBase.model';
import { WebClimateDataValue } from './generated/WebClimateDataValue.model';
import { WebClimateSite } from './generated/WebClimateSite.model';
import { WebContact } from './generated/WebContact.model';
import { WebCountry } from './generated/WebCountry.model';
import { WebDrogueRun } from './generated/WebDrogueRun.model';
import { WebHelpDoc } from './generated/WebHelpDoc.model';
import { WebHydrometricDataValue } from './generated/WebHydrometricDataValue.model';
import { WebHydrometricSite } from './generated/WebHydrometricSite.model';
import { WebMikeScenario } from './generated/WebMikeScenario.model';
import { WebMunicipalities } from './generated/WebMunicipalities.model';
import { WebMunicipality } from './generated/WebMunicipality.model';
import { WebMWQMLookupMPN } from './generated/WebMWQMLookupMPN.model';
import { WebMWQMRun } from './generated/WebMWQMRun.model';
import { WebMWQMSample } from './generated/WebMWQMSample.model';
import { WebMWQMSite } from './generated/WebMWQMSite.model';
import { WebPolSourceGrouping } from './generated/WebPolSourceGrouping.model';
import { WebPolSourceSite } from './generated/WebPolSourceSite.model';
import { WebPolSourceSiteEffectTerm } from './generated/WebPolSourceSiteEffectTerm.model';
import { WebProvince } from './generated/WebProvince.model';
import { WebReportType } from './generated/WebReportType.model';
import { WebRoot } from './generated/WebRoot.model';
import { WebSamplingPlan } from './generated/WebSamplingPlan.model';
import { WebSector } from './generated/WebSector.model';
import { WebSubsector } from './generated/WebSubsector.model';
import { WebTideLocation } from './generated/WebTideLocation.model';
import { HttpStatus } from './HttpStatus.model';

export interface AppLoaded extends HttpStatus {
    LoggedInContact?: Contact;
    BreadCrumbWebBaseList?: WebBase[];
    PreferenceList?: Preference[];
    
    // Complete list not related to a TVItemID
    WebContact?: WebContact;
    AdminContactList?: Contact[];
    WebHelpDoc?: WebHelpDoc;
    WebMWQMLookupMPN?: WebMWQMLookupMPN;
    WebPolSourceGrouping?: WebPolSourceGrouping;
    WebPolSourceSiteEffectTerm?: WebPolSourceSiteEffectTerm;   
    WebReportType?: WebReportType;   
    WebTideLocation?: WebTideLocation;
   
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
