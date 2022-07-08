import { Contact } from 'src/app/models/generated/db/Contact.model';
import { WebArea } from 'src/app/models/generated/models/WebArea.model';
import { WebClimateSites } from 'src/app/models/generated/models/WebClimateSites.model';
import { WebCountry } from 'src/app/models/generated/models/WebCountry.model';
import { WebDrogueRuns } from 'src/app/models/generated/models/WebDrogueRuns.model';
import { WebHydrometricSites } from 'src/app/models/generated/models/WebHydrometricSites.model';
import { WebMikeScenarios } from 'src/app/models/generated/models/WebMikeScenarios.model';
import { WebMunicipality } from 'src/app/models/generated/models/WebMunicipality.model';
import { WebMWQMRuns } from 'src/app/models/generated/models/WebMWQMRuns.model';
import { WebMWQMSites } from 'src/app/models/generated/models/WebMWQMSites.model';
import { WebPolSourceSites } from 'src/app/models/generated/models/WebPolSourceSites.model';
import { WebProvince } from 'src/app/models/generated/models/WebProvince.model';
import { WebRoot } from 'src/app/models/generated/models/WebRoot.model';
import { WebAllSearch } from '../../models/generated/models/WebAllSearch.model';
import { WebSector } from 'src/app/models/generated/models/WebSector.model';
import { WebSubsector } from 'src/app/models/generated/models/WebSubsector.model';
import { WebAllCountries } from 'src/app/models/generated/models/WebAllCountries.model';
import { WebAllMunicipalities } from 'src/app/models/generated/models/WebAllMunicipalities.model';
import { WebAllProvinces } from 'src/app/models/generated/models/WebAllProvinces.model';
import { WebAllReportTypes } from 'src/app/models/generated/models/WebAllReportTypes.model';
import { WebAllContacts } from 'src/app/models/generated/models/WebAllContacts.model';
import { WebAllHelpDocs } from 'src/app/models/generated/models/WebAllHelpDocs.model';
import { WebAllMWQMLookupMPNs } from 'src/app/models/generated/models/WebAllMWQMLookupMPNs.model';
import { WebAllPolSourceGroupings } from 'src/app/models/generated/models/WebAllPolSourceGroupings.model';
import { WebAllPolSourceSiteEffectTerms } from 'src/app/models/generated/models/WebAllPolSourceSiteEffectTerms.model';
import { WebAllTideLocations } from 'src/app/models/generated/models/WebAllTideLocations.model';
import { WebAllAddresses } from 'src/app/models/generated/models/WebAllAddresses.model';
import { WebAllEmails } from 'src/app/models/generated/models/WebAllEmails.model';
import { WebAllTels } from 'src/app/models/generated/models/WebAllTels.model';
import { WebLabSheets } from 'src/app/models/generated/models/WebLabSheets.model';
import { WebTideSites } from 'src/app/models/generated/models/WebTideSites.model';
import { StatMWQMRun } from 'src/app/models/generated/models/StatMWQMRun.model';
import { MWQMSiteModel } from 'src/app/models/generated/models/MWQMSiteModel.model';
import { StatMWQMSite } from 'src/app/models/generated/models/StatMWQMSite.model';
import { TVItemModel } from 'src/app/models/generated/models/TVItemModel.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { ContactModel } from '../../models/generated/models/ContactModel.model';
import { WebMonitoringOtherStatsCountry } from '../../models/generated/models/WebMonitoringOtherStatsCountry.model';
import { WebMonitoringRoutineStatsCountry } from '../../models/generated/models/WebMonitoringRoutineStatsCountry.model';
import { WebMonitoringOtherStatsProvince } from '../../models/generated/models/WebMonitoringOtherStatsProvince.model';
import { WebMonitoringRoutineStatsProvince } from '../../models/generated/models/WebMonitoringRoutineStatsProvince.model';
import { MonitoringStatsModel } from '../../models/generated/models/MonitoringStatsModel.model';
import { InfrastructureModelPath } from 'src/app/models/generated/models/InfrastructureModelPath.model';
import { MikeSourceModel } from 'src/app/models/generated/models/MikeSourceModel.model';
import { WebMWQMSamples1980_2020 } from 'src/app/models/generated/models/WebMWQMSamples1980_2020.model';
import { WebMWQMSamples2021_2060 } from 'src/app/models/generated/models/WebMWQMSamples2021_2060.model';
import { WebAllMWQMAnalysisReportParameters } from 'src/app/models/generated/models/WebAllMWQMAnalysisReportParameters.model';
import { WebAllMWQMSubsectors } from 'src/app/models/generated/models/WebAllMWQMSubsectors.model';
import { WebAllUseOfSites } from 'src/app/models/generated/models/WebAllUseOfSites.model';

