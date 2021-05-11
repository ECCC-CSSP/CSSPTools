import { Injectable } from '@angular/core';
import { AppStateService } from '../app-state.service';
import { TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { AscDescEnum } from 'src/app/enums/generated/AscDescEnum';
import { PredicateAscByService } from 'src/app/services/helpers/predicate-asc-by.service';
import { PredicateDescByService } from 'src/app/services/helpers/predicate-desc-by.service';
import { TVItemID_TVText_Sort } from 'src/app/models/TVItemID_TVText_Sort.model';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { AppLanguageService } from '../app-language.service';
import { AppLoadedService } from '../app-loaded.service';

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
        if (typeof (arr) == "undefined" || !arr || arr.length == 0 || arr == null) return [];

        //let TVType: TVTypeEnum = this.appLoadedService.BreadCrumbTVItemModelList[this.appLoadedService.BreadCrumbTVItemModelList.length - 1].TVItem.TVType;
        let TVTypeOfList: TVTypeEnum = arr[0].TVItem.TVType;
        let AscDesc: AscDescEnum = AscDescEnum.Ascending;


        switch (TVTypeOfList) {
            case TVTypeEnum.Area:
                {
                    AscDesc = this.appStateService.ProvinceAreasSortOrder;
                }
                break;
            case TVTypeEnum.Country:
                {
                    AscDesc = this.appStateService.RootCountriesSortOrder;
                }
                break;
            case TVTypeEnum.Infrastructure:
                {
                    AscDesc = this.appStateService.MunicipalityInfrastructuresSortOrder;
                }
                break;
            case TVTypeEnum.MikeScenario:
                {
                    AscDesc = this.appStateService.MunicipalityMikeScenariosSortOrder;
                }
                break;
            case TVTypeEnum.Municipality:
                {
                    AscDesc = this.appStateService.ProvinceMunicipalitiesSortOrder;
                }
                break;
            case TVTypeEnum.MWQMSite:
                {
                    AscDesc = this.appStateService.SubsectorMWQMSitesSortOrder;
                }
                break;
            case TVTypeEnum.MWQMRun:
                {
                    AscDesc = this.appStateService.SubsectorMWQMRunsSortOrder;
                }
                break;
            case TVTypeEnum.PolSourceSite:
                {
                    AscDesc = this.appStateService.SubsectorPolSourceSitesSortOrder;
                }
                break;
            case TVTypeEnum.Province:
                {
                    AscDesc = this.appStateService.CountryProvincesSortOrder;
                }
                break;
            case TVTypeEnum.Root:
                {
                    AscDesc = this.appStateService.RootCountriesSortOrder;
                }
                break;
            case TVTypeEnum.Sector:
                {
                    AscDesc = this.appStateService.AreaSectorsSortOrder;
                }
                break;
            case TVTypeEnum.Subsector:
                {
                    AscDesc = this.appStateService.SectorSubsectorsSortOrder;
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

        for (let i = 0; i < arr.length; i++) {
            sortable.push(<TVItemID_TVText_Sort>{
                TVItemID: arr[i].TVItem.TVItemID,
                TVText: arr[i].TVItemLanguageList[this.appLanguageService.LangID].TVText.toLowerCase(),
            });
        }

        if (AscDesc == AscDescEnum.Ascending) {
            arr2 = sortable.sort(this.predicateAscByService.PredicateAscBy('TVText'));
        }
        else {
            arr2 = sortable.sort(this.predicateDescByService.PredicateDescBy('TVText'));
        }

        for (let i = 0; i < sortable.length; i++) {
            for (let j = 0; j < arr.length; j++) {
                if (arr2[i].TVItemID == arr[j].TVItem.TVItemID) {
                    tvItemModelSorted.push(arr[j]);
                    break;
                }
            }
        }

        return tvItemModelSorted;
    }
}
