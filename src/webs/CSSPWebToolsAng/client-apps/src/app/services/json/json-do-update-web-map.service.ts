import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { WebAllAddresses } from 'src/app/models/generated/web/WebAllAddresses.model';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { MapService } from '../map/map.service';
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
import { HistoryService } from '../helpers/history.service';
import { AreaSubComponentEnum } from 'src/app/enums/generated/AreaSubComponentEnum';
import { RootSubComponentEnum } from 'src/app/enums/generated/RootSubComponentEnum';
import { CountrySubComponentEnum } from 'src/app/enums/generated/CountrySubComponentEnum';
import { ProvinceSubComponentEnum } from 'src/app/enums/generated/ProvinceSubComponentEnum';
import { SectorSubComponentEnum } from 'src/app/enums/generated/SectorSubComponentEnum';
import { SubsectorSubComponentEnum } from 'src/app/enums/generated/SubsectorSubComponentEnum';
import { MunicipalitySubComponentEnum } from 'src/app/enums/generated/MunicipalitySubComponentEnum';
import { WebMWQMSamples } from 'src/app/models/generated/web/WebMWQMSamples.model';
import { SortTVItemListService } from '../helpers/sort-tvitem-list.service';
import { FilterService } from '../tvitem/filter.service';
import { SortTVItemMunicipalityListService } from '../helpers/sort-tvitem-municipality-list.service';
import { StatService } from '../helpers/stat.service';
import { WebMonitoringOtherStatsCountry } from 'src/app/models/generated/web/WebMonitoringOtherStatsCountry.model';
import { WebMonitoringRoutineStatsCountry } from 'src/app/models/generated/web/WebMonitoringRoutineStatsCountry.model';
import { WebMonitoringOtherStatsProvince } from 'src/app/models/generated/web/WebMonitoringOtherStatsProvince.model';
import { WebMonitoringRoutineStatsProvince } from 'src/app/models/generated/web/WebMonitoringRoutineStatsProvince.model';
import { MonitoringStatsModel } from 'src/app/models/generated/web/MonitoringStatsModel.model';
import { JsonLoadListService } from './json-loading-list.service';
import { JsonDataIsLoadedService } from './json-data-is-loaded.service';


@Injectable({
    providedIn: 'root'
})
export class JsonDoUpdateWebMapService {

    constructor(private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private mapService: MapService,
        private sortTVItemListService: SortTVItemListService,
        private sortTVItemMunicipalityListService: SortTVItemMunicipalityListService,
        private filterService: FilterService) {
    }

    DoUpdateWebMap(WebType) {
        this.mapService.ClearMap();
        switch (WebType) {
            case WebTypeEnum.WebArea: this.DoUpdateWebAreaMap(); break;
            case WebTypeEnum.WebCountry: this.DoUpdateWebCountryMap(); break;
            case WebTypeEnum.WebMunicipality: this.DoUpdateWebMunicipalityMap(); break;
            case WebTypeEnum.WebProvince: this.DoUpdateWebProvinceMap(); break;
            case WebTypeEnum.WebRoot: this.DoUpdateWebRootMap(); break;
            case WebTypeEnum.WebSector: this.DoUpdateWebSectorMap(); break;
            case WebTypeEnum.WebSubsector: this.DoUpdateWebSubsectorMap(); break;
            default: break;
        }
    }

    private DoUpdateWebAreaMap() {
        if (this.appStateService.UserPreference.AreaSubComponent == AreaSubComponentEnum.Sectors) {
            this.mapService.DrawObjects([
                ...this.sortTVItemListService.SortTVItemList(this.filterService.FilterTVItemModelList(this.appLoadedService.WebArea?.TVItemModelSectorList)),
                ...[this.appLoadedService.WebArea?.TVItemModel]
            ]);
        }

        if (this.appStateService.UserPreference.AreaSubComponent == AreaSubComponentEnum.Files) {
            this.mapService.DrawObjects([
                ...this.sortTVItemListService.SortTVItemList(this.filterService.FilterTVItemModelList(this.appLoadedService.WebArea?.TVItemModelSectorList)),
                ...[this.appLoadedService.WebArea?.TVItemModel]
            ]);
        }
    }

