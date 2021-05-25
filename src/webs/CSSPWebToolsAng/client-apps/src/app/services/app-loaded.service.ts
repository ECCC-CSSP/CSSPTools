import { Contact } from 'src/app/models/generated/db/Contact.model';
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
import { WebAllSearch } from '../models/generated/web/WebAllSearch.model';
import { WebSector } from 'src/app/models/generated/web/WebSector.model';
import { WebSubsector } from 'src/app/models/generated/web/WebSubsector.model';
import { WebAllCountries } from 'src/app/models/generated/web/WebAllCountries.model';
import { WebAllMunicipalities } from 'src/app/models/generated/web/WebAllMunicipalities.model';
import { WebAllProvinces } from 'src/app/models/generated/web/WebAllProvinces.model';
import { WebAllReportTypes } from 'src/app/models/generated/web/WebAllReportTypes.model';
import { WebAllContacts } from 'src/app/models/generated/web/WebAllContacts.model';
import { WebAllHelpDocs } from 'src/app/models/generated/web/WebAllHelpDocs.model';
import { WebAllMWQMLookupMPNs } from 'src/app/models/generated/web/WebAllMWQMLookupMPNs.model';
import { WebAllPolSourceGroupings } from 'src/app/models/generated/web/WebAllPolSourceGroupings.model';
import { WebAllPolSourceSiteEffectTerms } from 'src/app/models/generated/web/WebAllPolSourceSiteEffectTerms.model';
import { WebAllTideLocations } from 'src/app/models/generated/web/WebAllTideLocations.model';
import { WebAllAddresses } from 'src/app/models/generated/web/WebAllAddresses.model';
import { WebAllEmails } from 'src/app/models/generated/web/WebAllEmails.model';
import { WebAllTels } from 'src/app/models/generated/web/WebAllTels.model';
import { WebLabSheets } from 'src/app/models/generated/web/WebLabSheets.model';
import { WebMWQMSamples } from 'src/app/models/generated/web/WebMWQMSamples.model';
import { WebTideSites } from 'src/app/models/generated/web/WebTideSites.model';
import { StatMWQMRun } from 'src/app/models/generated/web/StatMWQMRun.model';
import { MWQMSiteModel } from 'src/app/models/generated/web/MWQMSiteModel.model';
import { StatMWQMSite } from 'src/app/models/generated/web/StatMWQMSite.model';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AppStateService } from 'src/app/services/app-state.service';
import { ContactModel } from '../models/generated/web/ContactModel.model';
import { WebMonitoringRoutineStatsByYearForCountry } from '../models/generated/web/WebMonitoringRoutineStatsByYearForCountry.model';
import { WebMonitoringRoutineStatsByYearForProvince } from '../models/generated/web/WebMonitoringRoutineStatsByYearForProvince.model';
import { WebMonitoringOtherStatsByYearForCountry } from '../models/generated/web/WebMonitoringOtherStatsByYearForCountry.model';
import { WebMonitoringOtherStatsByYearForProvince } from '../models/generated/web/WebMonitoringOtherStatsByYearForProvince.model';
import { MonitoringStatsByYearModel } from '../models/generated/web/MonitoringStatsByYearModel.model';

@Injectable({
  providedIn: 'root'
})
export class AppLoadedService {
  //BaseApiUrl = 'https://localhost:4447/api/'; 
  BaseApiUrl = 'https://localhost:44346/api/';

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
  WebAllMWQMLookupMPNs?: WebAllMWQMLookupMPNs;
  WebAllPolSourceGroupings?: WebAllPolSourceGroupings;
  WebAllPolSourceSiteEffectTerms?: WebAllPolSourceSiteEffectTerms;
  WebAllProvinces?: WebAllProvinces;
  WebAllReportTypes?: WebAllReportTypes;
  WebAllTels?: WebAllTels;
  WebAllTideLocations?: WebAllTideLocations;
  WebArea?: WebArea;
  WebClimateSites?: WebClimateSites;
  WebCountry?: WebCountry;
  WebDrogueRuns?: WebDrogueRuns;
  WebHydrometricSites?: WebHydrometricSites;
  WebLabSheets?: WebLabSheets;
  WebMikeScenarios?: WebMikeScenarios;
  WebMonitoringOtherStatsByYearForCountry?: WebMonitoringOtherStatsByYearForCountry;
  WebMonitoringRoutineStatsByYearForCountry?: WebMonitoringRoutineStatsByYearForCountry;
  WebMonitoringOtherStatsByYearForProvince?: WebMonitoringOtherStatsByYearForProvince;
  WebMonitoringRoutineStatsByYearForProvince?: WebMonitoringRoutineStatsByYearForProvince;
  WebMunicipality?: WebMunicipality;
  WebMWQMRuns?: WebMWQMRuns;
  WebMWQMSamples1980_2020?: WebMWQMSamples;
  WebMWQMSamples2021_2060?: WebMWQMSamples;
  WebMWQMSamples?: WebMWQMSamples;
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

  MonitoringStatsByYearModel?: MonitoringStatsByYearModel;

  constructor(public httpClient: HttpClient,
    public appStateService: AppStateService) {
  }
}
