import { Injectable } from '@angular/core';
import { WebAllAddresses } from 'src/app/models/generated/web/WebAllAddresses.model';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { WebTypeEnum } from 'src/app/enums/generated/WebTypeEnum';
import { WebAllContacts } from 'src/app/models/generated/web/WebAllContacts.model';
import { WebAllTideLocations } from 'src/app/models/generated/web/WebAllTideLocations.model';
import { WebAllTels } from 'src/app/models/generated/web/WebAllTels.model';
import { WebAllReportTypes } from 'src/app/models/generated/web/WebAllReportTypes.model';
import { WebAllProvinces } from 'src/app/models/generated/web/WebAllProvinces.model';
import { WebAllPolSourceSiteEffectTerms } from 'src/app/models/generated/web/WebAllPolSourceSiteEffectTerms.model';
import { WebAllPolSourceGroupings } from 'src/app/models/generated/web/WebAllPolSourceGroupings.model';
import { WebAllMWQMLookupMPNs } from 'src/app/models/generated/web/WebAllMWQMLookupMPNs.model';
import { WebAllMunicipalities } from 'src/app/models/generated/web/WebAllMunicipalities.model';
import { WebAllHelpDocs } from 'src/app/models/generated/web/WebAllHelpDocs.model';
import { WebAllEmails } from 'src/app/models/generated/web/WebAllEmails.model';
import { WebAllCountries } from 'src/app/models/generated/web/WebAllCountries.model';
import { WebArea } from 'src/app/models/generated/web/WebArea.model';
import { WebClimateSites } from 'src/app/models/generated/web/WebClimateSites.model';
import { WebHydrometricSites } from 'src/app/models/generated/web/WebHydrometricSites.model';
import { WebDrogueRuns } from 'src/app/models/generated/web/WebDrogueRuns.model';
import { WebCountry } from 'src/app/models/generated/web/WebCountry.model';
import { WebLabSheets } from 'src/app/models/generated/web/WebLabSheets.model';
import { WebMikeScenarios } from 'src/app/models/generated/web/WebMikeScenarios.model';
import { WebMunicipality } from 'src/app/models/generated/web/WebMunicipality.model';
import { WebMWQMRuns } from 'src/app/models/generated/web/WebMWQMRuns.model';
import { WebMWQMSites } from 'src/app/models/generated/web/WebMWQMSites.model';
import { WebPolSourceSites } from 'src/app/models/generated/web/WebPolSourceSites.model';
import { WebProvince } from 'src/app/models/generated/web/WebProvince.model';
import { WebRoot } from 'src/app/models/generated/web/WebRoot.model';
import { WebAllSearch } from 'src/app/models/generated/web/WebAllSearch.model';
import { WebSector } from 'src/app/models/generated/web/WebSector.model';
import { WebSubsector } from 'src/app/models/generated/web/WebSubsector.model';
import { WebTideSites } from 'src/app/models/generated/web/WebTideSites.model';
import { WebMWQMSamples1980_2020 } from 'src/app/models/generated/web/WebMWQMSamples1980_2020.model';
import { WebMWQMSamples2021_2060 } from 'src/app/models/generated/web/WebMWQMSamples2021_2060.model';
import { WebMonitoringOtherStatsCountry } from 'src/app/models/generated/web/WebMonitoringOtherStatsCountry.model';
import { WebMonitoringRoutineStatsCountry } from 'src/app/models/generated/web/WebMonitoringRoutineStatsCountry.model';
import { WebMonitoringOtherStatsProvince } from 'src/app/models/generated/web/WebMonitoringOtherStatsProvince.model';
import { WebMonitoringRoutineStatsProvince } from 'src/app/models/generated/web/WebMonitoringRoutineStatsProvince.model';
import { AppLoadedService } from '../app/app-loaded.service';
import { MonitoringStatsModel } from 'src/app/models/generated/web/MonitoringStatsModel.model';
import { WebMWQMSamples } from 'src/app/models/generated/web/WebMWQMSamples.model';


@Injectable({
    providedIn: 'root'
})
export class JsonDoLoadSwitchService {

    constructor(private appStateService: AppStateService,
        private appLoadedService: AppLoadedService) {
    }