    private DoUpdateWebCountryMap() {
        if (this.appStateService.UserPreference.CountrySubComponent == CountrySubComponentEnum.Provinces) {
            this.mapService.DrawObjects([
                ...this.sortTVItemListService.SortTVItemList(this.filterService.FilterTVItemModelList(this.appLoadedService.WebCountry?.TVItemModelProvinceList)),
                ...[this.appLoadedService.WebCountry?.TVItemModel]
            ]);
        }

        if (this.appStateService.UserPreference.CountrySubComponent == CountrySubComponentEnum.Files) {
            this.mapService.DrawObjects([
                ...this.sortTVItemListService.SortTVItemList(this.filterService.FilterTVItemModelList(this.appLoadedService.WebCountry?.TVItemModelProvinceList)),
                ...[this.appLoadedService.WebCountry?.TVItemModel]
            ]);
        }

        if (this.appStateService.UserPreference.CountrySubComponent == CountrySubComponentEnum.OpenDataNational) {
            this.mapService.DrawObjects([
                ...this.sortTVItemListService.SortTVItemList(this.filterService.FilterTVItemModelList(this.appLoadedService.WebCountry?.TVItemModelProvinceList)),
                ...[this.appLoadedService.WebCountry?.TVItemModel]
            ]);
        }

        if (this.appStateService.UserPreference.CountrySubComponent == CountrySubComponentEnum.EmailDistributionList) {
            this.mapService.DrawObjects([
                ...this.sortTVItemListService.SortTVItemList(this.filterService.FilterTVItemModelList(this.appLoadedService.WebCountry?.TVItemModelProvinceList)),
                ...[this.appLoadedService.WebCountry?.TVItemModel]
            ]);
        }

        if (this.appStateService.UserPreference.CountrySubComponent == CountrySubComponentEnum.RainExceedance) {
            this.mapService.DrawObjects([
                ...this.sortTVItemListService.SortTVItemList(this.filterService.FilterTVItemModelList(this.appLoadedService.WebCountry?.TVItemModelProvinceList)),
                ...[this.appLoadedService.WebCountry?.TVItemModel]
            ]);
        }
    }

    private DoUpdateWebMunicipalityMap() {
        if (this.appStateService.UserPreference.MunicipalitySubComponent == MunicipalitySubComponentEnum.Infrastructures) {
            this.mapService.DrawObjects([
                ...this.sortTVItemListService.SortTVItemList(this.filterService.FilterTVItemModelList(this.appLoadedService.WebMunicipality?.TVItemModelInfrastructureList)),
                ...[this.appLoadedService.WebMunicipality?.TVItemModel]
            ]);
        }

        if (this.appStateService.UserPreference.MunicipalitySubComponent == MunicipalitySubComponentEnum.Contacts) {
            this.mapService.DrawObjects([
                ...this.sortTVItemListService.SortTVItemList(this.filterService.FilterTVItemModelList(this.appLoadedService.WebMunicipality?.TVItemModelInfrastructureList)),
                ...[this.appLoadedService.WebMunicipality?.TVItemModel]
            ]);
        }

        if (this.appStateService.UserPreference.MunicipalitySubComponent == MunicipalitySubComponentEnum.MIKEScenarios) {
            this.mapService.DrawObjects([
                ...this.sortTVItemListService.SortTVItemList(this.filterService.FilterTVItemModelList(this.appLoadedService.WebMunicipality?.TVItemModelInfrastructureList)),
                ...[this.appLoadedService.WebMunicipality?.TVItemModel]
            ]);
        }

        if (this.appStateService.UserPreference.MunicipalitySubComponent == MunicipalitySubComponentEnum.Files) {
            this.mapService.DrawObjects([
                ...this.sortTVItemListService.SortTVItemList(this.filterService.FilterTVItemModelList(this.appLoadedService.WebMunicipality?.TVItemModelInfrastructureList)),
                ...[this.appLoadedService.WebMunicipality?.TVItemModel]
            ]);
        }
    }