@Injectable({
  providedIn: 'root'
})
export class AppLoadedService {
  BaseApiUrl = 'https://localhost:4446/api/'; 
  //BaseApiUrl = 'https://localhost:44328/api/';

  LoggedInContact?: Contact;
  BreadCrumbTVItemModelList?: TVItemModel[];

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
  WebAllMWQMAnalysisReportParameters?: WebAllMWQMAnalysisReportParameters;
  WebAllMWQMLookupMPNs?: WebAllMWQMLookupMPNs;
  WebAllMWQMSubsectors?: WebAllMWQMSubsectors;
  WebAllPolSourceGroupings?: WebAllPolSourceGroupings;
  WebAllPolSourceSiteEffectTerms?: WebAllPolSourceSiteEffectTerms;
  WebAllProvinces?: WebAllProvinces;
  WebAllReportTypes?: WebAllReportTypes;
  WebAllTels?: WebAllTels;
  WebAllTideLocations?: WebAllTideLocations;
  WebAllUseOfSites?: WebAllUseOfSites;
  WebArea?: WebArea;
  WebClimateSites?: WebClimateSites;
  WebCountry?: WebCountry;
  WebDrogueRuns?: WebDrogueRuns;
  WebHydrometricSites?: WebHydrometricSites;
  WebLabSheets?: WebLabSheets;
  WebMikeScenarios?: WebMikeScenarios;
  WebMonitoringOtherStatsCountry?: WebMonitoringOtherStatsCountry;
  WebMonitoringRoutineStatsCountry?: WebMonitoringRoutineStatsCountry;
  WebMonitoringOtherStatsProvince?: WebMonitoringOtherStatsProvince;
  WebMonitoringRoutineStatsProvince?: WebMonitoringRoutineStatsProvince;
  WebMunicipality?: WebMunicipality;
  WebMWQMRuns?: WebMWQMRuns;
  WebMWQMSamples1980_2020?: WebMWQMSamples1980_2020;
  WebMWQMSamples2021_2060?: WebMWQMSamples2021_2060;
  WebMWQMSites?: WebMWQMSites;
  WebPolSourceSites?: WebPolSourceSites;
  WebProvince?: WebProvince;
  WebRoot?: WebRoot;
  WebAllSearch?: WebAllSearch;
  WebSector?: WebSector;
  WebSubsector?: WebSubsector;
  WebTideSites?: WebTideSites;

  AdminContactModel?: ContactModel[];

  SearchResult?: TVItemModel[];

  // MWQMRunRoutingList?: MWQMRun[];
  MWQMSiteList?: MWQMSiteModel[];
  StatMWQMRunList?: StatMWQMRun[];
  StatMWQMSiteList?: StatMWQMSite[];

  MonitoringStatsModel?: MonitoringStatsModel;

  InfrastructureModelPathList?: InfrastructureModelPath[];
  TVItemModelInfrastructureList?: TVItemModel[];
  MikeSourceModelList?: MikeSourceModel[];

  constructor(public httpClient: HttpClient,
    public appStateService: AppStateService) {
  }
}