    DoLoadSwitch(WebType: WebTypeEnum) {
        let TVItemIDText = '';

        switch (WebType) {
            case WebTypeEnum.WebAllAddresses:
                {
                    this.appLoadedService.WebAllAddresses = <WebAllAddresses>{};
                }
                break;
            case WebTypeEnum.WebAllContacts:
                {
                    this.appLoadedService.WebAllContacts = <WebAllContacts>{};
                }
                break;
            case WebTypeEnum.WebAllCountries:
                {
                    this.appLoadedService.WebAllCountries = <WebAllCountries>{};
                }
                break;
            case WebTypeEnum.WebAllEmails:
                {
                    this.appLoadedService.WebAllEmails = <WebAllEmails>{};
                }
                break;
            case WebTypeEnum.WebAllHelpDocs:
                {
                    this.appLoadedService.WebAllHelpDocs = <WebAllHelpDocs>{};
                }
                break;
            case WebTypeEnum.WebAllMunicipalities:
                {
                    this.appLoadedService.WebAllMunicipalities = <WebAllMunicipalities>{};
                }
                break;
            case WebTypeEnum.WebAllMWQMLookupMPNs:
                {
                    this.appLoadedService.WebAllMWQMLookupMPNs = <WebAllMWQMLookupMPNs>{};
                }
                break;
            case WebTypeEnum.WebAllPolSourceGroupings:
                {
                    this.appLoadedService.WebAllPolSourceGroupings = <WebAllPolSourceGroupings>{};
                }
                break;
            case WebTypeEnum.WebAllPolSourceSiteEffectTerms:
                {
                    this.appLoadedService.WebAllPolSourceSiteEffectTerms = <WebAllPolSourceSiteEffectTerms>{};
                }
                break;
            case WebTypeEnum.WebAllProvinces:
                {
                    this.appLoadedService.WebAllProvinces = <WebAllProvinces>{};
                }
                break;
            case WebTypeEnum.WebAllReportTypes:
                {
                    this.appLoadedService.WebAllReportTypes = <WebAllReportTypes>{};
                }
                break;
            case WebTypeEnum.WebAllTels:
                {
                    this.appLoadedService.WebAllTels = <WebAllTels>{};
                }
                break;
            case WebTypeEnum.WebAllTideLocations:
                {
                    this.appLoadedService.WebAllTideLocations = <WebAllTideLocations>{};
                }
                break;
            case WebTypeEnum.WebArea:
                {
                    this.appLoadedService.WebArea = <WebArea>{};
                    this.appLoadedService.MonitoringStatsModel = <MonitoringStatsModel>{};
                    TVItemIDText = `/${this.appStateService.UserPreference.CurrentAreaTVItemID}`;
                }
                break;
            case WebTypeEnum.WebClimateSites:
                {
                    this.appLoadedService.WebClimateSites = <WebClimateSites>{};
                    TVItemIDText = `/${this.appStateService.UserPreference.CurrentProvinceTVItemID}`;
                }
                break;
            case WebTypeEnum.WebCountry:
                {
                    this.appLoadedService.WebCountry = <WebCountry>{};
                    this.appLoadedService.MonitoringStatsModel = <MonitoringStatsModel>{};
                    TVItemIDText = `/${this.appStateService.UserPreference.CurrentCountryTVItemID}`;
                }
                break;
            case WebTypeEnum.WebDrogueRuns:
                {
                    this.appLoadedService.WebDrogueRuns = <WebDrogueRuns>{};
                    TVItemIDText = `/${this.appStateService.UserPreference.CurrentProvinceTVItemID}`;
                }
                break;
            case WebTypeEnum.WebHydrometricSites:
                {
                    this.appLoadedService.WebHydrometricSites = <WebHydrometricSites>{};
                    TVItemIDText = `/${this.appStateService.UserPreference.CurrentProvinceTVItemID}`;
                }
                break;
            case WebTypeEnum.WebLabSheets:
                {
                    this.appLoadedService.WebLabSheets = <WebLabSheets>{};
                    TVItemIDText = `/${this.appStateService.UserPreference.CurrentSubsectorTVItemID}`;
                }
                break;
            case WebTypeEnum.WebMikeScenarios:
                {
                    this.appLoadedService.WebMikeScenarios = <WebMikeScenarios>{};
                    TVItemIDText = `/${this.appStateService.UserPreference.CurrentMunicipalityTVItemID}`;
                }
                break;
            case WebTypeEnum.WebMonitoringOtherStatsCountry:
                {
                    this.appLoadedService.WebMonitoringOtherStatsCountry = <WebMonitoringOtherStatsCountry>{};
                    TVItemIDText = `/${this.appStateService.UserPreference.CurrentCountryTVItemID}`;
                }
                break;
            case WebTypeEnum.WebMonitoringRoutineStatsCountry:
                {
                    this.appLoadedService.WebMonitoringRoutineStatsCountry = <WebMonitoringRoutineStatsCountry>{};
                    TVItemIDText = `/${this.appStateService.UserPreference.CurrentCountryTVItemID}`;
                }
                break;
            case WebTypeEnum.WebMonitoringOtherStatsProvince:
                {
                    this.appLoadedService.WebMonitoringOtherStatsProvince = <WebMonitoringOtherStatsProvince>{};
                    TVItemIDText = `/${this.appStateService.UserPreference.CurrentProvinceTVItemID}`;
                }
                break;
            case WebTypeEnum.WebMonitoringRoutineStatsProvince:
                {
                    this.appLoadedService.WebMonitoringRoutineStatsProvince = <WebMonitoringRoutineStatsProvince>{};
                    TVItemIDText = `/${this.appStateService.UserPreference.CurrentProvinceTVItemID}`;
                }
                break;
            case WebTypeEnum.WebMunicipality:
                {
                    this.appLoadedService.WebMunicipality = <WebMunicipality>{};
                    this.appLoadedService.InfrastructureModelPathList = [];
                    this.appLoadedService.TVItemModelInfrastructureList = [];
                    TVItemIDText = `/${this.appStateService.UserPreference.CurrentMunicipalityTVItemID}`;
                }
                break;
            case WebTypeEnum.WebMWQMRuns:
                {
                    this.appLoadedService.WebMWQMRuns = <WebMWQMRuns>{};
                    TVItemIDText = `/${this.appStateService.UserPreference.CurrentSubsectorTVItemID}`;
                }
                break;
            case WebTypeEnum.WebMWQMSamples1980_2020:
                {
                    this.appLoadedService.WebMWQMSamples1980_2020 = <WebMWQMSamples1980_2020>{};
                    this.appLoadedService.WebMWQMSamples = <WebMWQMSamples>{};
                    TVItemIDText = `/${this.appStateService.UserPreference.CurrentSubsectorTVItemID}`;
                }
                break;
            case WebTypeEnum.WebMWQMSamples2021_2060:
                {
                    this.appLoadedService.WebMWQMSamples2021_2060 = <WebMWQMSamples2021_2060>{};
                    TVItemIDText = `/${this.appStateService.UserPreference.CurrentSubsectorTVItemID}`;
                }
                break;
            case WebTypeEnum.WebMWQMSites:
                {
                    this.appLoadedService.WebMWQMSites = <WebMWQMSites>{};
                    TVItemIDText = `/${this.appStateService.UserPreference.CurrentSubsectorTVItemID}`;
                }
                break;
            case WebTypeEnum.WebPolSourceSites:
                {
                    this.appLoadedService.WebPolSourceSites = <WebPolSourceSites>{};
                    TVItemIDText = `/${this.appStateService.UserPreference.CurrentSubsectorTVItemID}`;
                }
                break;
            case WebTypeEnum.WebProvince:
                {
                    this.appLoadedService.WebProvince = <WebProvince>{};
                    this.appLoadedService.MonitoringStatsModel = <MonitoringStatsModel>{};
                    TVItemIDText = `/${this.appStateService.UserPreference.CurrentProvinceTVItemID}`;
                }
                break;
            case WebTypeEnum.WebRoot:
                {
                    this.appLoadedService.WebRoot = <WebRoot>{};
                }
                break;
            case WebTypeEnum.WebAllSearch:
                {
                    this.appLoadedService.WebAllSearch = <WebAllSearch>{};
                }
                break;
            case WebTypeEnum.WebSector:
                {
                    this.appLoadedService.WebSector = <WebSector>{};
                    this.appLoadedService.MonitoringStatsModel = <MonitoringStatsModel>{};
                    TVItemIDText = `/${this.appStateService.UserPreference.CurrentSectorTVItemID}`;
                }
                break;
            case WebTypeEnum.WebSubsector:
                {
                    this.appLoadedService.WebSubsector = <WebSubsector>{};
                    this.appLoadedService.MonitoringStatsModel = <MonitoringStatsModel>{};
                    TVItemIDText = `/${this.appStateService.UserPreference.CurrentSubsectorTVItemID}`;
                }
                break;
            case WebTypeEnum.WebTideSites:
                {
                    this.appLoadedService.WebTideSites = <WebTideSites>{};
                    TVItemIDText = `/${this.appStateService.UserPreference.CurrentProvinceTVItemID}`;
                }
                break;
            default:
                break;
        }

        return TVItemIDText;
    }
    }
