import { Injectable } from '@angular/core';
import { AppStateService } from '../app/app-state.service';
import { TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { AscDescEnum } from 'src/app/enums/generated/AscDescEnum';
import { PredicateAscByService } from 'src/app/services/helpers/predicate-asc-by.service';
import { PredicateDescByService } from 'src/app/services/helpers/predicate-desc-by.service';
import { TVItemModel } from 'src/app/models/generated/models/TVItemModel.model';
import { AppLanguageService } from '../app/app-language.service';
import { AppLoadedService } from '../app/app-loaded.service';
import { TVItemID_TVText_Sort } from 'src/app/models/generated/models/TVItemID_TVText_Sort.model';

@Injectable({
    providedIn: 'root'
})
export class SortTVItemListService {
    constructor(private appStateService: AppStateService,
        private appLanguageService: AppLanguageService,
        private appLoadedService: AppLoadedService,
        private predicateAscByService: PredicateAscByService,
        private predicateDescByService: PredicateDescByService) {
    }

    SortTVItemList(arr: TVItemModel[]): TVItemModel[] {
        if (typeof (arr) == "undefined" || !arr || arr?.length == 0 || arr == null) return [];

        let TVTypeOfList: TVTypeEnum = arr[0].TVItem.TVType;
        let AscDesc: AscDescEnum = AscDescEnum.Ascending;

        switch (TVTypeOfList) {
            case TVTypeEnum.Area:
                {
                    AscDesc = this.appStateService.UserPreference.ProvinceAreasSortOrder;
                }
                break;
            case TVTypeEnum.Country:
                {
                    AscDesc = this.appStateService.UserPreference.RootCountriesSortOrder;
                }
                break;
            case TVTypeEnum.Infrastructure:
                {
                    AscDesc = this.appStateService.UserPreference.MunicipalityInfrastructuresSortOrder;
                }
                break;
            case TVTypeEnum.MikeScenario:
                {
                    AscDesc = this.appStateService.UserPreference.MunicipalityMikeScenariosSortOrder;
                }
                break;
            case TVTypeEnum.Municipality:
                {
                    AscDesc = this.appStateService.UserPreference.ProvinceMunicipalitiesSortOrder;
                }
                break;
            case TVTypeEnum.MWQMSite:
                {
                    AscDesc = this.appStateService.UserPreference.SubsectorMWQMSitesSortOrder;
                }
                break;
            case TVTypeEnum.MWQMRun:
                {
                    AscDesc = this.appStateService.UserPreference.SubsectorMWQMRunsSortOrder;
                }
                break;
            case TVTypeEnum.PolSourceSite:
                {
                    AscDesc = this.appStateService.UserPreference.SubsectorPolSourceSitesSortOrder;
                }
                break;
            case TVTypeEnum.Province:
                {
                    AscDesc = this.appStateService.UserPreference.CountryProvincesSortOrder;
                }
                break;
            case TVTypeEnum.Root:
                {
                    AscDesc = this.appStateService.UserPreference.RootCountriesSortOrder;
                }
                break;
            case TVTypeEnum.Sector:
                {
                    AscDesc = this.appStateService.UserPreference.AreaSectorsSortOrder;
                }
                break;
            case TVTypeEnum.Subsector:
                {
                    AscDesc = this.appStateService.UserPreference.SectorSubsectorsSortOrder;
                }
                break;
            default:
                {
                    alert(`${TVTypeEnum[TVTypeOfList]} - Not Implemented Yet. See sort-tvitem-list.service.ts -- SortTVItemList function`);
                }
                break;
        }

        let tvItemModelSorted: TVItemModel[] = [];
        let arr2: TVItemID_TVText_Sort[] = [];
        let sortable: TVItemID_TVText_Sort[] = [];

        for (let i = 0, count = arr?.length; i < count; i++) {
            sortable.push(<TVItemID_TVText_Sort>{
                TVItemID: arr[i].TVItem.TVItemID,
                TVText: arr[i].TVItemLanguageList[this.appLanguageService.LangID]?.TVText.toLowerCase(),
            });
        }

        if (AscDesc == AscDescEnum.Ascending) {
            arr2 = sortable.sort(this.predicateAscByService.PredicateAscBy('TVText'));
        }
        else {
            arr2 = sortable.sort(this.predicateDescByService.PredicateDescBy('TVText'));
        }

        for (let i = 0, count = sortable?.length; i < count; i++) {
            for (let j = 0; j < arr?.length; j++) {
                if (arr2[i].TVItemID == arr[j].TVItem.TVItemID) {
                    tvItemModelSorted.push(arr[j]);
                    break;
                }
            }
        }

        return tvItemModelSorted;
    }
}