    private DoUpdateWebProvinceMap() {
        if (this.appStateService.UserPreference.ProvinceSubComponent == ProvinceSubComponentEnum.Areas) {
            this.mapService.DrawObjects([
                ...this.sortTVItemListService.SortTVItemList(this.filterService.FilterTVItemModelList(this.appLoadedService.WebProvince?.TVItemModelAreaList)),
                ...[this.appLoadedService.WebProvince?.TVItemModel]
            ]);
        }

        if (this.appStateService.UserPreference.ProvinceSubComponent == ProvinceSubComponentEnum.Municipalities) {
            this.mapService.DrawObjects([
                ...(this.sortTVItemMunicipalityListService.SortTVItemMunicipalityList(this.filterService.FilterTVItemModelList(this.appLoadedService.WebProvince?.TVItemModelMunicipalityList)).TVItemModeWithInfrastructurelList),
                ...[this.appLoadedService.WebProvince?.TVItemModel]
            ]);
        }

        if (this.appStateService.UserPreference.ProvinceSubComponent == ProvinceSubComponentEnum.Files) {
            this.mapService.DrawObjects([
                ...this.sortTVItemListService.SortTVItemList(this.filterService.FilterTVItemModelList(this.appLoadedService.WebProvince?.TVItemModelAreaList)),
                ...[this.appLoadedService.WebProvince?.TVItemModel]
            ]);
        }

        if (this.appStateService.UserPreference.ProvinceSubComponent == ProvinceSubComponentEnum.OpenData) {
            this.mapService.DrawObjects([
                ...this.sortTVItemListService.SortTVItemList(this.filterService.FilterTVItemModelList(this.appLoadedService.WebProvince?.TVItemModelAreaList)),
                ...[this.appLoadedService.WebProvince?.TVItemModel]
            ]);
        }

        if (this.appStateService.UserPreference.ProvinceSubComponent == ProvinceSubComponentEnum.SamplingPlan) {
            this.mapService.DrawObjects([
                ...this.sortTVItemListService.SortTVItemList(this.filterService.FilterTVItemModelList(this.appLoadedService.WebProvince?.TVItemModelAreaList)),
                ...[this.appLoadedService.WebProvince?.TVItemModel]
            ]);
        }

        if (this.appStateService.UserPreference.ProvinceSubComponent == ProvinceSubComponentEnum.ProvinceTools) {
            this.mapService.DrawObjects([
                ...this.sortTVItemListService.SortTVItemList(this.filterService.FilterTVItemModelList(this.appLoadedService.WebProvince?.TVItemModelAreaList)),
                ...[this.appLoadedService.WebProvince?.TVItemModel]
            ]);
        }
    }

    private DoUpdateWebRootMap() {
        if (this.appStateService.UserPreference.RootSubComponent == RootSubComponentEnum.Countries) {
            this.mapService.DrawObjects([
                ...this.sortTVItemListService.SortTVItemList(this.filterService.FilterTVItemModelList(this.appLoadedService.WebRoot?.TVItemModelCountryList)),
                ...[this.appLoadedService.WebRoot?.TVItemModel]
            ]);
        }

        if (this.appStateService.UserPreference.RootSubComponent == RootSubComponentEnum.Files) {
            this.mapService.DrawObjects([
                ...this.sortTVItemListService.SortTVItemList(this.filterService.FilterTVItemModelList(this.appLoadedService.WebRoot?.TVItemModelCountryList)),
                ...[this.appLoadedService.WebRoot?.TVItemModel]
            ]);
        }

        if (this.appStateService.UserPreference.RootSubComponent == RootSubComponentEnum.ExportArcGIS) {
            this.mapService.DrawObjects([
                ...this.sortTVItemListService.SortTVItemList(this.filterService.FilterTVItemModelList(this.appLoadedService.WebRoot?.TVItemModelCountryList)),
                ...[this.appLoadedService.WebRoot?.TVItemModel]
            ]);
        }
    }

