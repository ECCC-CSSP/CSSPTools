import { Injectable } from '@angular/core';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { MapService } from '../map/map.service';
import { WebTypeEnum } from 'src/app/enums/generated/WebTypeEnum';
import { AreaSubComponentEnum } from 'src/app/enums/generated/AreaSubComponentEnum';
import { RootSubComponentEnum } from 'src/app/enums/generated/RootSubComponentEnum';
import { CountrySubComponentEnum } from 'src/app/enums/generated/CountrySubComponentEnum';
import { ProvinceSubComponentEnum } from 'src/app/enums/generated/ProvinceSubComponentEnum';
import { SectorSubComponentEnum } from 'src/app/enums/generated/SectorSubComponentEnum';
import { SubsectorSubComponentEnum } from 'src/app/enums/generated/SubsectorSubComponentEnum';
import { MunicipalitySubComponentEnum } from 'src/app/enums/generated/MunicipalitySubComponentEnum';
import { SortTVItemListService } from '../helpers/sort-tvitem-list.service';
import { FilterService } from '../tvitem/filter.service';
import { SortTVItemMunicipalityListService } from '../helpers/sort-tvitem-municipality-list.service';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { MikeSourceModel } from 'src/app/models/generated/web/MikeSourceModel.model';
import { ClassificationService } from '../helpers/classification.service';
import { MWQMSiteService } from '../helpers/mwqm-site.service';
import { MWQMRunService } from '../helpers/mwqm-run.service';
import { PolSourceSiteService } from '../helpers/pol-source-site.service';

@Injectable({
    providedIn: 'root'
})
export class JsonDoUpdateWebMapService {

    constructor(private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private mapService: MapService,
        private sortTVItemListService: SortTVItemListService,
        private sortTVItemMunicipalityListService: SortTVItemMunicipalityListService,
        private filterService: FilterService,
        private classificationService: ClassificationService,
        private mwqmSiteService: MWQMSiteService,
        private mwqmRunService: MWQMRunService,
        private polSourceSiteService: PolSourceSiteService) {
    }

