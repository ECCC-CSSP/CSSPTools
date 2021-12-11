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
import { TVItemModelInfrastructureModel } from 'src/app/models/generated/models/TVItemModelInfrastructureModel.model';

@Injectable({
    providedIn: 'root'
})
export class SortTVItemMunicipalityListService {
    constructor(private appStateService: AppStateService,
        private appLanguageService: AppLanguageService,
        private appLoadedService: AppLoadedService,
        private predicateAscByService: PredicateAscByService,
        private predicateDescByService: PredicateDescByService) {
    }

    SortTVItemMunicipalityList(arr: TVItemModel[]): TVItemModelInfrastructureModel {
        if (typeof (arr) == "undefined" || !arr || arr?.length == 0 || arr == null) {
            return <TVItemModelInfrastructureModel>{
                TVItemModeWithInfrastructurelList: arr,
                TVItemModelWithoutInfrastructureList: [],
            };
        }

        let TVTypeOfList: TVTypeEnum = arr[0].TVItem.TVType;
        let AscDesc: AscDescEnum = AscDescEnum.Ascending;

        AscDesc = this.appStateService.UserPreference.ProvinceMunicipalitiesSortOrder;

        let tvItemModelSorted: TVItemModel[] = [];
        let arr2: TVItemID_TVText_Sort[] = [];
        let sortable: TVItemID_TVText_Sort[] = [];

        for (let i = 0; i < arr?.length; i++) {
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

        for (let i = 0; i < sortable?.length; i++) {
            for (let j = 0; j < arr?.length; j++) {
                if (arr2[i].TVItemID == arr[j].TVItem.TVItemID) {
                    tvItemModelSorted.push(arr[j]);
                    break;
                }
            }
        }

        let TVItemModelWithInfrastructureList: TVItemModel[] = [];
        let TVItemModelWithoutInfrastructureList: TVItemModel[] = [];

        for (let i = 0, count = tvItemModelSorted?.length; i < count; i++) {
            let existArr: number[] = this.appLoadedService.WebProvince?.MunicipalityWithInfrastructureTVItemIDList.filter(c => c == tvItemModelSorted[i].TVItem.TVItemID);

            if (existArr != null && existArr?.length > 0) {
                TVItemModelWithInfrastructureList.push(tvItemModelSorted[i]);
            }
            else {
                TVItemModelWithoutInfrastructureList.push(tvItemModelSorted[i]);
            }
        }

        return <TVItemModelInfrastructureModel>{
            TVItemModeWithInfrastructurelList: TVItemModelWithInfrastructureList,
            TVItemModelWithoutInfrastructureList: TVItemModelWithoutInfrastructureList
        };
    }
}