    private DoUpdateWebSectorMap() {
        if (this.appStateService.UserPreference.SectorSubComponent == SectorSubComponentEnum.Subsectors) {
            this.mapService.DrawObjects([
                ...this.sortTVItemListService.SortTVItemList(this.filterService.FilterTVItemModelList(this.appLoadedService.WebSector?.TVItemModelSubsectorList)),
                ...[this.appLoadedService.WebSector?.TVItemModel]
            ]);
        }
    }

    private DoUpdateWebSubsectorMap() {
        if (this.appStateService.UserPreference.SubsectorSubComponent == SubsectorSubComponentEnum.MWQMSites) {
            this.mapService.DrawObjects([
                ...this.sortTVItemListService.SortTVItemList(this.filterService.FilterTVItemModelList(this.appLoadedService.WebSubsector?.TVItemModelMWQMSiteList)),
                ...[this.appLoadedService.WebSubsector?.TVItemModel],
                ...this.appLoadedService.WebSubsector?.TVItemModelClassificationList,
            ]);
        }

        if (this.appStateService.UserPreference.SubsectorSubComponent == SubsectorSubComponentEnum.Analysis) {
            this.mapService.DrawObjects([
                ...this.sortTVItemListService.SortTVItemList(this.filterService.FilterTVItemModelList(this.appLoadedService.WebSubsector?.TVItemModelMWQMSiteList)),
                ...[this.appLoadedService.WebSubsector?.TVItemModel],
                ...this.appLoadedService.WebSubsector?.TVItemModelClassificationList,
            ]);
        }

        if (this.appStateService.UserPreference.SubsectorSubComponent == SubsectorSubComponentEnum.MWQMRuns) {
            this.mapService.DrawObjects([
                ...this.sortTVItemListService.SortTVItemList(this.filterService.FilterTVItemModelList(this.appLoadedService.WebSubsector?.TVItemModelMWQMRunList)),
                ...[this.appLoadedService.WebSubsector?.TVItemModel],
                ...this.appLoadedService.WebSubsector?.TVItemModelClassificationList,
            ]);
        }

        if (this.appStateService.UserPreference.SubsectorSubComponent == SubsectorSubComponentEnum.PollutionSourceSites) {
            this.mapService.DrawObjects([
                ...this.sortTVItemListService.SortTVItemList(this.filterService.FilterTVItemModelList(this.appLoadedService.WebSubsector?.TVItemModelPolSourceSiteList)),
                ...this.appLoadedService.WebSubsector?.TVItemModelClassificationList,
                ...[this.appLoadedService.WebSubsector?.TVItemModel],
            ]);
        }

        if (this.appStateService.UserPreference.SubsectorSubComponent == SubsectorSubComponentEnum.Files) {
            this.mapService.DrawObjects([
                ...this.sortTVItemListService.SortTVItemList(this.filterService.FilterTVItemModelList(this.appLoadedService.WebSubsector?.TVItemModelMWQMSiteList)),
                ...this.appLoadedService.WebSubsector?.TVItemModelClassificationList,
                ...[this.appLoadedService.WebSubsector?.TVItemModel],
            ]);
        }

        if (this.appStateService.UserPreference.SubsectorSubComponent == SubsectorSubComponentEnum.SubsectorTools) {
            this.mapService.DrawObjects([
                ...this.sortTVItemListService.SortTVItemList(this.filterService.FilterTVItemModelList(this.appLoadedService.WebSubsector?.TVItemModelMWQMSiteList)),
                ...this.appLoadedService.WebSubsector?.TVItemModelClassificationList,
                ...[this.appLoadedService.WebSubsector?.TVItemModel],
            ]);
        }

        if (this.appStateService.UserPreference.SubsectorSubComponent == SubsectorSubComponentEnum.LogBook) {
            this.mapService.DrawObjects([
                ...this.sortTVItemListService.SortTVItemList(this.filterService.FilterTVItemModelList(this.appLoadedService.WebSubsector?.TVItemModelMWQMSiteList)),
                ...this.appLoadedService.WebSubsector?.TVItemModelClassificationList,
                ...[this.appLoadedService.WebSubsector?.TVItemModel],
            ]);
        }
    }

}