    DoUpdateWebMap(WebType) {
        if (!this.appStateService.GoogleJSLoaded) return;

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

    DoMikeSourceUpdateWebMap(MikeSourceModelList: MikeSourceModel[])
    {
        if (!this.appStateService.GoogleJSLoaded) return;

        let TVItemModelList: TVItemModel[] = [];

        this.appLoadedService.MikeSourceModelList = [];

        for(let i = 0, count = MikeSourceModelList.length; i < count; i++)
        {
            TVItemModelList.push(MikeSourceModelList[i].TVItemModel);
            this.appLoadedService.MikeSourceModelList.push(MikeSourceModelList[i]);
        }   

        this.mapService.ClearMap();
        this.mapService.DrawObjects([
            // ...this.appLoadedService.TVItemModelInfrastructureList,
            // ...[this.appLoadedService.WebMunicipality?.TVItemModel],
            ...TVItemModelList
        ]);
    }

    DoInfrastructureUpdateWebMap()
    {
        if (!this.appStateService.GoogleJSLoaded) return;

        this.mapService.ClearMap();
        this.mapService.DrawObjects([
            ...this.appLoadedService.TVItemModelInfrastructureList,
            ...[this.appLoadedService.WebMunicipality?.TVItemModel],
        ]);
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
                ...this.appLoadedService.TVItemModelInfrastructureList,
                ...[this.appLoadedService.WebMunicipality?.TVItemModel]
            ]);
        }

        if (this.appStateService.UserPreference.MunicipalitySubComponent == MunicipalitySubComponentEnum.Contacts) {
            this.mapService.DrawObjects([
                ...this.appLoadedService.TVItemModelInfrastructureList,
                ...[this.appLoadedService.WebMunicipality?.TVItemModel]
            ]);
        }

        if (this.appStateService.UserPreference.MunicipalitySubComponent == MunicipalitySubComponentEnum.MIKEScenarios) {
            this.mapService.DrawObjects([
                ...this.appLoadedService.TVItemModelInfrastructureList,
                ...[this.appLoadedService.WebMunicipality?.TVItemModel]
            ]);
        }

        if (this.appStateService.UserPreference.MunicipalitySubComponent == MunicipalitySubComponentEnum.Files) {
            this.mapService.DrawObjects([
                ...this.appLoadedService.TVItemModelInfrastructureList,
                ...[this.appLoadedService.WebMunicipality?.TVItemModel]
            ]);
        }

        // if (this.appStateService.UserPreference.MunicipalitySubComponent == MunicipalitySubComponentEnum.Files) {
        //     this.mapService.DrawObjects([
        //         ...this.sortTVItemListService.SortTVItemList(this.filterService.FilterTVItemModelList(this.appLoadedService.WebMunicipality?.TVItemModelInfrastructureList)),
        //         ...[this.appLoadedService.WebMunicipality?.TVItemModel]
        //     ]);
        // }
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
                ...this.sortTVItemListService.SortTVItemList(this.filterService.FilterTVItemModelList(this.mwqmSiteService.GetMWQMSiteTVItemModelList(this.appLoadedService.WebMWQMSites?.MWQMSiteModelList))),
                ...[this.appLoadedService.WebSubsector?.TVItemModel],
                ...this.classificationService.GetClassificationTVItemModelList(this.appLoadedService.WebSubsector?.ClassificationModelList),
            ]);
        }

        if (this.appStateService.UserPreference.SubsectorSubComponent == SubsectorSubComponentEnum.Analysis) {
            this.mapService.DrawObjects([
                ...this.sortTVItemListService.SortTVItemList(this.filterService.FilterTVItemModelList(this.mwqmSiteService.GetMWQMSiteTVItemModelList(this.appLoadedService.WebMWQMSites?.MWQMSiteModelList))),
                ...[this.appLoadedService.WebSubsector?.TVItemModel],
                ...this.classificationService.GetClassificationTVItemModelList(this.appLoadedService.WebSubsector?.ClassificationModelList),
            ]);
        }

        if (this.appStateService.UserPreference.SubsectorSubComponent == SubsectorSubComponentEnum.MWQMRuns) {
            this.mapService.DrawObjects([
                ...this.sortTVItemListService.SortTVItemList(this.filterService.FilterTVItemModelList(this.mwqmRunService.GetMWQMRunTVItemModelList(this.appLoadedService.WebMWQMRuns?.MWQMRunModelList))),
                ...[this.appLoadedService.WebSubsector?.TVItemModel],
                ...this.classificationService.GetClassificationTVItemModelList(this.appLoadedService.WebSubsector?.ClassificationModelList),
            ]);
        }

        if (this.appStateService.UserPreference.SubsectorSubComponent == SubsectorSubComponentEnum.PollutionSourceSites) {
            this.mapService.DrawObjects([
                ...this.sortTVItemListService.SortTVItemList(this.filterService.FilterTVItemModelList(this.polSourceSiteService.GetPolSourceSiteTVItemModelList(this.appLoadedService.WebPolSourceSites?.PolSourceSiteModelList))),
                ...this.classificationService.GetClassificationTVItemModelList(this.appLoadedService.WebSubsector?.ClassificationModelList),
                ...[this.appLoadedService.WebSubsector?.TVItemModel],
            ]);
        }

        if (this.appStateService.UserPreference.SubsectorSubComponent == SubsectorSubComponentEnum.Files) {
            this.mapService.DrawObjects([
                ...this.sortTVItemListService.SortTVItemList(this.filterService.FilterTVItemModelList(this.mwqmSiteService.GetMWQMSiteTVItemModelList(this.appLoadedService.WebMWQMSites?.MWQMSiteModelList))),
                ...this.classificationService.GetClassificationTVItemModelList(this.appLoadedService.WebSubsector?.ClassificationModelList),
                ...[this.appLoadedService.WebSubsector?.TVItemModel],
            ]);
        }

        if (this.appStateService.UserPreference.SubsectorSubComponent == SubsectorSubComponentEnum.SubsectorTools) {
            this.mapService.DrawObjects([
                ...this.sortTVItemListService.SortTVItemList(this.filterService.FilterTVItemModelList(this.mwqmSiteService.GetMWQMSiteTVItemModelList(this.appLoadedService.WebMWQMSites?.MWQMSiteModelList))),
                ...this.classificationService.GetClassificationTVItemModelList(this.appLoadedService.WebSubsector?.ClassificationModelList),
                ...[this.appLoadedService.WebSubsector?.TVItemModel],
            ]);
        }

        if (this.appStateService.UserPreference.SubsectorSubComponent == SubsectorSubComponentEnum.LogBook) {
            this.mapService.DrawObjects([
                ...this.sortTVItemListService.SortTVItemList(this.filterService.FilterTVItemModelList(this.mwqmSiteService.GetMWQMSiteTVItemModelList(this.appLoadedService.WebMWQMSites?.MWQMSiteModelList))),
                ...this.classificationService.GetClassificationTVItemModelList(this.appLoadedService.WebSubsector?.ClassificationModelList),
                ...[this.appLoadedService.WebSubsector?.TVItemModel],
            ]);
        }
    }

}